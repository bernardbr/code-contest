namespace core.Model
{
    using System;

    public class Contest
    {
        public Contest()
        {
            this.PublicId = Guid.NewGuid().ToString();
        }

        public long Id { get; set; }

        public string PublicId { get; set; }

        public string ProblemDescription { get; set; }

        public string StartupProject { get; set; }
    }
}