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
        public SortedSet<int> QualificationPositions { get; }
        private int[] SelectedQualificationPositions;

        public ComboBoxManager(Form1 form)
        {
            Form = form;
            QualificationPositions = new SortedSet<int>(Enumerable.Range(1, Constants.NUMBER_OF_DRIVERS));
            SelectedQualificationPositions = new int[Constants.NUMBER_OF_DRIVERS];
            UploadDriverComboBoxItems();
        }

        public void AvailablePositionListUpdateOnAdding(int comboBoxIndex, int selectedPosition)
        {
            int cachedPosition = SelectedQualificationPositions[comboBoxIndex];
            if (cachedPosition != 0)
            {
                QualificationPositions.Add(cachedPosition);
            }
            SelectedQualificationPositions[comboBoxIndex] = selectedPosition;
            QualificationPositions.Remove(selectedPosition);
            RemoveDriverComboBoxItems();
            UploadDriverComboBoxItems();
        }

        public void AvailablePositionListUpdateOnRemoving(int comboBoxIndex, int selectedPosition)
        {
            int cachedPosition = SelectedQualificationPositions[comboBoxIndex];
            if (cachedPosition != 0)
            {
                QualificationPositions.Add(cachedPosition);
                SelectedQualificationPositions[comboBoxIndex] = 0;
                Form.removeComboBoxSelectedItem(comboBoxIndex);
                RemoveDriverComboBoxItems();
                UploadDriverComboBoxItems();
            }
        }

        private void UploadDriverComboBoxItems()
        {
            foreach (ComboBox comboBox in Form.DriverComboBoxes)
            {
                foreach (int number in QualificationPositions)
                {
                    comboBox.Items.Add(number);
                }
            }
        }

        private void RemoveDriverComboBoxItems()
        {
            foreach (ComboBox comboBox in Form.DriverComboBoxes)
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
    }
}
