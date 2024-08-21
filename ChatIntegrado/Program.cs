using ChatIntegrado;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// A�adiendo servicios al contenedor.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); // Configuraci�n de SignalR aqu�

var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor HSTS predeterminado es de 30 d�as. Puede que desees cambiar esto para entornos de producci�n.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear rutas para controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Mapear los concentradores de SignalR
app.MapHub<PruebaHub>("/PruebaHub");

app.Run();

