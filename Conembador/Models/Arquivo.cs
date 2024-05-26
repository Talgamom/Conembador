using System.Collections.Generic;

namespace Conembador.Models
{
    public class Arquivo
    {
        public int id_arquivo { get; set; }
        public string NomeEdi { get; set; }
        public double Versao { get; set; }
        //public ICollection<Itens> ItensArquivo { get; set; } // Coleção de itens
        public List<Itens> ItensArquivo { get; set; } = new List<Itens>();

        // Construtor para inicializar a coleção de itens
        public Arquivo()
        {
            ItensArquivo = new List<Itens>();
        }
    }
}
