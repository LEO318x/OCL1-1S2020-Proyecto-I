using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_1S2020_Proyecto_I
{
    class Analisis
    {
        private int fila = 1;
        private int columna = 1;
        private int estado = 0;        
        private int auxColumna = 0;
        private string lexema;

        Tokens tk = new Tokens();

        public Analisis(string textoEntrada)
        {
            string txt = textoEntrada;
            int tamanioTexto = textoEntrada.Length;
            for (int pos = 0; pos < tamanioTexto; pos++)
            {
                char ch = txt[pos];
                if (ch.Equals('\n'))
                {
                    columna = 1;
                    fila += 1;
                }
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(ch))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 1;
                        }else if (Char.IsDigit(ch))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 7;
                        }else if (ch.Equals('"'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 11;
                        }else if (ch.Equals('-'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 19;
                        }
                        else if (ch.Equals('/'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 21;
                        }else if (ch.Equals('<'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 23;
                        }else if (ch.Equals('['))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 27;
                        }else if (ch.Equals('.') | ch.Equals('|') | ch.Equals('?') | ch.Equals('*') | ch.Equals('+') | ch.Equals(';') | ch.Equals('{') | ch.Equals('}') |  ch.Equals(':'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 31;
                            pos -= 1;
                        }else if (ch.Equals('\\')){
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 32;
                        }
                        else
                        {
                            if((int) ch != 32 & !ch.Equals('\n') & (int) ch != 13)
                            {
                                lexema += ch;
                                Console.WriteLine((int)ch);
                                tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            
                        }
                        break;
                    case 1:
                        if (ch.Equals('~'))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 2;
                        }else if (Char.IsLetterOrDigit(ch) | ch.Equals('_'))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 4;
                        }
                        else if (ch.Equals(','))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 5;
                        }
                        else
                        {
                            tk.agregarT("IDENTIFICADOR",lexema,fila, columna-auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            pos -= 1;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsLetter(ch))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 3;
                            pos -= 1;
                        }
                        else
                        {
                            lexema += ch;
                            tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 3:
                        tk.agregarT("CONJUNTO_LETRAS", lexema, fila, columna - auxColumna);
                        auxColumna = 0;
                        lexema = "";
                        estado = 0;
                        break;
                    case 4:
                        if(Char.IsLetterOrDigit(ch) | ch.Equals('_'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 4;
                        }
                        else
                        {
                            if (lexema.Equals("CONJ"))
                            {
                                tk.agregarT("RES_CONJ", lexema, fila, columna - auxColumna);
                            }
                            else
                            {                                
                                tk.agregarT("IDENTIFICADOR", lexema, fila, columna - auxColumna);
                            }
                            
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                            pos -= 1;
                        }
                        break;
                    case 5:
                        if (Char.IsLetter(ch))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 6;
                        }
                        else
                        {
                            lexema = ch+"";
                            tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 6:
                        if (ch.Equals(','))
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                            estado = 5;
                        }
                        else
                        {
                            tk.agregarT("CONJUNTO_LETRAS2", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 7:
                        if (Char.IsDigit(ch))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 7;
                        }else if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 8;
                        }else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 9;
                        }
                        else
                        {
                            // posible error aquí
                        }
                        break;
                    case 8:
                        if (Char.IsDigit(ch))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 8;
                        }
                        else
                        {
                            tk.agregarT("CONJUNTO_NUMEROS", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                            pos -= 1;
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(ch))
                        {
                            pos -= 1;
                            estado = 10;
                        }
                        else
                        {
                            lexema = ch + "";
                            tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }                        
                        break;
                    case 10:
                        if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                        }
                        else if (ch.Equals(','))
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                            estado = 9;
                        }
                        else
                        {
                            auxColumna += 1;
                            columna += 1;
                            tk.agregarT("CONJUNTO_NUMEROS2", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                            pos -= 1;
                        }
                        break;
                    case 11:
                       // Console.WriteLine("x11");
                        if (ch.Equals('\\'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 12;

                        }else if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 15;
                        }
                        else if (ch.Equals('"'))
                        {
                            lexema += ch;
                            columna += 1;
                            auxColumna += 1;
                            pos -= 1;
                            estado = 14;
                        }
                        else if (ch.Equals(','))
                        {
                            lexema += ch;
                            columna += 1;
                            auxColumna += 1;                            
                            estado = 17;
                        }
                        else
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                            estado = 11;
                        }
                        break;
                    case 12:
                        //Console.WriteLine("x12");
                        if (ch.Equals('"') | ch.Equals('t') | ch.Equals('n'))
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 11;
                        }
                        else
                        {
                            auxColumna += 1;
                            columna += 1;
                            lexema += ch;
                            estado = 11;
                        }
                        break;
                    case 13:
                        //Console.WriteLine("x13");
                        if (ch.Equals('"'))
                        {
                            lexema += ch;
                            columna += 1;
                            auxColumna += 1;
                            estado = 14;
                        }else if (ch.Equals(','))
                        {
                            lexema += ch;
                            columna += 1;
                            auxColumna += 1;
                            pos -= 1;
                            estado = 17;
                        }
                        else
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 11;
                        }
                        break;
                    case 14:
                        //Console.WriteLine("x14");
                        tk.agregarT("TEXTO", lexema, fila, columna - auxColumna);
                        auxColumna = 0;
                        lexema = "";
                        estado = 0;
                        break;
                    case 15:
                        if ((int)ch > 33 & (int)ch < 48 | (int)ch > 57 & (int)ch < 65 | (int)ch > 90 & (int)ch < 97 | (int)ch > 122 & (int)ch < 126)
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 16;
                            pos -= 1;
                        }
                        else
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                            tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 16:
                        tk.agregarT("CONJUNTO_SIMBOLOS", lexema, fila, columna - auxColumna);
                        auxColumna = 0;
                        lexema = "";
                        estado = 0;
                        break;
                    case 17:
                        if ((int)ch > 33 & (int)ch < 48 | (int)ch > 57 & (int)ch < 65 | (int)ch > 90 & (int)ch < 97 | (int)ch > 122 & (int)ch < 126)
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 18;                            
                        }
                        break;
                    case 18:
                        if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }
                        else
                        {
                            tk.agregarT("CONJUNTO_SIMBOLOS2", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 19:
                        if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }else if (ch.Equals('>'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            pos -= 1;
                            estado = 20;
                        }
                        else
                        {
                            // posible error aquí
                        }
                        break;
                    case 20:
                        tk.agregarT("ASIGNACION", lexema, fila, columna - auxColumna);
                        auxColumna = 0;
                        lexema = "";
                        estado = 0;
                        break;
                    case 21:
                        if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }
                        else if (ch.Equals('/'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 22;
                        }
                        break;
                    case 22:
                        if (ch.Equals('\n'))
                        {
                            auxColumna += 1;
                            columna += 1;
                           // tk.agregarT("COMENTARIO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                            break;
                        }
                        else
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 22;
                        }
                        break;
                    case 23:
                        if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }
                        else if (ch.Equals('!'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 24;
                        }
                        break;
                    case 24:
                        lexema += ch;
                        columna += 1;
                        estado = 24;
                        if (ch.Equals('!'))
                        {
                            estado = 25;
                        }
                        break;
                    case 25:
                        if (ch.Equals('!'))
                        {
                            pos -= 1;
                            estado = 24;
                        }
                        else if (ch.Equals('>'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 26;
                            pos -= 1;
                        }
                        break;
                    case 26:
                        //tk.agregarT("MULTICOMENTARIO", lexema, fila, columna);
                        lexema = "";
                        estado = 0;
                        break;
                    case 27:
                        if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }else if (ch.Equals(':'))
                        {
                            columna += 1;
                            auxColumna += 1;
                            lexema += ch;
                            estado = 28;
                        }
                        break;
                    case 28:
                        lexema += ch;
                        columna += 1;
                        estado = 28;
                        if (ch.Equals(':'))
                        {
                            estado = 29;
                        }
                        break;
                    case 29:
                        if (ch.Equals(':'))
                        {
                            pos -= 1;
                            estado = 28;
                        }
                        else if (ch.Equals(']'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 30;
                            pos -= 1;
                        }
                        break;
                    case 30:
                        tk.agregarT("CONJUNTO_TODO", lexema, fila, columna);
                        lexema = "";
                        estado = 0;
                        break;
                    case 31:
                        if (txt[pos + 1].Equals('~'))
                        {
                            estado = 31;
                        }
                        else if (txt[pos + 1].Equals(','))
                        {
                            estado = 31;
                        }
                        else if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        else if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 17;
                        }
                        else
                        {
                            if (ch.Equals('.'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("PUNTO", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('|'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("OR", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('?'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("SINO", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('*'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("CEROMASVECES", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('+'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("UNOMASVECES", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals(';'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("PUNTOCOMA", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('{'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("LLAVE_ABIERTA", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals('}'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("LLAVE_CERRADA", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else if (ch.Equals(':'))
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarT("DOSPUNTOS", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                            }
                            else
                            {
                                auxColumna += 1;
                                columna += 1;
                                tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                                auxColumna = 0;
                                lexema = "";
                                estado = 0;
                                pos -= 1;
                            }
                        }                                                
                        break;
                    case 32:
                        if (ch.Equals('"') | ch.Equals('\'') | ch.Equals('n') | ch.Equals('t'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 33;
                            
                        }else if (ch.Equals('~'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 15;
                        }
                        break;
                    case 33:
                        if (ch.Equals(','))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 34;
                        }
                        else
                        {
                            tk.agregarT("CONJUNTO_ESPECIALES", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 34:
                        if (ch.Equals('\\'))
                        {
                            auxColumna += 1;
                            lexema += ch;
                            columna += 1;
                            estado = 32;
                        }
                        else
                        {
                            lexema += ch;
                            auxColumna += 1;
                            columna += 1;
                            tk.agregarE("NO_RECONOCIDO", lexema, fila, columna - auxColumna);
                            auxColumna = 0;
                            lexema = "";
                            estado = 0;
                        }
                        break;
                }
            }
        }

        public Tokens getTablaTokens()
        {
            return tk;
        }

        public void imprimir()
        {
            //tk.imprimirTabla();
        }

        public void imprimirError()
        {
            //tk.imprimirTablaError();
        }

        public void htmlT()
        {
            tk.generarHtmlTokens();
        }

        public void htmlE()
        {
            tk.generarHtmlErrores();
        }
    }
}
