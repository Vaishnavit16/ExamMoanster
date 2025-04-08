using Domain;
using Infras.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class MockTestSubREepo : GenRepo<MockTestSubject>, ImockTestSubject
    {
        Context cc;
        public MockTestSubREepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }
    }
}
