using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTasks
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }

    /*class Test
    {
        public void assertEquals(string expected,  string actual)
        {
            if(expected == actual)
            {
                Console.WriteLine("Тест пройден");
            } else
            {
                Console.WriteLine("Тест не пройден");
            }
        }

        public static void Main(string[] args)
        {
            Form1 form = new Form1();
            //ТЕСТ 1
            form.human = new Human[3];
            form.human[0] = new Human(190, 90, "Иванов");
            form.human[1] = new Human(182, 84, "Петров");
            form.human[2] = new Human(200, 100, "Видов");
            string result1 = form.displayFio(3, 200, 100);
            Test test1 = new Test();
            test1.assertEquals("Видов", result1);
            //ТЕСТ 2
            form.human = new Human[3];
            form.human[0] = new Human(190, 90, "Иванов");
            form.human[1] = new Human(182, 84, "Петров");
            form.human[2] = new Human(100, 100, "Видов");
            string result2 = form.displayFio(3, 190, 90);
            Test test2 = new Test();
            test2.assertEquals("Нет людей с фамилией на В", result2);
            //ТЕСТ 3
            form.human = new Human[4];
            form.human[0] = new Human(190, 90, "Иванов");
            form.human[1] = new Human(182, 84, "Петров");
            form.human[2] = new Human(100, 100, "Видов");
            form.human[3] = new Human(190, 100, "Видов");
            string result3 = form.displayFio(4, 190, 100);
            Test test3 = new Test();
            test3.assertEquals("Видов", result3);
        }
    }*/
}
