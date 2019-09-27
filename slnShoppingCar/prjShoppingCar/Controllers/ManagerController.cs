using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjShoppingCar.Models;

namespace prjShoppingCar.Controllers
{

    public class ManagerController : Controller
    {
        dbShoppingCarEntities db = new dbShoppingCarEntities();
        ///////////////////////////////////////////管理者登入///////////////////////////////////////////////////////////

        //Get:AllLogin/ManagerLogin管理者登入
        public ActionResult ManagerLogin()
        {
            return View();
        }

        //POST:AllLogin/ManagerLogin管理者登入
        [HttpPost]
        public ActionResult ManagerLogin(string fMUserId, string fMPwd)
        {
            // 依帳密取得管理者並指定給manager
            var manager = db.tManager
                .Where(m => m.fMUserId == fMUserId && m.fMPwd == fMPwd).FirstOrDefault();
            //若manager為null，表示輸入錯誤
            if (manager == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View();
            }

            //使用Session變數記錄歡迎詞
            Session["WelCome"] = manager.fMName + "歡迎光臨";
            //使用Session變數記錄登入的會員物件
            Session["Manager"] = manager;
            //執行Home控制器的Index動作方法
            return RedirectToAction("ManagerCenter");
        }

        //Get:AllLogin/ManagerLogout 登出
        public ActionResult ManagerLogout()
        {
            Session.Clear();  //清除Session變數資料
            return RedirectToAction("Index");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //Get:Home/ManagerCenter 網站管理中心
        public ActionResult ManagerCenter()
        {
            //若Session["Manager"]為空，表示會員未登入
            if (Session["Manager"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Index", "_Layout");
            }
            //會員登入狀態
            //指定ManagerCenter.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("ManagerCenter", "_LayoutManager");
        }

        //GET:ManagerCenter/ManagerMember會員管理
        public ActionResult ManagerMember()
        {
            var editmember = db.tMember.OrderByDescending(m => m.fId).ToList();
            return View("ManagerMember", "_LayoutManager", editmember);

        }

        //會員管理>編輯
        public ActionResult ManagerMemberEdit(string fUserId)
        {
            string str_id = fUserId.ToString();
            var edit = db.tMember.Where(m => m.fUserId == str_id).FirstOrDefault();
            return View("ManagerMemberEdit", "_LayoutManager", edit);
        }

        [HttpPost]
        public ActionResult ManagerMemberEdit
            (string fUserId, string fPwd, string fName,
            string fEmail, string fTel, string fSex, Nullable<System.DateTime> fBirthday,
            string fUAddress)
        {
            var edit = db.tMember.Where(m => m.fUserId == fUserId).FirstOrDefault();
            edit.fName = fName;
            edit.fPwd = fPwd;
            edit.fUserId = fUserId;
            edit.fSex = fSex;
            edit.fEmail = fEmail;
            edit.fTel = fTel;
            edit.fBirthday = fBirthday;
            edit.fUAddress = fUAddress;

            db.SaveChanges();
            return RedirectToAction("MemberCenter");
        }




        //會員管理>刪除
        public ActionResult ManagerMemberDelete(string fUserId)
        {

            // 依fUerId找出要刪除會員中心的會員
            var memberdelete = db.tMember.Where(m => m.fUserId == fUserId).FirstOrDefault();
            //刪除會員中心的會員
            db.tMember.Remove(memberdelete);
            db.SaveChanges();
            //執行Home控制器的ManagerMemberDelete動作方法
            return RedirectToAction("ManagerMember", "Home", memberdelete);
        }


        //GET:ManagerCenter/ManagerProduct商品管理
        public ActionResult ManagerProduct()
        {
            return View();
        }
    }
}