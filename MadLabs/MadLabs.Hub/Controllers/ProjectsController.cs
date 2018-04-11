using MadLabs.Hub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MadLabs.Hub.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<ProjectMetaDataViewModel>(){
                new ProjectMetaDataViewModel()
            {
                Title = "Simple RTC Data Channel",
                Description = " A simple client-side P2P example using WebRTC's RTCPeerConnection and RTCDataChannel.",
                ImageSrc = "SimpleRTCDataChannelExample.jpg",
                Link = "https://github.com/niofire/Simple-RTCDataChannel-Example/wiki/How-it-Works",
                Technologies = new List<string>()
                    {
                        "JavaScript",
                        "Node.js",
                        "WebRTCDataChannel",
                        "WebRTCPeerConnection"
                    }
            }});
        }
    }
}