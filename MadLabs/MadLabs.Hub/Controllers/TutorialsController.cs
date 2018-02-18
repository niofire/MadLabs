using MadLabs.Hub.DataProviders;
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
        private readonly MarkdownDataProvider _mdProvider;

        public TutorialsController(IHostingEnvironment appEnvironment)
        {
            _mdProvider = new MarkdownDataProvider();
            _appEnvironment = appEnvironment;
            _tutorialRoot = Path.Combine(appEnvironment.WebRootPath, "markdown/Tutorials");
        }

        public IActionResult Index()
        {
            List<TutorialOptionViewModel> sections = new List<TutorialOptionViewModel>();

            foreach(var dir in Directory.GetDirectories(_tutorialRoot))
            {
                var option = new TutorialOptionViewModel();
                option.Section = Path.GetFileName(dir);

                foreach (var file in Directory.GetFiles(dir))
                {
                    option.TutorialsMetadata.Add(_mdProvider.GetMetadata(file));
                }

                if (option.TutorialsMetadata.Count != 0)
                    sections.Add(option);
            }

            return View(sections);
        }

        public IActionResult GetTutorial(string section, string filename)
        {
            var tutorialFilepath = Path.Combine(new string[] { _tutorialRoot, section, filename });

            return View(_mdProvider.GetMarkdownViewModel(tutorialFilepath));
        }
    }
}