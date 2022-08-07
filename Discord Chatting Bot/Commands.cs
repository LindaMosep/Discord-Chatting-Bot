using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace RoguelandsDiscordBot
{
    public class Commands :  ModuleBase<SocketCommandContext> 
    {
     [Command("dolar")]
     public async Task Dolar()
        {
            WebRequest DolarKuruRequest = HttpWebRequest.Create("https://www.google.com/finance/quote/USD-TRY");
            WebResponse DolarKuruResponse = DolarKuruRequest.GetResponse();
            StreamReader GetRequest = new StreamReader(DolarKuruResponse.GetResponseStream());
            string DolarKuruPage = GetRequest.ReadToEnd();


            string dolar;

            var stindex = DolarKuruPage.IndexOf("class=\"YMlKec fxKbKc\">") + "class=\"YMlKec fxKbKc\">".Length;
            var endindex = DolarKuruPage.Substring(stindex).IndexOf("<");
            dolar =  DolarKuruPage.Substring(stindex, endindex);


       
            await ReplyAsync("ONE FUCKING DOLLAR: " + "**"+ dolar +" TL**");
        }
        
       

    }
}
