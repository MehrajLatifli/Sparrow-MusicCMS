

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicCMS_API.Database.DbContext;
using MusicCMS_API.Database.IdentityAuth;
using MusicCMS_Business.Abstract;
using MusicCMS_Business.Concrete;
using MusicCMS_DataAccess.Abstract;
using MusicCMS_DataAccess.Concrete;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvcCore().AddApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {

        Title = "MusicCMS API",
        Version = "v1",
        Description = "Authentication & Authorization"
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Name= "Authorization",
        Type=Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description="Enter `Bearer` [space] and then your valid token in the text input below. \r\n\r\n Example: \"Bearer apikey \""
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            }, new string[]{}
        }
    });
});



builder.Services.AddCors();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers().AddJsonOptions(o =>
{

    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = 2147483648;
});


builder.Services.AddSqlServer<MusicCMSContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<CustomDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("CustomDbConnection")));

builder.Services.AddIdentity<CustomUser,IdentityRole>(options => {
options.User.RequireUniqueEmail = false;}).AddEntityFrameworkStores<CustomDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer= builder.Configuration["JWT:ValidateIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidateAudience"],
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


//builder.Services.AddControllers(
//options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressConsumesConstraintForFormFileParameters = true;
//    options.SuppressInferBindingSourcesForParameters = true;
//    options.SuppressModelStateInvalidFilter = true;
//});

builder.Services.AddTransient<IMusicService, MusicManager>();
builder.Services.AddTransient<IMusicDAL, EF_MusicDAL>();

builder.Services.AddTransient<IPlaylistService, PlaylistManager>();
builder.Services.AddTransient<IPlaylistDAL, EF_PlaylistDAL>();

builder.Services.AddTransient<IArtistService, ArtistManager>();
builder.Services.AddTransient<IArtistDAL, EF_ArtistDAL>();

builder.Services.AddTransient<IAlbumService, AlbumManager>();
builder.Services.AddTransient<IAlbumDAL, EF_AlbumDAL>();

builder.Services.AddTransient<IUserAccountService, UserAccountManager>();
builder.Services.AddTransient<IUserAccountDAL, EF_UserAccountDAL>();

builder.Services.AddTransient<IRadioService, RadioManager>();
builder.Services.AddTransient<IRadioDAL, EF_RadioDAL>();

builder.Services.AddTransient<IPlaylistMusicService, PlaylistMusicManager>();
builder.Services.AddTransient<IPlaylistMusicDAL, EF_PlaylistMusicDAL>();

builder.Services.AddTransient<IArtistAlbumService, ArtistAlbumManager>();
builder.Services.AddTransient<IArtistAlbumDAL, EF_ArtistAlbumDAL>();

builder.Services.AddTransient<IMusicAlbumService, MusicAlbumManager>();
builder.Services.AddTransient<IMusicAlbumDAL, EF_MusicAlbumDAL>();

builder.Services.AddTransient<INotificationService, NotificationManager>();
builder.Services.AddTransient<INotificationDAL, EF_NotificationDAL>();

builder.WebHost.UseUrls("https://localhost:7270");

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();


//builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
//{
//    builder.AllowAnyOrigin()
//           .AllowAnyMethod()
//           .AllowAnyHeader();
//}));



//builder.Services.AddDbContext<MusicCMSContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseDBConnString")));


//builder.Services.AddSession();
//builder.Services.AddMemoryCache();
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=> { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicCMS API"); });
}



app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.MapControllers();

app.MapControllerRoute(name: "default", pattern: "{MusicCMS}/{action=Index}/{id?}");

app.Run();
