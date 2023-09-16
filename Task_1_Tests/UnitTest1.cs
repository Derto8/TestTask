using Task_1;

namespace Task_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_String_True_Returned1()
        {
            string input = "(a[b{c}]d)";

            Assert.IsTrue(BracketValidator.Validate(input));
        }

        [TestMethod]
        public void Check_String_False_Returned2()
        {
            string input = "([)]";

            Assert.IsFalse(BracketValidator.Validate(input));
        }

        [TestMethod]
        public void Check_String_False_Returned3()
        {
            string input = "{[}]";

            Assert.IsFalse(BracketValidator.Validate(input));
        }

        [TestMethod]
        public void Check_String_Fasle_Returned4()
        {
            string input = "(((){}[]]]])(";

            Assert.IsFalse(BracketValidator.Validate(input));
        }

        [TestMethod]
        public void Check_String_True_Returned5()
        {
            string input = "(){}[][][]()";

            Assert.IsTrue(BracketValidator.Validate(input));
        }

        [TestMethod]
        public void Check_String_True_Returned6()
        {
            string input = "({[]})()[]";

            Assert.IsTrue(BracketValidator.Validate(input));
        }


    }
}