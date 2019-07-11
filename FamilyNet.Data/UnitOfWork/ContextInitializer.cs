using FamilyNet.Data.Interfaces;
using System.Data.Entity;

namespace FamilyNet.Data.UnitOfWork
{
    internal class ContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
    }
}