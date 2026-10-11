using System;
using System.Globalization;
using System.Windows.Forms;

namespace GulSatisi
{
    public partial class Form1 : Form
    {
        double toplam = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Xanalar bos olmasin!");
            }
            else
            {
                int count = 0;
                if (int.TryParse(textBox2.Text, out count) == false)
                {
                    MessageBox.Show("Say duzgun deyil!");
                }
                else
                {
                    string q = textBox3.Text;
                    q = q.Replace(',', '.');
                    double price = 0;
                    if (double.TryParse(q, NumberStyles.Any, CultureInfo.InvariantCulture, out price) == false)
                    {
                        MessageBox.Show("Qiymet duzgun deyil!");
                    }
                    else
                    {
                        if (count <= 0 || price <= 0)
                        {
                            MessageBox.Show("Say ve qiymet menfi ve ya sifir ola bilmez!");
                        }
                        else
                        {
                            double result = count * price;
                            dataGridView1.Rows.Add(textBox1.Text, count.ToString(), price.ToString(), result.ToString("F2"));
                            toplam = toplam + result;
                            lblToplam.Text = toplam.ToString("F2");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox1.Focus();
                        }
                    }
                }
            }
        }

        private void btnCixis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cixis edilsinmi?", "Cixis", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
            }
        }
    }
}
