using log4net;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*
 36.Adım
*/
namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();

            var configPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "log4net.config"
            );

            //xmlDocument.Load(File.OpenRead(configPath));
            var repositoryAssembly= Assembly.GetExecutingAssembly();
            ILoggerRepository loggerRepository;
            //=LogManager.CreateRepository(
            //    Assembly.GetEntryAssembly(),
            //    typeof(log4net.Repository.Hierarchy.Hierarchy)
            //);

            //log4net.Config.XmlConfigurator.Configure(
            //    loggerRepository,
            //    xmlDocument["log4net"]
            //);
            try
            {
                loggerRepository = LogManager.CreateRepository(
                    repositoryAssembly,
                    typeof(log4net.Repository.Hierarchy.Hierarchy)
                );
            }
            catch (log4net.Core.LogException)
            {
                loggerRepository =
                  LogManager.GetRepository(repositoryAssembly);
            }
            //_log = LogManager.GetLogger(loggerRepository.Name, name);
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load(File.OpenRead("log4net.config"));
            //ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            //  log4net.Config.XmlConfigurator.Configure(
            //    loggerRepository,
            //    xmlDocument["log4net"]
            //);
            log4net.Config.XmlConfigurator.Configure(loggerRepository, new FileInfo(configPath));
            _log = LogManager.GetLogger(
                loggerRepository.Name,
                name
            );
//            throw new Exception(
//    "LOGGER: " + _log.Logger.Name +
//    " / INFO: " + _log.IsInfoEnabled +
//    " / REPOSITORY: " + loggerRepository.Name +
//     "CONFIG PATH: " + configPath +
//    " / FILE EXISTS: " + File.Exists(configPath) +
//    " / CONFIGURED: " + loggerRepository.Configured +
//    " / APPENDER COUNT: " + ((log4net.Repository.Hierarchy.Hierarchy)loggerRepository).GetAppenders().Length +
//    " / APPENDER NAMES: " + string.Join(",", ((log4net.Repository.Hierarchy.Hierarchy)loggerRepository).GetAppenders().Select(a => a.Name)) +
//    " / IS INFO ENABLED: " + IsInfoEnabled
//);
        }
        //public ILog Log => _log;
        public bool IsInfoEnabled=> _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public void Info(object logMessage)
        {
            //          System.Diagnostics.Debug.WriteLine(
            //    "!!! INFO ÇAĞRILDI !!! " + _log.Logger.Name
            //);

            //          _log.Info(logMessage);

            //          System.Diagnostics.Debug.WriteLine(
            //              "!!! INFO BİTTİ !!!"
            //          );
            //        throw new Exception(
            //    "INFO ÇAĞRILDI - IsInfoEnabled = " + IsInfoEnabled
            //);
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if(IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if(IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if(IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if(IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
    }
}