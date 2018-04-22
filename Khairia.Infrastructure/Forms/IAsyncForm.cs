using MediatR;

namespace Khairia.Infrastructure.Forms
{
	public interface IAsyncForm<in TRequest, TResponse> :
		IAsyncRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
	}
}