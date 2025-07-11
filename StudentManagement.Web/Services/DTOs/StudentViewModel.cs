using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Web.Services.DTOs
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "El campo Código es obligatorio.")]
        [RegularExpression(@"^[0-9]{5,12}$", ErrorMessage = "El documento debe contener entre 5 y 12 caracteres.")] 
        [DisplayName("Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression("^[a-zA-ZñÑáéíóúÁÉÍÓÚ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        public IEnumerable<string> SelectedSubjectCodes { get; set; } = Enumerable.Empty<string>();
    }
}
