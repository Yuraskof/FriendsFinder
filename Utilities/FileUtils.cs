using LinkedInFriend.Constants;
using System.Text;
using LinkedInFriend.Constants;
using LinkedInFriend.Models;


namespace LinkedInFriend.Utilities
{
    public static class FileUtils
    {
        public static readonly TestData TestData = JsonUtils.ReadJsonDataFromPath<TestData>(FileConstants.PathToTestData);
        public static readonly LoginUser LoginUser = JsonUtils.ReadJsonDataFromPath<LoginUser>(FileConstants.PathToLoginUser);
        public static Dictionary<string, string> SqlRequests = JsonUtils.GetDataFromJson(FileConstants.PathToSqlRequests);
        public static readonly string SessionId = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();


        public static void ClearLogFile()
        {
            FileInfo file = new(FileConstants.PathToLogFile);

            if (file.Exists)
            {
                file.Delete();
                LoggerUtils.LogStep(nameof(ClearLogFile) + $" 'Log file deleted - [{file}]'");
            }
        }

        public static ByteArrayContent ReadImage(string path)
        {
            LoggerUtils.LogStep(nameof(ReadImage) + $" 'Image - [{path}] read'");
            byte[] imgdata = File.ReadAllBytes(path);
            return new(imgdata);
        }

        public static string ReadFile(string path)
        {
            LoggerUtils.LogStep(nameof(ReadFile) + $" 'File - [{path}] read'");
            StreamReader sr = new(path, Encoding.UTF8);
            return sr.ReadToEnd();
        }
    }
}