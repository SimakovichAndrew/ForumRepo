using ForumMVC.BLL.Interfaces;
using ForumMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ForumMVC.Web.Controllers
{
    public class CommentController : Controller
    {
        IOrderService repository;
        

        public int PageCom = 4;
        public CommentController(IOrderService comentRepository)
        {
            this.repository = comentRepository;
        }
        // GET: Comment com
        public ViewResult Chat(string topicname, int page = 1)
        {
            CommentsListViewModel model = new CommentsListViewModel
            {
                GetComments = repository.GetComments()
                .Where(p => topicname == null || p.TopicName == topicname)
                .OrderBy(p => p.CommentId)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = topicname == null ?
                    repository.GetComments().Count() :
                    repository.GetComments().Where(e => e.TopicName == topicname).Count()
                },
                CurrentTopicName = topicname
            };

            int dateTime = DateTime.Now.Hour;
            switch (dateTime)
            {
                case 1: case 2: case 3: case 4: case 5: case 22: case 23: ViewBag.Greeting = "Доброй ночи"; break;
                case 6: case 7: case 8: case 9: case 10: ViewBag.Greeting = "Доброе утро"; break;
                case 11: case 12: case 13: case 14: case 15: case 16: case 17: ViewBag.Greeting = "Доброй день"; break;
                case 18: case 19: case 20: case 21: ViewBag.Greeting = "Добрый вечер"; break;
            }



            return View(model);
        }
        //_______________________________________________________________________________


 [HttpPost]
        public ActionResult _Send(CommentsListViewModel com, int page = 1)
        {

            try
            {
                //    CommentsListViewModel model = new CommentsListViewModel
                //{
                //   
                //};  
                repository.CreateComment(com.Content, com.CurrentTopicName);
                CommentsListViewModel model = new CommentsListViewModel
                {
                    GetComments = repository.GetComments()
                    //    .Where(p => /*topicname == null || */p.TopicName == com.CurrentTopicName)
                    //    .OrderBy(p => p.CommentId)
                    //    .Skip((page - 1) * PageCom)
                    //    .Take(PageCom),
                    //    //PagingInfoCom = new PagingInfo
                    //    //{
                    //    //    CurrentPage = page,
                    //    //    ItemsPerPage = PageCom,
                    //    //    TotalItems = topicname == null ?
                    //    //    repository.Comments.Count() :
                    //    //    repository.Comments.Where(e => e.TopicName == topicname).Count()
                    //    //},
                    //    CurrentTopicName = com.CurrentTopicName
                };
                // var coment = repository.GetComments();
                return View(model);
               // return RedirectToAction("_ViewChat");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
       [HttpGet]
        public ActionResult _Send()
        {
            var coment = repository.GetComments();
            return View(coment);
            //try
            //{
            //    var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
            //    orderService.MakeOrder(orderDto);
            //    return Content("<h2>Ваш заказ успешно оформлен</h2>");
            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError(/*ex.Property,*/ ex.Message);
            //}
            //return View(order);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    orderService.Dispose();
        //    base.Dispose(disposing);
        //}
        ////________________________________________________________________________________________
    }
}