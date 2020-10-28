using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using RestArena.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Data = Google.Apis.Sheets.v4.Data;

namespace RestArena
{
    public interface IGoogleExporter 
    {
        void Export(List<Unit> list);
    }

    public class GoogleExporter : IGoogleExporter
    {
        static string name = "Swgoh Database";
        String mesPersosRange = @"Mes persos!A2:V";
        String mesVaisseauxRange = @"Mes vaisseaux!A2:V";
        String spreadsheetId = "1CVgeGelq874Vz-2WY-TOmYtgHhVrROSwdpY6x5aYf_Y";
        public void Export(List<Unit> list)
        {
            SheetsService service = Login();
            ExportChars(service, mesPersosRange,list);
            ExportShips(service, mesVaisseauxRange, list);

        }
        private void ExportShips(SheetsService service, String range, List<Unit> list)
        {
            CleanRange(service, range);
            IList<IList<object>> toReturn = new List<IList<object>>();
            foreach (Unit unit in list)
            {
                if (unit.Type.Equals(Unit.UnitType.SHIP.ToString()))
                {
                    List<object> row = new List<object>()
                    {
                      
                        "StormBringer",
                        unit.Name,
                        unit.Stars,
                        unit.Level,
                        unit.Gp,
                      

                    };
                    toReturn.Add(row);
                }
            }

            WriteToSheet(service, range, toReturn);
        }
        private void ExportChars(SheetsService service,String range,List<Unit> list)
        {
            CleanRange(service, range);
            IList<IList<object>> toReturn = new List<IList<object>>();
            foreach (Unit unit in list)
            {
                if (unit.Type.Equals(Unit.UnitType.CHAR.ToString()))
                {
                    List<object> row = new List<object>()
                    {
                        unit.Url,
                        "StormBringer",
                        unit.Name,
                        unit.Stars,
                        unit.Gear,
                        unit.Level,
                        unit.Gp,
                        unit.Zetas,
                        unit.Health,
                        unit.Speed,
                        unit.PhysicalDamage,
                        unit.CriticalChance,
                        unit.CriticalDamage,
                        unit.Potency,
                        unit.Tenacity,
                        unit.HealSteal,
                        unit.Protection,
                        unit.Relic

                    };
                    toReturn.Add(row);
                }
            }

            WriteToSheet(service, range, toReturn);
        }

        private void CleanRange(SheetsService service, string range)
        {
            Data.ClearValuesRequest requestBody = new Data.ClearValuesRequest();

            SpreadsheetsResource.ValuesResource.ClearRequest request = service.Spreadsheets.Values.Clear(requestBody, spreadsheetId, range);

            // To execute asynchronously in an async method, replace `request.Execute()` as shown:
            Data.ClearValuesResponse response = request.Execute();
        }

        private void WriteToSheet(SheetsService service, string range, IList<IList<object>> toReturn)
        {
            Data.ValueRange valueRange = new Data.ValueRange();
            valueRange.Values = toReturn;
            // Append the above record...
            var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        private SheetsService Login()
        {
         
            var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read);
            var credentials = GoogleCredential.FromStream(stream);

            if (credentials.IsCreateScopedRequired)
            {
                credentials = credentials.CreateScoped(new string[] { SheetsService.Scope.Spreadsheets });
            }

            SheetsService service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = name
            });
            return service;
        }
    }
}
