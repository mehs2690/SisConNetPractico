using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataUsers.Pocos
{
    [Table("Profilem")]
    public class ProfilePoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Estatus { get; set; }
        public int Range { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public Guid? ApplicationId { get; set; }

        public ProfilePoco()
        {

        }
    }
}
