using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppWebAPI.Models;

namespace ToDoAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoListContext _context;

        public ToDoListController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: api/ToDoList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListItem>>> GetToDoList()
        {
            return await _context.ToDoList.ToListAsync();
        }

        // GET: api/ToDoList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListItem>> GetToDoListItem(int id)
        {
            var toDoListItem = await _context.ToDoList.FindAsync(id);

            if (toDoListItem == null)
            {
                return NotFound();
            }

            return toDoListItem;
        }

        // PUT: api/ToDoList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoListItem toDoListItem)
        {
            if (id != toDoListItem.ToDoId)
            {
                return BadRequest();
            }

            _context.Entry(toDoListItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoList
        [HttpPost]
        public async Task<ActionResult<ToDoListItem>> PostToDoItem(ToDoListItem toDoListItem)
        {
            _context.ToDoList.Add(toDoListItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoListItem", new { id = toDoListItem.ToDoId }, toDoListItem);
        }

        // DELETE: api/ToDoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItemToDelete = await _context.ToDoList.FindAsync(id);
            if (toDoItemToDelete == null)
            {
                return NotFound();
            }

            _context.ToDoList.Remove(toDoItemToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoListItemExists(int id)
        {
            return _context.ToDoList.Any(item => item.ToDoId == id);
        }
    }
}

