using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.DTOs {
    public class StateDTO {
        [Required]
        [MaxLength(100,ErrorMessage="Nome do estado deve ter no máximo 100 caracteres")]
        public string Name { get; set; }
        [Required]
        [MaxLength(2,ErrorMessage="Iniciais do estado devem ter no máximo 2 caracteres")]
        public string Initials { get; set; }
    }
}
