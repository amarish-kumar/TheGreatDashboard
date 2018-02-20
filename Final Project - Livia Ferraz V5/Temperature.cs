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
    public partial class Temperature : Form
    {
        public Temperature()
        {
            InitializeComponent();
        }
        string dir = @"C:\Temperature\";
        string path = @"C:\Temperature\TempConversions.txt";
        FileStream fs = null;

        private void Temperature_Load(object sender, EventArgs e)
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
            double celsius, fahrenheit, answer;
            DateTime currentDateTime = DateTime.Now;
            string temperature = " ";
            textBox3.Text = " ";

            if (radioButton1.Checked) //From C to F
            {
                celsius = Convert.ToDouble(textBox1.Text);
                answer = (celsius*9/5)+32;
                textBox2.Text = Math.Round(answer, 2).ToString();
                temperature = celsius.ToString() + " C = " + Math.Round(answer, 2).ToString() + " F, " + currentDateTime.ToString() + "\t\n";
                label2.Text = "C";
                label4.Text = "F";


                if (celsius == 100)
                {
                    textBox3.Text = "Water boils"; 
                }
                else if (celsius == 40)
                {
                    textBox3.Text = "Hot Bath"; 
                }
                else if (celsius == 37)
                {
                    textBox3.Text = "Body temperature";
                }
                else if (celsius == 30)
                {
                    textBox3.Text = "Beach weather";
                }
                else if (celsius == 21)
                {
                    textBox3.Text = "Room temperature";
                }
                else if (celsius == 10)
                {
                    textBox3.Text = "Cool Day";
                }
                else if (celsius == 0)
                {
                    textBox3.Text = "Freezing point of water";
                }
                else if (celsius == -18)
                {
                    textBox3.Text = "Very Cold Day";
                }
                else if (celsius == -40)
                {
                    textBox3.Text = "Extremely Cold Day";
                }
               
            }

            if (radioButton2.Checked) //From F to c
            {
                fahrenheit = Convert.ToDouble(textBox1.Text);
                answer = (fahrenheit - 32) * 5 / 9;
                textBox2.Text = Math.Round(answer, 2).ToString();
                temperature = fahrenheit.ToString() + " F = " + Math.Round(answer, 2).ToString() + " C, " + currentDateTime.ToString() + "\n";

                label2.Text = "F";
                label4.Text = "C";

                if (fahrenheit == 212)
                {
                    textBox3.Text = "Water boils";
                }
                else if (fahrenheit == 104)
                {
                    textBox3.Text = "Hot Bath";
                }
                else if (fahrenheit == 98.6)
                {
                    textBox3.Text = "Body temperature";
                }
                else if (fahrenheit == 86)
                {
                    textBox3.Text = "Beach weather";
                }
                else if (fahrenheit == 70)
                {
                    textBox3.Text = "Room temperature";
                }
                else if (fahrenheit == 50)
                {
                    textBox3.Text = "Cool Day";
                }
                else if (fahrenheit == 32)
                {
                    textBox3.Text = "Freezing point of water";
                }
                else if (fahrenheit == 0)
                {
                    textBox3.Text = "Very Cold Day";
                }
                else if (fahrenheit == - 40)
                {
                    textBox3.Text = "Extremely Cold Day";
                }
            }
            //Writing .txt file
            try
            {
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);

                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file
                textOut.WriteLine(temperature + "|");

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

        private void button2_Click(object sender, EventArgs e) //Reading file button
        {
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                // create the object for the input stream for a text file
                StreamReader textIn = new StreamReader(fs);
                string textToPrint = "The result of the conversion is: \n\n";
                // read the data from the file and store it in the list
                while (textIn.Peek() != -1)
                {
                    string row = textIn.ReadLine();
                    //textToPrint += row + "\n";
                    string[] columns = row.Split('|');
                    textToPrint += columns[0] + "\n";
                }
                MessageBox.Show(textToPrint, "Temperature Converter - Livia Ferraz");
                // close the output stream for the text file reading
                textIn.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(path + " Not found.", "File Not Found for reading");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(path + " Not found.", "Directory Not Found for reading");
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "IOException"); }
            finally
            { // close the output file stream
                if (fs != null) fs.Close();
            }
        }
    }
}
