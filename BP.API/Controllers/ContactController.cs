using BP.API.Models;
using BP.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace BP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;
        private readonly ILogger<ContactController> logger;
        public ContactController(IConfiguration Configuration, IContactService ContactService, ILogger<ContactController> Logger)
        {
            configuration = Configuration;
            contactService = ContactService;
            logger = Logger;
        }

        [HttpGet]
        public String Get()
        {
            //10.48
            logger.LogTrace("LogTrace => Get method is called");
            logger.LogDebug("LogDebug => Get method is called");
            logger.LogInformation("LogInformation => Get method is called");
            logger.LogWarning("LogWarning => Get method is called");
            logger.LogError("LogError => Get method is called");


            return configuration["ReadMe"].ToString();
        }

        [ResponseCache (Duration =10)]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {
            //create contact on db
            return contact;
        }
    }
}
