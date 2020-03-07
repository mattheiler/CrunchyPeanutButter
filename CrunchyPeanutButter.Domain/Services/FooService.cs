using System.Threading;
using System.Threading.Tasks;
using CrunchyPeanutButter.Domain.Aggregates.Foos;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Stores;
using MediatR;

namespace CrunchyPeanutButter.Domain.Services
{
    public class FooService :
        IRequestHandler<CreateFooCommand, Foo>,
        IRequestHandler<UpdateFooCommand, Foo>,
        IRequestHandler<DeleteFooCommand, bool>
    {
        private readonly ICrunchyPeanutButterUnitOfWork _context;

        public FooService(ICrunchyPeanutButterUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Foo> Handle(CreateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            await _context.Foos.AddAsync(foo, cancellationToken);

            await _context.SaveAsync(cancellationToken);

            return foo;
        }

        public async Task<Foo> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            _context.Foos.Update(foo);

            await _context.SaveAsync(cancellationToken);

            return foo;
        }

        public async Task<bool> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Foos.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }
    }
}