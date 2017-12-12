using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
    public class CalcController
    {
        private readonly ICalcService _calcService;

        public CalcController(ICalcService calcService)
        {
            _calcService = calcService;
        }

        public double calcDollar(double euro)
        {
            return _calcService.calcEuro2Dollar(euro);
        }

    }
}
