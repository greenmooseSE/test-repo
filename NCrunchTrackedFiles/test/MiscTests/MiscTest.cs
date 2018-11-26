namespace MiscTests
{
    using System;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;
    using StdLibWithTrackedFiles;

    [TestFixture]
    internal abstract class MiscTest
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
            string rootNamespace = typeof(Client).Namespace;
            string resourcePath = $"{rootNamespace}." + relativePath;
            //string resourcePath = $"{rootNamespace}." + relativePath;
            LogIt("Reading from '{0}'.", resourcePath);
            using (var reader =
                new StreamReader(typeof(Client).Assembly.GetManifestResourceStream(resourcePath)))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        protected string ReadFileFromStdLibBinOutput(string relativePath)
        {
            //var slnFilePath = NCrunch.Framework.NCrunchEnvironment.GetOriginalSolutionPath();
            string assemblyFilePath = typeof(Client).Assembly.Location;
            string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);

            string fullFilePath = Path.Combine(assemblyDirPath, relativePath);
            LogIt("Reading from '{0}'.", fullFilePath);
            FileAssert.Exists(fullFilePath);
            return File.ReadAllText(fullFilePath);
        }

        protected string JsonFile2AsEmbeddedResourceName { get; } = "JsonFile2AsEmbeddedResource.json";
        protected string JsonFileCopiedToOutputName { get; } = "JsonFile1CopiedToOutput.json";
    }
}