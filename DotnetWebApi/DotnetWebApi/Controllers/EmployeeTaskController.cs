using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotnetWebApi.Data;
using DotnetWebApi.Model;

namespace DotnetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly CrudContext _context;

        public EmployeeTaskController(CrudContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTask>>> GetEmployeeTasks()
        {
            return await _context.EmployeeTasks.Include(e => e.AssignedEmployee).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTask>> GetEmployeeTask(int id)
        {
            var employeeTask = await _context.EmployeeTasks.FindAsync(id);

            if (employeeTask == null)
            {
                return NotFound();
            }

            return employeeTask;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeTask>> PutEmployeeTask(int id, EmployeeTask employeeTask)
        {
            if (id != employeeTask.ID)
            {
                return BadRequest();
            }

            _context.Entry(employeeTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return employeeTask;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeTask>> PostEmployeeTask(EmployeeTask employeeTask)
        {
            employeeTask.CreatedAt = DateTime.Now;
            _context.EmployeeTasks.Add(employeeTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeTask", new { id = employeeTask.ID }, employeeTask);
        }

        [HttpDelete]
        public async Task<ActionResult<List<EmployeeTask>>> DeleteEmployeeTask(int[] id)
        {
            var employeeTask = _context.EmployeeTasks.Where(x => id.Contains(x.ID)).ToList();
            if (employeeTask == null)
            {
                return NotFound();
            }

            _context.EmployeeTasks.RemoveRange(employeeTask);
            await _context.SaveChangesAsync();

            return employeeTask;
        }

        private bool EmployeeTaskExists(int id)
        {
            return _context.EmployeeTasks.Any(e => e.ID == id);
        }
    }
}
