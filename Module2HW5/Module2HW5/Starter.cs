using System;
using System.IO;
using Module2HW5.Exceptions;
using Module2HW5.Services;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Starter
    {
        private readonly IConfigService _configService;
        private readonly IActions _actions;
        public Starter(ILoger loger, IConfigService configService)
        {
            Loger = loger;
            _actions = new Actions(Loger);
            _configService = configService;
        }

        public ILoger Loger { get; }

        public void Run()
        {
            var rnd = new Random();
            for (var i = 0; i < _configService.Config.LogerConfig.CountOfLogs; i++)
            {
                try
                {
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            _actions.Method1();
                            break;
                        case 2:
                            _actions.Method2();
                            break;
                        default:
                            _actions.Method3();
                            break;
                    }
                }
                catch (BusinessException businessException)
                {
                    Loger.LogWarning($"Action got this custom Exception: {businessException.Message} in method: {businessException.TargetSite.Name}");
                }
                catch (Exception exception)
                {
                    Loger.LogError($"Action failed by a reason: {exception.Message} in method {exception.TargetSite.Name}");
                }
            }
        }
    }
}