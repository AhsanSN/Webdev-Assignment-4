﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace Assignment4Client.Models
{
    class CalculationManager
    {
        public static TaxComputation GetMonthlyTax(decimal totalSalary, decimal totalTaxPaid,
            int remainingMonths)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["portnum"]);//new Uri("http://localhost:57199/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                string requestQuery = string.Format(
                    "api/TaxCalculator/CalculateTax?yearlyIncome={0}&remainingPeriods={1}&taxPaid={2}",
                    totalSalary, remainingMonths, totalTaxPaid);
                HttpResponseMessage response = client.GetAsync(requestQuery).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultObject = response.Content.ReadAsAsync<TaxComputation>().Result;
                    return resultObject;
                }
            }
            return null;
        }
    }

    public class TaxComputation
    {
        public decimal TotalSalary { get; set; }
        public decimal TotalTaxLiability { get; set; }
        public decimal TaxPaid { get; set; }
        public int RemainingPeriods { get; set; }
        public decimal TaxPerMonth { get; set; }
    }
}
