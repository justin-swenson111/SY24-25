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
        public List<CarCard> carCards = new List<CarCard>();
        public int number;

        public hand(int num) { 
            number = num;
        }
        public CarCard topCard() {

            if (carCards.Count != 0)
            {
                return carCards[0];

            }
            else
            {
                return null;
            }
        }
        public void next()
        {
            if (carCards.Count != 0)
            {
                CarCard temp = carCards[0];
                for (int i = 0; i < carCards.Count; i++)
                {
                    if (i != carCards.Count - 1)
                    {
                        carCards[i] = carCards[i + 1];
                    }
                    else
                    {
                        carCards[i] = temp;
                    }
                }
            }

        }

        public void add(CarCard card) { carCards.Add(card); }
        public void remove(CarCard card) { carCards.Remove(card); }

    }
}
