namespace Allspring.OMS.Api.Model
{
    public record FileMetadata()
    {
        public string Extention { get; set; }
        public char Delimiter{ get; set; }
        public bool ShouldHaveHeader{ get; set; }

        public string FolderName { get; set; }

        public string FileName{ get; set; }

        public string HeaderLine { get; set; }
    }
}
