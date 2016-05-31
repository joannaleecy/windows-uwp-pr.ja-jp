---
author: mcleanbyron Description: アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。 ここでは、アプリ内で製品を販売できるようにする方法について説明します。
title: アプリ内製品購入の有効化 ms.assetid: D158E9EB-1907-4173-9889-66507957BD6B keywords: アプリ内販売 keywords: アプリ内購入 keywords: アプリ内製品 keywords: アプリ内購入/販売をサポートする方法 keywords: アプリ内購入コード サンプル keywords: アプリ内販売コード サンプル
---

# アプリ内製品購入の有効化

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。 ここでは、アプリ内で製品を販売できるようにする方法について説明します。

**注:** アプリ内製品は、アプリの試用版では提供できません。 アプリの試用版を使用中のユーザーがアプリ内製品を購入できるのは、通常版のアプリを購入する場合のみです。

## 前提条件

-   ユーザーが購入できる機能を追加する Windows アプリ。
-   新しいアプリ内製品のコード記述やテストを初めて行うときは、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトではなく、[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) オブジェクトを使う必要があります。 そうすることで、実稼働サーバーを呼び出すのではなく、ライセンス サーバーへのシミュレートされた呼び出しを使って、ライセンス ロジックを検証できます。 そのためには、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData で "WindowsStoreProxy.xml" という名前のファイルをカスタマイズする必要があります。 このファイルは、アプリを初めて実行するときに Microsoft Visual Studio シミュレーターによって作られます。カスタマイズされたファイルを実行時に読み込むこともできます。 詳しくは、「[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766)」をご覧ください。
-   このトピックでは、[ストア サンプル](http://go.microsoft.com/fwlink/p/?LinkID=627610)で提供されているコード例も参照します。 このサンプルを利用すると、ユニバーサル Windows プラットフォーム (UWP) アプリに提供されるさまざまな収益化オプションを体験できます。

## 手順 1: アプリのライセンス情報を初期化する

アプリを初期化するときに、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) または [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) を初期化することでアプリの [**LicenseInformation**](https://msdn.microsoft.com/library/windows/apps/br225157) オブジェクトを取得し、アプリ内製品の購入を有効にします。

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

## 手順 2: アプリにアプリ内製品の販売を追加する

アプリ内製品によって提供する機能ごとに、販売を作り、アプリに追加します。

**重要**  ストアにアプリを提出する前に、ユーザーに提供するすべてのアプリ内製品をアプリに追加する必要があります。 新しいアプリ内製品を後から追加する場合は、アプリを更新し、新しいバージョンを再提出する必要があります。

1.  **アプリ内販売トークンを作成する**

    アプリの各アプリ内製品は、トークンで識別します。 このトークンは開発者が定義する文字列であり、アプリ内とストア内で、特定のアプリ内製品を識別するために使われます。 アプリに固有のわかりやすい名前を付けて、その機能をコードの記述中に簡単に識別できるようにしてください。 たとえば、次のような名前を付けます。

    -   "SpaceMissionLevel4"
    -   "ContosoCloudSave"
    -   "RainbowThemePack"

2.  **条件ブロック内に機能のコードを記述する**

    アプリ内製品の対象となる各機能のコードは、その機能を使うためのライセンスをユーザーが持っているかどうかをテストする条件ブロック内に記述する必要があります。

    次の例は、ライセンス固有の条件ブロック内に **featureName** という名前の製品機能のコードを記述する方法を示しています。 **featureName** という文字列は、アプリ内でこの製品を一意に識別するトークンであり、ストアでも識別用に使われます。

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

3.  **この機能の購入 UI を追加する**

    アプリには、アプリ内製品で提供される製品または機能をユーザーが購入するための方法も用意する必要があります。 ユーザーは、完全なアプリを購入したときのように、ストアを通じてそれらの製品または機能を購入することはできません。

    次の例は、ユーザーが既にアプリ内製品を所有しているかどうかをテストし、所有していない場合は購入できるように購入用ダイアログを表示する方法を示しています。 "show the purchase dialog" というコメントを、購入用ダイアログの独自のコードに置き換えてください (わかりやすい [このアプリを購入] ボタンのあるページなど)。

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

## 手順 3: テスト コードを最終的な呼び出しに変更する

この手順は簡単です。アプリのコード内の [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) への参照をすべて [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) への参照に変えます。 WindowsStoreProxy.xml ファイルは不要になるので、アプリのパスから削除します (ただし、次の手順でアプリ内販売を構成するときの参照用に保存しておくことをお勧めします)。

## 手順 4: ストアでアプリ内製品を構成する

デベロッパー センター ダッシュボードで、アプリ内製品の製品 ID、種類、価格などのプロパティを定義します。 テストのときに WindowsStoreProxy.xml で設定した構成と同じ構成になっていることを確認してください。 詳しくは、「[IAP の申請](https://msdn.microsoft.com/library/windows/apps/mt148551)」をご覧ください。

## 注釈

コンシューマブルなアプリ内購入オプション (購入して使い切った後、必要に応じて再購入できる項目) を顧客に提供することに関心がある場合は、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。

ユーザーがアプリ内購入を行ったことを確認するために通知を使う必要がある場合は、「[通知を使った製品購入の確認](use-receipts-to-verify-product-purchases.md)」を確認してください。

## 関連トピック


* [コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)
* [アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)
* [通知を使った製品購入の確認](use-receipts-to-verify-product-purchases.md)
* [ストア サンプル (試用版とアプリ内購入のデモンストレーション)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
 

 






<!--HONumber=May16_HO2-->


