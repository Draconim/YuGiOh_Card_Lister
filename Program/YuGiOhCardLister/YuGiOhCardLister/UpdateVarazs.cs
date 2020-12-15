using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOhCardLister.Models.Records;
using YuGiOhCardLister.Models.Manager;
using YuGiOhCardLister.Models.Enums;

namespace YuGiOhCardLister
{
    public partial class UpdateVarazs : Form
    {
        public static string regiAzon;
        public UpdateVarazs(string azonosito)
        {
            InitializeComponent();
            cb_varazs_tipus.DataSource = Enum.GetValues(typeof(VarazsTipus));
            cb_ritkasag.DataSource = Enum.GetValues(typeof(Rarity));
            VarazsTabla manager = new VarazsTabla();
            List<Varazs> varazslap = manager.keresSelect(null, azonosito);
            txb_azonosito.Text = varazslap[0].Azonosito;
            txb_nev.Text = varazslap[0].Nev;
            txb_leiras.Text = varazslap[0].Leiras;
            cb_varazs_tipus.Text = varazslap[0].VarazsTipus;
            cb_ritkasag.Text = varazslap[0].Rarity;
            txb_mennyiseg.Text = varazslap[0].Quantity;
            regiAzon = varazslap[0].Azonosito;

        }

        private void Btn_megse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_frissit_Click(object sender, EventArgs e)
        {
            Varazs varazslap = new Varazs();
            varazslap.Azonosito = txb_azonosito.Text.ToString();
            varazslap.Nev = txb_nev.Text.ToString();
            varazslap.Leiras = txb_leiras.Text.ToString();
            varazslap.VarazsTipus = cb_varazs_tipus.Text.ToString();
            varazslap.Rarity = cb_ritkasag.Text.ToString();
            varazslap.Quantity = txb_mennyiseg.Text.ToString();
            VarazsTabla manager = new VarazsTabla();
            manager.Update(varazslap, regiAzon);
            MessageBox.Show("A frissítés megtörtént!");
            Form1 form = new Form1();
            form.InitDataGridViewVarazs();
            this.Close();
        }
    }
}
