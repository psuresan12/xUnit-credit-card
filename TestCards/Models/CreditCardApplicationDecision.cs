using System;
namespace TestCards.Models
{
    public class CreditCardApplicationDecision
    {
        public enum CreditCardApplicationDecisionType
        {
            Unknown,
            AutoAccepted,
            AutoDeclined,
            ReferredToHuman
        }
    }
}
