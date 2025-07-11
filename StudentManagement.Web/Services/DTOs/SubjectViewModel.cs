using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Web.Services.DTOs
{
    public class SubjectViewModel
    {
        [Required(ErrorMessage = "El campo Código es obligatorio.")]
        [StringLength(4, ErrorMessage = "Solo se permiten letras.")]
        [DisplayName("Código")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Créditos es obligatorio.")]
        [Range(1, 4, ErrorMessage = "El rango permitido es entre 1 y 4")]
        [DisplayName("Créditos")]
        public int Credits { get; set; }
    }
}
