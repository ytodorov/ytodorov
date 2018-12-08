namespace ytodorov.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Models;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    public class ItemController : Controller
    {
        private readonly IDocumentDBRepository<ytodorov.Models.Item> Respository;
        public ItemController(IDocumentDBRepository<ytodorov.Models.Item> Respository)
        {
            this.Respository = Respository;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await Respository.GetItemsAsync(d => !d.Completed);
            return View(items);
        }

        [ActionName("KendoRead")]
        public async Task<ActionResult> KendoRead()
        {
            var items = await Respository.GetItemsAsync(d => true);

            return Json(items);
        }

        [ActionName("KendoCreate")]
        public async Task<ActionResult> KendoCreate(string models)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(models);


            if (items != null && ModelState.IsValid)
            {
                Item item = items.FirstOrDefault();
                var res = await Respository.CreateItemAsync(item);
                item.Id = res.Id;
                
            }

            return Json(items);
        }

        [ActionName("KendoUpdate")]
        public async Task<ActionResult> KendoUpdate(string models)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(models);

            if (items != null && ModelState.IsValid)
            {
                Item item = items.FirstOrDefault();
                await Respository.UpdateItemAsync(item.Id, item);
            }

            return Json(items);
        }

        [ActionName("KendoDestroy")]
        public async Task<ActionResult> KendoDestroy(string models)
        {
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(models);

            if (items != null && ModelState.IsValid)
            {
                Item item = items.FirstOrDefault();
                await Respository.DeleteItemAsync(item.Id);
            }

            return Json(items);
        }







#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Id,Name,Description,Completed")] Item item)
        {
            if (ModelState.IsValid)
            {
                await Respository.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Id,Name,Description,Completed")] Item item)
        {
            if (ModelState.IsValid)
            {
                await Respository.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await Respository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await Respository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await Respository.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Item item = await Respository.GetItemAsync(id);
            return View(item);
        }
    }

}