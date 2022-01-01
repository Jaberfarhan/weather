using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleApp4
{
    
    class Program
    {
        string ss;
        static TelegramBotClient Bot = new TelegramBotClient("5096913389:AAGuL1gb_QiF-i2z1JzUpzIPMM2PvJ3wGac");
        static void Main(string[] args)
        {
           
            // MessageBox.Show(salah.today.Fajr);
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;
            Console.ReadLine();
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.StartsWith("/start"))
                {
                    // try
                    // {
                    string ss = "";

                        WebRequest flight = HttpWebRequest.Create("https://airport-info.p.rapidapi.com/airport?icao="+ e.Message.Text.Split(' ')[1].ToString());
                        // WebRequest student = HttpWebRequest.Create("https://dailyprayer.abdulrcs.repl.co/api/"+e.Message.Text.Split(' ')[1].ToString());
                        flight.Headers.Add("x-rapidapi-key", "ce19d0164fmsh3d383efc0e85ce5p16dcb1jsnb1a4a3c79541");
                       flight.Headers.Add("x-rapidapi-host","airport-info.p.rapidapi.com");
                        WebResponse flight1 = flight.GetResponse();
                        
                    StreamReader flight2 = new StreamReader(flight1.GetResponseStream());
                      
                    string response2 = flight2.ReadToEnd();
                        Root salah = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(response2);
                        ss = salah.country.ToString()+"\n"+ salah.state.ToString() + "\n" + salah.latitude.ToString() + "\n" + salah.longitude.ToString() + "\n" + salah.website.ToString(); ; ;// +"الفجر"+salah.today.Sunrise + "شروق الشمس"+ salah.today.Dhuhr + "الظهر "+ salah.today.Asr + "العصر"+ salah.today.Maghrib + "المغرب "+ salah.today.Sunrise + "العشاء";
                    string response12 = ss;
                   // response12 += e.Message.Text.ToString();
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, response12);
                  //  }
                   //catch(Exception)
                   // {
                        Bot.SendTextMessageAsync(e.Message.Chat.Id,"please your input must be /start location");
                    //}

                }
            }
        }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root
    {
        public int id { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string street_number { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string country_iso { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int uct { get; set; }
        public string website { get; set; }
    }

}
