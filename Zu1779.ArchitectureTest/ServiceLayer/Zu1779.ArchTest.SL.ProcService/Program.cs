namespace Zu1779.ArchTest.SL.ProcService
{
    using System;

    using NLog;
    using Topshelf;

    class Program
    {
        static int Main()
        {
            Logger log = LogManager.GetCurrentClassLogger();

            log.Info("BEFORE HOST CREATION");

            var host = HostFactory.New(c =>
                {
                    c.Service<ArchitectureTestService>();
                    c.SetServiceName(nameof(ArchitectureTestService));
                    c.SetDescription("Main service for the Architecture test solution");
                    c.RunAsNetworkService();
                    c.EnablePauseAndContinue();
                    c.EnableServiceRecovery(d =>
                    {
                        d.OnCrashOnly();
                        d.TakeNoAction();
                        //d.RestartComputer(1, "Test");
                        //d.RestartService(1);
                        //d.TakeNoAction();
                    });
                    c.EnableSessionChanged();
                    c.EnableShutdown();
                    c.StartManually();
                    c.UseNLog();

                    //c.UseTestHost();
                    c.OnException((ex) =>
                    {
                        log.Error(ex, "OnException Error");
                    });
                });
            TopshelfExitCode exitCode = host.Run();
            return (int)exitCode;
        }
    }
}
