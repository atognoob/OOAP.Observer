using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ObserverDesign.Form1;

namespace ObserverDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public interface ISubject
        {
            void RegisterObserver(IObserver observer);
            void RemoveObserver(IObserver observer);
            void NotifyObservers();
        }   
        public interface IObserver
        {
            void update(string availability);
        }
        public class Subject : ISubject
        {
            private List<IObserver> observers = new List<IObserver>();
            private string ProductName { get; set; }
            private int ProductPrice { get; set; }
            private string Availability { get; set; }
            public Subject(string productName, int productPrice, string availability)
            {
                ProductName = productName;
                ProductPrice = productPrice;
                Availability = availability;
            }
            public string getAvailability()
            {
                return Availability;
            }
            public void setAvailability(string availability)
            {
                this.Availability = availability;
                NotifyObservers();
            }
            public void RegisterObserver(IObserver observer)
            {
                observers.Add(observer);
            }
            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }
            public void NotifyObservers()
            {
                Availability = "Product Name: " + ProductName + ", price" + ProductPrice + " is " + Availability;
                MessageBox.Show(Availability);
                foreach (IObserver observer in observers)
                {
                    observer.update(Availability);
                }
            }
        }
        public class Observer : IObserver
        {
            public string UserName { get; set; }
            public Observer(string userName, ISubject subject)
            {
                UserName = userName;
                subject.RegisterObserver(this);
            }

            public void update(string availability) {
                
                availability = "Hello " + UserName + ", Product is "+ availability;
                MessageBox.Show(availability);
            }
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
            Subject NameSubject = new Subject("sub", price, "no Available");
            listBox2.Visible = true;
            listBox2.Items.Clear();
            foreach (string item in listBox1.Items)
            {
                Observer user = new Observer(item, NameSubject);

                listBox2.Items.Add("Observer: " + item);

            }
            if (button1.BackColor == Color.Green)
            {
                listBox2.Items.Add("Product Name: " + sub + ", price" + price + " is not available");
            }
            else
            {
                listBox2.Items.Add("Product Name: " + sub + ", price" + price + " is Now available. So notifying all Registered users");
                foreach (string item in listBox1.Items)
                {
                    listBox2.Items.Add("Hello " + item + ", Product is now availability");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button1.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            button1.BackColor = Color.White;
        }
    }
}
