namespace jogo_da_velha_windows_form
{
    class Velha
    {
        //Jogador 1 = inteiro de valor 1
        //Jogador 2 = inteiro de valor 2

        //Atributos
        int[,] campo = new int[3, 3];
        bool jogador1 = true;
        int contJogadas = 0;

        public bool Jogador1 { get => jogador1;}

        public int ProximaJogada()
        {
            contJogadas++;

            int valorJogadorAtual = jogador1 ? 1 : 2;

            switch (VerificaVencedor(valorJogadorAtual))
            {
                case 0:
                    if (contJogadas == 9)
                    {
                        return 3;
                    }
                    break;
                case 1:
                    return 1;
                case 2:
                    return 2;
            }

            jogador1 = !jogador1;
            return 0;
        }

        public int VerificaVencedor(int jogador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (VerificaLinha(i, jogador)) return jogador;
                if (VerificaColuna(i, jogador)) return jogador;
            }

            if (VerificaDiagonal(jogador))
            {
                return jogador;
            }
            else
            {
                return 0;
            }
        }

        private bool VerificaLinha(int linha, int jogador)
        {
            if(campo[linha, 0] == jogador && campo[linha, 1] == jogador && campo[linha, 2] == jogador)
            {
                return true;
            }               
            else
            {
                return false;
            }
        }

        private bool VerificaColuna(int coluna, int jogador)
        {
            if (campo[0, coluna] == jogador && campo[1, coluna] == jogador && campo[2, coluna] == jogador)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerificaDiagonal(int jogador)
        {
            if ((campo[0, 0] == jogador && campo[1, 1] == jogador && campo[2, 2] == jogador) || (campo[0, 2] == jogador && campo[1, 1] == jogador && campo[2, 0] == jogador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NovoJogo()
        {
            campo = new int[3, 3];
            contJogadas = 0;
            jogador1 = true;
        }

        public bool DefineCasa(int[] jogada)
        {
            int valorCasa = campo[jogada[0], jogada[1]];

            if(valorCasa != 0)
            {
                return false;
            }
            else
            {
                campo[jogada[0], jogada[1]] = jogador1 ? 1 : 2;
                return true;
            }
        }
    }
}
