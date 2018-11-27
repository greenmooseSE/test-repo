namespace StdLibTestCommon
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using StdLibWithTrackedFiles;

    [TestFixture]
    public abstract class ReadJsonFilesTestBase : UnitTestBase
    {
        /// <summary>
        ///     this is the only test treated as impacted by NCrunch when file is changed, IF it runs in a .NET Framework test
        ///     runner assembly.
        /// </summary>
        [Test]
        public void CanReadJson1FileFromBinOutput()
        {
            string fileContent = ReadFileFromStdLibBinOutput("Generated\\" + JsonFileCopiedToOutputName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }

        [Test]
        public void CanReadJsonFile2AsEmbeddedResource()
        {
            string fileContent =
                ReadFileFromStdLibBinAssemblyResource("Generated." + JsonFile2AsEmbeddedResourceName);
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }

        [Test]
        public void CanReadJsonFile3FromResources()
        {
            string fileContent = Resources.JsonFile3ReferencedByResourcesResx;
            Assert.IsNotEmpty(fileContent);
            LogIt($"Got content:\n{fileContent}\n");
        }
    }
}