using System;
using AutoMapper;
using CrunchyPeanutButter.Core.GetFoos;

namespace CrunchyPeanutButter.Web.Models.Foos
{
    [AutoMap(typeof(GetFoosQueryResult))]
    public class GetFoosResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}