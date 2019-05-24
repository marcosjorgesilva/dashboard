using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDashboard.Models;

namespace WebDashboard.Controllers
{
    public class ItensPedidoesController : Controller
    {
        private readonly WebDashboardContext _context;

        public ItensPedidoesController(WebDashboardContext context)
        {
            _context = context;
        }

        // GET: ItensPedidoes
        public async Task<IActionResult> Index()
        {
            var webDashboardContext = _context.ItensPedido.Include(i => i.Pedido);
            return View(await webDashboardContext.ToListAsync());
        }

        // GET: ItensPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .SingleOrDefaultAsync(m => m.RefIdIPedido == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // GET: ItensPedidoes/Create
        public IActionResult Create()
        {
            ViewData["RefIdIPedido"] = new SelectList(_context.Set<Pedido>(), "IdPedido", "IdPedido");
            return View();
        }

        // POST: ItensPedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantidade,ValorTotal,RefIdIPedido,RefIdProduto")] ItensPedido itensPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itensPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefIdIPedido"] = new SelectList(_context.Set<Pedido>(), "IdPedido", "IdPedido", itensPedido.RefIdIPedido);
            return View(itensPedido);
        }

        // GET: ItensPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido.SingleOrDefaultAsync(m => m.RefIdIPedido == id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            ViewData["RefIdIPedido"] = new SelectList(_context.Set<Pedido>(), "IdPedido", "IdPedido", itensPedido.RefIdIPedido);
            return View(itensPedido);
        }

        // POST: ItensPedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Quantidade,ValorTotal,RefIdIPedido,RefIdProduto")] ItensPedido itensPedido)
        {
            if (id != itensPedido.RefIdIPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itensPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItensPedidoExists(itensPedido.RefIdIPedido))
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
            ViewData["RefIdIPedido"] = new SelectList(_context.Set<Pedido>(), "IdPedido", "IdPedido", itensPedido.RefIdIPedido);
            return View(itensPedido);
        }

        // GET: ItensPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .SingleOrDefaultAsync(m => m.RefIdIPedido == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // POST: ItensPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itensPedido = await _context.ItensPedido.SingleOrDefaultAsync(m => m.RefIdIPedido == id);
            _context.ItensPedido.Remove(itensPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItensPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.RefIdIPedido == id);
        }
    }
}
