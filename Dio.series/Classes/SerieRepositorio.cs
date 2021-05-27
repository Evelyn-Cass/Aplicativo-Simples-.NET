using System;
using System.Collections.Generic;
using Dio.series.Interfaces;

namespace Dio.series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
           listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Exclui();
        }

        public void Insere(Serie Objeto)
        {
            listaSerie.Add(Objeto);            
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int Id)
        {
            return listaSerie[Id];
        }

        public string TituloPorID(int id)
        {
            return listaSerie[id].retornaTitulo();
        }

    }
}