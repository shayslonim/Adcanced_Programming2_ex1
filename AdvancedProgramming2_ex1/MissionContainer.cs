using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        //Using an IDictionary to map each string to a delegate
        private IDictionary<string, Func<double, double>> funcsMap;

        /// <summary>
        /// The constructor of the FunctionsContainer.
        /// Sets the funcsMap to be a new Dictionary.
        /// </summary>
        public FunctionsContainer()
        {
            this.funcsMap = new Dictionary<string, Func<double, double>>();
        }
        /// <summary>
        /// Map between a string and a double-to-double function
        /// </summary>
        /// <param name="funcName">The chosen name for the function</param>
        /// <returns>If there is a mapping - the matching funtion is returned. Otherwise, the Id function is returned.</returns>
        public Func<double, double> this[string funcName]
        {
            
            get
            {
                if (funcsMap.ContainsKey(funcName))
                {
                    return this.funcsMap[funcName];
                }
                else
                {

                    //The function does not exist, return the Id function, and map between this name and the Id function.
                    Func<double,double> IdFunction =  (value => value);
                    this.funcsMap[funcName] = IdFunction;
                    return IdFunction;
                }
            }
            set
            {
                this.funcsMap[funcName] = value;
            }
        }
        /// <summary>
        /// Gives the collection of all the functions' names.
        /// </summary>
        /// <returns>A list of all the names of the functions</returns>
        public ICollection<string> getAllMissions()
        {
            return this.funcsMap.Keys;
        }
    }
}
