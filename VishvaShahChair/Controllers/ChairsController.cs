using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VishvaShahChair.Data;
using VishvaShahChair.Models;

namespace VishvaShahChair.Controllers
{
    public class ChairsController : Controller
    {
        private readonly VishvaShahChairContext _context;

        public ChairsController(VishvaShahChairContext context)
        {
            _context = context;
        }

        // GET: Chairs
        /* public async Task<IActionResult> Index()
         {
           return View(await _context.Chair.ToListAsync());
         }*/

        /* public async Task<IActionResult> Index(string searchString)
         {
             var movies = from m in _context.Chair
                          select m;

             if (!String.IsNullOrEmpty(searchString))
             {
                 movies = movies.Where(s => s.Type.Contains(searchString));
             }

             return View(await movies.ToListAsync());
         }
        */

        /*  public async Task<IActionResult> Index(string searchString)
          {
              var chairs = from m in _context.Chair
                           select m;

              if (!String.IsNullOrEmpty(searchString))
              {
                  chairs = chairs.Where(s => s.Type.Contains(searchString));
              }

              return View(await chairs.ToListAsync());
          }*/

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Chair
                                            orderby m.ErgonomicDesign
                                            select m.ErgonomicDesign;

            var movies = from m in _context.Chair
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Type.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.ErgonomicDesign == movieGenre);
            }

            var movieGenreVM = new ChairErgonomicDesignViewModel
            {
                ErgonomicDesigns = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Chairs = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        /* public async Task<IActionResult> Index(string id)
         {
             var movies = from m in _context.Chair
                          select m;

             if (!String.IsNullOrEmpty(id))
             {
                 movies = movies.Where(s => s.Type.Contains(id));
             }

             return View(await movies.ToListAsync());
         }*/
        // GET: Movies
        // GET: Movies


        // GET: Chairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // GET: Chairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Material,Color,ErgonomicDesign,Accessories,Price,Ratings")] Chair chair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chair);
        }

        // GET: Chairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair.FindAsync(id);
            if (chair == null)
            {
                return NotFound();
            }
            return View(chair);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Material,Color,ErgonomicDesign,Accessories,Price,Ratings")] Chair chair)
        {
            if (id != chair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChairExists(chair.Id))
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
            return View(chair);
        }

        // GET: Chairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chair = await _context.Chair
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chair == null)
            {
                return NotFound();
            }

            return View(chair);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chair = await _context.Chair.FindAsync(id);
            _context.Chair.Remove(chair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChairExists(int id)
        {
            return _context.Chair.Any(e => e.Id == id);
        }
    }
}
