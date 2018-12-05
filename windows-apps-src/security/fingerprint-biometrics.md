---
title: 指紋生体認証
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。
ms.assetid: 55483729-5F8A-401A-8072-3CD611DDFED2
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 973091926ddff312b20002f7b535d34a3b7d2bc4
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8730171"
---
# <a name="fingerprint-biometrics"></a>指紋生体認証




この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。 特定の操作に対してユーザーの同意を得る必要がある場合は、指紋認証の要求を含めると、アプリのセキュリティを高めることができます。 たとえば、アプリ内購入を承認する前や制限されたリソースにアクセスする前に指紋認証を要求できます。 指紋認証は、[**Windows.Security.Credentials.UI**](https://msdn.microsoft.com/library/windows/apps/hh701356) 名前空間の [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って管理されます。

## <a name="check-the-device-for-a-fingerprint-reader"></a>デバイスに指紋リーダーがあるかどうかをチェックする


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

## <a name="request-consent-and-return-results"></a>同意を求めて、結果を返す


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