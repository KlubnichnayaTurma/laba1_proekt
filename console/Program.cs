using System;
using laba1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("");
                Console.WriteLine($"Стабильность: {logic.GetStability()}");
                Console.WriteLine($"");
                Console.WriteLine($"|||| 1. Добавить сущность");
                Console.WriteLine($"|||| 2. Удалить сущность");
                Console.WriteLine($"|||| 3. Изменить сущность");
                Console.WriteLine($"|||| 4. Список сущностей");
                Console.WriteLine($"|||| 5. Вызвать разлом");
                Console.WriteLine($"|||| 6. Стабилизировать");
                Console.WriteLine($"|||| 7. Выход");
                Console.WriteLine($"");
                Console.WriteLine("Ввод:");

                string Input = Console.ReadLine();

                if (!int.TryParse(Input, out int answer) || !(Convert.ToInt32(Input) >=1 && Convert.ToInt32(Input) <= 7) || Input == "")
                {
                    Console.Clear();

                    Console.WriteLine("Введите число от 1 до 7");
                    Console.ReadLine();
                    continue;
                }

                switch (Convert.ToInt32(Input))
                {
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Обзовите сущность");
                        string name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Нет.");
                            Console.ReadLine();
                            continue;
                        }
                        logic.Add(name);
                        continue;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Кто из них вам не угодил? (Id)");
                        string id = Console.ReadLine();
                        if (!int.TryParse(id, out int answer2) || id == "")
                        {
                            Console.Clear();

                            Console.WriteLine("Введите число.");
                            Console.ReadLine();
                            continue;
                        }
                        if (!logic.Evaporate(Convert.ToInt32(id)))
                        {
                            Console.Clear();

                            Console.WriteLine("Не нашли.");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Готово.");
                            Console.ReadLine();
                            continue;
                        }

                    case 3:
                        Console.Clear();

                        
                        Console.Clear();
                        Console.WriteLine("Какому Id присвоить?");
                        string ans = Console.ReadLine();
                        if (!int.TryParse(ans, out int answer3) || ans == "")
                        {
                            Console.Clear();

                            Console.WriteLine("Введите число.");
                            Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine("Введите новое имя:");
                        string New_Name = Console.ReadLine();
                        if (New_Name == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Нет.");
                            Console.ReadLine();
                            continue;
                        }
                        if (logic.Edit(Convert.ToInt32(ans), New_Name))
                        {
                            Console.Clear();
                            Console.WriteLine("Готово.");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Clear();
                            Console.WriteLine("Не нашли.");
                            Console.ReadLine();
                            continue;
                        }



                    case 4:
                        Console.Clear();

                        if (logic.SData().Count > 0)
                        {
                            foreach (Sushnost sushnost in logic.SData())
                            {
                                Console.WriteLine($"Имя: {sushnost.Name}, Id: {sushnost.Id}, Трансцендентность: {sushnost.Transcendence}, Возраст: {sushnost.Age}");
                            }
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Пустота.");
                            Console.ReadLine();
                            continue;
                        }

                    case 5:
                        Console.Clear();

                        if (!logic.Rift())
                        {
                            Console.WriteLine("Пустота.");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Успешно. Проверьте сущности.");
                            Console.ReadLine();
                            continue;
                        }

                    case 6:
                        Console.Clear();

                        if (!logic.Stabilize())
                        {
                            Console.WriteLine("Пустота.");
                            Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Успешно. Проверьте сущности.");
                            Console.ReadLine();
                            continue;
                        }

                    case 7: 
                        Console.Clear();

                        if (logic.SData().Count == 0)
                        {
                            Console.WriteLine("Безопасный выход из системы...");
                            Console.ReadLine();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Они найдут вас.");
                            Console.ReadLine();
                            return;
                        }
                        
                        
                }































            }
        }
    }
}
