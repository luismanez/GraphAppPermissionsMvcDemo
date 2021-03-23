# GraphAppPermissionsMvcDemo
Just trying to help with this Twitter thread (https://twitter.com/NaupliusTrevor/status/1373709457469833217). asp.net core 3.1 MVC WebApp showing how to call MS Graph API using Application permissions.

This sample is using the Microsoft.Identity.Web library, which is great for configuring Azure AD Auth.

Sample is getting top 5 Groups in the Tenant, and printing them in the Index view.

Sample has some comments with some things to consider:
    - Using MSAL TokenCache. Sample is using InMemory cache, which is not recommended for WebApps
    - You can also configure Graph with Delegated permissions, and when calling a specific endpoint, you can set AppOnly permissions
    - Admin consent was granted from the Azure AD portal.

## Register Azure AD App
You need to register an Azure AD App and configure MS Graph API permissions. The sample requires Application permission on _Group.Read.All_. Update the settings file Azure AD section:

```json
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "TENANT.onmicrosoft.com",
    "TenantId": "Azure AD Tenant ID",
    "ClientId": "AZURE AD APP CLIENT_ID",
    "ClientSecret": "CLIENT_SECRET"
  }
```
