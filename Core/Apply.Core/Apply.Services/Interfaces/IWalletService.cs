using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apply.Services
{
    interface IWalletService
    {
        bool InsertWallet(Wallet wallet);
        bool InsertData(Wallet wallet);
    }
}
