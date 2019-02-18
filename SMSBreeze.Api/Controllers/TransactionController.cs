using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Api.Data;
using SMSBreeze.Api.Models;

namespace SMSBreeze.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly ApplicationDbContext _dbContext;

		public TransactionController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;

		}
		// GET: api/Transaction
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Transaction/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Transaction
		[HttpPost]
		public void Post([FromBody] SmsTransaction transactionDetails)
		{
			
		}

		// PUT: api/Transaction/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
