using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dash.Data;
using Dash.DemoApp.UserControls;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace Dash.DemoApp
{
    public static class ManageOrders
    {
        public static List<PrioListElement> GetPrioList(IConfigurationRoot Configuration)
        {
            int tableStartIndex = 4;
            int tableEndIndex = 50;

            List<PrioListElement> list = new();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] bin;

            //bin = File.ReadAllBytes(Configuration["ConnectionStrings:DefaultExcelFileConnection"] + Configuration["Files:DefaultExcelFile"]);
            bin = File.ReadAllBytes(Configuration["ConnectionStrings:DefaultExcelFileConnectionHome"] + Configuration["Files:DefaultExcelFile"]);

            MemoryStream stream = new(bin);
            ExcelPackage excelPackage = new(stream);

            var worksheet = excelPackage.Workbook.Worksheets[0];

            for (int i = tableStartIndex; i <= tableEndIndex && worksheet.Cells[i, 1].Value is not null; i++)
            {
                PrioListElement p = new();

                p.Project = worksheet.Cells[i, 1].Value.ToString();
                p.OrderNr = worksheet.Cells[i, 2].Value.ToString();
                p.DeliveryDate = Convert.ToDateTime(worksheet.Cells[i, 3].Value);
                p.CWPlanned = Convert.ToInt16(worksheet.Cells[i, 5].Value);
                p.Progress = Convert.ToDecimal(worksheet.Cells[i, 6].Value);
                p.Position = Convert.ToInt16(worksheet.Cells[i, 7].Value);
                p.Quantity = Convert.ToInt16(worksheet.Cells[i, 8].Value);
                p.TimeTotal = Convert.ToInt16(worksheet.Cells[i, 9].Value);
                p.TimeOutstanding = Convert.ToInt16(worksheet.Cells[i, 10].Value);
                p.TimeDone = Convert.ToInt16(worksheet.Cells[i, 11].Value);

                list.Add(p);
            }

            return list;
        }

        public static List<OrderControl> GetOrders(List<PrioListElement> prioList)
        {
            List<OrderControl> orders = new();

            foreach (var prioElement in prioList)
            {
                OrderControl order = new(prioElement);

                orders.Add(order);
            }

            return orders;
        }

        
    }
}
