---
title: 指紋生体認証
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。
ms.assetid: 55483729-5F8A-401A-8072-3CD611DDFED2
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 973091926ddff312b20002f7b535d34a3b7d2bc4
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8694495"
---
# <a name="fingerprint-biometrics"></a><span data-ttu-id="f8b46-104">指紋生体認証</span><span class="sxs-lookup"><span data-stu-id="f8b46-104">Fingerprint biometrics</span></span>




<span data-ttu-id="f8b46-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに指紋生体認証を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f8b46-105">This article explains how to add fingerprint biometrics to your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="f8b46-106">特定の操作に対してユーザーの同意を得る必要がある場合は、指紋認証の要求を含めると、アプリのセキュリティを高めることができます。</span><span class="sxs-lookup"><span data-stu-id="f8b46-106">Including a request for fingerprint authentication when the user must consent to a particular action increases the security of your app.</span></span> <span data-ttu-id="f8b46-107">たとえば、アプリ内購入を承認する前や制限されたリソースにアクセスする前に指紋認証を要求できます。</span><span class="sxs-lookup"><span data-stu-id="f8b46-107">For example, you could require fingerprint authentication before authorizing an in-app purchase, or access to restricted resources.</span></span> <span data-ttu-id="f8b46-108">指紋認証は、[**Windows.Security.Credentials.UI**](https://msdn.microsoft.com/library/windows/apps/hh701356) 名前空間の [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って管理されます。</span><span class="sxs-lookup"><span data-stu-id="f8b46-108">Fingerprint authentication is managed using the [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) class in the [**Windows.Security.Credentials.UI**](https://msdn.microsoft.com/library/windows/apps/hh701356) namespace.</span></span>

## <a name="check-the-device-for-a-fingerprint-reader"></a><span data-ttu-id="f8b46-109">デバイスに指紋リーダーがあるかどうかをチェックする</span><span class="sxs-lookup"><span data-stu-id="f8b46-109">Check the device for a fingerprint reader</span></span>


<span data-ttu-id="f8b46-110">デバイスに指紋リーダーがあるかどうかを調べるには、[**UserConsentVerifier.CheckAvailabilityAsync**](https://msdn.microsoft.com/library/windows/apps/dn279138) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f8b46-110">To find out whether the device has a fingerprint reader, call [**UserConsentVerifier.CheckAvailabilityAsync**](https://msdn.microsoft.com/library/windows/apps/dn279138).</span></span> <span data-ttu-id="f8b46-111">デバイスで指紋認証がサポートされている場合も、アプリでは、指紋認証を有効または無効にする設定オプションをユーザーに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8b46-111">Even if a device supports fingerprint authentication, your app should still provide users with an option in Settings to enable or disable it.</span></span>

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

## <a name="request-consent-and-return-results"></a><span data-ttu-id="f8b46-112">同意を求めて、結果を返す</span><span class="sxs-lookup"><span data-stu-id="f8b46-112">Request consent and return results</span></span>


<span data-ttu-id="f8b46-113">指紋のスキャンによってユーザーの同意を求めるには、[**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f8b46-113">To request user consent from a fingerprint scan, call the [**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139) method.</span></span> <span data-ttu-id="f8b46-114">指紋認証を行うには、あらかじめユーザーが指紋データベースに指紋の "署名" を追加している必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8b46-114">For fingerprint authentication to work, the user must have previously added a fingerprint "signature" to the fingerprint database.</span></span>

<span data-ttu-id="f8b46-115">[**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139) を呼び出すと、ユーザーに指紋のスキャンを求めるモーダル ダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8b46-115">When you call the [**UserConsentVerifier.RequestVerificationAsync**](https://msdn.microsoft.com/library/windows/apps/dn279139), the user is presented with a modal dialog requesting a fingerprint scan.</span></span> <span data-ttu-id="f8b46-116">**UserConsentVerifier.RequestVerificationAsync** メソッドには、次の図に示すように、モーダル ダイアログの一部として表示されるメッセージを指定できます。</span><span class="sxs-lookup"><span data-stu-id="f8b46-116">You can supply a message to the **UserConsentVerifier.RequestVerificationAsync** method that will be displayed to the user as part of the modal dialog, as shown in the following image.</span></span>

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