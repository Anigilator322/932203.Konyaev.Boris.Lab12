using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebLab12.Models;
using WebLab12.Services;

namespace WebLab12.Controllers
{
    public class CalcController : Controller
    {
        ICalcService _calcService;

        public CalcController(ICalcService calcService)
        {
            _calcService = calcService;
        }

        private string ParseAndCalculate()
        {
            try
            {
                int firstNumber = int.Parse(Request.Form["firstNum"]);
                int secondNumber = int.Parse(Request.Form["secondNum"]);
                string operation = Request.Form["oper"];
                return _calcService.Calculate(firstNumber, secondNumber, operation);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IActionResult Manual()
        {
            if (Request.Method == "GET")
            {
                return View("CalcInputForm");
            }
            else
            {
                ViewData["result"] = ParseAndCalculate();
                return View("CalcResult");
            }
        }

        [HttpGet, ActionName("ManualSeparate")]
        public IActionResult ManualSeparateGet()
        {
            return View("CalcInputForm");
        }

        [HttpPost, ActionName("ManualSeparate")]
        public IActionResult ManualSeparatePost()
        {
            ViewData["result"] = ParseAndCalculate();
            return View("CalcResult");
        }

        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("CalcInputForm");
        }

        [HttpPost]
        public IActionResult ModelBindingSeparate(int firstNum, int secondNum, string oper)
        {

            ViewData["result"] = _calcService.Calculate(firstNum, secondNum, oper);
            return View("CalcResult");
        }

        [HttpGet]
        public IActionResult ModelBinding()
        {
            return View("CalcInputForm");
        }

        [HttpPost]
        public IActionResult ModelBinding(CalcActionModel expressionModel)
        {
            ViewData["result"] = _calcService.Calculate(expressionModel);
            return View("CalcResult");
        }

    }
}
