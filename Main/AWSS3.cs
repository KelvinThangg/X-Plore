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
        string AccessKey = "ASIAZD7PBJSZ7DY6DAYO";
        string SecretKey = "i40KAtN7V5S5/bxu3cJawjBu9efaQcT3IqmYvf6t";
        string SessionToken = "IQoJb3JpZ2luX2VjEOD//////////wEaCXVzLXdlc3QtMiJGMEQCIGjdVy35A30kf+hmze9M5ug8W75SsEQG0zLwc/L/0L5UAiAR/UURSjFrZgh6S8n5XCVX7BQt64r7vOuwJz5xdkCftiqwAgh5EAAaDDYyNzAyOTY1ODgwMyIMzEK5bWE87bNKOyCHKo0CJVIfjFFmBF5Z6S1qK9QDmoKCg+VA4CHtEba/gsx0ioP5yZsfbd/SSZV8WLDZIaj8RI/8k2SNDC8srrRYMWjwqf4/XUxHYqqOio8AVEQah0j5TKmO75v2GR7zxREV1m9tGhuq3P9zUwueWA6crFFz4BBxZerseHsq7TsePty9ktfED867xsNrU5uIpwHwktN+KYU55dIHJmSSBjcsxhwTEOZR+eRJvqRGU74F0SE3tWAUnMjS0eK2zuWt7//qycVQS94uXxbNi61YHlqedcE8io8DV/JtGCj1D+1JJfMaotPnHJUFFMSRbHM0PQeO/Wtvi38KkcCDGRBqNlygun+6/6HmL+Mr6AryV3HZyS0w4oOnswY6ngHA0ibqopx+D41j24cZeslTpFu+bBTGWj7MHn4VfMZDyjgaXq9Buf3y54Jsy5l0OA/ePELFB9C9Sg3mfWWa8tg6QNEA+TJagyBZqhuSoNCcJXFkD8tn8+jXKDTIX06EO9yeSNyZQljNWQMql/A57vpRKt6//LKA1uy+baFJV43lOxBsptdIfBQBQCFM9v2uYxvEMM3USQRo9Zsz4oMPPA==";
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
       


