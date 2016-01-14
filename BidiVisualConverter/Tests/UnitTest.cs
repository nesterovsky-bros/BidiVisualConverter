namespace Tests
{
  using System;
  using NesterovskyBros.Bidi;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class UnitTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      var input = "ןגראל";
      var expected = "לארגן";
      var result = BidiConverter.Convert(input, false, true);

      Assert.AreEqual(result, expected);
    }
  }
}
