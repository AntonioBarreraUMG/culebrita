using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace culebrita.Colas
{
    interface ICola<T> : IEnumerable
    {
        void Encolar(T elemento);
        T Desencolar();
        void Limpiar();
        T ObtenerFinal();
        bool EstaVacia();
        int ObtenerTamaño();

    }
}