namespace MyMVCApp.ViewModels.Customer
{
    public class CustomerDiscountViewModel
    {
        public int CustomerId { get; set; }
        public string ? CustomerName { get; set; }
        public DateTime ? CustomerBirthdate { get; set; }
        public string ? MembershipType { get; set; }
        public double DiscountRate { get; set; }
    }
}