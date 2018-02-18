using System.Collections.Generic;

namespace MadLabs.Hub.ViewModels
{
    public class TutorialOptionViewModel
    {
        public string Section { get; set; }

        public List<Dictionary<string, string>> TutorialsMetadata { get; set; } = new List<Dictionary<string, string>>();
    }
}
