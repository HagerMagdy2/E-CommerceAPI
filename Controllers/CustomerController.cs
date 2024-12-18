﻿
using E_CommerceAPI.DTOs.CustomerDTO;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public CustomerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpPost]
        public IActionResult create(AddCustomerDTO customer)
        {
            Customer cust = new Customer()
            {
                Email = customer.email,
                UserName = customer.username,
                Address = customer.Address,
                PhoneNumber = customer.phonenumber,
                fullname = customer.fullname,
            };
            IdentityResult result = userManager.CreateAsync(cust, customer.password).Result;
            if (result.Succeeded)
            {
                IdentityRole _role = roleManager.FindByNameAsync("customer").Result;
                // roleManager.FindByNameAsync("customer").Result;
                // await _role=  roleManager.FindByNameAsync("customer");
                if (_role != null)
                {
                    IdentityResult roleResult = userManager.AddToRoleAsync(cust, _role.Name).Result;
                    if (roleResult.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }

                }
                return BadRequest();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPut]
        public IActionResult editprofile(EditCustomerDTO _customer)
        {
            if (ModelState.IsValid)
            {
                Customer cust = (Customer)userManager.FindByIdAsync(_customer.id).Result;
                if (cust == null) return NotFound();
                cust.fullname = _customer.fullname;
                cust.UserName = _customer.username;
                cust.Address = _customer.fullname;
                cust.PhoneNumber = _customer.phonenumber;
                cust.Email = _customer.email;

                var result = userManager.UpdateAsync(cust).Result;
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else { return BadRequest(result.Errors); }

            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost("changepassword")]
        public IActionResult changePassword(ChangePasswordDTO _changePassword)
        {
            if (ModelState.IsValid)
            {
                Customer cust = (Customer)userManager.FindByIdAsync(_changePassword.id).Result;
                if (cust == null) return NotFound();
                var result = userManager.ChangePasswordAsync(cust, _changePassword.old_password, _changePassword.newPassword).Result;
                if (result.Succeeded)
                {
                    return Ok("change Passsword Successfully");
                }
                else { return BadRequest(result.Errors); }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        // [Authorize(Roles ="admin")]
        //  [AllowAnonymous]
        public IActionResult getAll()
        {
            var customers = userManager.GetUsersInRoleAsync("customer").Result.OfType<Customer>().ToList();
            if (!customers.Any()) return NotFound();
            List<SelectCustomerDTO> CustomerDTO = new List<SelectCustomerDTO>();
            foreach (var cust in customers)
            {
                SelectCustomerDTO custDTO = new SelectCustomerDTO()
                {
                    id = cust.Id,
                    fullname = cust.fullname,
                    username = cust.UserName,
                    email = cust.Email,
                    Address = cust.Address,
                    phonenumber = cust.PhoneNumber
                };
                CustomerDTO.Add(custDTO);
            }
            return Ok(CustomerDTO);
        }
        [HttpGet("{id}")]
        public IActionResult getById(string id)
        {
            //By Role
            var cus = (Customer)userManager.GetUsersInRoleAsync("customer").Result.Where(n => n.Id == id).FirstOrDefault();
            //tofind any user without role
            // var cust = (Customer)userManager.FindByIdAsync(id).Result;
            if (cus == null) return NotFound();
            SelectCustomerDTO CustomerDTO = new SelectCustomerDTO()
            {
                id = cus.Id,
                fullname = cus.fullname,
                username = cus.UserName,
                email = cus.Email,
                Address = cus.Address,
                phonenumber = cus.PhoneNumber,
            };
            return Ok(CustomerDTO);
        }
    }
}
