using MadLabs.Hub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MadLabs.Hub.Controllers
{
    public class TutorialsController : Controller
    {
        public IActionResult Index()
        {
            return View(
                new List<TutorialOptionViewModel>()
                {
                    new TutorialOptionViewModel(){
                        Id ="aspnetcore",
                        Tutorials = new List<TutorialViewModel>{
                                new TutorialViewModel{
                                    Summary="Hello, world!"
                                }
                            }
                    },
                    new TutorialOptionViewModel(){
                        Id="vsts",
                        Tutorials = new List<TutorialViewModel>{
                            new TutorialViewModel{
                                Summary = "Hello, some other world!"
                            }
                    }
                    }
                }
                );
        }
    }
}