using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(Cor.branca, tab), new Posicao(0, 3));
            tab.ColocarPeca(new Rei(Cor.branca, tab), new Posicao(0, 1));
            tab.ColocarPeca(new Torre(Cor.preta, tab), new Posicao(4, 5));
            tab.ColocarPeca(new Rei(Cor.preta, tab), new Posicao(6, 7));
            Tela.ImprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}
