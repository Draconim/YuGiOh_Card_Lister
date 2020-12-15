using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOhCardLister
{
    public partial class Valasztas : Form
    {
        public Valasztas()
        {
            InitializeComponent();
        }

        private void V_btn_Szorny_Click(object sender, EventArgs e)
        {
            YuGiOhCardLister.Form1.AddCardByResult( V_btn_Szorny.Text.ToString());
            this.Close();
        }

        private void V_btn_Varazs_Click(object sender, EventArgs e)
        {
            YuGiOhCardLister.Form1.AddCardByResult(V_btn_Varazs.Text.ToString());
            this.Close();
        }

        private void V_btn_Csapda_Click(object sender, EventArgs e)
        {
            YuGiOhCardLister.Form1.AddCardByResult(V_btn_Csapda.Text.ToString());
            this.Close();
        }
    }
}
