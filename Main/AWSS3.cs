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
        string AccessKey = "ASIAZD7PBJSZWTY3QB3C";
        string SecretKey = "smv7XztvKKpNQUvtu6sxrtqVPlQ5O0Zs0FgsWRGj";
        string SessionToken = "IQoJb3JpZ2luX2VjEJb//////////wEaCXVzLXdlc3QtMiJHMEUCIQCG2zBKg4u9hUlx9kU2ZgfJQUDaAFCrcJvzD7Cx4U6zXgIgWdOqu6Vi7xFE+iN3KLt/MX/p4WZnsPMjJiWFWgCQEpAqsAIILxAAGgw2MjcwMjk2NTg4MDMiDB43iRfSq0ZzosTV+SqNAsryYK8khac9aElK/DyKx2enWf3Vjw+56PgxBua9kr7IJbMwEgYfdBdojOaFu/XZvz6WwrKwWelojMshPRGGVK3tEc29iCoHOAr8UDEQ40s0eTy/fTTa4NCLxJRQ8svNHFg34ME4p1FkU4VmB8ek4Ix5SKh0LmGoxwKPYAUgl6c0rkWBX3wSbZrjhhveG+lWS/iIhZowXEEv6DNKi1w6BaOaQ01MdMAzg4950q7Ph1xvMbMFwJFjsnm1QoW2vK6RYFzHIcdqTUDYjIDln4xR79XAPE+GRxHMHP4mrjyGitGqnaYbE84dLbmcWEzWC6JpaTkiR0+KGybWMxB09k9bVkhAz8kyBydUXxTNLPEcMNrylrMGOp0BJomxBEfxWAeftZPXGbMwbFZFBphflCjKPDExWtCbxqtAF2ctNPrfmVlJyz+OA2NmbJfLyfUXf5mrdbGHWxXw14IdsDoQz5OdsUfLC2CLXpcJeN/DVUn28SIuDInM1rIsWD+A42ATBnFAEYrDe7zNa4zMcBviHhkn08C7/iPz3ep1CwqxC3Sda3GMPLtaxIaF/LZ87K7y6P4aajiG/A==";
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
       


