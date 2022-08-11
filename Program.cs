//hosting - responsavel por criar a aplicação web
//Quem escuta as interações do front-end
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/saveproduct",(Product Product) => {
    return Product.Code + Product.Name;
});

app.MapPost("/getproduct/{code}",([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
});

app.Run();

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}

public static class ProductRepository{
    public static List<Product> Products { get; set; }

    public static void Add(Product product) {
        if(Products == null){
            Products = new List<Product>();

            Products.Add(product);
        }
    }

    public static Product GetBy(string code){
        return Products.First(p => p.Code == Code);
    }
}


