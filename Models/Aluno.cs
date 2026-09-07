using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBuddies.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Nome com no máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Idade")]
        [Range(5, 8, ErrorMessage = "A idade deve estar entre 5 e 8 anos")]
        public int Idade { get; set; }

        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        [Display(Name = "Professor")]
        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }

        public virtual ICollection<Progresso> Progressos { get; set; } = new List<Progresso>();
        public virtual Ranking Ranking { get; set; }
    }
}
