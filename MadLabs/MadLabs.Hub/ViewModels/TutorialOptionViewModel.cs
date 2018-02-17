using System.Collections.Generic;

namespace MadLabs.Hub.ViewModels
{
    public class TutorialOptionViewModel
    {
        public string Id { get; set; }

        public List<TutorialViewModel> Tutorials { get; set; }
    }
}
