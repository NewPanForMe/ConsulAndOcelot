using Consul;

namespace ServiceB;

public class Startup
{

    private IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    // 该方法由运行时调用，使用该方法向DI容器添加服务
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    // 该方法由运行时调用，使用该方法配置HTTP请求管道
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IHostApplicationLifetime appLifetime)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(x => { x.MapControllers(); });
        RegisterConsul(appLifetime);
    }


    private void RegisterConsul(IHostApplicationLifetime appLifetime)
    {
        using var client = new ConsulClient(x => x.Address = new Uri("http://127.0.0.1:8500"));
        var check = new AgentServiceCheck()
        {
            DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务停止后，5s开始接触注册
            HTTP = "http://localhost:5087/api/Health/CheckHealth",//健康检查
            Interval = TimeSpan.FromSeconds(10),//每10s轮询一次健康检查
            Timeout = TimeSpan.FromSeconds(5),
        };
        var service = new AgentServiceRegistration()
        {
            Checks = new[] { check },
            ID = Guid.NewGuid().ToString(),
            Name = "ServiceB",
            Port = 5087,
            Address = "localhost"
        };
        client.Agent.ServiceRegister(service).Wait();
        appLifetime.ApplicationStopped.Register(() =>
        {
            using var consulClient = new ConsulClient(x => x.Address = new Uri("http://127.0.0.1:8500"));
            consulClient.Agent.ServiceDeregister(service.ID).Wait();
        });
    }



}