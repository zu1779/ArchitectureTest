namespace Zu1779.ArchTest.CL.BaseConsole
{
    using System;

    using LightInject;
    using NLog;

    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILogger>(c => LogManager.GetCurrentClassLogger());
            serviceRegistry.Register<Program>(new PerContainerLifetime());
        }
    }
}
