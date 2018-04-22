using System;
using System.Net;
using Khairia.Controllers;
using Khairia.Core.Commands.Volunteer;
using Khairia.Core.Models;
using Khairia.DependencyInjection;
using MediatR;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StructureMap;

namespace Khairia
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			var container = new Container();
			container.Configure(config =>
			{
				config.Scan(scanner =>
				{
					scanner.TheCallingAssembly();
					scanner.AssemblyContainingType<HelpController>();
					scanner.AssemblyContainingType<AddVolunteer>();
					scanner.AssemblyContainingType<IMediator>();
					scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>)); // Handlers with no response
					scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); // Handlers with a response
					scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>)); // Async handlers with no response
					scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>)); // Async Handlers with a response
					scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
					scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
				});
				config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => ctx.GetInstance);
				config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => ctx.GetAllInstances);
				config.For<IMediator>().Use<Mediator>();
				config.For<DependencyInjectionContainer>().Use(ctx => new DependencyInjectionContainer(ctx.GetInstance));

				var connectionString = Configuration.GetConnectionString("app");
				var coreDbContextOptions = new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
				config.For<CoreDbContext>().Use(ctx => new CoreDbContext(coreDbContextOptions));

				config.For<UserContext>().Use(ctx => GetUserContext(ctx));
				

				config.Scan(_ =>
				{
					_.AssembliesFromApplicationBaseDirectory();
					_.WithDefaultConventions();
				});

				config.Populate(services);
			});


			services.AddMediatR(typeof(HelpController));
			var builder = services.AddMvc();
			services.AddCors(options =>
				options.AddPolicy("AllowSpecific", p => p
					.AllowAnyMethod()
					.AllowAnyOrigin()
					.AllowAnyHeader()));

			builder.AddMvcOptions(o => { o.Filters.Add(new GlobalExceptionFilter()); });

			// Populate the container using the service collection.
			// This will register all services from the collection
			// into the container with the appropriate lifetime.
			container.Populate(services);


			var serviceProvider = container.GetInstance<IServiceProvider>();
			return serviceProvider;
		}

		private static UserContext GetUserContext(IContext ctx)
		{
			return null;
			//var contextAccessor = ctx.GetInstance<IHttpContextAccessor>();
			//var httpContextUser = contextAccessor.HttpContext.User;

			//if (!httpContextUser.Identity.IsAuthenticated)
			// return new UserContext();

			//return new UserContext
			//{
			// UserId = httpContextUser.Identity.Name,
			// Roles = httpContextUser.Claims.Where(t => t.Type == ClaimTypes.Role).Select(t => t.Value)
			//  // Ensure that there is at least one role, otherwise "public" 
			//  // actions won't work.
			//  .Append(SystemRole.User.Name)
			//};
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseMvc();
			app.UseCors("AllowSpecific");
		}
	}


	public class GlobalExceptionFilter : IExceptionFilter
	{

		public void OnException(ExceptionContext context)
		{
			context.Result = new JsonResult(context.Exception.Message)
			{
				StatusCode =  (int)HttpStatusCode.BadRequest,
				ContentType = "application/json; charset=utf-8"
			};

		}
	}

	public class ErrorResponse
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
	}
}