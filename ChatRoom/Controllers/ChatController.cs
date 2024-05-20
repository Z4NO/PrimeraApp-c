using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        public static Dictionary<int, string> Rooms = new Dictionary<int, string>()
        {
            {1, "Room 1"},
            {2, "Room 2"},
            {3, "Room 3"}
        };

        public IActionResult Index()
        {
            return View(Rooms);
        }

        public IActionResult Room(int room)
        {
            if (!Rooms.ContainsKey(room))
            {
                return NotFound();
            }
            return View("Room", room);
        }
    }
}
