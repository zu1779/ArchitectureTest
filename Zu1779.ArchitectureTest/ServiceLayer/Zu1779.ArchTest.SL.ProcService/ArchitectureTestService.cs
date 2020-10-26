namespace Zu1779.ArchTest.SL.ProcService
{
    using System;

    using NLog;
    using Topshelf;

    using TestGrpcLibrary;

    public class ArchitectureTestService : ServiceControl, ServiceCustomCommand, ServicePowerEvent, ServiceSessionChange,
        ServiceShutdown, ServiceSuspend
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        #region ServiceControl
        public bool Start(HostControl hostControl)
        {
            log.Info("Starting");
            ServiceManager.StartService();
            log.Info("Started");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            log.Info("Stopping");
            ServiceManager.StopService();
            log.Info("Stopped");
            return true;
        }
        #endregion

        #region ServiceCustomCommand
        public void CustomCommand(HostControl hostControl, int command)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region ServicePowerEvent
        public bool PowerEvent(HostControl hostControl, PowerEventArguments changedArguments)
        {
            //throw new NotImplementedException();
            return true;
        }
        #endregion

        #region ServiceSessionChange
        public void SessionChange(HostControl hostControl, SessionChangedArguments changedArguments)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region ServiceShutdown
        public void Shutdown(HostControl hostControl)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region ServiceSuspend
        public bool Pause(HostControl hostControl)
        {
            //throw new NotImplementedException();
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            //throw new NotImplementedException();
            return true;
        }
        #endregion
    }
}
