using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_1S2020_Proyecto_I
{
    class Lista
    {
        private Nodo Primero = new Nodo();
        private Nodo Ultimo = new Nodo();

        public Lista()
        {
            Primero = null;
            Ultimo = null;
        }

        public Nodo getPrimero()
        {
            return Primero;
        }

        public void insertar(string token, string lexema, int fila, int columna)
        {
            Nodo Nuevo = new Nodo();

            Nuevo.Token = token;
            Nuevo.Lexema = lexema;
            Nuevo.Fila = fila;
            Nuevo.Columna = columna;

            if(Primero == null)
            {
                Primero = Nuevo;
                Primero.Siguiente = null;
                Ultimo = Nuevo;
            }
            else
            {
                Ultimo.Siguiente = Nuevo;
                Nuevo.Siguiente = null;
                Ultimo = Nuevo;
            }
        }

        public void desplegar()
        {
            Nodo Actual = new Nodo();
            Actual = Primero;

            if(Primero != null)
            {
                while (Actual != null)
                {
                    Console.WriteLine(Actual.Token);
                    Actual = Actual.Siguiente;
                }
            }
            else
            {
                // Lista Vacia
            }
        }

        
    }
}
