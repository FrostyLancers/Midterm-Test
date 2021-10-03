using System;
using System.Collections.Generic;

namespace _3.__Improve_the_Code
{
    class Program
    {
        class FlowerStore
        {
            public List<string> flowerList = new List<string>();
            List<string> cart = new List<string>();
            
            public FlowerStore()
            {
                flowerList.Add("Rose");
                flowerList.Add("Lotus");
            }
            
            public void addToCart(string name)
            {
                cart.Add(name);
            }

            public void showCart()
            {
                if (cart.Count == 0)
                {
                    Console.WriteLine("Cart is empty");
                }
                else
                {
                    Console.WriteLine("My Cart: ");
                    foreach (string i in cart)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }       
        
        static void Main(string[] args)
        {
            string decide = "y";
            FlowerStore flowerStore = new FlowerStore();

            do
            {
                SelectFlowerYouWannaBuy(flowerStore);

                decide = ExitOrNot(flowerStore, decide);

            } while (decide != "exit");
        }
        
        static void SelectFlowerHeadMenu()
        {
            Console.WriteLine("Select number for buy flower :");
        }
        
        static void SelectFlowerYouWannaBuy(FlowerStore flowerStore)
        {
            SelectFlowerHeadMenu();

            foreach (string flower in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(flower) + 1) + " ");
                Console.WriteLine(flower);
            }
            string selectFlower = SelectTheFlower();
            AddFlowerToCart(flowerStore, selectFlower);
        }        
        
        static string SelectTheFlower()
        {
            return Console.ReadLine();
        }
       
        static void AddFlowerToCart(FlowerStore flowerStore, string selectFlower)
        {
            switch (selectFlower)
            {
                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;
                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;
                default:
                    Console.WriteLine("Not Added to cart. Cannot find selected number of flower");
                    break;
            }

            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
        }
       
        static string ExitOrNot(FlowerStore flowerStore, string Decide)
        {
            Decide = WannaExitYet();
            if (Decide == "exit")
            {
                //Console.WriteLine("Current my cart: ");
                flowerStore.showCart();
            }
            return Decide;
        }

        static string WannaExitYet()
        {
            return Console.ReadLine();
        }
    }
}
