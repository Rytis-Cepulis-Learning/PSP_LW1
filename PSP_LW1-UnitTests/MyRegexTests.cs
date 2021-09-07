using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class MyRegexTests
    {
        readonly MyRegex _myRegex = new MyRegex();
        readonly string _simpleStr = "str";
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            };

        [TestMethod]
        public void IsHaveAtSign_WithSymbol_Correct()
        {
            var str = _simpleStr + "@";

            var result = _myRegex.IsHaveAtSymbol(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveAtSign_NoAtSign_Incorrect()
        {
            var result = _myRegex.IsHaveAtSymbol(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFirstSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = "%" + _simpleStr;

            var result = _myRegex.IsFirstSpecialCharacter(str, _specialChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsFirstSpecialCharacter(_simpleStr, _specialChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = _simpleStr + "%";

            var result = _myRegex.IsLastSpecialCharacter(str, _specialChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsLastSpecialCharacter(_simpleStr, _specialChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveTwoOrMoreConsecutiveSpecialChars_HasTwo_Incorrect()
        {
            var str = _simpleStr + "%*";

            var result = _myRegex.IsHaveTwoOrMoreConsecutiveSpecialChars(str, _specialChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveUppercase_WithUppercase_Correct()
        {
            var str = _simpleStr + "U";

            var result = _myRegex.IsHaveUppercase(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveUppercase_NoUppercase_Incorrect()
        {
            var result = _myRegex.IsHaveUppercase(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveSpecialCharacter_HasSpecialSymbol_Correct()
        {
            var str = _simpleStr + "%";

            var result = _myRegex.IsHaveAllowedSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveSpecialCharacter_NoSpecialSymbol_Incorrect()
        {
            var result = _myRegex.IsHaveAllowedSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveSpecialCharacter_HasNotAllowedSpecialSymbol_Incorrect()
        {
            var str = _simpleStr + "(";

            var result = _myRegex.IsHaveAllowedSpecialCharacter(str);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnlyNumbers_NumberStr_Correct()
        {
            var str = "1234567890";

            var result = _myRegex.IsOnlyNumbers(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnlyNumbers_NotOnlyNumberStr_Incorrect()
        {
            var str = _simpleStr + "1234567890";

            var result = _myRegex.IsOnlyNumbers(str);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnlyLetters_OnlyLettersStr_Correct()
        {
            var result = _myRegex.IsOnlyLetters(_simpleStr);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnlyLetters_NotOnlyLettersStr_Incorrect()
        {
            var str = _simpleStr + "1234567890";

            var result = _myRegex.IsOnlyLetters(str);

            Assert.IsFalse(result);
        }
    }
}
