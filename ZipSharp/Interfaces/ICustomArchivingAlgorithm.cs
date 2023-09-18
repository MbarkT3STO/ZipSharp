namespace ZipSharp.Interfaces;

/// <summary>
/// Represents a custom archiving algorithm that can be used to archive files and directories.
/// </summary>
public interface ICustomArchivingAlgorithm
{
    /// <summary>
    /// Archives the specified source file or directory to the specified destination.
    /// </summary>
    /// <param name="source">The path of the file or directory to archive.</param>
    /// <param name="destination">The path of the archive file to create.</param>
    void Archive(string source, string destination);
}
