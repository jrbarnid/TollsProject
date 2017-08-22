using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TollsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            IEnumerable<Control> controls = GetAll(this, typeof(TextBox));
            if (controls.Where(x => string.IsNullOrWhiteSpace(x.Text)).Count() == 0)
            {
                string address = txtStreetAddress.Text + "+" + txtCity.Text + "+" + txtState.Text +
                "+" + txtZip.Text;
                GoogleMapsService service = new GoogleMapsService();
                service.Origin = address;
                service.Get();
            }
            else
            {
                MessageBox.Show("All fields must be complete");
            }
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
