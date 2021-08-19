using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Services
{
    public class WalletService : IWalletService
    {
        private Context Context { get; set; }

        public WalletService()
        {
            this.Context = new Context();
        }

        public async Task<bool> InsertData(WalletParameters wallet)
        {
            if (wallet != null)
            {
                wallet.CodBank = 1;

                Bank bank = Context.Banks.Where(x => x.CodBank == wallet.CodBank).FirstOrDefault();

                foreach (var item in wallet.Cards)
                {
                    item.CodBank = 1;
                    item.BankNavigation = bank;
                }

                foreach (var item in wallet.Payments)
                {
                    item.CodBank = 1;
                    item.BankNavigation = bank;
                }

                foreach (var item in wallet.FlowClosed)
                {
                    item.CodBank = 1;
                    item.BankNavigation = bank;
                }

                Context.Wallet.Update(new Wallet
                {
                    CodWallet = 3,
                    CardsNavigation = wallet.Cards,
                    FlowClosedNavigation = wallet.FlowClosed,
                    PaymentNavigation = wallet.Payments,
                    BankNavigation = bank
                });

                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public WalletParameters Get(long codBank, long codWallet)
        {

            try
            {
                WalletParameters parameters = new WalletParameters();
                parameters.TimeString = new List<string>();
                parameters.Cards = new List<Cards>();

                var wallet = new
                {
                    Payments = Context.Payment.Where(x => x.BankNavigation.CodBank == codBank && x.WalletNavigation.CodWallet == codWallet).ToList(),
                    Cards = Context.Card.Where(x => x.BankNavigation.CodBank == codBank && x.WalletNavigation.CodWallet == codWallet)
                        .ToList().GroupBy(x => new { x.TimeString }),
                    FlowClosed = Context.FlowClosed.Where(x => x.BankNavigation.CodBank == codBank && x.WalletNavigation.CodWallet == codWallet).ToList()
                };

                foreach (var item in wallet.Cards)
                {
                    parameters.TimeString.Add(item.Key.TimeString);

                    foreach (var card in item.ToList())
                    {
                        parameters.Cards.Add(card);
                    }
                }

                parameters.Payments = wallet.Payments;
                
                parameters.FlowClosed = wallet.FlowClosed;


                return parameters;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
