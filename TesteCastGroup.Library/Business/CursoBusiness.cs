using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCastGroup.Library.Domain;

namespace TesteCastGroup.Library.Business
{
    public class CursoBusiness : IBusiness<Curso>
    {
        private TesteCastGroupContext objTesteCastGroupContext;
        public CursoBusiness(TesteCastGroupContext parTesteCastGroupContext)
        {
            objTesteCastGroupContext = parTesteCastGroupContext;
        }


        public Resposta<Curso> Get(Guid parId)
        {
            Curso objCurso = objTesteCastGroupContext.Cursos.Find(parId);

            if (objCurso == null)
                return new Resposta<Curso>(false, "Curso não localizado.", null);

            else
                return new Resposta<Curso>(true, "", objCurso);
        }

        public List<Curso> GetAll()
        {
            return objTesteCastGroupContext.Cursos.ToList();

        }

        public Resposta<Curso> Save(Curso parObject)
        {
            if (parObject.DataInicio.Date < DateTime.Now.Date)
            {
                return new Resposta<Curso>(false, "A data de inicio do curso não pode ser anterior a hoje.", null);
            }
            if (VerificaTemCursoPeriodo(parObject.DataInicio.Date, parObject.DataTerminio))
            {
                return new Resposta<Curso>(false, "Existe(m) curso(s) planejados(s) dentro do período informado.", null);
            }

            objTesteCastGroupContext.Add(parObject);
            objTesteCastGroupContext.SaveChanges();
            return new Resposta<Curso>(true, "Curso incluido com sucesso.", parObject);
        }

        public Resposta<Curso> Update(Curso parObject)
        {
            if (parObject.DataInicio.Date < DateTime.Now.Date)
            {
                return new Resposta<Curso>(false, "A data de inicio do curso não pode ser anterior a hoje.", null);
            }
            if (VerificaTemCursoPeriodo(parObject.DataInicio, parObject.DataTerminio))
            {
                return new Resposta<Curso>(false, "Existe(m) curso(s) planejados(s) dentro do período informado.", null);
            }

            objTesteCastGroupContext.Update(parObject);
            objTesteCastGroupContext.SaveChanges();
            return new Resposta<Curso>(true, "Curso atualizado com sucesso.", parObject);
        }

        public Resposta<Curso> Delete(Guid parId)
        {
            Resposta<Curso> rem = Get(parId);
            if (!rem.Sucesso)
                return new Resposta<Curso>(true, "Curso não exite.", null);
            else
            {
                objTesteCastGroupContext.Remove(rem.Objeto);
                objTesteCastGroupContext.SaveChanges();
                return new Resposta<Curso>(true, "Curso excluido com sucesso.", null);
            }
        }

        public bool VerificaTemCursoPeriodo(DateTime parDataInicio, DateTime parDataFinal)
        {





            int countIni = (from curso in objTesteCastGroupContext.Cursos
                            where parDataInicio.Date >= curso.DataInicio.Date && parDataInicio.Date <= curso.DataTerminio.Date
                            select curso).Count();

            int countFin = (from curso in objTesteCastGroupContext.Cursos
                            where parDataFinal.Date >= curso.DataInicio.Date   && parDataFinal.Date <= curso.DataTerminio.Date
                            select curso).Count();






            //A junção OR não estava refletindo a lógica da data inicial ou final estar dentro do periodo de outro curso
            //int countIni = objTesteCastGroupContext.Cursos.Where(c =>
            // (c.DataInicio.Date >= parDataInicio.Date && parDataInicio.Date <= c.DataTerminio.Date)).Count();

            //int countFin = objTesteCastGroupContext.Cursos.Where(c =>
            // (c.DataInicio.Date >= parDataFinal.Date && parDataFinal.Date <= c.DataTerminio.Date)).Count();

            return countIni + countFin > 0;
        }
    }
}
