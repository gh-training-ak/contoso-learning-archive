using Contoso.Application.Abstractions;
using Contoso.Application.Services;
using Contoso.Infrastructure.Persistence;
using Contoso.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContosoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Contoso")));

builder.Services.AddScoped<IMentorRepository, MentorRepository>();
builder.Services.AddScoped<MentorSearchService>();
builder.Services.AddScoped<MatchRequestService>();
builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddDbContextCheck<ContosoDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();

public partial class Program;
