---
xxxxx: Xxxxx xxxxx
xxxxxxxxxxx: Xxxx xxxxx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xxxxx xxxxx xx xxxxxxx xxxxx xx xxxxxx xxxxxxx xxxxxxxx, xxxxxxxxx xxx xx xxxxxx xxxxxxxx xxxxx xxxx xxxxxxx, xxxxxx xxxxxxx xxxxx xxxxx, xxxxxxxxxxx xxxx xxxxx xxxxx, xxxxxxxxxxxx xxxxx, xxxxx xxxx XXXx, xxx xxxxxx xx xxxxxxxxxx xxxxx xxxxx.
xx.xxxxxxx: YYYYYYYY-YYXY-YYYY-XXYY-YYXYXYXYYYYY
---

# Xxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xxxxx xxxxx xx xxxxxxx xxxxx xx xxxxxx xxxxxxx xxxxxxxx, xxxxxxxxx xxx xx xxxxxx xxxxxxxx xxxxx xxxx xxxxxxx, xxxxxx xxxxxxx xxxxx xxxxx, xxxxxxxxxxx xxxx xxxxx xxxxx, xxxxxxxxxxxx xxxxx, xxxxx xxxx XXXx, xxx xxxxxx xx xxxxxxxxxx xxxxx xxxxx.

## Xxxxxxxxx xxx xxx xxxxxxxx


Xxxxxx xxxx xxx xxx xxxxxxxxxxxx xxxxx xxxxx xxxxx xxxxx xx xxxxxxx xxxxx xxxxx, xxx xxxx xxx xxx **Xxxxxx Xxxx Xxxxxxxxxxxx** xxxxxxxxxx xx xxx xxxxxxx Xxxxxxx.xxxxxxxxxxxx xxxx.

## Xxxxxx xxxxxxxxx xxxx xxxxxxx xxx xxxxx xxxxx


Xxx xxx xxxxx xxx xxxxxxx xxx xxxxxxxx xxxxx xxxxx xx xxxxxxx xxx xxxxxx XX (xxxxxxxxx xx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225393)) xx xxx [**XxxxxXxxxXxxxxx.XxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263890) xxxxxx. Xx xxxxxx xxx xxxxx xxxxx xxxxxxxxx xxxxxxxx xx xxx xxxxxxxx xxxxxx xxxxxx, xxxx [**XxxxxXxxxXxxxxx.XxxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263887).

```cs
string selector = SmartCardReader.GetDeviceSelector();
DeviceInformationCollection devices =
    await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation device in devices)
{
    SmartCardReader reader =
        await SmartCardReader.FromIdAsync(device.Id);

    // For each reader, we want to find all the cards associated
    // with it.  Then we will create a SmartCardListItem for
    // each (reader, card) pair.
    IReadOnlyList<SmartCard> cards =
        await reader.FindAllCardsAsync();
}
```

Xxx xxxxxx xxxx xxxxxx xxxx xxx xx xxxxxxx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263866) xxxxxx xx xxxxxxxxxxxx x xxxxxx xx xxxxxx xxx xxxxxxxx xx xxxx xxxxxxxxx.

```cs
private void reader_CardAdded(SmartCardReader sender, CardAddedEventArgs args)
{
  // A card has been inserted into the sender SmartCardReader.
}
```

Xxx xxx xxxx xxxx xxxx xxxxxxxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn297565) xxxxxx xx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801) xx xxxxxx xxx xxxxxxx xxxx xxxxx xxxx xxx xx xxxxxx xxx xxxxxxxxx xxx xxxxxxxxxxxxx.

## Xxxxxx x xxxxxxx xxxxx xxxx


Xx xxxxxx x xxxxxxx xxxxx xxxx xxxxx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801), xxxx xxx xxxx xxxxx xxxx xx xxxxxxx x xxxxxxxx xxxx, xx xxxxx xxx, xxx x [**XxxxxXxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297642). Xxx xxxxxxxx xxxx xx xxxxxxxxx xxxxxxxxx xxxxxxxx xx xxx xxx, xxx xxxx xxx xxxx xxxxx xxxx xx xxxxxxx xx xxxxx xxx xxx xxxxxxxx xx xxxxxxxx xx xxx xxxxxxx **XxxxxXxxxXxxXxxxxx** xxxxxx xxxxxxx xxx xxxxx xxxxxx xx [**XxxxxxxXxxxxxxXxxxxXxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263830).

1.  Xxxxxx x xxx xxxxxxxx xx x [**XxxxxXxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297642)
2.  Xxxxxxxx xxx xxxxx xxx xxxxx xx xxxxxxx [**XxxxxxxxxxxxxXxxxxx.XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241392) xx xxx xxxxx xxx xxxxx xxxxxxxx xx xxx xxxxxxx xx xxxxxxxxxx xxxx.
3.  Xxxx xxxxx xxxxxx xxxxx xxxx xxx *XxxxxxxxXxxxXxxx* xxxxxx xx [**XxxxxxxXxxxxxxXxxxxXxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263830).

```cs
SmartCardPinPolicy pinPolicy = new SmartCardPinPolicy();
pinPolicy.MinLength = 6;

IBuffer adminkey = CryptographicBuffer.GenerateRandom(24);

SmartCardProvisioning provisioning = await
     SmartCardProvisioning.RequestVirtualSmartCardCreationAsync(
          "Card friendly name",
          adminkey,
          pinPolicy);
```

Xxxx [**XxxxxxxXxxxxxxXxxxxXxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263830) xxx xxxxxxxx xxx xxxxxxxxxx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801) xxxxxx, xxx xxxxxxx xxxxx xxxx xx xxxxxxxxxxx xxx xxxxx xxx xxx.

## Xxxxxx xxxxxxxxxxxxxx xxxxxxxxxx


Xx xxxxxxxxxxxx xxxx xxxxx xxxxx xx xxxxxxx xxxxx xxxxx, xxxx xxx xxxx xxxxxxx xxx xxxxxxxx xx xxxxxxxx xxxxxxxxxx xxxxxxx xxx xxxxx xxx xxxx xxxxxx xx xxx xxxx, xxx xxx xxxxx xxx xxxx xxxxxxxxxx xx xxx xxxxxxxxxxxxxx xxxxxx xx xxxxxxxxxx xxxx.

Xxx xxxxxxxxx xxxx xxxxx xxx xx xxxxxxx xxxxx xxxx xxxxxxxxxxxxxx xxx xxxxxxxx xx xxxxxxxxxxxx xx xxxxxxxx xx xxxxxxx xxxx xxxxxxx. Xx xxx xxxx xxxxxxxxx xxxxx xxx xxxxx xxx xx xxx xxxx ("xxxxxxxxx") xx xxx xxxx xx xxx xxxxx xxx xxxx xxxxxxxx xx xxx xxxxxx xx xxxxxxxxxx xxxx ("xxxxxxxx"), xxxxxxxxxxxxxx xx xxxxxxxxxx.

```cs
static class ChallengeResponseAlgorithm
{
    public static IBuffer CalculateResponse(IBuffer challenge, IBuffer adminkey)
    {
        if (challenge == null)
            throw new ArgumentNullException("challenge");
        if (adminkey == null)
            throw new ArgumentNullException("adminkey");

        SymmetricKeyAlgorithmProvider objAlg = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.TripleDesCbc);
        var symmetricKey = objAlg.CreateSymmetricKey(adminkey);
        var buffEncrypted = CryptographicEngine.Encrypt(symmetricKey, challenge, null);
        return buffEncrypted;
    }
}
```

Xxx xxxx xxx xxxx xxxx xxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxxx xxxxx xxx xx xxxxxx xxx xx xxxxxxxx xx xxxxxxxxxxxxxx xxxxxx, xxx xxx xx xxxxx xxxxxxx xx xxxxx xxxx xxx xxxxxxx xxxxx xxxx xxxxxxxxxxx.

## Xxxxxx xxxxx xxxx xx xxxxxxx xxxxx xxxx xxxxxxxxxxxxxx xxxxxxxx


Xxx xxxx xx xxxx xxx xxxxx xxx xxxxxxxxxxxxxx xxxxxxxxxx xxxxxxx, xx xxx xxxxxxxxxxx xxxx xxx xxxxxx xx xxxxxx xxx xxxxx xxxx, xx xxxxxxxxxxxxx, xxxxxx x xxxxxxx xxxxx xxxx xxx xxxxxxxxxxxxxx.

1.  Xx xxxxx xxx xxxxxxxxx, xxxx [**XxxXxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263811) xxxx xxx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801) xxxxxx xxxxxxxxxx xxxx xxx xxxxx xxxx. Xxxx xxxx xxxxxxxx xx xxxxxxxx xx [**XxxxxXxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297570), xxxxx xxxxxxxx xxx xxxx'x [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297578) xxxxx.

2.  Xxxx, xxxx xxx xxxx'x xxxxxxxxx xxxxx xxx xxx xxxxx xxx xxxxxxxx xx xxx xxxxxxx xx xxxxxxxxxx xxxx xx xxx **XxxxxxxxxXxxxxxxxXxxxxxxxx** xxxx xx xxxxxxx xx xxx xxxxxxxx xxxxxxx.

3.  [
            **XxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297627) xxxx xxxxxx **xxxx** xx xxxxxxxxxxxxxx xx xxxxxxxxxx.

```cs
bool verifyResult = false;
SmartCard card = await rootPage.GetSmartCard();
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

using (SmartCardChallengeContext context =
       await provisioning.GetChallengeContextAsync())
{
    IBuffer response = ChallengeResponseAlgorithm.CalculateResponse(
        context.Challenge,
        rootPage.AdminKey);

    verifyResult = await context.VerifyResponseAsync(response);
}
```

## Xxxxxx xx xxxxx x xxxx XXX


Xx xxxxxx xxx XXX xxxxxxxxxx xxxx x xxxxx xxxx:

1.  Xxxxxx xxx xxxx xxx xxxxxxxx xxx xxxxxxxxxx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801) xxxxxx.
2.  Xxxx [**XxxxxxxXxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263823) xx xxxxxxx x XX xx xxx xxxx xx xxxxxxxx xxxx xxxxxxxxx.
3.  Xx xxx XXX xxx xxxxxxxxxxxx xxxxxxx xxx xxxx xxxx xxxxxx **xxxx**.

```cs
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

bool result = await provisioning.RequestPinChangeAsync();
```

Xx xxxxxxx x XXX xxxxx:

1.  Xxxx [**XxxxxxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263825) xx xxxxxxxx xxx xxxxxxxxx. Xxxx xxxx xxxxxxxx x [**XxxxxXxxxXxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297701) xxxxxx xxxx xxxxxxxxxx xxx xxxxx xxxx xxx xxx xxx xxxxx xxxxxxx.
2.  [
            **XxxxxXxxxXxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297701) xxxxxxxx xxxxxxxxxxx xxxx xxx **XxxxxxxxxXxxxxxxxXxxxxxxxx**, xxxxxxx xx x [**XxxxxXxxxXxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn297693) xxxx, xxxx xx xxxxxxx xxx xxxx'x xxxxxxxxx xxxxx xxx xxx xxxxx xxx xxxxxxxx xx xxx xxxxxxx xx xxxxxxxxxx xxxx xx xxxxxxxxxxxx xxx xxxxxxx.

3.  Xx xxx xxxxxxxxx xx xxxxxxxxxx, xxx [**XxxxxxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263825) xxxx xx xxxxxxxxx; xxxxxxxxx **xxxx** xx xxx XXX xxx xxxxxxxxxxxx xxxxx.

```cs
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

bool result = await provisioning.RequestPinResetAsync(
    (pinResetSender, request) =>
    {
        SmartCardPinResetDeferral deferral =
            request.GetDeferral();

        try
        {
            IBuffer response =
                ChallengeResponseAlgorithm.CalculateResponse(
                    request.Challenge,
                    rootPage.AdminKey);
            request.SetResponse(response);
        }
        finally
        {
            deferral.Complete();
        }
    });
}
```

## Xxxxxx x xxxxx xxxx xx xxxxxxx xxxxx xxxx


Xxxx x xxxxxxxx xxxxx xxxx xx xxxxxxx x [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263875) xxxxx xxxx xxxx xxxx xxx xxxx xx xxxxxxx.

Xxxxxxxxx xxx xxxxxx xx xxxx xxxxx xxxx xxx xxxx xxxxxx xxxx xxx xxxxxx xxxx xxxxxxx xxxx xxx'x xxxxxxxx xx xxxx xx xxxxxx xxxxxxx xx xx xxxxx xxxxxxx. Xxxx xxxxxxxx xxx xx xxxxxxxxx xx xxxxxx xx xxxxxxxxx xxxxxxxxxxxx xx xxx xxxx xxxx xxx xxxx xxx xxxxxxx.

```cs
reader = card.Reader;
reader.CardRemoved += HandleCardRemoved;
```

Xxx xxxxxxx xx x xxxxxxx xxxxx xxxx xx xxxxxxx xxxxxxxxxxxxxxxx xx xxxxx xxxxxxxxxx xxx xxxx xxx xxxx xxxxxxx [**XxxxxxxXxxxxxxXxxxxXxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263850) xxxx xxx [**XxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263801) xxxxxxxx xxxxxx.

```cs
bool result = await SmartCardProvisioning
    .RequestVirtualSmartCardDeletionAsync(card);
```

 

 




<!--HONumber=Mar16_HO1-->
