using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateLibrary
{
    public class Adjuster
    {
        decimal _percent;
        public const decimal StandardPercent = 50.0M;

        public Adjuster(decimal percent)
        {
            _percent = percent;
        }

        public decimal Apply(decimal amount)
        {
            return amount * (1.0M + _percent / 100);
        }

        public static decimal ApplyStandard(decimal amount)
        {
            return amount * (1.0M + StandardPercent / 100);
        }
    }
}
