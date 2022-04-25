using Microsoft.OpenApi.Models;
using PizzaStore;

//Create the Builder Object which has the services property which we will use to set up the middleware
//like CORS, Swagger, Entity Framework 
//
//Middleware is usually code that intercepts the request and carries out checks like checking for authentication or
//ensuring the client is allowed to perform this operation according to CORS.
//After the middleware is done executing, the actual request is carried out.
//Data is either read or written to the store and a response is sent back to the calling client.
var builder = WebApplication.CreateBuilder(args);

//Cross-origin resource sharing is a mechanism that allows restricted resources on a web page to be requested from another domain
//outside the domain from which the first resource was served.
//A web page may freely embed cross-origin images, stylesheets, scripts, iframes, and videos....
//
//“CORS” stands for Cross-Origin Resource Sharing. It allows you to make requests from one website to another website in the browser,
//which is normally prohibited by another browser policy called the Same-Origin Policy (SOP).
builder.Services.AddCors(options => { });
//Swagger self documenting API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PIZZASTORE API", Description = "Keep track of your tasks", Version = "v1" });
});


//Create the app object which will actually USE the services defined in the builder.Services property...
//so we can use the app object to setup routing
var app = builder.Build();

//Set up HTML responses to exceptions
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Tell the app to use swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PIZZASTORE API V1");
});

//Set up routes
//
//GET: Returns Data 
//POST: Sends data that creates a resource
//PUT: Sends data that updates a resource
//DELTE: Removes a resource
//
//When a client initiates a request, it does so toward a server endpoint.
//Imagine a request made toward GET http://localhost:3000/products. The server verifies the request to see what HTTP verb is used.
//It also needs to know where it's going, which is indicated by "/products." The server then attempts to resolve the request by producing a response.

//This code should be read in the following way: if the client uses the GET HTTP verb toward the route "/", then respond with "Hello World!".
app.MapGet("/stores/{id}", (string id) => StoreDb.GetStore(id));
app.MapGet("/stores", () => StoreDb.GetStores());
app.MapPost("/stores", (Store store) => StoreDb.CreateStore(store));
app.MapPut("/stores", (Store store) => StoreDb.UpdateStore(store));
app.MapDelete("/stores/{id}", (string id) => StoreDb.RemoveStore(id));
//TODO: Set up database
//app.MapGet("/Store/{id}", (int id) => data.SingleOrDefault(product => product.Id == id));



//C# 9 - C# 9 introduces records, a new reference type that you can create instead of classes or structs.
//C# 10 adds record structs so that you can define records as value types. Records are distinct from classes in that record types use value-based equality.
//Two variables of a record type are equal if the record type definitions are identical, and if for every field, the values in both records are equal.
//
//public record Product(int Id, string Name)

//Start the API and have it listening for requests
app.Run();
