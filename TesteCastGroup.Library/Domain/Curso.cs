using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCastGroup.Library.Domain
{
    public class Curso
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(200)]
        [Required]
        public string DescricaoAssunto { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTerminio { get; set; }
        public int QuantidadeAluno { get; set; }
        [Required]
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}
