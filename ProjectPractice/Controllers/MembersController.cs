using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Models;
using ProjectPractice.Models.DTOs;
using ProjectPractice.Models.Extensions;
using ProjectPractice.Models.Repositories;
using ProjectPractice.Models.VMs;

namespace ProjectPractice.Controllers
{
    public class MembersController : Controller
    {
        private readonly PracticeContext _context;
        private readonly MemberRepository _context2;

		public MembersController(PracticeContext context)
        {
            _context = context;
            _context2 = new MemberRepository(context);

		}

        // GET: Members
        public IActionResult Index()
        {
            var members = _context2.GetAll().Select(x => x.DTOToIndexVM());

			return View(members);
        }

        public IEnumerable<MemberIndexVM> GetSomeMembers(string account, string selectCity)
        {
            IEnumerable<MemberDTO> members;

            if (selectCity == "請選擇縣市..." && string.IsNullOrEmpty(account)) members = _context2.GetAll();   

            else if (selectCity == "請選擇縣市...") members = _context2.GetSomeAccount(account);

            else if (string.IsNullOrEmpty(account)) members = _context2.GetSomeAddress(selectCity);

            else members = _context2.GetSomeAccountAndAddress(account, selectCity);

            return members.Select(x => x.DTOToIndexVM());
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmailAccount,EncryptedPassword,RealName,NickName,BirthOfDate,Mobile,Address,PhotoSticker,About,ConfirmCode,IsConfirmed,IsInBlackList")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailAccount,EncryptedPassword,RealName,NickName,BirthOfDate,Mobile,Address,PhotoSticker,About,ConfirmCode,IsConfirmed,IsInBlackList")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'PracticeContext.Members'  is null.");
            }
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
          return _context.Members.Any(e => e.Id == id);
        }
    }
}
