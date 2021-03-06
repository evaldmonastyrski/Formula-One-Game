﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Team : DreamTeamComponent, IComparable
    {
        private List<Driver> drivers;

        public Team(string name)
            : base(name)
        {
            drivers = new List<Driver>();
        }

        public void SetPrice()
        {
            Price = Constants.TEAM_PRICE_RATIO * drivers.Sum(driver => driver.Price);
        }

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public void UpdatePoints()
        {
            Points = Constants.TEAM_PRICE_RATIO * drivers.Sum(Driver => Driver.Points);
        }

        public void UpdatePriceChange()
        {
            PriceChange = Constants.TEAM_PRICE_RATIO * drivers.Sum(Driver => Driver.PriceChange);
        }

        public override string ToString()
        {
            return Name.Replace("_", " ");
        }
    }
}
