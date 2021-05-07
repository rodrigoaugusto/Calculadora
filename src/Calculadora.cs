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

        public static readonly string SOMA = "+";
        public static readonly string SUBTRACAO = "-";
        public static readonly string MULTIPLICACAO = "*";
        public static readonly string DIVISAO = "/";

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
            this.operacao = operacao;
        }

        public double Calcular(double valorAtual, Boolean comIgual= false)
        {

            this.novoValor = valorAtual;

            if (resultado > 0)
            {

                this.ultimoResultado = resultado;

                if (this.operacao == SOMA)
                {
                    this.resultado = this.Somar(this.novoValor);
                }
                else if (this.operacao == SUBTRACAO)
                {
                    this.resultado = this.Subtrair(this.novoValor);
                }
                else if (this.operacao == MULTIPLICACAO)
                {
                    this.resultado = this.Multiplicar(this.novoValor);
                }
                else if (this.operacao == DIVISAO)
                {
                    this.resultado = this.Dividir(this.novoValor);
                }
            }
            else
            {
                this.resultado = this.novoValor;
            }

            this.UpdateHistorico(comIgual);

            return this.resultado;
        }

        private double Somar(double valor)
        {
            return this.resultado = valor;
        }

        private double Subtrair(double valor)
        {
            return this.resultado += valor;
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

        private String UpdateHistorico(Boolean comIgual = false)
        {
            if (comIgual)
            {
                this.historico = this.ultimoResultado + " " + this.operacao + " " + novoValor + " = ";
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
