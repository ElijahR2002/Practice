namespace CSharpProject4
{
     internal class Program
    {
        static void Main(string[] args)
        {
            MenuSystem MyMenu = new MenuSystem();
            MyMenu.Choice();
            MyMenu.Tip();
            MyMenu.Payment();
            MyMenu.Receipt();
        }

        public class MenuSystem
        {

            string[] appName = { "Onion Blossom", "Cheese Dip", "Fried Pickles", "Salad" };
            double[] appPrice = { 7.99, 5.99, 6.99, 4.99 };

            string[] drinkName = { "Water", "Dr. Pepper", "Sprite", "Pepsi", "Mt. Dew" };
            double[] drinkPrice = { 0.00, 2.49, 2.49, 2.49, 2.49 };

            string[] entName = { "Hamburger", "Sirloin", "Shrimp", "Catfish" };
            double[] entPrice = { 10.99, 14.99, 11.99, 15.99 };

            string[] dessertName = { "Apple Pie", "Cheesecake", "Banana Split", "Secret Sweet" };
            double[] dessertPrice = { 4.99, 4.99, 6.99, 42.99 };

            int choice = 0, itemCounter = 0, priceCounter = 0, quantityCounter = 0, TotalCounter = 0;
            double subtotal = 0, total, tax, newTotal, payment = 0, change = 0, temp = 0;
            int menuChoice, quantity;
            char checkTip;
            double tipAmt;

            string[] purchaseItem = new string[50];
            double[] purchasePrice = new double[50];
            int[] purchaseQuantity = new int[50];

            public void Choice()
            {
                while (choice != 99)
                {
                    Console.WriteLine("Which Menu items would you like to look at?");
                Console.WriteLine("1. Drinks");
                Console.WriteLine("2. Appetizers");
                Console.WriteLine("3. Entrees");
                Console.WriteLine("4. Desserts");
                Console.WriteLine("Subtotal " + subtotal.ToString("c2"));
                Console.Write("Make your selection here (99 to finish): ");
                choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Drink Menu ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Which drink would you like?");
                        Menu(drinkName, drinkPrice);

                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Appetizer Menu ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Which appetizer would you like?");
                        Menu(appName, appPrice);

                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Entree Menu ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Which entree would you like?");
                        Menu(entName, entPrice);

                    }
                    else if (choice == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Dessert Menu ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Which dessert would you like?");
                        Menu(dessertName, dessertPrice);
                    }
              
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("This wasn't a choice on the menu. I'm Sorry you must restart.");
                        Choice();
                    }
                }
            }
            void Menu(string[] Name, double[] Price)
            {
                for (int i = 0; i < Name.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + Name[i] + "\t" + Price[i].ToString("c2"));
                }
                Console.WriteLine("Subtotal " + subtotal.ToString("c2"));
                Console.Write("Selection: ");
                menuChoice = Convert.ToInt32(Console.ReadLine());
                if (menuChoice > Name.Length || menuChoice < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Not on the menu try again!");
                }
                else
                {
                    Console.Write("Enter how many: ");
                    quantity = Convert.ToInt32(Console.ReadLine());


                    subtotal += Price[menuChoice - 1] * quantity;

                    purchaseItem[itemCounter] = Name[menuChoice - 1];
                    itemCounter++;

                    purchasePrice[priceCounter] = Price[menuChoice - 1];
                    priceCounter++;

                    purchaseQuantity[quantityCounter] = quantity;
                    quantityCounter++;

                    TotalCounter++;

                    Console.Clear();
                }
            }
            public void Tip()
            {
                tax = subtotal * .1;
                total = subtotal + tax;

                Console.Clear();
                Console.WriteLine("Total: " + total.ToString("c2"));
                Console.WriteLine("Would you like to leave a tip? (y or n)");
                Console.Write("Tip?: ");
                checkTip = Convert.ToChar(Console.ReadLine());
                if (checkTip == 'y' || checkTip == 'Y')
                {
                    Console.WriteLine("How much would you like to leave?");
                    Console.WriteLine("Recommended:");
                    Console.Write("15% " + (subtotal * .15).ToString("c2"));
                    Console.Write("\t18% " + (subtotal * .18).ToString("c2"));
                    Console.Write("\t20% " + (subtotal * .20).ToString("c2"));
                    Console.Write("\nTip: ");
                    tipAmt = Convert.ToDouble(Console.ReadLine());
                    if (tipAmt < 0)
                    {
                        tipAmt = 0;
                    }
                    newTotal = total + tipAmt;
                    Console.Clear();
                }
                else if (checkTip == 'n' || checkTip == 'N')
                {
                    tipAmt = 0.00;
                    Console.Clear();
                    Donation();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Okay Funny Guy. Automatic $50 tip added.");
                    tipAmt = 50.00;
                    newTotal = total + tipAmt;

                }


                Console.WriteLine("Total: " + newTotal.ToString("c2"));
            }

            public void Payment()
            {
                Console.Clear();
                while (payment < newTotal)
                {
                    Console.WriteLine("Balance Due: " + (newTotal - payment).ToString("c2"));
                    Console.Write("Enter Payment: ");
                    temp = Convert.ToDouble(Console.ReadLine());
                    payment = payment + temp;
                    Console.Clear();
                }
            }
            public void Receipt()
            {
                change = payment - newTotal;
                Console.Clear();
                Console.WriteLine("Reciept:\n");
                Console.WriteLine("Items Purchased:");

                for (int i = 0; i < TotalCounter; i++)
                {
                    Console.WriteLine(purchaseItem[i] + "\t\t" + purchasePrice[i] + "x " + purchaseQuantity[i]);
                }

                Console.WriteLine("\nYour Total was: " + newTotal.ToString("c2"));
                Console.WriteLine("Paid: " + (change + newTotal).ToString("c2"));
                Console.WriteLine("Your change is: " + change.ToString("c2"));
            }

            public double Donation()
            {
                char donate;
                newTotal = total + tipAmt;
                Console.WriteLine("Your Current Total is: " + newTotal.ToString("c2"));
                Console.WriteLine("\nWould you like to round your money up to donate to our foundation?(y or n)");
                Console.Write("Decision: ");
                donate = Convert.ToChar(Console.ReadLine());
                if (donate == 'y' || donate == 'y')
                {

                    newTotal = Math.Ceiling(newTotal);//Rounds to the higher whole number.
                    return newTotal;

                }
                else if (donate == 'n' || donate == 'N')
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Restart");
                    Donation();
                }
                return newTotal;
            }
        };
    }
}
