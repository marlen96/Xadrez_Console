using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez p = new PartidaDeXadrez();

                while (!p.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(p.Tab);
                    Console.WriteLine();
                    Console.Write("origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                    p.ExecutaMovimento(origem, destino);
                }


            } catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
