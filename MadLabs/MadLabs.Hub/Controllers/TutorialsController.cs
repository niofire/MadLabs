using MadLabs.Hub.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace MadLabs.Hub.Controllers
{
    public class TutorialsController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly string _tutorialRoot;

        public TutorialsController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _tutorialRoot = Path.Combine(appEnvironment.WebRootPath, "markdown/Tutorials");
        }

        public IActionResult Index()
        {
            //get directory names
            List<TutorialOptionViewModel> sections = new List<TutorialOptionViewModel>();

            foreach(var dir in Directory.GetDirectories(_tutorialRoot))
            {
                var option = new TutorialOptionViewModel();
                option.Section = Path.GetFileName(dir);

                foreach (var file in Directory.GetFiles(dir))
                {
                    option.Tutorials.Add(new TutorialViewModel()
                    {
                        Summary = "template",
                        Filename = Path.GetFileName(file)
                    });
                }

                if (option.Tutorials.Count != 0)
                    sections.Add(option);
            }

            return View(sections);
            /*
            return View(
                new List<TutorialOptionViewModel>()
                {

                    new TutorialOptionViewModel(){
                        Id ="aspnetcore",
                        Tutorials = new List<TutorialViewModel>{
                                new TutorialViewModel{
                                    Summary="Hello, world!",
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
                );*/
        }

        public IActionResult GetTutorial(string section, string filename)
        {
            var filepath = Path.Combine(new string[] { _appEnvironment.WebRootPath,"markdown", "Tutorials", section, filename });
            using (StreamReader sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read)))
            using(StringWriter writer = new StringWriter())
            {
                CommonMark.CommonMarkConverter.Convert(sr, writer);
                return View("Views/Tutorials/TutorialTemplate.cshtml",writer.ToString());
            }
        }
    }
}