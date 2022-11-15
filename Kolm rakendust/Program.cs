using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolm_rakendust
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());


            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Loginandpass maksim = new Loginandpass { kasutajanimi = "maksim", email = "lagunovski.m@gmail.com" };

                // добавляем их в бд
                db.Logins.Add(maksim);
                db.SaveChanges();
                //Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Logins.ToList();
                Console.WriteLine("List:");
                foreach (Loginandpass u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.kasutajanimi} - {u.email}");
                }
            }
        }


    }


}

