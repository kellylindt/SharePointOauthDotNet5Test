//using Microsoft.SharePoint.Client;
//using System;
//using System.Security;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    public class SharePointRepository 
//    {
//        private readonly string sharepointSiteUrl;
//        private readonly string SharepointFolderUrl;
//        //TODO: change to Service Account
//        private readonly string ServiceAccountUsername;
//        private readonly string ServiceAccountPassword;
//        private readonly string azureApplicationId;

//        public SharePointRepository()
//        {
//            this.sharepointSiteUrl = "https://cffoundation.sharepoint.com/CRMDEV";
//            this.SharepointFolderUrl = "https://cffoundation.sharepoint.com/CRMDEV";
//            this.ServiceAccountUsername = "svc_CP-Int@cff.org";
//            this.ServiceAccountPassword = "yhVYxj6Leex\"q:K6Xp92";
//            this.azureApplicationId = "9b260f60-1c9a-42a8-8ed2-f19ca2f9a2b6";
//        }

//        public ClientContext GetNewClientContext()
//        {
//            Uri site = new Uri(sharepointSiteUrl);
//            string username = ServiceAccountUsername;
//            string rawPassword = ServiceAccountPassword;
//            SecureString password = new SecureString();
//            foreach (char c in rawPassword) password.AppendChar(c);
//            string azureAppId = azureApplicationId;

//            SharepointAuthenticationManager authManager = new SharepointAuthenticationManager();
//            var context = authManager.GetContext(site, username, password, azureAppId);
//            return context;
//        }


//        public async Task CreateSharepointDocumantLocationAsync(ClientContext clientContext, string folderName)
//        {
//            try
//            {

//                var sharepointWebContext = clientContext.Web;
//                var sharepointList = sharepointWebContext.Lists.GetByTitle(SharepointFolderUrl);
//                var newFolder = sharepointList.RootFolder.Folders.Add(folderName);
//                sharepointWebContext.Context.Load(newFolder);
//                await sharepointWebContext.Context.ExecuteQueryAsync();
//            }
//            catch (Exception ex)
//            {
//                //logger.LogError(ex, "create sharepoint folder fail {@folderName}", folderName);
//                throw;
//            }
//        }

//        public async Task UploadPdfToFolder(ClientContext clientContext, string folderName, byte[] pdf)
//        {
//            try
//            {

//                var sharepointWebContext = clientContext.Web;
//                var sharepointList = sharepointWebContext.Lists.GetByTitle(SharepointFolderUrl);

//                var folder = sharepointList.RootFolder.Folders.GetByUrl(folderName);
//                //clientContext.Load(sharepointWebContext);
//                //clientContext.Load(sharepointList);
//                clientContext.Load(folder);


//                FileCreationInformation newFile = new FileCreationInformation();

//                // The next line of code causes an exception to be thrown for files larger than 2 MB.
//                newFile.Content = pdf;
//                newFile.Url = $"CV_Signup_{DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss")}.pdf";


//                File uploadFile = folder.Files.Add(newFile);
//                clientContext.Load(uploadFile);
//                await clientContext.ExecuteQueryAsync().ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                //logger.LogError(ex, "upload CV singup pdf failed {@folderName}", folderName);
//                throw;
//            }
//        }

//        private SecureString GetPassword(string password)
//        {
//            SecureString securePassword = new SecureString();
//            foreach (char c in password)
//            {
//                securePassword.AppendChar(c);
//            }
//            return securePassword;
//        }


//    }
//}
