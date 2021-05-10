using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCastGroup.API.DTO
{
    public class CursoDTO
    {
        public string DescricaoAssunto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTerminio { get; set; }
        public int QuantidadeAluno { get; set; }
        public string CategoriaCodigo { get; set; }

    }
}
