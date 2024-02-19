using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.BusinessEntities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Llenalo todo webi wabo")]
        [StringLength(50, ErrorMessage ="50 cara de sapo")]
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Ad>  Ads { get; set; } = new List<Ad>();

    }
}
