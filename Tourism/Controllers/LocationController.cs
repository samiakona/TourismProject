using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tourism.AggregateRoot.Model;
using Tourism.DTO;
using Tourism.Handler;

namespace Tourism.MVC.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationHandler _locationHandler;
        public LocationController(ILocationHandler locationHandler)
        {
            _locationHandler = locationHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string searchString)
        {
            var locations = _locationHandler.GetLocations(searchString);
            return View(locations);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationDTO locationDto)
        {
            if(ModelState.IsValid)
            {
                _locationHandler.CreateLocation(locationDto);
                TempData["success"] = "Location Created Successful..";
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Edit(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            if (location == null) 
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(LocationDTO locationDto)
        {
            if (ModelState.IsValid) 
            {
                _locationHandler.UpdateLocation(locationDto);
                TempData["success"] = "Location Update successful..";
                return RedirectToAction("Index");
            }
           
            return View(locationDto);
        }


        public IActionResult Delete(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            if(location == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeletePost(int id)
        {
            _locationHandler.DeleteLocation(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var location = _locationHandler.GetLocationById(id);
            if(location == null)
            {
                return NotFound();
            }
            return View(location);
        }





    }
}
