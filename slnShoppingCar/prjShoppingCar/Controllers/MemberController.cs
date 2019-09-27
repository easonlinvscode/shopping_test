//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using prjShoppingCar.Models;

//namespace prjShoppingCar.Controllers
//{
//    public class MemberController : Controller
//    {
//        dbShoppingCarEntities db = new dbShoppingCarEntities();

//        // GET: Member
//        //GET:會員檢視資料

//        public ActionResult MemberCenter()
//        {
//            //取得登入會員的帳號並指定給fUserId
//            string fUserId = (Session["Member"] as tMember).fUserId;
//            //
//            var member = db.tMember.Where(m => m.fUserId == fUserId).ToList();
//            //指定MemberCenter.cshtml套用_LayoutMember.cshtml，View使用member模型
//            return View("MemberCenter", "_LayoutMember", member);
//        }

//        //編輯會員資料
//        public ActionResult Edit(string fUserId)
//        {
//            string str_id = fUserId.ToString();
//            var edit = db.tMember.Where(m => m.fUserId == str_id).FirstOrDefault();
//            return View("MemberCenter", "_LayoutMember", edit);
//        }

//        [HttpPost]
//        public ActionResult Edit
//            (string fUserId, string fPwd, string fName,
//            string fEmail, string fTel, string fSex, Nullable<System.DateTime> fBirthday,
//            string fUAddress)
//        {
//            var edit = db.tMember.Where(m => m.fUserId == fUserId).FirstOrDefault();
//            edit.fName = fName;
//            edit.fPwd = fPwd;
//            edit.fUserId = fUserId;
//            edit.fSex = fSex;
//            edit.fEmail = fEmail;
//            edit.fTel = fTel;
//            edit.fBirthday = fBirthday;
//            edit.fUAddress = fUAddress;

//            db.SaveChanges();
//            return RedirectToAction("MemberCenter");
//        }
//    }
//}