using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILog _logger;

        public HomeController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;

            _logger = LogManager.GetLogger("HomeController");
        }

        public async Task<IActionResult> Index()
        {
            _logger.Debug("Session list requested.");
            var sessionList = await _sessionRepository.ListAsync();
            _logger.Info($"Session list contains {sessionList.Count} items.");

            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });

            return View(model);
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.Warn("Bad reuest: some models are invalid or haven't been valdated yet.");
                return BadRequest(ModelState);
            }
            else
            {
                _logger.Debug("Adding of new session started.");
                await _sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                });
                _logger.Debug($"Session {model.SessionName} added.");
            }

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
