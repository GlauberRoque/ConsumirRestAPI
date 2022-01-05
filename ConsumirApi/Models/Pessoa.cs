using System.ComponentModel.DataAnnotations;

namespace ConsumirApi.Models
{
    public class Pessoa
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome da pessoa: ")]
        [StringLength(100, MinimumLength = 6)]
        public string Nome { get; set; }


    }
}
