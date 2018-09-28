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
        private const int NUMBER_OF_DRIVERS = 20;
        private const int NUMBER_OF_TEAMS = 10;

        private GameArea theGameArea;
        private Label[] driverLabels = new Label[NUMBER_OF_DRIVERS];
        private Label[] teamLabels = new Label[NUMBER_OF_TEAMS];

        public Form1()
        {
            InitializeComponent();
            driverLabels = new Label[NUMBER_OF_DRIVERS];
            fillDriverLabels();
            fillTeamLabels();
            theGameArea = new GameArea(this);
        }

        public Label[] getDriverLabels()
        {
            return driverLabels;
        }

        public Label[] getTeamLabels()
        {
            return teamLabels;
        }

        private void fillDriverLabels()
        {
            driverLabels[0] = this.label1;
            driverLabels[1] = this.label2;
            driverLabels[2] = this.label3;
            driverLabels[3] = this.label4;
            driverLabels[4] = this.label5;
            driverLabels[5] = this.label6;
            driverLabels[6] = this.label7;
            driverLabels[7] = this.label8;
            driverLabels[8] = this.label9;
            driverLabels[9] = this.label10;
            driverLabels[10] = this.label11;
            driverLabels[11] = this.label12;
            driverLabels[12] = this.label13;
            driverLabels[13] = this.label14;
            driverLabels[14] = this.label15;
            driverLabels[15] = this.label16;
            driverLabels[16] = this.label17;
            driverLabels[17] = this.label18;
            driverLabels[18] = this.label19;
            driverLabels[19] = this.label20;
        }

        private void fillTeamLabels()
        {
            teamLabels[0] = this.label21;
            teamLabels[1] = this.label22;
            teamLabels[2] = this.label23;
            teamLabels[3] = this.label24;
            teamLabels[4] = this.label25;
            teamLabels[5] = this.label26;
            teamLabels[6] = this.label27;
            teamLabels[7] = this.label28; 
            teamLabels[8] = this.label29;
            teamLabels[9] = this.label30;
        }
    }
}
