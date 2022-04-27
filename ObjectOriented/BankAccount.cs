using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOriented
{
    /// <summary>
    /// 银行卡 -【抽象、封装】
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// 卡号初始化
        /// </summary>
        private static int s_accountNumberSeed = 621356035;
        /// <summary>
        /// 最小金额
        /// </summary>
        private readonly decimal _minimumBalance;
        /// <summary>
        /// 账户流水
        /// </summary>
        private readonly List<Transaction> _transactions = new();

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; }
        /// <summary>
        /// 持卡所有者姓名
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance
        {
            get
            {
                return _transactions.Sum(e => e.Amount);
            }
        }
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            CardNumber = s_accountNumberSeed.ToString();

            s_accountNumberSeed++;

            Owner = name;

            _minimumBalance = minimumBalance;

            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "初始化账户");
            }
        }
        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="date">日期</param>
        /// <param name="note">内容</param>
        /// <exception cref="ArgumentException"></exception>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "存款金额必须为正数");
            }
            var depost = new Transaction(amount, date, note);
            _transactions.Add(depost);
        }
        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="date">日期</param>
        /// <param name="note">内容</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "取款金额必须为正数");
            }

            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

            Transaction? withdrawal = new(-amount, date, note);

            _transactions.Add(withdrawal);

            if (overdraftTransaction != null)
            {
                _transactions.Add(overdraftTransaction);
            }
        }

        /// <summary>
        /// 结算
        /// </summary>
        public virtual void PerformMonthEndTransactions() { }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("这次提款资金不足");
            }
            else
            {
                return default;
            }
        }
        /// <summary>
        /// 打印流水
        /// </summary>
        /// <returns></returns>
        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;

            report.AppendLine($"卡号:{CardNumber}\t姓名:{Owner}\t余额:{Balance}");

            report.AppendLine("发生日期\t金额\t余额\t小计");

            foreach (var item in _transactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
            }

            return report.ToString();
        }
    }
}
