using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.Enums;

namespace WishlistSavingPlanner.Models
{
    public class CashflowModel
    {
        private double amount;
        private string name;
        private DateTime dateOccure;
        private CashflowRate repeatRate;
        public CashflowModel(double amount, string name, CashflowRate repeatRate, DateTime dateOccure)
        {
            this.amount = amount;
            this.name = name;
            this.dateOccure = dateOccure;
            this.repeatRate = repeatRate;
        }

        public CashflowRate RepeatRate { get => repeatRate; set => repeatRate = value; }
        public DateTime DateOccure { get => dateOccure; set => dateOccure = value; }
        public string Name { get => name; set => name = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
