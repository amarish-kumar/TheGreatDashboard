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
    public partial class Lotto : Form
    {
        public Lotto()
        {
            InitializeComponent();
        }

        string dir = @"C:\Lotto\";
        string path = @"C:\Lotto\LottoNumbers.txt";
        FileStream fs = null;

        private void Lotto_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e) //Generate button
        {
            List<int> randomNumber = new List<int>();
            Random random = new Random();
            DateTime currentDateTime = DateTime.Now;
            int number;
            string st1 = "";
            for (int i = 0; i < 7; i++)
            {
                do
                {
                    number = random.Next(1, 49);
                } while (randomNumber.Contains(number));

                randomNumber.Add(number);
                if (i==6)
                {
                    st1 = st1 + number.ToString();
                }
                else
                {
                    st1 = st1 + number.ToString() + ",";
                }
                
            }
            textBox3.Text += "\n649, " + currentDateTime.ToString() + ",  " + st1 + "\t\n";

            //Writing .txt file
            try
            {
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);

                // create the output stream for a text file that exists
                StreamWriter textOut = new StreamWriter(fs);
                // write the fields into text file
                textOut.WriteLine("\n649, " + currentDateTime.ToString() + ",  " + st1 + "|");

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

        private void button2_Click(object sender, EventArgs e) //Read file Button
        {
            

            //Reading .txt file
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                // create the object for the input stream for a text file
                StreamReader textIn = new StreamReader(fs);
                string textToPrint = "Numbers generated in: \tNumbers:\n\n";
                // read the data from the file and store it in the list
                while (textIn.Peek() != -1)
                {
                    string row = textIn.ReadLine();
                    //textToPrint += row + "\n";
                    string[] columns = row.Split('|');
                    textToPrint += columns[0] + "\n";
                }
                MessageBox.Show(textToPrint, "Lotto 6-49 - Livia Ferraz");
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
