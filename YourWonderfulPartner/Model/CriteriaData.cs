using System.ComponentModel.DataAnnotations;

namespace YourWonderfulPartner.Model
{
    public class CriteriaData
    {
        [Key]
        public int CriteriaId { get; set; }
        public int? Age_Min{ get; set; }
        public int? Age_Max { get; set; }
        public string? Sex{ get; set; }
        public int? Height_Min { get; set; }
        public int? Heigth_Max { get; set; }
        public int? Weight_Min { get; set; }
        public int? Weigth_Max { get; set; }
        public string? Haircolor { get; set; }
        public string? Postcode1 { get; set; }
        public string? Postcode2 { get; set; }
        public string? Postcode3 { get; set; }
        public int? UserId { get; set; }
    }
}

