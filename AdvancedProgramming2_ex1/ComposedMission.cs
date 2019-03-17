using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
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

        public ComposedMission(string name)
        {
            this.funcsHolder = new List<Func<double, double>>();
            this.Name = name;
        }
        public ComposedMission Add(Func<double, double> function)
        {
            this.funcsHolder.Add(function);
            return this;
        }

        public double Calculate(double value)
        {
            //if there are functions in the funcsHodler
            if (funcsHolder.Count() > 0)
            {
                //calculate the value
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
