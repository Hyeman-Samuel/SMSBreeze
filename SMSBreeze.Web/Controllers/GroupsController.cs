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
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupsController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var applicationDbContext = await _context.Groups.Where(x => x.CustomerId == _customer.ID).Include(x => x.Members).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var group = await _context.Groups.Include(x => x.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (group == null)
            {
                return NotFound();
            }
            List<Contact> contacts = new List<Contact>();
            foreach (var item in group.Members)
            {
                var members = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == item.ContactID);
                contacts.Add(members);
            }
            var GroupVm = new GroupViewModel() {
             Contacts = contacts,
             Group = group
            };
           

            return View(GroupVm);
        }

        // GET: Groups/Create
        public async Task<IActionResult> Create()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var GroupVm = new GroupViewModel()
            {
                Contacts = _context.Contacts.Where(x => x.CustomerID == _customer.ID).ToList(),
                Referee = Request.Headers["Referer"].ToString()
            };
            return View(GroupVm);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GroupName")]Group group, int[] Contacts)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (ModelState.IsValid)
           {
                group.CustomerId = _customer.ID;
                List <GroupAssign> _contacts = new List<GroupAssign>();
                if (Contacts == null) { } else
                {
                    foreach (var item in Contacts)
                    {
                      var contacts = _context.Contacts.First(x => x.ID == item);
                        GroupAssign assign = new GroupAssign()
                        {
                            ContactID = contacts.ID
                        };
                        _contacts.Add(assign);
                    }
                    group.Members = _contacts;
                }
                
                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {    if (id == null)
            {
                return NotFound();
            } 
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = await _context.Customers.FirstAsync(x => x.ApplicationUserId == user.Id);
            var group = await _context.Groups.FindAsync(id);
            var assig =await _context.GroupAssigns.Where(x => x.Group.ID == id).ToListAsync();
            var AllContacts = await _context.Contacts.Where(x => x.CustomerID == _customer.ID).ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            var list = new List<CheckBox>();
            foreach (var item in AllContacts)
            {
                
                list.Add(new CheckBox()
                {
                    Contact = item,
                    Checked = assig.Any(p => p.ContactID == item.ID) ? true : false
                });
            }                            
            var GroupVm = new GroupViewModel()
            {     Group =group,
                Contacts = _context.Contacts.Where(x => x.CustomerID == _customer.ID).ToList(),
                  CheckedContacts =list ,
                Referee = Request.Headers["Referer"].ToString()
            };
            return View(GroupVm);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GroupName")] Group group, int[] Contacts)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            if (id != group.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                group.CustomerId = _customer.ID;
                try
                {
                    List<GroupAssign> _contacts = new List<GroupAssign>();
                    if (Contacts == null) { }
                    else
                    {
                        foreach (var item in Contacts)
                        {
                            var contacts = _context.Contacts.First(x => x.ID == item);
                            if(_context.GroupAssigns.Where(x => x.Group.ID == group.ID).Any(x =>x.ContactID == contacts.ID)){ } else { 
                            GroupAssign assign = new GroupAssign()
                            {
                                ContactID = contacts.ID
                            };
                            _contacts.Add(assign);
                        }
                        group.Members = _contacts;
                    }
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.ID))
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
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var group = await _context.Groups.FindAsync(id);
            var assign = _context.GroupAssigns.Where(x => x.Group.ID == id).ToList();
            group.CustomerId = _customer.ID;
            foreach (var item in assign)
            {
                _context.GroupAssigns.Remove(item);
            }           
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.ID == id);
        }
       
        public async Task<IActionResult> Remove(int id, int GroupId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var Group = _context.Groups.First(x => x.ID == GroupId);
            var assign = _context.GroupAssigns.Where(x => x.ContactID == id).First(x =>x.Group.ID ==GroupId);
            if (assign == null)
            { }
            else { 
                Group.Members.Remove(assign);
            _context.GroupAssigns.Remove(assign);
                    await _context.SaveChangesAsync(); }
                    return Redirect(Request.Headers["Referer"].ToString());          
        }

        public async Task<IActionResult> AddToGroup(int GroupId)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);
            var Assign = _context.GroupAssigns.Where(x => x.Group.ID == GroupId);
            List<Contact> contacts = _context.Contacts.Where(x => x.CustomerID == _customer.ID).ToList();
            foreach (var item in Assign)
            {
               var contact = _context.Contacts.Find(_context.GroupAssigns.First(x => x.ID == item.ID).ContactID);
                contacts.Remove(contact);
            }
            var GroupVm = new GroupViewModel()
            {
                Group = _context.Groups.First(i => i.ID == GroupId),
                Contacts = contacts,
                Referee = Request.Headers["Referer"].ToString()
            };

            return View(GroupVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToGroup([Bind("ID")]int Id, int[] Contacts)
        {
            var _Group = _context.Groups.First(i => i.ID == Id);
            foreach (var item in Contacts)
            {
                var _contacts = await _context.Contacts.FirstAsync(i => i.ID == item);
                GroupAssign assign = new GroupAssign()
                {
                    Group =_Group,
                    ContactID = _contacts.ID
                };
                _Group.Members.Add(assign);
                _context.GroupAssigns.Add(assign);
                await _context.SaveChangesAsync();
            }

              return RedirectToAction(nameof(Index));
        }
        }
}
