using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCastGroup.Library.Domain;

namespace TesteCastGroup.Library.Business
{
    public interface IBusiness<T>
    {
        public List<T> GetAll();
        public Resposta<T> Get(Guid parId);
        public Resposta<T> Save(T parObject);
        public Resposta<T> Update(T parObject);
        public Resposta<T> Delete(Guid parId);

    }
}
