using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Plore.Chat.CS
{
    public class MessageNode
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsFile { get; set; } = false;
        public string FileName { get; set; }
        public bool IsDisplayed { get; set; }
    }

    public class Room
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string AppId { get; set; } // Mã định danh ứng dụng
        public List<MessageNode> Messages { get; set; } // Danh sách tin nhắn trong phòng
        public Room()
        {
            Messages = new List<MessageNode>();
        }
    }

    public class Users
    {
        public string UserName { get; set; }
        public List<string> RoomNames { get; set; } // Danh sách tên phòng mà người dùng tham gia
        public List<string> FoundRooms { get; set; } // Danh sách các phòng mà người dùng đã tìm thấy
        public Users()
        {
            RoomNames = new List<string>();
            FoundRooms = new List<string>();
        }
    }
}
