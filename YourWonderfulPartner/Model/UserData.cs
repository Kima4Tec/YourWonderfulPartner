using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourWonderfulPartner.Model
    {
        public class UserData
        {
            [Key]
            public int UserId { get; set; }
            public string Name { get; set; } = null!;
            public DateOnly? Birthday { get; set; } = null!;
            public string? Sex { get; set; } = null!;
            public decimal? Height { get; set; }
            public int? Weight { get; set; }
            public string? Haircolor { get; set; }
            public string Postcode { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string UserName { get; set; } = null!;
            public string Password { get; set; } = null!;
            public byte[]? PictureData { get; set; }
            public string? PictureName { get; set; }

            [NotMapped]
            public int Age
            {
                get
                {
                    if (Birthday == null)
                        return 0;

                    var today = DateOnly.FromDateTime(DateTime.Today);
                    int age = today.Year - Birthday.Value.Year;

                    if (today < Birthday.Value.AddYears(age))
                    {
                        age--;
                    }

                    return age;
                }
            }
        }
    }



