﻿using E_CommerceAPI.DTOs.ProductDTO;
using E_CommerceAPI.Models;
using E_CommerceAPI.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        UnitOFWork _unit;
        
        public ProductsController(UnitOFWork _unit)
        {
            this._unit = _unit;
            

        }
        [HttpGet]
       
        public IActionResult getAll()
        {
            List<Product> products = _unit.ProductsRepositry.selectall();
            List<DisplayProductDTO> productsDTO = new List<DisplayProductDTO>();
            foreach (Product product in products)
            {
                DisplayProductDTO productDTO = new DisplayProductDTO()
                {
                    id = product.id,
                    producr_name = product.producr_name,
                    price = product.price,
                    srock = product.stock,
                    category = product.category.name,
                };
                productsDTO.Add(productDTO);
            }
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Product product = _unit.ProductsRepositry.selectbyid(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                DisplayProductDTO productDTO = new DisplayProductDTO()
                {
                    id = product.id,
                    producr_name = product.producr_name,
                    price = product.price,
                   
                    srock = product.stock,
                    category = product.category.name,
                };
                return Ok(productDTO);
            }
        }
        [HttpPost]
        //  [Authorize(Roles ="admin")]
        public IActionResult add(AddProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    producr_name = productDTO.producr_name,
                    price = productDTO.price,
                    
                    stock = productDTO.srock,
                    
                    cat_id = productDTO.cat_id,
                };
                
                _unit.ProductsRepositry.add(product);
                _unit.savechanges();
                return CreatedAtAction("getById", new { id = product.id }, productDTO);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
       
        public IActionResult edit(int id, AddProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                //_unit.BooksRepositry.update
                //fetch by id and change way
                //Book book = _unit.BooksRepositry.selectbyid(id);
                //if (book == null)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    book.title = bookDTO.title;
                //    book.price = bookDTO.price;
                //    book.publishdate = bookDTO.publishdate;
                //    book.srock = bookDTO.srock;
                //    book.author_id = bookDTO.author_id;
                //    book.cat_id = bookDTO.cat_id;
                //}
                Product product = new Product()
                {
                    id = id,
                    producr_name = productDTO.producr_name,
                    price = productDTO.price,
                    
                    stock = productDTO.srock,
                    
                    cat_id = productDTO.cat_id,
                };

                _unit.ProductsRepositry.update(product);
                _unit.savechanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
       
        public IActionResult delete(int id)
        {
            _unit.ProductsRepositry.delete(id);
            _unit.savechanges();
            return Ok();
        }
    }
}