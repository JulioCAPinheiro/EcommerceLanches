﻿using Ecommerce.Areas.Admin.Services;
using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Interfaces;
using Ecommerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;



namespace Ecommerce;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        //Vincunalando o serviço para o banco de dados
        services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));


        //Definindo Serviço de Rota para o Banco de dados
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        //Adicionando independencia (CONTAINER DI)

        services.AddTransient<ILanchesRepository, LanchesRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidosRepository, PedidoRepository>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddScoped<RelatorioVendasServices>();

        
        services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", politica =>
            {
                politica.RequireRole("Admin");
            });
        });


        //Recupera uma extancia de sessãp HTTP
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // O Uso do Session e o Uso do HTTPContext foi feito para gerenciar o estado da sessão


        services.AddMemoryCache();
        services.AddSession();

        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //Cria o perfil
        seedUserRoleInitial.SeedRoles();
        //Cria o usuário e atribui ao perfil
        seedUserRoleInitial.SeedUsers();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {

            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=admin}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Lanche/{action}/{categoria?}",
                defaults: new { Controller = "Lanche", Action = "List" });


            endpoints.MapControllerRoute(
                name: default,
                pattern: "{controller=Home}/{action=Index}/{id?}");
            /* Roteamendo Convencional 
                  pattern: "{controller=Home}/{action=Index}/{id?}");
                */
        });
    }
}