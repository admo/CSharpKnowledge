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
        private MyProperties myProperties = new MyProperties();

        public Form()
        {
            InitializeComponent();

            // textBox1 is bounded in designer time, but we have to add data source manualy
            myPropertiesBindingSource.Add(myProperties);

            textBox2.DataBindings.Add("Text", myProperties, "Property2");

            // Timer event configuration
            timer1.Tick += new EventHandler((o, e) => ++myProperties.Property1);
            timer1.Tick += new EventHandler((o, e) => --myProperties.Property2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++myProperties.Property1;
            --myProperties.Property2;
        }
    }

    public class MyProperties : INotifyPropertyChanged
    {
        private int _property1;
        private int _property2;

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

        public int Property2
        {
            get => _property2;
            set
            {
                if (value == _property2) return;
                _property2 = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
