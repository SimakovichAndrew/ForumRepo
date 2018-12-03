using AutoMapper;
using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Interfaces;
using ForumMVC.Web.Models;
//using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        //private IOrderService Context
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Get<IOrderService>();
        //    }
        //}

        public ActionResult Index()
        {
            IEnumerable<CommentDTO> commentDtos = orderService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var phones = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);
            return View(phones);
            //if (Session["isLoginRepeat"] == null)
            //    Session["isLoginRepeat"] = false;
            //return View(Context.User.ToList());
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}