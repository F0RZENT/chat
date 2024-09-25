using UDPserver;

class Program
{
    public static async Task Main(string[] args)
    {
        await Server.AcceptMessage();
    }
}