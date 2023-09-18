namespace ZipSharp.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs during archiving.
/// </summary>
public class ArchivingException : Exception
{
	public ArchivingException(string message) : base(message)
	{
	}
	
	public ArchivingException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
