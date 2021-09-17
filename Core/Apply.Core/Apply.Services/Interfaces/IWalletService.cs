using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apply.Services
{
    public interface IWalletService
    {
        Task<bool> InsertData(WalletParameters wallet);
        public Wallet GetWalletByUsuCod(long usuCod);
        public WalletParameters GetByUsuCod(long codUsuario, string dataJoined = "");
    }
}
