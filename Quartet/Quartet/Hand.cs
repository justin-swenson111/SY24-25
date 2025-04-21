using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartet
{
    internal class Hand
    {
        List<CarCard> carCards = new List<CarCard>();
        public CarCard topCard()
        {
            if (carCards.Count == 0)
            {
                return null;
            }
            return carCards[0];
        }
        public void Add(CarCard carCard)
        {
            carCards.Add(carCard);
        }
    }
}
