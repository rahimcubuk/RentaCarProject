using Core.DataAccess.Repositories;
using DataAccess.Abstract.Dals;
using DataAccess.Concrete.Contexts;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EFDals
{
    public class EfUserCardDal : EntityRepository<UserCard, EfProjectContext>, IUserCardDal
    {
        public UserCardDetailsDto GetUserCardById(Expression<Func<UserCardDetailsDto, bool>> filter)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                IQueryable<UserCardDetailsDto> data = createData(context);

                return data.FirstOrDefault(filter);
            }
        }

        public List<UserCardDetailsDto> GetUserCardsByUserId(Expression<Func<UserCardDetailsDto, bool>> filter)
        {
            using (EfProjectContext context = new EfProjectContext())
            {
                IQueryable<UserCardDetailsDto> data = createData(context);
                return data.Where(filter).ToList();
            }
        }

        private static IQueryable<UserCardDetailsDto> createData(EfProjectContext context)
        {
            return from uc in context.UserCards
                   join cc in context.FakeCreditCards on uc.CardId equals cc.Id
                   join us in context.Users on uc.UserId equals us.UserId
                   select new UserCardDetailsDto
                   {
                       Id = uc.Id,
                       UserId = us.UserId,
                       CardId = cc.Id,
                       UserName = (us.FirstName + " " + us.LastName).ToLower(),
                       NameOnTheCard = (cc.NameOnTheCard).ToLower(),
                       CardNumber = cc.CardNumber,
                       CardCvv = cc.CardCvv,
                       ExpirationMonth = cc.ExpirationMonth,
                       ExpirationYear = cc.ExpirationYear
                   };
        }
    }
}
