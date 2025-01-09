using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftWhatsAppCRMDash.Data;
using SoftWhatsAppCRMDash.Models;
using SoftWhatsAppCRMDash.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoftWhatsAppCRMDash.Controllers
{
    [Route("Crm")]
    public class CrmController : Controller
    {
        private readonly WhatsAppCrmContext _context;
        public CrmController(WhatsAppCrmContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Client")]
        public async Task<IActionResult> Client()
        {
            List<ClientVM> clients = new List<ClientVM>();
            try
            {
                var clientsDb = await _context.Clientes.ToListAsync();
                clients= clientsDb.Select(client => new ClientVM
                {
                    Id = client.Id,
                    Nombre = client.Nombre,
                    Numero = client.Numero,
                    Photo = client.Photo,
                    StateColor=GetStateColor((StateChat)client.StateChat),
                    StateName=GetStateName((StateChat)client.StateChat),
                    StateUpdate=(int)GetStateUpdate((StateChat)client.StateChat)
                    
                }).OrderBy(client=>client.Id).ToList();
                return View(clients);
            }
            catch (Exception ex)
            {
                
                return View(clients);
            }
        }

        [HttpPost("Client/{id}")]
        public async Task<IActionResult> UpdateStateClient(int id,ClientCreateVM clientCreateVM)
        {
            try
            {

                var client=await _context.Clientes.FindAsync(id);
                if (client == null)
                {
                    return NotFound();
                }
                client.StateChat = clientCreateVM.StateChat;
                _context.Update(client);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Client));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Client));
            }
        }
        [HttpGet]
        [Route("client/{id}")]
        public  async Task<IActionResult> Index(int id)
        {
            var client=await _context.Clientes.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        private string GetStateName(StateChat state)
        {
            switch (state)
            {
                case StateChat.ActiveChat:
                    return "Desactivar";
                case StateChat.InactiveChat:
                    return "Activar";
                default:
                    return "Desconocido";
            }
        }

        private StateChat GetStateUpdate(StateChat state)
        {
            switch (state)
            {
                case StateChat.ActiveChat:
                    return StateChat.InactiveChat;
                case StateChat.InactiveChat:
                    return StateChat.ActiveChat;
                default:
                    return StateChat.InactiveChat;
            }
        }
        private string GetStateColor(StateChat state)
        {
            switch (state) { 
                case StateChat.ActiveChat:
                    return "bg-green-500";
                case StateChat.InactiveChat:
                    return "bg-red-500";
                default:
                    return "bg-yellow-500";
            }
        }


    }

   
    public enum StateChat
    {
        ActiveChat=1,
        InactiveChat=2,
    }
}
