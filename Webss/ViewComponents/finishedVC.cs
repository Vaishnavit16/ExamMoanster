using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.ViewComponents
{
    public class finishedVC:ViewComponent
    {
        IScdeule erepo;
        public finishedVC(IScdeule erepo)
        {
            this.erepo = erepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rec = await this.erepo.Finished();
            return View(rec);

        }
    }
}