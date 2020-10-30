using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebApplication.Models;
using FirstWebApplication.Services;

namespace FirstWebApplication.Controllers
{

    public class PhonesController : Controller
    {
        private PhonesService serv = new PhonesService();
        private readonly PhonesContext _context;

        public PhonesController(PhonesContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            var phones = serv.GetPhones();
            return View(phones);
            //return View(await _context.Phones.ToListAsync());
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var phone = await _context.Phones
            //    .FirstOrDefaultAsync(m => m.IdPhone == id);
            var phone = serv.GetPhone(Convert.ToInt32(id)); 
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("Brand,Model,Price,Image")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                serv.AddPhone(phone);
                //_context.Add(phone);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var phone = await _context.Phones.FindAsync(id);
            var phone = serv.GetPhone(Convert.ToInt32(id));
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhone,Brand,Model,Price,Image")] Phone phone)
        {
            if (id != phone.IdPhone)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(phone);
                    //await _context.SaveChangesAsync();
                    serv.UpdatePhone(phone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.IdPhone))
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
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var phone = await _context.Phones
            //    .FirstOrDefaultAsync(m => m.IdPhone == id);
            var phone = serv.GetPhone(Convert.ToInt32(id));
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var phone = await _context.Phones.FindAsync(id);
            //_context.Phones.Remove(phone);
            //await _context.SaveChangesAsync();

            serv.DeletePhone(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.IdPhone == id);
        }
    }
}
