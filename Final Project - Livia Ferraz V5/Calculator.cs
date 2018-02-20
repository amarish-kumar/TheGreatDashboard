using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //For reading and writing file

namespace Final_Project___Livia_V1
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        Calculator1 calc = new Calculator1();
        bool finish = false;

        string dir = @"C:\Calculator\";
        string path = @"C:\Calculator\Calculator_Numbers.txt";
        FileStream fs = null;
        string operation = "";

        private void Calculator_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";

            if (!Directory.Exists(dir)) //Creating directory
                Directory.CreateDirectory(dir);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Number 1
        {
            if (textBox1.Text == "0" || finish == true) // to make the initial zero desapear
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "1";
        }

        private void button17_Click(object sender, EventArgs e) //Clear Button
        {
            textBox1.Text = "0";
            finish = false;
            calc.Clear();
        }

        private void button18_Click(object sender, EventArgs e) //Exit Button
        {
            byte answer;
            answer = (byte)MessageBox.Show("Do you want \nto quit the application?", "Exit ?", MessageBoxButtons.YesNo);
            if (answer == 6)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) //Number 2
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e) //Number 3
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "3";

        }

        private void button8_Click(object sender, EventArgs e) //Number 4
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "4";
        }

        private void button7_Click(object sender, EventArgs e) //Number 5
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e) //Number 6
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "6";
        }

        private void button12_Click(object sender, EventArgs e) //Number 7
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "7";
        }

        private void button11_Click(object sender, EventArgs e) //Number 8
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "8";
        }

        private void button10_Click(object sender, EventArgs e) //Number 9
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "9";
        }

        private void button16_Click(object sender, EventArgs e) //Number 0
        {
            if (textBox1.Text == "0" || finish == true)
            {
                textBox1.Clear();
            }
            finish = false;
            textBox1.Text = textBox1.Text + "0";
        }

        private void button15_Click(object sender, EventArgs e) //Number .
        {
            finish = false;
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text + "."; //only lets exist one "."
            }
        }

        private void AddButton_Click(object sender, EventArgs e) // + operation
        {

            if (finish == false)
            {
                EqualButton.PerformClick(); //used to perform multiple calculations
                calc.Add(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            else
            {
                calc.Add(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }

            operation += textBox1.Text + " + ";

        }

        private void EqualButton_Click(object sender, EventArgs e) //Equal
        {
            calc.Equals(Convert.ToDecimal(textBox1.Text));
            textBox1.Text = calc.CurrentValue.ToString();
            //finish = true;

            operation += calc.Operand2.ToString() + " = " + calc.CurrentValue.ToString();

            //Writing in .txt file
            try
            {
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);

                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file
                textOut.WriteLine(operation + "|");
                operation = "";
                // close the output stream for the text file writing
                textOut.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(path + " Not found.", "File Not Found for writing");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(path + " Not found.", "Directory Not Found for writing");
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "IOException"); }
            finally
            { // close the output file stream
                if (fs != null) fs.Close();
            }
           
        }

        private void SubButton_Click(object sender, EventArgs e) // - operation
        {

            if (finish == false)
            {
                EqualButton.PerformClick(); //used to perform multiple calculations
                calc.Subtract(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            else
            {
                calc.Subtract(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            operation += textBox1.Text + " - ";
        }

        private void MultButton_Click(object sender, EventArgs e) // * operation
        {
            if (finish == false)
            {
                EqualButton.PerformClick(); //used to perform multiple calculations
                calc.Multiply(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            else
            {
                calc.Multiply(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            operation += textBox1.Text + " * ";

        }

        private void DivButton_Click(object sender, EventArgs e) // / operation
        {
            if (finish == false)
            {
                EqualButton.PerformClick(); //used to perform multiple calculations
                calc.Divide(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            else
            {
                calc.Divide(Convert.ToDecimal(textBox1.Text));
                finish = true;
            }
            operation += textBox1.Text + " / ";
        }
    }

    class Calculator1 //New class
    {
        decimal currentValue = 0;
        decimal operand1 = 0;
        decimal operand2 = 0;
        string op = " ";

        public decimal CurrentValue //Property
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }
        public decimal Operand1 //Property
        {
            get
            {
                return operand1;
            }
            set
            {
                operand1 = value;
            }
        }

        public decimal Operand2 //Property
        {
            get
            {
                return operand2;
            }
            set
            {
                operand2 = value;
            }
        }

        public Calculator1() //Constructor
        {
            CurrentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = " ";
        }

        public void Add(decimal displayValue) //Add Method
        {
            Operand1 = displayValue;
            op = "+";
        }
        public void Subtract(decimal displayValue) //Subtract Method
        {
            operand1 = displayValue;
            op = "-";
        }
        public void Multiply(decimal displayValue) //Multiply Method
        {
            operand1 = displayValue;
            op = "*";
        }
        public void Divide(decimal displayValue) //Divide Method
        {
            operand1 = displayValue;
            op = "/";
        }
        public void Clear() //Clear Method
        {
            CurrentValue = 0;
            operand1 = 0;
            operand2 = 0;
            op = " ";
        }
        public void Equals(decimal displayValue) //Equals Method
        {
            operand2 = displayValue;
            CurrentValue = displayValue;

            switch (op)
            {
                case "+":
                    CurrentValue = Operand1 + Operand2;
                    break;

                case "-":
                    CurrentValue = Operand1 - Operand2;
                    break;

                case "*":
                    CurrentValue = Operand1 * Operand2;
                    break;

                case "/":
                    try
                    {
                        CurrentValue = Operand1 / Operand2;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("A format exception has occurred. Please check all entries.", "Entry Error");
                        this.Clear();
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("An overflow exception has occurred. Please enter smaller values.", "Entry Error");
                        this.Clear();
                    }
                    catch (Exception exep) // all other exceptions
                    {
                        MessageBox.Show(exep.Message);
                        this.Clear();
                    }

                    break;

                default:
                    break;
            }

        }



    }
}
