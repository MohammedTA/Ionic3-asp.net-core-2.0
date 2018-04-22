using MediatR;

namespace Khairia.Infrastructure.Forms
{
	public interface IForm<in TRequest, out TResponse> :
		IRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
	}
}