using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzMVC.Web.Models
{
    public class Number
    {
        public DayOfWeek DayToday { get; set; }
        public int NumberEntered { get; set; }
        public List<int> MyListOfNumbers // class property allows access to myListOfNumbers private field (encapsulation)
        {
            get
            {
                return myListOfNumbers;
            }
            set
            {
                myListOfNumbers = value;
            }
        }
        //public string ErrorMessage { get; set; }
        public Number()
        {
            DayToday = DateTime.Today.DayOfWeek;
            NumberEntered = 0;
            MyListOfNumbers = new List<int>();
            //ErrorMessage = "";
        }

        public void AddNewNumberToMyListOfNumbers(int newnumber)
        {
            MyListOfNumbers.Add(newnumber);
        }

        private List<int> myListOfNumbers; // private field
    }
}


