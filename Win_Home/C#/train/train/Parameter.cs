using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Setting = train.Properties.Settings;

namespace train
{
    public class Parameter
    {
        public struct Custom
        {
            public UInt16 level;
            public UInt64 levelValue;
            public UInt64 cash;
            public UInt64 coin;
            public UInt16 cityVolume;
            public UInt16 garageVolume;
            public UInt16 carVolume;
            public DateTime closeTime;
        }

        public struct City
        {
            public UInt16 cityIndex;
            public string cityName;
            public byte cityStars;
            public byte cityLever;
            public UInt64 cityValue;
            public Int32 stationVolume;
            public Int32 strandedNumber;
        }

        public struct Garage
        {
            public string carName;
            public byte carPeopleVolume;
            public byte carCargoVolume;
            public UInt16 carSpeed;
            public UInt16 carPower;
            public UInt16 carWeight;
            public UInt64 carValue;
        }

        public struct Car
        {
            public string carName;
            public byte carPeopleVolume;
            public byte carCargoVolume;
            public UInt16 carSpeed;
            public UInt16 carPower;
            public UInt16 carWeight;
            public UInt64 carValue;
            public UInt16 carDepartureCityIndex;
            public string carDepartureCityName;
            public DateTime carDepartureTime;
            public UInt16 carArrivalCityIndex;
            public string carArrivalCityName;
            public DateTime carArrivalTime;
            public bool carstatus;
            public UInt32 carTotalCash;
            public UInt32 carTotalCoin;
            public UInt32 carCost;
        }

        public struct CityToCity
        {
            public int distance;
            public int cashfare;
            public int people;
            public int cargo;
        }
    }
}
