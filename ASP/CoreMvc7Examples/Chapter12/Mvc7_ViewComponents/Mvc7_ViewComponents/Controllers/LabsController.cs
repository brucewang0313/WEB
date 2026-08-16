using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Mvc7_ViewComponents.Controllers
{
    public class LabsController : Controller
    {
        private readonly ILogger _logger;

        public LabsController(ILogger<LabsController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        //
        public IActionResult Pokemon()
        {
            return View();
        }

        public async Task<IActionResult> HttpClientPokemon()
        {
            /*程式移至View
            int maxCounter = 0;

            HttpClient client = new HttpClient();

            for (int i = 1; i < 10; i++)
            {
                string imageUrl = $"https://assets.pokemon.com/assets/cms2/img/pokedex/detail/{i.ToString("000")}.png";

                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/image"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(imageUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        maxCounter = i;
                    }
                }
                catch (Exception ex)
                {
                    client.Dispose();
                }
            }
            */

            return View();
        }


        //Display Website
        //http://localhost:xxxx/Labs/GetWebsite/www.tenlong.com.tw

        public async Task<IActionResult> GetWebsite(string id)
        {
            string websiteUrl = id;
            if (string.IsNullOrEmpty(websiteUrl))
            {
                websiteUrl = $"https://www.tenlong.com.tw";
            }
            else
            {
                websiteUrl = $"https://{id}";
            }

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(websiteUrl);

                if (response.IsSuccessStatusCode)
                {
                    string htmlContent = await response.Content.ReadAsStringAsync();

                    ViewData["WebSite"] = htmlContent;
                }
            }
            catch (Exception ex)
            {
                //Logger寫入的目標之一為Windows事件檢視器
                _logger.LogError(ex.ToString());
            }
            finally
            {
                client.Dispose();
            }

            return View();
        }
    }
}