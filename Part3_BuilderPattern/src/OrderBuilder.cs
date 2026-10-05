using System;
public class OrderBuilder
{
    private DateTime? _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private decimal? _subTotal;
    private decimal? _discountAmount;
    private decimal? _taxAmount;
    private decimal? _totalAmount;


    public OrderBuilder WithOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder WithPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder WithCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder WithSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public OrderBuilder WithDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder WithTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public OrderBuilder WithTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
        return this;
    }


    public Order Build()
    {
        Validate();

        return new Order(
            _orderDate!.Value,
            _paymentMethod,
            _currency!,
            _subTotal!.Value,
            _discountAmount ?? 0,
            _taxAmount ?? 0,
            _totalAmount!.Value
        );
    }


    private void Validate()
    {
        if (!_orderDate.HasValue)
            throw new InvalidOperationException(
                "OrderDate is required.");

        if (string.IsNullOrWhiteSpace(_currency))
            throw new InvalidOperationException(
                "Currency is required.");

        if (!_subTotal.HasValue)
            throw new InvalidOperationException(
                "SubTotal is required.");

        if (!_totalAmount.HasValue)
            throw new InvalidOperationException(
                "TotalAmount is required.");

        if (_subTotal < 0)
            throw new InvalidOperationException(
                "SubTotal cannot be negative.");

        if (_discountAmount < 0)
            throw new InvalidOperationException(
                "DiscountAmount cannot be negative.");

        if (_taxAmount < 0)
            throw new InvalidOperationException(
                "TaxAmount cannot be negative.");

        if (_totalAmount < 0)
            throw new InvalidOperationException(
                "TotalAmount cannot be negative.");
    }
}