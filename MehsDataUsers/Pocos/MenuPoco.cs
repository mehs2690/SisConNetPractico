using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MehsDataUsers.Pocos
{
    [Table("Menum")]
    public class MenuPoco
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Index]
        public int Order { get; set; }
        public string Icon { get; set; }
        public string StyleClass { get; set; }
        public string EventOn { get; set; }
        public string Estatus { get; set; }
        public string OptionType { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }

        public int? ParentRefId { get; set; }

        [ForeignKey("ParentRefId")]
        public virtual MenuPoco Parent { get; set; }

        public MenuPoco()
        {

        }
    }
}
