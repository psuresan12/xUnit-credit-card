using System;
namespace TestCards.Models
{
    public class CreditCardApplicationEvaluator
    {
        private const int AutoReferralMaxAge = 20;
        private const int HighIncomeThreshhold = 100_000;
        private const int LowIncomeThreshhold = 20_000;


        public CreditCardApplicationDecision.CreditCardApplicationDecisionType Evaluate(CreditCardApplication application)
        {
            if (application.GrossAnnualIncome >= HighIncomeThreshhold)
            {
                return CreditCardApplicationDecision.CreditCardApplicationDecisionType.AutoAccepted;
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
