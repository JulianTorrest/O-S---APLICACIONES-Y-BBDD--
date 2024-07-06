// Models/Customer.cs
public class Customer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool HasAuthorized { get; set; }
    public DateTime CreatedAt { get; set; }
}

// Models/OperationCenter.cs
public class OperationCenter
{
    public int CenterID { get; set; }
    public string CenterName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public DateTime CreatedAt { get; set; }
}

// Models/CustomerEntry.cs
public class CustomerEntry
{
    public int EntryID { get; set; }
    public int CustomerID { get; set; }
    public int CenterID { get; set; }
    public DateTime EntryDate { get; set; }
    public bool HasAuthorized { get; set; }

    public Customer Customer { get; set; }
    public OperationCenter OperationCenter { get; set; }
}

