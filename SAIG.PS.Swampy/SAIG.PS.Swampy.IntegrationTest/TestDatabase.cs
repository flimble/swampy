using System.Collections.Generic;
using MongoDB.Driver.Builders;
using SAIG.PS.Swampy.MongoDataAccess;
using SAIG.PS.Swampy.Service;
using SAIG.PS.Swampy.Service.Entities;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.IntegrationTest.Mongo
{
    public static class TestDatabase
    {
        public static Session Session()
        {
            return new Session("mongodb://localhost/?safe=true", "swampyintegrationtests");
        }

        public static void Down()
        {
            var session = Session();
            session.Server.DropDatabase("swampyintegrationtests");
            session.Dispose();
        }

        public static void Up()
        {
            using (var session = TestDatabase.Session())
            {

                session.GetCollection<Environment>().EnsureIndex(new IndexKeysBuilder().Ascending("Name"),
                                                                 IndexOptions.SetUnique(true));


                var sit1Environment = new Environment
                                      {
                                          Name = "SIT1",
                                          Endpoints = new List<EndpointBase>
                                                          {
                                                                new SimpleEndpoint
                                                              {
                                                                  Key="ModeKey",
                                                                  Value="SIT2"
                                                              },
                                                              new Server
                                                                  {
                                                                      Key="QVAS.ServerName",
                                                                      Value="ausydhq-pstap08.saig.frd.global"
                                                                  },
                                                              
                                                              new DatabaseConnectionString
                                                                  {
                                                                      Key = "CommonDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "SSRDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ04.SAIG.frd.global;initial catalog=SSR;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "ApexDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Apex;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "WorkflowDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=WorkflowStore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "OscarDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Oscar;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "TransDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Trans;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "Trans2DBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Trans2;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "FilestoreDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=Filestore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "QVASDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ03.SAIG.frd.global;initial catalog=QVAS;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "DMSDBConnectionString",
                                                                      Value = @"data source=ausydhc-psqsq01.saigprod.local;initial catalog=ANZ;User ID=reports;Password=hungry4data;persist security info=False;packet size=4096"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key = "CSMUrl",
                                                                      Value = @"http://ausydhq-pstap08:8040"
                                                                  },
                                                                  new WebpageUrl                                                                  
                                                                  {
                                                                      Key = "DMSUrl",
                                                                      Value = @"https://dms.SIT1.property.saiglobal.com/WorkSite/DMSLogin.aspx?1=1"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ReportingServiceUrl",
                                                                      Value="http://AUSYDHQ-PSTSQ04.SAIG.frd.global/ReportServer/ReportService.asmx"
                                                                  }, 
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="DeliveryEngine",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8001"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="LandgateDM",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8002"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon Service Monitor",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8005"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon Common File Service",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8006"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="SSRDeliveryEngine",
                                                                      Value=@"net.tcp://ausydhq-pstap07:8006"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CPM",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8004"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="QVASService",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8007"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMAgent",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8008"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="MailerService",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8009"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMService",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8040"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon.CSMSync",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8013"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="TransService",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8015"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ESM Inbound Web Service",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8042"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ESM Outgoing Message Relay",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8056"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMPublicService",
                                                                      Value=@"net.tcp://ausydhq-pstap08:8055"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="DMSMessageGateway",
                                                                      Value=@"net.tcp://10.200.23.81:5000"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Instruction Print Service",
                                                                      Value=@"net.tcp://ausydhq-pstap07:8026"
                                                                  },
                                                          }

                                      };

                session.Save(sit1Environment);

                var sit2Environment = new Environment
                {
                    Name = "SIT2",
                    Endpoints = new List<EndpointBase>
                                                          {
                                                               new SimpleEndpoint
                                                              {
                                                                  Key="ModeKey",
                                                                  Value="SIT2"
                                                              },
                                                              new Server
                                                                  {
                                                                      Key="QVAS.ServerName",
                                                                      Value="ausydhq-pstap10.saig.frd.global"
                                                                  },
                                                              new DatabaseConnectionString
                                                                  {
                                                                      Key = "CommonDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ06.SAIG.frd.global;initial catalog=Common;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "SSRDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ06.SAIG.frd.global;initial catalog=SSR;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "ApexDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=Apex;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "WorkflowDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=WorkflowStore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "OscarDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=Oscar;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "TransDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=Trans;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "Trans2DBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=Trans2;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "FilestoreDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=Filestore;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },
                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "QVASDBConnectionString",
                                                                      Value = @"data source=AUSYDHQ-PSTSQ05.SAIG.frd.global;initial catalog=QVAS;User ID=eonapp;Password=330n@pp10ck;persist security info=False;packet size=4096"
                                                                  },

                                                                  new DatabaseConnectionString
                                                                  {
                                                                      Key = "DMSDBConnectionString",
                                                                      Value = @"data source=ausydhc-psqsq01.saigprod.local;initial catalog=ANZ;User ID=reports;Password=hungry4data;persist security info=False;packet size=4096"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key = "CSMUrl",
                                                                      Value = @"http://ausydhq-pstap10:8040"
                                                                  },
                                                                  new WebpageUrl                                                                  
                                                                  {
                                                                      Key = "DMSUrl",
                                                                      Value = @"https://dms.SIT2.property.saiglobal.com/WorkSite/DMSLogin.aspx?1=1"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ReportingServiceUrl",
                                                                      Value="http://AUSYDHQ-PSTSQ06.SAIG.frd.global/ReportServer/ReportService.asmx"
                                                                  }, 
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="DeliveryEngine",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8001"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="LandgateDM",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8002"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon Service Monitor",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8005"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon Common File Service",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8006"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="SSRDeliveryEngine",
                                                                      Value=@"net.tcp://ausydhq-pstap09:8006"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CPM",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8004"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="QVASService",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8007"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMAgent",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8008"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="MailerService",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8009"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMService",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8040"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Espreon.CSMSync",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8013"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="TransService",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8015"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ESM Inbound Web Service",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8042"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="ESM Outgoing Message Relay",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8056"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="CSMPublicService",
                                                                      Value=@"net.tcp://ausydhq-pstap10:8055"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="DMSMessageGateway",
                                                                      Value=@"net.tcp://10.200.23.81:5000"
                                                                  },
                                                                  new ServiceUrl
                                                                  {
                                                                      Key="Instruction Print Service",
                                                                      Value=@"net.tcp://ausydhq-pstap09:8026"
                                                                  },
                                                          }

                };

                session.Save(sit2Environment);
            }
        }
    }
}
