using System;
using System.Linq;
using System.Text;

namespace Validadores
{
    public abstract class Validador : IValidavel
    {
        protected virtual bool PossuiNumeroMinimoElementos(string parametros, int posicoes)
        {
            var resultado = parametros.Length >= posicoes;
            return resultado;
        }

        protected virtual bool OsElementosNaoSaoTodosIguaisEntreSi(string parametros)
        {
            var elementosDiferentes = parametros.ToCharArray().ToList();
            var resultado = elementosDiferentes.Distinct().Count() > 1;
            
            return resultado;
        }
        
        protected virtual bool VerificarDigitos(string parametros, int posicaoDigito)
        {
            var digitoVerificadorCalculado = CalcularDigitoVerificador(parametros, posicaoDigito);
            var digitoVerificadorInformado = Convert.ToInt32(parametros[posicaoDigito].ToString());
            var resultado = digitoVerificadorInformado == digitoVerificadorCalculado;

            return resultado;
        }

        public virtual string ToStringFormatado(StringBuilder parametros)
        {
            return ToStringFormatado(parametros.ToString());
        }


        protected abstract int CalcularDigitoVerificador(string parametros, int posicaoDigito);
        public abstract bool EstaValido(string parametros);
        public abstract string GerarValorParaTestes(bool formatado = false);
        public abstract string ToStringFormatado(string parametros);
    }
}
