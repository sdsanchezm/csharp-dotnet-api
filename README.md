# dotnet (dotnet new webapi)

- About
    - repo to track process

## Requisites

- dotnet
- entity framework


## Patterns

- MVC(data (Model), View (User Interface) and logic (controller))
- MXC (only data and logic, Model, Controller)


## webapi filesystem

- `Program.cs`: Este archivo contiene la clase principal del programa, que es el punto de entrada para la aplicación. También contiene la lógica para iniciar el host de la aplicación y configurar el enrutamiento.

- `Controllers`: Este directorio contiene los controladores de la API. Cada controlador es responsable de manejar una o varias solicitudes HTTP y devolver una respuesta.

- `appsettings.json`: Este archivo contiene la configuración de la aplicación, como las opciones de conexión a la base de datos y las opciones de configuración personalizadas.

- `Properties`: Este directorio contiene información sobre el proyecto, como la información de versión y la información de compilación.

- `Models`: Este directorio contiene los modelos de datos utilizados por la API. Los modelos representan los datos que se manejan en la API, como los recursos que se están exponiendo.

- `.csproj` some directives for the project `PropertyGroup` and `ItemGroup`

- `launchSettings.json` configuration for launching the project (ports for example) and IIS Express with VS

## Controllers

- Name always ends using "Controller" word in Controller folders

## Routes

- 
    ```cs
    [ApiController]
    [Route("api/[controller]")]  <<-- here
    public class WeatherForecastController : ControllerBase
    ```

- El atributo **`Route`** es un atributo de enrutamiento que se utiliza para definir la ruta base para las acciones en un controlador.
    - En este caso, la ruta base para las acciones en este controlador será `api/[controller]`, donde `[controller]` se reemplazará automáticamente con el nombre del controlador sin la palabra `Controller`.
    - Example, si el nombre del controlador es `WeatherForecastController`, la ruta base para las acciones será `api/WeatherForecast`.
    - 
        ```cs
        [ApiController]
        [Route("api/[controller]")]
        public class WeatherForecastController : ControllerBase {}
        ```
        ```cs
        [Route("[action]")]
	    public IEnumerable<WeatherForecast> Getw() {}
        ```
        - El atributo **`Route`** se utiliza para definir la ruta para la acción. En este caso, la ruta será “[action]”, donde “[action]” se reemplazará automáticamente con el nombre del método de acción. Por ejemplo, si el nombre del método de acción es “Get”, la ruta para esta acción será “Get”.

- Its accessible through `localhost:5294/api/WeatherForecast/get/weatherforecast`
    - 
    ```cs
        [HttpGet(Name = "GetWeatherForecast")]

        [Route("Get/weatherforecast")] // localhost:5294/api/WeatherForecast/get/weatherforecast
        [Route("Get/weatherforecast2")] // localhost:5294/api/WeatherForecast/get/weatherforecast2
        
        [Route("[action]")] // localhost:5294/api/WeatherForecast/get
        public IEnumerable<WeatherForecast> Get()
        
        [Route("[action]")] // localhost:5294/api/WeatherForecast/getASD
        public IEnumerable<WeatherForecast> GetASD()
    ```

### webapi

- Utiliza modelo MVC para estructurar el código (sin utilizar la vista)
- Se puede utilizar para proyectos de cualquier tamaño
- Mas sencillo de escalar ( utilizar más modelos, más recursos, etc)


## Middlewares

- Los middlewares son un componente que permite interceptar un request para realizar alguna lógica especifica
- Los middlewares tienen una estructura 
- middlewares must be in order (they will be executed in order)
    - Order:
        - Request
            - Exception handler
            - HSTS
            - HttpRedirection
            - Static Files
            - Routing
            - CORS
            - Authentication
            - Authorization
                - Custom Middleware 
                    - Endpoint
            

### Custom Middleware

- Steps
    1. Create a Class for Your Middleware:
    2. Implement Your Middleware Logic:
    3. Register the Middleware in Startup.cs:
    4. Inject Dependencies (Optional):
    5. Middleware Order:





### DTO

- DTO son clases que tiene como función guardar datos que se van a transferir dentro de la aplicación con una estructura personalizada


## Interfaces

- Interface = defines a "contract" that all the classes inheriting from should follow
- An interface declares "what a class should have"
- An inheriting class defines "how it should do it"
- Benefit = security + multiple inheritance + "plug-and-play"


## Dependency Injection (DI)

- there is a suggested lecture[#doc2]
- AddScoped
    - crea una instancia por cada request del cliente
    - Recommended
    - `builder.Services.AddScoped`
- AddTransient
    - crea una instancia por cada controlador
- AddSingelton
    - crea una sola instancia para todo lo que dure la ejecución de la API
    - `builder.Services.AddSingleton`
    - is not recommended, because of memory management

- /Service/HelloWorldService.cs
    ```cs    
        namespace webapi.Services
        {
            public class HelloWorldService : IHelloWorldService
            {
                public string GetHelloWorld()
                {
                    Console.WriteLine("Hallo Welt!");
                    return "Hallo Welt hier!";
                }

            }

            public interface IHelloWorldService
            {
                string GetHelloWorld();
            }
        }
    ```


- /Service/HelloWorldController.cs
    ```cs
    using Microsoft.AspNetCore.Mvc;
    using webapi.Services;

    namespace webapi.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class HelloWorldController : ControllerBase
        {
            IHelloWorldService helloWorldService;

            public HelloWorldController(IHelloWorldService helloWorld)
            {
                helloWorldService = helloWorld;
            }

            public IActionResult Get()
            {
                return Ok(helloWorldService.GetHelloWorld());
            }
        }
    }
    ```

- /Program.cs
    ```cs
    // DI 1
    //builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

    // DI 2
    builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());

    var app = builder.Build();
    ```

- El principio de inversión de dependencias nos indica que nuestras clases dependen de abstracciones y no de implementaciones.

- Pero qué quiere decir, actualmente nuestro método está ligado a la implementación de PersonalProfileInfo, para abstraer nuestro código debemos extraer una interfaz y nuestra clase PersonalProfileInfo deberá implementar esta interfaz 


## Creating loggins API

- Trace: (0) Información detallada y de diagnóstico que se utiliza principalmente durante la depuración y el desarrollo.
- Debug: (1) Información adicional que se utiliza durante la depuración y el desarrollo.
- Information: (2) Información general que puede ser útil para comprender lo que está sucediendo en la aplicación.
- Warning: (3) Información que indica que algo no está funcionando según lo previsto, pero que no impide el funcionamiento de la aplicación.
- Error: (4) Información que indica que un error ha ocurrido y que puede afectar el funcionamiento de la aplicación.
- Critical: (5) Información que indica un error grave que puede impedir el funcionamiento de la aplicación.
- None: (6)

- to configure the default level, gotta modify the appsettings.json file
- documentation [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0]


## Documenting APIs with Swagger

- in the csprj file:
    ```xml
    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="7.0.5" />
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
    </ItemGroup>
    ```

- in Program.cs
    - 
    ```cs
        builder.Services.AddSwaggerGen();
    ```
    - and 
    ```cs
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    ```
- Above code in Program.cs, is because swagger, should be only part of the Development environment
- swagger uses openapi standar (it's required to work with swagger)



## Adding libs for entity framework

- Get it from: [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.3]
- StringConn: 
    - `builder.Services.AddSqlServer<ToDoContext>("Data Source=KRAUSP52\\SQLEXPRESS;Initial Catalog=TodoDb;Trusted_Connection=True;TrustServerCertificate=true;");`

## Services

- Add business Logic to communicate with DB (using EF in this case)
- Actions that will be executed from the controllers
- Controllers will consume these services and execute these actions from services
- the idea is build an scalable project, so controllers can call services, and the logic will be separated



### Save Sync
- 
    ```cs
        public void Save(Category c)
        {
            context.Add(c);
            context.SaveChanges();
        }
    ```

### Save Async
- 
    ```cs
        public async Task Save(Category c) 
        {
            await context.SaveChangesAsync(); 
        }
    ```

### Update Async
- 
    ```cs
        public async Task Update(Guid id, Category c)
        {
            var actualCategory = context.Categories.Find(id);

            if (actualCategory != null)
            {
                actualCategory.CategoryName = c.CategoryName;
                actualCategory.CategoryDescription = c.CategoryDescription;
                actualCategory.CategoryLevel = c.CategoryLevel;

                await context.SaveChangesAsync();
            }
        }
    ```


### Delete
- 
    ```cs
        public void Delete(Guid id)
        {
            var actualCategory = context.Categories.Find(id);
            if (actualCategory != null)
            {
                context.Remove(actualCategory);
                context.SaveChanges();
            }
        }
    ```

### Interface to export Services

- Sync: 
    ```cs
        public interface ICategoryService
        {
            IEnumerable<Category> Get();
            void Save(Category c);
            Task Update(Guid id, Category c);
            void Delete(Guid id);
        }
    ```





## Fluent api detail

- Cascade Delete:
    - `modelBuilder.Entity<Profile>().HasOptional(c => c.ProfileImages).WithOptionalDependent().WillCascadeOnDelete(true);`

# Minimal API (dotnet new web)

- Create
    - `dotnet new web`

- create routes with functions
- used when the api is not too big (only 1 endpoint)
- dificult to escalate in complex projects

- **Minimal API** es pensada para proyectos de preferencia con un solo endpoint, ya que toda la logica y configuración se realiza en un mismo archivo. Lo hace ser más rápido pero sin escalabilidad (a menos que les guste el espagueti).

- **Web API** es para proyectos mas estructurados con multiples endpoints y con una sencillez para escalar. Se puede usar para un solo endpoint y nos da la posibilidad de crecerlo como sea necesario.







## misc

- List
    - `dotnet new`
    - `dotnet new --list`

- api creation from dotnet template
    - `dotnet new webapi`
    - `dotnet new webapi --framework net6.0`

- run the project
    - `dotnet run`
    - `dotnet watch run`
- compile project
    - `dotnet build` 
- restaura dependencias y librerias
    - `dotnet restore`
- permite monitorear los cambios en tiempo real
    - `dotnet clean`

## Documentation

- [https://dotnet.microsoft.com/en-us/apps/aspnet]
#### doc2
- Dependency injection [https://www.netmentor.es/entrada/inyeccion-dependencias-scoped-transient-singleton]
- Interfaces: [https://www.youtube.com/watch?v=RuhGv81tpoU]

### List of Interfaces

- IApplicationBuilder
- ILogger
- IEnumerable
- IActionResult
- IMiddleware (from Microsoft.AspNetCore.Http)








