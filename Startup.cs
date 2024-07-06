public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<CustomerEntryContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    services.AddControllers();
}

