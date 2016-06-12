// <copyright file="ReturnSomethingMiddleware.cs" company="Victor Grigoriu">
// Copyright © Victor Grigoriu. Some rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Core.Startup))]
namespace Core
{
    /// <summary>
    /// Return something in the "content" key
    /// </summary>
    internal class ReturnSomethingMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnSomethingMiddleware"/> class.
        /// </summary>
        /// <param name="next">next middleware</param>
        public ReturnSomethingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        /// <summary>
        /// Puts something in the "content" key
        /// </summary>
        /// <param name="context">the context</param>
        /// <returns>when it's ready</returns>
        public override Task Invoke(IOwinContext context)
        {
            context.Set("content", new { a = 1, b = 2 });
            return Task.CompletedTask;
        }
    }
}
