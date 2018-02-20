//Name: Livia Ferraz Ximenes
//Introduction to Object Programming - Final Project
//Date: April 2016
//This project shows a dashboard containing 5 buttons.They open a simple calculator, a temperature converter, a money converter, a lottery ticket and an exit button. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___Livia_V1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //Exit Button
        {
            byte answer;
           answer= (byte) MessageBox.Show("Do you want \nto quit the application?", "Exit ?", MessageBoxButtons.YesNo);
           if (answer == 6)
           {
               this.Close();
           }

        }

        private void button4_Click(object sender, EventArgs e) //Calculator Button
        {
            Calculator calc = new Calculator();
            calc.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Temperature Button
        {
            Temperature temp = new Temperature();
            temp.Show();
        }

        private void button1_Click(object sender, EventArgs e)//Money Button
        {
            Money_Exchange money = new Money_Exchange();
            money.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Lotto Button
        {
            Lotto lotto = new Lotto();
            lotto.Show();
        }
    }
}
