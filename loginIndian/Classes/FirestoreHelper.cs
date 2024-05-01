using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginIndian.Classes
{
    internal static class FirestoreHelper
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""xplore-24c71"",
          ""private_key_id"": ""ee5dd3248142859195b9f0b04220b266d22aba16"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEuwIBADANBgkqhkiG9w0BAQEFAASCBKUwggShAgEAAoIBAQCcnHKhVdDIwHNt\nVbPdf07aNcL5XLQHvGJg5fNEaw2kdZmn9LXRyd5Ye27cZASlzFJ6TALusHhxvVWh\nyTgj4KEHLfkMwXNbRKKry+WD3nYMbvkHBL+gHvhil//6ojaNO4P6bFOskw7RQCWf\nW/8WA4zYJF2CAkVrb3YDAKiwnTpIQXIesI4H7OFUS4Q8m+8XjKx/g/kSa7JPiXNk\nOO67RPOquDotkf20hbiJlvqv1LjSc0EXMT760wGJXY2vSHcKX1KepzutSkonnwZZ\nNLVDFLFF1fZJsjPuIkRSdzYpCloFxGDYdxn8Tc+wWgnZCe5y/RrimKqnWqQxLlK5\nSryN5feDAgMBAAECgf9bw09nOOEcv6biaVT6c53APcAAXFEgN0FthU8Ex7U2p7Fg\nuAHQ6nddYPWULQaMHyw0fFU7hisMeeOy6DP80aGIk2daEf+FerHV96KDodWJc3x2\noFGngH4JRwa11FYiarzp/o8IjyIfeXaR6VWNkIb2Hlir1KjYSnbbS4eL9JQxwTxX\nLfuWmaQvf6SCKa4uHVUEG/VRNg917BZb+PJbuva18418dZBbUZ0P7DQPABNjFK6y\nMFrho2RicBy9HxK9nGO9M3017G78u5Ex04VKSUf1siQeQlTZ+nfKjcofmh74Da+o\nFDQxi9zex9u6FlbltZ6SUnTXDgJUTWu9+xy7DYECgYEAzuceVS4oMe2sMcQ7GBQR\nlhHQYXgDxHacjXIhS1Xi/DjM3+nAEysz+zaymbhayIyIbG01KfSxr1WLmXNIHpWL\nXiiMzeaaqgtaKAB+fmHn5/nGEMf70+hQlDS08vrGZYfzO2ygI1jh2r9SU9EAv+3W\npElhdeT0jO6iaCJApKUznyMCgYEAwcY47HJfmZR2p8qhXvYtadUOFuAXEj9a5Xcc\nPG53mohAPIE9WciqiXk69y9y4fVv1Qt7/reij5qCmXq/0CiRLC8fKM6D2/741DsG\n6eGBJQmKmrsOWrbInAeI84SjHHobHxboRK4WhwD/pBkyB0sKRlUMfd6KMDRcjlqe\n0m2I/CECgYEAse/eDE+XzeijEGG8mKaZwUAsv8ZhJxMC7DpdG9cPUO7gcykqQNIE\n8GVIEB+WI6eIpAb/k8eXED03w457VaIyq5WgEmviU59Tt9dE8hftQ3lxt3jlwIao\n1ezGObkl6qeSrWZsCjokcuXbPa4fQPCgicV6BdQT5ShNj9T1VyOkU5UCgYB+uAx9\nxAX0v3whGogRO9hS/3tpRj6QNlJRAWW7t1oL+tJXPwVJ88pigJ8pCySL1B/AKPR7\njMeINbj2eal6jSzywhYUb4kXk1RSJg/NXyU/fU/hBDbM5/+k2eCbr7+jXc7is+5N\nC7O7sdF8FOX8kvwzJmc24RNplrR4e5alcfBFQQKBgBg8qSz4eV4jrKes5YmUSd/1\n36MqsYyLgGXvAOt5eTCvf3prgoUk0o5EPhV1kVxGkOwqRbjdhe06BzvdDEn1qGMo\n8nmzHf6ay3yIUllvG0S9MyfjdN6ptyhXWsrCKR2utfOoPsWF5b1kYLUOprHKpVTS\nwcP+gAorGxKuopEugO6Y\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-xznci@xplore-24c71.iam.gserviceaccount.com"",
          ""client_id"": ""107858674860445824719"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-xznci%40xplore-24c71.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";

        static string filepath = "";
        public static FirestoreDb? Database {  get; private set; }

        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) +".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            Database = FirestoreDb.Create("xplore-24c71");
            File.Delete(filepath);
        }
    }
}
