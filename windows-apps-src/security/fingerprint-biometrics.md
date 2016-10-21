---
title: "指紋生体認証"
description: "この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。"
ms.assetid: 55483729-5F8A-401A-8072-3CD611DDFED2
author: awkoren
translationtype: Human Translation
ms.sourcegitcommit: 36bc5dcbefa6b288bf39aea3df42f1031f0b43df
ms.openlocfilehash: d2dfbc6c69e8ee97a01bbf0d7ae82488ca62e3cb

---

# 指紋生体認証


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。 特定の操作に対してユーザーの同意を得る必要がある場合は、指紋認証の要求を含めると、アプリのセキュリティを高めることができます。 たとえば、アプリ内購入を承認する前や制限されたリソースにアクセスする前に指紋認証を要求できます。 指紋認証は、[**Windows.Security.Credentials.UI**](https://msdn.microsoft.com/library/windows/apps/hh701356) 名前空間の [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って管理されます。

## デバイスに指紋リーダーがあるかどうかをチェックする


デバイスに指紋リーダーがあるかどうかを調べるには、[**UserConsentVerifier.CheckAvailabilityAsync**](https://msdn.microsoft.com/library/windows/apps/dn279138) メソッドを呼び出します。 デバイスで指紋認証がサポートされている場合も、アプリでは、指紋認証を有効または無効にする設定オプションをユーザーに提供する必要があります。

```cs
public async System.Threading.Tasks.Task<string> CheckFingerprintAvailability()
{
    string returnMessage = "";

    try
    {
        // Check the availability of fingerprint authentication.
        var ucvAvailability = await Windows.Security.Credentials.UI.UserConsentVerifier.CheckAvailabilityAsync();

        switch (ucvAvailability)
        {
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.Available:
                returnMessage = "Fingerprint verification is available.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DeviceBusy:
                returnMessage = "Biometric device is busy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DeviceNotPresent:
                returnMessage = "No biometric device found.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DisabledByPolicy:
                returnMessage = "Biometric verification is disabled by policy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.NotConfiguredForUser:
                returnMessage = "The user has no fingerprints registered. Please add a fingerprint to the " +
                                "fingerprint database and try again.";
                break;
            default:
                returnMessage = "Fingerprints verification is currently unavailable.";
                break;
        }
    }
    catch (Exception ex)
    {
        returnMessage = "Fingerprint authentication availability check failed: " + ex.ToString();
    }

    return returnMessage;
}
```

## 同意を求めて、結果を返す


指紋のスキャンによってユーザーの同意を求めるには、[**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139) メソッドを呼び出します。 指紋認証を行うには、あらかじめユーザーが指紋データベースに指紋の "署名" を追加している必要があります。

[**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139) を呼び出すと、ユーザーに指紋のスキャンを求めるモーダル ダイアログが表示されます。 **UserConsentVerifier.RequestVerificationAsync** メソッドには、次の図に示すように、モーダル ダイアログの一部として表示されるメッセージを指定できます。

```cs
private async System.Threading.Tasks.Task<string> RequestConsent(string userMessage)
{
    string returnMessage;

    if (String.IsNullOrEmpty(userMessage))
    {
        userMessage = "Please provide fingerprint verification.";
    }

    try
    {
        // Request the logged on user's consent via fingerprint swipe.
        var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(userMessage);

        switch (consentResult)
        {
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.Verified:
                returnMessage = "Fingerprint verified.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceBusy:
                returnMessage = "Biometric device is busy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceNotPresent:
                returnMessage = "No biometric device found.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DisabledByPolicy:
                returnMessage = "Biometric verification is disabled by policy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.NotConfiguredForUser:
                returnMessage = "The user has no fingerprints registered. Please add a fingerprint to the " +
                                "fingerprint database and try again.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.RetriesExhausted:
                returnMessage = "There have been too many failed attempts. Fingerprint authentication canceled.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.Canceled:
                returnMessage = "Fingerprint authentication canceled.";
                break;
            default:
                returnMessage = "Fingerprint authentication is currently unavailable.";
                break;
        }
    }
    catch (Exception ex)
    {
        returnMessage = "Fingerprint authentication failed: " + ex.ToString();
    }

    return returnMessage;
}
```


<!--HONumber=Aug16_HO3-->


