namespace petclinicmicroservice.Interfaces
{
	public interface INonQueryCommand : ICommand
	{
		int AffectedRowsCount { get; }
		int ReturnValue { get; }
	}
}
