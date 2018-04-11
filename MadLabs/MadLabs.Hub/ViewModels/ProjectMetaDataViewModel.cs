using System.Collections.Generic;

namespace MadLabs.Hub.ViewModels
{
    public class ProjectMetaDataViewModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Technologies { get; set; }
        public string ImageSrc { get; set; }
        public string Link { get; set; }
    }
}
