using System;
using System.IO;
using System.Windows.Forms;

namespace ChargeData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            DateTime first = datefrom.Value.Date;
            var fdate = first.ToShortDateString();
            //string name = "виписані КНП ВРЦСП_в_ЦПМСД №";
            DateTime sekond = dateto.Value.Date;
            var sdate = sekond.ToShortDateString();

            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                int ind;
                //int number = 1;
                for (int i = 0; i < files.Length; i++)
                {
                    //ind = files[i].LastIndexOf('\\');
                    //File.Move(files[i], files[i].Remove(ind + 1) + name + number + " " + fdate + "-" + sdate + ".doc");
                    //number++;
                    try
                    {
                        ind = files[i].LastIndexOf('№');
                        File.Move(files[i], files[i].Remove(ind + 2) + " " + fdate + "-" + sdate + ".doc");
                        //number++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }


                }
                MessageBox.Show("Готово!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
