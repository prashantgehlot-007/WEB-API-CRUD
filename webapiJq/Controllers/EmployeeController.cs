using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using webapiJq.Models;

namespace webapiJq.Controllers
{
    public class EmployeeController : ApiController
    {
        Database1Entities db = new Database1Entities();

        // GET: api/Employee
        public List<Emp> Get()
        {
            List<Emp> emps = db.Emps.ToList();
            return emps;
        }
        //public IQueryable<Emp> GetEmps()
        //{
        //    return db.Emps;
        //}

        // GET: api/Employee/5
        public Emp Get(int id)
        {
            var res = from k in db.Emps
                      where k.ECode == id
                      select k;
            Emp t = (Emp)res.FirstOrDefault();
            return t;
        }
        //[ResponseType(typeof(Emp))]
        //public IHttpActionResult GetEmp(int id)
        //{
        //    Emp emp = db.Emps.Find(id);
        //    if (emp == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(emp);
        //}

        // PUT: api/Employee/5
        public void Put(Emp t)
        {
            var res = from k in db.Emps
                      where k.ECode == t.ECode
                      select k;
            Emp e = (Emp)res.FirstOrDefault();
            e.EName = t.EName;
            e.ESal = t.ESal;
            db.SaveChanges();         
        }
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEmp(int id, Emp emp)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != emp.ECode)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(emp).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmpExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Employee

        public void PostEmp(Emp emp)
        {
            Database1Entities db = new Database1Entities();
            db.Emps.Add(emp);
            db.SaveChanges();
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            var res = from k in db.Emps
                      where k.ECode == id
                      select k;
            Emp e = (Emp)res.FirstOrDefault();
            db.Emps.Remove(e);
            db.SaveChanges();
            
        }
        //[ResponseType(typeof(Emp))]
        //public IHttpActionResult DeleteEmp(int id)
        //{
        //    Emp emp = db.Emps.Find(id);
        //    if (emp == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Emps.Remove(emp);
        //    db.SaveChanges();

        //    return Ok(emp);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpExists(int id)
        {
            return db.Emps.Count(e => e.ECode == id) > 0;
        }
    }
}