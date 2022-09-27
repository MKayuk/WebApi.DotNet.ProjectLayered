using System.ComponentModel.DataAnnotations;

namespace Base.Application.ViewModel
{
    public record BasePost
    {
        [Required(ErrorMessage = "Cpf is required.")]
        public string Cpf { get; init; }
    }
}
