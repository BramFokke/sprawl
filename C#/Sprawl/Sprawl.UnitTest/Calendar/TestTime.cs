using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sprawl.Calendar;

namespace Sprawl.UnitTest.Calendar
{

    [TestFixture()]
    public class TestTime
    {

        [Test()]
        public void TestFormat1()
        {
            var time = new Time(1.5f);
            Assert.AreEqual("1.12:00", time.ToString());
        }

    }
}
