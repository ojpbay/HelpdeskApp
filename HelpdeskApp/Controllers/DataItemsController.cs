using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpdeskApp.Models;

namespace HelpdeskApp.Controllers
{
    public class DataItemsController : Controller
    {
        private readonly HelpdeskAppContext _context;

        public DataItemsController(HelpdeskAppContext context)
        {
            _context = context;
        }

        // GET: DataItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: DataItems
        public async Task<IActionResult> Search(FilterItems filters)
        {
            IQueryable<DataItem> data = null;

            if (!string.IsNullOrWhiteSpace(filters.NameFilter))
            {
                //data = _context.Items.Where(dataItem => filters.NameFilter.Any(text => dataItem.Name.Contains(text)));

                data = _context.Items.Where(d => d.Name.Contains(filters.NameFilter));
            }

            if (!string.IsNullOrWhiteSpace(filters.LastNameFilter))
            {
                data = _context.Items.Where(d => d.LastName.Contains(filters.LastNameFilter));
                //data = _context.Items.Where(dataItem => filters.LastNameFilter.Any(text => dataItem.LastName != null && dataItem.LastName.Contains(text)));
            }

            if (data != null)
            {
                var viewData = await data.ToListAsync();
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataItem == null)
            {
                return NotFound();
            }

            return View(dataItem);
        }

        // GET: DataItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name, LastName")] DataItem dataItem)
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

            var dataItem = await _context.Items.FindAsync(id);
            if (dataItem == null)
            {
                return NotFound();
            }
            return View(dataItem);
        }

        // POST: DataItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DataItem dataItem)
        {
            if (id != dataItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataItem);
                    await _context.SaveChangesAsync();
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
