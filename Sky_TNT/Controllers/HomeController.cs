using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Sky_TNT.Models;
using PagedList;
namespace Sky_TNT.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext(); //truy cập database thông qua Model trung gian DataContext trong thư mục Models
                                                    //Em đã thử tìm cách để dùng interface tuy nhiên em đã thử nhiều cách nhưng nó vẫn váo lỗi error CS0525

        public ActionResult Index(string chao, int? page, string search)
        {
            var img = db.img.Include(i => i.Images_GroupImages);
            ViewBag.listimg = img.OrderByDescending(i => i.CountView).ToList();

            if (DateTime.Now.Hour < 5)              //Nếu thời gian nằm trong khoản từ 0h đến 5h thì sẽ chào buổi tối
            {
                ViewBag.chao = "Good Night !";
            }
            else if (DateTime.Now.Hour < 11)        //Nếu thời gian nằm trong khoản từ 5h đến 11h thì sẽ chào buổi sáng
            {
                ViewBag.chao = "Good Morning !";
            }
            else if (DateTime.Now.Hour < 18)        //Nếu thời gian nằm trong khoản từ 11h đến 18h thì sẽ chào buổi chiều
            {
                ViewBag.chao = "Good Afternoon !";
            }
            else if (DateTime.Now.Hour < 24)        //Nếu thời gian nằm trong khoản từ 18h đến 24h thì sẽ chào buổi tối
            {
                ViewBag.chao = "Good Evening !";
            }
            if(!string.IsNullOrEmpty(search))
            {
                if (search.Contains("@gmail.com"))
                {
                    img = img.Where(i => i.Email.Contains(search));
                }
                else
                {
                    img = img.Where(i => i.Images_GroupImages.NameGroup.Contains(search));
                }
            }
            return View(img.OrderBy(e => e.IdImages).ToPagedList(page ?? 1, 6 ));
        }

    }
}