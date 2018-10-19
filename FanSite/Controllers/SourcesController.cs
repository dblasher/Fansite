using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanSite.Models;
using System.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FanSite.Controllers
{
    public class SourcesController : Controller
    {
        
        public SourcesController()
        {
            //I was putting test data here for books and links, these now live in
            //the addTestData methods in LinkRepository and BookRepository
        }

        public ViewResult Print() 
        {
            List<Book> books = BookRepository.Books;
            books.Sort((b1, b2) => b1.Title.CompareTo(b2.Title));
            return View(books);
        }

        public ViewResult Links()
        {
            List<Link> links = LinkRepository.Links;
            links.Sort((l1, l2) => l1.Title.CompareTo(l2.Title));
            return View(links);
        }
        //refer to BookReview project for how to implement multiple controllers
        //return Books and print media (displayed in a table based on the model) 
        //return Links to online media (displayed in a table based on the model)
    }
}
