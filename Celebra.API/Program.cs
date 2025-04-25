using Celebra.Business;
using Celebra.Business.Services.BirthdayReminder;
using Celebra.DAL.Contexts;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServiceRegistration.AddServices(builder.Services);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("MSSQL")));
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IBirthdayReminderService>(
    "birthday-reminder-job",
    x => x.CheckBirthdaysAsync(),
    Cron.Minutely,
    TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time")
);


app.UseStaticFiles();

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
