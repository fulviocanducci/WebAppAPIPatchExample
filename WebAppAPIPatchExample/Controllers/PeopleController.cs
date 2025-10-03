using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using WebAppAPIPatchExample.Models;
namespace WebAppAPIPatchExample.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public PeopleController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<People>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<People>> Get()
        {
            return Ok(_databaseContext.People);
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<People>> Get(int id)
        {
            People? result = await _databaseContext.People.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<People>> Create(People entity)
        {
            if (ModelState.IsProblem())
            {
                return BadRequest(ModelState);
            }
            await _databaseContext.People.AddAsync(entity);
            _databaseContext.SaveChanges();
            return Ok(entity);
        }

        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<People>> Update(int id, [FromBody] JsonPatchDocument<People> changes)
        {
            try
            {
                People? result = await _databaseContext.People.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return NotFound();
                }
                changes.ApplyTo(result, ModelState);
                TryValidateModel(result);
                if (ModelState.IsProblem())
                {
                    return BadRequest(ModelState);
                }
                _databaseContext.SaveChanges();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

