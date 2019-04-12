namespace petclinicmicroservice.Interfaces
{
	public interface IReaderCommand<out TResult> : ICommand
	{
		TResult Result { get; }
	}
}
