using System.IO.Compression;
using System.Security.AccessControl;
using System.Text;

namespace ZipSharp.Archivers;

/// <summary>
/// Represents a ZIP archiver that implements the <see cref="IArchiver"/> interface.
/// </summary>
public class ZipArchiver : IArchiver, IDisposable
{
	private bool _disposed = false;
	
	
	/// <inheritdoc/>
	public void Archive(string source, string destination)
	{
		if(!Directory.Exists(source))
			throw new ArchivingException($"The source directory '{source}' does not exist.");
			
		if(!Directory.Exists(destination))
			throw new ArchivingException($"The destination directory '{destination}' does not exist.");
			
		try
		{
			// ZipFile.CreateFromDirectory(source, destination, CompressionLevel.Optimal, false, Encoding.UTF8);

			// Get the directory info for the destination directory
			var directoryInfo = new DirectoryInfo(destination);

			// Get the current access control settings for the directory
			var directorySecurity = directoryInfo.GetAccessControl();

			// Add a new access rule that grants write permission to everyone
			var accessRule = new FileSystemAccessRule("Everyone", FileSystemRights.Write, AccessControlType.Allow);
			directorySecurity.AddAccessRule(accessRule);

			// Set the new access control settings for the directory
			directoryInfo.SetAccessControl(directorySecurity);

			// The same method but with write permissions
			using (var zip = ZipFile.Open(destination, ZipArchiveMode.Create))
			{
				foreach(var file in Directory.GetFiles(source))
				{
					zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Fastest);
				}
			}
		}
		catch(Exception ex)
		{
			throw new ArchivingException($"An error occurred while archiving '{source}' to '{destination}'.", ex);
		}
	}

	/// <inheritdoc/>
	public void Archive(string source, string destination, ICustomArchivingAlgorithm algorithm)
	{
		if(!Directory.Exists(source))
			throw new ArchivingException($"The source directory '{source}' does not exist.");
			
		if(!Directory.Exists(destination))
			throw new ArchivingException($"The destination directory '{destination}' does not exist.");
		
		try
		{
			algorithm.Archive(source, destination);
		}
		catch(Exception ex)
		{
			throw new ArchivingException($"An error occurred while archiving '{source}' to '{destination}'.", ex);
		}
	}

	/// <inheritdoc/>
	public void Extract(string source, string destination)
	{
		throw new NotImplementedException();
	}
	
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
			return;
		
		if (disposing)
		{
			// Dispose managed resources
		}
		
		// Dispose unmanaged resources
		_disposed = true;
	}
}
