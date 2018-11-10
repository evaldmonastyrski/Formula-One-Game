using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula_One_Game
{
    class ComboBoxManager
    {
        private Form1 Form;
        private GameArea GameArea;
        public SortedSet<int> QualificationPositions { get; }
        public SortedSet<int> RacePositions { get; }
        private int[] selectedQualificationPositions;
        private int[] selectedRacePositions;

        public ComboBoxManager(Form1 form, GameArea gameArea)
        {
            Form = form;
            GameArea = gameArea;
            QualificationPositions = new SortedSet<int>(Enumerable.Range(1, Constants.NUMBER_OF_DRIVERS));
            selectedQualificationPositions = new int[Constants.NUMBER_OF_DRIVERS];
            RacePositions = new SortedSet<int>(Enumerable.Range(1, Constants.NUMBER_OF_DRIVERS));
            selectedRacePositions = new int[Constants.NUMBER_OF_DRIVERS];
            uploadDriverComboBoxItems(QualificationPositions, SessionType.QUALIFICATION);
            uploadDriverComboBoxItems(RacePositions, SessionType.RACE);
        }

        public void AvailablePositionListUpdateOnAdding(int comboBoxIndex, int selectedPosition, SessionType sessionType)
        {
            int[] selectedPositions = selectedQualificationPositions;
            SortedSet<int> positions = QualificationPositions;
            whichPositions(sessionType, out selectedPositions, out positions);

            int cachedPosition = selectedPositions[comboBoxIndex];
            if (cachedPosition != 0)
            {
                positions.Add(cachedPosition);
            }
            selectedPositions[comboBoxIndex] = selectedPosition;
            GameArea.UpdateDreamTeamComponents(comboBoxIndex, selectedQualificationPositions[comboBoxIndex], selectedRacePositions[comboBoxIndex]);
            positions.Remove(selectedPosition);
            removeDriverComboBoxItems(positions, sessionType);
            uploadDriverComboBoxItems(positions, sessionType);
        }

        public void AvailablePositionListUpdateOnRemoving(int comboBoxIndex, int selectedPosition, SessionType sessionType)
        {
            int[] selectedPositions = selectedQualificationPositions;
            SortedSet<int> positions = QualificationPositions;
            whichPositions(sessionType, out selectedPositions, out positions);

            int cachedPosition = selectedPositions[comboBoxIndex];
            if (cachedPosition != 0)
            {
                positions.Add(cachedPosition);
                selectedPositions[comboBoxIndex] = 0;
                removeComboBoxSelectedItem(comboBoxIndex, sessionType);
                removeDriverComboBoxItems(positions, sessionType);
                uploadDriverComboBoxItems(positions, sessionType);
            }
            GameArea.UpdateDreamTeamComponents(comboBoxIndex, selectedQualificationPositions[comboBoxIndex], selectedRacePositions[comboBoxIndex]);
        }

        public void restoreQualificationPositions()
        {
            for (int i = 1; i <= Constants.NUMBER_OF_DRIVERS; i++)
            {
                if(!QualificationPositions.Contains(i))
                {
                    QualificationPositions.Add(i);
                }
            }
            selectedQualificationPositions = new int[Constants.NUMBER_OF_DRIVERS];
            clearComboBoxes(Form.DriverQualificationComboBoxes);
            uploadDriverComboBoxItems(QualificationPositions, SessionType.QUALIFICATION);
        }

        public void restoreRacePositions()
        {
            for (int i = 1; i <= Constants.NUMBER_OF_DRIVERS; i++)
            {
                if (!RacePositions.Contains(i))
                {
                    RacePositions.Add(i);
                }
            }
            selectedRacePositions = new int[Constants.NUMBER_OF_DRIVERS];
            clearComboBoxes(Form.DriverRaceComboBoxes);
            uploadDriverComboBoxItems(RacePositions, SessionType.RACE);
        }

        private void removeComboBoxSelectedItem(int comboBoxIndex, SessionType sessionType)
        {
            ComboBox[] driverComboBoxes = whichSessionArray(sessionType);
            driverComboBoxes[comboBoxIndex].SelectedItem = null;
        }

        private void uploadDriverComboBoxItems(SortedSet<int> positions, SessionType sessionType)
        {
            ComboBox[] driverComboBoxes = Form.DriverQualificationComboBoxes;
            if (sessionType == SessionType.RACE)
            {
                driverComboBoxes = Form.DriverRaceComboBoxes;
            }

            foreach (ComboBox comboBox in driverComboBoxes)
            {
                foreach (int number in positions)
                {
                    comboBox.Items.Add(number);
                }
            }
        }

        private void removeDriverComboBoxItems(SortedSet<int> positions, SessionType sessionType)
        {
            ComboBox[] driverComboBoxes = Form.DriverQualificationComboBoxes;
            if (sessionType == SessionType.RACE)
            {
                driverComboBoxes = Form.DriverRaceComboBoxes;
            }

            foreach (ComboBox comboBox in driverComboBoxes)
            {
                if (comboBox.SelectedItem == null)
                {
                    comboBox.Items.Clear();
                }
                else
                {
                    int numberOfExistingItems = comboBox.Items.Count;
                    for (int j = numberOfExistingItems - 1; j > -1; j--)
                    {
                        if ((int)comboBox.SelectedItem != (int)comboBox.Items[j])
                        {
                            comboBox.Items.RemoveAt(j);
                        }
                    }
                }
            }
        }

        private void whichPositions(SessionType sessionType, out int[] selectedPositions, out SortedSet<int> positions)
        {
            selectedPositions = selectedQualificationPositions;
            positions = QualificationPositions;
            if (sessionType == SessionType.RACE)
            {
                selectedPositions = selectedRacePositions;
                positions = RacePositions;
            }
        }

        private ComboBox[] whichSessionArray(SessionType sessionType)
        {
            ComboBox[] driverComboBoxes = Form.DriverQualificationComboBoxes;
            if (sessionType == SessionType.RACE)
            {
                driverComboBoxes = Form.DriverRaceComboBoxes;
            }
            return driverComboBoxes;
        }

        private void clearComboBoxes(ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                comboBox.Items.Clear();
            }
        }
    }
}
