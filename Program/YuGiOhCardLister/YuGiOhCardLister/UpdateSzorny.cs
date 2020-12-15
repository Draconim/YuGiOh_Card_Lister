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
    public partial class UpdateSzorny : Form
    {
        public static string regiAzon;
        public UpdateSzorny(string azonosito)
        {
            InitializeComponent();
            cb_szorny_tipus.DataSource = Enum.GetValues(typeof(MonsterCardType));
            cb_ritkasag.DataSource = Enum.GetValues(typeof(Rarity));
            cb_attributum.DataSource = Enum.GetValues(typeof(Attributum));
            SzornyekTabla manager = new SzornyekTabla();
            List<Szornyek> szorny = manager.keresSelect(null, azonosito);
            txb_azonosito.Text = szorny[0].Azonosito;
            txb_nev.Text = szorny[0].Nev;
            txb_leiras.Text = szorny[0].Leiras;
            cb_szorny_tipus.Text = szorny[0].MonsterCardType;
            txb_szint.Text = szorny[0].Level;
            cb_attributum.Text = szorny[0].Attribute;
            txb_tipus.Text = szorny[0].Type;
            txb_atk.Text = szorny[0].Attack;
            txb_def.Text = szorny[0].Defense;
            txb_link_szint.Text = szorny[0].LinkLevel;
            cb_ritkasag.Text = szorny[0].Rarity;
            txb_mennyiseg.Text = szorny[0].Quantity;
            regiAzon = szorny[0].Azonosito;
            BoxEllen();
        }

        private void Btn_frissites_Click(object sender, EventArgs e)
        {
            Szornyek szorny = new Szornyek();
            szorny.Azonosito = txb_azonosito.Text.ToString();
            szorny.Nev = txb_nev.Text.ToString();
            szorny.Leiras = txb_leiras.Text.ToString();
            szorny.MonsterCardType = cb_szorny_tipus.Text.ToString();
            szorny.Level = txb_szint.Text.ToString();
            szorny.Attribute = cb_attributum.Text.ToString();
            szorny.Type = txb_tipus.Text.ToString();
            szorny.Attack = txb_atk.Text.ToString();
            szorny.Defense = txb_def.Text.ToString();
            szorny.LinkLevel = txb_link_szint.Text.ToString();
            szorny.Rarity = cb_ritkasag.Text.ToString();
            szorny.Quantity = txb_mennyiseg.Text.ToString();
            SzornyekTabla manager = new SzornyekTabla();
            manager.Update(szorny,regiAzon);
            MessageBox.Show("A feltöltés megtörtént!");
            Form1 form = new Form1();
            form.InitDataGridViewSzorny();
            this.Close();
        }

        private void Cb_szorny_tipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_szorny_tipus.Text.ToString())
            {
                case "link":
                    txb_def.Enabled = false;
                    txb_def.Clear();
                    txb_szint.Enabled = false;
                    txb_szint.Clear();
                    txb_link_szint.Enabled = true;
                    break;
                default:
                    txb_def.Enabled = true;
                    txb_szint.Enabled = true;
                    txb_link_szint.Enabled = false;
                    txb_link_szint.Clear();
                    break;

            }
        }
        private void BoxEllen()
        {
            switch (cb_szorny_tipus.Text.ToString())
            {
                case "link":
                    txb_def.Enabled = false;
                    txb_def.Clear();
                    txb_szint.Enabled = false;
                    txb_szint.Clear();
                    txb_link_szint.Enabled = true;
                    break;
                default:
                    txb_def.Enabled = true;
                    txb_szint.Enabled = true;
                    txb_link_szint.Enabled = false;
                    txb_link_szint.Clear();
                    break;

            }
        }
    }
}
