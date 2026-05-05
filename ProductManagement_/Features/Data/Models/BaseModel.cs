namespace ProductManagement_.Features.Data.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public string? UpdatedAt { get; set; }
    }
}
