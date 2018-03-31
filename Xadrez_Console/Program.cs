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

                    try {
                    Console.Clear();
                    Tela.ImprimirPartida(p);
                    Console.WriteLine();
                    Console.Write("origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    p.ValidarPosicaoDeOrigem(origem);

                    bool[,] PosicoesPossiveis = p.Tab.peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(p.Tab , PosicoesPossiveis);
                    Console.WriteLine();

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                    p.ValidarPosicaoDeDestino(origem, destino);

                    p.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(p);

            } catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
