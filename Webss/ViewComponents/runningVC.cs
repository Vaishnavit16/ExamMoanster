using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.ViewComponents
{
    public class runningVC:ViewComponent
    {

        IScdeule erepo;
        public runningVC(IScdeule erepo)
        {
            this.erepo = erepo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rec = await this.erepo.Running();
            return View(rec);

        }
    }
}
