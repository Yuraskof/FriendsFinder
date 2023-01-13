using LinkedInFriend.Utilities;

namespace LinkedInFriend.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StatusId { get; set; }
        public string MethodName { get; set; }
        public int SessionId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Env { get; set; }
        public string Browser { get; set; }
        public int ProjectId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            TestModel other = (TestModel)obj;

            if (Name.Equals(other.Name) && MethodName.Equals(other.MethodName) &&
                StartTime.Equals(other.StartTime) && Env.Equals(other.Env) && Browser.Equals(other.Browser))
            {
                LoggerUtils.LogStep(nameof(Equals) + " 'Test models are equal'");
                return true;
            }
            LoggerUtils.LogStep(nameof(Equals) + " 'Test models are not equal'");
            return false;
        }
    }
}
