using NLog;
using ParkMark.Infrastructure;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Logger
{
    public class NLogProxy<T> : Infrastructure.Log.ILogger
    {
        public const string FunctionPropName = "CallerName";
        public const string DataPropName = "BigData";
        public const string TagsPropName = "Tags";
        public const string SitePropName = "Site";
        public const string UserIdPropName = "UserId";
        public const string ApiAccountPropName = "ApiAccount";
        public const string URLPropName = "URL";
        public const string UserAgentPropName = "UserAgent";
        public const string VersionPropName = "Version";


        readonly ILogRequestContext requestContext;

        public NLogProxy(ILogRequestContext requestContext)
        {
            this.requestContext = requestContext;
        }


        private static readonly NLog.ILogger logger =
                     LogManager.GetLogger(typeof(T).FullName);

        public bool IsDebugEnabled { get { return logger.IsDebugEnabled; } }

        public bool IsErrorEnabled { get { return logger.IsErrorEnabled; } }

        public bool IsFatalEnabled { get { return logger.IsFatalEnabled; } }

        public bool IsInfoEnabled { get { return logger.IsInfoEnabled; } }

        public bool IsTraceEnabled { get { return logger.IsTraceEnabled; } }

        public bool IsWarnEnabled { get { return logger.IsWarnEnabled; } }


        private void log(Exception exception, LogTag[] tag, string format, string function, object[] args, NLog.LogLevel level, string data = null)
        {
            if (logger.IsEnabled(level))
            {
                if (data.IsEmpty())
                {
                    runLog(exception, tag, format, function, args, level, data);
                }
                else
                {
                    Task.Run(() =>
                    {
                        runLog(exception, tag, format, function, args, level, data);
                    });
                }
            }
        }

        private void runLog(Exception exception, LogTag[] tag, string format, string function, object[] args, NLog.LogLevel level, string data)
        {
            LogEventInfo logInfo = createLogInfo(exception, tag, format, function, args, level, data);
            logger.Log(logInfo);
        }

        private LogEventInfo createLogInfo(Exception exception, LogTag[] tag, string format, string function, object[] args, NLog.LogLevel level, string data)
        {

            var logInfo = new LogEventInfo()
            {
                Level = level,
                LoggerName = logger.Name,
                Message = format,
                Parameters = args,
                Exception = exception
            };


            logInfo.Properties[FunctionPropName] = function;
            if (data.IsEmpty() == false)
            {
                //logInfo.Properties[DataPropName] = Infrastructure.Serializer.SerializerHelper.CompressString(data);
                //var rawLenght = data.Length;
                //var compressLenght = ((string)logInfo.Properties[DataPropName]).Length;

                //var asx= Infrastructure.Serializer.SerializerHelper.Serialize(data).Length;
                //var sxa = System.Text.ASCIIEncoding.Unicode.GetByteCount(data);

            }
            if (tag?.Any() == true)
            {
                logInfo.Properties[TagsPropName] = tag.Select(x => ((int)x).ToString()).Aggregate((a, b) => a + "," + b);
            }
            if (requestContext != null)
            {
                logInfo.Properties[SitePropName] = requestContext?.Site;

                if (requestContext.ApiAccount != null)
                {
                    logInfo.Properties[ApiAccountPropName] = requestContext.ApiAccount;
                }
                if (requestContext.UserId.IsEmpty() == false)
                {
                    logInfo.Properties[UserIdPropName] = requestContext.UserId;
                }
                if (requestContext.Version.IsEmpty() == false)
                {
                    logInfo.Properties[VersionPropName] = requestContext.Version;
                }
                if (requestContext.URL.IsEmpty() == false)
                {
                    logInfo.Properties[URLPropName] = requestContext.URL;
                }
                if (requestContext.UserAgent.IsEmpty() == false)
                {
                    logInfo.Properties[UserAgentPropName] = requestContext.UserAgent;
                }
            }
            return logInfo;
        }


        public void Debug(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Debug);
        }
        public void Debug(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Debug);
        }
        public void Debug(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Debug);
        }
        public void Debug(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Debug);
        }
        public void Debug(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Debug);
        }
        public void Debug(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Debug);
        }
        public void Debug(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Debug);
        }



        public void Trace(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Trace);
        }
        public void Trace(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Trace);
        }
        public void Trace(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Trace);
        }
        public void Trace(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Trace);
        }
        public void Trace(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Trace);
        }
        public void Trace(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Trace);
        }
        public void Trace(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Trace);
        }


        public void Info(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Info);
        }
        public void Info(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Info);
        }
        public void Info(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Info);
        }

        public void Info(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Info);
        }

        public void Info(string format, string data, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Info, data);
        }

        public void Info(string format, string data, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Info, data);
        }

        public void Info(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Info);
        }
        public void Info(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Info);
        }
        public void Info(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Info);
        }


        public void Error(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Error);
        }
        public void Error(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Error);
        }
        public void Error(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Error);
        }
        public void Error(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Error);
        }
        public void Error(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Error);
        }
        public void Error(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Error);
        }
        public void Error(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Error);
        }


        public void Warn(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Warn);
        }
        public void Warn(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Warn);
        }
        public void Warn(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Warn);
        }
        public void Warn(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Warn);
        }
        public void Warn(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Warn);
        }
        public void Warn(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Warn);
        }
        public void Warn(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Warn);
        }


        public void Fatal(Exception exception, [CallerMemberName] string function = null, params LogTag[] tags)
        {
            log(exception, tags, null, function, null, NLog.LogLevel.Fatal);
        }
        public void Fatal(string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, null, format, function, args, NLog.LogLevel.Fatal);
        }
        public void Fatal(string format, LogTag tag, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Fatal);
        }
        public void Fatal(string format, LogTag[] tags, [CallerMemberName] string function = null, params object[] args)
        {
            log(null, tags, format, function, args, NLog.LogLevel.Fatal);
        }
        public void Fatal(Exception exception, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, null, format, function, args, NLog.LogLevel.Fatal);
        }
        public void Fatal(Exception exception, LogTag tag, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, new LogTag[] { tag }, format, function, args, NLog.LogLevel.Fatal);
        }
        public void Fatal(Exception exception, LogTag[] tags, string format, [CallerMemberName] string function = null, params object[] args)
        {
            log(exception, tags, format, function, args, NLog.LogLevel.Fatal);
        }


    }
}
