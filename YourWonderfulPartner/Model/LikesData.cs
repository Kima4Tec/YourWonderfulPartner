using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourWonderfulPartner.Model
    {
        public class LikesData
        {
            [Key]
        public int Id { get; set; }
        public int LikesId { get; set; } = 0;
        public int UserId { get; set; } = 0;
    }
    }



