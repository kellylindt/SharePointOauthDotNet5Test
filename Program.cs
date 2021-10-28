using System;
using System.Security;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test();
        }

        static void Test()
        {
            const string siteUrl = "https://cffoundation.sharepoint.com/CRMDEV";
            const string folderUrl = "https://cffoundation.sharepoint.com/CRMDEV";
            const string username = "svc_CP-Int@cff.org";
            const string password = "yhVYxj6Leex\"q:K6Xp92";
            const string azureAppId = "9b260f60-1c9a-42a8-8ed2-f19ca2f9a2b6";

            Uri site = new Uri(siteUrl);
            SecureString passwordstring = new SecureString();
            foreach (char c in password) passwordstring.AppendChar(c);

            var authenticationManager = new SharepointAuthenticationManager();
            var context = authenticationManager.GetContext(site, username, passwordstring, azureAppId);
            var folder = context.Web.GetFolderByServerRelativeUrl(folderUrl);

            context.Load(folder);
            context.ExecuteQuery();

            Console.WriteLine(context != null);
            Console.WriteLine(folder != null);
            Console.ReadLine();
        }
    }
}
