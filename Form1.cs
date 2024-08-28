using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_2._0
{
    public partial class Form1 : Form
    {
        private double valor1 = 0;
        private double valor2 = 0;
        private string operacao = "";
        private bool operacaoPressionada = false;


        public Form1()
        {
            InitializeComponent();
        }
        // Evento para os botões numéricos
        // Evento para os botões numéricos
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
        }
        private void btnNumero_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            if (btn == null) return;

            if ((txtDisplay.Text == "0") || (operacaoPressionada))
                txtDisplay.Text = "";

            operacaoPressionada = false;
            txtDisplay.Text += btn.Text;
        }

        // Evento para as operações
        private void btnOperacao_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            if (btn == null) return;

            valor1 = double.Parse(txtDisplay.Text);
            operacao = btn.Text;
            operacaoPressionada = true;
        }

        // Evento para o botão de igual
        private void btnIgual_Click(object sender, EventArgs e)
        {
            valor2 = double.Parse(txtDisplay.Text);

            switch (operacao)
            {
                case "+":
                    txtDisplay.Text = (valor1 + valor2).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (valor1 - valor2).ToString();
                    break;
                case "x":
                    txtDisplay.Text = (valor1 * valor2).ToString();
                    break;
                case "÷":
                    txtDisplay.Text = (valor1 / valor2).ToString();
                    break;
            }

            operacaoPressionada = false;
        }

        // Evento para o botão de vírgula
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains(","))
                txtDisplay.Text += ",";
        }
        
        // Manipulação do teclado
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control btn = this.Controls["btnNumero" + e.KeyChar.ToString()] as SimpleButton;
            if (btn != null)
            {
                btnNumero_Click(btn, e);
            }
            else if (e.KeyChar == '+')
            {
                btnOperacao_Click(btnOperacaoMais, e);
            }
            else if (e.KeyChar == '-')
            {
                btnOperacao_Click(btnOperacaoMenos, e);
            }
            else if (e.KeyChar == 'x')
            {
                btnOperacao_Click(btnOperacaoMultiplicacao, e);
            }
            else if (e.KeyChar == '÷')
            {
                btnOperacao_Click(btnOperacaoDivisao, e);
            }
            else if (e.KeyChar == '=' || e.KeyChar == '\r')
            {
                btnIgual_Click(btnIgual, e);
            }
            else if (e.KeyChar == ',')
            {
                btnVirgula_Click(btnVirgula, e);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            valor1 = 0;
            valor2 = 0;
            operacao = "";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {


            DialogResult Sair;
            Sair = MessageBox.Show("Deseja fechar ?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Sair == DialogResult.Yes)
            {
                Application.Exit();
            }

            else
            {
                MessageBox.Show("Operação cancelada");
            }

        }

    }
}

