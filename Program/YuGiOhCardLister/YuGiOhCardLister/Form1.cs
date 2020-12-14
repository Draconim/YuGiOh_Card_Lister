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
        BackgroundWorker bgWorker;

        public Form1()
        {
            InitializeComponent();
            szornyManager = new SzornyekTabla();
            varazsManager = new VarazsTabla();
            csapdaManager = new CsapdaTabla();
            rekords_SzornyekList = new List<Szornyek>();
            rekords_VarazsList = new List<Varazs>();
            rekords_CsapdaList = new List<Csapda>();
            bgWorker = new BackgroundWorker();

        }

    }
}
