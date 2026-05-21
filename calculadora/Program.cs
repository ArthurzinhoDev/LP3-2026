gitvar builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8000");
var app = builder.Build();

app.MapGet("/", () =>
{
    return new { mensagem = "API em execução ..." };
});

//um app.map para cada operação, ou seja, 4 app.map para as 4 operações


app.MapGet("/calcula/soma/{valor1}/{valor2}", (int valor1, int valor2) =>
{
    return Results.Ok(new { mensagem = $"{valor1} + {valor2} = {valor1 + valor2}" });
});

app.MapGet("/calcula/subtracao/{valor1}/{valor2}", (int valor1, int valor2) =>
    {  
    return Results.Ok(new { mensagem = $"Execução do caso 2: {valor1} - {valor2} = {valor1 - valor2}" });     
});

app.MapGet("/calcula/multiplicacao/{valor1}/{valor2}", (int valor1, int valor2) =>
{   
    return Results.Ok(new { mensagem = $"Execução do caso 3: {valor1} * {valor2} = {valor1 * valor2}" });
});

app.MapGet("/calcula/divisao/{valor1}/{valor2}", (int valor1, int valor2) =>
{
            if (valor2 == 0)
            {
                return Results.BadRequest(new { erro = "Erro: Divisão por zero não é permitida." });
            }
            else{
            return Results.Ok(new { mensagem = $"Execução do caso 4: {valor1} / {valor2} = {valor1 / valor2}" });
            }
            
    }
);

app.Run();