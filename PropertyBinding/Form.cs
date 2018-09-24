using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyBinding
{
    public partial class Form : System.Windows.Forms.Form
    {
        public MyProperties MyProperties1 = new MyProperties();
        private MyProperties myProperties2 = new MyProperties();

        public Form()
        {
            InitializeComponent();

            // textBox1 is bounded in designer time
            textBox2.DataBindings.Add("Text", myProperties2, "Property1");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++MyProperties1.Property1;
            ++myProperties2.Property1;
        }
    }

    public class MyProperties : INotifyPropertyChanged
    {
        private int _property1;

        public int Property1
        {
            get => _property1;
            set
            {
                if (value == _property1) return;
                _property1 = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
