//using logic.IoC;
//using logic.Logic;
//using model.Entities;
//using Ninject;
//using System;

//namespace ConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True";

//            IKernel kernel = new StandardKernel(new SimpleConfigModule(connString));

//            SushnostLogic logic = kernel.Get<SushnostLogic>();

//            while (true)
//            {
//                Console.Clear();

//                Console.WriteLine("");
//                Console.WriteLine($"Стабильность: {logic.GetStability()}");
//                Console.WriteLine($"");
//                Console.WriteLine($"|||| 1. Добавить сущность");
//                Console.WriteLine($"|||| 2. Удалить сущность");
//                Console.WriteLine($"|||| 3. Изменить сущность");
//                Console.WriteLine($"|||| 4. Список сущностей");
//                Console.WriteLine($"|||| 5. Вызвать разлом");
//                Console.WriteLine($"|||| 6. Стабилизировать");
//                Console.WriteLine($"|||| 7. Выход");
//                Console.WriteLine($"");
//                Console.WriteLine("Ввод:");

//                string Input = Console.ReadLine();

//                if (!int.TryParse(Input, out int answer) || !(Convert.ToInt32(Input) >=1 && Convert.ToInt32(Input) <= 7) || Input == "")
//                {
//                    Console.Clear();

//                    Console.WriteLine("Введите число от 1 до 7");
//                    Console.ReadLine();
//                    continue;
//                }

//                switch (Convert.ToInt32(Input))
//                {
//                    case 1:
//                        Console.Clear();

//                        Console.WriteLine("Обзовите сущность");
//                        string name = Console.ReadLine();
//                        if (name == "")
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Нет.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        logic.Add(name);
//                        continue;
//                    case 2:
//                        Console.Clear();

//                        Console.WriteLine("Кто из них вам не угодил? (Id)");
//                        string id = Console.ReadLine();
//                        if (!int.TryParse(id, out int answer2) || id == "")
//                        {
//                            Console.Clear();

//                            Console.WriteLine("Введите число.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        if (!logic.Evaporate(Convert.ToInt32(id)))
//                        {
//                            Console.Clear();

//                            Console.WriteLine("Не нашли.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        else
//                        {
//                            Console.Clear();

//                            Console.WriteLine("Готово.");
//                            Console.ReadLine();
//                            continue;
//                        }

//                    case 3:
//                        Console.Clear();


//                        Console.Clear();
//                        Console.WriteLine("Какому Id присвоить?");
//                        string ans = Console.ReadLine();
//                        if (!int.TryParse(ans, out int answer3) || ans == "")
//                        {
//                            Console.Clear();

//                            Console.WriteLine("Введите число.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        Console.WriteLine("Введите новое имя:");
//                        string New_Name = Console.ReadLine();
//                        if (New_Name == "")
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Нет.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        if (logic.Edit(Convert.ToInt32(ans), New_Name))
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Готово.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        else
//                        {
//                            Console.Clear();
//                            Console.Clear();
//                            Console.WriteLine("Не нашли.");
//                            Console.ReadLine();
//                            continue;
//                        }



//                    case 4:
//                        Console.Clear();

//                        if (logic.SData().Count > 0)
//                        {
//                            foreach (Sushnost sushnost in logic.SData())
//                            {
//                                Console.WriteLine($"Имя: {sushnost.Name}, Id: {sushnost.Id}, Трансцендентность: {sushnost.Transcendence}, Возраст: {sushnost.Age}");
//                            }
//                            Console.ReadLine();
//                            continue;
//                        }
//                        else
//                        {
//                            Console.WriteLine("Пустота.");
//                            Console.ReadLine();
//                            continue;
//                        }

//                    case 5:
//                        Console.Clear();

//                        if (!logic.Rift())
//                        {
//                            Console.WriteLine("Пустота.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        else
//                        {
//                            Console.WriteLine("Успешно. Проверьте сущности.");
//                            Console.ReadLine();
//                            continue;
//                        }

//                    case 6:
//                        Console.Clear();

//                        if (!logic.Stabilize())
//                        {
//                            Console.WriteLine("Пустота.");
//                            Console.ReadLine();
//                            continue;
//                        }
//                        else
//                        {
//                            Console.WriteLine("Успешно. Проверьте сущности.");
//                            Console.ReadLine();
//                            continue;
//                        }

//                    case 7: 
//                        Console.Clear();

//                        if (logic.SData().Count == 0)
//                        {
//                            Console.WriteLine("Безопасный выход из системы...");
//                            Console.ReadLine();
//                            return;
//                        }
//                        else
//                        {
//                            Console.WriteLine("Они найдут вас.");
//                            Console.ReadLine();
//                            return;
//                        }


//                }































//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using Shared.DTO;        
using Shared.Interfaces; 

namespace ConsoleApp
{
    // 1. Класс консоли реализует IView
    public class ConsoleView : IView
    {
        public event EventHandler LoadRequest;
        public event EventHandler AddRequest;
        public event EventHandler<int> DeleteRequest;
        public event EventHandler<(int id, string name)> EditRequest;
        public event EventHandler RiftRequest;
        public event EventHandler StabilizeRequest;
        public event EventHandler ExitRequest;

        private bool _isRunning = true;

        public void Start()
        {
            while (_isRunning)
            {
                Console.Clear();
                // Просим Presenter загрузить данные
                LoadRequest?.Invoke(this, EventArgs.Empty);

                Console.WriteLine("|||| 1. Добавить\n|||| 2. Удалить\n|||| 3. Изменить\n|||| 5. Разлом\n|||| 6. Стабилизация\n|||| 7. Выход");
                Console.Write("Ввод: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1: AddRequest?.Invoke(this, EventArgs.Empty); break;
                        case 2:
                            string idStr = ShowInputBox("Id для удаления", "");
                            if (int.TryParse(idStr, out int idDel)) DeleteRequest?.Invoke(this, idDel);
                            break;
                        case 3:
                            string idEditStr = ShowInputBox("Id для изменения", "");
                            if (int.TryParse(idEditStr, out int idEdit))
                            {
                                string newName = ShowInputBox("Новое имя", "");
                                if (!string.IsNullOrWhiteSpace(newName)) EditRequest?.Invoke(this, (idEdit, newName));
                            }
                            break;
                        case 5: RiftRequest?.Invoke(this, EventArgs.Empty); break;
                        case 6: StabilizeRequest?.Invoke(this, EventArgs.Empty); break;
                        case 7: ExitRequest?.Invoke(this, EventArgs.Empty); break;
                    }
                }
            }
        }

        // --- Методы IView ---

        public void ShowData(List<SushnostDto> data, double stability)
        {
            Console.WriteLine($"Стабильность: {stability}");
            if (data.Count == 0) Console.WriteLine("Пустота.");
            foreach (var item in data)
            {
                Console.WriteLine($"Имя: {item.Name}, Id: {item.Id}, Трансцендентность: {item.Transcendence}, Возраст: {item.Age}");
            }
        }

        public void ShowMessage(string message, bool isError)
        {
            if (isError) Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine(); // Пауза
        }

        public string ShowInputBox(string prompt, string title)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public void CloseView()
        {
            _isRunning = false; // Останавливаем цикл
        }
    }

   
}