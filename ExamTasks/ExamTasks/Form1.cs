using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTasks
{
    public struct Human
    {
        public double height;
        public double mass;
        public string fio;

        public Human(double height, double mass, string fio)
        {
            this.height = height;
            this.mass = mass;
            this.fio = fio;
        }
    }
    public partial class Form1 : Form
    {
        public Human[] human;
        public int index = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int countBox = Convert.ToInt32(textBox1.Text);
                if (index == countBox)
                {
                    double maxHeight = searchMaxHeight(countBox);
                    double maxMass = searchMaxMass(countBox);
                    displayFio(countBox, maxHeight, maxMass);
                    textBox1.Enabled = true;
                    textBox1.Text = "";
                } else
                {
                    MessageBox.Show("Вы ввели меньше количества людей!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Вы ничего не ввели!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int countBox = Convert.ToInt32(textBox1.Text);
                if (index == 0) human = new Human[countBox];
                string fioBox = textBox2.Text;
                double massBox = Convert.ToDouble(textBox3.Text);
                double heightBox = Convert.ToDouble(textBox4.Text);
                if (validationValues(countBox, fioBox, massBox, heightBox))
                {
                    human[index] = new Human(heightBox, massBox, fioBox);
                    listBox1.Items.Add(fioBox + " " + massBox + " " + heightBox);
                    index++;
                    clearValues();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Вы ничего не ввели!");
            }
        }

        private bool validationValues(int countBox, string fioBox, double massBox, double heightBox)
        {
            if(countBox < 0 && fioBox.Length == 0 && massBox < 0.5 && heightBox < 50)
            {
                return false;
            }
            return true;
        }

        private double searchMaxHeight(int countBox)
        {
            double maxHeight = 0;
            for(int i = 0; i < countBox; i++)
            {
                if (human[i].height > maxHeight)
                {
                    maxHeight = human[i].height;
                }
            }
            return maxHeight;
        }

        private double searchMaxMass(int countBox)
        {
            double maxMass = 0;
            for (int i = 0; i < countBox; i++)
            {
                if (human[i].mass > maxMass)
                {
                    maxMass = human[i].mass;
                }
            }
            return maxMass;
        }

        public string displayFio(int countBox, double maxHeight, double maxMass)
        {
            for(int i = 0; i < countBox; i++)
            {
                if (human[i].height == maxHeight)
                {
                    if (human[i].mass == maxMass && searchLetterB(human[i].fio))
                    {
                        return human[i].fio;
                    }
                }
            }
            return "Нет людей с фамилией на В";
        }

        private bool searchLetterB(string fio)
        {
            char letterB = fio[0];
            if(letterB == 'В')
            {
                return true;
            }
            return false;
        }

        private void clearValues()
        {
            textBox1.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void clearBox()
        {
            textBox1.Enabled = true;
            textBox1.Text = "";
            listBox1.Items.Clear();
        }
    }
}