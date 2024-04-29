using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNew.Text != "")
            {
                listBox1.Items.Add(textBoxNew.Text);
            }
            else
            {
                MessageBox.Show("Wrong input");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in listBox1.SelectedItems)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            catch
            {
                return;
            }
        }

        private void buttonNotify_Click(object sender, EventArgs e)
        {
            string sub = textBoxSubject.Text;
            int price = Convert.ToInt32(textBoxPrice.Text);
            listBox2.Visible = true;
            listBox2.Items.Clear();
            foreach (string item in listBox1.Items)
            {
                listBox2.Items.Add("Observer" + item);
            }
            listBox2.Items.Add("Product Name: " + sub + ", price" + price + " is Now available. So notifying all Registered users");
            foreach (string item in listBox1.Items)
            {
                listBox2.Items.Add("Hello " + item + ", Product is now availability");
            }
        }
    }
}
