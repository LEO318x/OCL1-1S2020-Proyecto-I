using System;
using System.Diagnostics;

namespace OCL1_1S2020_Proyecto_I
{
    public class AnalisisLexico
    {
        int fila = 1;
        int columna = 0;
        int estado = 0;
        string lexema = "";

        Tokens tk = new Tokens();

        public AnalisisLexico(string txt)
        {
            for (int pos = 0; pos < txt.Length; pos++)
            {
                char ch = txt[pos];
                if (ch.Equals('\n'))
                {
                    columna = 1;
                    fila += 1;
                }
                switch(estado){

                    case 0:
                        if (Char.IsLetter(ch))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 1;                            
                        }else if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 7;
                        }else if(
                            ((int) ch > 32 & (int) ch < 48 | (int) ch > 57 & (int) ch < 65 | (int)ch > 90 & (int)ch < 97 | (int)ch > 122 & (int)ch < 126)
                            & !ch.Equals('{') & !ch.Equals('-') & !ch.Equals('/') & !ch.Equals('<') & !ch.Equals('[') & !ch.Equals('"') & !ch.Equals('\\'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 12;
                        }else if (ch.Equals('{'))
                        {
                            lexema += ch;
                            estado = 15;
                            columna += 1;
                        }else if (ch.Equals('-'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 18;
                        }else if (ch.Equals('/'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 20;
                        }
                        else if (ch.Equals('<'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 22;
                        }else if (ch.Equals('"'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 26;
                        }else if (ch.Equals('\\'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 28;
                        }

                        break;
                    case 1:
                        if (Char.IsLetterOrDigit(ch) | ch.Equals('_'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 2;
                        }else if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 3;
                        }else if (ch.Equals(','))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 4;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("ID", lexema, fila, columna);

                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 2:
                        if(Char.IsLetterOrDigit(ch) | ch.Equals('_'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 2;
                            if(pos == txt.Length - 1)
                            {
                                Console.WriteLine(lexema);
                                tk.agregarT("ID", lexema, fila, columna);
                                lexema = "";
                                estado = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("ID", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                            pos -= 1;
                        }
                        break;
                    case 3:
                        if (Char.IsLetter(ch))
                        {
                            lexema += ch;
                            estado = 5;
                            columna += 1;
                            pos -= 1;
                        }                        
                        break;
                    case 4:
                        if (Char.IsLetter(ch))
                        {
                            lexema += ch;
                            estado = 6;
                            columna += 1;
                        }
                        break;
                    case 5:
                        Console.WriteLine(lexema);
                        tk.agregarT("CONJUNTO", lexema, fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                    case 6:
                        if (ch.Equals(','))
                        {
                            lexema += ch;
                            estado = 4;
                            columna += 1;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("CONJUNTO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 7:
                        if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 7;
                        }else if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 8;
                        }else if (ch.Equals(','))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 10;
                        }
                        break;
                    case 8:
                        if (Char.IsDigit(ch))
                        {
                            //lexema += ch;
                            //columna += 1;
                            estado = 9;
                            pos -= 1;
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 9;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("CONJUNTO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 10:
                        if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            estado = 11;
                            columna += 1;
                        }
                        break;
                    case 11:
                        if (Char.IsDigit(ch))
                        {
                            lexema += ch;
                            estado = 11;
                            columna += 1;
                        }
                        else if (ch.Equals(','))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 10;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("CONJUNTO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 12:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 13;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("SIMBOLO", lexema, fila, columna);
                            columna += 1;
                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 13:
                        if ((int)ch > 33 & (int)ch < 48 | (int)ch > 57 & (int)ch < 65 | (int)ch > 90 & (int)ch < 97 | (int)ch > 122 & (int)ch < 126)
                        {
                            lexema += ch;
                            estado = 14;
                            columna += 1;
                            pos -= 1;
                        }
                        break;
                    case 14:
                        Console.WriteLine(lexema);
                        tk.agregarT("CONJUNTO", lexema, fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                    case 15:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            estado = 13;
                            columna += 1;
                        }else if (Char.IsLetter(ch))
                        {
                            //lexema += ch;
                            //estado = 16;
                            //columna += 1;
                            estado = 16;
                            pos -= 1;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("SIMBOLO", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                            pos -= 1;
                        }
                        break;
                    case 16:
                        if(Char.IsLetterOrDigit(ch) | ch.Equals('_'))
                        {
                            lexema += ch;
                            estado = 16;
                            columna += 1;
                        }else if (ch.Equals('}'))
                        {
                            lexema += ch;
                            estado = 17;
                            columna += 1;
                            pos -= 1;
                        }
                        break;
                    case 17:
                        Console.WriteLine(lexema);
                        tk.agregarT("CONJUNTO2", lexema, fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                    case 18:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 13;
                        }else if (ch.Equals('>'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 19;
                            pos -= 1;
                        }
                        else
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("SIMBOLO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                            pos -= 1;
                        }
                        break;
                    case 19:
                        Console.WriteLine(lexema);
                        tk.agregarT("ASIGNACION", lexema, fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                    case 20:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 13;
                        }else if (ch.Equals('/'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 21;
                        }
                        break;
                    case 21:
                        if (!ch.Equals('\n'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 21;
                        }                            
                        if (ch.Equals('\n'))
                        {
                            //lexema += ch;
                            Console.WriteLine(lexema);
                            tk.agregarT("COMENTARIO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                        }else if(pos == txt.Length - 1)
                        {
                            Console.WriteLine(lexema);
                            tk.agregarT("COMENTARIO", lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 22:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 13;
                        }
                        else if (ch.Equals('!'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 23;
                        }
                        break;
                    case 23:
                        lexema += ch;
                        columna += 1;
                        estado = 23;
                        if (ch.Equals('!'))
                        {
                            estado = 24;
                        }
                        break;
                    case 24:
                        if (ch.Equals('!'))
                        {
                            pos -= 1;
                            estado = 23;
                        }else if (ch.Equals('>'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 25;
                            pos -= 1;
                        }
                        break;
                    case 25:
                        Console.WriteLine(lexema);
                        tk.agregarT("MULTICOMENTARIO", lexema, fila, columna);
                        lexema = "";
                        estado = 0;
                        break;
                    case 26:
                        if (ch.Equals('~'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 13;
                        }else if (ch.Equals('"'))
                        {
                            lexema += ch;
                            Console.WriteLine(lexema);
                            tk.agregarT("STRING", lexema, fila, columna);
                            lexema = "";
                            estado = 0;
                        }
                        else
                        {
                            lexema += ch;
                            estado = 26;
                        }
                        break;
                    case 27:
                        if (ch.Equals('"'))
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 26;
                        }
                        else
                        {
                            lexema += ch;
                            columna += 1;
                            estado = 26;
                        }
                        break;
                    case 28:
                        if (ch.Equals('n'))
                        {

                        }
                        break;
                }

            }
        }

        public void imprimir()
        {
            tk.imprimirTabla();
        }

    }
}