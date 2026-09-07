using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBuddies.Models
{
    [Table("Ranking")]
    public class Ranking
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

        [Display(Name = "Pontos")]
        [Range(0, int.MaxValue)]
        public int Pontos { get; set; }

        [Display(Name = "Estrelas")]
        [Range(0, int.MaxValue)]
        public int Estrelas { get; set; }
    }
}
