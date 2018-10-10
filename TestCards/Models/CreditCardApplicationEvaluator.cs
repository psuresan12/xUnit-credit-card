using System;
using TestCards.Services;

namespace TestCards.Models
{
    public class CreditCardApplicationEvaluator
    {
        private readonly IFrequentFlyerNumberValidator _validator;
        private const int AutoReferralMaxAge = 20;
        private const int HighIncomeThreshhold = 100_000;
        private const int LowIncomeThreshhold = 20_000;

        public CreditCardApplicationEvaluator(IFrequentFlyerNumberValidator validator)
        {
            _validator = validator;
        }


        public CreditCardApplicationDecision.CreditCardApplicationDecisionType Evaluate(CreditCardApplication application)
        {
            if (application.GrossAnnualIncome >= HighIncomeThreshhold)
            {
                return CreditCardApplicationDecision.CreditCardApplicationDecisionType.AutoAccepted;
            }

            if(!_validator.IsValid(application.FrequentFlyerNumber))
            {
                return CreditCardApplicationDecision.CreditCardApplicationDecisionType.ReferredToHuman;
            }

            if (application.Age <= AutoReferralMaxAge)
            {
                return CreditCardApplicationDecision.CreditCardApplicationDecisionType.ReferredToHuman;
            }

            if (application.GrossAnnualIncome < LowIncomeThreshhold)
            {
                return CreditCardApplicationDecision.CreditCardApplicationDecisionType.AutoDeclined;
            }

            return CreditCardApplicationDecision.CreditCardApplicationDecisionType.ReferredToHuman;
        }
    }
}
