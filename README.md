# API documentation
https://revolutdev.github.io/business-api/

# Get NuGet Package
[RevolutAPI ](https://www.nuget.org/packages/RevolutAPI/)

# Source code client setup
1. Clone RevolutLib from [GitHub](https://github.com/ssrdio/RevolutAPI) inside your project directory
2. Add the RevolutApi project to yout solution
3. Add a reference to the RevolutApi project

# Authorization and Authentication
1. generate certificate on machine with openssl (bellow snippet in ubuntu)
```bash
openssl genrsa -out privatekey.pem 1024
openssl req -new -x509 -key privatekey.pem -out publickey.cer -days 1825
openssl pkcs12 -inkey privatekey.pem -in publickey.cer -export -out revolut_pfx.pfx
base64 revolut_pfx.pfx
```
2. copy public cert into revolut
```bash
cat publickey.cer
```
3. because .NET core currnetly does not support *.pem certificats we created pfx in previous step now what we need to to is just to base64 encode certificate and we paste it into our configuration
```bash
base64 revolut_pfx.pfx
```

4. Include nuget package

# Revolut API client usage
## Auth
This part requres manual work where we need to provide new authorization code every 90 days. 

Call function `AuthorizationApiClient.Authorize` providing all the parameters
```c#
// issuer shuld be without http or https
Result<AuthorizationCodeResp> authorisationResp = await authorizationApiClient.Authorize("base64enconced pfx cert","certificate password","your domain (issuer)", "clientId provided by revolut", "authorization code provided by revolut");
// here you save rerresh token
db.Save(authorisationResp.Value.RefreshToken);
```
## Normal usage 
```c#
RevolutApiClient revolutApiClient = new RevolutApiClient(settings.Value.RevolutSettings.Endpoint, new RevolutAPI.Models.Authorization.RefreshAccessTokenModel
{
    PrivateCert = "base64enconced pfx cert",
    CertificatePassword = "certificate password",
    ClientId =  "clientId provided by revolut",
    Issuer = "your domain (issuer)",
    RefreshToken = db.getLastRefreshToken()
}, memoryCache);

CounterPartiesApiClient counterPartiesApiClient = new CounterPartiesApiClient(revolutApiClient);
Result<AddNonRevolutCounterpartyResp> resp = await _counterPartyApiClient.CreateNonRevolutCounterparty(req);
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
