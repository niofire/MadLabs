using System.Collections.Generic;

using MetadataStore = System.Collections.Generic.Dictionary<string, string>;
namespace MadLabs.Hub.ViewModels
{
    public class TutorialSectionViewModel
    {
        public string Section { get; set; }

        public List<MetadataStore> TutorialsMetadata { get; set; } = new List<MetadataStore>();
    }
}
