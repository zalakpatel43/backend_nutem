using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Domain;
using Application.Helper;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity with long as ID type for Role
builder.Services.AddIdentity<User, Role>(options =>
{
    // Configure identity options if needed
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsPrincipalFactory>();

// Configure JWT Bearer authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");
    var key = jwtSettings["SecretKey"];
    var issuer = jwtSettings["Issuer"];
    var audience = jwtSettings["Audience"];

    if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience))
    {
        throw new ArgumentNullException("JWT settings are not properly configured.");
    }

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});



// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register application services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<IAutoMapperGenericDataMapper, AutoMapperGenericDataMapper>();
builder.Services.AddScoped<INozzleMasterRepository, NozzleMasterRepository>();
builder.Services.AddScoped<INozzleMasterService, NozzleMasterService>();
builder.Services.AddScoped<IProductMasterRepository, ProductMasterRepository>();
builder.Services.AddScoped<IProductMasterService, ProductMasterService>();
builder.Services.AddScoped<IProductionOrderRepository, ProductionOrderRepository>();
builder.Services.AddScoped<IProductionOrderService, ProductionOrderService>();
builder.Services.AddScoped<IShiftMasterRepository, ShiftMasterRepository>();
builder.Services.AddScoped<IShiftMasterService, ShiftMasterService>();
builder.Services.AddScoped<IMastersRepository, MastersRepository>();
builder.Services.AddScoped<IMastersService, MastersService>();
builder.Services.AddScoped<ICauseMasterRepository, CauseMasterRepository>();
builder.Services.AddScoped<ICauseMasterService, CauseMasterService>();
builder.Services.AddScoped<IWeightCheckDetailsRepository, WeightCheckDeatilsRepository>();
builder.Services.AddScoped<IWeightCheckSubDetailsRepository, WeightCheckSubDeatilsRepository>();
builder.Services.AddScoped<IWeightCheckRepository, WeightCheckRepository>();
builder.Services.AddScoped<IWeightCheckService, WeightCheckService>();
builder.Services.AddScoped<IAttributeCheckRepository, AttributeCheckRepository>();
builder.Services.AddScoped<IAttributeCheckDetailsRepository, AttributeCheckDetailsRepository>();
builder.Services.AddScoped<IAttributeCheckService, AttributeCheckService>();
builder.Services.AddScoped<IDowntimeTrackingRepository, DowntimeTrackingRepository>();
builder.Services.AddScoped<IDowntimeTrackingService, DowntimeTrackingService>();
builder.Services.AddScoped<IDowntimeTrackingDetailsRepository, DowntimeTrackingDetailsRepository>();
builder.Services.AddScoped<IPrePostQuestionRepository, PrePostQuestionRepository>();
builder.Services.AddScoped<IPrePostQuestionService, PrePostQuestionService>();
builder.Services.AddScoped<IPreCheckListRepository, PreCheckListRepository>();
builder.Services.AddScoped<IPreCheckListDetailRepository, PreCheckListDetailRepository>();
builder.Services.AddScoped<IPreCheckListService, PreCheckListService>();
builder.Services.AddScoped<ICompanyMasterRepository, CompanyMasterRepository>();
builder.Services.AddScoped<ICompanyMasterService, CompanyMasterService>();
builder.Services.AddScoped<ITrailerInspectionRepository, TrailerInspectionRepository>();
builder.Services.AddScoped<ITrailerInspectionService, TrailerInspectionService>();
builder.Services.AddScoped<IStartEndBatchChecklistRepository, StartEndBatchChecklistRepository>();
builder.Services.AddScoped<IStartEndBatchChecklistService, StartEndBatchChecklistService>();
builder.Services.AddScoped<ITankMasterRepository, TankMasterRepository>();
builder.Services.AddScoped<ITankMasterService, TankMasterService>();
builder.Services.AddScoped<IMaterialMasterRepository, MaterialMasterRepository>();
builder.Services.AddScoped<IMaterialMasterService, MaterialMasterService>();
builder.Services.AddScoped<IProductInstructionDetailsRepository, ProductInstructionDetailsRepository>();
builder.Services.AddScoped<IProductInstructionDetailsService, ProductInstructionDetailsService>();
builder.Services.AddScoped<IQCTSpecificationMasterRepository, QCTSpecificationMasterRepository>();
builder.Services.AddScoped<IQCTSpecificationMasterService, QCTSpecificationMasterService>();
builder.Services.AddScoped<ILiquidPreparationAdjustmentDetailsRepository, LiquidPreparationAdjustmentDetailsRepository>();
builder.Services.AddScoped<ILiquidPreparationChecklistDetailsRepository, LiquidPreparationChecklistDetailsRepository>();
builder.Services.AddScoped<ILiquidPreparationInstructionDetailsRepository, LiquidPreparationInstructionDetailsRepository>();
builder.Services.AddScoped<ILiquidPreparationSpecificationDetailsRepository, LiquidPreparationSpecificationDetailsRepository>();
builder.Services.AddScoped<ILiquidPreparationRepository, LiquidPreparationRepository>();
builder.Services.AddScoped<ILiquidPreparationService, LiquidPreparationService>();




// Register generic and specific repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Adjust according to your client's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
    // Add more policies as needed
});

// Add controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors();

// Use authentication and authorization middleware
app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Seed data if needed
await SeedData(app);

app.Run();

// Method to seed data
async Task SeedData(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    //var companyRepository = scope.ServiceProvider.GetRequiredService<ICompanyRepository>();

    // Seed roles
    string[] roles = { "Admin", "User", "Manager" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var newRole = new Role
            {
                Name = role,
                IsActive = true
            };
            await roleManager.CreateAsync(newRole);
        }
    }

    // Seed users
    var adminEmail = "admin@nutem.com";
    var adminPassword = "Admin@123";
    var adminName = "steve";

    if (userManager.Users.All(u => u.UserName != adminEmail))
    {
        var adminUser = new User
        {
            UserName = adminEmail,
            Email = adminEmail,
            Name = adminName
        };
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    var user1Email = "user1@nutem.com";
    var user2Email = "user2@nutem.com";
    var userPassword = "User@123";
    var user1Name = "adam";
    var user2Name = "alpha";

    if (userManager.Users.All(u => u.UserName != user1Email))
    {
        var user1 = new User
        {
            UserName = user1Email,
            Email = user1Email,
            Name = user1Name
        };
        var result = await userManager.CreateAsync(user1, userPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user1, "User");
        }
    }

    if (userManager.Users.All(u => u.UserName != user2Email))
    {
        var user2 = new User
        {
            UserName = user2Email,
            Email = user2Email,
            Name = user2Name
        };
        var result = await userManager.CreateAsync(user2, userPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "User");
        }
    }

    // Seed default company data
    //var defaultCompany = new Company
    //{
    //    UniqueID = Guid.NewGuid(),
    //    CompanyName = "Tech Innovations Ltd.",
    //    Alias = "TechInno",
    //    Address1 = "1234 Silicon Valley",
    //    Address2 = "Suite 567",
    //    Address3 = "Building A",
    //    Pincode = "94043",
    //    City = "Mountain View",
    //    State = "California",
    //    Country = "USA",
    //    PANNo = "AAACT1234F",
    //    GSTNo = "27AAACT1234F1Z5",
    //    EmailID = "contact@techinnovations.com",
    //    Website = "https://www.techinnovations.com",
    //    IsActive = true,
    //    CreatedBy = 1,
    //    CreatedDate = DateTime.UtcNow,
    //    LastModifiedBy = 1,
    //    LastModifiedDate = DateTime.UtcNow,
    //    CompanyLogoId = 101,
    //    CurrencyID = 1,
    //    CompanyCode = "TI1234",
    //    StateName = "California",
    //    PhoneNo = "+1-650-123-4567"
    //};

    //var existingCompany = await companyRepository.GetByIdAsync(defaultCompany.Id);
    //if (existingCompany == null)
    //{
    //    await companyRepository.AddAsync(defaultCompany);
    //}
}
