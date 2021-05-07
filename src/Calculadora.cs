using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora
{
    public class Calculadora
    {


        private double novoValor;
        private String historico;
        private String operacao;
        private double resultado;

        private double ultimoResultado;
        private String ultimaOperacao;

        public static readonly string SOMA = "+";
        public static readonly string SUBTRACAO = "-";
        public static readonly string MULTIPLICACAO = "*";
        public static readonly string DIVISAO = "/";
        public static readonly string IGUAL = "=";

        public Calculadora()
        {
            this.Reset();
        }

        public string GetHistorico()
        {
            return this.historico;
        }

        public void SetOperacao(String operacao)
        {
            this.ultimaOperacao = this.operacao;
            this.operacao = operacao;
        }

        public double Calcular(double valorAtual)
        {
            this.ultimoResultado = this.resultado;
            this.novoValor = valorAtual;

            if (resultado > 0 && !this.ultimaOperacao.Equals(IGUAL))
            {
                String operacao = this.operacao.Equals(IGUAL) ? this.ultimaOperacao : this.operacao;

                if (operacao == SOMA)
                {
                    this.resultado = this.Somar(this.novoValor);
                }
                else if (operacao == SUBTRACAO)
                {
                    this.resultado = this.Subtrair(this.novoValor);
                }
                else if (operacao == MULTIPLICACAO)
                {
                    this.resultado = this.Multiplicar(this.novoValor);
                }
                else if (operacao == DIVISAO)
                {
                    this.resultado = this.Dividir(this.novoValor);
                }
            }
            else
            {
                if (!this.ultimaOperacao.Equals(IGUAL))
                {
                    this.resultado = this.novoValor;
                }
                    
            }

            this.UpdateHistorico();

            return this.resultado;
        }

        private double Somar(double valor)
        {
            return this.resultado = valor;
        }

        private double Subtrair(double valor)
        {
            return this.resultado -= valor;
        }

        private double Dividir(double valor)
        {
            if (valor == 0)
            {
                throw new ArgumentException("Divisor não pode ser zero!");
            }
            return this.resultado /= valor;
        }

        private double Multiplicar(double valor)
        {
            return this.resultado *= valor;
        }

        private String UpdateHistorico()
        {
            if (!this.ultimaOperacao.Equals(IGUAL) && this.operacao.Equals(IGUAL))
            {
                this.historico = this.ultimoResultado + " " + this.ultimaOperacao + " " + novoValor + " = ";
            }
            else
            {
                this.historico = this.resultado + this.operacao;
            }

            return this.historico;
        }

        public void Reset()
        {
            this.novoValor = 0;
            this.resultado = 0;
            this.operacao = String.Empty;
            this.historico = String.Empty;

        }
    }
}
