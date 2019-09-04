using ContactsManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.Interfaces
{
    public interface IContactCompanyRelationshipRepository
    {
        Task Create(ContactCompanyRelationship contactCompanyRelationship);
        IEnumerable<ContactCompanyRelationship> List();
        IEnumerable<ContactCompanyRelationship> List(Expression<Func<ContactCompanyRelationship, bool>> predicate);
        void Delete(ContactCompanyRelationship contactCompanyRelationship);
        Task<bool> Save();
    }
}
