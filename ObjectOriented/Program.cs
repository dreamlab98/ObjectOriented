using ObjectOriented;

var savings = new InterestEarningAccount("储蓄卡", 10000);
savings.MakeDeposit(750, DateTime.Now, "节省一笔钱");
savings.MakeDeposit(1250, DateTime.Now, "工资存款");
savings.MakeWithdrawal(250, DateTime.Now, "账单开销");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

var giftCard = new GiftCardAccount("礼品卡", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "买一杯咖啡");
giftCard.MakeWithdrawal(50, DateTime.Now, "吃一顿午饭");
giftCard.PerformMonthEndTransactions();
giftCard.MakeDeposit(27.50m, DateTime.Now, "存入一些零花钱");
Console.WriteLine(giftCard.GetAccountHistory());


var lineOfCredit = new LineOfCreditAccount("信用卡", 0, 20000);
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "每月房租");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "小额还款");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "车祸 医疗费用");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "小额还款");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());


Console.ReadKey();