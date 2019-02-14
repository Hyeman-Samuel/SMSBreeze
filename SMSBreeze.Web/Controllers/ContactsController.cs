using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Data;
using SMSBreeze.Web.Models.ViewModel;

namespace SMSBreeze.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ContactsController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var applicationDbContext = await _context.Contacts.Where(x => x.CustomerID == _customer.ID).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (id == null && _context.Contacts.Where(x => x.CustomerID == user.Customer.ID) == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,PhoneNumber")] Contact contact)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (ModelState.IsValid)
            {
                contact.CustomerID = _customer.ID;
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null && _context.Contacts.Where(x => x.CustomerID == _customer.ID) == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,PhoneNumber")] Contact contact)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);

            if (id != contact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    contact.CustomerID = _customer.ID;
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ID))
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
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (id == null && _context.Contacts.Where(x => x.CustomerID == _customer.ID) == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ID == id);
        }
        public async Task<IActionResult> AddToGroup(int ContactId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);

            var Assign = _context.GroupAssigns.Where(x => x.ContactID == ContactId);
            List<Group> groups = _context.Groups.Where(x => x.CustomerId == _customer.ID).ToList();
            foreach (var item in Assign)
            {
                var Group = _context.Groups.Find(_context.GroupAssigns.First(x => x.ID == item.ID).Group.ID);
                groups.Remove(Group);
            }
            var ContactVm = new ContactViewModel()
            {
                Contact = _context.Contacts.First(i => i.ID == ContactId),
                Groups = groups
            };

            return View(ContactVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToGroup([Bind("ID")]int Id, int[] Groups)
        {
            var _Contacts = _context.Contacts.First(i => i.ID == Id);
            foreach (var item in Groups)
            {
                var _Group = await _context.Groups.FirstAsync(i => i.ID == item);
                GroupAssign assign = new GroupAssign()
                {
                    Group = _Group,
                    ContactID = _Contacts.ID
                };
                _Group.Members.Add(assign);
                _context.GroupAssigns.Add(assign);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
