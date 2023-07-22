using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Models;
using SipayApi.Data.Repository;
using SipayApi.Schema;

namespace SipayApi.Service;



[ApiController]
[Route("sipy/api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository repository;
    private readonly IMapper mapper;
    public TransactionController(ITransactionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }



    [HttpPost]
    public ApiResponse Post([FromBody] TransactionRequest request)
    {
        var entity = mapper.Map<TransactionRequest, Transaction>(request);
        repository.Insert(entity);
        repository.Save();
        return new ApiResponse();
    }

    [HttpGet]
    public IActionResult GetByParameter([FromQuery] TransactionParameters param)
    {
        var filterList = repository.GetByParameter(x => (x.AccountNumber == param.AccountNumber) && (x.ReferenceNumber == param.ReferenceNumber) && 
        (x.CreditAmount >= param.MinAmountCredit) && (x.CreditAmount <= param.MaxAmountCredit) &&
        (x.DebitAmount >= param.MinAmountDebit) && (x.CreditAmount <= param.MaxAmountDebit) &&
        (x.InsertDate >= param.BeginDate) && (x.InsertDate <= param.EndDate) &&
        (x.Description.Contains(param.Description)));
        return Ok(filterList);
    }


}
