using System.Collections.Generic;

namespace TechartMap_back.DAL.Models
{ 
    public class PlaceResponse
    {
        public int Number;
        public bool IsFree;
        public string PlaceType;

        public PlaceResponse(int number, bool isFree, string placeType)
        {
            this.Number = number;
            this.IsFree = isFree;
            this.PlaceType = placeType;
        }
    }
}