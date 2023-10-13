using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApiConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString("hh:mm tt"));
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            var value = _contactService.TGetContactCount(); 
            return Ok(value);
        }
    }
}
