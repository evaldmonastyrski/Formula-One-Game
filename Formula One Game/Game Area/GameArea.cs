using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula_One_Game
{
    class GameArea
    {
        private Form1 form;
        private DataDeserializer dataDeserializer;
        private SortedSet<Driver> drivers;
        private SortedSet<Team> teams;
        private SortedSet<Engine> engines;

        public void addDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public GameArea(Form1 form)
        {
            this.form = form;
            drivers = new SortedSet<Driver>();
            teams = new SortedSet<Team>();
            engines = new SortedSet<Engine>();
            dataDeserializer = new DataDeserializer(this);
            initializeLabels();
        }

        private void initializeLabels()
        {
            int labelIndex = 0;

            foreach(Driver driver in drivers)
            {
                form.getDriverLabels()[labelIndex].Text = driver.ToString();
                labelIndex++;
            }
        }
    }
}
