﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Validadores
{
    public class CadastroPessoaFisica : Validador
    {
        protected override int CalcularDigitoVerificador(string parametros, int posicaoDigito)
        {
            var somatorio = 0;
            var multiplicador = posicaoDigito + 1;

            for (var i = 0; i < posicaoDigito; i++)
            {
                var elemento = Convert.ToInt32(parametros[i].ToString());
                var va = elemento * multiplicador;
                somatorio += va;
                multiplicador--;
            }

            var resto = somatorio % 11;
            var digitoVerificadorCalculado = 0;

            if (resto >= 2)
                digitoVerificadorCalculado = 11 - resto;
            return digitoVerificadorCalculado;
        }

        public override bool EstaValido(string parametros)
        {
            const int tamanhoCpf = 11;
            var expressaoRegular = new Regex("[^0-9]");
            var parametrosLimpos = expressaoRegular.Replace(parametros, string.Empty);

            if (!PossuiNumeroMinimoElementos(parametrosLimpos, tamanhoCpf))
                return false;
            
            if (!OsElementosNaoSaoTodosIguaisEntreSi(parametrosLimpos))
                return false;
            
            const int posicaoPrimeiroDigito = 9;
            const int posicaoSegundoDigito = 10;

            var primeiroDigitoVerificadorCorreto = VerificarDigitos(parametrosLimpos, posicaoPrimeiroDigito);
            var segundoDigitoVerificadorCorreto = VerificarDigitos(parametrosLimpos, posicaoSegundoDigito);

            return primeiroDigitoVerificadorCorreto && segundoDigitoVerificadorCorreto;
        }

        public override string GerarValorParaTestes(bool formatado = false)
        {
            var valores = new StringBuilder();
            const int tamanhoCpfSemDv = 9;

            for (var i = 0; i < tamanhoCpfSemDv; i++)
            {
                var numeroAleatorio = new Random();
                Thread.Sleep(100);
                var numero = numeroAleatorio.Next(9);

                valores.Append(numero);
            }

            const int posicaoDigitoVerificador1 = 9;
            var digitoVerificador1 = CalcularDigitoVerificador(valores.ToString(), posicaoDigitoVerificador1);
            valores.Append(digitoVerificador1);

            const int posicaoDigitoVerificador2 = 10;
            var digitoVerificador2 = CalcularDigitoVerificador(valores.ToString(), posicaoDigitoVerificador2);
            valores.Append(digitoVerificador2);

            var resultado = formatado ? ToStringFormatado(valores) : valores.ToString();

            return resultado;
        }

        public override string ToStringFormatado(string parametros)
        {
            return string.Format(@"{0:000\.000\.000\-00}", Convert.ToInt64(parametros));
        }
    }
}
