using System.Collections.Generic;

namespace MadLabs.Hub.ViewModels
{
    public class TutorialOptionViewModel
    {
        public string Section { get; set; }

        public List<TutorialViewModel> Tutorials { get; set; } = new List<TutorialViewModel>();
    }
}
