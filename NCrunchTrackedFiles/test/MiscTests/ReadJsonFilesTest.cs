namespace MiscTests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using StdLibTestCommon;

    [TestFixture]
    internal class ReadJsonFilesTest : MiscTest, IResourceFileTest
    {
        /// <inheritdoc />
        public void CanReadJsonFile2AsEmbeddedResource()
        {
            string fileContent =
                ReadFileFromStdLibBinAssemblyResource("Generated." + JsonFile2AsEmbeddedResourceName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }

        /// <inheritdoc />
        public void CanReadJsonFile3FromResources()
        {
            throw new NotImplementedException("TODO:(/20181127) Implement CanReadJsonFile3FromResources.");
        }

        [Test]
        public void CanReadJson1FileFromFile()
        {
            string fileContent = ReadFileFromStdLibBinOutput("Generated\\" + JsonFileCopiedToOutputName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }
    }
}