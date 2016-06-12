using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Core.Startup))]
namespace Core
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Use(typeof(SerializingMiddleware));
            app.Use(typeof(ReturnSomethingMiddleware));
        }
    }

    public class SerializingMiddleware : OwinMiddleware
    {
        public SerializingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.ContentType = "text/json";
            await Next.Invoke(context);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(context.Get<object>("content")));
        }
    }

    public class ReturnSomethingMiddleware : OwinMiddleware
    {
        public ReturnSomethingMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            context.Set("content", new { a = 1, b = 2 });
            return Task.CompletedTask;
        }
    }
}
