namespace ProjetoInterdisciplinar {
    internal static class Program
    {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MinhaPoliticaCors", policy =>
                {
                    policy.WithOrigins( "http://127.0.0.1:3000") // Coloque a URL do seu front-end aqui
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseCors("MinhaPoliticaCors");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapPost("/produtos", (Produto produtoDetails) => { return Results.Ok(produtoDetails.Nome); });

            app.Run();
        }
    }
}


