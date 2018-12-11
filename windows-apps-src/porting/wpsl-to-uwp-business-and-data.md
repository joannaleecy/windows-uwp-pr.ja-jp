---
description: UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。
title: WindowsPhone Silverlight のビジネスおよび UWP へのデータ レイヤーの移植
ms.assetid: 27c66759-2b35-41f5-9f7a-ceb97f4a0e3f
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cb53295227655e3067dafd5e3a3f1f4631a97455
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8882094"
---
#  <a name="porting-windowsphone-silverlight-business-and-data-layers-to-uwp"></a>WindowsPhone Silverlight のビジネスおよび UWP へのデータ レイヤーの移植


前のトピックは、「[入出力、デバイス、アプリ モデルの移植](wpsl-to-uwp-input-and-sensors.md)」でした。

UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。 こうしたレイヤーのコードでは、オペレーティング システムと .NET Framework API (たとえば、バックグラウンド処理、場所、カメラ、ファイル システム、ネットワーク、その他のデータ アクセスなど) を呼び出します。 その大半が[ユニバーサル Windows プラットフォーム (UWP) アプリ](https://msdn.microsoft.com/library/windows/apps/br211369)で利用可能であり、したがって変更なくこのコードの大半を移植できると考えられます。

## <a name="asynchronous-methods"></a>非同期メソッド

ユニバーサル Windows プラットフォーム (UWP) で優先されることの 1 つは、真に一貫して応答性が高いアプリを構築できるようにすることです。 アニメーションは常にスムーズで、パンやスワイプなどのタッチ操作は遅延なく瞬時であり、UI が指に密着するように感じさせます。 これを実現するために、50 ミリ秒以内の完了が保証できないすべての UWP API は非同期になり、名前の後に **Async** が付加されています。 UI スレッドは、**Async** メソッドの呼び出し後に直ちに戻り、別のスレッドで処理を実行します。 **Async** メソッドの使用は、構文的に非常に簡単であり、C# の **await** 演算子、JavaScript promise オブジェクト、C++ 後続タスクを使います。 詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。

## <a name="background-processing"></a>バックグラウンド処理

WindowsPhone Silverlight アプリは、アプリがフォア グラウンドにないときにタスクを実行するのに管理**ScheduledTaskAgent**オブジェクトを使用できます。 UWP アプリでは、同様の方法でバックグラウンド タスクを作成、登録するために [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスを使います。 バックグラウンド タスクの処理を実装するクラスを定義します。 システムでは、バックグラウンド タスクを定期的に実行し、処理を実行するクラスの [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを呼び出します。 UWP アプリでは、アプリ パッケージ マニフェストで**バックグラウンド タスク**の宣言を忘れずに設定します。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/mt299103)」をご覧ください。

バック グラウンドで大きなデータ ファイルを転送するには、WindowsPhone Silverlight アプリは、 **BackgroundTransferService**クラスを使用します。 UWP アプリは、このために [**Windows.Networking.BackgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) 名前空間の API を使います。 機能は同様のパターンを使って転送を開始しますが、新しい API では機能と性能が向上しています。 詳しくは、「[バックグラウンドでのデータの転送](https://msdn.microsoft.com/library/windows/apps/xaml/hh452975)」をご覧ください。

WindowsPhone Silverlight アプリは、アプリがフォア グラウンドにないときにオーディオを再生する**Microsoft.Phone.BackgroundAudio**名前空間のマネージ クラスを使います。 UWP は Windows Phone ストア アプリ モデルを使います。詳しくは、「[バックグラウンド オーディオ](https://msdn.microsoft.com/library/windows/apps/mt282140)」および[バックグラウンド オーディオ](http://go.microsoft.com/fwlink/p/?linkid=619997)のサンプルをご覧ください。

## <a name="cloud-services-networking-and-databases"></a>クラウド サービス、ネットワーク、データベース

Azure を使ってクラウドでデータとアプリ サービスをホストできます。 「[Mobile Services の使用](http://go.microsoft.com/fwlink/p/?LinkID=403138)」をご覧ください。 オンラインおよびオフラインの両データを必要とするソリューションの場合は、「[Mobile Services でのオフライン データの同期の使用](http://azure.microsoft.com/documentation/articles/mobile-services-windows-store-dotnet-get-started-offline-data/)」をご覧ください。

UWP は **System.Net.HttpWebRequest** クラスを部分的にサポートしていますが、**System.Net.WebClient** クラスはサポートされていません。 お勧めできる将来的な代替案は、[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または、.NET をサポートする他のプラットフォームにコードを移植可能にする場合は [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) を使って HTTP 要求を表します。

UWP アプリには、現在、大量のデータ アクセスを実行するシナリオ (基幹業務 (LOB) シナリオなど) を対象としたサポートは組み込まれていません。 ただし、ローカル トランザクション データベース サービスのために SQLite を使うことができます。 詳しくは、「[SQLite](https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936)」をご覧ください。

相対 URI ではなく絶対 URI を Windows ランタイム型に渡します。 「[Windows ランタイムへの URI の引き渡し](https://msdn.microsoft.com/library/hh763341.aspx)」をご覧ください。

## <a name="launchers-and-choosers"></a>ランチャーとセレクター

ランチャーとセレクター ( **Microsoft.Phone.Tasks**名前空間にあります)、WindowsPhone Silverlight アプリは、メールの作成、写真を選択または特定の種類の共有などの一般的な操作を実行するオペレーティング システムを操作できるの別のアプリとデータです。 [Windows Phone Silverlight は、windows 10 の名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)と同等の UWP の型を検索するトピックの「 **Microsoft.Phone.Tasks**を検索します。 これには、ランチャーおよびピッカーと呼ばれる同様のメカニズムから、アプリ間でデータを共有するコントラクトの実装に至るまで、一連の型が含まれます。

WindowsPhone Silverlight アプリ配置できます休止状態にまたは廃棄でも、たとえば、写真選択タスクを使用する場合。 UWP アプリは、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスの使用中はアクティブで実行中のままになります。

## <a name="monetization-trial-mode-and-in-app-purchases"></a>収益化 (試用モードとアプリ内購入)

WindowsPhone Silverlight アプリは、コードを移植する必要があるように、試用モードと、アプリ内購入機能のほとんどの UWP [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765)クラスを使用できます。 ただし、WindowsPhone Silverlight アプリが購入用アプリを提供する**MarketplaceDetailTask.Show**を呼び出します。

```csharp
    private void Buy()
    {
        MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
        marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
        marketplaceDetailTask.Show();
    }
```

UWP の  [**RequestAppPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/hh967813) メソッドを呼び出すコードを移植します。

```csharp
    private async void Buy()
    {
        await Windows.ApplicationModel.Store.CurrentApp.RequestAppPurchaseAsync(false);
    }
```

テスト目的のためにアプリ購入機能およびアプリ内購入機能をシミュレートするコードがある場合は、代わりに [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスを使うようにこのコードを移植できます。

## <a name="notifications-for-tile-or-toast-updates"></a>タイルまたはトーストの更新通知

通知は、WindowsPhone Silverlight アプリのプッシュ通知モデルの拡張機能です。 Windows プッシュ通知サービス (WNS) から通知を受信した場合、タイル更新またはトーストにより UI にこの情報を提示できます。 通知機能の UI 側の移植については、「[タイルとトースト](w8x-to-uwp-porting-xaml-and-ui.md)」をご覧ください。

UWP アプリで通知を使う方法について詳しくは、「[トースト通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868266)」をご覧ください。

C++、C#、または Visual Basic を使った Windows ランタイム アプリでのタイル、トースト、バッジ、バナー、通知の使用についての情報とチュートリアルは、「[タイル、バッジ、トースト通知の操作](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259)」をご覧ください。

## <a name="storage-file-access"></a>ストレージ (ファイル アクセス)

分離ストレージのキー/値ペアとしてアプリの設定を格納する WindowsPhone Silverlight コードは簡単に移植します。 ここでは前に、と後で例では、まず WindowsPhone Silverlight バージョンです。

```csharp
    var propertySet = IsolatedStorageSettings.ApplicationSettings;
    const string key = "favoriteAuthor";
    propertySet[key] = "Charles Dickens";
    propertySet.Save();
    string myFavoriteAuthor = propertySet.Contains(key) ? (string)propertySet[key] : "<none>";
```

次に相当する UWP の要素を示します。

```csharp
    var propertySet = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
    const string key = "favoriteAuthor";
    propertySet[key] = "Charles Dickens";
    string myFavoriteAuthor = propertySet.ContainsKey(key) ? (string)propertySet[key] : "<none>";
```

**Windows.Storage**名前空間のサブセットでは、利用できるように、多くの WindowsPhone Silverlight アプリは i/o **IsolatedStorageFile**をクラスがサポートされているなったファイルを実行します。 できたことを前提**IsolatedStorageFile**が使われている記述と読み取りは、ファイルにはまず WindowsPhone Silverlight バージョンの前に、と後で例を次に示します。

```csharp
    const string filename = "FavoriteAuthor.txt";
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var streamWriter = new StreamWriter(store.CreateFile(filename)))
        {
            streamWriter.Write("Charles Dickens");
        }
        using (var StreamReader = new StreamReader(store.OpenFile(filename, FileMode.Open, FileAccess.Read)))
        {
            string myFavoriteAuthor = StreamReader.ReadToEnd();
        }
    }
```

そして、UWP を使う同じ機能です。

```csharp
    const string filename = "FavoriteAuthor.txt";
    var store = Windows.Storage.ApplicationData.Current.LocalFolder;
    Windows.Storage.StorageFile file = await store.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
    await Windows.Storage.FileIO.WriteTextAsync(file, "Charles Dickens");
    file = await store.GetFileAsync(filename);
    string myFavoriteAuthor = await Windows.Storage.FileIO.ReadTextAsync(file);
```

WindowsPhone Silverlight アプリは、オプションの SD カードに読み取り専用アクセスが許可されます。 UWP アプリは、オプションの SD カードに読み取り専用のアクセスを行います。 詳しくは、「[SD カードへのアクセス](https://msdn.microsoft.com/library/windows/apps/mt188699)」をご覧ください。

UWP アプリでの写真、音楽、ビデオ ファイルへのアクセスについて詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](https://msdn.microsoft.com/library/windows/apps/mt188703)」をご覧ください。

詳しくは、「[ファイル、フォルダー、およびライブラリ](https://msdn.microsoft.com/library/windows/apps/mt185399)」をご覧ください。

次のトピックは、「[フォーム ファクターと UX の移植](wpsl-to-uwp-form-factors-and-ux.md)」です。

## <a name="related-topics"></a>関連トピック

* [名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)
 

