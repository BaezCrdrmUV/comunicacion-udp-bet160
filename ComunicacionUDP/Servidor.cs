using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ComunicacionUDP
{
    class Servidor
    {
        static void Main(string[] args)
        {
            byte[] datos = new byte[1024];
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11000);
            UdpClient servidor = new UdpClient(endPoint);
            Console.WriteLine("Esperando la conexion del cliente...");
            
            try{

                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

                datos = servidor.Receive(ref sender);

                Console.WriteLine(Encoding.ASCII.GetString(datos, 0, datos.Length));

                datos = Encoding.ASCII.GetBytes("Conexion lista puede enviar mensajes");
                servidor.Send(datos, datos.Length, sender);

                while (true)
                {
                datos = servidor.Receive(ref sender);

                Console.WriteLine(Encoding.ASCII.GetString(datos, 0, datos.Length));
                servidor.Send(datos, datos.Length, sender);
                }
                
            }catch(Exception e){
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
