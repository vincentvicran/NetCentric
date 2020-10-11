using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FirstMVCApp.Controllers
{
    public class PolymorphismController : Controller
    {
        public IActionResult Index()
        {
            Calculator cal = new Calculator();
            int thirdAddMethod = cal.Add(155, Convert.ToDecimal(100.5));
            int firstAddMethod = cal.Add(150, 100);
            int secondAddMethod = cal.Add(150, 100, 50);

            return Json(new { firstAdd = firstAddMethod, secondAdd = secondAddMethod, thirdAdd = thirdAddMethod });
        }

        public IActionResult AbstractIndex()
        {
            AbstractCalculator cal = new NormalClass();
            int abstractMethod = cal.Add(150, 100);
            int secondabstractMethod = cal.Adder(150, 100, 50);

            return Json(new { abstractMethodResult = abstractMethod, secondabstractMethodResult = secondabstractMethod});
        }

        public IActionResult Override()
        {
            ScientificCalculator sc = new ScientificCalculator();
            int result = sc.GetDifference(100, 200);
            return Json(result);
        }
    }
    public class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public int Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }
        public int Add(decimal firstNumber, decimal secondNumber)
        {
            return Convert.ToInt32(firstNumber + secondNumber);
        }

    }
    public class GeneralCalculator
    {
        public virtual int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public virtual int GetDifference(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }


    //inheritance from parent class generalcalculator to derived class scienttific calculator
    public class ScientificCalculator : GeneralCalculator
    {
        //method hiding parent class GeneralCalculator to derived class Scientific calculator
        public new int Add(int firstNumber, int secondNumber)
        {
            return Convert.ToInt32(firstNumber + secondNumber);
        }

        //method overriding from parent class GeneralCalculator to derived class Scientific calculator
        public override int GetDifference(int firstNumber, int secondNumber)
        {
            int result;
            if (firstNumber >= secondNumber)
            {
                //use of base keyowrd which helps to reference towards parent class and its methods.
                result = base.GetDifference(firstNumber, secondNumber); 
            }
            else
            {
                result = secondNumber - firstNumber;
            }
            return result;
        }

        

    }
    public abstract class AbstractCalculator
    {
        public abstract int Add(int firstN, int secondN);

        public int Adder(int x, int y, int z)
        {
            return x + y + z;
        }

    }

    public class NormalClass : AbstractCalculator
    {
        public override int Add(int firstN, int secondN)
        {
            return firstN + secondN;
        }
    }
}