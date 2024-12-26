using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTasks
{
    public partial class Form3 : Form
    {
        int indexArr = 0;
        string[] arrGroupText = new string[100];
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                string text = textBox1.Text;
                addTextToArray(text);
                textBox1.Text = "";
            } catch(Exception ex)
            {
                MessageBox.Show("Вы не ввели что-то!");
            }
        }

        private void addTextToArray(string text)
        {
            if (indexArr < arrGroupText.Length)
            {
                arrGroupText[indexArr] = text;
                indexArr++;
            }
            else
            {
                MessageBox.Show("Достигнуто максимальное количество строк!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // Очищаем список перед добавлением новых строк
            for (int i = 0; i < indexArr; i++)
            {
                string line = arrGroupText[i];
                string processedLine = processLine(line);
                listBox1.Items.Add(processedLine);
            }
        }

        private string processLine(string line)
        {
            string[] words = line.Split(' ');
            int minIndex = findIndexMinLength(words);
            if (minIndex != -1)
            {
                words[minIndex] = reverseWord(words[minIndex]);
            }
            return string.Join(" ", words);
        }

        private int findIndexMinLength(string[] words)
        {
            int minIndex = -1;
            int minLength = int.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < minLength)
                {
                    minLength = words[i].Length;
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private string reverseWord(string str)
        {
            char[] charArray1 = str.ToCharArray();
            char[] charArray2 = str.ToCharArray();
            int upIndex = str.Length - 1;
            for (int i = 0; i < charArray1.Length; i++)
            {
                charArray1[i] = charArray2[upIndex];
                upIndex--;
            }
            string text = "";
            for(int i = 0; i < charArray1.Length; i++)
            {
                text += charArray1[i] + "";
            }
            return text;
        }
    }
}
