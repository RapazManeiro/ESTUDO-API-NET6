//hosting - responsavel por criar a aplicação web
//Quem escuta as interações do front-end
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Bem Vindo Lucas!");
app.MapPost("/", () => new {Name= "Julia Vavlis", Status = "Linda"});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Lucas", "Teste");
    return new {Name= "Julia Vavlis", Status = "Muito Linda"};
});

app.MapPost("/saveproduct",(Produto produto) => {
    return produto.Code + " | " + produto.Nome;
});

app.Run();

public class Produto {
    public string Code { get; set; }
    public string Nome { get; set; }
}
