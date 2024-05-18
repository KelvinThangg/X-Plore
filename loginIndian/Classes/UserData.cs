using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginIndian.Classes
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public string Gender { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Phone { get; set; }
        [FirestoreProperty("isLoggedIn")]
        public bool IsLoggedIn { get; set; }
        [FirestoreProperty]
        public string DisplayName { get; set; }

        [FirestoreProperty("2FAEnable")]
        public bool Is2FAEnabled { get; set; } = false;
        [FirestoreProperty]
        public string Key { get; set; }
    }
}
