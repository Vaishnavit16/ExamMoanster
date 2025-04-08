using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.ViewComponents
{
    public class OfferDiscountVC:ViewComponent
    {     IOfferDiscount repo;

        public OfferDiscountVC(IOfferDiscount repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var res = await this.repo.GetAll();
            return View(res);
        }
    }
}
