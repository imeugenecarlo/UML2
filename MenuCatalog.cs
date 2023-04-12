using System;
using System.Collections.Generic;
namespace UML2
{
    public class MenuCatalog
    {

         public List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }
        public void Delete(int number)
        {
            foreach (var p in _pizzas)
            {
                if (number == p.Number)
                {
                 _pizzas.Remove(p);
                  break;
                }
                
            }
            //Pizza p = SearchPizza(number) ;
            
        }
        public void PrintMenu()
        {
            foreach (var p in _pizzas)
            {
                Console.WriteLine(p);
            }

        }
        public Pizza Read(int number)
        {
            foreach(var p in _pizzas)
            {
                if (number == p.Number)
                {
                    return p;
                }
            }
            return null;
        }

        public Pizza? SearchPizza(string Criteria)
        {
            foreach (var p in _pizzas)
            {
                if (Criteria == p.Name)
                { 
                return p;
                }
            }
            return null;
        }

        public void Update(Pizza p , int price) 
        {
        p.Price = price;
        }
    }
}