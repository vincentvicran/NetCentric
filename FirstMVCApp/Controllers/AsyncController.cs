using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AsyncController : Controller
    {

        List<string> NameList = new List<string>();
        int counter = 0;
        public IActionResult Index()
        {
            FirstFunctionAsync();
            SecondFunction();
            return View();
        }

        public async Task FirstFunctionAsync()
        {
            await Task.Run(() =>
            {
                for (; counter <= 100; counter++)
                {
                    NameList.Add("first function executed");
                }
            }
            );
           
        }

        public void SecondFunction()
        {
            
                for (; counter <= 100; counter++)
                {
                    NameList.Add("first function executed");
                }
            
        }

      /*public async void SecondFunction()
        {
            await Task.Run(() =>
            {
                for (; counter <= 100; counter++)
                {
                    NameList.Add("first function executed");
                }
            });
        }*/
    }
}
