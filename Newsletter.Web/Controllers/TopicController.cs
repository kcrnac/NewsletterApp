using Newsletter.Service.TopicService;
using Newsletter.Service.UserService;
using System.Web.Mvc;

namespace Newsletter.Web.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private IUserService _userService;
        private ITopicService _topicService;

        public TopicController(IUserService userService, ITopicService topicService)
        {
            this._userService = userService;
            this._topicService = topicService;
        }

        public ActionResult Index()
        {
            var users = _topicService.GetTopics();

            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var topic = _topicService.GetTopic(id);
            
            return View(topic);
        }

        [HttpPost]
        public ActionResult RemoveUser(string id, string userId)
        {
            var result = _topicService.RemoveUser(id, userId);

            return Json(result);
        }
    }
}