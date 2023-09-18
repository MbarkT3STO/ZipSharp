using System.Diagnostics;

namespace ZipSharp.Archivers;

public class RarArchiver : IArchiver, IDisposable
{
	bool _disposed = false;
	
	/// <inheritdoc/>
	public void Archive(string source, string destination)
	{
		if(!Directory.Exists(source))
			throw new ArchivingException($"The source directory '{source}' does not exist.");
		
		if(!Directory.Exists(destination))
			throw new ArchivingException($"The destination directory '{destination}' does not exist.");
			
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "rar",
				Arguments = $"a \"{destination}\" \"{source}\"",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};

			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();
			
			if(process.ExitCode != 0)
			{
				string error = process.StandardError.ReadToEnd();
				throw new ArchivingException($"An error occurred while archiving '{source}' to '{destination}'.\n{error}");
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
		if(!File.Exists(source))
			throw new ArchivingException($"The source archive '{source}' does not exist.");
		
		if(!Directory.Exists(destination))
			throw new ArchivingException($"The destination directory '{destination}' does not exist.");
			
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "unrar",
				Arguments = $"x \"{source}\" \"{destination}\"",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};

			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();
			
			if(process.ExitCode != 0)
			{
				string error = process.StandardError.ReadToEnd();
				throw new ArchivingException($"An error occurred while extracting '{source}' to '{destination}'.\n{error}");
			}
		}
		catch(Exception ex)
		{
			throw new ArchivingException($"An error occurred while extracting '{source}' to '{destination}'.", ex);
		}
	}
	
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	
	protected virtual void Dispose(bool disposing)
	{
		if(_disposed)
			return;
			
		if(disposing)
		{
			// Dispose managed resources here.
		}
		
		// Dispose unmanaged resources here.
		
		_disposed= true;
	}
}
