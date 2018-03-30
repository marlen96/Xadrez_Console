using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor JogadoreAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadoreAtual = Cor.branca;
            terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem , Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarMovimento();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Cor.branca, Tab), new PosicaoXadrez('c', 1).toPosicao());
            Tab.ColocarPeca(new Rei(Cor.branca, Tab), new PosicaoXadrez('c', 2).toPosicao());
            Tab.ColocarPeca(new Torre(Cor.preta, Tab), new PosicaoXadrez('c', 8).toPosicao());
            Tab.ColocarPeca(new Rei(Cor.preta, Tab), new PosicaoXadrez('c', 7).toPosicao());
        }
    }
}
