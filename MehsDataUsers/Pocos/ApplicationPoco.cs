using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataUsers.Pocos
{
    [Table("Applicationm")]
    public class ApplicationPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activate { get; set; }
        public string Estatus { get; set; }
        public string Url { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<UserPoco> Users { get; set; }

        public ApplicationPoco()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Users = new HashSet<UserPoco>();
        }
    }
}
