using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Helper.Extensions
{
    public static class LoggerExtensions
    {
        private static string GetFileName(string filePath)
            => Path.GetFileNameWithoutExtension(filePath ?? "UnknownFile");

        private static void FallbackLog(string level, string message, string filePath, string caller) =>
            Console.WriteLine($"[{level} {GetFileName(filePath)}.{caller}] {message}");

        public static void Info(this ILogger logger, string message, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            if (logger is null)
                FallbackLog("🟨 INFO", message, filePath, caller);
            else
                logger.LogInformation("[🟨 INFO [{File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
        }

        public static void Error(this ILogger logger, string message, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            if (logger is null)
                FallbackLog("🟦 ERROR", message, filePath, caller);
            else
                logger.LogError("[🟦 ERROR {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
        }
        
        public static void Debug(this ILogger logger, string message, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            if (logger is null)
                FallbackLog("🟦 ERROR", message, filePath, caller);
            else
                logger.LogDebug("[🟦 ERROR {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
        }

        public static void Trace(this ILogger logger, string message, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            if (logger is null)
                FallbackLog("⬜ TRACE", message, filePath, caller);
            else
                logger.LogInformation("[⬜ TRACE {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
        }

        public static void Success(this ILogger logger, string message, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            if (logger is null)
                FallbackLog("🟩 SUCCESS", message, filePath, caller);
            else
                logger.LogInformation("[🟩 SUCCESS {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
        }

        public static void Exception(this ILogger logger, AppException ex, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            var message = ex?.InnerException?.Message ?? ex?.Message ?? "Unknown AppException";
            if (logger is null)
            {
                FallbackLog("🟦 ERROR", message, filePath, caller);
                Console.WriteLine(ex);
            }
            else
            {
                logger.LogError("[🟦 ERROR {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
                logger.LogError(ex, "[🟥 APP EXCEPTION stack trace");
            }
        }

        public static void Exception(this ILogger logger, Exception ex, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
        {
            var message = ex?.InnerException?.Message ?? ex?.Message ?? "Unknown Exception";
            if (logger is null)
            {
                FallbackLog("❌ ERROR", message, filePath, caller);
                Console.WriteLine(ex);
            }
            else
            {
                logger.LogError("[❌ ERROR {File}.{Caller}] : {Message}", GetFileName(filePath), caller, message);
                logger.LogError(ex, "[❌ EXCEPTION stack trace");
            }
        }
    }
}