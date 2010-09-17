using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public abstract class ConcernFor<T>
    {
        [SetUp]
        public void SetUp()
        {
            Context();
            Subject = CreateSubject();
            Because();
        }

        protected T Subject { get; set; }
        protected virtual void Context() { }
        protected abstract T CreateSubject();
        protected virtual void Because() { }
    }
}