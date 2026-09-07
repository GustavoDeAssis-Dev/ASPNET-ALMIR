using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBuddies.Models
{
    [Table("Progresso")]
    public class Progresso
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [Display(Name = "Aluno")]
        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }

        [Display(Name = "Fase")]
        public int FaseJogoId { get; set; }

        [Display(Name = "Fase")]
        [ForeignKey("FaseJogoId")]
        public virtual FaseJogo FaseJogo { get; set; }

        [Display(Name = "Nota")]
        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10")]
        public float Nota { get; set; }

        [Display(Name = "Concluído")]
        public bool Concluido { get; set; }
    }
}
