using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebLab12.Models;

namespace WebLab12.Services
{
    public class CalcService : ICalcService
    {

        public string Calculate(CalcActionModel model)
        {
            return Calculate(model.firstNum, model.secondNum, model.oper);
        }

        public string Calculate(int firstNum, int secondNum, string oper)
        {
            switch (oper)
            {
                case "+":
                    return Addition(firstNum, secondNum);
                case "-":
                    return Subtraction(firstNum, secondNum);
                case "*":
                    return Multiplication(firstNum, secondNum);
                case "/":
                    return Division(firstNum, secondNum);
                default:
                    return "Unindetified operator";
            }
        }

        public string Addition(int a, int b)
        {
            return (a+b).ToString();
        }

        public string Division(int a, int b)
        {
            return (b == 0) ? "Divide by zero!" : (a / b).ToString();
        }

        public string Multiplication(int a, int b)
        {
            return (a * b).ToString();
        }

        public string Subtraction(int a, int b)
        {
            return (a - b).ToString();
        }

        
    }
}
