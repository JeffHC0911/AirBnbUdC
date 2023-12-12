using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Repository.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeRepository
    {
        MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDbModel record);
        MultimediaTypeDbModel GetRecord(int recordId);
        IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter);
    }
}
