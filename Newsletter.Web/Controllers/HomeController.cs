using Newsletter.Service.TopicService;
using Newsletter.Service.UserService;
using System.Web.Mvc;

namespace Newsletter.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private ITopicService _topicService;

        public HomeController(IUserService userService,
            ITopicService topicService)
        {
            _userService = userService;
            _topicService = topicService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Api()
        {
            return View();
        }


    }
}