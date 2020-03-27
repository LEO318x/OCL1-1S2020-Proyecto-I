using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_1S2020_Proyecto_I
{

    class NodoT
    {
        string dato;
        string camino;
        string tipo = "";
        int num = 0;
        NodoT siguiente = null;
        NodoT anterior = null;

        public string Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public NodoT Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }

        public NodoT Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }


        /* public Nodo Inicio
         {
             get { return inicio; }
             set { inicio = value; }
         }

         public Nodo Final
         {
             get { return final; }
             set { final = value; }
         }*/
    }
    class Thompson
    {
        

        LinkedList<Nodo> ls = new LinkedList<Nodo>();
        public void Or(string op1, string op2)
        {
            NodoT t1 = new NodoT();

        }

        public void Mas(string op1)
        {
            NodoT t1 = new NodoT();
            t1.Tipo = "inicio";

            NodoT t2 = new NodoT();
            t2.Dato = "e";
            t2.Tipo = "noterminal";

            NodoT t3 = new NodoT();
            t3.Dato = op1;
            t3.Tipo = "terminal";

            NodoT t4 = new NodoT();
            t4.Dato = "e";
            t4.Tipo = "final";

            t1.Siguiente = t2;

            t2.Siguiente = t3;

            t3.Siguiente = t4;
            t3.Anterior = t2;

           // TestMas(t1);
            graficar(t1);

        }

        public void TestMas(NodoT n)
        {
            NodoT actual = new NodoT();
            actual = n;
            if (n != null)
            {
                while (actual != null)
                {
                    Console.WriteLine(actual.Tipo);
                    actual = actual.Siguiente;
                }
            }
            
        }

        public void graficar(NodoT n)
        {
            string dot = "digraph G {\n\nnode [shape = record,height=.1];\nsplines=\"line\";\n\n";

            //graficar2(this.raiz, ref dot);
            dot += "rankdir = LR;";
            string auxAnterior = "";
            int c = 0;
            NodoT actual = new NodoT();
            actual = n;
            string texto = "";
            if (n != null)
            {
                while (actual != null)
                {
                    actual.Num = c;
                    texto += "nodo" + actual.Num + "[label=\"" + actual.Num + "\"];";

                    if (actual.Tipo.Equals("inicio")) {

                    }
                    else
                    {
                        
                        texto += "nodo" + actual.Num + "->" + "nodo" + (actual.Num - 1) + "[label = \"" + actual.Dato + "\"];";
                        if (actual.Anterior != null)
                        {
                            texto += "nodo" + actual.Anterior.Num + "->" + "nodo" + actual.Num + "[label = \"e\"];";
                        }
                    }
                    
                    actual = actual.Siguiente;
                    c++;
                }
            }
            dot += texto;
            dot += "}";

            StreamWriter sw = new StreamWriter("C:\\test\\dot.txt");
            sw.Write(dot);
            sw.Close();

            string ruta = "C:\\test\\dot.txt";
            string ruta2 = "C:\\test\\Arbol.png";

            string cmd = "C:\\Graphviz\\bin\\dot.exe -Tpng " + ruta + " -o " + ruta2;

            System.Diagnostics.ProcessStartInfo miProceso = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);
            System.Diagnostics.Process.Start(miProceso);
        }
    }

    
}
