using System;
using System.Net;
using System.IO;
class GameServer
{
    public void start()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:3333/");
        listener.Start();

        while(true)
        {
            HttpListenerContext cycle = listener.GetContext();
            Console.WriteLine("Got request for {0} from {1}.", cycle.Request.RawUrl, cycle.Request.RemoteEndPoint);
            StreamWriter outgoing = new StreamWriter(cycle.Response.OutputStream);
            cycle.Response.ContentType = "text/plain";
            outgoing.WriteLine("It works!");
            outgoing.Close();
            cycle.Response.Close();
        }
    }
}