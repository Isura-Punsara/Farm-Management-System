using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm
{
    public partial class breedreportview : Form
    {
        public breedreportview()
        {
            InitializeComponent();
            
        }

        private void breedreportview_Load(object sender, EventArgs e)
        {

            this.reportview.RefreshReport();
        }
    }
}
