using System.Text;
using ExamTaskDockerUiDb.Constants;
using ExamTaskDockerUiDb.Models;

namespace ExamTaskDockerUiDb.Utilities
{
    public static class ApiApplicationRequest
    {
        public static Dictionary<string, string> ApiMethods = JsonUtils.GetDataFromJson(FileConstants.PathToApiMethods);
        private static readonly string host = FileUtils.TestData.ApiHost;


        public static string GetAccessToken(GetAccessTokenModel model)
        {
            LoggerUtils.LogStep(nameof(GetAccessToken) + " 'Send request to get access token'");

            string request = host + ApiMethods["getToken"] + "?" + "variant=" + model.Variant;

            var stringContent = JsonUtils.SerializeJsonData(model);
            var httpContent = new StringContent(stringContent, Encoding.UTF8, FileConstants.MediaType);
            HttpResponseMessage response = ApiUtils.PostRequest(request, httpContent);

            if (!IsStatusCodeCorrect((int)StatusCodes.OK, response))
            {
                LoggerUtils.LogStep(nameof(GetAccessToken) + $" 'Invalid status code - [{response.StatusCode}]'");
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public static bool IsStatusCodeCorrect(int expectedStatusCode, HttpResponseMessage response)
        {
            LoggerUtils.LogStep(nameof(IsStatusCodeCorrect) + " 'Check status code'");
            return (int)response.StatusCode == expectedStatusCode;
        }
    }
}
