---
Description: 使用できるように、アプリ内製品を提供して &\#8212; 購入可能な項目が使用され、もう一度購入 &\#8212; ストアを通じて購入のお客様のエクスペリエンスが提供するコマース プラットフォームは両方の堅牢なと信頼性の高い。
title: コンシューマブルなアプリ内製品購入の有効化
ms.assetid: F79EE369-ACFC-4156-AF6A-72D1C7D3BDA4
keywords: UWP, コンシューマブル, アドオン, アプリ内購入, IAP, Windows.ApplicationModel.Store
ms.date: 08/25/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5588558eff3e9c9b2954f0726995765a2862c43b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655647"
---
# <a name="enable-consumable-in-app-product-purchases"></a>コンシューマブルなアプリ内製品購入の有効化

ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。

> [!IMPORTANT]
> この記事では、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使って、コンシューマブルなアプリ内製品の購入を有効化する方法について説明します。 この名前空間は更新されなくなり、新機能も追加されないため、代わりに [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用することをお勧めします。 **Windows.Services.Store**名前空間が消耗アドオンの管理対象の Store や、サブスクリプションなど、最新のアドオン型をサポートしているしは将来の種類の製品とパートナーによってサポートされる機能に対応するように設計されていますCenter とストア。 **Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。 **Windows.Services.Store** 名前空間を使用したコンシューマブルなアプリ内製品購入の有効化について詳しくは、[この記事](enable-consumable-add-on-purchases.md)をご覧ください。

## <a name="prerequisites"></a>前提条件

-   このトピックでは、コンシューマブルなアプリ内製品の購入とフルフィルメントの完了報告について説明します。 アプリ内製品に詳しくない場合は、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」を読んで、ライセンス情報と、ストアでアプリ内製品を適切に一覧表示する方法を確かめてください。
-   新しいアプリ内製品のコード記述やテストを初めて行うときは、[CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) オブジェクトではなく、[CurrentAppSimulator](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) オブジェクトを使う必要があります。 そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。 これを行うには、%userprofile% WindowsStoreProxy.xml をという名前のファイルをカスタマイズする必要があります\\AppData\\ローカル\\パッケージ\\&lt;パッケージ名&gt;\\LocalState\\Microsoft\\Windows ストア\\ApiData します。 このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。 詳しくは、「[CurrentAppSimulator での WindowsStoreProxy.xml ファイルの使用](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#proxy)」をご覧ください。
-   このトピックでは、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)で提供されているコード例も参照します。 このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。

## <a name="step-1-making-the-purchase-request"></a>手順 1:購入要求を行う

最初の購買要求は、ストアを通じて行われた他の購入と同様に、[RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync) を使って行います。 コンシューマブルなアプリ内製品に関する違いとして、購入が成功した後、その購入に対するフルフィルメントが正常に完了したことをアプリがストアに通知するまで、顧客は同じ製品をもう一度購入することができません。 アプリは、購入されたコンシューマブルのフルフィルメントを処理し、ストアにフルフィルメントの完了を通知する責任を負います。

次の例は、コンシューマブルなアプリ内製品の購入要求を示しています。 コードのコメントに、購入要求が成功した場合と同じ製品の購入のフルフィルメントが完了していないことが原因で購入要求が成功しなかった場合の 2 つの異なるシナリオについて、アプリがコンシューマブルなアプリ内製品のローカル フルフィルメントをいつ完了する必要があるかが示されています。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumablePurchases](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#MakePurchaseRequest)]

## <a name="step-2-tracking-local-fulfillment-of-the-consumable"></a>手順 2:ローカルの調達、消耗品の追跡

コンシューマブルなアプリ内製品へのアクセスを顧客に許可するとき、フルフィルメントの対象になっている製品 (*productId*) と、フルフィルメントが関連付けられているトランザクション (*transactionId*) を追跡することが重要です。

> [!IMPORTANT]
> アプリは、ストアにフルフィルメントの完了を正確に報告する必要があります。 この手順は、顧客が体験する公正で信頼できる購入エクスペリエンスを維持するために必要です。

次の例では、前の手順の [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync) 呼び出しの [PurchaseResults](https://msdn.microsoft.com/library/windows/apps/dn263392)プロパティを使って、フルフィルメントの対象となる、購入された製品を識別しています。 ローカル フルフィルメントが成功したことを確かめるために、コレクションを使って後で参照できる場所に製品情報が保存されます。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumablePurchases](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#GrantFeatureLocally)]

次の例では、前の例の配列を使って、後でストアにフルフィルメントを報告するときに使われる製品 ID とトランザクション ID のペアにアクセスする方法を示しています。

> [!IMPORTANT]
> フルフィルメントの追跡と確認のために使っている方法を問わず、アプリは、顧客が受け取っていないアイテムに対して課金されることのないように適正評価を行う必要があります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumablePurchases](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#IsLocallyFulfilled)]

## <a name="step-3-reporting-product-fulfillment-to-the-store"></a>手順 3:ストアへのレポート製品フルフィルメント

ローカル フルフィルメントが完了した後、アプリは、*productId* と製品購入が含まれるトランザクションを含む [ReportConsumableFulfillmentAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.reportconsumablefulfillmentasync) 呼び出しを行う必要があります。

> [!IMPORTANT]
> フルフィルメントが完了したコンシューマブルなアプリ内製品をストアに報告しなかった場合、ユーザーは、前回の購入のフルフィルメントが報告されるまで、その製品をもう一度購入することができなくなります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumablePurchases](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#ReportFulfillment)]

## <a name="step-4-identifying-unfulfilled-purchases"></a>手順 4:条件を満たさなく購入を識別します。

アプリでは、[GetUnfulfilledConsumablesAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getunfulfilledconsumablesasync) メソッドを使って、コンシューマブルなアプリ内製品に対するフルフィルメントの未完了をいつでも確認することができます。 このメソッドは、ネットワーク接続の中断やアプリの終了など、予期しないアプリのイベントが原因でフルフィルメントが完了していないコンシューマブルを調べるために、定期的に呼び出す必要があります。

次の例に、[GetUnfulfilledConsumablesAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getunfulfilledconsumablesasync) を使ってフルフィルメントが未完了のコンシューマブルを列挙する方法と、アプリでこの一覧を反復処理してローカル フルフィルメントを完了する方法を示します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[EnableConsumablePurchases](./code/InAppPurchasesAndLicenses/cs/EnableConsumablePurchases.cs#GetUnfulfilledConsumables)]

## <a name="related-topics"></a>関連トピック

* [アプリ内製品購入を有効にする](enable-in-app-product-purchases.md)
* [ストアのサンプル (試用版とアプリ内購入のデモンストレーション)](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)
* [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/br225197)
 

 
