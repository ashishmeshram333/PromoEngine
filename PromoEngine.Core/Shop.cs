using System;
using System.Collections.Generic;

namespace PromoEngine.Core
{
    public class Shop
    {
        List<Item> catalogue = new List<Item>();
        List<Promotion> promotions = new List<Promotion>(); 

        public Shop()
        {
            this.SeedCatalogue();
            this.SeedPromotions();
        }

        public int Checkout(List<CartItem> cart)
        {
            int finalAmount = 0;
            List<char> checkedout = new List<char>();

            foreach (CartItem item in cart)
            {
                int unitPrice = this.catalogue.Find(c => c.SKU == item.SKU).UnitPrice;
                Promotion promo = this.promotions.Find(p => p.SKU == item.SKU);

                if (promo.IsCombo)
                {
                    CartItem otherItemInCombo = cart.Find(i => i.SKU == promo.SKU2);
                    if (otherItemInCombo != null)
                    {
                        if (!checkedout.Contains(item.SKU))
                        {
                            finalAmount += promo.DiscountedPrice;
                            checkedout.Add(otherItemInCombo.SKU);
                        }
                    }
                    else
                    {
                        finalAmount += item.Quantity * unitPrice;
                    }
                }
                else
                {
                    if (promo.QuantityForDiscount > item.Quantity)
                    {
                        finalAmount += item.Quantity * unitPrice;
                    }
                    else
                    {
                        finalAmount += (item.Quantity % promo.QuantityForDiscount) * unitPrice;
                        finalAmount += (item.Quantity / promo.QuantityForDiscount) * promo.DiscountedPrice;
                    }
                }
            }
            return finalAmount;
        }


        public void SeedCatalogue()
        {
            catalogue.Add(new Item { SKU = 'A', UnitPrice = 50 });
            catalogue.Add(new Item { SKU = 'B', UnitPrice = 30 });
            catalogue.Add(new Item { SKU = 'C', UnitPrice = 20 });
            catalogue.Add(new Item { SKU = 'D', UnitPrice = 15 });
        }

        public void SeedPromotions()
        {
            promotions.Add(new Promotion { SKU = 'A', IsCombo = false, QuantityForDiscount = 3, DiscountedPrice = 130, IsActive = true });
            promotions.Add(new Promotion { SKU = 'B', IsCombo = false, QuantityForDiscount = 2, DiscountedPrice = 45, IsActive = true });
            promotions.Add(new Promotion { SKU = 'C', IsCombo = true, DiscountedPrice = 30, SKU2 = 'D', IsActive = true });
            promotions.Add(new Promotion { SKU = 'D', IsCombo = true, DiscountedPrice = 30, SKU2 = 'C', IsActive = true });
        }

    }

    public class Item
    {
        public char SKU { get; set; }
        public int UnitPrice { get; set; }
    }

    public class Promotion
    {
        public char SKU { get; set; }
        public bool IsCombo { get; set; }
        public int QuantityForDiscount { get; set; }
        public int DiscountedPrice { get; set; }
        public char SKU2 { get; set; }
        public bool IsActive { get; set; }
    }

    public class CartItem
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
    }
}
