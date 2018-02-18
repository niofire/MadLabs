using System.Collections.Generic;

namespace MadLabs.Hub.ViewModels
{
    public class MarkdownViewModel
    {
        public string Content { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
