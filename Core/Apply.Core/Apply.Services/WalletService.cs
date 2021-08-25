using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Apply.Services
{
    public class WalletService : IWalletService
    {
        SecurityService SecuritySVC = new SecurityService();

        private Context context { get; set; }

        public WalletService()
        {
            this.context = new Context();
        }

        public async Task<bool> InsertData(WalletParameters wallet)
        {
            if (wallet != null)
            {
                wallet.CodBank = 1;

                Bank bank = context.Banks.Where(x => x.CodBank == 1).FirstOrDefault();

                var Wallet = context.Usuario.Include(x => x.WalletNavigation)
                    .Where(x => x.CodUsuario == wallet.CodUsuario)
                    .FirstOrDefault()
                    .WalletNavigation;

                var codWallet = Wallet.CodWallet;

                foreach (var item in wallet.Cards)
                {
                    item.CodWallet = codWallet;                    
                    item.BankNavigation = bank;
                }

                foreach (var item in wallet.Payments)
                {
                    item.CodWallet = codWallet;                    
                    item.BankNavigation = bank;
                }

                foreach (var item in wallet.FlowClosed)
                {
                    item.CodWallet = codWallet;                    
                    item.BankNavigation = bank;                    
                }
        
                context.Card.AddRange(wallet.Cards);
                context.FlowClosed.AddRange(wallet.FlowClosed);
                context.Payment.AddRange(wallet.Payments);                

                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public WalletParameters GetById(long codUsuario)
        {

            try
            {
                WalletParameters parameters = new WalletParameters();
                parameters.TimeString = new List<string>();
                parameters.Cards = new List<Cards>();

                var Wallet = context.Usuario.Include(x => x.WalletNavigation).ThenInclude(x => x.BankNavigation)
                   .Where(x => x.CodUsuario == codUsuario)
                   .FirstOrDefault()
                   .WalletNavigation;

                var wallet = new
                {
                    Payments = context.Payment.Where(x =>x.CodWallet == Wallet.CodWallet).ToList(),
                    Cards = context.Card.Where(x => x.CodWallet == Wallet.CodWallet)
                        .ToList().GroupBy(x => new { x.TimeString }),
                    FlowClosed = context.FlowClosed.Where(x => x.CodWallet == Wallet.CodWallet).ToList()
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
