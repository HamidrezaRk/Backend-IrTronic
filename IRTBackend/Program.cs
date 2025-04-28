using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        //Customaiz Swagger
        builder.Services.AddSwaggerGen(c =>
        {
           // c.OperationFilter<AddAcceptLanguageHeaderParameter>();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "IRTronic", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"

            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, Array.Empty<string>()
                }
            });
        });

       // ApplicationStarter.AddApplication(builder.Services);
        #region ConectionString
        string MasterDbConnectionString = builder.Configuration.GetConnectionString("MasterDatabase")!;
        string SlaveDbConnectionString = builder.Configuration.GetConnectionString("SlaveDatabase")!;

        #endregion
        #region JWT
        //var jwtSettings = new JwtSettings();
        //builder.Configuration.Bind("Jwt", jwtSettings);
        //builder.Services.AddSingleton(jwtSettings);
        //builder.Services.AddAuthentication(x =>
        //{
        //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()

        //{
        //    ValidateIssuer = true,
        //    ValidateAudience = true,
        //    ValidateLifetime = true,
        //    ValidateIssuerSigningKey = true,
        //    ValidIssuer = jwtSettings.Issuer,
        //    ValidAudience = jwtSettings.Audience,
        //    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Key)),
        //});
        //builder.Services.AddAuthorization(options =>
        //{

        //    options.AddPolicy("RequireDriverRole", policy => policy.RequireRole("3"));
        //    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("1"));

        //});
        #endregion
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());


        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
