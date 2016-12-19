---
author: mcleanbyron
ms.assetid: E322DFFE-8EEC-499D-87BC-EDA5CFC27551
description: "製品購入が成功した各 Windows ストアのトランザクションでは、必要に応じてトランザクションの通知を返すことができます。"
title: "通知を使った製品購入の確認"
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: 55631d364ca6f2d76d214eca6d00fbdd969c0e15

---

# <a name="use-receipts-to-verify-product-purchases"></a>通知を使った製品購入の確認


>**注**&nbsp;&nbsp;この記事では、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、アプリ内での購入の受領通知を取得および検証する方法について説明します。 アプリがこの名前空間の代わりに、Windows 10 Version 1607 で導入された [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) を使用する場合、アプリ内での購入に関する受領通知を取得するための API は提供されていません。 ただし、Windows ストア コレクション API の REST メソッドを使って、購入トランザクションのデータを取得することができます。 詳しくは、「[アプリ内購入の受領通知](in-app-purchases-and-trials.md#receipts)」をご覧ください。


製品購入が成功した各 Windows ストアのトランザクションでは、必要に応じてトランザクションの通知を返すことができます。 この通知は、ユーザーに対する製品と金銭的コストの一覧を掲載します。

この情報は、ユーザーがアプリを購入したことや、Windows ストアからアドオン (アプリ内製品または IAP とも呼ばれます) の購入が行われたことをアプリで確認する必要がある場合などに役立ちます。 たとえば、ダウンロードしたコンテンツを提供するゲームを想像してください。 ゲーム コンテンツを購入したユーザーが別のデバイスでゲームをする場合、そのユーザーが既にコンテンツを所有していることを確認する必要があります。 以下にその方法を示します。

## <a name="requesting-a-receipt"></a>通知の要求


**Windows.ApplicationModel.Store** 名前空間は、受領通知を取得する複数の方法をサポートしています。

* [CurrentApp.RequestAppPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/hh967813)か [CurrentApp.RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/hh779780.aspx) (またはこのメソッドの他のオーバーロードのいずれか) を使って購入すると、戻り値に受領通知が含まれます。
* [CurrentApp.GetAppReceiptAsync](https://msdn.microsoft.com/library/windows/apps/hh967811) メソッドを呼び出して、アプリおよびアプリ内のアドオンに関する現在の受領通知を取得できます。

アプリの通知は次のようになります。

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

製品の通知は次のようになります。

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

これらの通知の例のいずれかを使って検証コードをテストできます。 受領通知の内容について詳しくは、「[受領通知の要素と属性の説明](#receipt-descriptions)」をご覧ください。

## <a name="validating-a-receipt"></a>通知の検証

受領通知の真正を検証するには、バックエンド システム (Web サービスやそれに類するサービス) でパブリック証明書を使って受領通知の署名を確認する必要があります。 この証明書を取得するには、URL ```https://go.microsoft.com/fwlink/p/?linkid=246509&cid=CertificateId``` (```CertificateId``` は受領通知の **CertificateId** の値) を使用します。

検証プロセスの例を以下に示します。 このコードは、**System.Security** アセンブリへの参照を含む .NET Framework コンソール アプリケーションで実行されます。

> [!div class="tabbedCodeSnippets"]
[!code-cs[ReceiptVerificationSample](./code/ReceiptVerificationSample/cs/Program.cs#ReceiptVerificationSample)]

<span id="receipt-descriptions" />
## <a name="element-and-attribute-descriptions-for-a-receipt"></a>受領通知の要素と属性の説明

このセクションでは、受領通知内の属性と要素について説明します。

### <a name="receipt-element"></a>受領通知の要素

このファイルのルート要素は、**Receipt** 要素です。これには、アプリとアプリ内での購入に関する情報が含まれています。 この要素には、次の子要素が含まれます。

|  要素  |  必須かどうか  |  数量  |  説明   |
|-------------|------------|--------|--------|
|  [AppReceipt](#appreceipt)  |    必須ではない        |  0 または 1  |  現在のアプリの購入情報が含まれています。            |
|  [ProductReceipt](#productreceipt)  |     必須ではない       |  0 以上    |   現在のアプリのアプリ内での購入に関する情報が含まれています。     |
|  Signature  |      必須      |  1   |   この要素は、標準の [XML-DSIG コンストラクト](http://go.microsoft.com/fwlink/p/?linkid=251093)です。 これには、受領通知の検証に使用する **SignatureValue** 要素に加え、**SignedInfo** 要素が含まれています。      |

**Receipt** には次の属性があります。

|  属性  |  説明   |
|-------------|-------------------|
|  **Version**  |    受領通知のバージョン番号            |
|  **CertificateId**  |     受領通知の署名に使用された証明サムプリント          |
|  **ReceiptDate**  |    受領通知が署名され、ダウンロードされた日付です。           |  
|  **ReceiptDeviceId**  |   この受領通知の要求に使用するデバイスを識別します。         |  |

<span id="appreceipt" />
### <a name="appreceipt-element"></a>AppReceipt 要素

この要素には、現在のアプリの購入情報が含まれています。

**AppReceipt** には次の属性があります。

|  属性  |  説明   |
|-------------|-------------------|
|  **Id**  |    購入を識別します。           |
|  **AppId**  |     OS がアプリに対して使用するパッケージ ファミリ名です。           |
|  **LicenseType**  |    ユーザーがアプリの通常版を購入した場合は、**Full** です。 ユーザーがアプリの試用版をダウンロードした場合は、**Trial** です。           |  
|  **PurchaseDate**  |    アプリが取得された日付です。          |  |

<span id="productreceipt" />
### <a name="productreceipt-element"></a>ProductReceipt 要素

この要素には、現在のアプリのアプリ内での購入に関する情報が含まれています。

**ProductReceipt** は次の属性があります。

|  属性  |  説明   |
|-------------|-------------------|
|  **Id**  |    購入を識別します。           |
|  **AppId**  |     ユーザーが購入に使ったアプリを識別します。           |
|  **ProductId**  |     購入した製品を識別します。           |
|  **ProductType**  |    製品の種類を示します。 現在サポートされている値は、**Durable** のみです。          |  
|  **PurchaseDate**  |    購入した日付です。          |  |

 

 



<!--HONumber=Dec16_HO1-->


