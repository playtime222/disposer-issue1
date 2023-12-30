
using DisposingLama.Old;
using Playtime222.PostsharpAspects.Disposer;
using Xunit;

namespace Disposer.Tests
{

    public class DisposerFieldAttributeTests 
    {
        [Fact]
        public void CtorDefaults()
        {
            var actual = new DisposerFieldAttribute();
            Assert.Equal(false, actual.Excluded);
            Assert.Equal(1000, actual.Order);
        }

        [Fact]
        public void Default()
        {
            Assert.Equal(false, DisposerFieldAttribute.Default.Excluded);
            Assert.Equal(1000, DisposerFieldAttribute.Default.Order);
        }

        [Fact]
        public void Ctor()
        {
            var actual = new DisposerFieldAttribute {Excluded = true, Order =  999};
            Assert.Equal(true, actual.Excluded);
            Assert.Equal(999, actual.Order);
        }
    }
}