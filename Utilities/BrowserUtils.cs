namespace ExamTaskDockerUiDb.Utilities
{
    public static class BrowserUtils
    {
        public static string CreateUrlWithCredentials()
        {
            LoggerUtils.LogStep(nameof(CreateUrlWithCredentials) + " 'Create url with credentials'");
            return "http://" + FileUtils.LoginUser.Login  + ":" + FileUtils.LoginUser.Password + "@" + FileUtils.TestData.Url;
        }
    }
}
