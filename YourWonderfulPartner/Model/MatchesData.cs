using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourWonderfulPartner.Model
    {
        public class MatchesData
        {
            [Key]
        public int Id { get; set; }
        public int MatchesId { get; set; }
        public int UserId { get; set; }

    }
    }



