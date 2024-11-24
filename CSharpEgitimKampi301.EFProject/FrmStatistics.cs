using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString(); //Lokasyon tablosunu say
            lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice)?.ToString("0.00") + "₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);

            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
            
            lblCappadociaLocationCapasity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y =>y.LocationCapacity).FirstOrDefault().ToString();
            
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

            var RomeGuideId = db.Location.Where(x => x.LocationCity == "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == RomeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideIdAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdAysegulCinar).Count().ToString();

        }
    }
}
