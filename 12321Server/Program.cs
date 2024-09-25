﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static TcpListener server;
    static TcpClient client1;
    static TcpClient client2;
    static NetworkStream stream1;
    static NetworkStream stream2;
    static string historyFolderPath = "ChatHistory";

    static async Task Main(string[] args)
    {
        server = new TcpListener(IPAddress.Any, 12345);
        server.Start();

        Console.WriteLine("Сервер запущен. Ожидание подключений...");

        client1 = await server.AcceptTcpClientAsync();
        stream1 = client1.GetStream();
        Console.WriteLine("Первый клиент подключен.");

        client2 = await server.AcceptTcpClientAsync();
        stream2 = client2.GetStream();
        Console.WriteLine("Второй клиент подключен.");

        Task.Run(async () => await ReceiveAndSendMessages(stream1, stream2, client1, client2));
        Task.Run(async () => await ReceiveAndSendMessages(stream2, stream1, client2, client1));

        Console.ReadLine();
    }

    static async Task ReceiveAndSendMessages(NetworkStream fromStream, NetworkStream toStream, TcpClient fromClient, TcpClient toClient)
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[1024];
                int bytesRead = await fromStream.ReadAsync(data, 0, data.Length);
                string message = Encoding.UTF8.GetString(data, 0, bytesRead);

                Console.WriteLine("Новое сообщение от клиента: " + message);

                byte[] responseData = Encoding.UTF8.GetBytes(message);
                await toStream.WriteAsync(responseData, 0, responseData.Length);

                string historyFilePath = Path.Combine(historyFolderPath, $"{((IPEndPoint)fromClient.Client.RemoteEndPoint).Address}_{((IPEndPoint)toClient.Client.RemoteEndPoint).Address}_chat_history.txt");
                SaveMessageToHistory(historyFilePath, ((IPEndPoint)fromClient.Client.RemoteEndPoint).Address.ToString(), message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении/отправке сообщения: " + ex.Message);
                break;
            }
        }
    }

    static void SaveMessageToHistory(string filePath, string ipAddress, string message)
    {
        if (!Directory.Exists(historyFolderPath))
        {
            Directory.CreateDirectory(historyFolderPath);
        }

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{DateTime.Now} - IP: {ipAddress}, Message: {message}");
        }
    }
}

