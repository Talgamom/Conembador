using System.Collections.Generic;

namespace Conembador.Models
{
    public class Arquivo
    {
        public int Id_arquivo { get; set; }
        public string NomeEdi { get; set; }
        public double Versao { get; set; }
        //public ICollection<Itens> ItensArquivo { get; set; } // Coleção de itens
        public List<Item> ItensArquivo { get; set; } = new List<Item>();

        // Construtor para inicializar a coleção de itens
        public Arquivo()
        {
            ItensArquivo = new List<Item>();
        }
    }
}
