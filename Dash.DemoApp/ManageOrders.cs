﻿using Dash.Data;
using Dash.Shared;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static List<OrderContainer> GetOrders(List<PrioListElement> prioList)
        {
            List<OrderContainer> orders = new();

            foreach (var prioElement in prioList)
            {
                OrderContainer order = new(prioElement);

                orders.Add(order);
            }

            return orders;
        }

        public static List<OrderContainer> CheckOrdersAgainstPrioritization(List<OrderContainer> orders, List<Order> prioritizedOrders)
        {
            foreach (var order in orders)
            {
                if (prioritizedOrders.Exists(o => o.Key.Equals(order.ListElement.KeyToString())))
                {
                    var currentCw = prioritizedOrders.First(o => o.Key.Equals(order.ListElement.KeyToString())).CurrentCW;

                    order.CurrentCW = currentCw;
                }
            }

            return orders;
        }

    }
}
