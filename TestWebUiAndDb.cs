using System.Diagnostics;
using Aquality.Selenium.Browsers;
using LinkedInFriend.Base;
using LinkedInFriend.Constants;
using LinkedInFriend.Models;
using LinkedInFriend.Utilities;
using OpenQA.Selenium;

namespace LinkedInFriend
{
    public class TestWebUiAndDb:BaseTest
    {
        [Test(Description = "ET-0001 Checking the website functionality using UI and Database")]
        public void TestWebUiAndDatabase()
        {
            //GetAccessTokenModel model = ModelUtils.CreateGetAccessTokenModel();
            //string accessToken = ApiApplicationRequest.GetAccessToken(model);
            //Assert.NotNull(accessToken, "Acess token should be exist");
            //LoggerUtils.Logger.Info("Step 1 completed.");

            //AqualityServices.Browser.GoTo(BrowserUtils.CreateUrlWithCredentials());
            //AqualityServices.Browser.Maximize();
            //AllProjectsPage allProjectsPage = new();
            //Assert.IsTrue(allProjectsPage.State.WaitForDisplayed(), $"{allProjectsPage.Name} should be presented");
            //AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", accessToken));
            //AqualityServices.Browser.Refresh();
            //string footerText = allProjectsPage.GetFooterText();
            //Assert.IsTrue(StringUtils.SeparateString(footerText, ':')[1] == FileUtils.TestData.Variant, "Values should be equal");
            //LoggerUtils.Logger.Info("Step 2 completed.");

            //allProjectsPage.GoToProjectPage(FileUtils.TestData.ProjectName);
            //ProjectPage projectPage = new();
            //projectPage.State.WaitForDisplayed();
            //List<TestModel> testModelsFromPage = projectPage.GetTestsNames();
            //List<TestModel> testModelsFromDb = ResponseParser.ParseToTestModel(DataBaseUtils.SendRequest(FileUtils.SqlRequests["projectId1Tests"]));

            //Assert.Multiple(() =>
            //{
            //    Assert.IsTrue(ModelUtils.IsModelsDatesDescending(testModelsFromPage), "Dates should be descending");
            //    Assert.IsTrue(ModelUtils.IsDbContainsModelsFromPage(testModelsFromPage, testModelsFromDb), "Values should be equal");
            //});
            //LoggerUtils.Logger.Info("Step 3 completed.");

            //AqualityServices.Browser.GoBack();
            //allProjectsPage.State.WaitForDisplayed();
            //allProjectsPage.OpenAddProjectForm();
            //allProjectsPage.SwitchToNewFrame();
            //ProjectModel projectModel = new();
            //projectModel.Name = EnvironmentUtil.GetProjectName();
            //allProjectsPage.AddProjectForm.State.WaitForDisplayed();
            //allProjectsPage.AddProjectForm.AddProject(projectModel.Name);
            //Assert.IsTrue(allProjectsPage.AddProjectForm.IsProjectSuccessfullyAdded(), "Success message should be presented");
            //allProjectsPage.CloseAddProjectForm();
            //Assert.IsTrue(allProjectsPage.AddProjectForm.State.WaitForNotDisplayed(), $"{allProjectsPage.AddProjectForm.Name} shouldn't be presented");
            //AqualityServices.Browser.Refresh();
            //Assert.IsTrue(allProjectsPage.IsProjectPresented(EnvironmentUtil.GetProjectName()), "Project should be presented");
            //LoggerUtils.Logger.Info("Step 4 completed.");

            //allProjectsPage.GoToProjectPage(EnvironmentUtil.GetProjectName());
            //projectModel.Id = Convert.ToInt32(ResponseParser.ParseToString(DataBaseUtils.SendRequest(StringUtils.CreateGetProjectIdByNameRequest(EnvironmentUtil.GetProjectName()))));
            
            //SessionModel sessionModel = new();
            //sessionModel.BuildNumber = EnvironmentUtil.GetBuildNumber();
            //sessionModel.SessionKey = FileUtils.SessionId;
            //DataBaseUtils.SendRequest(StringUtils.CreateSessionSqlRequest(sessionModel));
            //sessionModel.Id = Convert.ToInt32(ResponseParser.ParseToString(DataBaseUtils.SendRequest(StringUtils.CreateGetSessionIdRequest(sessionModel))));

            //TestModel testModel = new();
            //StackFrame sf = new();
            //testModel.SessionId = sessionModel.Id;
            //testModel.ProjectId = projectModel.Id;
            //testModel.Name = EnvironmentUtil.GetTestName();
            //testModel.Env = EnvironmentUtil.GetHostName();
            //testModel.Browser = EnvironmentUtil.GetBrowserName();
            //testModel.MethodName = StringUtils.SeparateString(sf.GetMethod().ToString(), ' ')[1];
            //DataBaseUtils.SendRequest(StringUtils.CreateSendTestSqlRequest(testModel));
            //testModel = ResponseParser.ParseToTestModel(DataBaseUtils.SendRequest(StringUtils.CreateGetTestModelSqlRequest(testModel)))[0];

            //AqualityServices.Browser.Driver.GetScreenshot().SaveAsFile(FileConstants.PathToScreenshot + "screenshot.png");
            //string screenshotString = AqualityServices.Browser.Driver.GetScreenshot().AsBase64EncodedString;
            //DataBaseUtils.SendRequest(StringUtils.CreateSendAttachmentsSqlRequest(screenshotString, FileUtils.TestData.ImageContentType, testModel.Id));
            //string logs = StringUtils.ConvertLogsToString();
            //DataBaseUtils.SendRequest(StringUtils.CreateSendLogsSqlRequest(logs, testModel.Id));
            //Assert.IsTrue(projectPage.IsProjectSuccessfullyAdded(testModel), "Project should exist");
            //LoggerUtils.Logger.Info("Step 5 completed.");

            //projectPage.GoToTestPage(testModel);
            //projectPage.TestPage.State.WaitForDisplayed();

            //Assert.Multiple(() =>
            //{
            //    Assert.IsTrue(projectPage.TestPage.GetProjectName() == projectModel.Name, "Names should be eqal");
            //    Assert.IsTrue(projectPage.TestPage.IsStatusTextboxEnabled(testModel), "Wrong status");
            //    Assert.IsTrue(projectPage.TestPage.IsEndTimeHasCorrectValue(testModel), "Wrong end time");
            //    Assert.IsTrue(projectPage.TestPage.IsDurationHasCorrectValue(testModel), "Wrong duration time");
            //    Assert.IsTrue(StringUtils.FormatLogs(logs).Contains(projectPage.TestPage.GetLogs()), "Logs should be equal");
            //    Assert.IsTrue(projectPage.TestPage.GetImage().Contains(screenshotString), "Images should be equal");
            //    TestModel tessTestModelFromPage = projectPage.TestPage.GeTestModel();
            //    Assert.IsTrue(tessTestModelFromPage.Equals(testModel), "Models should be equal");
            //});
            //LoggerUtils.Logger.Info("Step 6 completed.");
        }
    }
}