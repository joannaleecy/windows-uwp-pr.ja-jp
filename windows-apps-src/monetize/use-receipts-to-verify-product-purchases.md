---
ms.assetid: E322DFFE-8EEC-499D-87BC-EDA5CFC27551
description: 製品購入が成功した Microsoft Store の各トランザクションでは、必要に応じてトランザクションの受領通知を返すことができます。
title: 受領通知を使った製品購入の確認
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, アプリ内購入, IAP, 受領通知, Windows.ApplicationModel.Store
ms.localizationpriority: medium
ms.openlocfilehash: 6cae88e57a61e6d4e982f1eac7e65582861ef5d2
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58335010"
---
# <a name="use-receipts-to-verify-product-purchases"></a><span data-ttu-id="912bd-104">受領通知を使った製品購入の確認</span><span class="sxs-lookup"><span data-stu-id="912bd-104">Use receipts to verify product purchases</span></span>

<span data-ttu-id="912bd-105">製品購入が成功した Microsoft Store の各トランザクションでは、必要に応じてトランザクションの受領通知を返すことができます。</span><span class="sxs-lookup"><span data-stu-id="912bd-105">Each Microsoft Store transaction that results in a successful product purchase can optionally return a transaction receipt.</span></span> <span data-ttu-id="912bd-106">この通知は、ユーザーに対する製品と金銭的コストの一覧を掲載します。</span><span class="sxs-lookup"><span data-stu-id="912bd-106">This receipt provides information about the listed product and monetary cost to the customer.</span></span>

<span data-ttu-id="912bd-107">この情報は、ユーザーがアプリを購入したことや、Microsoft Store からアドオン (アプリ内製品または IAP とも呼ばれます) の購入が行われたことをアプリで確認する必要がある場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="912bd-107">Having access to this information supports scenarios where your app needs to verify that a user purchased your app, or has made add-on (also called in-app product or IAP) purchases from the Microsoft Store.</span></span> <span data-ttu-id="912bd-108">たとえば、ダウンロードしたコンテンツを提供するゲームを想像してください。</span><span class="sxs-lookup"><span data-stu-id="912bd-108">For example, imagine a game that offers downloaded content.</span></span> <span data-ttu-id="912bd-109">ゲーム コンテンツを購入したユーザーが別のデバイスでゲームをする場合、そのユーザーが既にコンテンツを所有していることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="912bd-109">If the user who purchased the game content wants to play it on a different device, you need to verify that the user already owns the content.</span></span> <span data-ttu-id="912bd-110">以下にその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="912bd-110">Here's how.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="912bd-111">この記事では、[Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間のメンバーを使って、アプリ内での購入の受領通知を取得および検証する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="912bd-111">This article shows how to use members of the [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) namespace to get and validate a receipt for an in-app purchase.</span></span> <span data-ttu-id="912bd-112">アプリ内購入に [Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.Services.Store) 名前空間 (Windows 10 バージョン 1607 で導入され、Visual Studio で **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットにするプロジェクトでも利用できる) を使用している場合、この名前空間では、アプリ内購入の購入受領通知を取得するための API が提供されません。</span><span class="sxs-lookup"><span data-stu-id="912bd-112">If you are using the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.Services.Store) namespace for in-app purchases (introduced in Windows 10, version 1607, and available to projects that target **Windows 10 Anniversary Edition (10.0; Build 14393)** or a later release in Visual Studio), this namespace does not provide an API for getting purchase receipts for in-app purchases.</span></span> <span data-ttu-id="912bd-113">ただし、Microsoft Store コレクション API の REST メソッドを使うと、購入トランザクションのデータを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="912bd-113">However, you can use a REST method in the Microsoft Store collection API to get data for a purchase transaction.</span></span> <span data-ttu-id="912bd-114">詳しくは、「[アプリ内購入の受領通知](in-app-purchases-and-trials.md#receipts)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="912bd-114">For more information, see [Receipts for in-app purchases](in-app-purchases-and-trials.md#receipts).</span></span>

## <a name="requesting-a-receipt"></a><span data-ttu-id="912bd-115">通知の要求</span><span class="sxs-lookup"><span data-stu-id="912bd-115">Requesting a receipt</span></span>


<span data-ttu-id="912bd-116">**Windows.ApplicationModel.Store** 名前空間は、受領通知を取得する複数の方法をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="912bd-116">The **Windows.ApplicationModel.Store** namespace supports several ways to get a receipt:</span></span>

* <span data-ttu-id="912bd-117">[CurrentApp.RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestapppurchaseasync)か [CurrentApp.RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync) (またはこのメソッドの他のオーバーロードのいずれか) を使って購入すると、戻り値に受領通知が含まれます。</span><span class="sxs-lookup"><span data-stu-id="912bd-117">When you make a purchase by using [CurrentApp.RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestapppurchaseasync) or [CurrentApp.RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync) (or one of the other overloads of this method), the return value contains the receipt.</span></span>
* <span data-ttu-id="912bd-118">[CurrentApp.GetAppReceiptAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getappreceiptasync) メソッドを呼び出して、アプリおよびアプリ内のアドオンに関する現在の受領通知を取得できます。</span><span class="sxs-lookup"><span data-stu-id="912bd-118">You can call the [CurrentApp.GetAppReceiptAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getappreceiptasync) method to retrieve the current receipt info for your app and any add-ons in your app.</span></span>

<span data-ttu-id="912bd-119">アプリの通知は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="912bd-119">An app receipt looks something like this.</span></span>

> [!NOTE]
> <span data-ttu-id="912bd-120">次の例では、書式を設定して XML を読みやすくしています。</span><span class="sxs-lookup"><span data-stu-id="912bd-120">This example is formatted to help make the XML readable.</span></span> <span data-ttu-id="912bd-121">実際のアプリの通知では、要素間に空白は含まれません。</span><span class="sxs-lookup"><span data-stu-id="912bd-121">Real app receipts do not include whitespace between elements.</span></span>

> [!div class="tabbedCodeSnippets"]
```xml
<Receipt Version="1.0" ReceiptDate="2012-08-30T23:10:05Z" CertificateId="b809e47cd0110a4db043b3f73e83acd917fe1336" ReceiptDeviceId="4e362949-acc3-fe3a-e71b-89893eb4f528">
    <AppReceipt Id="8ffa256d-eca8-712a-7cf8-cbf5522df24b" AppId="55428GreenlakeApps.CurrentAppSimulatorEventTest_z7q3q7z11crfr" PurchaseDate="2012-06-04T23:07:24Z" LicenseType="Full" />
    <ProductReceipt Id="6bbf4366-6fb2-8be8-7947-92fd5f683530" ProductId="Product1" PurchaseDate="2012-08-30T23:08:52Z" ExpirationDate="2012-09-02T23:08:49Z" ProductType="Durable" AppId="55428GreenlakeApps.CurrentAppSimulatorEventTest_z7q3q7z11crfr" />
    <Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
        <SignedInfo>
            <CanonicalizationMethod Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#" />
            <SignatureMethod Algorithm="http://www.w3.org/2001/04/xmldsig-more#rsa-sha256" />
            <Reference URI="">
                <Transforms>
                    <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature" />
                </Transforms>
                <DigestMethod Algorithm="http://www.w3.org/2001/04/xmlenc#sha256" />
                <DigestValue>cdiU06eD8X/w1aGCHeaGCG9w/kWZ8I099rw4mmPpvdU=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>SjRIxS/2r2P6ZdgaR9bwUSa6ZItYYFpKLJZrnAa3zkMylbiWjh9oZGGng2p6/gtBHC2dSTZlLbqnysJjl7mQp/A3wKaIkzjyRXv3kxoVaSV0pkqiPt04cIfFTP0JZkE5QD/vYxiWjeyGp1dThEM2RV811sRWvmEs/hHhVxb32e8xCLtpALYx3a9lW51zRJJN0eNdPAvNoiCJlnogAoTToUQLHs72I1dECnSbeNPXiG7klpy5boKKMCZfnVXXkneWvVFtAA1h2sB7ll40LEHO4oYN6VzD+uKd76QOgGmsu9iGVyRvvmMtahvtL1/pxoxsTRedhKq6zrzCfT8qfh3C1w==</SignatureValue>
    </Signature>
</Receipt>
```

<span data-ttu-id="912bd-122">製品の通知は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="912bd-122">A product receipt looks like this.</span></span>

> [!NOTE]
> <span data-ttu-id="912bd-123">次の例では、書式を設定して XML を読みやすくしています。</span><span class="sxs-lookup"><span data-stu-id="912bd-123">This example is formatted to help make the XML readable.</span></span> <span data-ttu-id="912bd-124">実際の製品の通知では、要素間に空白は含まれません。</span><span class="sxs-lookup"><span data-stu-id="912bd-124">Real product receipts do not include whitespace between elements.</span></span>

> [!div class="tabbedCodeSnippets"]
```xml
<Receipt Version="1.0" ReceiptDate="2012-08-30T23:08:52Z" CertificateId="b809e47cd0110a4db043b3f73e83acd917fe1336" ReceiptDeviceId="4e362949-acc3-fe3a-e71b-89893eb4f528">
    <ProductReceipt Id="6bbf4366-6fb2-8be8-7947-92fd5f683530" ProductId="Product1" PurchaseDate="2012-08-30T23:08:52Z" ExpirationDate="2012-09-02T23:08:49Z" ProductType="Durable" AppId="55428GreenlakeApps.CurrentAppSimulatorEventTest_z7q3q7z11crfr" />
    <Signature xmlns="http://www.w3.org/2000/09/xmldsig#">
        <SignedInfo>
            <CanonicalizationMethod Algorithm="http://www.w3.org/2001/10/xml-exc-c14n#" />
            <SignatureMethod Algorithm="http://www.w3.org/2001/04/xmldsig-more#rsa-sha256" />
            <Reference URI="">
                <Transforms>
                    <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature" />
                </Transforms>
                <DigestMethod Algorithm="http://www.w3.org/2001/04/xmlenc#sha256" />
                <DigestValue>Uvi8jkTYd3HtpMmAMpOm94fLeqmcQ2KCrV1XmSuY1xI=</DigestValue>
            </Reference>
        </SignedInfo>
        <SignatureValue>TT5fDET1X9nBk9/yKEJAjVASKjall3gw8u9N5Uizx4/Le9RtJtv+E9XSMjrOXK/TDicidIPLBjTbcZylYZdGPkMvAIc3/1mdLMZYJc+EXG9IsE9L74LmJ0OqGH5WjGK/UexAXxVBWDtBbDI2JLOaBevYsyy+4hLOcTXDSUA4tXwPa2Bi+BRoUTdYE2mFW7ytOJNEs3jTiHrCK6JRvTyU9lGkNDMNx9loIr+mRks+BSf70KxPtE9XCpCvXyWa/Q1JaIyZI7llCH45Dn4SKFn6L/JBw8G8xSTrZ3sBYBKOnUDbSCfc8ucQX97EyivSPURvTyImmjpsXDm2LBaEgAMADg==</SignatureValue>
    </Signature>
</Receipt>
```

<span data-ttu-id="912bd-125">これらの通知の例のいずれかを使って検証コードをテストできます。</span><span class="sxs-lookup"><span data-stu-id="912bd-125">You can use either of these receipt examples to test your validation code.</span></span> <span data-ttu-id="912bd-126">受領通知の内容について詳しくは、「[受領通知の要素と属性の説明](#receipt-descriptions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="912bd-126">For more information about the contents of the receipt, see the [element and attribute descriptions](#receipt-descriptions).</span></span>

## <a name="validating-a-receipt"></a><span data-ttu-id="912bd-127">通知の検証</span><span class="sxs-lookup"><span data-stu-id="912bd-127">Validating a receipt</span></span>

<span data-ttu-id="912bd-128">受領通知の真正を検証するには、バックエンド システム (Web サービスやそれに類するサービス) でパブリック証明書を使って受領通知の署名を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="912bd-128">To validate a receipt's authenticity, you need your back-end system (a web service or something similar) to check the receipt's signature using the public certificate.</span></span> <span data-ttu-id="912bd-129">この証明書を取得するには、URL ```https://go.microsoft.com/fwlink/p/?linkid=246509&cid=CertificateId``` (```CertificateId``` は受領通知の **CertificateId** の値) を使用します。</span><span class="sxs-lookup"><span data-stu-id="912bd-129">To get this certificate, use the URL ```https://go.microsoft.com/fwlink/p/?linkid=246509&cid=CertificateId```, where ```CertificateId``` is the **CertificateId** value in the receipt.</span></span>

<span data-ttu-id="912bd-130">検証プロセスの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="912bd-130">Here's an example of that validation process.</span></span> <span data-ttu-id="912bd-131">このコードは、**System.Security** アセンブリへの参照を含む .NET Framework コンソール アプリケーションで実行されます。</span><span class="sxs-lookup"><span data-stu-id="912bd-131">This code runs in a .NET Framework console application that includes a reference to the **System.Security** assembly.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-csharp[ReceiptVerificationSample](./code/ReceiptVerificationSample/cs/Program.cs#ReceiptVerificationSample)]

<span id="receipt-descriptions" />

## <a name="element-and-attribute-descriptions-for-a-receipt"></a><span data-ttu-id="912bd-132">受領通知の要素と属性の説明</span><span class="sxs-lookup"><span data-stu-id="912bd-132">Element and attribute descriptions for a receipt</span></span>

<span data-ttu-id="912bd-133">このセクションでは、受領通知内の属性と要素について説明します。</span><span class="sxs-lookup"><span data-stu-id="912bd-133">This section describes the elements and attributes in a receipt.</span></span>

### <a name="receipt-element"></a><span data-ttu-id="912bd-134">受領通知の要素</span><span class="sxs-lookup"><span data-stu-id="912bd-134">Receipt element</span></span>

<span data-ttu-id="912bd-135">このファイルのルート要素は、**Receipt** 要素です。これには、アプリとアプリ内での購入に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-135">The root element of this file is the **Receipt** element, which contains information about app and in-app purchases.</span></span> <span data-ttu-id="912bd-136">この要素には、次の子要素が含まれます。</span><span class="sxs-lookup"><span data-stu-id="912bd-136">This element contains the following child elements.</span></span>

|  <span data-ttu-id="912bd-137">要素</span><span class="sxs-lookup"><span data-stu-id="912bd-137">Element</span></span>  |  <span data-ttu-id="912bd-138">必須</span><span class="sxs-lookup"><span data-stu-id="912bd-138">Required</span></span>  |  <span data-ttu-id="912bd-139">Quantity</span><span class="sxs-lookup"><span data-stu-id="912bd-139">Quantity</span></span>  |  <span data-ttu-id="912bd-140">説明</span><span class="sxs-lookup"><span data-stu-id="912bd-140">Description</span></span>   |
|-------------|------------|--------|--------|
|  [<span data-ttu-id="912bd-141">AppReceipt</span><span class="sxs-lookup"><span data-stu-id="912bd-141">AppReceipt</span></span>](#appreceipt)  |    <span data-ttu-id="912bd-142">X</span><span class="sxs-lookup"><span data-stu-id="912bd-142">No</span></span>        |  <span data-ttu-id="912bd-143">0 または 1</span><span class="sxs-lookup"><span data-stu-id="912bd-143">0 or 1</span></span>  |  <span data-ttu-id="912bd-144">現在のアプリの購入情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-144">Contains purchase information for the current app.</span></span>            |
|  [<span data-ttu-id="912bd-145">ProductReceipt</span><span class="sxs-lookup"><span data-stu-id="912bd-145">ProductReceipt</span></span>](#productreceipt)  |     <span data-ttu-id="912bd-146">X</span><span class="sxs-lookup"><span data-stu-id="912bd-146">No</span></span>       |  <span data-ttu-id="912bd-147">0 以上</span><span class="sxs-lookup"><span data-stu-id="912bd-147">0 or more</span></span>    |   <span data-ttu-id="912bd-148">現在のアプリのアプリ内での購入に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-148">Contains information about an in-app purchase for the current app.</span></span>     |
|  <span data-ttu-id="912bd-149">署名</span><span class="sxs-lookup"><span data-stu-id="912bd-149">Signature</span></span>  |      <span data-ttu-id="912bd-150">〇</span><span class="sxs-lookup"><span data-stu-id="912bd-150">Yes</span></span>      |  <span data-ttu-id="912bd-151">1</span><span class="sxs-lookup"><span data-stu-id="912bd-151">1</span></span>   |   <span data-ttu-id="912bd-152">この要素は、標準の [XML-DSIG コンストラクト](https://go.microsoft.com/fwlink/p/?linkid=251093)です。</span><span class="sxs-lookup"><span data-stu-id="912bd-152">This element is a standard [XML-DSIG construct](https://go.microsoft.com/fwlink/p/?linkid=251093).</span></span> <span data-ttu-id="912bd-153">これには、受領通知の検証に使用する **SignatureValue** 要素に加え、**SignedInfo** 要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-153">It contains a **SignatureValue** element, which contains the signature you can use to validate the receipt, and a **SignedInfo** element.</span></span>      |

<span data-ttu-id="912bd-154">**Receipt** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="912bd-154">**Receipt** has the following attributes.</span></span>

|  <span data-ttu-id="912bd-155">属性</span><span class="sxs-lookup"><span data-stu-id="912bd-155">Attribute</span></span>  |  <span data-ttu-id="912bd-156">説明</span><span class="sxs-lookup"><span data-stu-id="912bd-156">Description</span></span>   |
|-------------|-------------------|
|  <span data-ttu-id="912bd-157">**バージョン**</span><span class="sxs-lookup"><span data-stu-id="912bd-157">**Version**</span></span>  |    <span data-ttu-id="912bd-158">受領通知のバージョン番号</span><span class="sxs-lookup"><span data-stu-id="912bd-158">The version number of the receipt.</span></span>            |
|  <span data-ttu-id="912bd-159">**CertificateId**</span><span class="sxs-lookup"><span data-stu-id="912bd-159">**CertificateId**</span></span>  |     <span data-ttu-id="912bd-160">受領通知の署名に使用された証明サムプリント</span><span class="sxs-lookup"><span data-stu-id="912bd-160">The certificate thumbprint used to sign the receipt.</span></span>          |
|  <span data-ttu-id="912bd-161">**ReceiptDate**</span><span class="sxs-lookup"><span data-stu-id="912bd-161">**ReceiptDate**</span></span>  |    <span data-ttu-id="912bd-162">受領通知が署名され、ダウンロードされた日付です。</span><span class="sxs-lookup"><span data-stu-id="912bd-162">Date the receipt was signed and downloaded.</span></span>           |  
|  <span data-ttu-id="912bd-163">**ReceiptDeviceId**</span><span class="sxs-lookup"><span data-stu-id="912bd-163">**ReceiptDeviceId**</span></span>  |   <span data-ttu-id="912bd-164">この受領通知の要求に使用するデバイスを識別します。</span><span class="sxs-lookup"><span data-stu-id="912bd-164">Identifies the device used to request this receipt.</span></span>         |  |

<span id="appreceipt" />

### <a name="appreceipt-element"></a><span data-ttu-id="912bd-165">AppReceipt 要素</span><span class="sxs-lookup"><span data-stu-id="912bd-165">AppReceipt element</span></span>

<span data-ttu-id="912bd-166">この要素には、現在のアプリの購入情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-166">This element contains purchase information for the current app.</span></span>

<span data-ttu-id="912bd-167">**AppReceipt** には次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="912bd-167">**AppReceipt** has the following attributes.</span></span>

|  <span data-ttu-id="912bd-168">属性</span><span class="sxs-lookup"><span data-stu-id="912bd-168">Attribute</span></span>  |  <span data-ttu-id="912bd-169">説明</span><span class="sxs-lookup"><span data-stu-id="912bd-169">Description</span></span>   |
|-------------|-------------------|
|  <span data-ttu-id="912bd-170">**Id**</span><span class="sxs-lookup"><span data-stu-id="912bd-170">**Id**</span></span>  |    <span data-ttu-id="912bd-171">購入を識別します。</span><span class="sxs-lookup"><span data-stu-id="912bd-171">Identifies the purchase.</span></span>           |
|  <span data-ttu-id="912bd-172">**AppId**</span><span class="sxs-lookup"><span data-stu-id="912bd-172">**AppId**</span></span>  |     <span data-ttu-id="912bd-173">OS がアプリに対して使用するパッケージ ファミリ名です。</span><span class="sxs-lookup"><span data-stu-id="912bd-173">The Package Family Name value that the OS uses for the app.</span></span>           |
|  <span data-ttu-id="912bd-174">**LicenseType**</span><span class="sxs-lookup"><span data-stu-id="912bd-174">**LicenseType**</span></span>  |    <span data-ttu-id="912bd-175">ユーザーがアプリの通常版を購入した場合は、**Full** です。</span><span class="sxs-lookup"><span data-stu-id="912bd-175">**Full**, if the user purchased the full version of the app.</span></span> <span data-ttu-id="912bd-176">ユーザーがアプリの試用版をダウンロードした場合は、**Trial** です。</span><span class="sxs-lookup"><span data-stu-id="912bd-176">**Trial**, if the user downloaded a trial version of the app.</span></span>           |  
|  <span data-ttu-id="912bd-177">**PurchaseDate**</span><span class="sxs-lookup"><span data-stu-id="912bd-177">**PurchaseDate**</span></span>  |    <span data-ttu-id="912bd-178">アプリが取得された日付です。</span><span class="sxs-lookup"><span data-stu-id="912bd-178">Date when the app was acquired.</span></span>          |  |

<span id="productreceipt" />

### <a name="productreceipt-element"></a><span data-ttu-id="912bd-179">ProductReceipt 要素</span><span class="sxs-lookup"><span data-stu-id="912bd-179">ProductReceipt element</span></span>

<span data-ttu-id="912bd-180">この要素には、現在のアプリのアプリ内での購入に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="912bd-180">This element contains information about an in-app purchase for the current app.</span></span>

<span data-ttu-id="912bd-181">**ProductReceipt** は次の属性があります。</span><span class="sxs-lookup"><span data-stu-id="912bd-181">**ProductReceipt** has the following attributes.</span></span>

|  <span data-ttu-id="912bd-182">属性</span><span class="sxs-lookup"><span data-stu-id="912bd-182">Attribute</span></span>  |  <span data-ttu-id="912bd-183">説明</span><span class="sxs-lookup"><span data-stu-id="912bd-183">Description</span></span>   |
|-------------|-------------------|
|  <span data-ttu-id="912bd-184">**Id**</span><span class="sxs-lookup"><span data-stu-id="912bd-184">**Id**</span></span>  |    <span data-ttu-id="912bd-185">購入を識別します。</span><span class="sxs-lookup"><span data-stu-id="912bd-185">Identifies the purchase.</span></span>           |
|  <span data-ttu-id="912bd-186">**AppId**</span><span class="sxs-lookup"><span data-stu-id="912bd-186">**AppId**</span></span>  |     <span data-ttu-id="912bd-187">ユーザーが購入に使ったアプリを識別します。</span><span class="sxs-lookup"><span data-stu-id="912bd-187">Identifies the app through which the user made the purchase.</span></span>           |
|  <span data-ttu-id="912bd-188">**productId**</span><span class="sxs-lookup"><span data-stu-id="912bd-188">**ProductId**</span></span>  |     <span data-ttu-id="912bd-189">購入した製品を識別します。</span><span class="sxs-lookup"><span data-stu-id="912bd-189">Identifies the product purchased.</span></span>           |
|  <span data-ttu-id="912bd-190">**ProductType**</span><span class="sxs-lookup"><span data-stu-id="912bd-190">**ProductType**</span></span>  |    <span data-ttu-id="912bd-191">製品の種類を示します。</span><span class="sxs-lookup"><span data-stu-id="912bd-191">Determines the product type.</span></span> <span data-ttu-id="912bd-192">現在サポートされている値は、**Durable** のみです。</span><span class="sxs-lookup"><span data-stu-id="912bd-192">Currently only supports a value of **Durable**.</span></span>          |  
|  <span data-ttu-id="912bd-193">**PurchaseDate**</span><span class="sxs-lookup"><span data-stu-id="912bd-193">**PurchaseDate**</span></span>  |    <span data-ttu-id="912bd-194">購入した日付です。</span><span class="sxs-lookup"><span data-stu-id="912bd-194">Date when the purchase occurred.</span></span>          |  |

 

 
