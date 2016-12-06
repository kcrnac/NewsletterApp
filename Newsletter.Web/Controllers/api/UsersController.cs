using Newsletter.Service.TopicService;
using Newsletter.Service.UserService;
using Newsletter.Web.Helpers;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Newsletter.Web.Controllers.api
{
    [Authorize]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private IUserService _userService;
        private ITopicService _topicService;

        public UsersController(IUserService userService, ITopicService topicService)
        {
            this._userService = userService;
            this._topicService = topicService;
        }

        public HttpResponseMessage Get()
        {
            var users = _userService.GetUsers().MapToUserViewModels();

            if (users != null)
                return Request.CreateResponse(HttpStatusCode.OK, users);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No users found");
        }

        public HttpResponseMessage Get(string id)
        {
            var user = _userService.GetUser(id).MapToUserViewModel();

            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK, user);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No user found");
        }

        [HttpGet]
        [Route("Search")]
        public HttpResponseMessage Search(string topicTitle)
        {
            var users = _userService.SearchsUsers(topicTitle).MapToUserViewModels();

            if (users != null)
                return Request.CreateResponse(HttpStatusCode.OK, users);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No users found");
        }
    }
}
