using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTasks
{
    public partial class Form2 : Form
    {
        int col = 0, row = 0, index = 0;
        int[,] arrTickets;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                row = Convert.ToInt32(textBox1.Text);
                col = Convert.ToInt32(textBox2.Text);
                string text = "";
                string numTickets = textBox3.Text;
                string[] arr = textBox3.Text.Split(' ');
                int[] arrRow = new int[col];
                convertStrToInt(arr, arrRow);
                if (validationNums(arrRow))
                {
                    addNums(ref text, arrRow);
                    listBox1.Items.Add(text);
                    clearValues();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                checkTickets();
                clearBox();
            } catch(Exception ex)
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void convertStrToInt(string[] arr, int[] arrRow)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arrRow[i] = int.Parse(arr[i]);
            }
        }

        private bool validationNums(int[] arrRow)
        {
            for(int i = 0; i < arrRow.Length; i++)
            {
                if (arrRow[i] < 9 || arrRow[i] > 99)
                {
                    MessageBox.Show("Надо вводить двузначные числа!");
                    return false;
                }
            }
            return true;
        }

        private string addNums(ref string text, int[] arrRow)
        {
            if (index == 0) arrTickets = new int[row, col];
            for(int i = 0; i < arrRow.Length; i++)
            {
                arrTickets[index, i] = arrRow[i]; 
                text += arrRow[i] + " ";
            }
            index++;
            return text;
        }

        private string checkTickets()
        {
            bool isFlag = false;
            int countFail = 0;
            for(int i = 0; i < row; i++)
            {
                isFlag = false;
                for(int j = 0; j < col && isFlag != true; j++)
                {
                    if (sumDigits(arrTickets[i,j]) % 2 == 0) {
                        isFlag = true;
                        countFail++;
                    }
                }
            }
            if(countFail == row)
            {
                label4.Text = "FAIL";
                return "FAIL";
            }
            label4.Text = "OK";
            return "OK";
        }
       
        private int sumDigits(int num) 
        {
            return (num / 10) + (num % 10);
        }

        private void clearBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Text = "";
        }

        private void clearValues()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Text = "";
        }
    }
}
