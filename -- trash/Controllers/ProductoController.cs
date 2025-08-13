using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShopCuzco_AdminPanel.Models;

public class ProductoController : Controller
{
    private readonly ApplicationDbContext _context;
    private const int PageSize = 10;

    public ProductoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Listar(int page = 1)
    {
        var query = _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.Estado);

        var total = await query.CountAsync();
        var productos = await query
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)PageSize);
        ViewBag.Page = page;
        return View(productos);
    }

    public async Task<IActionResult> Habilitar(int page = 1)
    {
        var query = _context.Productos.Include(p => p.Categoria);
        var total = await query.CountAsync();
        var productos = await query
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)PageSize);
        ViewBag.Page = page;
        return View(productos);
    }

    public IActionResult Registrar()
    {
        ViewBag.Categorias = _context.CategoriasProducto.Where(c => c.Estado).ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = _context.CategoriasProducto.Where(c => c.Estado).ToList();
            return View(producto);
        }
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Listar));
    }

    public async Task<IActionResult> Actualizar(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();

        ViewBag.Categorias = _context.CategoriasProducto.Where(c => c.Estado).ToList();
        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Actualizar(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = _context.CategoriasProducto.Where(c => c.Estado).ToList();
            return View(producto);
        }
        _context.Update(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Listar));
    }

    public async Task<IActionResult> Deshabilitar(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            producto.Estado = false;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Listar));
    }

    public async Task<IActionResult> HabilitarProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            producto.Estado = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Habilitar));
    }
}
