//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Collections;

//namespace FizzBuzzMVC.Web.Models
//{
//    public class GameResult
//    {
//        public List<string> StoredResult { get; set; }

//        public GameResult()
//        {
//            StoredResult = new List<string>();
//        }
//        public void GenerateGameResult(Number number)
//        {
//            if (number.DayToday == DayOfWeek.Wednesday)
//            {
//                foreach (var value in number.MyListOfNumbers)
//                {
//                    if ((value % 3) == 0 && (value % 5) == 0)
//                    {
//                        StoredResult.Add("wizz wuzz");
//                    }
//                    else if (value % 3 == 0)
//                    {
//                        StoredResult.Add("wizz");
//                    }
//                    else if (value % 5 == 0)
//                    {
//                        StoredResult.Add("wuzz");
//                    }
//                    else
//                    {
//                        StoredResult.Add(value.ToString());
//                    }
//                }
//            }
//            else
//            {
//                foreach (var value in number.MyListOfNumbers)
//                {
//                    if ((value % 3) == 0 && (value % 5) == 0)
//                    {
//                        StoredResult.Add("fizz buzz");
//                    }
//                    else if ((value % 3 == 0))
//                    {
//                        StoredResult.Add("fizz");
//                    }
//                    else if ((value % 5 == 0))
//                    {
//                        StoredResult.Add("buzz");
//                    }
//                    else
//                    {
//                        StoredResult.Add(value.ToString());
//                    }
//                }
//            }
//        }
//    }
//}