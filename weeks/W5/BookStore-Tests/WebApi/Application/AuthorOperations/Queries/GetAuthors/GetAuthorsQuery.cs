using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.Queries.GetAuthors;

public class GetAuthorsQuery
{
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<AuthorsViewModel> Handle()
    {
        var authorList = _context.Authors.OrderBy(b => b.Id).ToList<Author>();
        List<AuthorsViewModel> authorsViewModelList = _mapper.Map<List<AuthorsViewModel>>(authorList);
        return authorsViewModelList;
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}