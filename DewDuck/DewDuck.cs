using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace DewCore
{
    /// <summary>
    /// Dew duck class
    /// </summary>
    public class DewDuck
    {
        /// <summary>
        /// Return the list of methods of a duck
        /// </summary>
        /// <param name="duck"></param>
        /// <returns></returns>
        public static List<string> GetDuckMethodsList(object duck)
        {
            var result = new List<string>();
            foreach (var item in duck.GetType().GetRuntimeMethods())
            {
                result.Add(item.ToString());
            }
            return result;
        }
        /// <summary>
        /// Return true if the passed actions are methods in the passed duck
        /// </summary>
        /// <param name="duck1"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static bool WhatThisDuckShouldDo(object duck1, List<string> actions)
        {
            var firstDuck = duck1.GetType();
            var methodsDuck1 = firstDuck.GetRuntimeMethods();
            foreach (var item in methodsDuck1)
            {
                if (actions.FirstOrDefault((x) => { return x == item.ToString(); }) == null)
                {
                    return false;
                }
            }
            return true;
        }
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
