using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class CalcService : ICalcService
    {
        public double calcEuro2Dollar(double euro) => euro * 1.17;
    }
}
