using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCastGroup.Library.Domain
{
    public class Resposta<T>
    {
        private bool sucesso;
        private string mensagem;
        private T objeto;

        public Resposta(bool parSucesso, string parMensagem, T parObjeto) {
            sucesso = parSucesso;
            mensagem = parMensagem;
            objeto = parObjeto;
        }
        public bool Sucesso { get { return sucesso; }  }
        public string Mensagem { get { return mensagem; } }
        public T Objeto { get { return objeto; } }
    }
}
