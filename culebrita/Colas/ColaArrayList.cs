using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace culebrita.Colas
{
    class ColaArrayList<T> : ICola<T>
    {
        protected int Fin;
        protected int Frente;
        protected ArrayList ArrayListCola;

        public ColaArrayList()
        {
            Frente = 0;
            Fin = -1;
            ArrayListCola = new ArrayList();
        }
        public void Encolar(T elemento) 
        {
            Fin++;
            ArrayListCola.Add(elemento);
        }

        public T Desencolar() 
        {
            if (!EstaVacia())
            {
                return (T)ArrayListCola[Frente++];
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
                return (T)ArrayListCola[Fin];
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

        public int ObtenerTamaño()
        {
            return (Fin - Frente) + 1;
        }

        public IEnumerator GetEnumerator() 
        {
            for (int i = Frente; i < Fin; i++) 
            {
                yield return ArrayListCola[i];
            }
        }
    }
}
