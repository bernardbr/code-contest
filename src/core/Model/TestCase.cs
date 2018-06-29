namespace core.Model
{
    public class TestCase
    {
        public long Id { get; set; }

        public long ContestId { get; set; }

        public int Timeout { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        public int Order { get; set; }
    }
}