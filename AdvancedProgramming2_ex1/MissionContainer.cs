using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        //  public delegate double CalcFunc(double value);
        private Dictionary<string, Func<double, double>> funcsMap;

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
                    throw new Exception("Function not found");
                }
            }
            set
            {
                this.funcsMap[funcName] = value;
            }
        }

        public IEnumerable<string> getAllMissions()
        {
            return this.funcsMap.Keys;
        }
    }
}
