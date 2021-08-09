using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apply.Services
{
    class WalletService : IWalletService
    {
        Context Context { get; set; }
        
        public bool InsertWallet(Wallet wallet)
        {
            if (wallet != null)
            {
                Context.Wallet.Add(wallet);

                Context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool InsertData(Wallet wallet)
        {
            if (wallet != null)
            {
                Context.Wallet.Add(wallet);

                Context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
