using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDPServer;
using UDPServer.Models;

namespace UDPserver
{
    public class Server
    {

        public static async Task AcceptMessage()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(35486);

            Console.WriteLine("Сервер запущен");
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref ep);
                string data = Encoding.UTF8.GetString(buffer);

                Message message = Message.FromJSON(data);
                if (message.Command == "Send")
                {
                    string ipFromMod = ModIP(message.IpFrom);
                    string ipToMod = ModIP(message.IpTo);

                    string fileName = GenerateFileName(ipFromMod, ipToMod);
                    if (fileName != null)
                    {
                        var curDir = Directory.GetCurrentDirectory();
                        curDir = curDir.Replace("\\","/");
                        string newFileName = String.Format($"{curDir}/history/{fileName}.txt");
                        Chat chat = new Chat(fileName);
                        chat.Messages.Add(message);
                        MongoConector.UpdateData(chat);
                        // using var sw = new StreamWriter(newFileName, true);
                        //sw.Write(ipFromMod + ":" + message.Text + "\n");
                        //await sw.WriteAsync(message.ToJSON() + "\n");
                        //sw.Flush();
                    }
                    
                   
                    
                }
                else if (message.Command == "Update")
                {
                    string IpFromMod = ModIP(message.IpFrom);
                    string IpToMod = ModIP(message.IpTo);
                    string fileName = GenerateFileName(IpFromMod, IpToMod);
                    var curDir = Directory.GetCurrentDirectory();
                    curDir = curDir.Replace("\\", "/");
                    string file = String.Format($"{curDir}/history/{fileName}.txt");
                    try
                    {
                        using var sr = new StreamReader(file, true);
                        string pathMessage = file;
                        byte[] messageBytes = System.IO.File.ReadAllBytes(file);

                        udpClient.Send(messageBytes, new IPEndPoint(IPAddress.Parse(message.IpFrom), 34285));
                    }
                    catch(Exception e)
                    {

                    }
                    
                }
            }

        }
        public static string GenerateFileName(string firstIp, string secondIp)
        {
            
                string[] arr1 = firstIp.Split('_');
                string[] arr2 = secondIp.Split('_');
                for (int i = 0; i < 4; i++)
                {
                    if (int.Parse(arr1[i]) > int.Parse(arr2[i]))
                    {
                        return secondIp + "=" + firstIp;
                    }
                    else if (int.Parse(arr1[i]) < int.Parse(arr2[i]))
                    {
                        return firstIp + '=' + secondIp;
                    }
                }
            return null;


        }
        //192.168.220.223
        public static string ModIP(string adres)
        {
            adres = adres.Replace(".", "_");
            string modIp = "";

            for (int i = 0; i < adres.Length; i++)
            {
                if (adres[i] == ':')
                {
                    modIp = adres.Substring(0, i);
                }
            }
            if (modIp == "")
            {
                modIp = adres;
            }
            return modIp;
     

        }
    }
}
