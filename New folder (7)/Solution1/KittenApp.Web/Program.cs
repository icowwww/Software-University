namespace KittenApp.Web
{
    using Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new KittenAppContext())
            {
                context.Database.EnsureCreated();
            }
            var server = new WebServer(42420, new ControllerRouter(), new ResourceRouter());
            MvcEngine.Run(server,new KittenAppContext());
        }
    }
}
