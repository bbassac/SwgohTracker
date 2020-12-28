using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ipd;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestArena.Models;


namespace RestArena.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("export")]
    public class ExportController : ControllerBase
    {
        private readonly IGoogleExporter googleExporter;
        public ExportController(IGoogleExporter googleExporter)
        {
            this.googleExporter = googleExporter;
        }

        
        [HttpGet]
        public async void GetAsync()
        {
            var result = await SwgohRosterConverter.GetSwgohDataAsync();
            googleExporter.Export(result);
           
        }
    }



}
