
using prjShoppingCar.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjShoppingCar.Controllers
{
    public class HomeController : Controller
    {
        //建立可存取dbShoppingCar.mdf 資料庫的dbShoppingCarEntities 類別物件db
        dbShoppingCarEntities db = new dbShoppingCarEntities();
        

        // Get:Home/Index
        public ActionResult Index()
        {
            
            //若Session["Member"]為空，表示會員未登入
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Index", "_Layout");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Index", "_LayoutMember");
        }

        //GET:Home/Store 婚禮小物
        public ActionResult Store()
        {
            //取得所有產品放入products
            var products = db.tProduct.ToList();
            //若Session["Member"]為空，表示會員未登入
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Store", "_Layout", products);
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Store", "_LayoutMember", products);
        }

        //Get:Home/ProductView 商品介紹
        public ActionResult ProductView(string fImg,string id)
        {
            
            var view = db.tProduct.Where(m=>m.fPId==id).OrderByDescending(m => m.fImg==fImg).ToList();

           
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("ProductView", "_Layout", view);
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("ProductView", "_LayoutMember",view);
        }


        //GET:Home/Program 婚宴方案
        public ActionResult Program()
        {
            
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Program", "_Layout");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Program", "_LayoutMember");
        }
        //GET:Home/WeddingDress 婚紗.禮服
        public ActionResult WeddingDress()
        {
            //若Session["Member"]為空，表示會員未登入
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("WeddingDress", "_Layout");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("WeddingDress", "_LayoutMember");
        }

        //GET:Home/Photography 婚禮攝影
        public ActionResult Photography()
        {
            //若Session["Member"]為空，表示會員未登入
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Photography", "_Layout");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Photography", "_LayoutMember");
        }
        //GET:Home/Connection 聯絡我們
        public ActionResult Connection()
        {
            //若Session["Member"]為空，表示會員未登入
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Connection", "_Layout");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Connection", "_LayoutMember");
        }



        ////Get: Home/AllLogin  All登入
        public ActionResult AllLogin()
        {
            return View();
        }

        ///////////////////////////////////////////管理者登入///////////////////////////////////////////////////////////
        
        //Get:AllLogin/ManagerLogin管理者登入 
        public ActionResult ManagerLogin()
        {
            return View();
        }

        //POST:AllLogin/ManagerLogin管理者登入
        [HttpPost]
        public ActionResult ManagerLogin(string fMUserId,string fMPwd)
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
            Session["WelCome"] =manager.fMName + "歡迎光臨";
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
            return RedirectToAction("ManagerMember","Home", memberdelete);
        }


        //GET:ManagerCenter/ManagerProduct商品管理
        public ActionResult ManagerProduct()
        {
            var editproduct = db.tProduct.OrderByDescending(m => m.fId).ToList();
            return View("ManagerProduct", "_LayoutManager", editproduct);
        }
        //商品管理>新增
        public ActionResult ProductCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate
            (string fPId, string fName, string fPType, string fPContent, 
            int fPrice, HttpPostedFileBase fImg, string oldImg)
        {
            try
            {
                //上傳圖檔
                string fileName = "";
                //檔案上傳
                if (fImg != null)
                {
                    if (fImg.ContentLength > 0)
                    {
                        //取得圖檔
                        fileName = System.IO.Path.GetFileName(fImg.FileName);
                        var path = System.IO.Path.Combine(Server.MapPath("~/images/婚禮小物/全部商品"), fileName);
                        //檔案存到~/images/婚禮小物/全部商品資料夾下
                        fImg.SaveAs(path);
                    }
                }
                //新增紀錄
                tProduct product = new tProduct();
                product.fPId = fPId;
                product.fName = fName;
                product.fPType = fPType;
                product.fPContent = fPContent;
                product.fPrice = fPrice;
                product.fImg = fileName;
                db.tProduct.Add(product);
                db.SaveChanges();
                return RedirectToAction("ManagerProduct");

            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();


            
        }

        //商品管理>刪除
        public ActionResult ManagerProductDelete(string fPId)
        {
            //依網址傳來的fPId編號取得要刪除的產品紀錄
            var product = db.tProduct.Where(m => m.fPId == fPId).FirstOrDefault();
            //取得要刪除商品的圖檔
            string fileName = product.fImg;
            if(fileName != "")
            {
                //刪除指定圖檔
                System.IO.File.Delete(Server.MapPath("~/images/婚禮小物/全部商品") + "/" + fileName);
            }
            db.tProduct.Remove(product);
            db.SaveChanges();
            //依編號刪除產品紀錄
            return RedirectToAction("ManagerProduct");
        }
        

        //商品管理>編輯
        public ActionResult ManagerProductEdit(string fPId)
        {
            var editproduct = db.tProduct.Where(m => m.fPId == fPId).FirstOrDefault();
            return View("ManagerProductEdit", "_LayoutManager", editproduct);
        }
        [HttpPost]
        public ActionResult ManagerProductEdit
            (string fPId,string fName,string fPType,string fPContent,int fPrice,HttpPostedFileBase fImg,string oldImg)
        {
            string fileName = "";
            //檔案上傳
            if (fImg == null)
            {
                if (fImg.ContentLength > 0)
                {
                    //取得圖檔名稱
                    fileName = System.IO.Path.GetFileName(fImg.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/images/婚禮小物/全部商品"), fileName);
                    fImg.SaveAs(path);
                }
            }
            else
            {
                //若無上傳圖檔,則指定hidden隱藏欄位的資料
                fileName = oldImg;
            }
            var edit = db.tProduct.Where(m => m.fPId == fPId).FirstOrDefault();
            edit.fPId = fPId;
            edit.fName = fName;
            edit.fPType = fPType;
            edit.fPContent = fPContent;
            edit.fPrice = fPrice;
            edit.fImg = fileName;

            db.SaveChanges();
            return RedirectToAction("ManagerProduct");
        }



        ///////////////////////////////////////////會員登入///////////////////////////////////////////////////////////  

        //Get: Home/Login  登入
        public ActionResult Login()
        {
            return View();
        }
        //Post: Home/Login  登入
        [HttpPost]
        public ActionResult Login(string fUserId, string fPwd)
        {
            // 依帳密取得會員並指定給member
            var member = db.tMember
                .Where(m => m.fUserId == fUserId && m.fPwd == fPwd)
                .FirstOrDefault();
            //若member為null，表示會員未註冊
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View();
            }
            //使用Session變數記錄歡迎詞
            Session["WelCome"] = member.fName + "歡迎光臨";
            //使用Session變數記錄登入的會員物件
            Session["Member"] = member;
            //執行Home控制器的Index動作方法
            return RedirectToAction("Index");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////  

        ///////////////////////////////////////////會員註冊///////////////////////////////////////////////////////////    
        //Get:Home/Register 註冊
        public ActionResult Register()
        {
            return View();
        }
        //Post:Home/Register 註冊
        [HttpPost]
        public ActionResult Register(tMember pMember)
        {
            //若模型沒有通過驗證則顯示目前的View
            if (ModelState.IsValid == false)
            {
                return View();
            }
            // 依帳號取得會員並指定給member
            var member = db.tMember
                .Where(m => m.fUserId == pMember.fUserId)
                .FirstOrDefault();
            //若member為null，表示會員未註冊
            if (member == null)
            {
                //將會員記錄新增到tMember資料表
                db.tMember.Add(pMember);
                db.SaveChanges();
                //執行Home控制器的Login動作方法
                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號己有人使用，註冊失敗";
            return View();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////    

        ///////////////////////////////////////////會員登出///////////////////////////////////////////////////////////    

        //Get:Index/Logout 登出
        public ActionResult Logout()
        {
            Session.Clear();  //清除Session變數資料
            return RedirectToAction("Index");
        }

        

        //Get:Index/ShoppingCar 
        public ActionResult ShoppingCar()
        {
            //取得登入會員的帳號並指定給fUserIdadd
            string fUserId = (Session["Member"] as tMember).fUserId;
            //找出未成為訂單明細的資料，即購物車內容
            var orderDetails = db.tOrderDetail.Where
                (m => m.fUserId == fUserId && m.fIsApproved == "否")
                .ToList();
            ViewBag.TotalAmount = db.tOrderDetail.Where(m => m.fIsApproved == "否" && m.fUserId == fUserId).Sum(m => m.fAmount);          



            //指定ShoopingCar.cshtml套用_LayoutMember.cshtml，View使用orderDetails模型
            return View("ShoppingCar", "_LayoutMember", orderDetails);
        }

        //GET:會員檢視資料
        
        public ActionResult MemberCenter()
        {
            //取得登入會員的帳號並指定給fUserId
            string fUserId = (Session["Member"] as tMember).fUserId;
            //
            var member = db.tMember.Where(m => m.fUserId == fUserId).ToList();
            //指定MemberCenter.cshtml套用_LayoutMember.cshtml，View使用member模型
            return View("MemberCenter", "_LayoutMember", member);
        }

        //編輯會員資料
        public ActionResult Edit(string fUserId)    
        {
            string str_id = fUserId.ToString();
            var edit = db.tMember.Where(m => m.fUserId == str_id).FirstOrDefault();
            return View("Edit", "_LayoutMember", edit);
        }

        [HttpPost]
        public ActionResult Edit
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



        //Get:Index/AddCar 商品新增到購物車
        public ActionResult AddCar(string fPId)
        {
            //取得會員帳號並指定給fUserId
            string fUserId = (Session["Member"] as tMember).fUserId;
            //找出會員放入訂單明細的產品，該產品的fIsApproved為"否"
            //表示該產品是購物車狀態
            var currentCar = db.tOrderDetail
                .Where(m => m.fPId == fPId && m.fIsApproved == "否" && m.fUserId == fUserId)
                .FirstOrDefault();
            var product = db.tProduct.Where(m => m.fPId == fPId).FirstOrDefault();
            //若currentCar等於null，表示會員選購的產品不是購物車狀態
            if (currentCar == null)
            {
                //找出目前選購的產品並指定給product
                //將產品放入訂單明細，因為產品的fIsApproved為"否"，表示為購物車狀態
                tOrderDetail orderDetail = new tOrderDetail();
                orderDetail.fUserId = fUserId;
                orderDetail.fPId = product.fPId;
                orderDetail.fName = product.fName;
                orderDetail.fPrice = product.fPrice;
                orderDetail.fQty = 1;
                orderDetail.fAmount = product.fPrice * orderDetail.fQty;
                
                orderDetail.fIsApproved = "否";
                db.tOrderDetail.Add(orderDetail);
               
            }
            else
            {
                //若產品為購物車狀態，即將該產品數量加1
                currentCar.fQty += 1;
                currentCar.fAmount = product.fPrice * currentCar.fQty;

            }
            db.SaveChanges();
            //執行Home控制器的ShoppingCar動作方法

            //Session["TotalAmount"] = db.tOrderDetail.Where(m => m.fIsApproved == "否" && m.fUserId == fUserId).Sum(m => m.fAmount);

            //ViewBag.TotalAmount = db.tOrderDetail.Sum(m => m.fAmount);

            return RedirectToAction("ShoppingCar");
        }

        //Get:Index/DeleteCar 刪除購物車商品
        public ActionResult DeleteCar(int fId)
        {
            // 依fId找出要刪除購物車狀態的產品
            var orderDetail = db.tOrderDetail.Where
                (m => m.fId == fId).FirstOrDefault();
            //刪除購物車狀態的產品
            db.tOrderDetail.Remove(orderDetail);
            db.SaveChanges();
            //執行Home控制器的ShoppingCar動作方法
            return RedirectToAction("ShoppingCar");
        }

        //Post:Index/ShoppingCar 購物車
        [HttpPost]
        public ActionResult ShoppingCar(string fReceiver, string fEmail, string fAddress,string fPhone)
        {
            //找出會員帳號並指定給fUserId
            string fUserId = (Session["Member"] as tMember).fUserId;
            //建立唯一的識別值並指定給guid變數，用來當做訂單編號
            //tOrder的fOrderGuid欄位會關聯到tOrderDetail的fOrderGuid欄位
            //形成一對多的關係，即一筆訂單資料會對應到多筆訂單明細
            string guid = Guid.NewGuid().ToString();
            //建立訂單主檔資料
            tOrder order = new tOrder();
            order.fOrderGuid = guid;
            order.fUserId = fUserId;
            order.fReceiver = fReceiver;
            order.fPhone = fPhone;
            order.fEmail = fEmail;
            order.fAddress = fAddress;
            order.fDate = DateTime.Now;
            db.tOrder.Add(order);
            //找出目前會員在訂單明細中是購物車狀態的產品
            var carList = db.tOrderDetail
                .Where(m => m.fIsApproved == "否" && m.fUserId == fUserId)
                .ToList();
            //將購物車狀態產品的fIsApproved設為"是"，表示確認訂購產品
            foreach (var item in carList)
            {
                item.fOrderGuid = guid;
                item.fIsApproved = "是";
            }
            //更新資料庫，異動tOrder和tOrderDetail
            //完成訂單主檔和訂單明細的更新
            db.SaveChanges();

            //var carList2 = db.tOrderDetail
            //    .Where(m => m.fIsApproved == "否" && m.fUserId == fUserId)
            //    .ToList();
            //int aaa=0;
            //foreach (var item in carList2)
            //{
            //    aaa += (int)item.fAmount;
                
            //}
            //執行Home控制器的OrderList動作方法
            return RedirectToAction("OrderList");
        }

        //Get:Home/OrderList 訂單
        public ActionResult OrderList()
        {
            //找出會員帳號並指定給fUserId
            string fUserId = (Session["Member"] as tMember).fUserId;
            //找出目前會員的所有訂單主檔記錄並依照fDate進行遞增排序
            //將查詢結果指定給orders
            var orders = db.tOrder.Where(m => m.fUserId == fUserId)
                .OrderByDescending(m => m.fDate).ToList();
            

            //目前會員的訂單主檔
            //指定OrderList.cshtml套用_LayoutMember.cshtml，View使用orders模型
            return View("OrderList", "_LayoutMember", orders);
        }

        //Get:Index/OrderDetail  訂單明細
        public ActionResult OrderDetail(string fOrderGuid)
        {
            //根據fOrderGuid找出和訂單主檔關聯的訂單明細，並指定給orderDetails
            var orderDetails = db.tOrderDetail
                .Where(m => m.fOrderGuid == fOrderGuid).ToList();
            ViewBag.TotalAmount = db.tOrderDetail.Where(m => m.fOrderGuid == fOrderGuid).Sum(m => m.fAmount);
            //目前訂單明細
            //指定OrderDetail.cshtml套用_LayoutMember.cshtml，View使用orderDetails模型
            return View("OrderDetail", "_LayoutMember", orderDetails);
        }

        
    }
}