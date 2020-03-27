using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OCL1_1S2020_Proyecto_I
{
    class Tokens
    {
        Lista T = new Lista();
        Lista E = new Lista();

        
        public Tokens()
        {
            
        }


        public void agregarT(string token, string lexema, int fila, int columna)
        {
            T.insertar(token, lexema, fila, columna);
        }

        public void agregarE(string token, string lexema, int fila, int columna)
        {
            E.insertar(token, lexema, fila, columna);
        }

        public Lista getTablaT()
        {
            return T;
        }
        
        

        public void generarHtmlTokens()
        {
            int num = 1;
            string html = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                            <meta charset='utf-8' />
                            <meta http-equiv='x-ua-compatible' content='ie=edge, chrome=1' />
                            <title>TABLA SIMBOLOS ARCHIVO DE ENTRADA</title>
                            <link rel='stylesheet' href='' />
                                <style type='text/css'>
                                .tg  {border-collapse:collapse;border-spacing:0;}
                                .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:black;}
                                .tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:black;}
                                .tg .tg-fymr{font-weight:bold;border-color:inherit;text-align:left;vertical-align:top}
                                .tg .tg-0pky{border-color:inherit;text-align:left;vertical-align:top}
                                </style>
                            </head>
                            <body>
<h1>TABLA SIMBOLOS ARCHIVO DE ENTRADA</h1>
                            <table class='tg'>
                              <tr>
                                <th class='tg-1wig'>#</th>
                                <th class='tg-1wig'>Lexema</th>
                                <th class='tg-1wig'>Token</th>
                                <th class='tg-1wig'>Fila</th>
                                <th class='tg-1wig'>Columna</th>
                              </tr>";

            Nodo Actual = new Nodo();
            Actual = T.getPrimero();

            if (T.getPrimero() != null)
            {
                while (Actual != null)
                {
                    if (Actual.Token != "MULTICOMENTARIO" & Actual.Token != "COMENTARIO")
                    {
                        html += @"
                <tr>
                    <td class='tg-0lax'>" + num + @"</td>
                    <td class='tg-0lax'>" + Actual.Lexema + @"</td>
                    <td class='tg-0lax'>" + Actual.Token + @"</td>
                    <td class='tg-0lax'>" + Actual.Fila + @"</td>
                    <td class='tg-0lax'>" + Actual.Columna + @"</td>
                  </tr>";
                        num++;
                    }
                    Actual = Actual.Siguiente;
                }
            }
            else
            {
                // Lista Vacia
            }
        
            html += @"
                    </table>
                    <script src=''></script>
                    </body>
                    </html>";

            webForm web = new webForm(html);
            web.Show();


            //Console.WriteLine(html);
        }

        public void generarHtmlErrores()
        {
            int num = 1;
            string html = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                            <meta charset='utf-8' />
                            <meta http-equiv='x-ua-compatible' content='ie=edge, chrome=1' />
                            <title>TABLA ERRORES ARCHIVO DE ENTRADA</title>
                            <link rel='stylesheet' href='' />
                                <style type='text/css'>
                                .tg  {border-collapse:collapse;border-spacing:0;}
                                .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:black;}
                                .tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:black;}
                                .tg .tg-fymr{font-weight:bold;border-color:inherit;text-align:left;vertical-align:top}
                                .tg .tg-0pky{border-color:inherit;text-align:left;vertical-align:top}
                                </style>
                            </head>
                            <body>
<h1>TABLA ERRORES ARCHIVO DE ENTRADA</h1>
                            <table class='tg'>
                              <tr>
                                <th class='tg-1wig'>#</th>
                                <th class='tg-1wig'>Lexema</th>
                                <th class='tg-1wig'>Token</th>
                                <th class='tg-1wig'>Fila</th>
                                <th class='tg-1wig'>Columna</th>
                              </tr>";

            Nodo Actual = new Nodo();
            Actual = E.getPrimero();

            if (E.getPrimero() != null)
            {
                while (Actual != null)
                {

                        html += @"
                <tr>
                    <td class='tg-0lax'>" + num + @"</td>
                    <td class='tg-0lax'>" + Actual.Lexema + @"</td>
                    <td class='tg-0lax'>" + Actual.Token + @"</td>
                    <td class='tg-0lax'>" + Actual.Fila + @"</td>
                    <td class='tg-0lax'>" + Actual.Columna + @"</td>
                  </tr>";
                        num++;
                    
                    Actual = Actual.Siguiente;
                }
            }
            else
            {
                // Lista Vacia
            }

            html += @"
                    </table>
                    <script src=''></script>
                    </body>
                    </html>";
            //Console.WriteLine(html);
            webForm web = new webForm(html);
            web.Show();
        }

        private void ventanaHtml()
        {

        }

    }
}
