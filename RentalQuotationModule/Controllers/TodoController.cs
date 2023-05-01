using Microsoft.AspNetCore.Mvc;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentalQuotationModule.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoService _toDoService;

        public ToDoController(ITodoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<IActionResult> Index()
        {
            var toDos = await _toDoService.GetAllAsync();
            var toDoViewModels = toDos.Select(t => new ToDoViewModel
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            }).ToList();
            return View(toDoViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoViewModel toDoViewModel)
        {
            if (ModelState.IsValid)
            {
                var toDo = new Todo
                {
                    Title = toDoViewModel.Title,
                    IsCompleted = toDoViewModel.IsCompleted
                };
                await _toDoService.AddAsync(toDo);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var toDo = await _toDoService.GetByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            var toDoViewModel = new ToDoViewModel
            {
                Id = toDo.Id,
                Title = toDo.Title,
                IsCompleted = toDo.IsCompleted
            };
            return View(toDoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ToDoViewModel toDoViewModel)
        {
            if (id != toDoViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var toDo = await _toDoService.GetByIdAsync(id);
                toDo.Title = toDoViewModel.Title;
                toDo.IsCompleted = toDoViewModel.IsCompleted;
                await _toDoService.UpdateAsync(toDo);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var toDo = await _toDoService.GetByIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            var toDoViewModel = new ToDoViewModel
            {
                Id = toDo.Id,
                Title = toDo.Title,
                IsCompleted = toDo.IsCompleted
            };
            return View(toDoViewModel);
        }
    }
}
