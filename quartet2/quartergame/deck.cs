
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartet
{
    internal class Deck
    {
        List<CarCard> carCards;
        public Deck(List<CarCard> cards)
        {
            this.carCards = cards;
        }
        public void Shuffle()
        {
            //int n = 0;
            //CarCard temp = null;
            //Random rnd = new Random();

            //for (int i = 0; i < carCards.Count; i++)
            //{
            //temp = carCards[i];
            //n = rnd.Next(carCards.Count);
            //carCards[i] = carCards[n];
            //}
            Random rng = new Random();
            int n = carCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                CarCard value = carCards[k];
                carCards[k] = carCards[n];
                carCards[n] = value;
            }
        }
        public CarCard GetCard(int index)
        {
            CarCard c = carCards[index];
            carCards.RemoveAt(index);
            return c;

        }
        public int Count()
        {
            return carCards.Count;
        }
        public override string ToString()
        {
            string retVal = "Deck:\n";
            foreach (CarCard card in carCards)
            {
                retVal += card.ToString();
            }
            return retVal;
        }
    }
}
