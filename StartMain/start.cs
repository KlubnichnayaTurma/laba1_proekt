using ConsoleApp; // Твоя консоль
using DataAccessLayer;
using laba1.BusinessLogic;
using logic.IoC;
using logic.Logic;
using model.Entities;
using Ninject;
using Presenter;
using Shared.Interfaces;
using System;
using System.Windows.Forms;
using winforms; // Твоя форма

namespace StartMain
{
    internal static class Program
    {
        private static SushnostModel logic;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("Выберите режим запуска:");
            Console.WriteLine("1. Графический интерфейс (WinForms)");
            Console.WriteLine("2. Консольный интерфейс");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True";
            
            IKernel kernel = new StandardKernel(new SimpleConfigModule(connString));

            logic = kernel.Get<SushnostModel>();
            
            if (choice == "1")
            {
                // Запуск WinForms
                IModel model = logic;
                IView view = new formandq();
                var presenter = new AbsolutePresenter(view, model);
                Application.Run((Form)view);
            }
            else if (choice == "2")
            {
                IModel model = logic;
                var view = new ConsoleView();
                var presenter = new AbsolutePresenter(view, model);
                view.Start();
            }
            else
            {
                Console.WriteLine("Неверный выбор. Программа завершена.");
            }
        }
    }
}