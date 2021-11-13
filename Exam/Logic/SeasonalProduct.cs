using System;

namespace Exam.Logic
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; }
        public DateTime SeasonEndDate { get; }

        public override bool Active
        {
            // TODO check if there is an each case error
            get => !(DateTime.Now.Date < SeasonStartDate.Date ||
                     DateTime.Now.Date > SeasonEndDate.Date);
        }

        public SeasonalProduct( string name
                              , int price
                              , bool canBeBoughtOnCredit
                              , DateTime seasonStartDate
                              , DateTime seasonEndDate
                              ) : base(name, price, canBeBoughtOnCredit)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
    }
}
