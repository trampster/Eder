using Eder.Models;
using Eder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Encodings.Web;

namespace Eder.Controllers
{
    public class MembersController : Controller
    {
        readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        public IActionResult Index()
        {
            return View(_membersService.GetMembers());
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Member member)
        {
            if(ModelState.IsValid) 
            { 
                _membersService.Add(member);
                return RedirectToAction("Index"); 
            } 

            return View();
        }

        public ActionResult Edit(int id)
        {
            var member = _membersService.GetMember(id);
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {
            if(ModelState.IsValid) 
            { 
                _membersService.Update(member);
                return RedirectToAction("Index"); 
            } 

            return View();
        }
    }
}