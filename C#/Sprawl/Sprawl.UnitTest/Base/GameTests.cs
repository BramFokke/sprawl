using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sprawl.Base;
using Sprawl.Common.Time;

namespace Sprawl.UnitTest.Base
{

    [TestFixture()]
    public class GameTests
    {

        [Test()]
        public void TestLoad()
        {
            using (var game = new BaseGame())
            {
                var nowService = game.Extensions.Get<INowService>();
                Assert.AreEqual(DateTime.Now.Date, nowService.Now.Date);
            }
        }

    }
}
