using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCastGroup.Library.Domain;

namespace TesteCastGroup.Library.Business
{

    public class CategoriaBusiness : IBusiness<Categoria>
    {

        private TesteCastGroupContext objTesteCastGroupContext;
        public CategoriaBusiness(TesteCastGroupContext parTesteCastGroupContext)
        {
            objTesteCastGroupContext = parTesteCastGroupContext;
        }
        public Resposta<Categoria> Get(Guid parId)
        {
            Categoria objCategoria = objTesteCastGroupContext.Categorias.Find(parId);

            if (objCategoria == null)
                return new Resposta<Categoria>(false, "Categoria não localizada.", null);

            else
                return new Resposta<Categoria>(true, "", objCategoria);
        }
        public List<Categoria> GetAll()
        {
            return objTesteCastGroupContext.Categorias.ToList();
        }

        public Resposta<Categoria> GetByCodigo(string parCodigo)
        {
            Categoria objCategoria = objTesteCastGroupContext.Categorias.Where(c => c.Codigo == parCodigo).FirstOrDefault();
            if (objCategoria == null)
                return new Resposta<Categoria>(false, "Categoria não localizada.", null);

            else
                return new Resposta<Categoria>(true, "", objCategoria);
        }

        public Resposta<Categoria> Save(Categoria parObject)
        {
            objTesteCastGroupContext.Add(parObject);
            objTesteCastGroupContext.SaveChanges();
            return new Resposta<Categoria>(true, "Categoria incluida com sucesso.", parObject);

        }

        public Resposta<Categoria> Update(Categoria parObject)
        {
            objTesteCastGroupContext.Update(parObject);
            objTesteCastGroupContext.SaveChanges();
            return new Resposta<Categoria>(true, "Categoria atualizada com sucesso.", parObject);


        }

        public Resposta<Categoria> Delete(Guid parId)
        {
            Resposta<Categoria> rem = Get(parId);
            if (!rem.Sucesso)
                return new Resposta<Categoria>(true, "Categoria não exite.", null);
            else
            {

                objTesteCastGroupContext.Remove(rem.Objeto);
                objTesteCastGroupContext.SaveChanges();
                return new Resposta<Categoria>(true, "Categoria excluida com sucesso.", null);
            }
        }


        /// <summary>
        /// Inicializa as categorias dos curso se basendo no quantitativo de Categorias
        /// </summary>
        /// <returns></returns>
        public void Init()
        {
            if (objTesteCastGroupContext.Categorias.Count() < 4)
            {
                Save(new Categoria() { Codigo = "comp", Descricao = "Comportamental", Id = new Guid() });
                Save(new Categoria() { Codigo = "prog", Descricao = "Programação", Id = new Guid() });
                Save(new Categoria() { Codigo = "qual", Descricao = "Qualidade", Id = new Guid() });
                Save(new Categoria() { Codigo = "proc", Descricao = "Processos", Id = new Guid() });
            }
        }
    }
}
