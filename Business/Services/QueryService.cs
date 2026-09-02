using Business.Query;
using Business.Validation;
using DataAccess;
using Domain.Definition;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

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
        string sql = _queryBuilder.Build(query, out var parameters);
        //Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(
        // query, new JsonSerializerOptions
        // {
        //     WriteIndented = true
        // }));
        //Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(
        // parameters, new JsonSerializerOptions
        // {
        //     WriteIndented = true
        // }));
        Debug.WriteLine(sql);
        return _dataRepository.ExecuteQuery(sql, parameters);
    }

}
