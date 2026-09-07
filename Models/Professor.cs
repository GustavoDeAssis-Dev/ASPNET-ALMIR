using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBuddies.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Nome com no máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
