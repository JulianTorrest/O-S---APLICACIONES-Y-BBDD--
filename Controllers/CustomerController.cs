// Controllers/CustomersController.cs
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomerEntryContext _context;

    public CustomersController(CustomerEntryContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> RegisterCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, customer);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }
}

