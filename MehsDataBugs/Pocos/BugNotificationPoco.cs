using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataBugs.Pocos
{
    [Table("BugNotification")]
    public class BugNotificationPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public string Status { get; set; }

        public BugNotificationPoco()
        {

        }
    }
}
