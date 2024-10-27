using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pooltable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void ctlPoolTable1_Load(object sender, EventArgs e)
        {

        }

        private void ctlPoolTable4_OnTableComplete(object sender, ctlPoolTable.TableCompletedEventArgs e)
        {
            string TableResults = "";

            TableResults = "Time Consumed " + e.TimeText;
            TableResults = TableResults + ", Total Seconds= " + e.timeinsocnd;
            TableResults = TableResults + ", HourlyRate=" + e.rateperhour.ToString();
            TableResults = TableResults + ", Total Fees=" + e.Totalfee.ToString();

            MessageBox.Show(TableResults);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
