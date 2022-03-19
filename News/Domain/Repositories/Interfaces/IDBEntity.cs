using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Domain.Repositories.Interfaces
{
    public interface IDBEntity<T>
    {
        public T GetFieldById(Guid fieldId);

        public void SaveField(T field);

        public void DeleteField(Guid fieldId);
    }
}
