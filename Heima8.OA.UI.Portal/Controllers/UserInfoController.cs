using Heima8.OA.BLL;
using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoService _userInfoService = new UserInfoService();

        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = _userInfoService.GetEntities(u =>true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            _userInfoService.Add(userInfo);
            return RedirectToAction("Index");
        }

    }
}