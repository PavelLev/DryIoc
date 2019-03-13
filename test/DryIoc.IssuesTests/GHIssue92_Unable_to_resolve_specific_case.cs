using System;
using NUnit.Framework;

namespace DryIoc.IssuesTests
{
    [TestFixture]
    public class GHIssue92_Unable_to_resolve_specific_case
    {
        [Ignore("fixme")]
        [Test]
        public void Test()
        {
            var container = new Container();

            container.UseInstance(new SomeConfiguration());

            container.Register(
                made: Made.Of(
                    () => new Dependency(Arg.Index<string>(0), Arg.Of<string>(), Arg.Index<string>(1)),
                    request => request.Container.Resolve<SomeConfiguration>().Configuration,
                    request => request.Container.Resolve<SomeConfiguration>().AnotherConfiguration
                    )
                );

            var getDependency = container.Resolve<Func<string, Dependency>>();

            getDependency("");
        }

        class Dependency
        {
            public Dependency()
            {

            }

            public Dependency(string configuration, string runtimeValue, string anotherConfiguration)
            {

            }
        }

        class SomeConfiguration
        {
            public string Configuration { get; set; }
            public string AnotherConfiguration { get; set; }
        }
    }
}