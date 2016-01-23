using OpenTK;
using Ploeh.AutoFixture;

namespace Game.NET.Tests
{
    public static class FixtureExtensions
    {
        public static void OmitVector3Properties(this Fixture fixture)
        {
            fixture.Customize<Vector3>(composer => composer
                .Without(v => v.Xy)
                .Without(v => v.Xz)
                .Without(v => v.Yx)
                .Without(v => v.Yz)
                .Without(v => v.Zx)
                .Without(v => v.Zy)
                .Without(v => v.Xzy)
                .Without(v => v.Yxz)
                .Without(v => v.Yzx)
                .Without(v => v.Zxy)
                .Without(v => v.Zyx));
        }
    }
}
