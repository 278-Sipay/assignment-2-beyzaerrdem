using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Data.Models;
using SipayApi.Data.Repository;

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

    [HttpGet]
    public IActionResult GetByParameter([FromQuery] TransactionParameters param)
    {
        var filterList = repository.GetByParameter(x => (x.AccountNumber == param.AccountNumber) && (x.ReferenceNumber == param.ReferenceNumber) && 
        (x.CreditAmount >= param.MinAmountCredit) && (x.CreditAmount <= param.MaxAmountCredit) &&
        (x.DebitAmount >= param.MinAmountDebit) && (x.DebitAmount <= param.MaxAmountDebit) &&
        (x.InsertDate >= param.BeginDate) && (x.InsertDate <= param.EndDate) &&
        (x.Description.Contains(param.Description)));
        return Ok(filterList);
    }
}
