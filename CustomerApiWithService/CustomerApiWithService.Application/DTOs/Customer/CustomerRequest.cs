using System.ComponentModel.DataAnnotations;

namespace CustomerApiWithService.Application.DTOs.Customer
{
    public class CustomerRequest
    {
        // Properties
        [Required(ErrorMessage = "FirsrName é requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName é requerido")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "E-mail é requerido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone inválido")]
        [Required(ErrorMessage = "Phone é requerido")]
        public string Phone { get; set; }
    }
}
