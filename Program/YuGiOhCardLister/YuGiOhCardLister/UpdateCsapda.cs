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
    public partial class UpdateCsapda : Form
    {
        public static string regiAzon;
        public UpdateCsapda(string azonosito)
        {
            InitializeComponent();
            cb_csapda_tipus.DataSource = Enum.GetValues(typeof(CsapdaTipus));
            cb_ritkasag.DataSource = Enum.GetValues(typeof(Rarity));
            CsapdaTabla manager = new CsapdaTabla();
            List<Csapda> csapdalap = manager.keresSelect(null, azonosito);
            txb_azonosito.Text = csapdalap[0].Azonosito;
            txb_nev.Text = csapdalap[0].Nev;
            txb_leiras.Text = csapdalap[0].Leiras;
            cb_csapda_tipus.Text = csapdalap[0].CsapdaTipus;
            cb_ritkasag.Text = csapdalap[0].Rarity;
            txb_mennyiseg.Text = csapdalap[0].Quantity;
            regiAzon = csapdalap[0].Azonosito;
        }

        private void Btn_megse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_frissit_Click(object sender, EventArgs e)
        {
            Csapda csapdalap = new Csapda();
            csapdalap.Azonosito = txb_azonosito.Text.ToString();
            csapdalap.Nev = txb_nev.Text.ToString();
            csapdalap.Leiras = txb_leiras.Text.ToString();
            csapdalap.CsapdaTipus = cb_csapda_tipus.Text.ToString();
            csapdalap.Rarity = cb_ritkasag.Text.ToString();
            csapdalap.Quantity = txb_mennyiseg.Text.ToString();
            CsapdaTabla manager = new CsapdaTabla();
            manager.Update(csapdalap, regiAzon);
            MessageBox.Show("A frissítés megtörtént!");
            Form1 form = new Form1();
            form.InitDataGridViewCsapda();
            this.Close();
        }
    }
}
