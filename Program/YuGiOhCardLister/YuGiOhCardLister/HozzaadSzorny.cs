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
    public partial class HozzaadSzorny : Form
    {
        public HozzaadSzorny()
        {
            InitializeComponent();
            cb_szorny_tipus.DataSource = Enum.GetValues(typeof(MonsterCardType));
            cb_ritkasag.DataSource = Enum.GetValues(typeof(Rarity));
            cb_attributum.DataSource = Enum.GetValues(typeof(Attributum));

        }

        private void Btn_megse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] numbers = "0123456789".ToCharArray();
        private void Btn_Feltoltes_Click(object sender, EventArgs e)
        {
            if (txb_azonosito.Text.ToString().Length != 10)
                MessageBox.Show("A megadott azonosító formátuma hibás! Helyes formátum: XX12-EN012");
            else
                if (alpha.Contains(txb_azonosito.Text.ToString()[0]) && alpha.Contains(txb_azonosito.Text.ToString()[1]))
                    if (numbers.Contains(txb_azonosito.Text.ToString()[2]) && numbers.Contains(txb_azonosito.Text.ToString()[3]))
                        if (txb_azonosito.Text.ToString()[4] == '-')
                            if (txb_azonosito.Text.ToString()[5] == 'E' && txb_azonosito.Text.ToString()[6] == 'N')
                            {
                                int i = 7;
                                while (i < 10)
                                {
                                    if (!numbers.Contains(txb_azonosito.Text.ToString()[i]))
                                        break;
                                i++;
                                }
                                if (i == 10)
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
                                    manager.Insert(szorny);
                                    MessageBox.Show("A feltöltés megtörtént!");
                                    Form1 form = new Form1();
                                    form.InitDataGridViewSzorny();
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Az azonosító utolsó három karaktere rossz!");
                            }
                            else
                                MessageBox.Show("Az azonosító második felének 'EN'-el kell kezdődnie!");
                        else
                            MessageBox.Show("A megadott azonosító első fele hibás!");
                    else
                        MessageBox.Show("A megadott azonosító első fele hibás!");
                else
                    MessageBox.Show("A megadott azonosító első fele hibás!");

        }
    

        private void Cb_szorny_tpius_SelectedIndexChanged(object sender, EventArgs e)
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
