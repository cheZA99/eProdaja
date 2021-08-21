using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI.Korisnici
{
    public partial class frmKorisniciDodajUredi : Form
    {
        public frmKorisniciDodajUredi()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            err.SetError(txtIme, Properties.Resources.ObavezanUnosPolja);
        }
    }
}
