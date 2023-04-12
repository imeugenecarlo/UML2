using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{
    public class UserDialog
    {
        MenuCatalog _menucatalog;

        public Pizza pizza { get; set; }

        public UserDialog(MenuCatalog menucatalog)
        {
            _menucatalog = menucatalog;
        }

        Pizza GetNewPizza() 
        {
            Pizza Pizzaitem = new Pizza();
            Console.Clear();
            Console.WriteLine("----------------");
            Console.WriteLine("|Creating Pizza|");
            Console.WriteLine("----------------");

            Console.WriteLine();
            Console.WriteLine("Enter name: ");
            Pizzaitem.Name = Console.ReadLine();

            string input = "";
            Console.WriteLine("Enter price: ");
        
            try
            {
                input = Console.ReadLine();
                Pizzaitem.Price = Int32.Parse(input);
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse '{input}' - Message: {e.Message}");
                throw;
            }

            return Pizzaitem;
        }

        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("Mama's Pizzabar Menu");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Options");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.WriteLine("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try 
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException) 
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new Pizza",
                "2. Print menu",
                "3. Delete a Pizza",
                "4. Edit a Pizza",
                "5. Search a Pizza"

            };
            while (proceed) 
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;

                    case 1:
                        try 
                        {
                            Pizza pizza = GetNewPizza();
                            _menucatalog.Create(pizza);
                            Console.WriteLine($"You created{pizza}");
                        }
                        catch (Exception) 
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 2:
                        _menucatalog.PrintMenu();
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 3:
                        
                        
                        Console.WriteLine($"You selected : {mainMenulist[MenuChoice]}");
                        Console.WriteLine("Press the correpsonded key to delete the pizza from the menu");
                        Console.WriteLine();
                        _menucatalog.PrintMenu();
                        Console.WriteLine();
                        try
                        {
                            string input = Console.ReadKey().KeyChar.ToString();
                            int result = Int32.Parse(input);

                            _menucatalog.Delete(result);
                            Console.WriteLine($"Succesfully deleted Pizza nr:{result}");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }

                        catch (Exception)
                        {
                            Console.WriteLine($"Pizza Doesn't exist");
                        }
                        Console.WriteLine($"Press any key to continue");
                        Console.ReadKey();
                        
                        break;

                    case 4:
                        

                        Console.WriteLine($"You selected :{mainMenulist[MenuChoice]}");
                        _menucatalog.PrintMenu();
                        Console.WriteLine();
                        Console.WriteLine("Press the corresponded key to edit the pizza from the menu");

                        try 
                        { 
                            string press = Console.ReadKey().KeyChar.ToString();
                            int pressresults = Int32.Parse(press);
                            Console.WriteLine();
                            Pizza foundpizza = _menucatalog.Read(pressresults);
                            if (foundpizza == null)
                            {
                                Console.WriteLine($"Pizza does not exist");
                                Console.WriteLine("Press enter to return");
                                Console.ReadLine();

                            }
                            else
                            {
                                Console.WriteLine($"You are editing nr.{pressresults}");
                                Console.WriteLine("Now change the price for the pizza");
                                Console.WriteLine();

                                string pressedkey = Console.ReadLine();
                                int results = Int32.Parse(pressedkey);


                                Console.WriteLine($"Updating the price for {foundpizza.Name} #{foundpizza.Number}");
                                foundpizza.Name += " (Updated)";
                                _menucatalog.Update(foundpizza, results);
                                Console.ReadLine();
                            }
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("Can't edit pizza");
                            Console.WriteLine("Press any key to return to menu");
                            Console.ReadKey();
                            
                        }
                        break;

                    case 5:


                        Console.WriteLine($"You selected : {mainMenulist[MenuChoice]}");
                        _menucatalog.PrintMenu();
                        Console.WriteLine();
                 
                        try
                        {
                            Console.WriteLine("Input your search Criteria");
                            Console.WriteLine();
                            var SearchCriteria = Console.ReadLine();

                            Console.WriteLine($"Finding Pizza with the Criteria:{SearchCriteria}");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();

                            Pizza foundPizza = _menucatalog.SearchPizza(SearchCriteria);
                            if (foundPizza == null)
                            {
                                Console.WriteLine($"Cant find a pizza with: ||{SearchCriteria}|| as search criteria");
                                Console.WriteLine("Press enter to return to menu");
                                Console.ReadLine( );
                            }
                            else
                            {
                                Console.WriteLine($"We found results: {foundPizza}");

                                Console.WriteLine("Press enter to return to menu");
                                Console.ReadLine();
                            }
                        }

                        catch (Exception )
                        {
                            Console.WriteLine("Can't Find the pizza");
                            Console.WriteLine("Press any key to return to menu");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    
                }       
            }
        }
    }
}
