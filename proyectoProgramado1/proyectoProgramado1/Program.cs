using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgramado1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float totalAcumulado = 0;
            bool agregarMasProductos;

            do
            {
                float precioUnitario = solicitarPrecio();
                int cantidad = solicitarCantidad();

                float subTotal = calcularSubtotal(precioUnitario, cantidad);
                float impuesto = calcularImpuesto(precioUnitario, subTotal);
                float precioVenta = subTotal + impuesto;

                resultados(subTotal, impuesto, precioVenta);

                totalAcumulado += precioVenta;

                agregarMasProductos = continuarCompra();

            } while (agregarMasProductos);

            Console.WriteLine($"El total a pagar por todos los productos es: ¢{totalAcumulado}.\n");
        }

        static float solicitarPrecio()
        {
            Console.Write("Ingrese el precio del producto:\n");
            return float.Parse(Console.ReadLine()); 
        }

        static int solicitarCantidad()
        {
            Console.Write("Ingrese la cantidad del producto:\n");
            return int.Parse(Console.ReadLine());
        }

        static float calcularSubtotal(float precioUnitario, int cantidad)
        {
            return precioUnitario * cantidad;
        }

        static float calcularImpuesto(float precioUnitario, float subTotal)
        {
            if (precioUnitario <= 1000)
            {
                return subTotal * 0.08f;
            }
            else if (precioUnitario > 1000 && precioUnitario < 5000)
            {
                return subTotal * 0.10f;
            }
            else
            {
                return subTotal * 0.13f;
            }
        }

        static void resultados(float subTotal, float impuesto, float precioVenta)
        {
            Console.WriteLine($"El subtotal es: {subTotal} colones.");
            Console.WriteLine($"El impuesto es: {impuesto} colones.");
            Console.WriteLine($"El precio total a pagar por este producto es: {precioVenta} colones.");
        }

        static bool continuarCompra()
        {
            string respuesta;
            do
            {
                Console.Write("¿Desea agregar otro producto? (si/no):\n");
                respuesta = Console.ReadLine().ToLower();
            } while (respuesta != "si" && respuesta != "no");

            return respuesta == "si";
        }
    }
}
