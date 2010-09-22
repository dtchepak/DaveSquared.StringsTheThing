using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public abstract class ConcernFor<TSubject>
    {
        [SetUp]
        public void SetUp()
        {
            Context();
            Subject = CreateSubject();
            Because();
        }

        protected TSubject Subject { get; set; }
        protected virtual void Context() { }
        protected abstract TSubject CreateSubject();
        protected virtual void Because() { }
    }
}