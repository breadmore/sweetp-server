using Microsoft.EntityFrameworkCore;
using sweetp_server.Data;
using sweetp_server.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<PlayerContext>(opt => opt.UseInMemoryDatabase("PlayerList"));

builder.Services.AddDbContext<Player_TBContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Player_DataContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Player_RecordContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Weapon_TBContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Weapon_DataContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Weapon_MarketContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<Player_ScrollContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SweetP API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
 * if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SweetP API V1");
        //c.RoutePrefix = string.Empty; // 루트 경로에서 Swagger UI 접근을 원할 경우 주석 해제

        // 추가적인 구성: Swagger UI를 사용하기 위해 필요한 인증 설정을 제거
    });
}
 */

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SweetP API V1");
    //c.RoutePrefix = string.Empty; // 루트 경로에서 Swagger UI 접근을 원할 경우 주석 해제

    // 추가적인 구성: Swagger UI를 사용하기 위해 필요한 인증 설정을 제거
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
