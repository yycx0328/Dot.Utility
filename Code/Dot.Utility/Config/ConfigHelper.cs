﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dot.Utility.Config
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件中的AppSettings的指定键的值，并转换为指定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetAppSettingOrDefault<T>(string key, T defaultValue = default(T))
            where T : struct
        {
            var value = GetAppSettingOrDefault(key);
            if (!string.IsNullOrWhiteSpace(value))
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    try
                    {
                        return (T)converter.ConvertFromString(value);
                    }
                    catch { }
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// 获取配置文件中的AppSettings的指定键的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetAppSettingOrDefault(string key, string defaultValue = "")
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        /// <summary>
        /// 获取配置文件中的ConnectionString的指定键的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetConnectionStringOrDefault(string key, string defaultValue = "")
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString ?? defaultValue;
        }

        /// <summary>
        /// 是否存在key配置项
        /// </summary>
        /// <param name="key">不区分大小写</param>
        /// <returns></returns>
        public static bool ExistsAppSetting(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Any(k => k.Equals(key, StringComparison.OrdinalIgnoreCase));
        }


        //public static void Set(string key,string value)
        //{
        //    Properties.Settings connset = Properties.Settings.Default;
        //    constr = connset.ConnectionString;
        //    ConfigurationManager.AppSettings.Set(key, value);
        //}
    }
}
