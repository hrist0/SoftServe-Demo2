using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoftServe.Demo2.Models.EmployeeContext;
using SoftServe.Demo2.Models.EmployeesModel;
using PagedList;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SoftServe.Demo2.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: Employees
        public ActionResult Index(string search, string sortOrder, int? page)
        {
            var employees = db.Employees
                .Include(e => e.Project)
                .Include(e => e.Team)
                .OrderBy(e => e.Id);

            // Set page size and pages number
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            // Search employees by name, position, team or project
            employees = SearchEmployees(search, employees);

            // Order employees by some criteria
            employees = OrderEmployees(sortOrder, employees);

            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position,Salary,Workplace,Email,Phone,Address,ProjectId,TeamId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", employee.TeamId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", employee.TeamId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,Salary,Workplace,Email,Phone,Address,ProjectId,TeamId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", employee.TeamId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Searching method by criteria
        private static IOrderedQueryable<Employee> SearchEmployees(string search, IOrderedQueryable<Employee> employees)
        {
            if (!String.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.Name.Contains(search)
                    || e.Position.ToString().Contains(search)
                    || e.Team.Name.Contains(search)
                    || e.Project.ProjectName.Contains(search)
                    || e.Workplace.Contains(search))
                    .OrderBy(e => e.Project.ProjectName);
            }
            return employees;
        }

        // Ordering method by some criteria
        private IOrderedQueryable<Employee> OrderEmployees(string sortOrder, IOrderedQueryable<Employee> employees)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.PositionSort = String.IsNullOrEmpty(sortOrder) ? "position" : "";
            ViewBag.ProjectSort = String.IsNullOrEmpty(sortOrder) ? "project" : "";
            ViewBag.TeamSort = String.IsNullOrEmpty(sortOrder) ? "team" : "";
            ViewBag.WorkplaceSort = String.IsNullOrEmpty(sortOrder) ? "workplace" : "";

            switch (sortOrder)
            {
                case "name":
                    employees = employees.OrderBy(e => e.Name);
                    break;
                case "position":
                    employees = employees.OrderBy(e => e.Position.ToString());
                    break;
                case "project":
                    employees = employees.OrderBy(e => e.Project.ProjectName);
                    break;
                case "team":
                    employees = employees.OrderBy(e => e.Team.Name);
                    break;
                case "workplace":
                    employees = employees.OrderBy(e => e.Workplace);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Id);
                    break;
            }
            return employees;
        }
    }
}
