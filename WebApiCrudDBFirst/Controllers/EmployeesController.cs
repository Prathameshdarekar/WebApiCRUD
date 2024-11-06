using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApiCrudDBFirst;

namespace WebApiCrudDBFirst.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        private WebApiCrudDBFirstEntities db = new WebApiCrudDBFirstEntities();

        // GET: api/Employees
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetEmployees()
        {
            return Ok(db.Employees.ToList());
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("{id:int}", Name = "GetEmployee")]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateEmployee([FromBody] Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            // Use the named route "GetEmployee" here
            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateEmployee(int id, [FromBody] Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest("ID mismatch");
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeId == id) > 0;
        }
    }
}
