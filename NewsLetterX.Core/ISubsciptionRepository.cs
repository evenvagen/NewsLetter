using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Core;

namespace DomainServices.Core
{
    public interface ISubsciptionRepository
    {
        Task<bool> Create(Subscription subscription);
        Task<Subscription> ReadByEmail(string email);
        Task<bool> Update(Subscription subscription);
        Task<Subscription> Read(string name);

    }
}
