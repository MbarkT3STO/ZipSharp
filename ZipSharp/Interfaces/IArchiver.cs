namespace ZipSharp.Interfaces;

/// <summary>
/// Defines methods for archiving and extracting files and directories.
/// </summary>
public interface IArchiver
{
	/// <summary>
	/// Archives the specified source file or directory to the specified destination.
	/// </summary>
	/// <param name="source">The path of the file or directory to archive.</param>
	/// <param name="destination">The path of the archive file to create.</param>
	void Archive(string source, string destination);
	
	/// <summary>
	/// Archives the specified source file or directory to the specified destination using the specified custom archiving algorithm.
	/// </summary>
	/// <param name="source">The path to the file or directory to be archived.</param>
	/// <param name="destination">The path to the archive file to be created.</param>
	/// <param name="algorithm">The custom archiving algorithm to use.</param>
	void Archive(string source, string destination, ICustomArchivingAlgorithm algorithm);


	/// <summary>
	/// Extracts the specified archive file to the specified destination directory.
	/// </summary>
	/// <param name="source">The path of the archive file to extract.</param>
	/// <param name="destination">The path of the directory to extract the archive to.</param>
	void Extract(string source, string destination);
}
