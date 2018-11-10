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
        public Label[] DriverLabels { get; }
        public Label[] TeamLabels { get; }
        public Label[] EngineLabels { get; }
        public ComboBox[] DriverQualificationComboBoxes { get; }
        public ComboBox[] DriverRaceComboBoxes { get; }
        public Label[] DriverPointsLabels { get; }
        public Label[] TeamPointsLabels { get; }
        public Label[] EnginePointsLabels { get; }
        public Label[] DriverPriceChangeLabels { get; }
        public Label[] TeamPriceChangeLabels { get; }
        public Label[] EnginePriceChangeLabels { get; }
        private GameArea GameArea;
        private ComboBoxManager ComboBoxManager;
        
        public Form1()
        {
            InitializeComponent();
            DriverLabels = new Label[Constants.NUMBER_OF_DRIVERS];
            TeamLabels = new Label[Constants.NUMBER_OF_TEAMS];
            EngineLabels = new Label[Constants.NUMBER_OF_ENGINES];
            DriverQualificationComboBoxes = new ComboBox[Constants.NUMBER_OF_DRIVERS];
            DriverRaceComboBoxes = new ComboBox[Constants.NUMBER_OF_DRIVERS];
            DriverPointsLabels = new Label[Constants.NUMBER_OF_DRIVERS];
            TeamPointsLabels = new Label[Constants.NUMBER_OF_TEAMS];
            EnginePointsLabels = new Label[Constants.NUMBER_OF_ENGINES];
            DriverPriceChangeLabels = new Label[Constants.NUMBER_OF_DRIVERS];
            TeamPriceChangeLabels = new Label[Constants.NUMBER_OF_TEAMS];
            EnginePriceChangeLabels = new Label[Constants.NUMBER_OF_ENGINES];
            fillDriverQualificationComboBoxes();
            fillDriverRaceComboBoxes();
            fillDriverLabels();
            fillTeamLabels();
            fillEngineLabels();
            fillDriverPointsLabels();
            fillTeamPointsLabels();
            fillEnginePointsLabels();
            fillDriverPriceChangeLabels();
            fillTeamPriceChangeLabels();
            fillEnginePriceChangeLabels();
            GameArea = new GameArea(this);
            ComboBoxManager = new ComboBoxManager(this, GameArea);
            comboBoxGPRace.SelectedIndex = comboBoxGPRace.Items.Count - 1;
        }

        public void SetGPCombo(List<string> gpStages)
        {
            foreach(string gpStage in gpStages)
            {
                comboBoxGPRace.Items.Add(gpStage.Replace("_", " "));
            }
        }

        private void fillDriverLabels()
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

        private void fillDriverQualificationComboBoxes()
        {
            DriverQualificationComboBoxes[0] = this.comboBox1;
            DriverQualificationComboBoxes[1] = this.comboBox2;
            DriverQualificationComboBoxes[2] = this.comboBox3;
            DriverQualificationComboBoxes[3] = this.comboBox4; 
            DriverQualificationComboBoxes[4] = this.comboBox5;
            DriverQualificationComboBoxes[5] = this.comboBox6;
            DriverQualificationComboBoxes[6] = this.comboBox7;
            DriverQualificationComboBoxes[7] = this.comboBox8;
            DriverQualificationComboBoxes[8] = this.comboBox9;
            DriverQualificationComboBoxes[9] = this.comboBox10;
            DriverQualificationComboBoxes[10] = this.comboBox11;
            DriverQualificationComboBoxes[11] = this.comboBox12;
            DriverQualificationComboBoxes[12] = this.comboBox13;
            DriverQualificationComboBoxes[13] = this.comboBox14;
            DriverQualificationComboBoxes[14] = this.comboBox15;
            DriverQualificationComboBoxes[15] = this.comboBox16;
            DriverQualificationComboBoxes[16] = this.comboBox17;
            DriverQualificationComboBoxes[17] = this.comboBox18;
            DriverQualificationComboBoxes[18] = this.comboBox19;
            DriverQualificationComboBoxes[19] = this.comboBox20;
        }

        private void fillDriverRaceComboBoxes()
        {
            DriverRaceComboBoxes[0] = this.comboBox21;
            DriverRaceComboBoxes[1] = this.comboBox22;
            DriverRaceComboBoxes[2] = this.comboBox23;
            DriverRaceComboBoxes[3] = this.comboBox24;
            DriverRaceComboBoxes[4] = this.comboBox25;
            DriverRaceComboBoxes[5] = this.comboBox26;
            DriverRaceComboBoxes[6] = this.comboBox27;
            DriverRaceComboBoxes[7] = this.comboBox28;
            DriverRaceComboBoxes[8] = this.comboBox29;
            DriverRaceComboBoxes[9] = this.comboBox30;
            DriverRaceComboBoxes[10] = this.comboBox31;
            DriverRaceComboBoxes[11] = this.comboBox32;
            DriverRaceComboBoxes[12] = this.comboBox33;
            DriverRaceComboBoxes[13] = this.comboBox34;
            DriverRaceComboBoxes[14] = this.comboBox35;
            DriverRaceComboBoxes[15] = this.comboBox36;
            DriverRaceComboBoxes[16] = this.comboBox37;
            DriverRaceComboBoxes[17] = this.comboBox38;
            DriverRaceComboBoxes[18] = this.comboBox39;
            DriverRaceComboBoxes[19] = this.comboBox40;
        }

        private void fillDriverPointsLabels()
        {
            DriverPointsLabels[0] = this.labelDriver1;
            DriverPointsLabels[1] = this.labelDriver2;
            DriverPointsLabels[2] = this.labelDriver3;
            DriverPointsLabels[3] = this.labelDriver4;
            DriverPointsLabels[4] = this.labelDriver5;
            DriverPointsLabels[5] = this.labelDriver6;
            DriverPointsLabels[6] = this.labelDriver7;
            DriverPointsLabels[7] = this.labelDriver8;
            DriverPointsLabels[8] = this.labelDriver9;
            DriverPointsLabels[9] = this.labelDriver10;
            DriverPointsLabels[10] = this.labelDriver11;
            DriverPointsLabels[11] = this.labelDriver12;
            DriverPointsLabels[12] = this.labelDriver13;
            DriverPointsLabels[13] = this.labelDriver14;
            DriverPointsLabels[14] = this.labelDriver15;
            DriverPointsLabels[15] = this.labelDriver16;
            DriverPointsLabels[16] = this.labelDriver17;
            DriverPointsLabels[17] = this.labelDriver18;
            DriverPointsLabels[18] = this.labelDriver19;
            DriverPointsLabels[19] = this.labelDriver20;
        }

        private void fillTeamLabels()
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

        private void fillTeamPointsLabels()
        {
            TeamPointsLabels[0] = this.labelTeam1;
            TeamPointsLabels[1] = this.labelTeam2;
            TeamPointsLabels[2] = this.labelTeam3;
            TeamPointsLabels[3] = this.labelTeam4;
            TeamPointsLabels[4] = this.labelTeam5;
            TeamPointsLabels[5] = this.labelTeam6;
            TeamPointsLabels[6] = this.labelTeam7;
            TeamPointsLabels[7] = this.labelTeam8;
            TeamPointsLabels[8] = this.labelTeam9;
            TeamPointsLabels[9] = this.labelTeam10;
        }

        private void fillEnginePointsLabels()
        {
            EnginePointsLabels[0] = this.labelEngine1;
            EnginePointsLabels[1] = this.labelEngine2;
            EnginePointsLabels[2] = this.labelEngine3;
            EnginePointsLabels[3] = this.labelEngine4;
        }

        private void fillEngineLabels()
        {
            EngineLabels[0] = this.label31;
            EngineLabels[1] = this.label32;
            EngineLabels[2] = this.label33;
            EngineLabels[3] = this.label34;
        }

        private void fillDriverPriceChangeLabels()
        {
            DriverPriceChangeLabels[0] = this.labelDriverPC1;
            DriverPriceChangeLabels[1] = this.labelDriverPC2;
            DriverPriceChangeLabels[2] = this.labelDriverPC3;
            DriverPriceChangeLabels[3] = this.labelDriverPC4;
            DriverPriceChangeLabels[4] = this.labelDriverPC5;
            DriverPriceChangeLabels[5] = this.labelDriverPC6;
            DriverPriceChangeLabels[6] = this.labelDriverPC7;
            DriverPriceChangeLabels[7] = this.labelDriverPC8;
            DriverPriceChangeLabels[8] = this.labelDriverPC9;
            DriverPriceChangeLabels[9] = this.labelDriverPC10;
            DriverPriceChangeLabels[10] = this.labelDriverPC11;
            DriverPriceChangeLabels[11] = this.labelDriverPC12;
            DriverPriceChangeLabels[12] = this.labelDriverPC13;
            DriverPriceChangeLabels[13] = this.labelDriverPC14;
            DriverPriceChangeLabels[14] = this.labelDriverPC15;
            DriverPriceChangeLabels[15] = this.labelDriverPC16;
            DriverPriceChangeLabels[16] = this.labelDriverPC17;
            DriverPriceChangeLabels[17] = this.labelDriverPC18;
            DriverPriceChangeLabels[18] = this.labelDriverPC19;
            DriverPriceChangeLabels[19] = this.labelDriverPC20;
        }

        private void fillTeamPriceChangeLabels()
        {
            TeamPriceChangeLabels[0] = this.labelTeamPC1;
            TeamPriceChangeLabels[1] = this.labelTeamPC2;
            TeamPriceChangeLabels[2] = this.labelTeamPC3;
            TeamPriceChangeLabels[3] = this.labelTeamPC4;
            TeamPriceChangeLabels[4] = this.labelTeamPC5;
            TeamPriceChangeLabels[5] = this.labelTeamPC6;
            TeamPriceChangeLabels[6] = this.labelTeamPC7;
            TeamPriceChangeLabels[7] = this.labelTeamPC8;
            TeamPriceChangeLabels[8] = this.labelTeamPC9;
            TeamPriceChangeLabels[9] = this.labelTeamPC10;
        }

        private void fillEnginePriceChangeLabels()
        {
            EnginePriceChangeLabels[0] = this.labelEnginePC1;
            EnginePriceChangeLabels[1] = this.labelEnginePC2;
            EnginePriceChangeLabels[2] = this.labelEnginePC3;
            EnginePriceChangeLabels[3] = this.labelEnginePC4;
        }
       
        private void buttonPointSort_Click(object sender, EventArgs e)
        {
            DreamTeamOptionWindow dreamTeamOptionWindow = new DreamTeamOptionWindow(GameArea.GetAvailableOptions(SortType.POINTS));
            dreamTeamOptionWindow.Show();
        }

        private void buttonPriceChangeSort_Click(object sender, EventArgs e)
        {
            DreamTeamOptionWindow dreamTeamOptionWindow = new DreamTeamOptionWindow(GameArea.GetAvailableOptions(SortType.PRICE_CHANGE));
            dreamTeamOptionWindow.Show();
        }

        private void comboBoxQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int comboBoxIndex = whichComboBox(senderComboBox, SessionType.QUALIFICATION);
        
            if ((ModifierKeys & Keys.Control) != Keys.Control)
            {
                ComboBoxManager.AvailablePositionListUpdateOnAdding(comboBoxIndex, (int)senderComboBox.SelectedItem, SessionType.QUALIFICATION);
            }
            else
            {
                if (senderComboBox.SelectedItem != null)
                {
                    ComboBoxManager.AvailablePositionListUpdateOnRemoving(comboBoxIndex, (int)senderComboBox.SelectedItem, SessionType.QUALIFICATION);
                }
            }
        }

        private void comboBoxRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int comboBoxIndex = whichComboBox(senderComboBox, SessionType.RACE);

            if ((ModifierKeys & Keys.Control) != Keys.Control)
            {
                ComboBoxManager.AvailablePositionListUpdateOnAdding(comboBoxIndex, (int)senderComboBox.SelectedItem, SessionType.RACE);
            }
            else
            {
                if (senderComboBox.SelectedItem != null)
                {
                    ComboBoxManager.AvailablePositionListUpdateOnRemoving(comboBoxIndex, (int)senderComboBox.SelectedItem, SessionType.RACE);
                }
            }
        }

        private int whichComboBox(ComboBox sender, SessionType sessionType)
        {
            ComboBox[] DriverComboBoxes = whichSessionArray(sessionType);
            for (int i = 0; i < DriverComboBoxes.Length; i++)
            {
                if (DriverComboBoxes[i].Equals(sender))
                {
                    return i;
                }
            }
            return 0;
        }

        private ComboBox[] whichSessionArray(SessionType sessionType)
        {
            ComboBox[] driverComboBoxes = DriverQualificationComboBoxes;
            if (sessionType == SessionType.RACE)
            {
                driverComboBoxes = DriverRaceComboBoxes;
            }
            return driverComboBoxes;
        }

        private void comboBoxGPRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            disableSortButtons();
            GameArea.InitializeStageDependentGameAreaComponents(comboBoxGPRace.SelectedIndex);
            resetDriverPointsLabels();
            resetTeamPointsLabels();
            resetEnginePointsLabels();
            ComboBoxManager.restoreQualificationPositions();
            ComboBoxManager.restoreRacePositions();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            enableSortButtons();
            GameArea.CalculateCombinations((float)numericUpDownBudget.Value);
        }

        private void numericUpDownBudget_ValueChanged(object sender, EventArgs e)
        {
            disableSortButtons();
        }

        private void enableSortButtons()
        {
            buttonPointSort.Enabled = true;
            buttonPriceChangeSort.Enabled = true;
        }

        private void disableSortButtons()
        {
            buttonPointSort.Enabled = false;
            buttonPriceChangeSort.Enabled = false;
        }

        private void buttonFlushQ_Click(object sender, EventArgs e)
        {
            ComboBoxManager.restoreQualificationPositions();
            disableSortButtons();
        }

        private void buttonFlushR_Click(object sender, EventArgs e)
        {
            ComboBoxManager.restoreRacePositions();
            disableSortButtons();
        }

        private void resetDriverPointsLabels()
        {
            foreach (Label label in DriverPointsLabels)
            {
                label.Text = "";
            }
        }

        private void resetTeamPointsLabels()
        {
            foreach (Label label in TeamPointsLabels)
            {
                label.Text = "";
            }
        }

        private void resetEnginePointsLabels()
        {
            foreach (Label label in EnginePointsLabels)
            {
                label.Text = "";
            }
        }

        public void ColorLabels(Label label, float priceChange)
        {
            if (priceChange > 1.5F)
            {
                label.BackColor = Color.Chartreuse;
                label.ForeColor = Color.Black;
            }
            else if (priceChange > 0.5F)
            {
                label.BackColor = Color.SpringGreen;
                label.ForeColor = Color.Black;
            }
            else if (priceChange > 0F)
            {
                label.BackColor = Color.PaleGreen;
                label.ForeColor = Color.Black;
            }
            else if (priceChange > -0.5F)
            {
                label.BackColor = Color.Yellow;
                label.ForeColor = Color.Black;
            }
            else if (priceChange > -1F)
            {
                label.BackColor = Color.Red;
                label.ForeColor = Color.White;
            }
            else
            {
                label.BackColor = Color.Firebrick;
                label.ForeColor = Color.White;
            }
        }
    }
}
