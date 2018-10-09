using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula_One_Game
{
    public partial class Form1 : Form
    {
        private const int NumberOfDrivers = 20;
        private const int NumberOfTeams = 10;
        private const int NumberOfEngines = 4;

        public Label[] DriverLabels { get; }
        public Label[] TeamLabels { get; }
        public Label[] EngineLabels { get; }
        private GameArea GameArea;

        public Form1()
        {
            InitializeComponent();
            DriverLabels = new Label[NumberOfDrivers];
            TeamLabels = new Label[NumberOfTeams];
            EngineLabels = new Label[NumberOfEngines];
            FillDriverLabels();
            FillTeamLabels();
            FillEngineLabels();
            GameArea = new GameArea(this);
        }

        private void FillDriverLabels()
        {
            DriverLabels[0] = this.label1;
            DriverLabels[1] = this.label2;
            DriverLabels[2] = this.label3;
            DriverLabels[3] = this.label4;
            DriverLabels[4] = this.label5;
            DriverLabels[5] = this.label6;
            DriverLabels[6] = this.label7;
            DriverLabels[7] = this.label8;
            DriverLabels[8] = this.label9;
            DriverLabels[9] = this.label10;
            DriverLabels[10] = this.label11;
            DriverLabels[11] = this.label12;
            DriverLabels[12] = this.label13;
            DriverLabels[13] = this.label14;
            DriverLabels[14] = this.label15;
            DriverLabels[15] = this.label16;
            DriverLabels[16] = this.label17;
            DriverLabels[17] = this.label18;
            DriverLabels[18] = this.label19;
            DriverLabels[19] = this.label20;
        }

        private void FillTeamLabels()
        {
            TeamLabels[0] = this.label21;
            TeamLabels[1] = this.label22;
            TeamLabels[2] = this.label23;
            TeamLabels[3] = this.label24;
            TeamLabels[4] = this.label25;
            TeamLabels[5] = this.label26;
            TeamLabels[6] = this.label27;
            TeamLabels[7] = this.label28; 
            TeamLabels[8] = this.label29;
            TeamLabels[9] = this.label30;
        }
        private void FillEngineLabels()
        {
            EngineLabels[0] = this.label31;
            EngineLabels[1] = this.label32;
            EngineLabels[2] = this.label33;
            EngineLabels[3] = this.label34;
        }

        private void buttonPointSort_Click(object sender, EventArgs e)
        {
            DreamTeamOptionWindow dreamTeamOptionWindow = new DreamTeamOptionWindow(GameArea.GetAvailableOptions());
            dreamTeamOptionWindow.Show();
        }
    }
}
