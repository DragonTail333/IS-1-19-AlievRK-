using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_19_AlievRK
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        abstract class accessories<T> //Родительский класс комплектующих, имеет один обощенный тип
        {
            //пполя артикула, цена и дата соответственно
            public T artikul;
            public int realese;
            public int price;
         // конструктор, отвечающий за инициализацию полей класса
         public accessories(T AR, int RL, int PR)
            {
                artikul = AR;
                realese = RL;
                price = PR;
            }
            //абстрактный метод
            public abstract void DisplayInfo(ListBox lb);

        }
        //Дочерний класс процессоров, насследуемый от класса комплектующих
        class CPU<T> : accessories<T>
        {
            //Новые поля наследника
            int CPUfrequency;
            int core;
            int numbertheards;

            int CPUFrequency { get { return CPUfrequency; } set { CPUfrequency = value; } }
            int Core { get { return core; } set { core = value; } }
            int Numberthreads { get { return numbertheards; } set { numbertheards = value; } }
            //Конструктор, отвечающий за инициализацию полей класса
            public CPU(T AR, int RL, int PR, int CPUf, int C, int NT)
              : base(AR, RL, PR)
            {
                CPUfrequency = CPUf;
                core = C;
                numbertheards = NT;
            }
            // Первопределённый метод родительского абстрактного класса
            public override void DisplayInfo(ListBox lb)
            {
                lb.Items.Add($"Артикул:{artikul}, Год выпуска:{realese}, Цена:{price}, Частота процессора:{CPUfrequency}," +
                    $" Количество ядер:{core}, Количество потоков:{numbertheards}");
            }


        }
        //Дочерний класс Видеокарты, насследуемый от класса комплектующих
        class Videocard<T> : accessories<T>
        {
            //новые поля наследника
            public int GPUfrequency;
            public string manufacturer;
            public int numbertheards;

            public int GPUFrequency { get { return GPUfrequency; } set { GPUfrequency = value; } }
            public string Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
            public int Numbertheards { get { return numbertheards; } set { numbertheards = value; } }
            //Конструктор, отвечающий за инициализацию полей класса
            public Videocard(T AR, int RL, int PR, int GPUf, string M, int NT)
              : base(AR, RL, PR)
            {
                GPUfrequency = GPUf;
                manufacturer = M;
                numbertheards = NT;
            }
            // Первопределённый метод родительского абстрактного класса
            public override void DisplayInfo(ListBox lb)
            {
                lb.Items.Add($"Артикул:{artikul}, Год выпуска:{realese}, Цена:{price}," +
                    $" Частота GPU:{GPUfrequency}, Производитель:{manufacturer}, Количество потоков:{numbertheards}");

            }


        }
        CPU<int> ex1; //Наследования для CPU
        Videocard<int> ex2; //Наследование для видеокарт
        private void button1_Click(object sender, EventArgs e)
        {
          //Создание переменных 
          int a1 = Convert.ToInt32(textBox1.Text);
          int a2 = Convert.ToInt32(textBox2.Text);
          int a3 = Convert.ToInt32(textBox3.Text);
          int a4 = Convert.ToInt32(textBox4.Text);
          int a5 = Convert.ToInt32(textBox5.Text);
          int a6 = Convert.ToInt32(textBox6.Text);
          //Создание инициализации экземпляра
          ex1 = new CPU<int>(a1, a2, a3, a4, a5, a6);
          ex1.DisplayInfo(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Создание переменных 
            int b1 = Convert.ToInt32(textBox7.Text);
            int b2 = Convert.ToInt32(textBox8.Text);
            int b3 = Convert.ToInt32(textBox9.Text);
            int b4 = Convert.ToInt32(textBox10.Text);
            string b5 = textBox11.Text;
            int b6 = Convert.ToInt32(textBox12.Text);
            //Создание инициализации экземпляра
            ex2 = new Videocard<int>(b1, b2, b3, b4, b5, b6);
            ex2.DisplayInfo(listBox1);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
