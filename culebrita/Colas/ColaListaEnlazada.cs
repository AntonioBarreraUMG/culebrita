using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace culebrita.Colas
{
    class ColaListaEnlazada<T> : ICola<T>
    {
        protected LinkedList<T> ListaEnlazadaCola;

        public ColaListaEnlazada()
        {
            ListaEnlazadaCola = new LinkedList<T>();
        }
        public void Encolar(T elemento) 
        {
            ListaEnlazadaCola.AddLast(elemento);
        }

        public T Desencolar() 
        {
            var elemento = ListaEnlazadaCola.First();
            ListaEnlazadaCola.RemoveFirst();
            return elemento;
        }

        public void Limpiar()
        {
            ListaEnlazadaCola.Clear();
        }

        public T ObtenerFinal()
        {
            return ListaEnlazadaCola.Last();
        }

        public bool EstaVacia()
        {
            return ListaEnlazadaCola.Count == 0;
        }

        public int ObtenerTamaño()
        {
            return ListaEnlazadaCola.Count;
        }

        public IEnumerator GetEnumerator() 
        {
            foreach (var elemento in ListaEnlazadaCola) 
            {
                yield return elemento;
            }
        }
    }
}
