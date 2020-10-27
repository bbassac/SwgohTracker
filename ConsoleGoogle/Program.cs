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
namespace ConsoleGoogle
{
    class Program

    {// If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string name = "Swgoh Database";

        static void Main(string[] args)
        {
            UserCredential credential;

            var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read);
            var credentials = GoogleCredential.FromStream(stream);

            if (credentials.IsCreateScopedRequired)
            {
                credentials = credentials.CreateScoped(new string[] { SheetsService.Scope.Spreadsheets });
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = name
            });

            // Define request parameters.
            String spreadsheetId = "1CVgeGelq874Vz-2WY-TOmYtgHhVrROSwdpY6x5aYf_Y";
            String range = "BDD!A1:E";


            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<object>> vaA1lues = response.Values;

            
            range = "BDD!A4:E4";
            Data.ValueRange valueRange = new Data.ValueRange();
            var oblist = new List<object>() { "Harry", "80", "77", "62", "98" };
            valueRange.Values = new List<IList<object>> { oblist };
            // Append the above record...
            var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }
    }
}

