﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataUsers.Pocos
{
    [Table("Userm")]
    public class UserPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Estatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SignUpDate { get; set; }

        public virtual ICollection<ApplicationPoco> Apps { get; set; }
        public virtual ICollection<UserCatalogPoco> Types { get; set; }

        public UserPoco()
        {
            Id = Guid.NewGuid();
            SignUpDate = DateTime.Now;
            Apps = new HashSet<ApplicationPoco>();
            Types = new HashSet<UserCatalogPoco>();
        }
    }
}
