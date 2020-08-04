namespace TechartMap_back.DAL.Models
{
    public class PlaceResponse
    {
        public bool IsFree;
        public int Number;
        public string PlaceType;

        public PlaceResponse(int number, bool isFree, string placeType)
        {
            Number = number;
            IsFree = isFree;
            PlaceType = placeType;
        }
    }
}