

using UIRSHOP.WEBAPP.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<ProductService>(client =>
{
	client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<CategorieService>();
builder.Services.AddHttpClient<ProductService>(client =>
{
	client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddHttpClient<SubCategoryService>(client =>
{
	client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<SubCategoryService>();
builder.Services.AddHttpClient<SupplierService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<SupplierService>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
