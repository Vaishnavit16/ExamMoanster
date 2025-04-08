using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infras.Repository.Interface;

namespace Infras.Repository.Classes
{
    public class MocktestRepo : GenRepo<MockTest>, Imocktest
    {
        Context cc;
        public MocktestRepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }
    
    }
}
