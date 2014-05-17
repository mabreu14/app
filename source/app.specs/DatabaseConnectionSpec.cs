using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using app.web.application.store_browsing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks;

namespace app.specs
{
    class DatabaseConnectionSpec
    {
        class concern : Observes<IQueryADatabase, DatabaseConnection>
        {
            
        }

        class when_querying_the_database_for_the_product : concern
        {

            private Establish c = () =>
            {

                product_database = fake.an<IConnectToTheDatabase<OneReport>>();

                database_handler = depends.on<IFindTheRightDatabaseHandler>();

                database_handler.setup(x => x.databaseHandler<OneReport>()).Return(product_database);
                product_database.setup(x => x.reports());
            };

            private Because b = () => sut.run<OneReport>();



            private It Should_send_the_query_to_the_right_handler = () => product_database.received(x => x.reports());

            static IConnectToTheDatabase<OneReport> product_database;
            static IFindTheRightDatabaseHandler database_handler;

        }
        
        public class OneReport
        {
        }

    }

}
