using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace NguGame.DataAccess
{
    public class DataConnect
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "TimeSheetUpdation By Cybria Technology";
        //static void main(string[] args)
        //{
        //    var service = authorizegoogleapp();
        //    string newrange = getrange(service);
        //    ilist<ilist<object>> objnerecords = generatedata();
        //    updatgooglesheetinbatch(objnerecords, sheetid, newrange, service);
        //    console.writeline("inserted");
        //    console.read();
        //}
        private string SheetId { get; set; }
        private string Range { get; set; }
        private SheetsService Service { get; set; }


        public DataConnect()
        {
            this.SheetId = "1VCh1IgWRdIbsfT8AD9-v1SMBNbLwwUNB23kKBLMWpVg";
            this.Range = "Sheet1!A2:F";
            this.Service = AuthorizeGoogleApp();
        }

        private static SheetsService AuthorizeGoogleApp()
        {

            UserCredential credential;
            string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "credentials.json");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string settingsPath = Path.Combine(path, "settings.xml");
            StreamWriter stream2 = File.CreateText(settingsPath);
            using (var stream =
                new FileStream("redentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }
        public string GetRange(SheetsService service)
        {
            // Define request parameters.
            String spreadsheetId = this.SheetId;
            String range = "Sheet1";
            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;
            int currentCount = getValues.Count() + 1;
            String newRange = "Sheet1!A" + currentCount + ":F";
            return newRange;
        }

        private void UpdatGoogleSheetinBatch(IList<IList<Object>> values)
        {
            this.Range = GetRange(Service);
            SpreadsheetsResource.ValuesResource.AppendRequest request =
               this.Service.Spreadsheets.Values.Append(new ValueRange() { Values = values }, this.SheetId, this.Range);
            request.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }

        public IList<IList<Object>> ListGoogleSheetValue()
        {
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    this.Service.Spreadsheets.Values.Get(this.SheetId, this.Range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            return values;

        }
    }
}
