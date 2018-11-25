using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivityLockerServer.Data;
using ActivityLockerServer.Models;
using System.Text;

namespace ActivityLockerServer.Controllers
{
    public class UserTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserActivities
        public async Task<IActionResult> Index()
        {            
            return View(await _context.UserActivities
                .Include("UserGroup")
                .Where(item => item.UserId == User.Identity.Name)
                .OrderByDescending(item => item.CreatedDateTime)
                .ToListAsync());
        }

        // GET: UserActivities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivities
                .Include("ActivityUsers")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // GET: UserActivities/Create
        public IActionResult Create()
        {
            return View(new UserTaskViewModel(User.Identity.Name,_context));
        }

        // POST: UserActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Code,Url,SelectedUserGroups")] UserTaskViewModel userActivityVM)
        {
            if (ModelState.IsValid)
            {
                foreach (string groupId in userActivityVM.SelectedUserGroups)
                {
                    //get the Url from the group
                    UserActivity userActivity = new UserActivity();
                    userActivity.Id = Guid.NewGuid().ToString();
                    userActivity.Description = userActivityVM.Description;
                    userActivity.Url = _context.UserGroups.Single(item => item.Id == groupId).WebAddress;
                    userActivity.UserGroup = _context.UserGroups.Single(item => item.Id == groupId);
                    userActivity.UserId = User.Identity.Name;
                    userActivity.TenantId = "Mead354";//TODO
                    userActivity.Code = GenerateRandomCode();
                    userActivity.CreatedDateTime = DateTime.UtcNow;
                    userActivity.ActiveBeforeDateTime = DateTime.MinValue;//deactivate
                    //add some students for demo
                    userActivity.ActivityUsers = new List<UserActivityUser>();
                    userActivity.ActivityUsers.Add(new UserActivityUser() { Name = "student1@mead354.org", Status = UserActivityUserStatus.Waiting });
                    userActivity.ActivityUsers.Add(new UserActivityUser() { Name = "student2@mead354.org", Status = UserActivityUserStatus.Active });
                    userActivity.ActivityUsers.Add(new UserActivityUser() { Name = "student3@mead354.org", Status = UserActivityUserStatus.Exited });

                    _context.Add(userActivity);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(userActivityVM);
        }

        private string GenerateRandomCode()
        {
            //random six digit code (not used by another activity?)
            StringBuilder result = new StringBuilder();
            Random rnd = new Random();
            for (int i=0; i< 6; i++)
            {
                var ch = rnd.Next(65, 90);
                result.Append((char)ch);
            }
            return result.ToString();
        }

        // GET: UserActivities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivities.FindAsync(id);
            if (userActivity == null)
            {
                return NotFound();
            }
            return View(userActivity);
        }

        // POST: UserActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Description,Code,Url,UserId,TenantId")] UserActivity userActivity)
        {
            if (id != userActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserActivityExists(userActivity.Id))
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
            return View(userActivity);
        }

        // GET: UserActivities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // POST: UserActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userActivity = await _context.UserActivities.FindAsync(id);
            _context.UserActivities.Remove(userActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserActivityExists(string id)
        {
            return _context.UserActivities.Any(e => e.Id == id);
        }
    }
}
