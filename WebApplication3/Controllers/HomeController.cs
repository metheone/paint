using Core.AccountManagement;
using Microsoft.AspNet.Identity;
using Paint.Data.Interface;
using Paint.Data.Repository;
using Paint.Model.common;
using Paint.Model.Enums;
using Paint.Model.Models;
using Paint.Service;
using Paint.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new ApplicationUser("Test")
            {
                Email = "test@test.com",
                PhoneNumber = "5625625622"
            };
            //IdentityResult result = new IdentityManager().GetIdentityUserManager()
            //    .CreateAsync(user,"testpass").Result;

            //var test = new IdentityManager().GetUserManager();
            //var res = test.FindByEmail("test@test.com");
            var settings = new Settings("DefaultConnection");

            IColorRepository c = new ColorRepository(settings);
            IDefectRepository d = new DefectRepository(settings);
            IManufacturerRepository m = new ManufacturerRepository(settings);
            IMixRoomRepository mx = new MixRoomRepository(settings);
            IPartLogRepository pt = new PartLogRepository(settings);
            IPartRepository p = new PartRepository(settings);
            ISolventRepository s = new SolventRepository(settings);

            IPaintService service = new PaintService(c,d,m,mx,pt,p,s);


            var defects = service.GetAllDefects();
            var colors = service.GetAllColors();
            var manu = service.GetAllManufacturers();
            var parts = service.GetAllParts();
            var manu1 = service.GetPartsByManufacturerId(1);






























            var PostLogRepository = new PartLogRepository(settings);
            PartLog log = new PartLog();

            log.ColorId = 1;
            log.SolventId = 1;
            log.ManufacturerId = 1;
            log.PartId = 1;
            log.HasDefect = true;
            log.BarcodeId = 42342342;
            log.AddedBy = "Ani";
            var de = new Defect();
            de.DefectId = 1;
            log.Defects.Add(de);

            PostLogRepository.Save(ref log);

            //if (result != null)
            //{
            //    //Add role.
            //    if (result.Succeeded)
            //    {
            //        ////Send email to customer about account creation.
            //        //currentUser = GetUserByPhone(customerOrder.PhoneNumber);
            //        //new IdentityManager().AddUserToRole(currentUser.UserID, EnumRoles.Customer.ToString());
            //    }
            //}

            return View();
        }
    }
}
