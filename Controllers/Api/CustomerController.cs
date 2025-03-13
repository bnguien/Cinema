using Microsoft.AspNetCore.Mvc;
using MyMVCApp.Models;
using MyMVCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyMVCApp.ViewModels;

[Route("api/customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;

        if (_context.Customers.Count() == 0)
        {
            _context.Customers.Add(new Customer { Name = "Item1" });
            _context.SaveChanges();
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    // GET: api/Customer
    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _context.Customers
            .Include(c => c.MembershipType)
            .Select(c => new CustomerFormViewModel
            {
                Customer = c
            })
            .ToList();

        return Ok(customers);
    }


    // GET: api/Customer/5
    [HttpGet("{id}", Name = "GetCustomer")]
    public ActionResult<Customer> GetById(int id)
    {
        var item = _context.Customers.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    // POST: api/Customer
    [HttpPost]
    public IActionResult Create(Customer item)
    {
        _context.Customers.Add(item);
        _context.SaveChanges();

        return CreatedAtRoute("GetCustomer", new { id = item.Id }, item);
    }
    // PUT: api/Customer/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer item)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }

        customer.Name = item.Name;

        _context.Customers.Update(customer);
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Customer/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(Convert.ToInt32(id));
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        _context.SaveChanges();
        return NoContent();
    }
}