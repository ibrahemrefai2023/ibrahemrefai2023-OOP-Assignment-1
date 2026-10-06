using System;
public class InvoiceBuilder
{
    private int? _invoiceId;
    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private Address? _billingAddress;
    private Address? _shippingAddress;

    private Order? _order;


    public InvoiceBuilder WithInvoiceId(int invoiceId)
    {
        _invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder WithCustomerName(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder WithCustomerEmail(string customerEmail)
    {
        _customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder WithCustomerPhone(string customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder WithBillingAddress(Address address)
    {
        _billingAddress = address;
        return this;
    }

    public InvoiceBuilder WithShippingAddress(Address address)
    {
        _shippingAddress = address;
        return this;
    }

    public InvoiceBuilder WithOrder(Order order)
    {
        _order = order;
        return this;
    }


    public Invoice Build()
    {
        Validate();

        return new Invoice(
            _invoiceId!.Value,
            _customerName!,
            _customerEmail!,
            _customerPhone,
            _billingAddress!,
            _shippingAddress!,
            _order!
        );
    }


    private void Validate()
    {
        if (!_invoiceId.HasValue)
            throw new InvalidOperationException(
                "InvoiceId is required.");

        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException(
                "CustomerName is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException(
                "CustomerEmail is required.");

        if (_billingAddress is null)
            throw new InvalidOperationException(
                "BillingAddress is required.");

        if (_shippingAddress is null)
            throw new InvalidOperationException(
                "ShippingAddress is required.");

        if (_order is null)
            throw new InvalidOperationException(
                "Order is required.");
    }
}