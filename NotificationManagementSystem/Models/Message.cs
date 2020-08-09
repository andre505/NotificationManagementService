using NotificationManagementSystem.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationManagementSystem.Models
{
    [Table("messages")]
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string To { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string From { get; set; }
        [StringLength(100)]
        public string SenderName { get; set; }
        [StringLength(255)]
        public string Subject { get; set; }
        [Required]
        [StringLength(8192, MinimumLength = 3)]
        public string Body { get; set; }
        public MessageType MessageType { get; set; }
        public bool? Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }

    public class MessageRequest
    {
   
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string To { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string From { get; set; }
        [StringLength(100)]
        public string SenderName { get; set; }
        [StringLength(255)]
        public string Subject { get; set; }
        [Required]
        [StringLength(8192, MinimumLength = 3)]
        public string Body { get; set; }
        public MessageType MessageType { get; set; }

    }

    public class MessageResponse
    {
        public string status { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string TimeStamp { get; set; }

    }
}
