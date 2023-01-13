using ExamTaskDockerUiDb.Models;
using LinkedInFriend.Utilities;
using MySql.Data.MySqlClient;

namespace ExamTaskDockerUiDb.Utilities
{
    public static class ResponseParser
    {
        public static List<TestModel> ParseToTestModel(MySqlDataReader reader)
        {
            LoggerUtils.LogStep(nameof(ParseToTestModel) + " 'Start parsing response from database to test models'");
            List<TestModel> testModels = new();
            DateTime startTime = DateTime.Now;

            while (reader.Read() || DateTime.Now > startTime.AddSeconds(Convert.ToInt32(FileUtils.TestData.MaxSecondsForWhileExecution)))
            {
                TestModel testModel = new();
                testModel.Id = Convert.ToInt32(reader[0].ToString());
                testModel.ProjectId = Convert.ToInt32(reader[1].ToString());
                testModel.Name = reader[2].ToString();
                testModel.StatusId = reader[3].ToString();
                testModel.MethodName = reader[4].ToString();
                testModel.SessionId = Convert.ToInt32(reader[5].ToString());
                testModel.StartTime = StringUtils.ConvertDateTime(reader[6].ToString());
                testModel.EndTime = reader[7].ToString();
                testModel.Env = reader[8].ToString();
                testModel.Browser = reader[9].ToString();

                testModels.Add(testModel);
            }
            return testModels;
        }

        public static string ParseToString(MySqlDataReader reader)
        {
            LoggerUtils.LogStep(nameof(ParseToProjectModel) + " 'Start parsing response from database to string'");
            reader.Read();
            string result = reader[0].ToString();
            return result;
        }

        public static List<ProjectModel> ParseToProjectModel(MySqlDataReader reader)
        {
            LoggerUtils.LogStep(nameof(ParseToProjectModel) + " 'Start parsing response from database to project models'");
            List<ProjectModel> testModels = new();
            int iterations = 0;

            while (reader.Read() || iterations < Convert.ToInt32(FileUtils.TestData.MaxSecondsForWhileExecution))
            {
                ProjectModel model = new();

                model.Name = reader[0].ToString();
                model.Id = Convert.ToInt32(reader[1].ToString());
                
                testModels.Add(model);
                iterations++;
            }
            return testModels;
        }
    }
}
