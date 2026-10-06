Why is a single 20 parameter constructor a problem in practice?

A constructor with around 20 parameters is difficult to use and maintain

First the call site becomes hard to read When many values are passed positionally it is difficult to understand what each argument represents without constantly checking the constructor definition

For example several parameters may have the same type:

BillingCity and BillingState are both strings
SubTotal, DiscountAmount, TaxAmount, and TotalAmount are all decimal values.

Because they have the same type the compiler cannot detect when two values are accidentally passed in the wrong order The code can compile successfully while producing an incorrect invoice

A large constructor also becomes harder to maintain when the class changes If another optional property is added the constructor signature must change and every existing call site may need to be updated This becomes especially problematic in a large application where the object is created in many different places

Finally a constructor with many parameters makes it difficult to distinguish mandatory information from optional information The caller must provide everything at once even when some properties are not required

Is this purely a constructor is too long problem?

No, The problem is deeper than just having a long constructor

The Invoice class contains several conceptually different groups of information It contains customer information billing address information shipping address information and order/payment information

Putting all of these loosely related properties directly inside one large class makes the domain model harder to understand and maintain

For example an address naturally represents its own concept:

Street
City
State
ZipCode
Country

There is no reason for the Invoice class to treat every one of these values as unrelated primitive properties

A better design is to compose the Invoice from smaller objects such as Address and Order

Therefore the Builder pattern helps solve the complexity of constructing the object while composition helps solve the deeper problem of how the data is modeled

 Why is the composed version better than the single big builder?

The composed version is better because it separates the construction responsibilities according to the natural concepts in the domain.

Single Responsibility :

Each builder has one clear responsibility

AddressBuilder : is responsible only for constructing and validating an Address

OrderBuilder : is responsible only for constructing and validating an Order

InvoiceBuilder : is responsible for assembling the customer information the two addresses and the order into the final Invoice

This makes each builder smaller easier to understand test and maintain.

Independent Validation :

AddressBuilder : can completely validate an address without knowing anything about invoices.

For example it can guarantee that:

Street exists
City exists
State exists
ZipCode exists
Country exists

The InvoiceBuilder does not need to know how an address is validated It only needs to know that it has received a valid Address

The same principle applies to OrderBuilder which owns the validation rules for order and payment information

This creates better separation of responsibilities

Reuse :

The same AddressBuilder can be used to create both the billing and shipping addresses

There is no need to create separate BillingAddressBuilder and ShippingAddressBuilder classes

Without reuse the address building logic would have to be duplicated If the address rules changed later both implementations would need to be updated

With one AddressBuilder the address rules exist in one place

Readability at the Call Site :

The composed version makes the structure of the domain visible in the code

Instead of having one large builder containing methods such as WithBillingStreet, WithShippingStreet, WithBillingCity, WithShippingCity, and many order related methods the caller constructs meaningful domain objects first

The code becomes conceptually organized as:

 Build the billing address
 Build the shipping address
 Build the order
 Build the invoice from those objects

This makes the construction process easier to read and understand.

Conclusion :

The single Builder from Task 3.2 solves the problem of a large constructor and improves readability However the composed Builder design from Task 3.3 goes further by improving the domain model itself

Instead of treating an invoice as a collection of approximately twenty unrelated primitive properties the design models the natural relationships between the concepts:

Invoice contains two Address objects and one Order object

Therefore the composed Builder design provides better separation of responsibilities, validation, reuse, readability, and maintainability
