using System;
using System.Linq;
using NUnit.Framework;
using Sprawl.Common;
using Sprawl.Common.Extensibility;
using Sprawl.Common.Time;

namespace Sprawl.UnitTest.Common.Extensibility
{

    [TestFixture()]
    public class TestComposition
    {

        [Test()]
        public void CreateService()
        {
            using (var game = new Game(new Mods()
                            .AddTypes(typeof(NowService2000))))
            {
                var nowService = game.Extensions.Get<INowService>();
                Assert.NotNull(nowService);
            }
        }

        //[Test()]
        //public void ServicesAreSingleton()
        //{
        //    using (var game = new Game(new Mods()
        //                    .AddTypes(typeof(NowService2000))))
        //    {
        //        var nowService1 = game.Extensions.Get<INowService>();
        //        var nowService2 = game.Extensions.Get<INowService>();
        //        Assert.AreSame(nowService1, nowService2);

        //        var allServices = game.Extensions.AllExtensions().OfType<INowService>().ToList();
        //        Assert.AreEqual(1, allServices.Count);
        //        Assert.AreNotSame(nowService1, allServices.Single());
        //    }
        //}

        [Test()]
        public void TestCascadeSuccess()
        {
            using (var game = new Game(new Mods()
                            .AddTypes(typeof(NowService2000))
                            .AddTypes(typeof(NowService2001))))
            {
                var nowService = game.Extensions.Get<INowService>();
                Assert.AreEqual(new DateTime(2001, 1, 1), nowService.Now);
            }
        }

        private class NowService2000 : Extension, INowService
        {
            public DateTime Now => new DateTime(2000, 1, 1);
            public DateTime UtcNow => new DateTime(2000, 1, 1);
        }

        private class NowService2001 : Extension, INowService
        {
            public DateTime Now => new DateTime(2001, 1, 1);
            public DateTime UtcNow => new DateTime(2001, 1, 1);
        }
    }
}
