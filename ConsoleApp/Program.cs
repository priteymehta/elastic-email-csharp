using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        
        public static string USERNAME = "USERNAME";
        public static string API_KEY = "APIKEY";

        public static void Main(string[] args)
        {
            string from = "FROM_EMAIL";
            string fromName = "Your Company Name";
            string to = "TOEMAILS";
            string subject = "Your Subject";
            string bodyHtml = "<h1>Html Body</h1>";
            string bodyText = "Text Body";

            string result = SendEmail(to, subject, bodyText, bodyHtml, from, fromName);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string SendEmail(string to, string subject, string bodyText, string bodyHtml, string from, string fromName)
        {
            try
            {
                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", USERNAME);
                values.Add("api_key", API_KEY);
                values.Add("from", from);
                values.Add("from_name", fromName);
                values.Add("subject", subject);
                if (bodyHtml != null)
                    values.Add("body_html", bodyHtml);
                if (bodyText != null)
                    values.Add("body_text", bodyText);
                values.Add("to", to);

                byte[] response = client.UploadValues("https://api.elasticemail.com/mailer/send", values);
                return Encoding.UTF8.GetString(response);

            }
            catch(Exception ex)
            {
                return "";
            }         
        }
    }
}
    

