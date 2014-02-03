using System;
using Isima.ContactManager.Data;

namespace Isima.ContactManager.Serialization
{
    public interface IDatabaseSerializer
    {
        Database Load(string fileName);

        void Save(string fileName, Database data);
    }
}
