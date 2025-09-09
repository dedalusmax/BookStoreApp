using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        if (repository == null) throw new ArgumentNullException(nameof(repository));

        _repository = repository;
    }

    // GET: Book
    public ActionResult Index()
    {
        return View(_repository.GetAllBooks());
    }

    // GET: Book/Details/5
    public ActionResult Details(int id)
    {
        return View(_repository.GetBookById(id));
    }

    // GET: Book/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Book/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Book model)
    {
        try
        {
            _repository.AddBook(model);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Book/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Book model)
    {
        try
        {
            _repository.UpdateBook(model);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Book/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Book/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Book model)
    {
        try
        {
            _repository.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}

