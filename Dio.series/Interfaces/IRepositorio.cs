using System.Collections.Generic;

namespace Dio.series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int Id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}