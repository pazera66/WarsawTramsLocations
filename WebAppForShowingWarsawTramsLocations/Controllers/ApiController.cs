using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppForShowingWarsawTramsLocalization.Models;
using WebAppForShowingWarsawTramsLocations.Models;

namespace WebAppForShowingWarsawTramsLocations.Controllers
{

    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IUserRepository UserRepo;
        private readonly IRepository<TramLocation> TramsRepo;
        private readonly HttpClient Client;
        private readonly DatabaseContext.DatabaseContext context;

        public ApiController(IUserRepository userRepo, IRepository<TramLocation> tramsRepo, DatabaseContext.DatabaseContext context)
        {
            UserRepo = userRepo;
            TramsRepo = tramsRepo;
            this.context = context;
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpPost("TramsLocations")]
        public async Task<IActionResult> UpdateTramsLocations([FromBody] Credentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }  

            try
            {
                var user = UserRepo.SearchFor(x => x.Login.Equals(credentials.Login)).Single();

                if (!user.UserRole.Role.Code.Equals("ADMIN"))
                {
                    return Unauthorized();
                }

                if (user.Password.Equals(HashPassword(credentials.Password)))
                {
                    HttpResponseMessage response = await Client.GetAsync("https://api.um.warszawa.pl/api/action/wsstore_get/?id=c7238cfe-8b1f-4c38-bb4a-de386db7e776&apikey=a4160f82-2926-42b8-9966-a340cbd89512");
                    Task<string> responseContent = response.Content.ReadAsStringAsync();
                    Thread.Sleep(4000);

                    WarsawApiResult externalApiCallResult =
                        JsonConvert.DeserializeObject<WarsawApiResult>(responseContent.Result);
                    var listOfWebTramsLocations = externalApiCallResult.result;

                    if (listOfWebTramsLocations.Count <= 0) return NoContent();
                    context.RemoveRange(TramsRepo.GetAll());
                    context.SaveChanges();

                    var listOfTramLocations = listOfWebTramsLocations.Select(x => x.ToEntity());

                    foreach (var tramLocation in listOfTramLocations)
                    {
                        TramsRepo.Insert(tramLocation);
                    }

                    context.SaveChanges();

                    return Ok();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestResult();
            }

            return Unauthorized();
        }

        [HttpGet("TramsLocation")]
        public List<WebTramLocation> GetTramsLocation()
        {
            return TramsRepo.GetAll().Select(x => new WebTramLocation(x)).ToList();
        }

        private static string HashPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var dataForHash = Encoding.ASCII.GetBytes(password);
            var hash = sha1.ComputeHash(dataForHash);
            string hashedPassword = Convert.ToBase64String(hash);
            return hashedPassword;
        }
    }
}