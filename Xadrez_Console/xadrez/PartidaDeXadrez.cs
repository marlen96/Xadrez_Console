using System;
using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadoreAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadoreAtual = Cor.Branca;
            terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem , Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarMovimento();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(PecaCapturada != null)
            {
                Capturadas.Add(PecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem , Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            Mudajogador();
        }

        private void Mudajogador()
        {
            if(JogadoreAtual == Cor.Branca)
            {
                JogadoreAtual = Cor.Preta;
            } else
            {
                JogadoreAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(Tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não Existe peça na posição de origem escolhida!");
            }
            if(JogadoreAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void ColocarNovaPeca(char coluna , int linha , Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('b', 1, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('b', 2, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('d', 2, new Rei(Cor.Branca, Tab));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('c', 7, new Rei(Cor.Preta, Tab));
        }
    }
}
