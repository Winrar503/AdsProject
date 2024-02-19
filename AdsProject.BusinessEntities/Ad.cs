using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.BusinessEntities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Category")]
        [Required(ErrorMessage = "La categoría es requerid<")]
      
        [Display(Name = "Categoria")]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = " La categroia es requerid<")]
        [MaxLength(200, ErrorMessage = "Maximo 200 caracteres")]
        [Display(Name = "Categoria")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "  El titulo es requerid<")]
        [MaxLength(500, ErrorMessage = "Maximo 500 caracteres")]
        [Display(Name = "Categoria")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = " La descripcion es requerid<")]
        [MaxLength(500, ErrorMessage = "Maximo 500 caracteres")]
        [Display(Name = "Descripcion")]
        public decimal Price { get; set; } 
        [Required(ErrorMessage = " La fecha es requerid<")]
        [Display(Name = "Fecha")]
        public DateTime RegidtrationDate { get; set; }
        public string State { get; set; } = string.Empty;




        [NotMapped]
        public int Top_Aux {  get; set; }
        public Category Category { get; set; } = new Category();    
        public List<AdImage>    AdImages { get; set; } = new List<AdImage>();
    }
}
