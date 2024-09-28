using Microsoft.EntityFrameworkCore;
using Store.Comman.MapProfile;
using Store.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region CROS 
builder.Services.AddCors(options =>
{
	options.AddPolicy("CustomePolicy",x=> x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region Auto mapper

builder.Services.AddAutoMapper(typeof(MapProduct));

#endregion

#region Database Connection

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
