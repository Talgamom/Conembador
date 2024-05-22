using System;
using Conembador.Models;
using Conembador.Contexto;

namespace TesteInsert
{
    public class TesteInsert01
    {
        // Construtor da classe TesteInsert01
        /*
        public void TesteInsertAbc(List<Itens> Itens)
        {
            Console.WriteLine("Entrou aqui");
            using (var dbContext = new ConembadorContext())
            {
                Arquivo arquivo = new Arquivo();
                arquivo.NomeEdi = "Teste01";
                arquivo.Versao = 1;

                var itens1 = Itens;

                dbContext.Arquivos.Add(arquivo);

                foreach (var item in itens1)
                {
                    arquivo.ItensArquivo.Add(item);
                }
                foreach (var item in itens1)
                {
                    arquivo.ItensArquivo.Add(item);
                    dbContext.Itens.Add(item);
                }

                dbContext.SaveChanges();

                Console.WriteLine($"Arquivo: {arquivo.NomeEdi}, Versão: {arquivo.Versao}");

                foreach (var item in arquivo.ItensArquivo)
                {
                    Console.WriteLine($"Item: {item.Descricao}, Início: {item.Inicio}, Fim: {item.Fim}");
                }
            }

            return; // O retorno é opcional em um construtor
        }
        */
    }
}
