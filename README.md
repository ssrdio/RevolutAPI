# API documentation
https://revolutdev.github.io/business-api/

# Get NuGet Package
[RevolutAPI ](https://www.nuget.org/packages/RevolutAPI/)

# Source code client setup
1. Clone RevolutLib from [GitHub](https://github.com/ssrdio/RevolutAPI) inside your project directory
2. Add the RevolutApi project to yout solution
3. Add a reference to the RevolutApi project

# Revolut API client usage
The client exposes parts of the Revolut API as `Client` objects (ex. `AccountApiClient`, `PaymentApiClient`).
In order to create a client you need to:
1. Create a `RevolutApiClient` instance, passing the endpoint and authentication token
2. Pass the `RevolutApiClient` instance to the specific client you wish to use

```c#
RevolutApiClient revolutApiClient = new RevolutApiClient("[endpoint]", "[token]");
AccountApiClient accountApiClient = new AccountApiClient(revolutApiClient);

// returns and prints a list of all accounts available
List<GetAccountResp> accounts = await accountApiClient.GetAccounts();
foreach (GetAccountResp account in accounts)
{
    Console.WriteLine(account.Id);
}
```

# API client docs
### AccountApiClient:
* `GetAccounts()` -  Retrieves your accounts
* `GetAccount(string id)` - Retrieves one of your accounts by ID
* `GetAccountDetails()` - Retrieves individual account details

### CounterPartiesApiClient
* `CreateCounterparty()` - Create a counterparty for an existing Revolut user.
* `CreateCounterparty(AddCounterpartyReq req)` - You can create a counterparty for an non-Revolut bank account.
* `CreateNonRevolutCounterparty(AddNonRevolutCounterpartyReq req)` - Create a counterparty for an non-Revolut bank account.
* `DeleteCounterparty(string id)` - Deletes a counterparty with the given ID. Once a counterparty is deleted no payments can be made to it.
* `GetCounterparty(string id)` - Retrieves a counterparty by ID.
* `GetCounterparties()` - Retrieves all your counterparties.

### PaymentApiClient
* `GetTransfer(TransferReq req)` - Processes transfers between accounts of the business with the same currency.
* `CreatePayment(CreatePaymentReq req)` - Creates a new payment. If the payment is for another Revolut account, business or personal.
* `SchedulePayment(SchedulePaymentReq req)` - Schedule an internal payments for up to 30 days ahead. Scheduling external payments is not supported at the moment. Scheduled payments must be in the currency of the account from which you pay.
* `CheckPaymentStatusByTransactionId(string transactionId)` - Retrieves transaction details by transaction ID. It also allows you to find out more about the transaction, such as cardholder details for card payments.
* `CheckPaymentStatusByRequestId(string requestId)` - Retrieves transaction details by transaction ID or by request ID. It also allows you to find out more about the transaction, such as cardholder details for card payments.
* `CancelPayment(string transactionId)` - Cancel a scheduled transaction that was initiated by you, via API.
* `GetTransactions(DateTime from, DateTime to, string type, string counterparty = null)` - Retrieves historical transactions based on the provided query criteria.
* `GetTransactions(string from = null, string to = null, string counterparty = null, int count = 0, string type = null)` - Retrieves historical transactions based on the provided query criteria.

# Running API client tests
In order to run tests you need to modify the `Config.cs` file in the RevolutApiTests project.
This file contains global values used during test execution. The values are:
* `ENDPOINT` - The endpoint used during testing
* `TOKEN` - The authorization token

The following values are used when testing the payment endpoints. 
* `ACCOUNT_ID` - Sender account
* `COUNTERPARTY_ID` - Reciever counterparty
* `COUNTERPARTY_ACCOUNT_ID` - Reciever counterparty account
* `CURRENCY` - Currencry used in the trasaction tests

NOTE: These values should be prexisting accounts and couterparties with a non-empty balance. The currencty should also match, otherwise the tests will fail.
