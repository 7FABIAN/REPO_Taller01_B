using System;
using System.IO;
using System.Text;

namespace TallerCsharpfabian {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("TALLER IUJO: GESTIÓN DE ARCHIVOS");


            // desafio 1
            Console.WriteLine("Ejecutando Desafío 1...");
            string datosEntrada = "fabian_usuario;clave123"; 
            string[] partes = datosEntrada.Split(';');

            if (partes.Length >= 2 && partes[1].Contains("123")) {
                using (StreamWriter sw = new StreamWriter("seguridad.txt", true)) {
                    sw.WriteLine("Clave Débil detectada para el usuario: " + partes[0]);
                }
                Console.WriteLine("> Registro de seguridad creado.");
            }

            // desafio 2
            Console.WriteLine("\nEjecutando Desafío 2...");
            string fotoOriginal = "avatar.jpg";
            string fotoCopia = "respaldo.jpg";

           
            if (!File.Exists(fotoOriginal)) {
                File.WriteAllText(fotoOriginal, "simulacion de bytes de imagen");
            }

            using (FileStream fsIn = new FileStream(fotoOriginal, FileMode.Open, FileAccess.Read))
            using (FileStream fsOut = new FileStream(fotoCopia, FileMode.Create, FileAccess.Write)) {
                byte[] buffer = new byte[1024];
                int cantidad;
                while ((cantidad = fsIn.Read(buffer, 0, buffer.Length)) > 0) {
                    fsOut.Write(buffer, 0, cantidad);
                }
            }
            Console.WriteLine("> Clonación byte a byte terminada.");

            // desafio 3
            Console.WriteLine("\nEjecutando Desafío 3...");
            // Buscamos en la carpeta donde se ejecuta el programa
            string rutaActual = AppDomain.CurrentDomain.BaseDirectory;
            string[] listaArchivos = Directory.GetFiles(rutaActual);

            foreach (string ruta in listaArchivos) {
                FileInfo info = new FileInfo(ruta);
                // 5KB son 5120 bytes
                if (info.Length > 5120) {
                    Console.WriteLine("> Archivo pesado encontrado: " + info.Name + " (" + info.Length + " bytes)");
                    // Para borrarlo  info.Delete();
                }
            }

            Console.WriteLine("\n=== TODO CORRECTO. Presiona una tecla para salir ===");
            Console.ReadKey();
        }
	}
}