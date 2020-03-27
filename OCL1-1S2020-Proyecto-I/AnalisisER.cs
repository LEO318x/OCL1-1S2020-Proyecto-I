using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_1S2020_Proyecto_I
{
    class AnalisisER
    {
        string token;
        Nodo tempTablaTokens = new Nodo();
        Thompson thompson = new Thompson();

        public void analisisTokens(Tokens tablaTokens)
        {
           
        }

        public void analisis(Nodo tablaTokens)
        {
            tempTablaTokens = tablaTokens;
            token = tempTablaTokens.Token;
            INICIO();
        }

        public void INICIO()
        {
            LISTACONJUNTOS();
            LISTAEXPRESIONES();
        }

        public void LISTACONJUNTOS()
        {
            if (tempTablaTokens.Token.Equals("RES_CONJ"))
            {
                CONJUNTO();
                LISTACONJUNTOS();                
            }
        }

        public void CONJUNTO()
        {
            Parea("RES_CONJ");
            Parea("DOSPUNTOS");
            Parea("IDENTIFICADOR");
            Parea("ASIGNACION");
            TIPOCONJUNTO();
            Parea("PUNTOCOMA");
        }

        public void TIPOCONJUNTO()
        {
            if (tempTablaTokens.Token.Equals("CONJUNTO_LETRAS"))
            {
                Parea("CONJUNTO_LETRAS");
            }else if (tempTablaTokens.Token.Equals("CONJUNTO_LETRAS2"))
            {
                Parea("CONJUNTO_LETRAS2");
            }else if (tempTablaTokens.Token.Equals("CONJUNTO_NUMEROS"))
            {
                Parea("CONJUNTO_NUMEROS");
            }else if (tempTablaTokens.Token.Equals("CONJUNTO_NUMEROS2"))
            {
                Parea("CONJUNTO_NUMEROS2");
            }else if (tempTablaTokens.Token.Equals("CONJUNTO_SIMBOLOS"))
            {
                Parea("CONJUNTO_SIMBOLOS");
            }else if (tempTablaTokens.Token.Equals("CONJUNTO_SIMBOLOS2"))
            {
                Parea("CONJUNTO_SIMBOLOS2");
            }
            else if (tempTablaTokens.Token.Equals("CONJUNTO_ESPECIALES"))
            {
                Parea("CONJUNTO_ESPECIALES");
            }
            else if (tempTablaTokens.Token.Equals("CONJUNTO_TODO"))
            {
                Parea("CONJUNTO_TODO");
            }
        }

        public void LISTAEXPRESIONES()
        {
            if (tempTablaTokens.Token.Equals("IDENTIFICADOR"))
            {
                EXPRESION();
                LISTAEXPRESIONES();
            }
        }

        public void EXPRESION()
        {
            if (tempTablaTokens.Token.Equals("IDENTIFICADOR"))
            {
                Parea("IDENTIFICADOR");
                TIPOEXPRESION();
               // Parea("PUNTOCOMA");
            }
        }

        public void TIPOEXPRESION()
        {
            if (tempTablaTokens.Token.Equals("ASIGNACION"))
            {
                Parea("ASIGNACION");
                VALOREXPRESION();
            }else if (tempTablaTokens.Token.Equals("DOSPUNTOS"))
            {
                Parea("DOSPUNTOS");
                Parea("TEXTO");
            }
        }

        public string VALOREXPRESION()
        {
            if (tempTablaTokens.Token.Equals("PUNTO"))
            {
                Parea("PUNTO");
                VALOREXPRESION();
                VALOREXPRESION();

            }else if (tempTablaTokens.Token.Equals("OR"))
            {
                Console.WriteLine(tempTablaTokens.Token);
                Parea("OR");
               
//                VALOREXPRESION();
 //               VALOREXPRESION();
                thompson.Or(VALOREXPRESION(), VALOREXPRESION());


            }
            else if (tempTablaTokens.Token.Equals("SINO"))
            {
                Parea("SINO");
                VALOREXPRESION();
            }
            else if (tempTablaTokens.Token.Equals("CEROMASVECES"))
            {
                Parea("CEROMASVECES");
                VALOREXPRESION();
            }
            else if (tempTablaTokens.Token.Equals("UNOMASVECES"))
            {
                Parea("UNOMASVECES");
                VALOREXPRESION();
            }
            else if (tempTablaTokens.Token.Equals("LLAVE_ABIERTA"))
            {
                Parea("LLAVE_ABIERTA");
                IDENTIFICADOR();
                Parea("LLAVE_CERRADA");
                
            }
            else if (tempTablaTokens.Token.Equals("TEXTO"))
            {
                string lexema = tempTablaTokens.Lexema;
                Parea("TEXTO");
                return lexema;

            }
            return null;

        }

        public string IDENTIFICADOR()
        {
            string lexema = tempTablaTokens.Lexema;
            Parea("IDENTIFICADOR");
            return lexema;
        }

        public void Parea(String tkn)
        {
            if (tkn != token)
            {
                Console.WriteLine("Error Sintactico: Se esperaba: " + tkn + " TOKEN: " + tempTablaTokens.Lexema);
            }
            if (tempTablaTokens.Siguiente != null)
            {
                tempTablaTokens = tempTablaTokens.Siguiente;
                token = tempTablaTokens.Token;
            }
        }
    }
    
}
