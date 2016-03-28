using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace CSharp1
{
    public partial class Form1 : Form
    {
        OpenFileDialog fileDialog;
        FolderBrowserDialog folder;
        String[] list;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Show();
           
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //folderDialog.ShowDialog();
            fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"C:\Users\王小兵\Documents\Visual Studio 2015\Projects\CSharp1\CSharp1";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(fileDialog.FileName, Encoding.UTF8);
                try {
                    textBox1.Text = sr.ReadToEnd();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sr.Close();
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // String m= @"[^`~!@#$%^&*()+=|{}':;',\\[\\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]";
            String m = "[^！@#￥$#@&*]";
            Regex regex = new Regex(m);
            MatchCollection matchc= regex.Matches(textBox1.Text);
            textBox1.Text = "";
            for(int i = 0; i < matchc.Count; i++)
            {
                textBox1.Text += matchc[i].Value;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           folder = new FolderBrowserDialog();
            //folder.RootFolder = Path.GetPathRoot(@"C:\Users\王小兵\Documents\VisualStudio2015\Projects\CSharp1\CSharp1");
            folder.SelectedPath = @"C:\Users\王小兵\Documents\Visual Studio 2015\Projects\CSharp1\Csharp1";
            folder.ShowDialog();
            // imageList1.
             if(folder.SelectedPath!="")
             list = Directory.GetFiles(folder.SelectedPath);
            folder.Dispose();
            timer1.Enabled = true;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (folder.SelectedPath!=null)
            {
                //  pictureBox1.ImageLocation = folder.SelectedPath;
                pictureBox1.ImageLocation = list[i++];
                if (i == list.Length) i = 0;
            }

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedia = new SaveFileDialog();
          //  savedia.InitialDirectory= @"images";
            savedia.Filter = "文本文件|*.txt|所有文件|*.*";
            savedia.FilterIndex = 1;
            if (savedia.ShowDialog() == DialogResult.OK)
            {
                RichTextBox t1 = new RichTextBox();
                string path = fileDialog.FileName;
                StreamWriter sw = new StreamWriter(savedia.FileName,false);
                sw.Write(textBox1.Text,true);
                sw.Close();
                textBox1.Text = "";
             }
        }
    }
}
