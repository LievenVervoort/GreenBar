using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GreenBar
    {
        IList<Item> Items;
        public GreenBar(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name.Contains("Old Camembert") || item.Name.Contains("VIP passes"))
                {
                    if(item.SellIn != 0)
                    {
                        ReduceSellIn(item);
                        IncreaseQuality(item);
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                    
                }
                else
                {
                    if (!item.Name.Contains("Thunderfury"))
                    {
                        ReduceSellIn(item);
                        ReduceQuality(item);
                    }
                } 
            }
        }


        //splitted off the logic to increase and decrease the sellin and quality parameters makes the code easier to digest
        private void ReduceSellIn(Item item)
        {
            if (item.SellIn > 0)
            {
                item.SellIn--;
            }
            
        }

        private void ReduceQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if ((item.SellIn == 0 && item.Quality >=2) || item.Name.Contains("Conjured"))
                    item.Quality -= 2;
                else
                    item.Quality--;
            }
        }
        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                if (item.SellIn > 10)
                {
                    item.Quality++;
                }
                else
                {
                    if (item.SellIn <= 10 && item.SellIn > 5)
                    {
                        item.Quality += 2;
                    }
                    else
                    {
                        item.Quality += 3;
                    }
                }
            }
            else
            {
                item.Quality = 50;
            }
        }
    }
}

