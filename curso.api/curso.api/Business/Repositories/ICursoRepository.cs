using curso.api.Business.Entites;
using System.Collections.Generic;

namespace curso.api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso usuario);
        void Commit();
        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}
