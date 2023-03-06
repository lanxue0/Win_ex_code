using System.Collections.Generic;
using System;

namespace ConsoleApplication3delegate
{
    // 储蓄卡
    class DepositCard
    {
        public int amount;
// 6
        // 输出余额
        public void Display()
        {
            Console.WriteLine("储蓄卡余额为：{0}", amount);
        }
        // 取款
        public void Account(int balance, int payday)
        {
            amount += balance;
            Console.WriteLine("今天是本月的 {0}，取款 {1}，储蓄卡余额为：{2}。", payday, -balance, amount);
        }
    }

    // 信用卡
    class CreditCard
    {
        // 余额
        private int billamount;
        // 还款日
        private int repaymentday;
        // 构造函数，初始化余额和还款日
        public CreditCard(int billamount, int repaymentday)
        {
            this.billamount = billamount;
            this.repaymentday = repaymentday;
        }

        // 得到余额
        public int getbillamount() { return billamount; }
        // 得到还款日
        public int getrepaymentday() { return repaymentday; }
        // 输出余额
        public void Display() { Console.WriteLine("信用卡余额为：%d", billamount); }
        // 还款更改余额和还款日
        public void Display(int a, int b) 
        {
            billamount -= a;
            Console.WriteLine("信用卡余额为: {0}, 还款日: {1}", billamount, repaymentday);
            repaymentday -= b;
        }

    }
    // 信用卡委托
    class CreditCardDelegate
    {
        // 余额和还款日
        public int billamount;
        public int repaymentday;
        // 请在此处添加自己的代码
        public delegate void CCDelegate(int a, int b);
        public event CCDelegate PayEvent;

        public void Do()
        {
            if(PayEvent != null)
            {
                PayEvent(billamount, repaymentday);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DepositCard depositCard = new DepositCard();
            depositCard.amount = 10000;
            CreditCard creditCard1 = new CreditCard(-2000, 9);
            CreditCard creditCard2 = new CreditCard(-3000, 13);
            CreditCard creditCard3 = new CreditCard(-5000, 29);
            depositCard.Display(); Console.WriteLine("");
            List<CreditCard> Cards = new List<CreditCard>();
            Cards.Add(creditCard1); Cards.Add(creditCard2); Cards.Add(creditCard3);

            int tday = DateTime.Today.Day;

            foreach (CreditCard card in Cards)
            {
                Console.WriteLine("信用卡开始执行委托还款。。。。。。");
                // 请在此处添加自己的代码
                CreditCardDelegate CCD = new CreditCardDelegate();
                CCD.billamount = card.getbillamount(); CCD.repaymentday = card.getrepaymentday();
                
                while (card.getrepaymentday() > tday)
                {
                    ++tday;
                    Console.WriteLine("今天是{0}号，无需还款", tday);
                }

                // 还款
                if (depositCard.amount >= card.getbillamount())
                {
                    CCD.PayEvent += card.Display;
                    CCD.PayEvent += depositCard.Account;
                    CCD.Do();
                } else
                {
                    Console.WriteLine("余额不足，无法还款\n");
                }

                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
