using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Microsoft.Extensions.Configuration;
namespace ConfigurationCustom
{
    /// <summary>
    /// 定义一个定时器，每3秒钟刷新一次配置，配置的Key为"lastTime"
    /// </summary>
    internal class MyConfigurationProvider : ConfigurationProvider
    {
        Timer timer;
        public MyConfigurationProvider():base()
        {
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 3000;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Load(true);
        }

        public override void Load()
        {
            Load(false);
        }

        void Load(bool reload)
        {
            this.Data["lastTime"] = DateTime.Now.ToString();
            if (reload)
            {
                base.OnReload();
            }
        }
    }
}
