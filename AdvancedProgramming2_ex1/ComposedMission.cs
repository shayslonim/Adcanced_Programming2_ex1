using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /// <summary>
    /// The ComposedMission class can calculate the value of a composition of functions. 
    /// The calculation is done by the order they were given.
    /// Each function is a delegate of double-to-double
    /// </summary>
    public class ComposedMission : IMission
    {

        //This is the type of the composed mission
        private const string MISSION_TYPE_NAME = "Composed";

        private ICollection<Func<double, double>> funcsHolder;

        public event EventHandler<double> OnCalculate;

        public string Name { get; private set; }
        public string Type
        {
            get { return ComposedMission.MISSION_TYPE_NAME; }
        }

        //Constructor
        public ComposedMission(string name)
        {
            this.funcsHolder = new List<Func<double, double>>();
            this.Name = name;
        }
        /// <summary>
        /// Add a function to the composition. 
        /// </summary>
        /// <param name="function"></param>
        /// <returns>The current object is returned so the Add method could be used multiple times in a row</returns>
        public ComposedMission Add(Func<double, double> function)
        {
            this.funcsHolder.Add(function);
            return this;
        }
        /// <summary>
        ///Calculate the value of the functions composition and invoke the OnCalculate event
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the result value</returns>
        public double Calculate(double value)
        {
            //if there are functions in the funcsHodler
            if (funcsHolder.Count() > 0)
            {
                /*
                 * calculate the value:
                 * The result output of the previous function is the input output of the current one.
                 */
                double result = 0;
                foreach (var function in funcsHolder)
                {
                    result = function(value);
                    value = result;
                }
                this.OnCalculate?.Invoke(this, result);
                return result;
            }
            else
            {
                throw new Exception("No functions to calculate");
            }

        }
    }
}
