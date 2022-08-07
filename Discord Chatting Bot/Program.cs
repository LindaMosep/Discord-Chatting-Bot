using Discord;                //discord
using Discord.Commands;       //discord
using Discord.WebSocket;      //discord
using Microsoft.Extensions.DependencyInjection;
using RoguelandsDiscordBot.Forms;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RoguelandsDiscordBot
{
    class Program
    {
     
        public static DiscordSocketClient _client;
        public static CommandService _commands;
        public static IServiceProvider _services;
        public static bool isLogged = false;
   

   
       
        [STAThread]
        static void Main(string[] args)
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());

        }
        public static async Task MainAsync()
        {
            Console.WriteLine("Started");
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();
            _client.Log += Log;
            var token = "";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            _client.MessageReceived += MessageRecieve;


            await Task.Delay(-1);


        }

 


    
        static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        static async Task MessageRecieve(SocketMessage e)
        {
            var user = e.Author as IGuildUser;

            if(user != null)
            {
                var guild = user.Guild;
                if(e.Content.StartsWith(".linkbutton "))
                {

                }


            }


            if(e.Content.StartsWith("_dolar"))
            {
                WebRequest DolarKuruRequest = HttpWebRequest.Create("https://www.google.com/finance/quote/USD-TRY");
                WebResponse DolarKuruResponse = DolarKuruRequest.GetResponse();
                StreamReader GetRequest = new StreamReader(DolarKuruResponse.GetResponseStream());
                string DolarKuruPage = GetRequest.ReadToEnd();


                string dolar;

                var stindex = DolarKuruPage.IndexOf("class=\"YMlKec fxKbKc\">") + "class=\"YMlKec fxKbKc\">".Length;
                var endindex = DolarKuruPage.Substring(stindex).IndexOf("<");
                dolar =  DolarKuruPage.Substring(stindex, endindex);



                await e.Channel.SendMessageAsync("ONE FUCKING DOLLAR: " + "**"+ dolar +" TL**", false, null ,null ,null, e.Reference);
            }
            
            await Task.Delay(100);
        }


    }
}
