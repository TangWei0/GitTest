﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Setting = trans.Properties.Settings;

namespace trans
{
    public class Parameter
    {
        public struct Custom
        {
            public UInt16 level;
            public UInt64 levelValue;
            public UInt64 cash;
            public UInt64 coin;
            public UInt16 garageVolume;
            public UInt16 cityVolume;
         
        }

        public struct City
        {
            public UInt16 cityIndex;
            public string cityName;
            public UInt32 cityPeopleNumber;
            public byte cityStars;
            public byte cityLever;
            public UInt64 cityValue;
            public bool cityOpenStatus;

        }

        public struct Garage
        {
            public UInt16 carIndex;
            public string carName;
            public byte carPeopleVolume;
            public UInt16 carSpeed;
            public UInt16 carPower;
            public UInt16 carWeight;
            public UInt16 carDepartureCityIndex;
            public string carDepartureCityName;
            public DateTime carDepartureTime;
            public UInt16 carArrivalCityIndex;
            public string carArrivalCityName;
            public DateTime carArrivalTime;
            public bool carstatus;
            public UInt32 carTotalFare;
            public UInt32 carCost;

        }

        public struct CityToCity
        {
            public int distance;
            public int fare;

        }

      
    }
}
