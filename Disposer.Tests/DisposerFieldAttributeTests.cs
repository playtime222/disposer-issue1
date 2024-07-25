using Mefitihe.LamaHerd.Disposer;
using Mefitihe.LamaHerd.Disposer.Imp;
using Xunit;

namespace Disposer.Tests
{

    public class DisposerFieldAttributeTests 
    {
        [Fact]
        public void CtorDefaults()
        {
            var actual = new DisposerOrderAttribute();
            Assert.Equal(DisposerOrderAttribute.Default, actual.Order);
        }

        [Fact]
        public void Ctor()
        {
            var actual = new DisposerOrderAttribute { Order =  999};
            Assert.Equal(999, actual.Order);
        }
    }
}