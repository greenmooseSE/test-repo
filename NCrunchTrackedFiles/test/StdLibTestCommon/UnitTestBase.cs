namespace StdLibTestCommon
{
    using System;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;
    using StdLibWithTrackedFiles;

    [TestFixture]
    public abstract class UnitTestBase
    {
        protected void LogIt(string msg, params object[] args)
        {
            if (args.Length == 0)
                Console.WriteLine(msg);
            else
                Console.WriteLine(msg, args);
        }

        protected string ReadFileFromStdLibBinAssemblyResource(string relativePath)
        {
            string assemblyFilePath = typeof(Client).Assembly.Location;
            string rootNamespace = typeof(Client).Namespace;
            string resourcePath = $"{rootNamespace}." + relativePath;
            LogIt("Reading from resource '{0}' from assembly '{1}' .", resourcePath, assemblyFilePath);
            using (var reader =
                new StreamReader(typeof(Client).Assembly.GetManifestResourceStream(resourcePath)))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        protected string ReadFileFromStdLibBinOutput(string relativePath)
        {
            string assemblyFilePath = typeof(Client).Assembly.Location;
            string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);

            string fullFilePath = Path.Combine(assemblyDirPath, relativePath);
            LogIt("Reading from '{0}'.", fullFilePath);
            FileAssert.Exists(fullFilePath);
            return File.ReadAllText(fullFilePath);
        }

        protected string JsonFile2AsEmbeddedResourceName { get; } = "JsonFile2AsEmbeddedResource.json";

        protected string JsonFile3ReferencedByResourcesResx { get; } =
            "JsonFile3ReferencedByResourcesResx.json";

        protected string JsonFileCopiedToOutputName { get; } = "JsonFile1CopiedToOutput.json";
    }
}