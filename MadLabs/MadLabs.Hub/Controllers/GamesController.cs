using MadLabs.Hub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MadLabs.Hub.Controllers
{
    public class GamesController : Controller
    {

        private List<GameMetadataViewModel> _games = new List<GameMetadataViewModel>
        {
            new GameMetadataViewModel(){
                Title="Pong",
                BannerImageSrc="images/games/pong-banner.png",
                Description="Online/Offline 2 player Pong game. Classic and powerups mode available.",
                Url = "",
            }
        };
        
        public IActionResult Index()
        {
            return View(_games);
        }

        public IActionResult Play(int gameId)
        {
            return View(_games[gameId]);
        }
    }
}