using E_CommerceAPI.DTOs.CategoryDTO;
using E_CommerceAPI.Models;
using E_CommerceAPI.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        UnitOFWork _unit;
        public CategoryController(UnitOFWork _unit)
        {
            this._unit = _unit;
            
        }
        [HttpGet]

        public IActionResult getAll()
        {
            List<Category> categories = _unit.CategoriesRepositry.selectall();
            List<DisplayCategoryDTO> categoriesDTO = new List<DisplayCategoryDTO>();
            foreach (Category category in categories)
            {
                DisplayCategoryDTO categoeyDTO = new DisplayCategoryDTO()
                {
                    id = category.id,
                    name = category.name,
                    description = category.description,
                };
                categoriesDTO.Add(categoeyDTO);
            }
            return Ok(categoriesDTO);
        }

    
        [HttpPost]
        //  [Authorize(Roles ="admin")]
        public IActionResult add(AddCategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                   name = categoryDTO.name,
                   description = categoryDTO.description,
                };
                _unit.CategoriesRepositry.add(category);
                _unit.savechanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
       // [Authorize(Roles = "admin")]

        public IActionResult edit(int id, AddCategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {

                Category category = new Category()
                {
                    id = id,
                   name = categoryDTO.name,
                   description = categoryDTO.description,
                };

                _unit.CategoriesRepositry.update(category);
                _unit.savechanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
       // [Authorize(Roles = "admin")]

        public IActionResult delete(int id)
        {
            _unit.CategoriesRepositry.delete(id);
            _unit.savechanges();
            return Ok();
        }
    }
}
