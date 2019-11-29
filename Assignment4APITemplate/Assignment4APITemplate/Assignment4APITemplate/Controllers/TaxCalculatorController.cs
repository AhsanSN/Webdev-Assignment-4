﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment4APITemplate.Models;

namespace Assignment4APITemplate.Controllers
{
    public class TaxCalculatorController : ApiController
    {
        [HttpGet]
        public TaxComputation CalculateTax(decimal yearlyIncome = 75000000,
                    int remainingPeriods = 4, decimal taxPaid = 4000M)
        {
            double totalTax = 0;
            if (yearlyIncome < 600000)
            {
                totalTax = 0;
            }
            else if ((yearlyIncome >= 600000) && (yearlyIncome < 1200000)) {
                totalTax = (0.05 * ((double)yearlyIncome - 600000));
            }
            else if ((yearlyIncome >= 1200000) && (yearlyIncome < 1800000)) 
            {
                totalTax = 30000 + (0.10 * ((double)yearlyIncome - 1200000));
            }
            else if ((yearlyIncome >= 1800000) && (yearlyIncome < 2500000)) 
            {
                totalTax = 90000 + (0.15 * ((double)yearlyIncome - 1800000));
            }
            else if ((yearlyIncome >= 2500000) && (yearlyIncome < 3500000)) 
            {
                totalTax = 195000 + (0.175 * ((double)yearlyIncome - 2500000));
            }
            else if ((yearlyIncome >= 3500000) && (yearlyIncome < 5000000))
            {
                totalTax = 370000 + (0.20 * ((double)yearlyIncome - 3500000));
            }
            else if ((yearlyIncome >= 5000000) && (yearlyIncome < 8000000)) 
            {
                totalTax = 670000 + (0.225 * ((double)yearlyIncome - 5000000));
            }
            else if ((yearlyIncome >= 8000000) && (yearlyIncome < 12000000))
            {
                totalTax = 1345000 + (0.25 * ((double)yearlyIncome - 8000000));
            }
            else if ((yearlyIncome >= 12000000) && (yearlyIncome < 30000000))
            {
                totalTax = 2345000 + (0.275 * ((double)yearlyIncome - 12000000));
            }
            else if ((yearlyIncome >= 30000000) && (yearlyIncome < 50000000))
            {
                totalTax = 7295000 + (0.3 * ((double)yearlyIncome - 30000000));
            }
            else if ((yearlyIncome >= 50000000) && (yearlyIncome < 75000000))
            {
                totalTax = 13295000 + (0.325 * ((double)yearlyIncome - 50000000));
            }
            else if ((yearlyIncome >= 75000000))
            {
                totalTax = 21420000 + (0.35 * ((double)yearlyIncome - 75000000));
            }
            decimal taxPerMonth = (decimal)(totalTax / 12);
            // TODO: Write your code here
            return new TaxComputation
            {
                TotalSalary = yearlyIncome,
                RemainingPeriods = remainingPeriods,
                TaxPaid = taxPaid,
                TotalTaxLiability = ((decimal)totalTax- taxPaid),
                TaxPerMonth = (decimal)(totalTax / 12)
            };
        }
    }
}
