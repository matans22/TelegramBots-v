using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace YoasimBot
{
    class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("484612948:AAEzIj0rSB042UJLb_wqRYp4nodhsKzl6tQ");//483668878:AAH5Z47_dZcWEe95H2F5XgvRexic23ZR3O8
        static ReplyKeyboardMarkup markup = new ReplyKeyboardMarkup();
        static string[] arr = new string[5];
        static int i = 0;
        
        static void Main(string[] args)
        {
            bot.StartReceiving();
            bot.OnMessage += Bot_OnMessage;
            arr[0] = "ברוכים הבאים ליוע" + '"' + "סים (יועצי סמים), מטרתינו היא להפיץ מידע בנוגע לשימוש נכון בסמים ומזעור נזקים אנא קרא/י את החוקים הבאים בקפדנות. לאחר קריאתם," +
                        " יתקבל לינק כניסה לקבוצה. ";
            arr[1] = "אסור לבקש או להציע כיוון, העונש הוא הרחקה מיידית מהקבוצה.";
            arr[2] = "אין לייעץ אם אינך יוע" + '"' + "ס. מטרת חוק זה היא מניעת הפצת מידע שגוי, אנא תן/י לנו לעשות את עבודתינו. ניתנת חריגה במידה ויוע" + '"' + "ס ענה על שאלה ולדעתך יש פרט מידע חשוב שהתפספס";
            arr[3] = "אנא המנע/י מדיונים בנושאים שאינם בטיחות בסמים. יש לזכור שמטרת הקבוצה היא ערוץ מידע וקו חם לצרכנים.";
            arr[4] = "מעולה! לכניסה:https://t.me/joinchat/FMcvyEHi4dDlubt0C2mNyQ";
           
            Console.ReadLine();
        }
        /*אין לייעץ אם אינך יוע''ס.
מטרת חוק זה היא מניעת הפצה מידע שגוי, אנא תן/י לנו לעשות את עבודתינו.
ניתנת חריגה במידה ויוע"ס ענה על שאלה ולדעתך יש פרט מידע חשוב שהתפספס.*/
        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            
            if(e.Message.Type== MessageType.TextMessage)
            {
                var txt = e.Message.Text;
                var cid = e.Message.Chat.Id;
                var name = e.Message.From.FirstName + " " + e.Message.From.LastName;
                var uid = e.Message.From.Id;
                Console.WriteLine("{0} - {1} : {2}", uid, name, txt);
                if(txt== "/start")
                {
                    i = 0;
                    markup.ResizeKeyboard = true;
                    markup.Keyboard = new Telegram.Bot.Types.KeyboardButton[][]
                        {
                            new Telegram.Bot.Types.KeyboardButton[]
                            {
                                new Telegram.Bot.Types.KeyboardButton("הבא"),
                                new Telegram.Bot.Types.KeyboardButton("חזור")
                            },
                        };

                    await bot.SendTextMessageAsync
                        (cid,arr[0],ParseMode.Default,false,false,0,markup);
                    i++;
                }
                else if (txt =="הבא")
                {
                    if (i >= arr.Length) { i = 0; }
                    await bot.SendTextMessageAsync(cid, arr[i++]);

                    
                }
                else if( txt=="חזור")
                {
                    if (i - 1<= 0) { await bot.SendTextMessageAsync(cid, "פעולה לא חוקית"); return; }
                    
                    await bot.SendTextMessageAsync(cid, arr[--i-1]);
                    
                  
                }
                else
                {
                    
                    await bot.SendTextMessageAsync(cid, txt);
                }

            }
        }
    }
}
