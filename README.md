
[![stable](https://img.shields.io/nuget/v/RevolutAPI.svg?label=stable)](https://www.nuget.org/packages/RevolutAPI/)

# NOTICE
⚠️ Be **careful** using Revolut. Use it with **caution**, because they can **close your account** at any time **without prior notice** or **any explanation**.

# API documentation
https://developer.revolut.com/docs/merchant/merchant-api

https://developer.revolut.com/docs/business/business-api

API version: `2024-09-01`

# Supported API-s
* Business API 
* Merchant API

# Migrating to 4+
## Breaking changes 
### 1. API Endpoint URL has changed

- Previously, API Endpoint URL contained version number, e.g. `https://b2b.revolut.com/api/1.0`.
- Now, API Endpoint URL MUST NOT contain version number, e.g. `https://b2b.revolut.com/api`.

### 2. Request Models Constructor Added

- Previously, request models were initialized using object initializers, e.g.,
  ```csharp
  CreateOrderReq orderRequest = new CreateOrderReq
  {
    Amount = 10,
    Currency = "EUR"
  };
   ```         
            
- Now, all request models require explicit constructor initialization. For example:
    ```csharp
  CreateOrderReq orderRequest = new CreateOrderReq(amount:10,currency:"EUR")
   ```  
Each constructor includes required parameters, which enforces stricter model validation during object creation

### 3. Separation of API Methods into Specific Clients

Several methods have been moved to distinct API client classes for better modularity and adherence to single-responsibility principles.

- **PaymentApiClient**:
  - Previously, all payment-related methods (e.g., `CreateTransfer`, `CreatePayment`, `CreatePayment`,`GetTransactions`...) were housed in this class.

#### Example:
```csharp
// Before:
var paymentApi = new PaymentApiClient();
paymentApi.GetTransactions(...);
paymentApi.SchedulePayment(...);


// Now:
var transactionApi = new TransactionApiClient();
transactionApi.GetTransactions(...);

var paymentDraftsApi = new PaymentDraftsApiClient();
transactionApi.CreatePaymentDraft(...);
```
 
For details about the methods available in each client, refer to the client-specific documentation below.


### 4. Changes in OrderApiClient (MerchantApi)

The request and response parameters for the `OrderApiClient` methods have been updated to align with the current Revolut API version (2024-09-01). This update includes revisions for better clarity, extensibility, and additional metadata in the response format. Be sure to review the updated method signatures and response handling logic when working with the `OrderApiClient`.

## Migration Guide

To update your existing codebase to comply with these changes:

### 1. Remove version number from API Endpoint URL.

### 2. Update Request Model Initialization:
- Refactor all model initializations to use constructors instead of object initializers.
- Review the required parameters for each model constructor.

### 3. Adapt to New API Client Structure:
- Replace calls to methods previously in `PaymentApiClient` with the respective client class (e.g., `TransferApiClient`, `TransactionApiClient`).
- Instantiate and use the appropriate client class for each specific operation.

### 4. Update OrderApiClient Usage:
- Review the updated request parameter structure and revise method calls accordingly.
- Adjust response parsing logic to accommodate new response formats.



# Notes
For merchant API you only need a merchant API key and API version

# Get NuGet Package
[RevolutAPI ](https://www.nuget.org/packages/RevolutAPI/)

# Source code client setup
1. Clone RevolutLib from [GitHub](https://github.com/ssrdio/RevolutAPI) inside your project directory
2. Add the RevolutApi project to yout solution
3. Add a reference to the RevolutApi project


# Business API Setup 
## Authorization and Authentication
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


# BusinessApi client docs:
### [AccountApiClient](https://developer.revolut.com/docs/business/accounts)
* `GetAccounts()` -  Retrieves your accounts
* `GetAccount(string id)` - Retrieves one of your accounts by ID
* `GetAccountDetails(string id)` - Retrieves individual account details

### [CardApiClient](https://developer.revolut.com/docs/business/cards)
* `GetCards(GetCardsReq request)` -  Get the list of all cards in your organisation. The results are paginated and sorted by the created_at date in reverse chronological order.
* `GetCardDetails(string card_id)` -  Get the details of a specific card, based on its ID.
* `GetSensitiveCardDetails(string card_id)` -  Get sensitive details of a specific card, based on its ID. Requires the READ_SENSITIVE_CARD_DATA ``token scope.
* `CreateCard(CreateCardReq request)` -  Create a new card for an existing member of your Revolut Business team. When using the API, you can create only virtual cards. To create a physical card, use the Revolut Business app.
* `UpdateCardDetails(string card_id, UpdateCardReq request)` -  Update details of a specific card, based on its ID.
* `TerminateCard(string card_id)` -  Terminate a specific card, based on its ID. Once the card is terminated, it will not be returned by the API. A successful response does not get any content in return.
* `FreezeCard(string card_id)` -  Freeze a card to make it temporarily unavailable for spending. You can only freeze a card that is in the state active. A successful freeze changes the card's state to frozen, and no content is returned in the response.
* `UnfreezeCard(string card_id)` -  Unfreeze a card to re-enable spending for that card. You can only unfreeze a card that is in the state frozen. A successful unfreeze changes the card's state back to active, and no content is returned in the response.

### [CounterPartiesApiClient](https://developer.revolut.com/docs/business/counterparties)
* `CreateCounterparty(CreateCounterpartyReq request)` - Create a new counterparty to transact with. Depending on which country a counterparty account is based in, the fields that you need to specify are different.
* `DeleteCounterparty(string id)` - Deletes a counterparty with the given ID. Once a counterparty is deleted no payments can be made to it.
* `GetCounterparty(string id)` - Retrieves a counterparty by ID.
* `GetCounterparties()` - Retrieves all your counterparties.

### [ExpensesApiClient](https://developer.revolut.com/docs/business/expenses)
* `GetExpenses(GetExpensesReq request)` -  Get all your expenses, or use the query parameters to filter the results.
* `GetExpense(string expense_id)` -  Get the information about a specific expense by ID.

### [ForeignExchangeApiClient](https://developer.revolut.com/docs/business/foreign-exchange)
* `GetExchangeRate(GetExchangeRateReq request)` -  Get the sell exchange rate between two currencies.
* `Exchange(ExchangeMoneyReq request)` - Exchange money using one of these methods:  
  - `Sell currency`:  You know the amount of currency to sell. For example, you want to exchange 135.5 USD to some EUR.  
    Specify the amount in the `from` object.

  - `Buy currency`: You know the amount of currency to buy. For example, you want to exchange some USD to 200 EUR.
    Specify the amount in the  `to` object.

### [PaymentDraftsApiClient](https://developer.revolut.com/docs/business/payment-drafts)
* `GetPaymentDrafts()` -  Get the list of payment drafts created with the API that haven't been sent for processing.
* `GetPaymentDraft(string payment_draft_id)` -  Get the information about a specific payment draft by ID. The response lists the details of the payment(s) included in the draft, as well as the draft details.
* `CreatePaymentDraft(CreatePaymentDraftReq request)` -  Create a payment draft. When you create a payment draft, it stays a draft until you send it for processing as payment in the Revolut Business app. Until then, you can delete the draft if you no longer wish to proceed with it.
* `DeletePaymentDraft(string payment_draft_id)` -  Delete a payment draft with the given ID. You can delete a payment draft only if it hasn't been sent for processing.

### [PayoutLinksApiClient](https://developer.revolut.com/docs/business/payout-links)
* `GetPayoutLinks(GetPayoutLinksReq request)` -  Get all the links that you have created, or use the query parameters to filter the results. The links are sorted by the `created_at` date in reverse chronological order. The returned links are paginated. The maximum number of payout links returned per page is specified by the `limit` parameter. To get to the next page, make a new request and use the `created_at` date of the last payout link returned in the previous response.
* `GetPayoutLink(string payout_link_id)` -  Get the information about a specific link by its ID.
* `CreatePayoutLink(CreatePayoutLinkReq request)` -  Create a payout link to send money even when you don't have the full banking details of the counterparty.
After you have created the link, send it to the recipient so that they can claim the payment.
* `CanclePayoutLink(string payout_link_id)` -  Cancel a payout link. You can only cancel a link that hasn't been claimed yet. A successful request does not get any content in response.
* `GetTransferReasons()` -  In order to initiate a transfer in certain currencies and countries, you must provide a transfer reason. With this endpoint you can retrieve all transfer reasons available to your business account per country and currency. After you retrieve the results, use the appropriate reason code in the `transfer_reason_code` field when making a transfer to a counterparty or creating a payout link.

### [TransactionApiClient](https://developer.revolut.com/docs/business/transactions)
* `GetTransactions(GetTransactionsReq request)` -  Retrieve the historical transactions based on the provided query criteria.The transactions are sorted by the `created_at` date in reverse chronological order, and they're paginated. The maximum number of transactions returned per page is specified by the `count` parameter. To get the next page of results, make a new request and use the `created_at` date from the last item of the previous page as the value for the `to` parameter.
* `GetTransaction(string transaction_id)` -  Retrieve the details of a specific transaction. The details can include, for example, cardholder details for card payments.

### [TransferApiClient](https://developer.revolut.com/docs/business/transfers)
* `TransferMoneyBetweenAccounts(TransferBetweenAccountsReq request)` -  Move money between the Revolut accounts of the business in the same currency.
The resulting transaction has the type `transfer`.
* `TransferToAnotherAccountOrCard(TransferToAnotherAccountOrCardReq request)` -  Make a payment to a counterparty. You can choose either a bank transfer or a card transfer. The resulting transaction has the type `transfer`.
If you make the payment to another Revolut account, either business or personal, the transaction is executed instantly.
If the counterparty has multiple payment methods available, for example, 2 accounts, or 1 account and 1 card, you must specify the account or card to which you want to transfer the money (`receiver.account_id` or `receiver.card_id` respectively) .

### [TeamMemberApiClient](https://developer.revolut.com/docs/business/team-members)
* `GetTeamMemebers(GetTeamMembersReq request)` -  Get information about all the team members of your business.
* `InviteNewMember(InviteMemberReq request)` -  Invite a new member to your business account.
When you invite a new team member to your business account, an invitation is sent to their email address that you provided in this request. To join your business account, the new team member has to accept this invitation.

### [WebhookApiClient](https://developer.revolut.com/docs/business/webhooks-v-2)
* `GetWebhooks()` -  Get the list of all your existing webhooks and their details.
* `GetWebhook(string webhook_id)` -  Get the information about a specific webhook by ID.
* `CreateWebhook(CreateWebhookReq request)` -  Create a new webhook to receive event notifications to the specified URL. Provide a list of event types that you want to subscribe to and a URL for the webhook. Only HTTPS URLs are supported.
* `UpdateWebhook(string webhook_id,UpdateWebhookReq request)` -  Update an existing webhook. Change the URL to which event notifications are sent or the list of event types to be notified about.
You must specify at least one of these two. The fields that you don't specify are not updated.
* `DeleteWebhook(string webhook_id)` -  Delete a specific webhook.
A successful response does not get any content in return.
* `Rotate(string webhook_id, RotateWebhookReq request)` - Rotate a signing secret for a specific webhook.
* `GetFailedWebhookEvents(string webhook_id, GetFailedWebhookEventsReq request)` - Get the list of all your failed webhook events, or use the query parameters to filter the results.
The events are sorted by the `created_at` date in reverse chronological order.
The returned failed events are paginated. The maximum number of events returned per page is specified by the `limit` parameter. To get to the next page, make a new request and use the `created_at` date of the last event returned in the previous response.

# MerchantApi client docs:

### [OrderApiClient](https://developer.revolut.com/docs/merchant/orders)
* `GetOrderList(GetOrderListReq request)` -  Retrieve all the orders that you've created. 
* `GetOrder(string order_id)` -  Retrieve the details of an order that has been created. Provide the unique order ID, and the corresponding order information is returned. 
* `CreateOrder(CreateOrderReq request)` -  Create an Order `object`.
Creating orders is one of the basic operations of the Merchant API. Most of the other operations are related to creating orders. Furthermore, the payment methods merchants can use to take payments for their orders are also building on order creation.
* `UpdateOrder(string order_id, UpdateOrderReq request)` -  You can update an order and specific parameters based on the value of the `state` parameter. 
* `CaptureOrder(string order_id, CaptureOrderReq request)` -  This endpoint is used to capture the funds of an existing, uncaptured order. When the payment for an order is authorised, you can capture the order to send it to the processing stage.
* `CancelOrder(string order_id)` -  Cancel an existing uncaptured order.
You can only cancel an order that is in one of the following states: `pending` or `authorised`
* `RefundOrder(string order_id,RefundOrderReq request)` -  Issue a refund for a completed order. This operation allows for either a full or partial refund, which will be processed back to the customer's original payment method.

### [CustomersApiClient](https://developer.revolut.com/docs/merchant/customers)
* `CreateCustomer(CreateCustomerRequest request)` -  Create a `customer` that has the information in the body of the request. 
* `RetrieveCustomers()` -  Get a list of all your `customers`
* `RetrieveCustomer(string customer_id)` -  Get the information about a specific `customer`, based on its ID.
* `UpdateCustomer(string customer_id, UpdateCustomerRequest request)` -  Update the attributes of a specific customer.
* `DeleteCustomer(string customer_id)` - Delete the profile of a specific customer.
* `GetPaymentMethods(string customer_id)` - Retrieve all the payment methods for a specific customer.
This can be useful in the following example cases:
    - To show what information is stored for the customer.
     - To try a different payment method if the first payment method fails when a recurring transaction occurs.
* `GetPaymentMethod(string customer_id, string payment_method_id)` - Retrieve the information of a specific payment method that is saved.
* `UpdatePaymentMethod(string customer_id, string payment_method_id, UpdatePaymentMethod request)` - When you use this request to update a customer's payment method, the payment method can't be used for merchant initiated transactions (MIT) any more. This payment method can be used only when the customer is on the checkout page.
* `DeletePaymentMethod(string customer_id, string payment_method_id)` - Delete a specific payment method. The payment method is completely deleted from the customer payment methods.
To reuse the payment method that is deleted, direct your customer to the checkout page and save the card details again.

### [MerchantPaymentsApiClient](https://developer.revolut.com/docs/merchant/payments)
* `ConfirmOrder(string order_id, PayForAnOrderReq request)` -  Initiate a payment to pay full amount for an order using a customer's saved payment method.
* `RetrievePaymentListOfAnOrder(string order_id)` -  Retrieve a list of payments for a specific order, based on the order's ID.
* `RetrievePaymentDetails(string payment_id)` -  Retrieve information about a specific payment, based on the payment's ID.

### [PayoutsApiClient](https://developer.revolut.com/docs/merchant/payouts)
* `GetPayouts(GetPayoutReq request)` -  Retrieve all the payouts you made from your Merchant account. You can also use the query parameters for  `from_created_date` , `to_created_date`, `currency`, `state` and `limit`
* `GetPayout(string payout_id)` -  Retrieve the details of a payout. Provide the unique payout ID, and the corresponding payout information is returned.

### [LocationsApiClient](https://developer.revolut.com/docs/merchant/locations)
* `CreateLocation(CreateLocationReq request)` -  Create a Location object.
* `GetLocations(CreateLocationReq request)` -  Retrieve a list of locations registered for the merchant.
* `GetLocation(string location_id)` - Retrieve details of a specific location, based on its ID.
* `UpdateLocation(string location_id, UpdateLocationReq request)` - Update details of a specific location, based on its ID.
* `DeleteLocation(string location_id,)` - Delete a specific location, based on its ID.

### [WebhookApiClient](https://developer.revolut.com/docs/merchant/webhooks)
* `CreateWebhook(CreateWebhookReq request)` -  Set up a webhook URL so that the Merchant API can push event notifications to the specified URL.
* `GetWebhooks()` -  Get a list of webhooks that you are currently subscribed to.
* `GetWebhooks(string webhook_id)` -  Get the details of a specific webhook.
* `UpdateWebhook(string webhook_id,UpdateWebhookReq request)` -  Update the details of a specific webhook.
* `DeleteWebhook(string webhook_id)` - Delete a webhook so that events are not sent to the specified URL any more.
* `RotateWebhookSigningSecret(string webhook_id,RotateWebhookSigningSecretReq request)` - Rotate the signing secret for a specific webhook.



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
