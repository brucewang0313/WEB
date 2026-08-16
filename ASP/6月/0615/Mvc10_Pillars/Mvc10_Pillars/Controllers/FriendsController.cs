
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc10_Pillars.Models;

public class FriendsController : Controller
{
    private readonly Mvc10_FriendContext _context;

    public FriendsController(Mvc10_FriendContext context)
    {
        _context = context;
    }

    // GET: FRIENDS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Friend.ToListAsync());
    }

    // GET: FRIENDS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var friend = await _context.Friend
            .FirstOrDefaultAsync(m => m.Id == id);
        if (friend == null)
        {
            return NotFound();
        }

        return View(friend);
    }

    // GET: FRIENDS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FRIENDS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Phone,Email,City")] Friend friend)
    {
        if (ModelState.IsValid)
        {
            _context.Add(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(friend);
    }

    // GET: FRIENDS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var friend = await _context.Friend.FindAsync(id);
        if (friend == null)
        {
            return NotFound();
        }
        return View(friend);
    }

    // POST: FRIENDS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Phone,Email,City")] Friend friend)
    {
        if (id != friend.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(friend);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExists(friend.Id))
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
        return View(friend);
    }

    // GET: FRIENDS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var friend = await _context.Friend
            .FirstOrDefaultAsync(m => m.Id == id);
        if (friend == null)
        {
            return NotFound();
        }

        return View(friend);
    }

    // POST: FRIENDS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var friend = await _context.Friend.FindAsync(id);
        if (friend != null)
        {
            _context.Friend.Remove(friend);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FriendExists(int? id)
    {
        return _context.Friend.Any(e => e.Id == id);
    }
}
