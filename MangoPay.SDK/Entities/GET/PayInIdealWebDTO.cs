namespace MangoPay.SDK.Entities.GET
{
    public class PayInIdealWebDTO : PayInDTO
    {
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }

        /// <summary> The URL to which the user is redirected to complete the payment
        public string RedirectURL { get; set; }
        
        /// <summary> Name of the end-user’s bank </summary>
        public string BankName { get; set; }
    }
}