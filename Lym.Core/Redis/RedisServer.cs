using CSRedis;
using Lym.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lym.Core.Redis
{
    public static class RedisServer
    {
        public static CSRedisClient Cache;
        public static CSRedisClient Sequence;
        public static CSRedisClient Session;

        public static void Initalize()
        {
            Cache = new CSRedisClient(AppSettings.Configuration["RedisServer:Cache"]);
            Sequence = new CSRedisClient(AppSettings.Configuration["RedisServer:Sequence"]);
            Session = new CSRedisClient(AppSettings.Configuration["RedisServer:Session"]);
        }
    }
}
