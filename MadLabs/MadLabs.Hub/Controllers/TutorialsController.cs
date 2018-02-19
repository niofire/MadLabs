using MadLabs.Hub.DataProviders;
using MadLabs.Hub.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using MadLabs.Hub.Extensions;
using System.Linq;

namespace MadLabs.Hub.Controllers
{
    public class TutorialsController : Controller
    {
        /// <summary>
        /// The hosting environment service which contains information about the env/directories where the website is running.
        /// </summary>
        private readonly IHostingEnvironment _appEnvironment;

        /// <summary>
        /// The root directrory of the tutorial content folder located in the wwwroot directory.
        /// </summary>
        private readonly string _tutorialRoot;

        /// <summary>
        /// The markdown data provider, used to get markdown content & metadata.
        /// </summary>
        private readonly MarkdownDataProvider _mdProvider;

        /// <summary>
        /// The tutorial metadata, containing information such as filename, author and summary.
        /// </summary>
        private Dictionary<string, TutorialSectionViewModel> _tutorialMetadata = new Dictionary<string, TutorialSectionViewModel>();

        public TutorialsController(IHostingEnvironment appEnvironment)
        {
            _mdProvider = new MarkdownDataProvider();
            _appEnvironment = appEnvironment;
            _tutorialRoot = Path.Combine(appEnvironment.WebRootPath, "markdown/Tutorials");

        }

        public IActionResult Index()
        {
            if (_tutorialMetadata.Count == 0)
                LoadTutorialMetadata();

            return View(_tutorialMetadata.Values.ToList());
        }

        /// <summary>
        /// Gets the html & metadata of a md file.
        /// </summary>
        /// <param name="section">The tutorial section which correlates to one of the directories below wwwroot/Tutorials. Eg. "aspnetcore".</param>
        /// <param name="filename">The markdown file to convert including the file extension. Eg. "Create-Maintenance-Page.md"</param>
        /// <returns></returns>
        public IActionResult GetTutorial(string section, string filename)
        {
            var tutorialFilepath = Path.Combine(new string[] { _tutorialRoot, section, filename });

            return View(_mdProvider.GetMarkdownViewModel(tutorialFilepath));
        }

        /// <summary>
        /// Caches the tutorial metadata in order to limit IO impact on performance.
        /// </summary>
        private void LoadTutorialMetadata()
        {
            _tutorialMetadata = new Dictionary<string, TutorialSectionViewModel>();

            foreach (var dir in Directory.GetDirectories(_tutorialRoot))
            {
                var option = new TutorialSectionViewModel();
                option.Section = Path.GetFileName(dir);

                //Fetch all available md in the section's directory
                foreach (var file in Directory.GetFiles(dir))
                {
                    option.TutorialsMetadata.Add(_mdProvider.GetMetadata(file));
                }

                //
                option.TutorialsMetadata.Sort(
                    (x, y) =>
                    {
                        if (int.TryParse(x.GetValue("order", "-1"), out int xOrder))
                            return 1;
                        if (int.TryParse(y.GetValue("order", "-1"), out int yOrder))
                            return -1;

                        return xOrder - yOrder;
                    });

                if (option.TutorialsMetadata.Count != 0
                    && !_tutorialMetadata.ContainsKey(option.Section))
                    _tutorialMetadata.Add(option.Section, option);
            }
        }
    }
}