using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpdeskApp.Models;
using Microsoft.EntityFrameworkCore;
using HelpdeskApp.Models.ViewModels;

namespace HelpdeskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelpdeskAppContext _context;

        public HomeController(HelpdeskAppContext context)
        {
            this._context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: DataItems
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items
                                .Include(i => i.AssignmentGroup)
                                .Include(i => i.Contact)
                .ToListAsync();
            return View(items);
        }

        // GET: DataItems
        public async Task<IActionResult> Search(FilterItems filters)
        {
            IQueryable<DataItem> data = null;

            if (!string.IsNullOrWhiteSpace(filters.ContactFilter))
            {                
                data = _context.Items.Where(d => d.Contact != null && d.Contact.FullName.Contains(filters.ContactFilter));
            }

            if (!string.IsNullOrWhiteSpace(filters.DescriptionFilter))
            {
                data = _context.Items.Where(d => d.Description.Contains(filters.DescriptionFilter));
            }

            if (!string.IsNullOrWhiteSpace(filters.AssignmentGroupFilter))
            {
                data = _context.Items.Where(d => d.AssignmentGroup != null && d.AssignmentGroup.Name.Contains(filters.AssignmentGroupFilter));
            }

            if (data != null)
            {
                var viewData = await data
                                .Include(i => i.Contact)
                                .Include(i => i.AssignmentGroup)
                                .ToListAsync();
            }

            return View("index", data);
        }

        // GET: DataItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataItem = await _context.Items
                                .Include(i => i.AssignmentGroup)
                                .Include(i => i.Contact)
                                .SingleOrDefaultAsync(x => x.Id == id);
                
            if (dataItem == null)
            {
                return NotFound();
            }

            var viewModel = new EditViewModel
            {
                Description = dataItem.Description,
                Id = dataItem.Id,
                ContactId = dataItem.Contact.Id,
                AssignmentGroupId = dataItem.AssignmentGroup.Id
            };

            return View(viewModel);
        }

        // GET: DataItems/Create
        public async Task<IActionResult> Create()
        {
            var contacts = await _context.Contacts.ToListAsync();
            var groups = await _context.Groups.ToListAsync();

            return View(new CreateViewModel()
            {
                AssignmentGroups = groups,
                Contacts = contacts
            });
        }

        // POST: DataItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description, ContactId, AssignmentGroupId")] DataItem dataItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataItem);
        }

        // GET: DataItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataItem = await _context.Items
                                .Include(i => i.AssignmentGroup)
                                .Include(i => i.Contact)
                                .SingleOrDefaultAsync(x => x.Id == id);
                               
            if (dataItem == null)
            {
                return NotFound();
            }
            return View(new EditViewModel
            {
                AssignmentGroupId = dataItem.AssignmentGroup.Id,
                Id = dataItem.Id,
                Description = dataItem.Description,
                ContactId = dataItem.Contact.Id,
                AssignmentGroups = await _context.Groups.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync()
            });
        }

        // POST: DataItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description, AssignmentGroupId, ContactId")] EditViewModel dataItem)
        {
            if (id != dataItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var itemToUpdate = _context.Items.SingleOrDefault(x => x.Id == dataItem.Id);
                    if (await TryUpdateModelAsync<DataItem>(itemToUpdate, "", s => s.Description, s => s.Description, s => s.AssignmentGroup))
                    {
                        _context.Update(itemToUpdate);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataItemExists(dataItem.Id))
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
            return View(dataItem);
        }

        // GET: DataItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataItem = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataItem == null)
            {
                return NotFound();
            }

            return View(dataItem);
        }

        // POST: DataItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataItem = await _context.Items.FindAsync(id);
            _context.Items.Remove(dataItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
