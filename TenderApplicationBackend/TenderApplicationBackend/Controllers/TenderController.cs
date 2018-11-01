﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Modules;

namespace TenderApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly TenderModule _tenderModule;

        public TenderController(TenderModule tenderModule)
        {
            _tenderModule = tenderModule;
        }

        // GET api/tender
        [HttpGet]
        public List<TenderRequest> Get()
        {
            return _tenderModule.SelectAllTenders();
        }

        // POST tender posting new tenders
        [HttpPost]
        public void Post([FromBody] TenderRequest tenderValue)
        {
            _tenderModule.AddTender(tenderValue);
        }
    }
}