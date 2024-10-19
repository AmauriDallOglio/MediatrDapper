using MediatrDapper.Aplicacao;
using MediatrDapper.Aplicacao.Usuarios;
using MediatrDapper.Dominio.Interface;
using MediatrDapper.Infra.Contexto;
using MediatrDapper.Infra.Repositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MediatrDapperApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o do IDbConnection com a string de conex�o "Gravacao"
            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("Gravacao")));

            // Configura��o do DbContext para o GenericoContexto
            builder.Services.AddDbContext<GenericoContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Gravacao")));

            // Registro dos reposit�rios e outros servi�os necess�rios
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<UsuarioRepositorioMemoria>();



            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();




            // Registro do contexto em mem�ria e do MediatR
            builder.Services.AddSingleton<MemoriaContexto>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InserirUsuarioCommandHandler).Assembly));

            builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(MapperProfile)));
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            // Configura��o do MVC e Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Middleware para o Swagger e tratamento de erros
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Configurar a localiza��o
            var idiomas = new[] { "pt-BR", "en-US" };
            var localizacaoIdioma = new RequestLocalizationOptions()
                .SetDefaultCulture(idiomas[0])
                .AddSupportedCultures(idiomas)
                .AddSupportedUICultures(idiomas);

            app.UseRequestLocalization(localizacaoIdioma);


            app.Run();
        }
    }
}
