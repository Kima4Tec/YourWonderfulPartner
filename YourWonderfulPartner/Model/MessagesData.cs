using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourWonderfulPartner.Model
    {
        public class MessagesData
        {
            [Key]
        public int MessageId { get; set; }
        public string Message { get; set; } = null!;
        public int ReceiverId { get; set; } = 0;
        public int UserId { get; set; } = 0;
    }
    }



