---
Description: ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。
title: 試用版での機能の除外または制限
ms.assetid: 1B62318F-9EF5-432A-8593-F3E095CA7056
keywords: 無料試用版
keywords: 無料のお試し期間
keywords: 無料試用版のコード例
keywords: 無料試用版のコード サンプル
---

# 試用版での機能の除外または制限


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。 どのような機能を制限するかをコーディング開始前に決め、完全なライセンスが購入されたときにだけその機能が正しく動作するようにアプリを設定します。 また、顧客がアプリを購入する前の試用期間中にだけバナーや透かしなどが表示されるようにもできます。

ここでは、このような工夫をアプリに加える方法について説明します。

## 前提条件

ユーザーが購入できる機能を追加する Windows アプリ。

## 手順 1: 試用期間中に有効または無効にする機能を選ぶ

アプリの現時点でのライセンスの状態は、[**LicenseInformation**](https://msdn.microsoft.com/library/windows/apps/br225157) クラスのプロパティとして保存されています。 通常は、次の手順で説明するように、ライセンスの状態に依存する関数を条件ブロック内に記述します。 このような機能について検討するときには、ライセンスがどの状態であっても動作するように実装できることを確認してください。

また、アプリの実行中にライセンスが変更された場合の処理方法を決めておきます。 試用版のアプリでもすべての機能を使うことができるようにしながら、購入版では表示されない広告バナーを表示することができます。 また、試用版アプリでは一部の機能を無効にしたり、ユーザーに購入を勧めるメッセージを表示したりすることもできます。

アプリの性質を考慮して、それに適した試用や有効期限の戦略を立ててください。 ゲームの試用版の場合は、ユーザーが遊べるゲーム コンテンツの量を制限するのが良い戦略でしょう。 ユーティリティの試用版の場合は、有効期限日の設定や、ユーザーが使いたがるような機能の制限を検討するとよいでしょう。

ゲーム以外の多くのアプリでは、ユーザーにアプリ全体を理解してもらうために、有効期限日を設定するのが適しています。 ここでは、有効期限に関するいくつかの一般的なシナリオと、その処理方法について説明します。

-   **アプリの実行中に試用ライセンスが期限切れになった**

    アプリの実行中に試用ライセンスが期限切れになった場合は、次の対処方法があります。

    -   何もしない。
    -   ユーザーにメッセージを表示する。
    -   閉じる。
    -   ユーザーにアプリの購入を促す。

    お勧めするのは、アプリの購入を促すメッセージを表示することです。ユーザーがアプリを購入したら、すべての機能を有効にして、そのまま使うことができるようにします。 購入しなかった場合は、アプリを閉じるか、アプリの購入が必要なことを一定の間隔で通知します。

-   **アプリの起動前に試用ライセンスが期限切れになった**

    ユーザーがアプリを起動する前に試用ライセンスが期限切れになった場合、アプリは起動しません。 ユーザーには、ストアからそのアプリを購入できることを伝えるダイアログ ボックスが表示されます。

-   **アプリの実行中にユーザーがアプリを購入した**

    アプリの実行中にユーザーがアプリを購入した場合は、次の対処方法があります。

    -   何もせず、アプリが再起動されるまでは試用モードを続ける。
    -   購入に対するお礼をする、またはメッセージを表示する。
    -   完全なライセンスがある場合に使うことができる機能を、通知なしで有効にする (または、試用版であることを示す表示を消す)。

ライセンスの変更を検出して、アプリで対応する場合は、次の手順で説明するように、そのためのイベント ハンドラーを追加する必要があります。
## 手順 2: ライセンス情報を初期化する

アプリを初期化するときに、この例で示されているように、アプリの [**LicenseInformation**](https://msdn.microsoft.com/library/windows/apps/br225157) オブジェクトを取得してください。 **licenseInformation** は、**LicenseInformation** 型のグローバル変数またはフィールドであるとします。

[
            **CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) または [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) を初期化して、アプリのライセンス情報にアクセスします。

```CSharp
void initializeLicense()
{
    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;
      
}
```

アプリの実行中にライセンスが変更されたときに通知を受け取るイベント ハンドラーを追加します。 アプリのライセンスが変更されるのは、たとえば、試用期間が終了したときや、ユーザーがストアを通じてアプリを購入したときです。

```CSharp
void InitializeLicense()
{
    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;

    // Register for the license state change event.
     licenseInformation.LicenseChanged += new LicenseChangedEventHandler(licenseChangedEventHandler);

}

// ...

void licenseChangedEventHandler()
{
    ReloadLicense(); // code is in next steps
}
```

## 手順 3: 条件ブロック内に機能のコードを記述する

ライセンスの変更のイベントが発生したときに、アプリはライセンス API を呼び出して試用の状態が変わったかどうかを判定する必要があります。 この手順のコードは、このイベントのハンドラーを構造化する方法を示しています。 この時点で、ユーザーがアプリを購入したら、ライセンスの状態が変わったことをユーザーに知らせることをお勧めします。 コーディングの方法上、必要であれば、ユーザーにアプリを再起動してもらわなければならないこともあります。 ただし、この移行は可能な限りスムーズで違和感のないようにする必要があります。

この例は、アプリの機能を必要に応じて有効にしたり、無効にしたりできるように、アプリのライセンス状態を判断する方法を示したものです。

```CSharp
void ReloadLicense()
{
    if (licenseInformation.IsActive)
    {
         if (licenseInformation.IsTrial)
         {
             // Show the features that are available during trial only.
         }
         else
         {
             // Show the features that are available only with a full license.
         }
     }
     else
     {
         // A license is inactive only when there' s an error.
     }
}
```

## 手順 4: アプリの試用有効期限日を取得する

アプリの試用有効期限日を取得するコードを含めます。

この例のコードは、アプリの試用有効期限日を取得する関数を定義しています。 ライセンスがまだ有効であれば、試用期限が切れるまでの日数で有効期限を表示します。

```CSharp
void DisplayTrialVersionExpirationTime()
{
    if (licenseInformation.IsActive)
    {
        if (licenseInformation.IsTrial)
        {
            var longDateFormat = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longdate");
                                                
            // Display the expiration date using the DateTimeFormatter. 
            // For example, longDateFormat.Format(licenseInformation.ExpirationDate)

            var daysRemaining = (licenseInformation.ExpirationDate - DateTime.Now).Days;

            // Let the user know the number of days remaining before the feature expires
        }
        else
        {
            // ...
        }
    }
    else
    {
       // ...
    }
}
```

## 手順 5: シミュレートされたライセンス API 呼び出しで機能をテストする

シミュレートされたライセンス サーバー呼び出しを使って、アプリをテストしてみましょう。 JavaScript、C#、Visual Basic、または Visual C++ で、アプリの初期化コード内の [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) への参照を [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) への参照に置き換えます。

[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) は、%userprofile%\\AppData\\local\\packages\\&lt;package name&gt;\\LocalState\\Microsoft\\Windows Store\\ApiData にある "WindowsStoreProxy.xml" という XML ファイルから、テスト専用のライセンス情報を取得します。 このパスとファイルがない場合は、インストール時か実行時にそれらを作る必要があります。 WindowsStoreProxy.xml が所定の場所にない状態で [**CurrentAppSimulator.LicenseInformation**](https://msdn.microsoft.com/library/windows/apps/hh779768) プロパティにアクセスしようとすると、エラーになります。

この例は、異なるライセンス状態のもとでアプリをテストするときのコードを追加する方法を示します。

```CSharp
void appInit()
{
    // some app initialization functions

    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    //   licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    licenseInformation = CurrentAppSimulator.LicenseInformation;

    // other app initialization functions
}
```

WindowsStoreProxy.xml を編集して、アプリや機能のシミュレートされた有効期限日を変更できます。 すべてが意図したとおりに動作するように、想定されるすべての有効期限とライセンスの構成をテストします。

## 手順 6: シミュレートされたライセンス API メソッドを実際の API に置き換える

シミュレートされたライセンス サーバーでアプリをテストした後、認定用にストアにアプリを提出する前に、[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) を [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) に置き換えます (次のコード例を参照)。

**重要:** アプリはストアへの提出時に [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) オブジェクトを使っている必要があり、そうでない場合は認定が不合格になります。

```CSharp
void appInit()
{
    // some app initialization functions

    // Initialize the license info for use in the app that is uploaded to the Store.
    // uncomment for release
    licenseInformation = CurrentApp.LicenseInformation;

    // Initialize the license info for testing.
    // comment the next line for release
    //   licenseInformation = CurrentAppSimulator.LicenseInformation;

    // other app initialization functions
}
```

## 手順 7: 無料の試用版についてユーザーに説明する

アプリの動作でユーザーが驚くことがないように、無料の試用期間中にアプリがどのように機能し、この期間が過ぎるとアプリがどのようになるかを必ず説明してください。

アプリの説明について詳しくは、「[アプリの説明の作成](https://msdn.microsoft.com/library/windows/apps/mt148529)」をご覧ください。

## 関連トピック

* [ストア サンプル (試用版とアプリ内購入のデモンストレーション)](http://go.microsoft.com/fwlink/p/?LinkID=627610)
* [アプリの価格と使用可能状況の設定](https://msdn.microsoft.com/library/windows/apps/mt148548)
* [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765)
* [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766)
 

 






<!--HONumber=Mar16_HO1-->


