using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBuddies.Models
{
    [Table("FaseJogo")]
    public class FaseJogo
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Título da fase")]
        [StringLength(100, ErrorMessage = "Título com no máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string TituloFase { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(500, ErrorMessage = "Descrição com no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Nível de dificuldade")]
        [StringLength(30)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NivelDificuldade { get; set; }

        public virtual ICollection<Progresso> Progressos { get; set; } = new List<Progresso>();
    }
}
