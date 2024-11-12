namespace Entities.models
{
    public class feedbackmodel
    {
        public Guid id { get; set; }

        public string name { get; set; }
        public string email { get; set; }

        public string description { get; set; }

        public string number { get; set; }

        public Guid userId { get; set; }

    }
}
