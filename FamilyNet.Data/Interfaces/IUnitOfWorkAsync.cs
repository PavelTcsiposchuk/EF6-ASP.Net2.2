using FamilyNet.Data.Entity;
using FamilyNet.Models.Interfaces;
using System.Threading.Tasks;

namespace FamilyNet.Data.Interfaces
{
    public interface IUnitOfWorkAsync
    {
        IAsyncRepository<Orphanage> Orphanages { get; }
        IAsyncRepository<CharityMaker> CharityMakers { get; }
        IAsyncRepository<Representative> Representatives { get; }
        IAsyncRepository<Volunteer> Volunteers { get; }
        IAsyncRepository<Donation> Donations { get; }
        IAsyncRepository<Orphan> Orphans { get; }

        void SaveChangesAsync();
    }
}