namespace StdLibTestCommon
{
    using System;
    using System.Linq;

    public interface IResourceFileTest
    {
        #region Public members

        void CanReadJson1FileFromFile();
        void CanReadJsonFile2AsEmbeddedResource();
        void CanReadJsonFile3FromResources();

        #endregion
    }
}