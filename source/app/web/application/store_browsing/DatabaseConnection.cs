using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.store_browsing
{
    public class DatabaseConnection : IQueryADatabase
    {
        IFindTheRightDatabaseHandler database_finder;

        public DatabaseConnection(IFindTheRightDatabaseHandler database_finder)
        {
            this.database_finder = database_finder;
        }


        public IEnumerable<Report> run<Report>()
        {
            IConnectToTheDatabase<Report> database = database_finder.databaseHandler<Report>();
            return database.reports();
        }
    }
}
