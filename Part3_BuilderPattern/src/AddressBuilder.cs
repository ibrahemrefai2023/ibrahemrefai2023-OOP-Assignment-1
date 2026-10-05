using System;
public class AddressBuilder
{
    private string? _street;
    private string? _city;
    private string? _state;
    private string? _zipCode;
    private string? _country;


    public AddressBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public AddressBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public AddressBuilder WithState(string state)
    {
        _state = state;
        return this;
    }

    public AddressBuilder WithZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }

    public AddressBuilder WithCountry(string country)
    {
        _country = country;
        return this;
    }


    public Address Build()
    {
        Validate();

        return new Address(
            _street!,
            _city!,
            _state!,
            _zipCode!,
            _country!
        );
    }


    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(_street))
            throw new InvalidOperationException(
                "Street is required.");

        if (string.IsNullOrWhiteSpace(_city))
            throw new InvalidOperationException(
                "City is required.");

        if (string.IsNullOrWhiteSpace(_state))
            throw new InvalidOperationException(
                "State is required.");

        if (string.IsNullOrWhiteSpace(_zipCode))
            throw new InvalidOperationException(
                "ZipCode is required.");

        if (string.IsNullOrWhiteSpace(_country))
            throw new InvalidOperationException(
                "Country is required.");
    }
}