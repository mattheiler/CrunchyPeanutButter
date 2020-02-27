using CrunchyPeanutButter.Domain.Models;
using MediatR;

namespace CrunchyPeanutButter.Domain.Queries.Bars
{
    public class FindBarQuery : IRequest<Bar>
    {
        public FindBarQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}