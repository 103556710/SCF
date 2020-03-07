using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Senparc.ExtensionAreaTemplate.Services;
using Senparc.Scf.Core.Models.DataBaseModel;
using Senparc.Scf.Service;
using Senparc.Scf.XscfBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Senparc.ExtensionAreaTemplate.Models.DatabaseModel.Dto;
using Senparc.Scf.Core.Enums;

namespace Senparc.ExtensionAreaTemplate.Areas.MyApp.Pages
{
    public class MyHomePage : Senparc.Scf.AreaBase.Admin.AdminXscfModulePageModelBase
    {
        public ColorDto ColorDto { get; set; }

        private readonly ColorService _colorService;
        private readonly IServiceProvider _serviceProvider;
        public MyHomePage(IServiceProvider serviceProvider, ColorService colorService, Lazy<XscfModuleService> xscfModuleService)
            : base(xscfModuleService)
        {
            _colorService = colorService;
            _serviceProvider = serviceProvider;
        }

        public Task OnGetAsync()
        {
            ColorDto = new ColorDto(_colorService.GetObject(z => true, z => z.Id, OrderingType.Descending));
            return Task.CompletedTask;
        }

        public async Task OnBrightenAsync()
        {
            await _colorService.Brighten().ConfigureAwait(false);
        }

        public async Task OnDarkenAsync()
        {
            await _colorService.Darken().ConfigureAwait(false);
        }
    }
}
