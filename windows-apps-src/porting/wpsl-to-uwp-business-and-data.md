---
description: UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。
title: UWP に Windows Phone Silverlight のビジネス データおよびデータ層の移植
ms.assetid: 27c66759-2b35-41f5-9f7a-ceb97f4a0e3f
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3e5b97c236f71c95cdff9c56ccc205d3b0fbde5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661687"
---
#  <a name="porting-windowsphone-silverlight-business-and-data-layers-to-uwp"></a>UWP に Windows Phone Silverlight のビジネス データおよびデータ層の移植


前のトピックは、「[入出力、デバイス、アプリ モデルの移植](wpsl-to-uwp-input-and-sensors.md)」でした。

UI の背後には、ビジネス レイヤーとデータ レイヤーがあります。 こうしたレイヤーのコードでは、オペレーティング システムと .NET Framework API (たとえば、バックグラウンド処理、場所、カメラ、ファイル システム、ネットワーク、その他のデータ アクセスなど) を呼び出します。 その大半が[ユニバーサル Windows プラットフォーム (UWP) アプリ](https://msdn.microsoft.com/library/windows/apps/br211369)で利用可能であり、したがって変更なくこのコードの大半を移植できると考えられます。

## <a name="asynchronous-methods"></a>非同期メソッド

ユニバーサル Windows プラットフォーム (UWP) で優先されることの 1 つは、真に一貫して応答性が高いアプリを構築できるようにすることです。 アニメーションは常にスムーズで、パンやスワイプなどのタッチ操作は遅延なく瞬時であり、UI が指に密着するように感じさせます。 これを実現するために、50 ミリ秒以内の完了が保証できないすべての UWP API は非同期になり、名前の後に **Async** が付加されています。 UI スレッドは、**Async** メソッドの呼び出し後に直ちに戻り、別のスレッドで処理を実行します。 **Async** メソッドの使用は、構文的に非常に簡単であり、C# の **await** 演算子、JavaScript promise オブジェクト、C++ 後続タスクを使います。 詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。

## <a name="background-processing"></a>バックグラウンド処理

Windows Phone Silverlight アプリを使用してマネージできます**ScheduledTaskAgent**アプリがフォア グラウンドにないときにタスクを実行するオブジェクト。 UWP アプリでは、同様の方法でバックグラウンド タスクを作成、登録するために [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスを使います。 バックグラウンド タスクの処理を実装するクラスを定義します。 システムでは、バックグラウンド タスクを定期的に実行し、処理を実行するクラスの [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを呼び出します。 UWP アプリでは、アプリ パッケージ マニフェストで**バックグラウンド タスク**の宣言を忘れずに設定します。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/mt299103)」をご覧ください。

Windows Phone Silverlight アプリを使用して、バック グラウンドでの大きなデータ ファイルを転送する、 **BackgroundTransferService**クラス。 UWP アプリは、このために [**Windows.Networking.BackgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) 名前空間の API を使います。 機能は同様のパターンを使って転送を開始しますが、新しい API では機能と性能が向上しています。 詳しくは、「[バックグラウンドでのデータの転送](https://msdn.microsoft.com/library/windows/apps/xaml/hh452975)」をご覧ください。

Windows Phone Silverlight アプリでのマネージ クラスを使用して、 **Microsoft.Phone.BackgroundAudio**フォア グラウンドでアプリの中にオーディオを再生する名前空間がないです。 UWP は Windows Phone ストア アプリ モデルを使います。詳しくは、「[バックグラウンド オーディオ](https://msdn.microsoft.com/library/windows/apps/mt282140)」および[バックグラウンド オーディオ](https://go.microsoft.com/fwlink/p/?linkid=619997)のサンプルをご覧ください。

## <a name="cloud-services-networking-and-databases"></a>クラウド サービス、ネットワーク、データベース

Azure を使ってクラウドでデータとアプリ サービスをホストできます。 「[Mobile Services の使用](https://go.microsoft.com/fwlink/p/?LinkID=403138)」をご覧ください。 オンラインとオフラインの両方のデータを必要とするソリューションを参照してください。[Mobile Services でのオフライン データ同期を使用して](https://azure.microsoft.com/documentation/articles/mobile-services-windows-store-dotnet-get-started-offline-data/)します。

UWP は **System.Net.HttpWebRequest** クラスを部分的にサポートしていますが、**System.Net.WebClient** クラスはサポートされていません。 お勧めできる将来的な代替案は、[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または、.NET をサポートする他のプラットフォームにコードを移植可能にする場合は [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) を使って HTTP 要求を表します。

UWP アプリには、現在、大量のデータ アクセスを実行するシナリオ (基幹業務 (LOB) シナリオなど) を対象としたサポートは組み込まれていません。 ただし、ローカル トランザクション データベース サービスのために SQLite を使うことができます。 詳しくは、「[SQLite](https://visualstudiogallery.msdn.microsoft.com/4913e7d5-96c9-4dde-a1a1-69820d615936)」をご覧ください。

相対 URI ではなく絶対 URI を Windows ランタイム型に渡します。 「[Windows ランタイムへの URI の引き渡し](https://msdn.microsoft.com/library/hh763341.aspx)」をご覧ください。

## <a name="launchers-and-choosers"></a>ランチャーとセレクター

ランチャー、チューザーと (で見つかった、 **Microsoft.Phone.Tasks**名前空間)、Windows Phone Silverlight アプリ、写真を選択する、電子メールの構成などの一般的な操作を実行するオペレーティング システムと通信することができますか別のアプリとは、特定の種類のデータを共有します。 検索**Microsoft.Phone.Tasks** 、トピックの「 [Windows 10 の名前空間とクラス マッピングを Windows Phone Silverlight](wpsl-to-uwp-namespace-and-class-mappings.md) UWP 同等型が見つかりません。 これには、ランチャーおよびピッカーと呼ばれる同様のメカニズムから、アプリ間でデータを共有するコントラクトの実装に至るまで、一連の型が含まれます。

Windows Phone Silverlight アプリを配置できるに休止状態または廃棄も、たとえば、写真の選択タスクを使用する場合。 UWP アプリは、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスの使用中はアクティブで実行中のままになります。

## <a name="monetization-trial-mode-and-in-app-purchases"></a>収益化 (試用モードとアプリ内購入)

Windows Phone Silverlight アプリが、UWP を使用できます [**CurrentApp** ](https://msdn.microsoft.com/library/windows/apps/hh779765)クラスの試用版モードとアプリ内のほとんどは、機能を購入できるように、コードを移植する必要はありません。 しかし、Windows Phone Silverlight アプリを呼び出す**MarketplaceDetailTask.Show**購入アプリを提供します。

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

通知は、Windows Phone Silverlight アプリにプッシュ通知のモデルの拡張機能です。 Windows プッシュ通知サービス (WNS) から通知を受信した場合、タイル更新またはトーストにより UI にこの情報を提示できます。 通知機能の UI 側の移植については、「[タイルとトースト](w8x-to-uwp-porting-xaml-and-ui.md)」をご覧ください。

UWP アプリで通知を使う方法について詳しくは、「[トースト通知の送信](https://msdn.microsoft.com/library/windows/apps/xaml/hh868266)」をご覧ください。

C++、C#、または Visual Basic を使った Windows ランタイム アプリでのタイル、トースト、バッジ、バナー、通知の使用についての情報とチュートリアルは、「[タイル、バッジ、トースト通知の操作](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259)」をご覧ください。

## <a name="storage-file-access"></a>ストレージ (ファイル アクセス)

分離ストレージ内のキー/値ペアとしてアプリの設定を格納する Windows Phone Silverlight コードは簡単に移植します。 ここで例を示します前に、と後、最初に、Windows Phone の Silverlight バージョン。

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

サブセットですが、 **Windows.Storage**名前空間が使用できるようにするには、多くの Windows Phone Silverlight アプリの実行ファイルの i/o、 **IsolatedStorageFile**クラスではサポートされているため長くなります。 仮定**IsolatedStorageFile**が記述して、まず、Windows Phone の Silverlight バージョンのファイルの読み取りの前に、と後例を示します。 使用されています。

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

Windows Phone Silverlight アプリでは、オプションの SD カードに読み取り専用のアクセスを持ちます。 UWP アプリは、オプションの SD カードに読み取り専用のアクセスを行います。 詳しくは、「[SD カードへのアクセス](https://msdn.microsoft.com/library/windows/apps/mt188699)」をご覧ください。

UWP アプリでの写真、音楽、ビデオ ファイルへのアクセスについて詳しくは、「[ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー](https://msdn.microsoft.com/library/windows/apps/mt188703)」をご覧ください。

詳しくは、「[ファイル、フォルダー、およびライブラリ](https://msdn.microsoft.com/library/windows/apps/mt185399)」をご覧ください。

次のトピックは、「[フォーム ファクターと UX の移植](wpsl-to-uwp-form-factors-and-ux.md)」です。

## <a name="related-topics"></a>関連トピック

* [Namespace およびクラスのマッピング](wpsl-to-uwp-namespace-and-class-mappings.md)
 

