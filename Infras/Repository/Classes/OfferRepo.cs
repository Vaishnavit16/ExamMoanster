using Domain;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class OfferRepo:GenRepo<OfferDiscount>,IOfferDiscount
    {
        Context cc;
        public OfferRepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }

        
    }
}
