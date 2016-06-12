// <copyright file="Startup.cs" company="Victor Grigoriu">
// Copyright © Victor Grigoriu. Some rights reserved.
// </copyright>

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Core.Startup))]
namespace Core
{
    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures OWIN with the chain of middleware components
        /// </summary>
        /// <param name="app">The app.</param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Use(typeof(SerializingMiddleware));
            app.Use(typeof(ReturnSomethingMiddleware));
        }
    }
}
