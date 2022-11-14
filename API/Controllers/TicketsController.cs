using Application.IRepositories.Ticket;
using Application.ViewModels.Ticket;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketReadRepository _ticketReadRepository;
        private readonly ITicketWriteRepository _ticketWriteRepository;



        public TicketsController(ITicketReadRepository ticketReadRepository, ITicketWriteRepository ticketWriteRepository)
        {
            _ticketReadRepository = ticketReadRepository;
            _ticketWriteRepository = ticketWriteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(_ticketReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            return Ok(await _ticketReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(TicketCreateVM model)
        {
            var ticket=new Ticket() { Name=model.Name};
            await _ticketWriteRepository.AddAsync(ticket);
            await _ticketWriteRepository.SaveAsync();
            return Ok(ticket);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Ticket model)
        {
            Ticket ticket = await _ticketReadRepository.GetByIdGuidAsync(model.Id);

            ticket.Name = model.Name;
         
            await _ticketWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ticketWriteRepository.RemoveAsync(id);
            await _ticketWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
