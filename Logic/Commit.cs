namespace GitViz.Logic
{
    public class Commit
    {
        public string Hash { get; set; }
        public string[] ParentHashes { get; set; }
        public string[] Refs { get; set; }
        public long CommitDate { get; set; }
        public string Subject { get; set; }
        public string AuthorName { get; set; }

        public string ShortHash
        {
            get { return Hash.Substring(0, 7); }
        }
    }
}
