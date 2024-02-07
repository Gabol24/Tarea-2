using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio
{
    internal class ClsMenu
    {

        public static int opcion;

        public static void menu()
        {
            ClsProducto articulo = new ClsProducto();
            try
            {
                do
                {
                    Console.WriteLine("1- Agregar Productos");
                    Console.WriteLine("2- Venta de Productos");
                    Console.WriteLine("3- Actualizar Productos");
                    Console.WriteLine("4- Actualizar Precio");
                    Console.WriteLine("5- Borrar Producto");
                    Console.WriteLine("6- Reporte ");
                    Console.WriteLine("7- Salir");
                    Console.WriteLine("Digite una opcion...");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1: articulo.Agregar(); break;
                        case 2: ClsProducto.Venta(); break;
                        case 3: ClsProducto.ActualizarProducto(); break;
                        case 4: ClsProducto.ActualizarPrecio(); break;
                        case 5: ClsProducto.Borrar(); break;
                        case 6: ClsProducto.Reporte(); break;
                        case 7: break;
                        default:Console.WriteLine("Opcion incorrecta"); break;
                    }

                } while (opcion != 7);
            }
            catch (Exception ex )
            {
                Console.WriteLine("¡Digitaste mal el código!" + ex);
            }          
        }
    }
}
