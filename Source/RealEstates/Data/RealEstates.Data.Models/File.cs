namespace RealEstates.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}