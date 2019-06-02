using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly MELOCHICOUTContext _context;

        public PedidoesController(MELOCHICOUTContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var mELOCHICOUTContext = _context.Pedido.Include(p => p.IdFormaPagamentoNavigation).Include(p => p.IdUsuarioNavigation);
            return View(await mELOCHICOUTContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.IdFormaPagamentoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .SingleOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdFormaPagamento"] = new SelectList(_context.FormaPagamento, "IdFormaPagamento", "DescricaoFp");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdUsuario,IdFormaPagamento,DataPedido,DataEntrega,ValorPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFormaPagamento"] = new SelectList(_context.FormaPagamento, "IdFormaPagamento", "DescricaoFp", pedido.IdFormaPagamento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", pedido.IdUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.SingleOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdFormaPagamento"] = new SelectList(_context.FormaPagamento, "IdFormaPagamento", "DescricaoFp", pedido.IdFormaPagamento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", pedido.IdUsuario);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdUsuario,IdFormaPagamento,DataPedido,DataEntrega,ValorPedido")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            ViewData["IdFormaPagamento"] = new SelectList(_context.FormaPagamento, "IdFormaPagamento", "DescricaoFp", pedido.IdFormaPagamento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Cpf", pedido.IdUsuario);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.IdFormaPagamentoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .SingleOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.SingleOrDefaultAsync(m => m.IdPedido == id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.IdPedido == id);
        }
    }
}
