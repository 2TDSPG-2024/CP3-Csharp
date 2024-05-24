using Microsoft.AspNetCore.Mvc;
using CP3.Models;
using CP3.Persistence.Repositorys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CP3.MVC.Controllers
{
    public class StudentsController(IRepository<Student> context, IRepository<StudentClass> contextClasses)
        : Controller
    {
        // GET: Students
        public IActionResult Index()
        {
            return View(context.GetAll());
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["StudentClassId"] = new SelectList(contextClasses.GetAll(), "StudentClassId", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,StudentClassId,Name,Email,Identification,Active,CreationUser,CreationDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                TempData["StudentName"] = student.Name;

                if (context.GetAll().SingleOrDefault(x=> x.Email == student.Email) is not null )  
                    return RedirectToAction(nameof(Funny)) ;
               
                context.Add(student);
               
                ProducerKafka.ProducerKafka.Producer(student);

                return RedirectToAction(nameof(Success));
            }
            ViewData["StudentClassId"] = new SelectList(contextClasses.GetAll(), "StudentClassId", "Name");

            return View(student);
        }


        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Funny()
        {
            return View();
        }
    }
}
