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
            string address = txtStreetAddress.Text + "+" + txtCity.Text + "+" + txtState.Text +
                "+" + txtZip.Text;
            GoogleMapsService service = new GoogleMapsService();
            service.Get(address);
        }
    }
}
