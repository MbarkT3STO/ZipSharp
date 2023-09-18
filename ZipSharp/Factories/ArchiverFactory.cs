namespace ZipSharp.Factories;

/// <summary>
/// Factory class for creating archivers based on the file type.
/// </summary>
public class ArchiverFactory
{
    /// <summary>
    /// Creates an archiver based on the specified file type.
    /// </summary>
    /// <param name="fileType">The type of the file to be archived.</param>
    /// <returns>An instance of the IArchiver interface.</returns>
    public IArchiver CreateArchiver(FileType fileType)
    {
        switch(fileType)
        {
            case FileType.Zip:
                return new ZipArchiver();
            default:
                throw new NotSupportedException($"The file type {fileType} is not supported.");
        }
    }
}
