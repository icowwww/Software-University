namespace MeTube.App
{
    using MeTube.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            using (var context = new MeTubeContext())
            {
                context.Database.EnsureCreated();
            }
            var server = new WebServer(
                42420,
                new ControllerRouter(),
                new ResourceRouter());
            var dbContext = new MeTubeContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
