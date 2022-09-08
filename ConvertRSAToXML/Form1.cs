using System.Security.Cryptography;
using System.Xml;

namespace ConvertRSAToXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            stslabel.Text = "Ready";
        }

        private void Convert2XML()
        {
            stslabel.Text = "Converting";
            if (textBox1.Text == "")
            {
                stslabel.Text = "Error";
                MessageBox.Show("Please Upload the PEM file");
                return;
            }
            else if (txtFileName.Text == "")
            {
                stslabel.Text = "Error";
                MessageBox.Show("Please File Name cannot be Empty");
                return;
            }
            var privateKey = File.ReadAllText(textBox1.Text);
            var rsa = RSA.Create();
            rsa.ImportFromPem(privateKey);
            var d = new XmlDocument();
            d.LoadXml(rsa.ToXmlString(true));
            var getpath = Path.GetDirectoryName(textBox1.Text);
            d.Save(getpath + "\\" + txtFileName.Text + ".xml");
            MessageBox.Show("XML Conversation Complete");
            stslabel.Text = "Conversation Complete";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stslabel.Text = "Uploading File";
            OpenFileDialog btndialog = new OpenFileDialog();
            btndialog.ShowDialog();
            btndialog.InitialDirectory = @"C:\";
            btndialog.RestoreDirectory = true;
            btndialog.DefaultExt = ".PEM";
            btndialog.Title = "Browse for key";
            btndialog.CheckFileExists = true;
            btndialog.CheckPathExists = true;
            textBox1.Text = btndialog.FileName;
            stslabel.Text = "Ready";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Convert2XML();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
   
}