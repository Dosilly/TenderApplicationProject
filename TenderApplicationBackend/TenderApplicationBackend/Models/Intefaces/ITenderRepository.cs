using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public interface ITenderRepository
    {
        void AddTender(Tender tender);
        void DeleteTender(int id);
        void EditTender(Tender tender);
        List<Tender> SelectAllTenders();
    }
}