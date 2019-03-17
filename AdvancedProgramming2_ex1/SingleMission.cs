using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private const string MISSION_TYPE_NAME = "Single";

        public delegate double CalcFunc(double value);

        private readonly Func<double, double> func;

        public event EventHandler<double> OnCalculate;

        public string Name { get; private set; }
        public string Type
        {
            
            get { return SingleMission.MISSION_TYPE_NAME; }
        }

        public SingleMission(Func<double, double> function, string name)
        {
            this.func = function;
            this.Name = name;
        }

        public double Calculate(double value)
        {
            this.OnCalculate?.Invoke(this, value);

            return this.func(value);
        }
    }
}
