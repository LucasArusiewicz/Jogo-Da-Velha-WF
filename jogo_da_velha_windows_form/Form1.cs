using System;
using System.Windows.Forms;

namespace jogo_da_velha_windows_form
{
    public partial class Form1 : Form
    {

        Velha jogo = new Velha();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NovoJogo();
        }

        private void NovoJogo()
        {
            //Limpa Valores dos botoes
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            jogo.NovoJogo();

            MessageBox.Show("Jogador 1 = X\nJogador 2 = O", "INFO JOGADORES", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Jogada(Button botao, int[] casa)
        {
            string jogador = jogo.Jogador1 ? "X" : "O";

            if (jogo.DefineCasa(casa))
            {
                botao.Text = jogador;
                switch (jogo.ProximaJogada())
                {
                    case 1:
                        MessageBox.Show("JOGADOR 1\nJogador X", "VENCEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        NovoJogo();
                        break;
                    case 2:
                        MessageBox.Show("JOGADOR 2\nJogador O", "VENCEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        NovoJogo();
                        break;
                    case 3:
                        MessageBox.Show("EMPATE", "VELHA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        NovoJogo();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Essa casa já foi jogada.\nJogue em outra casa.", "CASA INVÁLIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogada(button1, new int [2]{ 0, 0 });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jogada(button2, new int[2] { 0, 1 });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Jogada(button3, new int[2] { 0, 2 });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Jogada(button4, new int[2] { 1, 0 });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Jogada(button5, new int[2] { 1, 1 });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Jogada(button6, new int[2] { 1, 2 });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Jogada(button7, new int[2] { 2, 0 });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Jogada(button8, new int[2] { 2, 1 });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Jogada(button9, new int[2] { 2, 2 });
        }

        private void button_novoJogo_Click(object sender, EventArgs e)
        {
            NovoJogo();
        }

    }
}
