using BusinessAccessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class ReportService : IReportService
    {
        IUnitOfWork DataBase { get; set; }

        public ReportService(IUnitOfWork db)
        {
            DataBase = db;
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public ExcelFile GetFile()
        {
            IEnumerable<ProgrammerProfile> profiles = DataBase.ProgrammerManager.GetAll();
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("DataTable to Sheet");

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Skills", typeof(string));

            foreach(var profile in profiles)
            {
                List<string> rates = new List<string>();
                foreach (var rate in profile.SkillRates)
                    rates.Add(rate.Skill.Name);
                dt.Rows.Add(new object[] 
                {
                    profile.Id,
                    profile.FirstName,
                    profile.LastName,
                    rates.Aggregate((x, y) => x + "," + y)
                });
            }

            ws.InsertDataTable(dt,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 2
            });

            return ef;
        }
    }
}
