using MeTube.Data;

namespace MeTube.Web
{
    using SimpleMvc.Framework;

    using SimpleMvc.Framework.Routers;
    using WebServer;
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MeTubeContext())
            {
                context.Database.EnsureCreated();
            }
            var server = new WebServer(42420, new ControllerRouter(), new ResourceRouter());
            MvcEngine.Run(server, new MeTubeContext());
        }
    }
}
