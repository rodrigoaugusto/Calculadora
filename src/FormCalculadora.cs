using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FormCalculadora : Form
    {

        private Calculadora calculadora = new Calculadora();
        private Boolean fezOperacaoNaUltimaAcao = false;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void ValueButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            this.UpdateValue(button.Text);
        }

        private void UpdateValue(String value)
        {
            
            if (txtResultado.Text.Equals("0") || fezOperacaoNaUltimaAcao)
            {
                this.txtResultado.Text = "";
                this.fezOperacaoNaUltimaAcao = false;
            }

            txtResultado.AppendText(value);

        }

        private void Calcular(Boolean comIgual = false)
        {
            double valorAtual = Double.Parse(txtResultado.Text);
            this.txtResultado.Text = this.calculadora.Calcular(valorAtual).ToString();
            this.txtHistorico.Text = this.calculadora.GetHistorico();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            this.calculadora.SetOperacao(Calculadora.IGUAL);
            this.Calcular();
            this.fezOperacaoNaUltimaAcao = true;
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            this.calculadora.SetOperacao(Calculadora.SOMA);
            this.Calcular();
            this.fezOperacaoNaUltimaAcao = true;
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            this.calculadora.SetOperacao(Calculadora.SUBTRACAO);
            this.Calcular();
            this.fezOperacaoNaUltimaAcao = true;
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            this.calculadora.SetOperacao(Calculadora.MULTIPLICACAO);
            this.Calcular();
            this.fezOperacaoNaUltimaAcao = true;
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            this.calculadora.SetOperacao(Calculadora.DIVISAO);
            this.Calcular();
            this.fezOperacaoNaUltimaAcao = true;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            this.txtResultado.Text = this.txtResultado.Text.Remove(this.txtResultado.Text.Length - 1);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.calculadora.Reset();
            this.txtResultado.Text = "0";
            this.txtHistorico.Text = String.Empty;
        }
    }
}
