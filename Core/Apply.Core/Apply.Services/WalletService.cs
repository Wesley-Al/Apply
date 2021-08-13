using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
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
                Context.Wallet.Add(new Wallet
                {
                    CardsNavigation = wallet.Cards,
                    FlowClosedNavigation = wallet.FlowClosed,
                    PaymentNavigation = wallet.Payments
                });

                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
