using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Pastehub.Helpers;
using Pastehub.Models;
using Pastehub.ViewModels;

namespace Pastehub.Controllers
{
    public class PasteController : Controller
    {
        private PastehubRepository _repo;
        private TheModelFactory _factory;

        public PasteController()
        {
            _repo = new PastehubRepository();
            _factory = new TheModelFactory();
        }

        public ActionResult Detail(int id)
        {
            var paste = _repo.GetPasteWithId(id);
            return View(paste);
        }

        public ActionResult MyPastes()
        {
            var userId = User.Identity.GetUserId();
            var myPastes = _repo.GetPastes(userId);
            List<PasteViewModel> pasteViewModels = new List<PasteViewModel>();

            foreach (var myPaste in myPastes)
            {
                pasteViewModels.Add(_factory.CreatePaste(myPaste));
            }

            return View(pasteViewModels);
        }


        public ActionResult PublicPastes()  
        {
            var publicPastes = _repo.GetPublicPastes();
            return View(publicPastes);
        }

        public ActionResult Create()
        {
            var createPastes = new Paste();
            createPastes.SyntaxHighlights = _repo.GetSyntax();
            return View(createPastes);
        }

        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(Paste newPaste)  
        {
            try
            {
                var client = PastehubHttpClient.GetClient();
                newPaste.UserId = User.Identity.GetUserId();

                var serializedItem = JsonConvert.SerializeObject(newPaste);
                var response = await client.PostAsync("/api/pastes",
                    new StringContent(serializedItem, Encoding.Unicode,
                                        "application/json"));
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home");
                else
                {
                    return Content("Error");
                }
            }
            catch (Exception exception)
            {
                return Content(exception.Message);
            }
        }
    }
}