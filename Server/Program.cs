using Firebase.Database;
using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Khởi tạo đối tượng FirebaseClient
            var firebaseClient = new FirebaseClient("https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/");

            try
            {
                // Truy cập vào "rooms" node trên Firebase
                var rooms = await firebaseClient.Child("rooms").OnceAsync<Room>();

                // Hiển thị thông tin của các room
                foreach (var room in rooms)
                {
                    Console.WriteLine($"Room Name: {room.Object.Name}, Password: {room.Object.Password}, Admin: {room.Object.IsAdmin}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class Room
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}