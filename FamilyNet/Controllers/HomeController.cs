using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FamilyNet.Models;
using FamilyNet.Data.Interfaces;
using FamilyNet.Data.Entity;

namespace FamilyNet.Controllers
{
    public class HomeController : Controller
    {
        //IUnitOfWork _unitOfWork;
        IUnitOfWorkAsync _unitOfWorkAsync;
        public HomeController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWorkAsync = unitOfWork;
        }
        

        public async Task<IActionResult> Index()
        {
            CharityMaker charityMaker = new CharityMaker()
            {
                FullName = new FullName() { Name = "33", Surname = "33", Patronymic = "3" },
                Address = new Address() { City = "test2", Country = "test2", House = "test2", Region = "test2", Street = "test2" },
                Birthday = DateTime.Now,
                Contacts = new Contacts() { Email = "test2" },
                Donations = null,
                Rating = 2
            };
            await _unitOfWorkAsync.CharityMakers.Create(charityMaker);
            _unitOfWorkAsync.SaveChangesAsync();
            var list = _unitOfWorkAsync.CharityMakers.GetAll().ToList();
            var list2 = _unitOfWorkAsync.CharityMakers.GetById(1).Result;
            var temp = list2.Address;
            list[0].Rating = 250;
            await _unitOfWorkAsync.CharityMakers.Update(list[0]);
            _unitOfWorkAsync.SaveChangesAsync();


            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
