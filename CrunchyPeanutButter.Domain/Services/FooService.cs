using System.Threading;
using System.Threading.Tasks;
using CrispyBacon.Commands;
using CrunchyPeanutButter.Domain.Commands.Foos;
using CrunchyPeanutButter.Domain.Models.Foos;
using CrunchyPeanutButter.Domain.Stores;

namespace CrunchyPeanutButter.Domain.Services
{
    public class FooService :
        ICommandHandler<CreateFooCommand, Foo>,
        ICommandHandler<UpdateFooCommand, Foo>,
        ICommandHandler<DeleteFooCommand, bool>
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

        public async Task<bool> Handle(DeleteFooCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Foos.FindAsync(request.Id);
            if (entity == null)
                return false;

            _context.Foos.Remove(entity);

            await _context.SaveAsync(cancellationToken);

            return true;
        }

        public async Task<Foo> Handle(UpdateFooCommand request, CancellationToken cancellationToken)
        {
            var foo = request.Foo;

            _context.Foos.Update(foo);

            await _context.SaveAsync(cancellationToken);

            return foo;
        }
    }
}