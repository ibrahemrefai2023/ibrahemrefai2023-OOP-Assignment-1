namespace Part3_BuilderPattern;

class Program
{
    static void Main(string[] args)
    {
        var billingAddress = new AddressBuilder()
            .WithStreet("Main Street")
            .WithCity("Giza")
            .WithState("Giza")
            .WithZipCode("12345")
            .WithCountry("Egypt")
            .Build();


        var shippingAddress = new AddressBuilder()
            .WithStreet("Nile Street")
            .WithCity("Cairo")
            .WithState("Cairo")
            .WithZipCode("54321")
            .WithCountry("Egypt")
            .Build();


        var order = new OrderBuilder()
            .WithOrderDate(DateTime.UtcNow)
            .WithPaymentMethod("Credit Card")
            .WithCurrency("EGP")
            .WithSubTotal(1000m)
            .WithDiscountAmount(100m)
            .WithTaxAmount(90m)
            .WithTotalAmount(990m)
            .Build();


        var invoice = new InvoiceBuilder()
            .WithInvoiceId(1001)
            .WithCustomerName("Ibrahim")
            .WithCustomerEmail("ibrahim@example.com")
            .WithCustomerPhone("01000000000")
            .WithBillingAddress(billingAddress)
            .WithShippingAddress(shippingAddress)
            .WithOrder(order)
            .Build();

    }
}
