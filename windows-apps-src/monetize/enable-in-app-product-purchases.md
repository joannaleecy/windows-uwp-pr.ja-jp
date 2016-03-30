---
Xxxxxxxxxxx: Xxxxxxx xxxx xxx xx xxxx xx xxx, xxx xxx xxxx xxxxxxx, xxxxx xxxx, xx xxx xxx xxxxxxxxxxxxx (xxxx xx xxxxxxxxx xxx xxxx xxxxx xx x xxxx) xxxx xxxxx xxxxxx xxx xxx. Xxxx xx xxxx xxx xxx xx xxxxxx xxxxx xxxxxxxx xx xxxx xxx.
xxxxx: Xxxxxx xx-xxx xxxxxxx xxxxxxxxx
xx.xxxxxxx: XYYYXYXX-YYYY-YYYY-YYYY-YYYYYYYYXXYX
xxxxxxxx: xx-xxx xxxxx
xxxxxxxx: xx-xxx xxxxxxxx
xxxxxxxx: xx-xxx xxxxxxx
xxxxxxxx: xxx xx xxxxxxx xx-xxx
xxxxxxxx: xx-xxx xxxxxxxx xxxx xxxxxx
xxxxxxxx: xx-xxx xxxxx xxxx xxxxxx
---

# Xxxxxx xx-xxx xxxxxxx xxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxxx xxxx xxx xx xxxx xx xxx, xxx xxx xxxx xxxxxxx, xxxxx xxxx, xx xxx xxx xxxxxxxxxxxxx (xxxx xx xxxxxxxxx xxx xxxx xxxxx xx x xxxx) xxxx xxxxx xxxxxx xxx xxx. Xxxx xx xxxx xxx xxx xx xxxxxx xxxxx xxxxxxxx xx xxxx xxx.

**Xxxx**  Xx-xxx xxxxxxxx xxxxxx xx xxxxxxx xxxx x xxxxx xxxxxxx xx xx xxx. Xxxxxxxxx xxxxx x xxxxx xxxxxxx xx xxxx xxx xxx xxxx xxx xx xx-xxx xxxxxxx xx xxxx xxxxxxxx x xxxx xxxxxxx xx xxxx xxx.

## Xxxxxxxxxxxxx

-   X Xxxxxxx xxx xx xxxxx xx xxx xxxxxxxx xxx xxxxxxxxx xx xxx.
-   Xxxx xxx xxxx xxx xxxx xxx xx-xxx xxxxxxxx xxx xxx xxxxx xxxx, xxx xxxx xxx xxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xxxxxx xxxxxxx xx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxxxx. Xxxx xxx xxx xxx xxxxxx xxxx xxxxxxx xxxxx xxxxx xxxxxxxxx xxxxx xx xxx xxxxxxx xxxxxx xxxxxxx xx xxxxxxx xxx xxxx xxxxxx. Xx xx xxxx, xxx xxxx xx xxxxxxxxx xxx xxxx xxxxx "XxxxxxxXxxxxXxxxx.xxx" xx %xxxxxxxxxxx%\\XxxXxxx\\xxxxx\\xxxxxxxx\\&xx;xxxxxxx xxxx&xx;\\XxxxxXxxxx\\Xxxxxxxxx\\Xxxxxxx Xxxxx\\XxxXxxx. Xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxxxxxxx xxxxxxx xxxx xxxx xxxx xxx xxx xxxx xxx xxx xxx xxxxx xxxx—xx xxx xxx xxxx xxxx x xxxxxx xxx xx xxxxxxx. Xxx xxxx xxxx, xxx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766).
-   Xxxx xxxxx xxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxx xx xxx [Xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=627610). Xxxx xxxxxx xx x xxxxx xxx xx xxx xxxxx-xx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxxxx xxxxxxx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.

## Xxxx Y: Xxxxxxxxxx xxx xxxxxxx xxxx xxx xxxx xxx

Xxxx xxxx xxx xx xxxxxxxxxxxx, xxx xxx [**XxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225157) xxxxxx xxx xxxx xxx xx xxxxxxxxxxxx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xx xxxxxx xxxxxxxxx xx xx xx-xxx xxxxxxx.

```CSharp
void AppInit()
{
    // some app initialization functions 

    // Get the license info
    // The next line is commented out for testing.
    // licenseInformation = CurrentApp.LicenseInformation;

    // The next line is commented out for production/release.       
    licenseInformation = CurrentAppSimulator.LicenseInformation;

    // other app initialization functions
}
```

## Xxxx Y: Xxx xxx xx-xxx xxxxxx xx xxxx xxx

Xxx xxxx xxxxxxx xxxx xxx xxxx xx xxxx xxxxxxxxx xxxxxxx xx xx-xxx xxxxxxx, xxxxxx xx xxxxx xxx xxx xx xx xxxx xxx.

**Xxxxxxxxx**  Xxx xxxx xxx xxx xxx xx-xxx xxxxxxxx xxxx xxx xxxx xx xxxxxxx xx xxxx xxxxxxxxx xx xxxx xxx xxxxxx xxx xxxxxx xx xx xxx Xxxxx. Xx xxx xxxx xx xxx xxx xx-xxx xxxxxxxx xxxxx, xxx xxxx xxxxxx xxxx xxx xxx xx-xxxxxx x xxx xxxxxxx.

1.  **Xxxxxx xx xx-xxx xxxxx xxxxx**

    Xxx xxxxxxxx xxxx xx-xxx xxxxxxx xx xxxx xxx xx x xxxxx. Xxxx xxxxx xx x xxxxxx xxxx xxx xxxxxx xxx xxx xx xxxx xxx xxx xx xxx Xxxxx xx xxxxxxxx x xxxxxxxx xx-xxx xxxxxxx. Xxxx xx x xxxxxx (xx xxxx xxx) xxx xxxxxxxxxx xxxx xx xxxx xxx xxx xxxxxxx xxxxxxxx xxx xxxxxxx xxxxxxx xx xxxxxxxxxx xxxxx xxx xxx xxxxxx. Xxxx xxx xxxx xxxxxxxx xx xxxxx:

    -   "XxxxxXxxxxxxXxxxxY"
    -   "XxxxxxxXxxxxXxxx"
    -   "XxxxxxxXxxxxXxxx".

2.  **Xxxx xxx xxxxxxx xx x xxxxxxxxxxx xxxxx**

    Xxx xxxx xxx xxx xxxx xxx xxxx xxxxxxx xxxx xx xxxxxxxxxx xxxx xx xx-xxx xxxxxxx xx x xxxxxxxxxxx xxxxx xxxx xxxxx xx xxx xx xxx xxxxxxxx xxx x xxxxxxx xx xxx xxxx xxxxxxx.

    Xxxx'x xx xxxxxxx xxxx xxxxx xxx xxx xxx xxxx x xxxxxxx xxxxxxx xxxxx **xxxxxxxXxxx** xx x xxxxxxx-xxxxxxxx xxxxxxxxxxx xxxxx. Xxx xxxxxx, **xxxxxxxXxxx**, xx xxx xxxxx xxxx xxxxxxxx xxxxxxxxxx xxxx xxxxxxx xxxxxx xxx xxx xxx xx xxxx xxxx xx xxxxxxxx xx xx xxx Xxxxx.

    ```    CSharp
    if (licenseInformation.ProductLicenses["featureName"].IsActive) 
        {
            // the customer can access this feature
        } 
        else
        {
            // the customer can' t access this feature
        }
    ```

3.  **Xxx xxx xxxxxxxx XX xxx xxxx xxxxxxx**

    Xxxx xxx xxxx xxxx xxxxxxx x xxx xxx xxxx xxxxxxxxx xx xxxxxxxx xxx xxxxxxx xx xxxxxxx xxxxxxx xx xxx xx-xxx xxxxxxx. Xxxx xxx'x xxxxxxxx xxxx xxxxxxx xxx Xxxxx xx xxx xxxx xxx xxxx xxxxxxxxx xxx xxxx xxx.

    Xxxx'x xxx xx xxxx xx xxx xx xxxx xxxxxxxx xxxxxxx xxxx xx xx-xxx xxxxxxx xxx, xx xxxx xxx'x, xxxxxxxx xxx xxxxxxxx xxxxxx xx xxxx xxx xxx xx. Xxxxxxx xxx xxxxxxx "xxxx xxx xxxxxxxx xxxxxx" xxxx xxxx xxxxxx xxxx xxx xxx xxxxxxxx xxxxxx (xxxx xx x xxxx xxxx x xxxxxxxx "Xxx xxxx xxx!" xxxxxx).

    ```    CSharp
    void BuyFeature1() {
            if (!licenseInformation.ProductLicenses["featureName"].IsActive)
            {
                try
                    {
                    // The customer doesn't own this feature, so 
                    // show the purchase dialog.
                                    
                    await CurrentAppSimulator.RequestProductPurchaseAsync("featureName", false);
                    //Check the license state to determine if the in-app purchase was successful.
                }
                catch (Exception)
                {
                    // The in-app purchase was not completed because 
                    // an error occurred.
                }
            } 
            else
            {
                // The customer already owns this feature.
            }
        }
    ```

## Xxxx Y: Xxxxxx xxx xxxx xxxx xx xxx xxxxx xxxxx

Xxxx xx xx xxxx xxxx: xxxxxx xxxxx xxxxxxxxx xx [**XxxxxxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh779766) xx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xx xxxx xxx'x xxxx. Xxx xxx'x xxxx xx xxxxxxx xxx XxxxxxxXxxxxXxxxx.xxx xxxx xxx xxxxxx, xx xxxxxx xx xxxx xxxx xxx'x xxxx (xxxxxxxx xxx xxx xxxx xx xxxx xx xxx xxxxxxxxx xxxx xxx xxxxxxxxx xxx xx-xxx xxxxx xx xxx xxxx xxxx).

## Xxxx Y: Xxxxxxxxx xxx xx-xxx xxxxxxx xxxxx xx xxx Xxxxx

Xx xxx Xxx Xxxxxx xxxxxxxxx, xxxxxx xxx xxxxxxx XX, xxxx, xxxxx, xxx xxxxx xxxxxxxxxx xxx xxxx xx-xxx xxxxxxx. Xxxx xxxx xxxx xxx xxxxxxxxx xx xxxxxxxxxxx xx xxx xxxxxxxxxxxxx xxx xxx xx XxxxxxxXxxxxXxxxx.xxx xxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [XXX xxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt148551).

## Xxxxxxx

Xx xxx'xx xxxxxxxxxx xx xxxxxxxxx xxxx xxxxxxxxx xxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxx (xxxxx xxxx xxx xx xxxxxxxxx, xxxx xx, xxx xxxx xxxxxxxxx xxxxx xx xxxxxxx), xxxx xx xx xxx [Xxxxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-consumable-in-app-product-purchases.md) xxxxx.

Xx xxx xxxx xx xxx xxxxxxxx xx xxxxxx xxxx xxxx xxxx xx xx-xxx xxxxxxxx, xx xxxx xx xxxxxx [Xxx xxxxxxxx xx xxxxxx xxxxxxx xxxxxxxxx](use-receipts-to-verify-product-purchases.md).

## Xxxxxxx xxxxxx


* [Xxxxxx xxxxxxxxxx xx-xxx xxxxxxx xxxxxxxxx](enable-consumable-in-app-product-purchases.md)
* [Xxxxxx x xxxxx xxxxxxx xx xx-xxx xxxxxxxx](manage-a-large-catalog-of-in-app-products.md)
* [Xxx xxxxxxxx xx xxxxxx xxxxxxx xxxxxxxxx](use-receipts-to-verify-product-purchases.md)
* [Xxxxx xxxxxx (xxxxxxxxxxxx xxxxxx xxx xx-xxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
 

 




<!--HONumber=Mar16_HO1-->
