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
        public ComboBox[] DriverComboBoxes { get; }
        private GameArea GameArea;
        private ComboBoxManager ComboBoxManager;

        public Form1()
        {
            InitializeComponent();
            DriverLabels = new Label[Constants.NUMBER_OF_DRIVERS];
            TeamLabels = new Label[Constants.NUMBER_OF_TEAMS];
            EngineLabels = new Label[Constants.NUMBER_OF_ENGINES];
            DriverComboBoxes = new ComboBox[Constants.NUMBER_OF_DRIVERS];
            FillDriverLabels();
            FillDriverComboBoxes();
            FillTeamLabels();
            FillEngineLabels();
            ComboBoxManager = new ComboBoxManager(this);
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

        private void FillDriverComboBoxes()
        {
            DriverComboBoxes[0] = this.comboBox1;
            DriverComboBoxes[1] = this.comboBox2;
            DriverComboBoxes[2] = this.comboBox3;
            DriverComboBoxes[3] = this.comboBox4; 
            DriverComboBoxes[4] = this.comboBox5;
            DriverComboBoxes[5] = this.comboBox6;
            DriverComboBoxes[6] = this.comboBox7;
            DriverComboBoxes[7] = this.comboBox8;
            DriverComboBoxes[8] = this.comboBox9;
            DriverComboBoxes[9] = this.comboBox10;
            DriverComboBoxes[10] = this.comboBox11;
            DriverComboBoxes[11] = this.comboBox12;
            DriverComboBoxes[12] = this.comboBox13;
            DriverComboBoxes[13] = this.comboBox14;
            DriverComboBoxes[14] = this.comboBox15;
            DriverComboBoxes[15] = this.comboBox16;
            DriverComboBoxes[16] = this.comboBox17;
            DriverComboBoxes[17] = this.comboBox18;
            DriverComboBoxes[18] = this.comboBox19;
            DriverComboBoxes[19] = this.comboBox20;
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

        public void removeComboBoxSelectedItem(int comboBoxIndex)
        {
            DriverComboBoxes[comboBoxIndex].SelectedItem = null;
        }

        private void comboBoxQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int comboBoxIndex = whichComboBox(senderComboBox);
        
            if ((ModifierKeys & Keys.Control) != Keys.Control)
            {
                ComboBoxManager.AvailablePositionListUpdateOnAdding(comboBoxIndex, (int)senderComboBox.SelectedItem);
            }
            else
            {
                if (senderComboBox.SelectedItem != null)
                {
                    ComboBoxManager.AvailablePositionListUpdateOnRemoving(comboBoxIndex, (int)senderComboBox.SelectedItem);
                }
            }
        }

        private int whichComboBox(ComboBox sender)
        {
            for (int i = 0; i < DriverComboBoxes.Length; i++)
            {
                if (DriverComboBoxes[i].Equals(sender))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
