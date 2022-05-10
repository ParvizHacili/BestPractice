using AutoMapper;
using BP.API.Data.Models;
using BP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BP.API.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public ContactService(IMapper Mapper,IHttpClientFactory HttpClientFactory)
        {
            mapper = Mapper;
            httpClientFactory = HttpClientFactory;
        }

        public ContactDVO GetContactById(int id)
        {
            Contact dbContact = getDummyContact();

            var client = httpClientFactory.CreateClient("garantiapi");

            ContactDVO resultContact = mapper.Map<ContactDVO>(dbContact);

            return resultContact;
        }


        private Contact getDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Parviz",
                LastName = "Hajili"
            };
        }
    }
}
