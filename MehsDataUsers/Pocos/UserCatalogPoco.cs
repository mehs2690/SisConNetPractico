using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataUsers.Pocos
{
    [Table("UsermCatalog")]
    public class UserCatalogPoco
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public UserCatalogPoco()
        {

        }
    }
}
