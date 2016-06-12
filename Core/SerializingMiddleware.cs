// <copyright file="SerializingMiddleware.cs" company="Victor Grigoriu">
// Copyright © Victor Grigoriu. Some rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(Core.Startup))]
namespace Core
{
    /// <summary>
    /// Serialize whatever is in the "content" key.
    /// </summary>
    public class SerializingMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializingMiddleware"/> class.
        /// </summary>
        /// <param name="next">next middleware</param>
        public SerializingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        /// <summary>
        /// Serialize whatever is in the "content" key.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Yes.</returns>
        public override async Task Invoke(IOwinContext context)
        {
            context.Response.ContentType = "text/json";
            await Next.Invoke(context);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(context.Get<object>("content")));
        }
    }
}
