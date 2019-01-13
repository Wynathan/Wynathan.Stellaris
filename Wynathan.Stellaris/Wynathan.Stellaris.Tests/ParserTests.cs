using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wynathan.Stellaris.Common.Modding.Models;
using Wynathan.Stellaris.Common.Parsing;

namespace Wynathan.Stellaris.Tests
{
    [TestClass]
    public class ParserTests
    {
        private const string sampleNameListsFilePath = ".auxiliary/TestData/sample-name_lists.txt";

        [TestMethod]
        public void Parser_Parse_1()
        {
            var entities = Parser.Parse<NameList>(sampleNameListsFilePath);
        }
    }
}
