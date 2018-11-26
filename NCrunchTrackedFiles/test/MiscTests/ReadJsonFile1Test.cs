namespace MiscTests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    internal class ReadJsonFile1Test : MiscTest
    {
        [Test]
        public void CanReadJson1FileFromFile()
        {
            string fileContent = ReadFileFromStdLibBinOutput("Generated\\" + JsonFileCopiedToOutputName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }

        [Test]
        public void CanReadJson1FileFromResource()
        {
            string fileContent =
                ReadFileFromStdLibBinAssemblyResource("Generated." + JsonFile2AsEmbeddedResourceName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }
    }
}