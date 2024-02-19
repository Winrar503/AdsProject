using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.BusinessEntities
{
    public class AdImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Ad")]
        [Required(ErrorMessage = "La referencia del enunciado es requirido")]
        [Display(Name = "Anuncion")]
        public int IdAd {  get; set; }

        [Required(ErrorMessage = " La ruta de la imagen es requerida")]
        [MaxLength(500, ErrorMessage = "Maximo 4000 caracteres")]
        [Display(Name = "Imagen")]
        public string Path { get; set; } = string.Empty;



        public int Top_Aux { get; set; }
        public Ad Ad { get; set; } = new Ad();
    }
}
