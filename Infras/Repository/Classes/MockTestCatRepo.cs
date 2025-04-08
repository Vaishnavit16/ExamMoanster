using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infras.Repository.Interface;

namespace Infras.Repository.Classes
{
    public class MockTestCatRepo:GenRepo<MockTestCategory>,IMockTestCategory
    {
        Context cc;
        public MockTestCatRepo(Context cc):base(cc)
        {
            this.cc = cc;
        }
    }
}
