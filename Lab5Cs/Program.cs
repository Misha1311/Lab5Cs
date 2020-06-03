using System;

namespace Lab5Cs
{
    //Одноадресный делегат
    delegate void singlethreaded();
    
    //Вывод информации
    interface Workers
    {
        void Write_Workers();
    }

    //Перезапись информации
    interface WReWrite
    {
        void Re_Write();
    }

    class Program
    {
        private string Working = "Петров";
        private string Frames = "Сидоров";
        private string Engineer = "Пупкин";
        private string Administration = "Федоров";
        public string working { get => Working; set => Working = value; }
        public string frames { get => Frames; set => Frames = value; }
        public string engineer { get => Engineer; set => Engineer = value; }
        public string administration { get => Administration; set => Administration = value; }

        //Конструктор для изминения данных
        public Program(string New_Working, string New_Frames, string New_Engineer, string New_Administration)
        {
            working = New_Working;
            frames = New_Frames;
            engineer = New_Engineer;
            administration = New_Administration;
        }

        public Program()
        {

        }

        //Делегат принимает адрес функции
        static void Main()
        {
            Program program = new Program();
            singlethreaded prog = program.input;
            prog();
        }

        //Конструктор принимает значения полей и записывают их в свойство
        public void input()
        {
            Inform inform = new Inform(working, frames, engineer, administration);
            Info(inform);
        }
        //Вызываем функцию интерфейса при помощи одноадресного делегата
        static void Info(Workers workers)
        {
            singlethreaded mor = workers.Write_Workers;
            mor();
        }
    }
    class Inform : Workers
    {
        private string Working;
        private string Frames;
        private string Engineer;
        private string Administration;

        public string Working1 { get => Working; set => Working = value; }
        public string Frames1 { get => Frames; set => Frames = value; }
        public string Engineer1 { get => Engineer; set => Engineer = value; }
        public string Administration1 { get => Administration; set => Administration = value; }

        //Конструктор для вывода информации
        public Inform(string working, string frames, string engineer, string administration)
        {
            Working1 = working;
            Frames1 = frames;
            Engineer1 = engineer;
            Administration1 = administration;
        }

        //Выводим данные о Рабочих
        void Workers.Write_Workers()
        {
            Console.WriteLine($"\nРабочий: {Working1}");
            Console.WriteLine($"Кадры: {Frames1}");
            Console.WriteLine($"Инженер: {Engineer1}");
            Console.WriteLine($"Администрация: {Administration1}");
            Console.Write("\nЕсли вы хотите изменить данные, введите - 1, если хотите выйти введите любое число : ");

            //При вводе 1 вызываем функцию для изменения данных
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                ReWrite write = new ReWrite();
                NewInfo(write);
            }
        }
        static void NewInfo(WReWrite write)
        {
            singlethreaded mor1 = write.Re_Write;
            mor1();
        }
    }


    class ReWrite : WReWrite
    {
        private string New_Working;
        private string New_Frames;
        private string New_Engineer;
        private string New_Administration;
        public string New_Working1 { get => New_Working; set => New_Working = value; }
        public string New_Frames1 { get => New_Frames; set => New_Frames = value; }
        public string New_Engineer1 { get => New_Engineer; set => New_Engineer = value; }
        public string New_Administration1 { get => New_Administration; set => New_Administration = value; }

        public ReWrite()
        {

        }

        //Вводим новые данные
        void WReWrite.Re_Write()
        {
            Console.Write("\nВведите нового рабочего: ");
            New_Working1 = Console.ReadLine();
            Console.Write("Введите новые кадры: ");
            New_Frames1 = Console.ReadLine();
            Console.Write("Введите нового инженера: ");
            New_Engineer1 = Console.ReadLine();
            Console.Write("Введите новую администрацию: ");
            New_Administration1 = Console.ReadLine();
            Program program = new Program(New_Working1, New_Frames1, New_Engineer1, New_Administration1);
            singlethreaded prog = program.input;
            prog();
        }
    }
}
