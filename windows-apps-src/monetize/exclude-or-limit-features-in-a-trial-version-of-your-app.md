---
Xxxxxxxxxxx: Xx xxx xxxxxx xxxxxxxxx xx xxx xxxx xxx xxx xxxx xxxxxx x xxxxx xxxxxx, xxx xxx xxxxxx xxxx xxxxxxxxx xx xxxxxxx xx xxx xxxx xxxxxxx xx xxxx xxx xx xxxxxxxxx xx xxxxxxxx xxxx xxxxxxxx xxxxxx xxx xxxxx xxxxxx.
xxxxx: Xxxxxxx xx xxxxx xxxxxxxx xx x xxxxx xxxxxxx
xx.xxxxxxx: YXYYYYYX-YXXY-YYYX-YYYY-XYXYYYXXYYYY
xxxxxxxx: xxxx xxxxx
xxxxxxxx: xxxx xxxxx xxxxxx
xxxxxxxx: xxxx xxxxx xxxx xxxxxxx
xxxxxxxx: xxxx xxxxx xxxx xxxxxx
---

# Xxxxxxx xx xxxxx xxxxxxxx xx x xxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xx xxx xxxxxx xxxxxxxxx xx xxx xxxx xxx xxx xxxx xxxxxx x xxxxx xxxxxx, xxx xxx xxxxxx xxxx xxxxxxxxx xx xxxxxxx xx xxx xxxx xxxxxxx xx xxxx xxx xx xxxxxxxxx xx xxxxxxxx xxxx xxxxxxxx xxxxxx xxx xxxxx xxxxxx. Xxxxxxxxx xxxxx xxxxxxxx xxxxxx xx xxxxxxx xxxxxx xxx xxxxx xxxxxx, xxxx xxxx xxxx xxxx xxxx xxx xxxx xxxxxx xxxx xx xxxx xxxx x xxxx xxxxxxx xxx xxxx xxxxxxxxx. Xxx xxx xxxx xxxxxx xxxxxxxx, xxxx xx xxxxxxx xx xxxxxxxxxx, xxxx xxx xxxxx xxxx xxxxxx xxx xxxxx, xxxxxx x xxxxxxxx xxxx xxxx xxx.

Xxx'x xxxx xx xxx xx xxx xxxx xx xxxx xxx.

## Xxxxxxxxxxxxx

X Xxxxxxx xxx xx xxxxx xx xxx xxxxxxxx xxx xxxxxxxxx xx xxx.

## Xxxx Y: Xxxx xxx xxxxxxxx xxx xxxx xx xxxxxx xx xxxxxxx xxxxxx xxx xxxxx xxxxxx

Xxx xxxxxxx xxxxxxx xxxxx xx xxxx xxx xx xxxxxx xx xxxxxxxxxx xx xxx [**XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225157) xxxxx. Xxxxxxxxx, xxx xxx xxx xxxxxxxxx xxxx xxxxxx xx xxx xxxxxxx xxxxx xx x xxxxxxxxxxx xxxxx, xx xx xxxxxxxx xx xxx xxxx xxxx. Xxxx xxxxxxxxxxx xxxxx xxxxxxxx, xxxx xxxx xxx xxx xxxxxxxxx xxxx xx x xxx xxxx xxxx xxxx xx xxx xxxxxxx xxxxxx.

Xxxx, xxxxxx xxx xxx xxxx xx xxxxxx xxxxxxx xx xxx xxx'x xxxxxxx xxxxx xxx xxx xx xxxxxxx. Xxxx xxxxx xxx xxx xx xxxx-xxxxxxxx, xxx xxxx xx-xxx xx xxxxxxx xxxxx xxx xxxx-xxx xxxxxxx xxxxx'x. Xx, xxxx xxxxx xxx xxx xxxxxxx xxxxxxx xxxxxxxx, xx xxxxxxx xxxxxxx xxxxxxxx xxxxxx xxx xxxx xx xxx xx.

Xxxxx xxxxx xxx xxxx xx xxx xxx'xx xxxxxx xxx xxxx x xxxx xxxxx xx xxxxxxxxxx xxxxxxxx xx xxx xx. Xxx x xxxxx xxxxxxx xx x xxxx, x xxxx xxxxxxxx xx xx xxxxx xxx xxxxxx xx xxxx xxxxxxx xxxx x xxxx xxx xxxx. Xxx x xxxxx xxxxxxx xx x xxxxxxx, xxx xxxxx xxxxxxxx xxxxxxx xx xxxxxxxxxx xxxx, xx xxxxxxxx xxx xxxxxxxx xxxx x xxxxxxxxx xxxxx xxx xxx.

Xxx xxxx xxx-xxxxxx xxxx, xxxxxxx xx xxxxxxxxxx xxxx xxxxx xxxx, xxxxxxx xxxxx xxx xxxxxxx x xxxx xxxxxxxxxxxxx xx xxx xxxxxxxx xxx. Xxxx xxx x xxx xxxxxx xxxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx xxx xxxxxxxx xxxx.

-   **Xxxxx xxxxxxx xxxxxxx xxxxx xxx xxx xx xxxxxxx**

    Xx xxx xxxxx xxxxxxx xxxxx xxxx xxx xx xxxxxxx, xxxx xxx xxx:

    -   Xx xxxxxxx.
    -   Xxxxxxx x xxxxxxx xx xxxx xxxxxxxx.
    -   Xxxxx.
    -   Xxxxxx xxxx xxxxxxxx xx xxx xxx xxx.

    Xxx xxxx xxxxxxxx xx xx xxxxxxx x xxxxxxx xxxx x xxxxxx xxx xxxxxx xxx xxx, xxx xx xxx xxxxxxxx xxxx xx, xxxxxxxx xxxx xxx xxxxxxxx xxxxxxx. Xx xxx xxxx xxxxxxx xxx xx xxx xxx xxx, xxxxx xx xx xxxxxx xxxx xx xxx xxx xxx xx xxxxxxx xxxxxxxxx.

-   **Xxxxx xxxxxxx xxxxxxx xxxxxx xxx xxx xx xxxxxxxx**

    Xx xxx xxxxx xxxxxxx xxxxxx xxx xxxx xxxxxxxx xxx xxx, xxxx xxx xxx'x xxxxxx. Xxxxxxx, xxxxx xxx x xxxxxx xxx xxxx xxxxx xxxx xxx xxxxxx xx xxxxxxxx xxxx xxx xxxx xxx Xxxxx.

-   **Xxxxxxxx xxxx xxx xxx xxxxx xx xx xxxxxxx**

    Xx xxx xxxxxxxx xxxx xxxx xxx xxxxx xx xx xxxxxxx, xxxx xxx xxxx xxxxxxx xxxx xxx xxx xxxx.

    -   Xx xxxxxxx xxx xxx xxxx xxxxxxxx xx xxxxx xxxx xxxxx xxxx xxxxxxx xxx xxx.
    -   Xxxxx xxxx xxx xxxxxx xx xxxxxxx x xxxxxxx.
    -   Xxxxxxxx xxxxxx xxx xxxxxxxx xxxx xxx xxxxxxxxx xxxx x xxxx-xxxxxxx (xx xxxxxxx xxx xxxxx-xxxx xxxxxxx).

Xx xxx xxxx xx xxxxxx xxx xxxxxxx xxxxxx xxx xxxx xxxx xxxxxx xx xxxx xxx, xxx xxxx xxx xx xxxxx xxxxxxx xxx xxxx xx xxxxxxxxx xx xxx xxxx xxxx.
## Xxxx Y: Xxxxxxxxxx xxx xxxxxxx xxxx

Xxxx xxxx xxx xx xxxxxxxxxxxx, xxx xxx [**XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225157) xxxxxx xxx xxxx xxx xx xxxxx xx xxxx xxxxxxx. Xx xxxxxx xxxx **xxxxxxxXxxxxxxxxxx** xx x xxxxxx xxxxxxxx xx xxxxx xx xxxx **XxxxxxxXxxxxxxxxxx**.

Xxxxxxxxxx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xx xxxxxx xxx xxx'x xxxxxxx xxxx.

```CSharp
void initializeLicense()
{
    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;
      
}
```

Xxx xx xxxxx xxxxxxx xx xxxxxxx xxxxxxxxxxxxx xxxx xxx xxxxxxx xxxxxxx xxxxx xxx xxx xx xxxxxxx. Xxx xxx'x xxxxxxx xxxxx xxxxxx xx xxx xxxxx xxxxxx xxxxxxx xx xxx xxxxxxxx xxxx xxx xxx xxxxxxx x Xxxxx, xxx xxxxxxx.

```CSharp
void InitializeLicense()
{
    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;

    // Register for the license state change event.
     licenseInformation.LicenseChanged += new LicenseChangedEventHandler(licenseChangedEventHandler);

}

// ...

void licenseChangedEventHandler()
{
    ReloadLicense(); // code is in next steps
}
```

## Xxxx Y: Xxxx xxx xxxxxxxx xx xxxxxxxxxxx xxxxxx

Xxxx xxx xxxxxxx xxxxxx xxxxx xx xxxxxx, xxxx xxx xxxx xxxx xxx Xxxxxxx XXX xx xxxxxxxxx xx xxx xxxxx xxxxxx xxx xxxxxxx. Xxx xxxx xx xxxx xxxx xxxxx xxx xx xxxxxxxxx xxxx xxxxxxx xxx xxxx xxxxx. Xx xxxx xxxxx, xx x xxxx xxxxxx xxx xxx, xx xx x xxxx xxxxxxxx xx xxxxxxx xxxxxxxx xx xxx xxxx xxxx xxx xxxxxxxxx xxxxxx xxx xxxxxxx. Xxx xxxxx xxxx xx xxx xxx xxxx xx xxxxxxx xxx xxx xx xxxx'x xxx xxx'xx xxxxx xx. Xxx xxxx xxxx xxxxxxxxxx xx xxxxxxxx xxx xxxxxxxx xx xxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxxxx xx xxx'x xxxxxxx xxxxxx xx xxxx xxx xxx xxxxxx xx xxxxxxx x xxxxxxx xx xxxx xxx xxxxxxxxxxx.

```CSharp
void ReloadLicense()
{
    if (licenseInformation.IsActive)
    {
         if (licenseInformation.IsTrial)
         {
             // Show the features that are available during trial only.
         }
         else
         {
             // Show the features that are available only with a full license.
         }
     }
     else
     {
         // A license is inactive only when there' s an error.
     }
}
```

## Xxxx Y: Xxx xx xxx'x xxxxx xxxxxxxxxx xxxx

Xxxxxxx xxxx xx xxxxxxxxx xxx xxx'x xxxxx xxxxxxxxxx xxxx.

Xxx xxxx xx xxxx xxxxxxx xxxxxxx x xxxxxxxx xx xxx xxx xxxxxxxxxx xxxx xx xxx xxx'x xxxxx xxxxxxx. Xx xxx xxxxxxx xx xxxxx xxxxx, xxxxxxx xxx xxxxxxxxxx xxxx xxxx xxx xxxxxx xx xxxx xxxx xxxxx xxx xxxxx xxxxxxx.

```CSharp
void DisplayTrialVersionExpirationTime()
{
    if (licenseInformation.IsActive)
    {
        if (licenseInformation.IsTrial)
        {
            var longDateFormat = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longdate");
                                                
            // Display the expiration date using the DateTimeFormatter. 
            // For example, longDateFormat.Format(licenseInformation.ExpirationDate)

            var daysRemaining = (licenseInformation.ExpirationDate - DateTime.Now).Days;

            // Let the user know the number of days remaining before the feature expires
        }
        else
        {
            // ...
        }
    }
    else
    {
       // ...
    }
}
```

## Xxxx Y: Xxxx xxx xxxxxxxx xxxxx xxxxxxxxx xxxxx xx xxx Xxxxxxx XXX

Xxx, xxxx xxxx xxx xxxxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxxx. Xx XxxxXxxxxx, X#, Xxxxxx Xxxxx, xx Xxxxxx X++, xxxxxxx xxxxxxxxxx xx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xx xxx xxx'x xxxxxxxxxxxxxx xxxx.

[
            **XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xxxx xxxx-xxxxxxxx xxxxxxxxx xxxx xxxx xx XXX xxxx xxxxxx "XxxxxxxXxxxxXxxxx.xxx", xxxxxxx xx %xxxxxxxxxxx%\\XxxXxxx\\xxxxx\\xxxxxxxx\\&xx;xxxxxxx xxxx&xx;\\XxxxxXxxxx\\Xxxxxxxxx\\Xxxxxxx Xxxxx\\XxxXxxx. Xx xxxx xxxx xxx xxxx xxx'x xxxxx, xxx xxxx xxxxxx xxxx, xxxxxx xxxxxx xxxxxxxxxxxx xx xx xxx-xxxx. Xx xxx xxx xx xxxxxx xxx [**XxxxxxxXxxXxxxxxxxx.XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779768) xxxxxxxx xxxxxxx XxxxxxxXxxxxXxxxx.xxx xxxxxxx xx xxxx xxxxxxxx xxxxxxxx, xxx xxxx xxx xx xxxxx.

Xxxx xxxxxxx xxxxxxxxxxx xxx xxx xxx xxx xxxx xx xxxx xxx xx xxxx xx xxxxx xxxxxxxxx xxxxxxxxx xxxxxx.

```CSharp
void appInit()
{
    // some app initialization functions

    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;

    // other app initialization functions
}
```

Xxx xxx xxxx XxxxxxxXxxxxXxxxx.xxx xx xxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxxx xxx xxxx xxx xxx xxx xxx xxxxxxxx. Xxxx xxx xxxx xxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxxxxxxxxx xx xxxx xxxx xxxxxxxxxx xxxxx xx xxxxxxxx.

## Xxxx Y: Xxxxxxx xxx xxxxxxxxx Xxxxxxx XXX xxxxxxx xxxx xxx xxxxxx XXX

Xxxxx xxx xxxx xxxx xxx xxxx xxx xxxxxxxxx xxxxxxx xxxxxx, xxx xxxxxx xxx xxxxxx xxxx xxx xx x Xxxxx xxx xxxxxxxxxxxxx, xxxxxxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xxxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765), xx xxxxx xx xxx xxxx xxxx xxxxxx.

**Xxxxxxxxx**  Xxxx xxx xxxx xxx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxxxx xxxx xxx xxxxxx xxxx xxx xx x Xxxxx xx xx xxxx xxxx xxxxxxxxxxxxx.

```CSharp
void appInit()
{
    // some app initialization functions

    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    //   licenseInformation = CurrentAppSimulator.LicenseInformation;

    // other app initialization functions
}
```

## Xxxx Y: Xxxxxxxx xxx xxx xxxx xxxxx xxxxx xx xxxx xxxxxxxxx

Xx xxxx xx xxxxxxx xxx xxxx xxx xxxx xxxxxx xxxxxx xxx xxxxx xxx xxxx xxxxx xxxxxx xx xxxx xxxxxxxxx xxx'x xx xxxxxxxxx xx xxxx xxx'x xxxxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxx xxx, xxx [Xxxxxx xxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt148529).

## Xxxxxxx xxxxxx

* [Xxxxx xxxxxx (xxxxxxxxxxxx xxxxxx xxx xx-xxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [Xxx xxx xxxxxxx xxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt148548)
* [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765)
* [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766)
 

 




<!--HONumber=Mar16_HO1-->
