using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATecTasks.DomainTest.Utils
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false, $"Expected message '{message}'");
            }
        }
    }
}
