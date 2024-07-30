using System.ComponentModel.DataAnnotations;

namespace YourWonderfulPartner.Model
{
    public class UserData
    {
        [Key]
        public int BrugerId { get; set; }
        public string? Name { get; set; }
        public DateOnly? Birthday { get; set; }
        public int? Age { get; set; }
        public string? Sex { get; set; }
        public decimal? Height { get; set; }
        public int? Weight { get; set; }
        public string? Haircolor { get; set; }
        public string? Postcode { get; set; }

        public byte[]? PictureData { get; set; }
        public string? PictureName { get; set; }
    }
}
