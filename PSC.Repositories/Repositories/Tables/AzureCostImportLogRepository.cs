using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Persistence.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence.Repositories.Tables
{
    public class AzureCostImportLogRepository : BaseRepository<AzureCostImportLog>, IAzureCostImportLogRepository
    {
        public AzureCostImportLogRepository(PSCContext db, ILogger<AzureCostImportLogRepository> log) : base(db, log) { }
    }
}