using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringUnitTest
{
  [TestClass]
  public class UnitTest1
  {
    //Replace

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("string", "s", "t", "ttring")]
    [DataRow("strinh", "h", "g", "string")]
    public void Replace_Only_One_Symbol(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("sstring", "ss", "k", "ktring")]
    [DataRow("striiing", "iii", "i", "string")]
    public void Replace_Multiple_Symbols_With_One(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("string", "i", "iii", "striiing")]
    [DataRow("string", "g", "ggg", "stringgg")]
    public void Replace_One_Symbol_With_Multipe(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Throws_Argument_Null_Exception()
    {
      "string".Replace(null, "g");
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [ExpectedException(typeof(ArgumentException))]
    public void Throws_Argument_Exception()
    {
      "string".Replace("", "g");
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("string", "b", "g", "string")]
    [DataRow("string", "bring", "g", "string")]
    [DataRow("string", "sing", "s", "string")]
    public void Nothing_To_Replace(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("string", "s", null, "tring")]
    [DataRow("string", "r", "", "sting")]
    public void Cuts_OldValue_If_NewValue_Is_Empty_Or_Null(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Replace")]
    [DataRow("string", "t", " ", "s ring")]
    [DataRow("string", "s", " ", " tring")]
    [DataRow("string", "t", "  ", "s  ring")]
    [DataRow("string", "g", " ", "strin ")]
    public void Inserts_Gap_If_NewValue_Is_Blank(string value, string oldValue, string newValue, string expected)
    {
      var actual = value.Replace(oldValue, newValue);

      Assert.AreEqual(expected, actual);
    }

    //Split

    [TestMethod]
    [TestCategory("String.Split")]
    [DataRow("Hello, world", ",", new string[] {"Hello", " world"})]
    [DataRow("Hello, world", ", ", new string[] {"Hello", "world"})]
    [DataRow("Hello, world", " ", new string[] {"Hello,", "world"})]
    [DataRow("Hello,   world", ",", new string[] { "Hello", "   world" })]
    [DataRow("Hello,  , world", ",", new string[] { "Hello", "  ", " world" })]
    [DataRow("Hello,  , world", " ", new string[] { "Hello,", "", ",", "world" })]
    [DataRow("Hello | world", "|", new string[] {"Hello ", " world"})]
    [DataRow("Hello | world", " | ", new string[] {"Hello", "world"})]
    public void Splits_By_Separator(string value, string separator, string[] expected)
    {
      var actual = value.Split(separator);

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Split")]
    [DataRow("Hello,     world", " ", new string[] { "Hello,", "world" })]
    [DataRow("Hello,  |   world", " ", new string[] { "Hello,", "|", "world" })]
    [DataRow("Hello,  , world", " ", new string[] { "Hello,", ",", "world" })]
    public void Split_RemoveEmptyEntries(string value, string separator, string[] expected)
    {
      var actual = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Split")]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Split_Throws_ArgumentOutOfRangeException()
    {
      "hello, world".Split(',', -1);
    }

    [TestMethod]
    [TestCategory("String.Split")]
    [DataRow("Hello, world, this, is, new, string", ", ", 3, new string[] { "Hello", "world", "this, is, new, string" })]
    [DataRow("Hello, world this is new string", " ", 1, new string[] { "Hello, world this is new string" })]
    [DataRow("Hello, world string", " ", 5, new string[] { "Hello,", "world", "string" })]
    public void Splits_With_Max_Number_Of_Substrings(string value, string separator, int count, string[] expected)
    {
      var actual = value.Split(separator, count);
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Split")]
    [DataRow("Hello, world", "|", new string[] { "Hello, world" })]
    [DataRow("Hello, world", "", new string[] { "Hello, world" })]
    [DataRow("Hello, world", null, new string[] { "Hello, world" })]
    public void No_Separator_Matches(string value, string separator, string[] expected)
    {
      var actual = value.Split(separator);

      CollectionAssert.AreEqual(expected, actual);
    }

    //Substring

    [TestMethod]
    [TestCategory("String.Substring")]
    [DataRow("Hello, world", 2, "llo, world")]
    [DataRow("Hello, world", 0, "Hello, world")]
    [DataRow("Hello, world", 12, "")]
    public void Substring_To_String_End(string value, int startIndex, string expected)
    {
      var actual = value.Substring(startIndex);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Substring")]
    [DataRow("Hello, world", 2, 3, "llo")]
    [DataRow("Hello, world", 0, 12, "Hello, world")]
    [DataRow("Hello, world", 0, 0, "")]
    public void Substring_Length(string value, int startIndex, int length, string expected)
    {
      var actual = value.Substring(startIndex, length);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [TestCategory("String.Substring")]
    [DataRow("Hello, world", -1, 10, "StartIndex cannot be less than zero. (Parameter 'startIndex')")]
    [DataRow("Hello, world", 15, 10, "startIndex cannot be larger than length of string. (Parameter 'startIndex')")]
    [DataRow("Hello, world", 12, 2, "Index and length must refer to a location within the string. (Parameter 'length')")]
    [DataRow("Hello, world", 0, -1, "Length cannot be less than zero. (Parameter 'length')")]
    public void Substring_Throws_ArgumentOutOfRangeException_Message(string value, int startIndex, int length, string exceptionMessage)
    {
      try
      {
        value.Substring(startIndex, length);
        Assert.Fail("Exception was not thrown");
       }
      catch (ArgumentOutOfRangeException e)
      {
        Assert.AreEqual(exceptionMessage, e.Message);
      }
    }
  }
}
