using Quartet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartet2
{
    internal class hand
    {
        List<CarCard> carCards;
        public CarCard topCard() {  return carCards[0]; }

        public void add(CarCard card) { carCards.Add(card); }
        public void remove(CarCard card) { carCards.Remove(card); }

    }
}
