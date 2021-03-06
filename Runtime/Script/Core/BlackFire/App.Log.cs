﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        #region Log

        private static void LogCallback(LogLevel logLevel, object message)
        {
            var logMessage = string.Empty;
            switch (logLevel)
            {
                case LogLevel.Trace:
                    logMessage = string.Format("<color=#AAAAAA>{0}:</color>{1}", logLevel, message);
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Debug:
                    logMessage = string.Format("<color=white>{0}:</color>{1}", logLevel, message);
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Info:
                    logMessage = string.Format("<color=green>{0}:</color>{1}", logLevel, message);
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Warn:
                    logMessage = string.Format("<color=yellow>{0}:</color>{1}", logLevel, message);
                    Debug.LogWarning(logMessage);
                    break;
                case LogLevel.Error:
                    logMessage = string.Format("<color=#FF3399>{0}:</color>{1}", logLevel, message);
                    Debug.LogError(logMessage);
                    break;
                case LogLevel.Fatal:
                    logMessage = string.Format("<color=red>{0}:</color>{1}", logLevel, message);
                    Debug.LogException(new System.Exception(logMessage));
                    break;
                default:
                    break;
            }

            BlackFire.Log.EnLogFileQueue(logMessage);
        }



        #endregion
    }
}