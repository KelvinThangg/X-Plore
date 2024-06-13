using Google.Cloud.Firestore;
using loginIndian.Classes;
using Microsoft.CodeAnalysis.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using Amazon.SecurityToken;
using System.Net;
using X_Plore.Chat;
using X_Plore.Class;
using X_Plore.Main;

namespace X_Plore.Class
{
    internal class AWSS3
    {
        string AccessKey = "ASIAZD7PBJSZRVLRTUVV";
        string SecretKey = "KZs07vZDyFVFYrgj22Tlk3pDMpkk6Ot2EVRzypT0";
        string SessionToken = "IQoJb3JpZ2luX2VjEPr//////////wEaCXVzLXdlc3QtMiJHMEUCIQCtIU395HZCvYINn7Q4++nWBBsG3JIfIXMrt0TpJJkNdwIgU35KP/1rz9QmACHTtr2WZACfIlEeIWR0+rT9RCcGOuUquQIIk///////////ARAAGgw2MjcwMjk2NTg4MDMiDGoOfPqBsfwWSovDvyqNAoBLUE45tHR75Jg/d8BXhLDpkYzHS56a/D4UKhtVzcQLHY9JU/y8vWTFu1O5+Fg/CkSvNCMJvwLlCzIk6E3QV4CWcCAcSeAap4yqu7yP/fgv9EtPAPplr5dpHEJ1v9XnHwyB8vMrxaQ2QOXe/ZlkyMnbrp8xa1xVW3RdDagIwFB2MtsO1QW3fp95P36GM0qzqEz966n1FTEfv30mbuWZciXZgPrsWflf/tJd+lEnnPlnPe7qJD0BLUJ2MNSYvBG5G88j4fV18UNfVnFlof/mx1leFCjhfAeZRRV9yYKzzKm6ClQwRjOqnOsFoeKvPXzmeKXPa9fOvKNJ27VAFsMNG/cE+tiCQ+MPp1H6QLB+MOHZrLMGOp0BnNpxbcafHNmOuB1dO1ZfhMVotwzh2x1elSFnMZrmswcC3Uxeg8c66WXvek+itTz6sQYmr6XGJerV5JLB8RvTSJfkQ5ILuDakTopYW2KcZ2aPHSN2o8AGm+QkP991sOEe5gHw7ny1/ZLeP227RCnMnXp1di/s70GNNOK233vaFrGUDi6vEZWxSfM61r18/dL7crlLXv8Jo9lmNNm6Zg==";
        string BucketName = "xplorer-bucket";
       public string GetAccessKey()
        {
            return AccessKey;
        }
        public string GetSecretKey()
        {
            return SecretKey;
        }
        public string GetSessionToken()
        {
            return SessionToken;
        }
        public string GetBucketName()
        {
            return BucketName;
        }
      
        
    }
 }
       


