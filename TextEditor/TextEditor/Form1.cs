using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private string fileText = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = openFileDialog1.FileName;
            if(filename.Length>= 1073741824 )
            { 
                MessageBox.Show("The file is too large"); 
            }
            else 
            { 
            fileText = System.IO.File.ReadAllText(filename,Encoding.GetEncoding(1251));
            MessageBox.Show("File opened");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            int numeric = 0;
            if (textBox1.Text != "")
            { 
                string number = textBox1.Text;
                numeric = Int16.Parse(number); 
            }
  
            if (fileText == null || checkBox1.Checked==true && textBox2.Text == "")
                MessageBox.Show("Incorrect data");
            else 
            {
                if (checkBox1.Checked == true && textBox2.Text != "")
                {
                    string filename = saveFileDialog1.FileName;
                    string mark = textBox2.Text;

                    fileText = Tools.deletePunctuation(fileText,mark); 
                    fileText = Tools.deleteWords(fileText, numeric); 
                    fileText = Regex.Replace(fileText, "[ ]+", " "); 
                
                    System.IO.File.WriteAllText(filename, fileText, Encoding.GetEncoding(1251));
                    MessageBox.Show("File saved");
                }
                if (checkBox1.Checked == false)
                {
                    string filename = saveFileDialog1.FileName;

                    fileText = Tools.deleteWords(fileText, numeric);
                    fileText = Regex.Replace(fileText, "[ ]+", " ");

                    System.IO.File.WriteAllText(filename, fileText, Encoding.GetEncoding(1251));
                    MessageBox.Show("File saved");
                } 
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= 47 || e.KeyChar >= 58)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.Enabled = true;
            else
            {
                textBox2.Text = null;
                textBox2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) textBox1.Enabled = true;
            else
            {
                textBox1.Text = null;
                textBox1.Enabled = false;
            }
        }
    }
}
