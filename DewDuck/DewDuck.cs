using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace DewCore
{
    public class DewDuck
    {
        /// <summary>
        /// Check if the passed classes are compatibles, so they are ducks
        /// </summary>
        /// <param name="duck1"></param>
        /// <param name="duck2"></param>
        /// <returns></returns>
        public static bool AreDucks(object duck1, object duck2)
        {
            var firstDuck = duck1.GetType();
            var secondDuck = duck2.GetType();
            var methodsDuck1 = firstDuck.GetRuntimeMethods();
            var methodsDuck2 = secondDuck.GetRuntimeMethods();
            var iterator = methodsDuck1.Count() >= methodsDuck2.Count() ? methodsDuck1 : methodsDuck2;
            var comparator = methodsDuck1.Count() < methodsDuck2.Count() ? methodsDuck1 : methodsDuck2;
            foreach (var item in iterator)
            {
                if (comparator.FirstOrDefault((x) => { return x.ToString() == item.ToString(); }) == null)
                {
                    return false;
                }
                
            }
            return true;
        }
        /// <summary>
        /// Return missed methods by duck1 to be a duck2
        /// </summary>
        /// <param name="duck1"></param>
        /// <param name="duck2"></param>
        /// <returns></returns>
        public static List<string> WhyNotDucks(object duck1, object duck2)
        {
            List<string> result = new List<string>();
            var firstDuck = duck1.GetType();
            var secondDuck = duck2.GetType();
            var methodsDuck1 = firstDuck.GetRuntimeMethods();
            var methodsDuck2 = secondDuck.GetRuntimeMethods();
            var iterator = methodsDuck1.Count() >= methodsDuck2.Count() ? methodsDuck1 : methodsDuck2;
            var comparator = methodsDuck1.Count() < methodsDuck2.Count() ? methodsDuck1 : methodsDuck2;
            foreach (var item in iterator)
            {
                if (comparator.FirstOrDefault((x) => { return x.ToString() == item.ToString(); }) == null)
                {
                    result.Add(item.ToString());
                }
            }
            return result;
        }
    }
}
