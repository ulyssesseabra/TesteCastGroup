using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCastGroup.Library.Domain
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(10)]
        public string Codigo { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
