using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    /// <summary>
    /// 账户流水
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; }
        /// <summary>
        /// 发生日期
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Note { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}
