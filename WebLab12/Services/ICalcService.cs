using WebLab12.Models;

namespace WebLab12.Services
{
    public interface ICalcService
    {
        public string Calculate(CalcActionModel model);
        public string Calculate(int firstNum, int secondNum, string oper);
        public string Addition(int a, int b);
        public string Subtraction(int a, int b);
        public string Division(int a, int b);
        public string Multiplication(int a, int b);
    }
}
