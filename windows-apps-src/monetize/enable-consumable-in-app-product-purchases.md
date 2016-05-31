---
author: mcleanbyron Description: ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。
title: コンシューマブルなアプリ内製品購入の有効化 ms.assetid: F79EE369-ACFC-4156-AF6A-72D1C7D3BDA4 keywords: アプリ内販売 keywords: コンシューマブル keywords: アプリ内購入 keywords: アプリ内製品 keywords: アプリ内購入/販売をサポートする方法 keywords: アプリ内購入コード サンプル keywords: アプリ内販売コード サンプル
---

# コンシューマブルなアプリ内製品購入の有効化


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。

## 前提条件

-   このトピックでは、コンシューマブルなアプリ内製品の購入とフルフィルメントの完了報告について説明します。 アプリ内製品に詳しくない場合は、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」を読んで、ライセンス情報と、ストアでアプリ内製品を適切に一覧表示する方法を確かめてください。
-   新しいアプリ内製品のコード記述やテストを初めて行うときは、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトではなく、[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) オブジェクトを使う必要があります。 そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。 そのためには、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData で "WindowsStoreProxy.xml" という名前のファイルをカスタマイズする必要があります。 このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。 詳しくは、「**CurrentAppSimulator**」をご覧ください。
-   このトピックでは、[ストア サンプル](http://go.microsoft.com/fwlink/p/?LinkID=627610)で提供されているコード例も参照します。 このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。

## 手順 1: 購入要求の作成

最初の購買要求は、ストアを通じて行われた他の購入と同様に、[**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263381) を使って行います。 コンシューマブルなアプリ内製品に関する違いとして、購入が成功した後、その購入に対するフルフィルメントが正常に完了したことをアプリがストアに通知するまで、顧客は同じ製品をもう一度購入することができません。 アプリは、購入されたコンシューマブルのフルフィルメントを処理し、ストアにフルフィルメントの完了を通知する責任を負います。

次の例は、コンシューマブルなアプリ内製品の購入要求を示しています。 コードのコメントに、購入要求が成功した場合と同じ製品の購入のフルフィルメントが完了していないことが原因で購入要求が成功しなかった場合の 2 つの異なるシナリオについて、アプリがコンシューマブルなアプリ内製品のローカル フルフィルメントをいつ完了する必要があるかが示されています。

```CSharp
PurchaseResults purchaseResults = await CurrentAppSimulator.RequestProductPurchaseAsync("product1");
switch (purchaseResults.Status)
{
    case ProductPurchaseStatus.Succeeded:
        product1TempTransactionId = purchaseResults.TransactionId;

        // Grant the user their purchase here, and then pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
        // To indicate local fulfillment to the Windows Store.
        break;

    case ProductPurchaseStatus.NotFulfilled:
        product1TempTransactionId = purchaseResults.TransactionId;

        // First check for unfulfilled purchases and grant any unfulfilled purchases from an earlier transaction.
        // Once products are fulfilled pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
        // To indicate local fulfillment to the Windows Store.
        break;
}
```

## 手順 2: コンシューマブルのローカル フルフィルメントの実行

コンシューマブルなアプリ内製品へのアクセスを顧客に許可するとき、フルフィルメントの対象になっている製品 (*productId*) と、フルフィルメントが関連付けられているトランザクション (*transactionId*) を追跡することが重要です。

**重要**  アプリは、ストアにフルフィルメントの完了を正確に報告する必要があります。 この手順は、顧客が体験する公正で信頼できる購入エクスペリエンスを維持するために必要です。

次の例では、前の手順の [**RequestProductPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/dn263381) の呼び出しの [**PurchaseResults**](https://msdn.microsoft.com/library/windows/apps/dn263392) プロパティを使って、フルフィルメントの対象となる、購入された製品を識別しています。 ローカル フルフィルメントが成功したことを確かめるために、配列を使って後で参照できる場所に製品情報が保存されます。

```CSharp
private void GrantFeatureLocally(string productId, Guid transactionId)
{
    if (!grantedConsumableTransactionIds.ContainsKey(productId))
    {
        grantedConsumableTransactionIds.Add(productId, new List<Guid>());
    }
    grantedConsumableTransactionIds[productId].Add(transactionId);

    // Grant the user their content. You will likely increase some kind of gold/coins/some other asset count.
}
```

次の例では、前の例の配列を使って、後でストアにフルフィルメントを報告するときに使われる製品 ID とトランザクション ID のペアにアクセスする方法を示しています。

**重要**  フルフィルメントの追跡と確認のために使っている方法を問わず、アプリは、顧客が受け取っていないアイテムに対して課金されることのないように適正評価を行う必要があります。

```CSharp
private Boolean IsLocallyFulfilled(string productId, Guid transactionId)
{
    return grantedConsumableTransactionIds.ContainsKey(productId) && grantedConsumableTransactionIds[productId].Contains(transactionId);
}
```

## 手順 3: ストアへの製品フルフィルメントの報告

ローカル フルフィルメントが完了した後、アプリは、*productId* と製品購入が含まれるトランザクションを含む [**ReportConsumableFulfillmentAsync**](https://msdn.microsoft.com/library/windows/apps/dn263380) 呼び出しを行う必要があります。

**重要**  フルフィルメントが完了したコンシューマブルなアプリ内製品をストアに報告しなかった場合、ユーザーは、前回の購入のフルフィルメントが報告されるまで、その製品をもう一度購入することができなくなります。

```CSharp
FulfillmentResult result = await CurrentAppSimulator.ReportConsumableFulfillmentAsync("product2", product2TempTransactionId);
```

## 手順 4: フルフィルメントが未完了の購入の識別

アプリでは、[**GetUnfulfilledConsumablesAsync**](https://msdn.microsoft.com/library/windows/apps/dn263379) メソッドを使って、コンシューマブルなアプリ内製品に対するフルフィルメントの未完了をいつでも確認することができます。 このメソッドは、ネットワーク接続の中断やアプリの終了など、予期しないアプリのイベントが原因でフルフィルメントが完了していないコンシューマブルを調べるために、定期的に呼び出す必要があります。

次の例に、[**GetUnfulfilledConsumablesAsync**](https://msdn.microsoft.com/library/windows/apps/dn263379) を使ってフルフィルメントが未完了のコンシューマブルを列挙する方法と、アプリでこの一覧を反復処理してローカル フルフィルメントを完了する方法を示します。

```CSharp
private async void GetUnfulfilledConsumables()
{
    products = await CurrentApp.GetUnfulfilledConsumablesAsync();

    foreach (UnfulfilledConsumable product in products)
    {
        logMessage += "\nProduct Id: " + product.ProductId + " Transaction Id: " + product.TransactionId;
        // This is where you would pass the product ID and transaction ID to currentAppSimulator.reportConsumableFulfillment
    // To indicate local fulfillment to the Windows Store.
    }
}
```

## 関連トピック

* [アプリ内製品購入の有効化](enable-in-app-product-purchases.md)
* [ストア サンプル (試用版とアプリ内購入のデモンストレーション)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [**Windows.ApplicationModel.Store**](https://msdn.microsoft.com/library/windows/apps/br225197)
 

 






<!--HONumber=May16_HO2-->


