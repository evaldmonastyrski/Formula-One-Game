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
            FillDriverLabels();
            FillDriverQualificationComboBoxes();
            FillDriverRaceComboBoxes();
            FillTeamLabels();
            FillEngineLabels();
            ComboBoxManager = new ComboBoxManager(this);
            GameArea = new GameArea(this);
        }

        public void SetGPCombo(List<string> gpStages)
        {
            foreach(string gpStage in gpStages)
            {
                comboBoxGPRace.Items.Add(gpStage);
            }
            comboBoxGPRace.SelectedIndex = 0;
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

        private void FillDriverQualificationComboBoxes()
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

        private void FillDriverRaceComboBoxes()
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

        }

        private void numericUpDownBudget_ValueChanged(object sender, EventArgs e)
        {
            GameArea.RecalculateCombinations();
        }
    }
}
