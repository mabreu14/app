using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.store_browsing
{
    public interface IQueryADatabase
    {
        IEnumerable<Report> run<Report>();
    }

    public interface IConnectToTheDatabase<Report>
    {
        IEnumerable<Report> reports();

    }

    public interface IFindTheRightDatabaseHandler
    {
        IConnectToTheDatabase<Report> databaseHandler<Report>();
    }
}
