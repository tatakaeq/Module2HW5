using System;
using Module2HW5.Exceptions;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class Actions : IActions
    {
        private readonly ILoger _loger;

        public Actions(ILoger loger)
        {
            _loger = loger;
        }

        public bool Method1()
        {
            _loger.LogInfo($"Start method: {nameof(Method1)}");
            return true;
        }

        public bool Method2()
        {
            throw new BusinessException($"Skipped logic in method");
        }

        public bool Method3()
        {
            throw new Exception("I broke a logic");
        }
    }
}