using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio
{
    internal class ClsProducto
    {
        // Atributos
        public int Codigo;
        public string Descripcion;
        public int Existencia;
        public int Minimo;
        public float Precio;
        public static List<ClsProducto> producto = new List<ClsProducto>();

        // Constructor
        public ClsProducto(int codigo, string descripcion, int existencia, int minimo, float precio)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Existencia = existencia;
            Minimo = minimo;
            Precio = precio;
        }     
        public ClsProducto() { }  
       
        public void Agregar()
        {
            Boolean fin = true;
            do
            {
                Console.WriteLine("Digite el codigo");
                int cod = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite la Descripcion");
                string descripcion = Console.ReadLine();
                Console.WriteLine("Digite La existencia");
                int existencia = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite el minimo");
                int minimo = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite precio");
                float precio = float.Parse(Console.ReadLine());
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El producto se ingreso correctamente");
                Console.ReadKey();
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("Desea ingresar otro producto: ");
                string n = Console.ReadLine();

                producto.Add(new ClsProducto() { Codigo = cod, Descripcion = descripcion, Existencia = existencia, Minimo = minimo, Precio = precio });

                if (n.Equals("n")) fin = false;
            } while (fin);

        }
        public static void Venta()
        {
            Reporte();

            Console.Write("Ingrese el código del artículo que desea vender: ");

            if (int.TryParse(Console.ReadLine(), out int codigoProducto))
            {
                Console.Write("Ingrese la cantidad a vender: ");
                if (int.TryParse(Console.ReadLine(), out int cantidadAVender))
                {
                    ClsProducto articuloAVender = producto.Find(a => a.Codigo == codigoProducto);

                    if (articuloAVender != null && articuloAVender.Existencia >= cantidadAVender)
                    {
                        articuloAVender.Existencia -= cantidadAVender;

                        int cantidadDisponibleDespuesVenta = articuloAVender.Existencia;

                        Console.WriteLine($"Venta realizada con éxito. Disponible: {cantidadDisponibleDespuesVenta}");
                    }
                    else
                    {
                        Console.WriteLine("Artículo no encontrado o cantidad insuficiente.");
                    }
                }
                else
                {
                    Console.WriteLine("¡¡El código digitado no existe!!");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo e ingrese un número entero.");
            }
        }

        public static void ActualizarProducto()
        {
            Reporte();
           
            Console.WriteLine("Digite el codigo del producto"); 
            if (int.TryParse(Console.ReadLine(), out int codigoProducto))
            {
                Console.Write("Ingrese el precio actualizado: ");
                if (int.TryParse(Console.ReadLine(), out int precioActualizado))
                {
                    ClsProducto articuloAVender = producto.Find(a => a.Codigo == codigoProducto);

                    if (articuloAVender != null && articuloAVender.Existencia >= precioActualizado)
                    {
                        articuloAVender.Existencia -= precioActualizado;

                        int cantidadDisponibleDespuesVenta = articuloAVender.Existencia;

                        Console.WriteLine($"Venta realizada con éxito. Disponible: {cantidadDisponibleDespuesVenta}");
                    }
                    else
                    {
                        Console.WriteLine("Artículo no encontrado o cantidad insuficiente.");
                    }
                }
                else
                {
                    Console.WriteLine("¡¡El código digitado no existe!!");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo e ingrese un número entero.");
            }
        }

        public static void ActualizarPrecio()
        {
            Reporte();

            Console.WriteLine("Digite el código del producto:");
            if (int.TryParse(Console.ReadLine(), out int codigoProducto))
            {
                ClsProducto articuloAVender = producto.Find(a => a.Codigo == codigoProducto);

                if (articuloAVender != null)
                {
                    Console.Write($"El precio actual del producto '{articuloAVender.Descripcion}' es: {articuloAVender.Precio}. Ingrese el nuevo precio: ");
                    if (float.TryParse(Console.ReadLine(), out float precioActualizado))
                    {
                        articuloAVender.Precio = precioActualizado;
                        Console.WriteLine($"¡El precio del producto '{articuloAVender.Descripcion}' se actualizó correctamente a: {articuloAVender.Precio}!");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Intente de nuevo e ingrese un número decimal para el precio.");
                    }
                }
                else
                {
                    Console.WriteLine("¡El código de producto ingresado no existe!");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo e ingrese un número entero para el código de producto.");
            }
        }

        public static void Borrar()
        {
            Console.WriteLine("De los siguienetes datos ingresados cual desea borrar: ");
            foreach (var item in producto)
            {
                Console.WriteLine($"Código:{item.Codigo} Descripción:{item.Descripcion} Precio:{item.Precio} Existencia:{item.Existencia}");
            }

            Console.Write("Ingrese el código que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int codigoBorrar))
            {
                ClsProducto productoAEliminar = producto.Find(a => a.Codigo == codigoBorrar);

                if (productoAEliminar != null)
                {
                    producto.Remove(productoAEliminar);
                    Console.WriteLine($"¡¡El código:{codigoBorrar} se eliminó con éxito.!!");
                }
                else
                {
                    Console.WriteLine($"¡¡No se encontró el código:{codigoBorrar}.!!");
                }
            }
            else
            {
                Console.WriteLine("¡¡Entrada invalida o código no existe!!");
            }
        }

        public static void Reporte()
        {
            Console.WriteLine("*** Articulos Registrados ***");
            foreach (var item in producto)
            {
                Console.WriteLine($"Código:{item.Codigo} Descripción:{item.Descripcion} Precio:{item.Precio} Existencia:{item.Existencia}");
            }

        }
    }
}
