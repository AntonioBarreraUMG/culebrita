using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using culebrita.Colas;

namespace culebrita
{
    class Program
    {
        static void Main()
        {
            ConsoleKey tecla;
            do
            {
                var pantalla = new Pantalla();
                var culebra = new Culebra();

                var punteo = 0;
                var velocidad = 100; //modificar estos valores y ver qué pasa
                var posiciónComida = Point.Empty;
                var tamañoPantalla = new Size(60, 20);

                //var culebrita = new ColaLineal<Point>();
                //var culebrita = new ColaArrayList<Point>();
                var culebrita = new ColaListaEnlazada<Point>();

                var longitudCulebra = 3; //modificar estos valores y ver qué pasa
                var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
                culebrita.Encolar(posiciónActual);
                var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa

                pantalla.DibujaPantalla(tamañoPantalla);
                pantalla.MuestraPunteo(punteo);

                while (culebra.MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
                {
                    Thread.Sleep(velocidad);
                    dirección = culebra.ObtieneDireccion(dirección);
                    posiciónActual = culebra.ObtieneSiguienteDireccion(dirección, posiciónActual);

                    if (posiciónActual.Equals(posiciónComida))
                    {
                        Console.Beep();
                        posiciónComida = Point.Empty;
                        longitudCulebra++; //modificar estos valores y ver qué pasa
                        punteo += 10; //modificar estos valores y ver qué pasa
                        pantalla.MuestraPunteo(punteo);
                        velocidad -= velocidad/20;
                    }

                    if (posiciónComida == Point.Empty) //entender qué hace esta linea
                    {
                        posiciónComida = culebra.MostrarComida(tamañoPantalla, culebrita);
                    }
                }

                Console.ResetColor();
                Console.SetCursorPosition(tamañoPantalla.Width / 2 - 27, tamañoPantalla.Height / 2);
                Console.WriteLine("Presiona cualquier tecla para continuar y F para salir.");
                tecla = Console.ReadKey(true).Key;
            } while (tecla != ConsoleKey.F);

        }


    }//end class
}













