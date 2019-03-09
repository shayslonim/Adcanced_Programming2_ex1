using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        public delegate double CalcFunc(double value);

        private readonly Func<double, double> func;
        public string Name { get; private set; }
        public string Type { get; private set; }

        public SingleMission(Func<double,double> function, string name)
        {
            this.func = function;
            this.Name = name;
            this.Type = function.ToString();
        }

        event EventHandler<double> IMission.OnCalculate
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public double Calculate(double value)
        {
            return this.func(value);
        }
    }
}
