using Business.Query;
using Business.Validation;
using DataAccess;
using Domain.Definition;
using System.Data;

namespace Business.Services;

public class QueryService
{
    private readonly DataRepository _dataRepository;
    private readonly QueryBuilder _queryBuilder;//=new QueryBuilder();
    private readonly QueryValidator _validator;

    public QueryService(
    DataRepository dataRepository,
    QueryBuilder queryBuilder,
    QueryValidator validator)
    {
        _dataRepository = dataRepository;
        _queryBuilder = queryBuilder;
        _validator = validator;
    }

    public DataTable Execute(QueryDefinition query)
    {
        _validator.Validate(query);
        string sql = _queryBuilder.Build(query);
        Console.WriteLine(sql); // Command Testing

        return _dataRepository.ExecuteQuery(sql);
    }

}