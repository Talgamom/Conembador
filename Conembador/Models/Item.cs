namespace Conembador.Models
{
    public class Item
    {
        public int Id_item { get; set; }
        public string Descricao { get; set; }
        public int Inicio { get; set; }
        public int Fim { get; set; }
        public int Id_arquivo { get; set; }
        public int Linha { get; set; }
    }
}
