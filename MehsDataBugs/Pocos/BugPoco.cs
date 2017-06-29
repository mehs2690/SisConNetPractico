using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehsDataBugs.Pocos
{
    [Table("Bug")]
    public class BugPoco
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BugRegistredDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BugClosedDate { get; set; }

        public Guid? AppId { get; set; }
        public Guid? UserRegId { get; set; }
        public Guid? UserSolId { get; set; }

        public BugPoco()
        {

        }
    }
}
