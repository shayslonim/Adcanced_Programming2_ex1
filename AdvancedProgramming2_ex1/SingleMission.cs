using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /// <summary>
    /// The SingleMission class can calculate the value of a single function. 
    /// The function is a delegate of double-to-double
    /// </summary>
    public class SingleMission : IMission
    {
        //This is the type of the single mission
        private const string MISSION_TYPE_NAME = "Single";

       //Func<double,double> is a delegate of type double and return type double
        private Func<double, double> func;

        public event EventHandler<double> OnCalculate;

        public string Name { get; private set; }
        public string Type
        {
            get { return SingleMission.MISSION_TYPE_NAME; }
        }

        //Constructor
        public SingleMission(Func<double, double> function, string name)
        {
            this.func = function;
            this.Name = name;
        }
        /// <summary>
        /// Calculate the value of the function and invoke the OnCalculate event
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the result value of the function</returns>
        public double Calculate(double value)
        {
            double result = this.func(value);
            this.OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
