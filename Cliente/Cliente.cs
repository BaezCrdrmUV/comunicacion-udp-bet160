using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    class Cliente
    {
        static void Main(string[] args)
        {
            UdpClient cliente = new UdpClient(9050);
            string mensaje;
            byte[] datos = new byte[1024];

            try
            {
                cliente.Connect("127.0.0.1", 11000);
                datos = Encoding.ASCII.GetBytes("Cliente conectado");
                cliente.Send(datos, datos.Length);

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

                datos = cliente.Receive(ref endPoint);
               
                Console.WriteLine(Encoding.ASCII.GetString(datos, 0, datos.Length));

                while(true){

                    Console.WriteLine("Escriba un mensaje para el servidor");
                    mensaje = Console.ReadLine().ToString();
                    datos = Encoding.ASCII.GetBytes(mensaje);
                    cliente.Send(datos, datos.Length);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
