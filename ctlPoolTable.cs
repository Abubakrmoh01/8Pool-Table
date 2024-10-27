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
    public partial class ctlPoolTable : UserControl
    {
        public ctlPoolTable()
        {
            InitializeComponent();
        }

        public class TableCompletedEventArgs:EventArgs
        {
            public string TimeText { get; }
            public int  timeinsocnd { get; }
            public float rateperhour { get; }
            public float Totalfee { get; }

            public TableCompletedEventArgs(string timeText, int timeinsocnd, float rateperhour, float totalfee)
            {
                this.TimeText = timeText;
                this.timeinsocnd = timeinsocnd;
                this.rateperhour = rateperhour;
               this.Totalfee = totalfee;
            }
        }



            public event EventHandler <TableCompletedEventArgs> OnTableComplete;
        public void RaiseOnTableComlete(string timeText, int timeinsocnd, float rateperhour, float totalfee)
        {
            RaiseOnTableComplete(new TableCompletedEventArgs( timeText,  timeinsocnd,  rateperhour,  totalfee));
        }
        protected virtual void RaiseOnTableComplete(TableCompletedEventArgs e)
        { 
                    OnTableComplete?.Invoke(this, e);

        }

            int _Sconds;

        private string _TableTitle = "Table";

        [
            Category("Pool Config"),
            Description("the table Name. ")
        ]
        public string TableTitle
        {
            get { return _TableTitle; }
            set {
                _TableTitle = value; 
                grpTable.Text= value;
                Invalidate();
            }
        }


        private string _TablePlayer = "Player";

        [
            Category("Pool Config"),
            Description("the Player Name. ")
        ]
        public string TablePlayer
        {
            get { return _TablePlayer; }
            set
            {
                _TablePlayer = value;
                lblPlayer.Text = value;
                Invalidate();
            }
        }


        private float _HoulryRate = 10.00F;
        [
           Category("Pool Config"),
           Description("Rate per Hour. ")
       ]
        public float HoulryRate
        {
            get { return _HoulryRate; }
            set
            {
                _HoulryRate = value;
                Invalidate();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text=="Start")
            {
                btnStart.Text = "Stop";
                timer1.Start();
            }
            else
            {
                btnStart.Text = "Start";
                timer1.Stop();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            float Totalfess = ((float)_Sconds / 60 / 60) * _HoulryRate;
            RaiseOnTableComlete(lblTime.Text,_Sconds,_HoulryRate ,Totalfess);
            grpTable.Text = "Table";
            lblPlayer.Text = "Player";
            lblTime.Text = "00:00:00";
            btnStart.Text = "Start";
            _Sconds = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _Sconds++;
           TimeSpan time=TimeSpan.FromSeconds(_Sconds);
            string str=time.ToString(@"hh\:mm\:ss");
            lblTime.Text = str;
            lblTime.Refresh();

        }

        private void ctlPoolTable_Load(object sender, EventArgs e)
        {
            grpTable.Text = _TableTitle;
            lblPlayer.Text = _TablePlayer;
        }

        private void cmsPlayer_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            lblPlayer.Text=toolStripTextBox1.Text;
        }
    }
}
