using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Apply.Library;
using Microsoft.EntityFrameworkCore;

namespace Apply.Services
{
    public class CardsService : ICardsService
    {
        private readonly Context Context;

        public CardsService(Context context)
        {
            DbContextOptions<Context> dbContextOptions = new DbContextOptions<Context>();

            Context = new Context(dbContextOptions);
        }

        public bool DeleteAll(long codWallet)
        {
            try
            {
                Context.Card.RemoveRange(Context.Card                    
                    .Where(x => x.CodWallet == codWallet)
                    .ToArray());                

                return Context.SaveChanges() > 0;
            }catch(Exception error)
            {
                throw;
            }
        }
    }
}
