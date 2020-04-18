using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcH.Data;
using MvcH.Models;

namespace MvcH.Controllers
{
    public class RelationsController : Controller
    {
        private readonly MvcHContext _context;

        public RelationsController(MvcHContext context)
        {
            _context = context;
        }

        // GET: Relations
        public async Task<IActionResult> Index()
        {
            var mvcHContext = _context.Relation.Include(r => r.Doctor).Include(r => r.Hospital).Include(r => r.Patient).Include(r => r.Room);
            return View(await mvcHContext.ToListAsync());
        }

        // GET: Relations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relation = await _context.Relation
                .Include(r => r.Doctor)
                .Include(r => r.Hospital)
                .Include(r => r.Patient)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (relation == null)
            {
                return NotFound();
            }

            return View(relation);
        }

        // GET: Relations/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "FullName");
            ViewData["HospitalID"] = new SelectList(_context.Hospital, "Id", "Name");
            ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Title");
            return View();
        }

        // POST: Relations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,HospitalID,RoomID,DoctorID")] Relation relation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "Id", relation.DoctorID);
            ViewData["HospitalID"] = new SelectList(_context.Hospital, "Id", "Id", relation.HospitalID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "Id", relation.PatientID);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", relation.RoomID);

            return View(relation);
        }

        // GET: Relations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relation = await _context.Relation.FindAsync(id);
            if (relation == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "FullName", relation.DoctorID);
            ViewData["HospitalID"] = new SelectList(_context.Hospital, "Id", "Name", relation.HospitalID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "FullName", relation.PatientID);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Title", relation.RoomID);
            return View(relation);
        }

        // POST: Relations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,HospitalID,RoomID,DoctorID")] Relation relation)
        {
            if (id != relation.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelationExists(relation.PatientID))
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
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "Id", relation.DoctorID);
            ViewData["HospitalID"] = new SelectList(_context.Hospital, "Id", "Id", relation.HospitalID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "Id", "Id", relation.PatientID);
            ViewData["RoomID"] = new SelectList(_context.Room, "Id", "Id", relation.RoomID);
            return View(relation);
        }

        // GET: Relations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relation = await _context.Relation
                .Include(r => r.Doctor)
                .Include(r => r.Hospital)
                .Include(r => r.Patient)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (relation == null)
            {
                return NotFound();
            }

            return View(relation);
        }

        // POST: Relations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relation = await _context.Relation.FindAsync(id);
            _context.Relation.Remove(relation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelationExists(int id)
        {
            return _context.Relation.Any(e => e.PatientID == id);
        }
    }
}
