namespace ExamTaskDockerUiDb.Utilities
{
    public static class ApiUtils
    {
        public static HttpResponseMessage PostRequest(string request, HttpContent content) 
        {
            LoggerUtils.LogStep(nameof(PostRequest) + $" 'Post request - [{request}]'");
            HttpClient client = new();
            HttpResponseMessage response = client.PostAsync(request, content).Result;
            client.Dispose();
            return response;
        }
    }
}
