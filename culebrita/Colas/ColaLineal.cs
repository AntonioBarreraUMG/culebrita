using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace culebrita.Colas
{
    class ColaLineal<T> : ICola<T>
    {
        protected int Fin;
        private static int MAXTAM = 100;
        protected int Frente;

        protected T[] ArregloCola;

        public ColaLineal()
        {
            Frente = 0;
            Fin = -1;
            ArregloCola = new T[MAXTAM];
        }

        public void Encolar(T elemento)
        {
            if (!EstaLlena())
            {
                ArregloCola[++Fin] = elemento;
            }
            else
            {
                throw new Exception("Overflow en la cola");
            }
        }

        public T Desencolar()
        {
            if (!EstaVacia())
            {
                return ArregloCola[Frente++];
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public void Limpiar()
        {
            Frente = 0;
            Fin = -1;
        }

        public T ObtenerFinal()
        {
            if (!EstaVacia())
            {
                return ArregloCola[Fin];
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public bool EstaVacia()
        {
            return Frente > Fin;
        }

        public bool EstaLlena()
        {
            return Fin == (MAXTAM - 1);
        }

        public int ObtenerTamaño()
        {
            return (Fin - Frente) + 1;
        }

        public IEnumerator GetEnumerator() 
        {
            for (int i = Frente; i < Fin; i++) 
            {
                yield return ArregloCola[i];
            }
        }
    }
}