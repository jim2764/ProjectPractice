using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Models;
using ProjectPractice.Models.Extensions;
using ProjectPractice.Models.VMs;

namespace ProjectPractice.Controllers
{
    public class BlackListsController : Controller
    {
        private readonly PracticeContext _context;

        public BlackListsController(PracticeContext context)
        {
            _context = context;
        }

        // GET: BlackLists
        public async Task<IActionResult> Index()
        {
              return View(await _context.Members.Where(x => x.IsInBlackList).Select(x => x.EntityToBlackVM()).ToListAsync());
        }

        [HttpPut]
        public void Delete(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);

            member.IsInBlackList = false;

            _context.SaveChangesAsync();
        }

        public IEnumerable<BlackListVM> GetSomeBackListMembers(string account)
        {
            var members = _context.Members
                .Where(x => x.EmailAccount != null && x.IsInBlackList && x.EmailAccount.Contains(account));

            return members.Select(x => x.EntityToBlackVM());
        }
    }
}
