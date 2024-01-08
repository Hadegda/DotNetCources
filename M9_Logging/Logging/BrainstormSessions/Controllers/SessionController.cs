using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
		private readonly ILog _logger;

		public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;

			_logger = LogManager.GetLogger("SessionController");
		}

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
				_logger.Warn($"Redirected to {nameof(Index)}.");
				return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

			_logger.Debug("Session resuested");
			var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
				_logger.Error($"Session not found. Session Id {id.Value}.");
				return Content("Session not found.");
            }
			_logger.Debug($"Session found {session.Name}");

			var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return View(viewModel);
        }
    }
}
