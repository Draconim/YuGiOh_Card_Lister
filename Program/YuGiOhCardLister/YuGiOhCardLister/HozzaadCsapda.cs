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
    public partial class HozzaadCsapda : Form
    {
        public HozzaadCsapda()
        {
            InitializeComponent();
            cb_csapda_tipus.DataSource = Enum.GetValues(typeof(CsapdaTipus));
            cb_ritkasag.DataSource = Enum.GetValues(typeof(Rarity));
        }

        private void Btn_megse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] numbers = "0123456789".ToCharArray();

        private void Btn_feltolt_Click(object sender, EventArgs e)
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
                                Csapda csapdalap = new Csapda();
                                csapdalap.Azonosito = txb_azonosito.Text.ToString();
                                csapdalap.Nev = txb_nev.Text.ToString();
                                csapdalap.Leiras = txb_leiras.Text.ToString();
                                csapdalap.CsapdaTipus = cb_csapda_tipus.Text.ToString();
                                csapdalap.Rarity = cb_ritkasag.Text.ToString();
                                csapdalap.Quantity = txb_mennyiseg.Text.ToString();
                                CsapdaTabla manager = new CsapdaTabla();
                                manager.Insert(csapdalap);
                                MessageBox.Show("A feltöltés megtörtént!");
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
    }
}
