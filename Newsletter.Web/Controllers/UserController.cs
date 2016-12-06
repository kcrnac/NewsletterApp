using Newsletter.Model.Users;
using Newsletter.Service.TopicService;
using Newsletter.Service.UserService;
using Newsletter.Web.Helpers;
using System;
using System.Web.Mvc;

namespace Newsletter.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;
        private ITopicService _topicService;

        public UserController(IUserService userService, ITopicService topicService)
        {
            this._userService = userService;
            this._topicService = topicService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetUsers();

            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var user = _userService.GetUser(id);

            ViewBag.Topics = DropdownHelper.TopicsForDropdown(_topicService);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNumber")] User model)
        {
            var updatedUser = _userService.UpdateUserDetails(model.Id, model);
            
            if(updatedUser != null)
            {
                TempData["MsgSuccess"] = "User details successfully updated.";

                ViewBag.Topics = DropdownHelper.TopicsForDropdown(_topicService);

                return View(updatedUser);
            }

            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(string id, string topicId)
        {
            var result = _userService.Subscribe(id, topicId);

            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        public ActionResult Unsubscribe(string id, string topicId)
        {
            var result = _userService.Unsubscribe(id, topicId);

            return Json(result);
        }
    }
}