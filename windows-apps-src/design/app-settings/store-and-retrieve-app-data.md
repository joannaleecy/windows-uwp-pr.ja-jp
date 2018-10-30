---
author: mijacobs
Description: Learn how to store and retrieve local, roaming, and temporary app data.
title: 設定と他のアプリ データを保存して取得する
ms.assetid: 41676A02-325A-455E-8565-C9EC0BC3A8FE
label: App settings and data
template: detail.hbs
ms.author: mijacobs
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2af9aec9742a950f7bd35794ff4d10763e6c2c5c
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5753839"
---
# <a name="store-and-retrieve-settings-and-other-app-data"></a>設定と他のアプリ データを保存して取得する

*アプリ データ*とは、特定のアプリに固有の実行可能データです。 ランタイム状態、ユーザー設定、その他の設定などがあります。 アプリ データは*ユーザー データ*とは異なり、アプリを使用しているときに、ユーザーが作成、管理するデータです。 ユーザー データには、ドキュメント ファイル、メディア ファイル、メール トランスクリプト、通信トランスクリプト、ユーザーが作成したコンテンツを保持するデータベース レコードなどがあります。 ユーザー データは複数のアプリで有効な場合があります。 多くの場合、ユーザー データは、ユーザーがアプリ自体とは無関係にエンティティとして操作または転送するデータ (ドキュメントなど) です。

**アプリ データに関する重要な注意:** アプリ データの有効期間は、アプリの有効期間に依存します。 アプリが削除されると、すべてのアプリ データが失われます。 ユーザー データや、ユーザーにとって欠かすことができない重要なデータの保存には、アプリ データを使用しないでください。 そのような情報の保存には、ユーザーのライブラリや Microsoft OneDrive を使用することをお勧めします。 アプリ データは、アプリ固有のユーザー設定、設定、お気に入りを保存するのに適しています。

## <a name="types-of-app-data"></a>アプリ データの種類


アプリ データには、設定とファイルの 2 種類があります。

-   **設定**

    設定を使用して、ユーザー設定やとアプリケーションの状態情報を保存します。 アプリ データ API を使用して、設定をを簡単に作成して取得できます (この記事の後半でいくつかの例を紹介します)。

    アプリの設定に使用できるデータ型を次に示します。

    -   **UInt8**、**Int16**、**UInt16**、**Int32**、**UInt32**、**Int64**、**UInt64**、**Single**、**Double**
    -   **Boolean**
    -   **Char16**、**String**
    -   [**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576)、[**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/br225996)
    -   **GUID**、[**Point**](https://msdn.microsoft.com/library/windows/apps/br225870)、[**Size**](https://msdn.microsoft.com/library/windows/apps/br225995)、[**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994)
    -   [**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588): 自動的にシリアル化および逆シリアル化する必要がある一連のアプリの設定。 コンポジット設定を使うと、相互に依存する設定のアトミックな更新が簡単になります。 同時アクセスとローミング時は、システムによってコンポジット設定の整合性が保たれます。 コンポジット設定は少量のデータに適しており、大きなデータ セットに使うとパフォーマンスが低下する場合があります。
-   **ファイル**

    ファイルを使うと、バイナリ データを保存したり、独自にカスタマイズされ、シリアル化された型を有効にできます。

## <a name="storing-app-data-in-the-app-data-stores"></a>アプリのデータ ストアにアプリ データを保存する


アプリのインストール時には、設定やファイル用に、ユーザーごとの固有のデータ ストアが設定されます。 物理的ストレージはシステムによって管理されるため、このデータの場所や形式を意識することなく、データは他のアプリやユーザーから確実に分離されます。 また、アプリに更新プログラムをインストールするときはデータ ストアの内容が保持され、アプリのアンインストール時にはデータ ストアの内容が完全に削除されます。

各アプリのデータ ストア内には、ローカル ファイル用、ローミング ファイル用、一時ファイル用に 1 つずつ、システム定義のルート ディレクトリがあります。 それぞれのルート ディレクトリに新しいファイルや新しいコンテナーをアプリで追加できます。

## <a name="local-app-data"></a>ローカル アプリ データ


ローカル アプリ データは、アプリ セッション間で保持する必要がある情報のうち、ローミング アプリ データには適していないものに使用されます。 また、他のデバイスには適さないデータもここに格納します。 ローカルに格納されるデータには、一般的なサイズの制限はありません。 ローカル アプリ データ ストアは、ローミングに適さないデータや、大きなデータ セットに使用してください。

### <a name="retrieve-the-local-app-data-store"></a>ローカル アプリ データ ストアを取得する

ローカル アプリ データを読み書きする前に、ローカル アプリ データ ストアを取得する必要があります。 ローカル アプリ データ ストアを取得するには、[**ApplicationData.LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) プロパティを使用して、アプリのローカル設定を [**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) オブジェクトとして取得します。 [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) オブジェクト内のファイルを取得するには、[**ApplicationData.LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティを使用します。 バックアップや復元に含まれていないファイルを保存できるローカル アプリ データ ストア内のフォルダーを取得するには、[**ApplicationData.LocalCacheFolder**](https://msdn.microsoft.com/library/windows/apps/dn633825) プロパティを使用します。

```CSharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;
```

### <a name="create-and-retrieve-a-simple-local-setting"></a>簡易ローカル設定を作成して取得する

設定を作成または書き込むには、[**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使用して、前の手順で取得した `localSettings` コンテナー内の設定にアクセスします。 次の例では、`exampleSetting` という名前の設定を作成します。

```CSharp
// Simple setting

localSettings.Values["exampleSetting"] = "Hello Windows";
```

設定を取得するには、設定を作成したときに使ったものと同じ [**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使います。 この例では作成した設定を取得する方法を示しています。

```CSharp
// Simple setting
Object value = localSettings.Values["exampleSetting"];
```

### <a name="create-and-retrieve-a-local-composite-value"></a>ローカル コンポジット値を作成して取得する

コンポジット値を作成または書き込むには、[**ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588) オブジェクトを作成します。 次の例では、`exampleCompositeSetting` という名前のコンポジット設定を作成し、`localSettings` コンテナーに追加します。

```CSharp
// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
    new Windows.Storage.ApplicationDataCompositeValue();
composite["intVal"] = 1;
composite["strVal"] = "string";

localSettings.Values["exampleCompositeSetting"] = composite;
```

この例では作成したコンポジット値を取得する方法を示しています。

```CSharp
// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
   (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["exampleCompositeSetting"];

if (composite == null)
{
   // No data
}
else
{
   // Access data in composite["intVal"] and composite["strVal"]
}
```

### <a name="create-and-read-a-local-file"></a>ローカル ファイルを作成して読み取る

ローカル アプリ データ ストアにファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。 次の例では、`localFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。 [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。

```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", 
       CreationCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

ローカル アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。 この例では、前の手順で作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。 さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```

## <a name="roaming-data"></a>ローミング データ


アプリでローミング データを使用すると、複数のデバイス間でアプリ データを簡単に同期することができます。 アプリを複数のデバイス上にインストールすると、OS によってアプリ データの同期が維持されるため、2 つ目のデバイス上でユーザーが行うアプリのセットアップ作業が軽減されます。 またローミングを使うと、異なるデバイス上でも、一覧の作成などの作業を中断したときの状態から再開することができます。 ローミング データが更新されると、OS によってクラウドにレプリケートされ、アプリがインストールされている別のデバイスに同期されます。

各アプリでローミングできるアプリ データのサイズには OS による制限があります。 「[**ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625)」をご覧ください。 この制限に達した場合、アプリでローミングされたアプリ データの合計が制限値未満に戻るまで、そのアプリのアプリ データはクラウドにまったくレプリケートされません。 このため、ローミング データは、ユーザー設定、リンク、小さなデータ ファイルのみに使うことをお勧めします。

アプリのローミング データは、一定の時間間隔内にユーザーがいずれかのデバイスからアクセスしている限り、クラウドに保持されます。 この時間間隔内にアプリが実行されないと、そのローミング データはクラウドから削除されます。 ユーザーがアプリをアンインストールしても、そのローミング データがクラウドから自動的に削除されることはなく、保持されます。 時間間隔内にユーザーがアプリを再インストールすると、ローミング データがクラウドから同期されます。

### <a name="roaming-data-dos-and-donts"></a>データのローミングの推奨事項と非推奨事項

-   ユーザーの基本設定やカスタマイズ、リンク、小さなデータ ファイルにローミングを使います。 たとえば、ローミングを使って、ユーザーの背景色の基本設定をすべてのデバイスで保持します。
-   ユーザーがデバイス間で作業を続けられるようにローミングを使います。 たとえば、下書きしたメールの内容やリーダー アプリで最近表示したページなどのアプリ データをローミングします。
-   アプリ データを更新して、[**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) イベントを処理します。 このイベントは、クラウドからのアプリ データの同期が完了したときに発生します。
-   生データではなくコンテンツへの参照をローミングします。 たとえば、オンライン記事のコンテンツではなく URL をローミングします。
-   タイム クリティカルな重要な設定に対しては、[**RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624) に関連付けられた *HighPriority* 設定を使います。
-   デバイス固有のアプリ データをローミングしないでください。 ローカルにあるファイル リソースのパス名など、ローカルのみに関連した情報もあります。 ローカル情報をローミングする場合は、その情報が別のデバイスで無効なときにアプリを回復できることを確認してください。
-   大量のアプリ データをローミングしないでください。 アプリでローミングできるアプリ データの量には制限があります。この最大値を取得するには、[**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625) プロパティを使ってください。 この制限に達した場合、アプリ データのサイズが制限を下回るまで、データはローミングできません。 アプリを設計する際は、この制限を超えないようにサイズの大きいデータをどのように制限するかを検討してください。 たとえば、ゲームの状態を保存するのにそれぞれ 10 KB 必要になる場合は、ユーザーによる保存を 10 ゲームまでに制限したりすると効果的です。
-   即時同期に依存するデータにローミングを使わないでください。 Windows では即時同期が保証されません。ユーザーがオフラインであったり、待ち時間の長いネットワークを使っている場合、ローミングはかなり遅れる可能性があります。 UI が即時同期に依存しないことを確認してください。
-   頻繁に変更されるデータのローミングを使用しないでください。 たとえば、再生中の曲の秒刻みの位置など、頻繁に変更される情報を追跡する場合は、この情報をローミング アプリ データとして保存しないでください。 代わりに、現在再生中の曲など、変更の頻度が少なく、ユーザー エクスペリエンスも損なわないような情報を利用します。

### <a name="roaming-pre-requisites"></a>ローミングの前提条件

アプリ データのローミングは、Microsoft アカウントを使ってデバイスにログインするすべてのユーザーに利点をもたらします。 ただし、いつでもデバイスでアプリ データのローミングを切り替えることができるのは、ユーザーとグループ ポリシーの管理者です。 ユーザーが Microsoft アカウントを使わない場合やデータのローミング機能を無効にする場合、ユーザーは引き続きアプリを使用できますが、アプリ データは各デバイスに対してローカルのままになります。

[**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) に格納されているデータは、ユーザーが "信頼" しているデバイスにしか移行されません。 デバイスが信頼されていない場合、この資格情報コンテナーのセキュリティで確保されているデータはローミングされません。

### <a name="conflict-resolution"></a>競合の解決

アプリ データのローミングは、複数のデバイスでの同時使用を想定していません。 2 台のデバイスで特定のデータ単位が変更されたことが原因で同期中に競合が発生した場合、最後に書き込まれた値が常に優先されます。 これにより、アプリで最新の情報が利用されます。 データ単位が設定コンポジットの場合、競合の解決は設定の単位で行われ、最新の変更を含むコンポジットが同期されます。

### <a name="when-to-write-data"></a>データを書き込むタイミング

想定される設定の有効期間に応じて、データを書き込むタイミングを変える必要があります。 変更の頻度が低いアプリ データや変更間隔の長いアプリ データは、変更されたらすぐに書き込むようにします。 ただし、頻繁に変更されるアプリ データは、アプリが中断されたとき以外は、一定の間隔 (5 分に 1 回など) でのみ書き込むようにします。 たとえば、音楽アプリでは、"現在の曲" の設定は新しい曲の再生が始まるたびに書き込みますが、曲の途中の実際の位置は中断したときにのみ書き込みます。

### <a name="excessive-usage-protection"></a>使いすぎに対する保護

リソースの不適切な使用を防止するために、システムにはさまざまな保護メカニズムが備わっています。 アプリ データが想定どおりに移行されない場合は、デバイスが一時的に制限されていることが考えられます。 通常、この状況はしばらくすると自動的に解決されるため、操作は必要ありません。

### <a name="versioning"></a>バージョン

アプリ データは、バージョンに基づいてデータ構造をアップグレードできます。 バージョン番号は、アプリのバージョンとは別の番号で、自由に設定することができます。 強制ではありませんが、バージョン番号は新しいデータほど大きくすることを強くお勧めします。新しいデータを表すバージョン番号が小さくなると、データ損失などの望ましくない問題が発生する可能性があります。

アプリ データのローミングは、バージョン番号が同じインストールされたアプリの間でしか行われません。 たとえば、どちらもバージョン 2 のデバイスの間やどちらもバージョン 3 のデバイスの間ではデータが移行されますが、バージョン 2 を実行中のデバイスとバージョン 3 を実行中のデバイスの間ではローミングは行われません。 他のデバイスでさまざまなバージョン番号を利用していたアプリを新たにインストールする場合、新たにインストールしたアプリは、最も大きいバージョン番号と関連付けられているアプリ データを同期します。

### <a name="testing-and-tools"></a>テストとツール

開発者は、ローミング アプリ データの同期をトリガーするためにデバイスをロックできます。 一定の期間にわたってアプリ データが移行されていない場合は、次の点を確認してください。

-   ローミング データが最大サイズを超えていないこと (詳しくは、「[**RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625)」をご覧ください)。
-   ファイルが閉じていて、適切に解放されていること。
-   同じバージョンのアプリを実行しているデバイスが 2 台以上あること。


### <a name="register-to-receive-notification-when-roaming-data-changes"></a>ローミング データが変更された場合に通知を受け取るように登録する

アプリのローミング データを使用するには、ローミング データの変更に備えて登録し、設定を読み書きできるように、ローミング データのコンテナーを取得する必要があります。

1.  ローミング データが変更されたときに通知を受け取るように登録します。

    [**DataChanged**](https://msdn.microsoft.com/library/windows/apps/br241620) イベントで、ローミング データが変更されたときに通知します。 この例では、ローミング データの変更のハンドラーとして `DataChangeHandler` を設定します。

```csharp
void InitHandlers()
    {
       Windows.Storage.ApplicationData.Current.DataChanged += 
          new TypedEventHandler<ApplicationData, object>(DataChangeHandler);
    }

    void DataChangeHandler(Windows.Storage.ApplicationData appData, object o)
    {
       // TODO: Refresh your data
    }
```

2.  アプリの設定とファイルのコンテナーを取得します。

    設定を取得するには [**ApplicationData.RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624) プロパティを、ファイルを取得するには [**ApplicationData.RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623) プロパティを使用します。

```csharp
Windows.Storage.ApplicationDataContainer roamingSettings = 
        Windows.Storage.ApplicationData.Current.RoamingSettings;
    Windows.Storage.StorageFolder roamingFolder = 
        Windows.Storage.ApplicationData.Current.RoamingFolder;
```

### <a name="create-and-retrieve-roaming-settings"></a>ローミング設定を作成して取得する

前のセクションで取得した `roamingSettings` コンテナー内の設定にアクセスするには、[**ApplicationDataContainer.Values**](https://msdn.microsoft.com/library/windows/apps/br241615) プロパティを使用します。 次の例では、`exampleSetting` という名前の簡易設定と、`composite` という名前のコンポジット値を作成します。

```csharp
// Simple setting

roamingSettings.Values["exampleSetting"] = "Hello World";
// High Priority setting, for example, last page position in book reader app
roamingSettings.values["HighPriority"] = "65";

// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
    new Windows.Storage.ApplicationDataCompositeValue();
composite["intVal"] = 1;
composite["strVal"] = "string";

roamingSettings.Values["exampleCompositeSetting"] = composite;

```

この例では作成した設定を取得します。

```csharp
// Simple setting

Object value = roamingSettings.Values["exampleSetting"];

// Composite setting

Windows.Storage.ApplicationDataCompositeValue composite = 
   (Windows.Storage.ApplicationDataCompositeValue)roamingSettings.Values["exampleCompositeSetting"];

if (composite == null)
{
   // No data
}
else
{
   // Access data in composite["intVal"] and composite["strVal"]
}
```

### <a name="create-and-retrieve-roaming-files"></a>ローミング ファイルを作成して取得する

ローミング アプリ データ ストアでファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。 次の例では、`roamingFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。 [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。

```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await roamingFolder.CreateFileAsync("dataFile.txt", 
       CreationCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

ローミング アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。 この例では、前のセクションで作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。 さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await roamingFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```


## <a name="temporary-app-data"></a>一時アプリ データ


一時アプリ データ ストアは、キャッシュのような働きをします。 ファイルはローミングされず、任意の時点で削除されます。 システム メンテナンス タスクを使うと、この場所に格納されているデータをいつでも自動的に削除できます。 ディスク クリーンアップを使って、一時データ ストアからファイルを削除することもできます。 一時アプリ データは、アプリ セッションの一時的な情報の格納に使うことができます。 このデータは、アプリ セッションの終了後に保持されるという保証はありません。必要に応じて使用領域が再利用されます。 この場所には、[**temporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使ってアクセスできます。

### <a name="retrieve-the-temporary-data-container"></a>一時データコンテナーを取得する

ファイルを取得するには [**ApplicationData.TemporaryFolder**](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティを使用します。 以降の手順では、この手順の `temporaryFolder` 変数を使用します。

```csharp
Windows.Storage.StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;
```

### <a name="create-and-read-temporary-files"></a>一時ファイルを作成して読み取る

一時アプリ データ ストアにファイルを作成して更新するには、[**Windows.Storage.StorageFolder.CreateFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227249) や [**Windows.Storage.FileIO.WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) などのファイル API を使用します。 次の例では、`temporaryFolder` コンテナーに `dataFile.txt` という名前のファイルを作成し、現在の日付と時刻をファイルに書き込みます。 [**CreationCollisionOption**](https://msdn.microsoft.com/library/windows/apps/br241631) 列挙体の **ReplaceExisting** 値は、ファイルが既にある場合にファイルを置き換えることを示します。


```csharp
async void WriteTimestamp()
{
   Windows.Globalization.DateTimeFormatting.DateTimeFormatter formatter = 
       new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");

   StorageFile sampleFile = await temporaryFolder.CreateFileAsync("dataFile.txt", 
       CreateCollisionOption.ReplaceExisting);
   await FileIO.WriteTextAsync(sampleFile, formatter.Format(DateTimeOffset.Now));
}
```

一時アプリ データ ストアのファイルを開いて読み取るには、[**Windows.Storage.StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272)、[**Windows.Storage.StorageFile.GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741)、[**Windows.Storage.FileIO.ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) などのファイル API を使用します。 この例では、前の手順で作成した `dataFile.txt` ファイルを開き、ファイルから日付を読み取ります。 さまざまな場所からファイル リソースを読み込む方法について詳しくは、「[ファイル リソースを読み込む方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965322)」をご覧ください。

```csharp
async void ReadTimestamp()
{
   try
   {
      StorageFile sampleFile = await temporaryFolder.GetFileAsync("dataFile.txt");
      String timestamp = await FileIO.ReadTextAsync(sampleFile);
      // Data is contained in timestamp
   }
   catch (Exception)
   {
      // Timestamp not found
   }
}
```

## <a name="organize-app-data-with-containers"></a>コンテナーでアプリ データを整理する


アプリ データの設定とファイルを整理するには、ディレクトリで直接作業するのではなく、コンテナー ([**ApplicationDataContainer**](https://msdn.microsoft.com/library/windows/apps/br241599) オブジェクトで表されます) を作成します。 コンテナーは、ローカル アプリ データ ストア、ローミング アプリ データ ストア、一時アプリ データ ストアに追加できます。 コンテナーは 32 階層まで入れ子にすることができます。

設定コンテナーを作成するには、[**ApplicationDataContainer.CreateContainer**](https://msdn.microsoft.com/library/windows/apps/br241611) メソッドを呼び出します。 次の例では、`exampleContainer` という名前のローカル設定コンテナーを作成し、`exampleSetting` という名前の設定を追加します。 [**ApplicationDataCreateDisposition**](https://msdn.microsoft.com/library/windows/apps/br241616) 列挙体の **Always** 値は、コンテナーがまだない場合に作成されることを示します。

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Setting in a container
Windows.Storage.ApplicationDataContainer container = 
   localSettings.CreateContainer("exampleContainer", Windows.Storage.ApplicationDataCreateDisposition.Always);

if (localSettings.Containers.ContainsKey("exampleContainer"))
{
   localSettings.Containers["exampleContainer"].Values["exampleSetting"] = "Hello Windows";
}
```

## <a name="delete-app-settings-and-containers"></a>アプリの設定とコンテナーを削除する


アプリでもう必要のない簡易設定を削除するには、[**ApplicationDataContainerSettings.Remove**](https://msdn.microsoft.com/library/windows/apps/br241608) メソッドを使用します。 この例では、前の手順で作成した `exampleSetting` ローカル設定を削除します。

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete simple setting

localSettings.Values.Remove("exampleSetting");
```

コンポジット設定を削除するには、[**ApplicationDataCompositeValue.Remove**](https://msdn.microsoft.com/library/windows/apps/br241597) メソッドを使用します。 この例では、前の例で作成したローカルの `exampleCompositeSetting` コンポジット設定を削除します。

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete composite setting

localSettings.Values.Remove("exampleCompositeSetting");
```

コンテナーを削除するには、[**ApplicationDataContainer.DeleteContainer**](https://msdn.microsoft.com/library/windows/apps/br241612) メソッドを呼び出します。 この例では、前の手順で作成したローカルの `exampleContainer` 設定コンテナーを削除します。

```csharp
Windows.Storage.ApplicationDataContainer localSettings = 
    Windows.Storage.ApplicationData.Current.LocalSettings;
Windows.Storage.StorageFolder localFolder = 
    Windows.Storage.ApplicationData.Current.LocalFolder;

// Delete container

localSettings.DeleteContainer("exampleContainer");
```

## <a name="versioning-your-app-data"></a>アプリ データのバージョン管理


必要に応じて、アプリのアプリ データをバージョン管理することもできます。 これにより、将来作成するアプリのバージョンでアプリ データの形式を変更しても、以前のバージョンとの互換性に問題が起こりません。 データ ストア内のアプリ データのバージョンをアプリが確認し、以前のバージョンであった場合、アプリ データは新しい形式に更新され、バージョンも更新されます。 詳しくは、「[**Application.Version**](https://msdn.microsoft.com/library/windows/apps/br241630) プロパティ」と「[**ApplicationData.SetVersionAsync**](https://msdn.microsoft.com/library/windows/apps/hh701429) メソッド」をご覧ください。

## <a name="related-articles"></a>関連記事

* [**Windows.Storage.ApplicationData**](https://msdn.microsoft.com/library/windows/apps/br241587)
* [**Windows.Storage.ApplicationData.RoamingSettings**](https://msdn.microsoft.com/library/windows/apps/br241624)
* [**Windows.Storage.ApplicationData.RoamingFolder**](https://msdn.microsoft.com/library/windows/apps/br241623)
* [**Windows.Storage.ApplicationData.RoamingStorageQuota**](https://msdn.microsoft.com/library/windows/apps/br241625)
* [**Windows.Storage.ApplicationDataCompositeValue**](https://msdn.microsoft.com/library/windows/apps/br241588)
