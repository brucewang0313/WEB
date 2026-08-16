using ShapeLibrary;

namespace ShapeLibraryTest
{
    [TestClass]
    public sealed class MyRectangleTests
    {
        [TestMethod()]
        public void GivenRectangle_Width_6_Height_5_WhenComputeArea_Then30()
        {
            double expected = 30;// 一定要在actual之前
            MyRectangle given = new MyRectangle(6, 5);
            double actual = given.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [DynamicData(nameof(GetRectangleSource))]
        [TestMethod]
        public void Rectangle_GetAreaTest(double width, double height, double expected)
        {
            var given = new MyRectangle(width, height);
            double actual = given.GetArea();
            Assert.AreEqual(expected, actual);
        }
        private static IEnumerable<object[]> GetRectangleSource()
        {
            //{width, height, expected}
            yield return new object[] { 6, 5, 30 };
            yield return new object[] { 7, 3, 21 };
            yield return new object[] { 9, 13, 117 };
        }
    }
}
