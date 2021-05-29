using System;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Client
{
    class Program
    {
        private static async Task RequestAsync(string command)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:8080/?command=" + command);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using(Stream stream = response.GetResponseStream())
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    Console.Write(reader.ReadToEnd());
                }
            }
            response.Close();
        }
        public static async Task Main()
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                try
                {
                    await RequestAsync(command);
                }
                catch (WebException)
                {
                    Console.WriteLine("Connection failed. Press Enter to try reconnect.");
                    Console.ReadLine();
                    continue;
                }
                command = Console.ReadLine();
            }
        }
    }
}
