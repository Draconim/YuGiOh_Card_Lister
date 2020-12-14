using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOhCardLister.Models.Manager;
using YuGiOhCardLister.Models.Records;
using YuGiOhCardLister.Models.Enums;



namespace YuGiOhCardLister
{
    public partial class Form1 : Form
    {
        SzornyekTabla szornyManager;
        VarazsTabla varazsManager;
        CsapdaTabla csapdaManager;
        List<Szornyek> rekords_SzornyekList;
        List<Varazs> rekords_VarazsList;
        List<Csapda> rekords_CsapdaList;
        //BackgroundWorker bgWorker;

        public Form1()
        {
            InitializeComponent();
            szornyManager = new SzornyekTabla();
            varazsManager = new VarazsTabla();
            csapdaManager = new CsapdaTabla();
            rekords_SzornyekList = new List<Szornyek>();
            rekords_VarazsList = new List<Varazs>();
            rekords_CsapdaList = new List<Csapda>();


        }

        private void Btn_Torles_Click(object sender, EventArgs e)
        {
            
            
            switch (cb_CardType.Text.ToString())
            {
                case "Szörny":
                    foreach (DataGridViewRow selectedRows in dgv_cards.SelectedRows)
                    {
                        Szornyek Torlendo = new Szornyek();
                        Torlendo.Azonosito = selectedRows.Cells["azonosito"].Value.ToString();

                        szornyManager.Delete(Torlendo);
                    }

                    MessageBox.Show(string.Format("Sor(ok) törölve."));
                    InitDataGridViewSzorny();
                    
                    break;
                case "Varázs":
                    foreach (DataGridViewRow selectedRows in dgv_cards.SelectedRows)
                    {
                        Varazs Torlendo = new Varazs();
                        Torlendo.Azonosito = selectedRows.Cells["azonosito"].Value.ToString();

                        varazsManager.Delete(Torlendo);
                    }

                    MessageBox.Show(string.Format("Sor(ok) törölve."));
                    InitDataGridViewVarazs();

                    break;
                case "Csapda":
                    foreach (DataGridViewRow selectedRows in dgv_cards.SelectedRows)
                    {
                        Csapda Torlendo = new Csapda();
                        Torlendo.Azonosito = selectedRows.Cells["azonosito"].Value.ToString();

                        csapdaManager.Delete(Torlendo);
                    }

                    MessageBox.Show(string.Format("Sor(ok) törölve."));
                    InitDataGridViewCsapda();

                    break;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {


            cb_CardType.DataSource = Enum.GetValues(typeof(KartyaTipus));

            switch (cb_CardType.Text.ToString())
            {
                case "Szörny":
                    InitDataGridViewSzorny();
                    break;
                case "Varázslap":
                    InitDataGridViewVarazs();
                    break;
                case "Csapdalap":
                    InitDataGridViewCsapda();
                    break;
            }


        }

        private void InitDataGridViewSzorny()
        {
            dgv_cards.Rows.Clear();
            dgv_cards.Columns.Clear();


            
            DataGridViewColumn AzonositoC = new DataGridViewColumn()
            {
                Name = "azonosito",
                HeaderText = "Azonosító",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(AzonositoC);

            DataGridViewColumn NevC = new DataGridViewColumn()
            {
                Name = "nev",
                HeaderText = "Név",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(NevC);

            DataGridViewColumn LeirasC = new DataGridViewColumn()
            {
                Name = "leiras",
                HeaderText = "Leírás",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(LeirasC);

            DataGridViewColumn MonsterCardTypeC = new DataGridViewColumn()
            {
                Name = "szornylaptipus",
                HeaderText = "Szörny típus",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(MonsterCardTypeC);

            DataGridViewColumn SzintC = new DataGridViewColumn()
            {
                Name = "szint",
                HeaderText = "Szint",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(SzintC);
           
            DataGridViewColumn AttributeC = new DataGridViewColumn()
            {
                Name = "attributum",
                HeaderText = "Attribútum",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(AttributeC);

            DataGridViewColumn TypeC = new DataGridViewColumn()
            {
                Name = "Tipus",
                HeaderText = "Típus",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(TypeC);
            
            DataGridViewColumn TamadasC = new DataGridViewColumn()
            {
                Name = "atk",
                HeaderText = "ATK",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(TamadasC);

            DataGridViewColumn VedekezesC = new DataGridViewColumn()
            {
                Name = "def",
                HeaderText = "DEF",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(VedekezesC);
 
            DataGridViewColumn LinkSzintC = new DataGridViewColumn()
            {
                Name = "linkSzint",
                HeaderText = "Link Szint",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(LinkSzintC);

            DataGridViewColumn RitkasagC = new DataGridViewColumn()
            {
                Name = "ritkasag",
                HeaderText = "Ritkaság",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(RitkasagC);

            DataGridViewColumn MennyisegC = new DataGridViewColumn()
            {
                Name = "mennyiseg",
                HeaderText = "Mennyiség",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(MennyisegC);


                    FillDataGridViewSzornyek();


        }

        private void InitDataGridViewVarazs()
        {
            dgv_cards.Rows.Clear();
            dgv_cards.Columns.Clear();



            DataGridViewColumn AzonositoC = new DataGridViewColumn()
            {
                Name = "azonosito",
                HeaderText = "Azonosító",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(AzonositoC);

            DataGridViewColumn NevC = new DataGridViewColumn()
            {
                Name = "nev",
                HeaderText = "Név",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(NevC);

            DataGridViewColumn LeirasC = new DataGridViewColumn()
            {
                Name = "leiras",
                HeaderText = "Leírás",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(LeirasC);

            DataGridViewColumn MagicTypeC = new DataGridViewColumn()
            {
                Name = "varazstipus",
                HeaderText = "Varázs típus",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(MagicTypeC);

            DataGridViewColumn RitkasagC = new DataGridViewColumn()
            {
                Name = "ritkasag",
                HeaderText = "Ritkaság",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(RitkasagC);

            DataGridViewColumn MennyisegC = new DataGridViewColumn()
            {
                Name = "mennyiseg",
                HeaderText = "Mennyiség",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(MennyisegC);

                    FillDataGridViewVarazs();
        }

        private void InitDataGridViewCsapda()
        {
            dgv_cards.Rows.Clear();
            dgv_cards.Columns.Clear();



            DataGridViewColumn AzonositoC = new DataGridViewColumn()
            {
                Name = "azonosito",
                HeaderText = "Azonosító",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(AzonositoC);

            DataGridViewColumn NevC = new DataGridViewColumn()
            {
                Name = "nev",
                HeaderText = "Név",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            dgv_cards.Columns.Add(NevC);

            DataGridViewColumn LeirasC = new DataGridViewColumn()
            {
                Name = "leiras",
                HeaderText = "Leírás",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(LeirasC);

            DataGridViewColumn TrapTypeC = new DataGridViewColumn()
            {
                Name = "csapdatipus",
                HeaderText = "Csapda típus",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(TrapTypeC);

            DataGridViewColumn RitkasagC = new DataGridViewColumn()
            {
                Name = "ritkasag",
                HeaderText = "Ritkaság",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(RitkasagC);

            DataGridViewColumn MennyisegC = new DataGridViewColumn()
            {
                Name = "mennyiseg",
                HeaderText = "Mennyiség",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dgv_cards.Columns.Add(MennyisegC);

                    FillDataGridViewCsapda();

        }


        private void FillDataGridViewSzornyek()
        {
            rekords_SzornyekList = szornyManager.Select();

            DataGridViewRow[] dataGridViewRows = new DataGridViewRow[rekords_SzornyekList.Count];

            for (int i = 0; i < rekords_SzornyekList.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                DataGridViewCell AzonositoCell = new DataGridViewTextBoxCell();
                AzonositoCell.Value = rekords_SzornyekList[i].Azonosito;
                dataGridViewRow.Cells.Add(AzonositoCell);

                DataGridViewCell NevCell = new DataGridViewTextBoxCell();
                NevCell.Value = rekords_SzornyekList[i].Nev;
                dataGridViewRow.Cells.Add(NevCell);

                DataGridViewCell LeirasCell = new DataGridViewTextBoxCell();
                LeirasCell.Value = rekords_SzornyekList[i].Leiras;
                dataGridViewRow.Cells.Add(LeirasCell);

                DataGridViewCell SzornyTipusCell = new DataGridViewTextBoxCell();
                SzornyTipusCell.Value = rekords_SzornyekList[i].MonsterCardType;
                dataGridViewRow.Cells.Add(SzornyTipusCell);

                DataGridViewCell SzintCell = new DataGridViewTextBoxCell();
                SzintCell.Value = rekords_SzornyekList[i].Level;
                dataGridViewRow.Cells.Add(SzintCell);

                DataGridViewCell AttributumCell = new DataGridViewTextBoxCell();
                AttributumCell.Value = rekords_SzornyekList[i].Attribute;
                dataGridViewRow.Cells.Add(AttributumCell);

                DataGridViewCell TipusCell = new DataGridViewTextBoxCell();
                TipusCell.Value = rekords_SzornyekList[i].Type;
                dataGridViewRow.Cells.Add(TipusCell);

                DataGridViewCell AtkCell = new DataGridViewTextBoxCell();
                AtkCell.Value = rekords_SzornyekList[i].Attack;
                dataGridViewRow.Cells.Add(AtkCell);

                DataGridViewCell DefCell = new DataGridViewTextBoxCell();
                DefCell.Value = rekords_SzornyekList[i].Defense;
                dataGridViewRow.Cells.Add(DefCell);

                DataGridViewCell LinkSzintCell = new DataGridViewTextBoxCell();
                LinkSzintCell.Value = rekords_SzornyekList[i].LinkLevel;
                dataGridViewRow.Cells.Add(LinkSzintCell);

                DataGridViewCell RitkasagCell = new DataGridViewTextBoxCell();
                RitkasagCell.Value = rekords_SzornyekList[i].Rarity;
                dataGridViewRow.Cells.Add(RitkasagCell);

                DataGridViewCell MennyisegCell = new DataGridViewTextBoxCell();
                MennyisegCell.Value = rekords_SzornyekList[i].Quantity;
                dataGridViewRow.Cells.Add(MennyisegCell);


                dataGridViewRows[i] = dataGridViewRow;
            }
            dgv_cards.Rows.Clear();
            dgv_cards.Rows.AddRange(dataGridViewRows);
        }

        private void FillDataGridViewVarazs()
        {

                    rekords_VarazsList = varazsManager.Select();



            DataGridViewRow[] dataGridViewRows = new DataGridViewRow[rekords_VarazsList.Count];

            for (int i = 0; i < rekords_VarazsList.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                DataGridViewCell AzonositoCell = new DataGridViewTextBoxCell();
                AzonositoCell.Value = rekords_VarazsList[i].Azonosito;
                dataGridViewRow.Cells.Add(AzonositoCell);

                DataGridViewCell NevCell = new DataGridViewTextBoxCell();
                NevCell.Value = rekords_VarazsList[i].Nev;
                dataGridViewRow.Cells.Add(NevCell);

                DataGridViewCell LeirasCell = new DataGridViewTextBoxCell();
                LeirasCell.Value = rekords_VarazsList[i].Leiras;
                dataGridViewRow.Cells.Add(LeirasCell);

                DataGridViewCell VarazsTipusCell = new DataGridViewTextBoxCell();
                VarazsTipusCell.Value = rekords_VarazsList[i].VarazsTipus;
                dataGridViewRow.Cells.Add(VarazsTipusCell);

                DataGridViewCell RitkasagCell = new DataGridViewTextBoxCell();
                RitkasagCell.Value = rekords_VarazsList[i].Rarity;
                dataGridViewRow.Cells.Add(RitkasagCell);

                DataGridViewCell MennyisegCell = new DataGridViewTextBoxCell();
                MennyisegCell.Value = rekords_VarazsList[i].Quantity;
                dataGridViewRow.Cells.Add(MennyisegCell);


                dataGridViewRows[i] = dataGridViewRow;
            }
            dgv_cards.Rows.Clear();
            dgv_cards.Rows.AddRange(dataGridViewRows);
        }

        private void FillDataGridViewCsapda()
        {


                    rekords_CsapdaList = csapdaManager.Select();

            DataGridViewRow[] dataGridViewRows = new DataGridViewRow[rekords_CsapdaList.Count];

            for (int i = 0; i < rekords_CsapdaList.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();

                DataGridViewCell AzonositoCell = new DataGridViewTextBoxCell();
                AzonositoCell.Value = rekords_CsapdaList[i].Azonosito;
                dataGridViewRow.Cells.Add(AzonositoCell);

                DataGridViewCell NevCell = new DataGridViewTextBoxCell();
                NevCell.Value = rekords_CsapdaList[i].Nev;
                dataGridViewRow.Cells.Add(NevCell);

                DataGridViewCell LeirasCell = new DataGridViewTextBoxCell();
                LeirasCell.Value = rekords_CsapdaList[i].Leiras;
                dataGridViewRow.Cells.Add(LeirasCell);

                DataGridViewCell VarazsTipusCell = new DataGridViewTextBoxCell();
                VarazsTipusCell.Value = rekords_CsapdaList[i].CsapdaTipus;
                dataGridViewRow.Cells.Add(VarazsTipusCell);

                DataGridViewCell RitkasagCell = new DataGridViewTextBoxCell();
                RitkasagCell.Value = rekords_CsapdaList[i].Rarity;
                dataGridViewRow.Cells.Add(RitkasagCell);

                DataGridViewCell MennyisegCell = new DataGridViewTextBoxCell();
                MennyisegCell.Value = rekords_CsapdaList[i].Quantity;
                dataGridViewRow.Cells.Add(MennyisegCell);


                dataGridViewRows[i] = dataGridViewRow;
            }
            dgv_cards.Rows.Clear();
            dgv_cards.Rows.AddRange(dataGridViewRows);
        }

        private void Cb_CardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_CardType.Text.ToString())
            {
                case "Szörny":
                    InitDataGridViewSzorny();
                    break;
                case "Varázslap":
                    InitDataGridViewVarazs();
                    break;
                case "Csapdalap":
                    InitDataGridViewCsapda();
                    break;
            }
        }

    }
}
