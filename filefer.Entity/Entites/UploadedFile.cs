namespace filefer.Entity.Entites
{
    public class UploadedFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
