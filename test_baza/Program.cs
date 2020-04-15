using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_Meetings
{
    /*База данных митингов. Таблица заявителей: ФИО, флаг наличия административных правонарушений.
 Таблица митингов: адрес, количество участников заявленное, количество участников по факту (может не
 указываться), дата, время, список заявителей, флаг разрешения.*/

     public class Zayav  // Струтура таблицы заявителей
     {

        public static List<Zayav> zayaviteli = new List<Zayav>();
        public string Name { get; set; }
        public bool Flag { get; set; }
        public Zayav(string Name, bool flag)
        {
            this.Name = Name;
            this.Flag = flag;
        }

    }

    public struct Meetings //Структура таблицы митингов
    {
        public static List<Meetings> meetings = new List<Meetings>();
        public string Address { get; set; }
        public DateTimeOffset Date { get; set;}
        public int Members { get; set; }
        public int MembersReal { get; set; }
        public bool Flag { get; set; }
        public List<Zayav> zayavs{ get; set; }
        public Meetings(string Adress, DateTimeOffset Date, int Members, int MembersReal, bool Flag)
        {
            this.MembersReal = MembersReal;
            this.Address = Address;
            this.Members = Members;
            this.Date = Date;
            this.Flag = Flag;
            
        }

    }
    class Program
    {
        
        static void AddString() //Функция добавления элементов в каждую таблицу
        {
            Console.WriteLine("Выберите таблицу (Заявители = 1 / Митинги = 2) : ");
            char h = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (h)
            {
                case '1':
                    Console.Write("Введите фамилию имя: ");
                    string s1 = Console.ReadLine();
                    Console.Clear();
                    string s2;
                    bool b1 = false;
                    do
                    {
                        Console.Write("Наличие флага правонарушений (да/нет): ");
                        s2 = Console.ReadLine();
                        s2 = s2.ToUpper();
                        switch (s2)
                        {

                            case "ДА":
                                b1 = true;
                                break;
                            case "НЕТ":
                                b1 = false;
                                break;
                            default:
                                Console.WriteLine("Неправильный ответ!");
                                break;
                        }
                    }
                    while ((s2 != "ДА") && (s2 != "НЕТ"));
                    Zayav.zayaviteli.Add(new Zayav(s1, b1));
                    break;
                case '2':
                    Console.WriteLine("Вторая таблица");
                    Console.Clear();
                    Console.Write("Адрес митинга: ");
                    string s = Console.ReadLine();
                    Console.WriteLine("Количество участников заявлено: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Количество участников по факту: ");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Дата и время митинга: ");
                    DateTimeOffset d = Convert.ToDateTime(Console.ReadLine());
                    bool b2 = false;
                    do
                    {
                        Console.Write("Наличие флага правонарушений (да/нет): ");
                        s2 = Console.ReadLine();
                        s2 = s2.ToUpper();
                        switch (s2)
                        {

                            case "ДА":
                                b2 = true;
                                break;
                            case "НЕТ":
                                b2 = false;
                                break;
                            default:
                                Console.WriteLine("Неправильный ответ!");
                                break;
                        }
                    }
                    while ((s2 != "ДА") && (s2 != "НЕТ"));
                    Console.WriteLine("Индекс Заявителя:");
                    int i3 = Convert.ToInt32(Console.ReadLine());

                    Meetings.meetings.Add(new Meetings(s, d, i, i1, b2));
                    break;
                default:
                    Console.WriteLine("Ошибка!!");
                    Console.ReadKey();
                    break;

            }


        }
        static void ViewString() //Функиця показа обеих таблиц
        {
            Console.WriteLine("Выберите таблицу (1/2)");
            int c1 = Console.ReadKey().KeyChar;

            switch (c1)
            {
                case '1':
                    int i = 1;
                    Console.Clear();
                    Console.WriteLine("===================================================DataBase of Meetings====================" + DateTime.Now.ToString("HH:mm-dd.MM.yyyy") + "===========");
                    Console.WriteLine("Колличество записей в таблице:" + Zayav.zayaviteli.Count);
                    Console.WriteLine("");
                    foreach (Zayav c in Zayav.zayaviteli)
                    {
                        string s1;
                        if (c.Flag == true)
                            s1 = "да";
                        else
                            s1 = "нет";
                        Console.WriteLine("| " + i++ + " | " + c.Name + " | " + s1 + " |");
                    }
                    Console.WriteLine("=======================================================================================================================");
                    Console.ReadKey();
                    break;
                case '2':
                    int i1 = 1;
                    Console.Clear();
                    Console.WriteLine("===================================================DataBase of Meetings====================" + DateTime.Now.ToString("HH:mm-dd.MM.yyyy") + "===========");
                    Console.WriteLine("Колличество записей в таблице:" + Meetings.meetings.Count);
                    Console.WriteLine("");
                    foreach (Meetings c in Meetings.meetings)
                    {
                        string s1;
                        if (c.Flag == true)
                            s1 = "да";
                        else
                            s1 = "нет";
                        Console.WriteLine("| " + i1++ + " | " + c.Address + " | " + c.Members + " | " + c.MembersReal + " | " + c.Date + " | " + c.zayavs + " | " + s1 + " |");
                    }
                    Console.WriteLine("=======================================================================================================================");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ошибка!!");
                    Console.ReadKey();
                    break;
            }
        }

        static void DeleteString() // Функция удаления элеменитов из обеи таблиц
        {
            Console.WriteLine("Выберите таблицу (Заявители = 1 / Митинги = 2) : ");
            char h = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (h)
            {
                case '1':
                    Console.WriteLine("Введите номер удаляемого элемента : ");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    i1--;
                    Zayav.zayaviteli.RemoveAt(i1);
                    Console.WriteLine("Удален " + i1++ + " элемент");
                    break;
                case '2':
                    Console.WriteLine("Введите номер удаляемого элемента : ");
                    int i2 = Convert.ToInt32(Console.ReadLine());
                    i2--;
                    Meetings.meetings.RemoveAt(i2);
                    Console.WriteLine("Удален " + i2++ + " элемент");
                    break;
                default:
                    Console.WriteLine("Ошибка!!");
                    break;
            }
        }

        static void EditString() // Функция редактирования обеих таблиц
        {
            Console.WriteLine("Выберите таблицу (Заявители = 1 / Митинги = 2) : ");
            char h = Console.ReadKey().KeyChar;
            switch (h)
            {

                case '1':
                    Console.WriteLine("Выберите элемент: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите ФИО: ");
                    Zayav.zayaviteli.ElementAt(i--).Name = Console.ReadLine();
                    string s2;
                    bool b1 = false;
                    do
                    {
                        Console.Write("Наличие флага правонарушений (да/нет): ");
                        s2 = Console.ReadLine();
                        s2 = s2.ToUpper();
                        switch (s2)
                        {

                            case "ДА":
                                b1 = true;
                                break;
                            case "НЕТ":
                                b1 = false;
                                break;
                            default:
                                Console.WriteLine("Неправильный ответ!");
                                break;
                        }
                    }
                    while ((s2 != "ДА") && (s2 != "НЕТ"));
                    Zayav.zayaviteli.ElementAt(--i).Flag = b1;
                    break;
                case '2':
                    Console.WriteLine("Выберите элемент: ");
                    int i5 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Адрес митинга: ");
                    string s = Console.ReadLine();
                    Console.WriteLine("Количество участников заявлено: ");
                    int i4 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Количество участников по факту: ");
                    int i1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Дата и время митинга: ");
                    DateTimeOffset d = Convert.ToDateTime(Console.ReadLine());
                    bool b2 = false;
                    do
                    {
                        Console.Write("Наличие флага правонарушений (да/нет): ");
                        s2 = Console.ReadLine();
                        s2 = s2.ToUpper();
                        switch (s2)
                        {

                            case "ДА":
                                b2 = true;
                                break;
                            case "НЕТ":
                                b2 = false;
                                break;
                            default:
                                Console.WriteLine("Неправильный ответ!");
                                break;
                        }
                    }
                    while ((s2 != "ДА") && (s2 != "НЕТ"));
                    Console.WriteLine("Индекс Заявителя:");
                    int i3 = Convert.ToInt32(Console.ReadLine());
                    Meetings.meetings.ElementAt(i5).Address = s;
                    Meetings.meetings.ElementAt(i5).Members = i4;
                    Meetings.meetings.ElementAt(i5).MembersReal = i1;
                    Meetings.meetings.ElementAt(i5).Date = d;
                    Meetings.meetings.ElementAt(i5).Flag = b2;
                    break;
                default:
                    Console.WriteLine("Ошибка!!");
                    break;


            }
        }

        static void Search() // Функиция поиска элементов
        {
            Console.WriteLine("Выберите таблицу (Заявители = 1 / Митинги = 2) : ");
            char h = Console.ReadKey().KeyChar;
            switch (h)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Введите индекс искомого элемента: ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    --i;
                    string s1;
                    if (Zayav.zayaviteli.ElementAt(i).Flag == true)
                        s1 = "да";
                    else
                        s1 = "нет";
                    try
                    {
                        Console.WriteLine(Zayav.zayaviteli.ElementAt(i).Name+" "+ s1);
                    }
                    catch (Exception) { Console.WriteLine("Ошибка!!!"); }
                    break;
            
                case '2':
                    break;
                default:
                    Console.WriteLine("Ошибка!!");
                    break;
            
        }
        }

        static void Filter() // Функция сортировки элементов
        {
            Console.WriteLine("Выберите таблицу:");
            char h = Console.ReadKey().KeyChar;
            switch (h)
            {
                case '1':
                  //  Zayav.zayaviteli.Sort();
                   
                    break;
                case '2':
                    break;
                default:
                    break;
            }
        }

        static void SaveFile() // Функция записи в файл 
        {
            char h = Console.ReadKey().KeyChar;
            switch (h)
            {
                case '1':
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\Example.txt");
                        foreach (Zayav c in Zayav.zayaviteli)
                        {
                            sw.WriteLine(c.Name + " " + c.Flag);
                        }
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }

                    break;
                case '2':
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\Example2.txt");
                        sw.WriteLine("Адрес/Число участников/Число участников по факту/Время Митинга"); 
                        foreach (Meetings c in Meetings.meetings)
                        {
                            sw.WriteLine(c.Address + " " + c.Members+ " " + c.MembersReal+ " " + c.Date);
                        }
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка!!!");
                    break;
            }
            
        }

        static void ReadFile() // Функция чтения из файла
        {

            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\example.txt");

                line = sr.ReadLine();


                while (line != null)
                {

                    Console.WriteLine(line);

                    line = sr.ReadLine();
                }


                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        static void Main(string[] args) // Меню 
        {

            int h;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            do
            {
                Console.WriteLine("===================================================DataBase of Meetings====================" + DateTime.Now.ToString("HH:mm-dd.MM.yyyy") + "===========");
                Console.WriteLine("||1.Add String------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||2.View------------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||3.Delete----------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||4.Edit------------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||5.Search----------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||6.Filter-----------------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||7.Save as a file--|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||8.Read from file--|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("||9.Exit------------|------------------------------------------------------------------------------------------------||");
                Console.WriteLine("=======================================================================================================================");
                Console.Write("Input number: ");
                h = Console.ReadKey().KeyChar;

                switch (h)
                {
                    case '1':  
                        Console.Clear();
                        AddString();
                        break;
                    case '2':
                        Console.Clear();
                        ViewString();
                       
                        
                        break;
                    case '3':
                        Console.Clear();
                        DeleteString();
                        Console.ReadKey();

                        break;
                    case '4':
                        Console.Clear();
                        EditString();
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        Search();
                        Console.ReadKey();
                        break;
                    case '6':
                        Console.Clear();
                        Filter();
                        Console.ReadKey();
                        break;
                    case '7':
                        Console.Clear();
                        SaveFile();
                        Console.ReadKey();
                        break;
                    case '8':
                        Console.Clear();
                        ReadFile();
                        Console.ReadKey();
                        break;
                    case '9':
                        Console.Clear();
                        Console.WriteLine("Good Bye :)");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" Invalid Button, Press any button to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.Clear();
            } while (h != '9');

        }
    }
}
