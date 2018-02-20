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
using System.Text.RegularExpressions; //to use regular expressions

namespace Final_Project___Livia_V1
{
    public partial class Money_Exchange : Form
    {
        public Money_Exchange()
        {
            InitializeComponent();
        }

        string dir = @"C:\MoneyEx\";
        string path = @"C:\MoneyEx\Money_Exchange.txt";
        FileStream fs = null;

        private void Money_Exchange_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(dir)) //Creating directory
                Directory.CreateDirectory(dir);
        }

        private void button3_Click(object sender, EventArgs e) //Exit Button
        {
            byte answer;
            answer = (byte)MessageBox.Show("Do you want \nto quit the application?", "Exit ?", MessageBoxButtons.YesNo);
            if (answer == 6)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) //Convert Button
        {
            double can, usd, eur, gbp;
            string money = "";

            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);
            DateTime currentDateTime = DateTime.Now;
            
                if (radioButton1.Checked && radioButton8.Checked) //CAN to CAN
                {
                    can = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Math.Round(can, 2).ToString();
                    money = can.ToString() + "$ CAN = " + can.ToString() + "$ CAN, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton1.Checked && radioButton7.Checked) //CAN to USD
                {
                    can = Convert.ToDouble(textBox1.Text);
                    usd = can * 0.76350452;
                    textBox2.Text = Math.Round(usd, 2).ToString();
                    money = can.ToString() + "$ CAN = " + Math.Round(usd, 2).ToString() + "$ US, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton1.Checked && radioButton6.Checked) //CAN to EUR
                {
                    can = Convert.ToDouble(textBox1.Text);
                    eur = can * 0.67192769;
                    textBox2.Text = Math.Round(eur, 2).ToString();
                    money = can.ToString() + "$ CAN = " + Math.Round(eur, 2).ToString() + "$ EUR, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton1.Checked && radioButton5.Checked) //CAN to GBP
                {
                    can = Convert.ToDouble(textBox1.Text);
                    gbp = can * 0.53969578;
                    textBox2.Text = Math.Round(gbp, 2).ToString();
                    money = can.ToString() + "$ CAN = " + Math.Round(gbp, 2).ToString() + "$ GBP, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton2.Checked && radioButton8.Checked) //USD to CAN
                {
                    usd = Convert.ToDouble(textBox1.Text);
                    can = usd * 1.3143;
                    textBox2.Text = Math.Round(can, 2).ToString();
                    money = usd.ToString() + "$ USD = " + Math.Round(can, 2).ToString() + "$ CAN, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton2.Checked && radioButton7.Checked) //USD to USD
                {
                    usd = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Math.Round(usd, 2).ToString();
                    money = usd.ToString() + "$ USD = " + Math.Round(usd, 2).ToString() + "$ USD, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton2.Checked && radioButton6.Checked) //USD to EUR
                {
                    usd = Convert.ToDouble(textBox1.Text);
                    eur = usd * 0.87985571;
                    textBox2.Text = Math.Round(eur, 2).ToString();
                    money = usd.ToString() + "$ USD = " + Math.Round(eur, 2).ToString() + "$ EUR, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton2.Checked && radioButton5.Checked) //USD to GBP
                {
                    usd = Convert.ToDouble(textBox1.Text);
                    gbp = usd * 0.70927268;
                    textBox2.Text = Math.Round(gbp, 2).ToString();
                    money = usd.ToString() + "$ USD = " + Math.Round(gbp, 2).ToString() + "$ GBP, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton3.Checked && radioButton8.Checked) //EUR to CAN
                {
                    eur = Convert.ToDouble(textBox1.Text);
                    can = eur * 1.49541896;
                    textBox2.Text = Math.Round(can, 2).ToString();
                    money = eur.ToString() + "$ EUR = " + Math.Round(can, 2).ToString() + "$ CAN, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton3.Checked && radioButton7.Checked) //EUR to USD
                {
                    eur = Convert.ToDouble(textBox1.Text);
                    usd = eur * 1.13705;
                    textBox2.Text = Math.Round(usd, 2).ToString();
                    money = eur.ToString() + "$ EUR = " + Math.Round(usd, 2).ToString() + "$ USD, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton3.Checked && radioButton6.Checked) //EUR to EUR
                {
                    eur = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Math.Round(eur, 2).ToString();
                    money = eur.ToString() + "$ EUR = " + Math.Round(eur, 2).ToString() + "$ EUR, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton3.Checked && radioButton5.Checked) //EUR to GBP
                {
                    eur = Convert.ToDouble(textBox1.Text);
                    gbp = eur * 0.80643905;
                    textBox2.Text = Math.Round(gbp, 2).ToString();
                    money = eur.ToString() + "$ EUR = " + Math.Round(gbp, 2).ToString() + "$ GBP, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton4.Checked && radioButton8.Checked) //GBP to CAN
                {
                    gbp = Convert.ToDouble(textBox1.Text);
                    can = gbp * 1.885635987;
                    textBox2.Text = Math.Round(can, 2).ToString();
                    money = gbp.ToString() + "$ GBP = " + Math.Round(can, 2).ToString() + "$ CAN, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton4.Checked && radioButton7.Checked) //GBP to USD
                {
                    gbp = Convert.ToDouble(textBox1.Text);
                    usd = gbp * 1.41126;
                    textBox2.Text = Math.Round(usd, 2).ToString();
                    money = gbp.ToString() + "$ GBP = " + Math.Round(usd, 2).ToString() + "$ USD, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton4.Checked && radioButton6.Checked) //GBP to EUR
                {
                    gbp = Convert.ToDouble(textBox1.Text);
                    eur = gbp * 1.23920214;
                    textBox2.Text = Math.Round(eur, 2).ToString();
                    money = gbp.ToString() + "$ GBP = " + Math.Round(eur, 2).ToString() + "$ EUR, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else if (radioButton4.Checked && radioButton5.Checked) //GBP to GBP
                {
                    gbp = Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Math.Round(gbp, 2).ToString();
                    money = gbp.ToString() + "$ GBP = " + Math.Round(gbp, 2).ToString() + "$ GBP, " + currentDateTime.ToString();
                    textOut.WriteLine(money + "|");
                    money = "";
                    textOut.Close();
                }
                else
                {
                    MessageBox.Show("Please select one textbox from each group.", "Error");
                    textBox1.Text = " ";
                }
        }

        private void button2_Click(object sender, EventArgs e) //read file button
        {
          
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                // create the object for the input stream for a text file
                StreamReader textIn = new StreamReader(fs);
                string textToPrint = "Money Conversions \n";
                // read the data from the file and store it in the list
                while (textIn.Peek() != -1)
                {
                    string row = textIn.ReadLine();
                    //textToPrint += row + "\n";
                    string[] columns = row.Split('|');
                    textToPrint += columns[0] + "\n";
                }
                MessageBox.Show(textToPrint, "Result of Conversion - Livia Ferraz");
                // close the output stream for the text file reading
                textIn.Close();
        }

        private bool ValidNumber(string nbr) //method regEx
        {
            Regex myRegex1 = new Regex("^([0-9]+)$");
            return myRegex1.IsMatch(nbr); //return true or false 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!ValidNumber(textBox1.Text))
            {
                MessageBox.Show("Number not accepted. Please type an positive integer.", "Error message");
                textBox1.Text = " ";
                
            }
        }
    }
}
