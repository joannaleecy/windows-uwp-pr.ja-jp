---
author: TylerMSFT
title: アプリ拡張機能の作成と利用
description: ユニバーサル Windows プラットフォーム (UWP) アプリの拡張機能を作成してホストすると、Microsoft Store からユーザーがインストールできるパッケージを介してアプリを拡張できます。
keywords: アプリの拡張機能, アプリ サービス, バック グラウンド
ms.author: twhitney
ms.date: 10/05/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a1722c22c717ec1a349f6e7d48c1e151209eab2c
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5997016"
---
# <a name="create-and-host-an-app-extension"></a>アプリ拡張機能の作成とホスト

この記事では、UWP アプリの拡張機能を作成し、UWP アプリ内でホストする方法について説明します。

この記事には、コード サンプルが付属しています。
- [Math Extension コード サンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip)をダウンロードして解凍します。
- Visual Studio 2017 で MathExtensionSample.sln ファイルを開きます。 ビルドの種類を x86 に設定します (両方のプロジェクトで、**[ビルド]** > **[構成マネージャー]** を選択し、**[プラットフォーム]** を **[x86]** に変更します)。
- ソリューションの展開: **[ビルド]** > **[ソリューションの配置]** を選択します。

## <a name="introduction-to-app-extensions"></a>アプリ拡張機能の概要

ユニバーサル Windows プラットフォーム (UWP) では、アプリ拡張機能により、プラグイン、アドイン、アドオンが他のプラットフォームで実行する処理に類似した機能が提供されます。 たとえば、Microsoft Edge 拡張機能は、UWP アプリ拡張機能です。 UWP アプリ拡張機能は、Windows 10 Anniversary エディション (Version 1607、ビルド 10.0.14393) で導入されました。

UWP アプリ拡張機能は、コンテンツと展開イベントをホスト アプリと共有するための拡張宣言を持つ UWP アプリです。 拡張アプリは、複数の拡張機能を提供できます。

アプリ拡張機能も UWP アプリであるため、別のアプリ パッケージを作成することなく、これらは完全に機能するアプリとして使用でき、拡張機能をホストすることも、他のアプリに拡張機能を提供することもできます。

アプリ拡張機能のホストを作成することは、アプリ周辺のエコシステムを構築するチャンスであり、自分では予測しなかった形態または用意できないリソースによって他の開発者にアプリを強化してもらうことも可能になります。 Microsoft Office 拡張機能、Visual Studio 拡張機能、ブラウザー拡張機能などについて考えてみてください。これらは、各アプリに当初含まれていた機能を越えて、より充実したエクスペリエンスを生み出しています。 拡張機能を利用すると、アプリに価値を付加し、アプリの寿命を延ばすことができます。

**概要**

大まかに言うと、アプリ拡張機能の関係をセットアップするために、次の作業を行う必要があります。

1. 拡張機能のホストとなるアプリを宣言します。
2. 拡張機能となるアプリを宣言します。
3. 拡張機能をアプリ サービス、バック グラウンド タスク、またはその他のいずれとして実装するのかを決定します。
4. ホストと拡張機能の通信方法を定義します。
5. ホスト アプリ内で拡張機能にアクセスするために、[Windows.ApplicationModel.AppExtensions](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.AppExtensions) API を使用します。

これがどのように行われるのか、[Math Extension コード サンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip)で見てみましょう。このコードでは仮想計算機を実装していますが、拡張機能を使用してこの計算機に新しい関数を追加できます。 Microsoft Visual Studio 2017 で、コード サンプルから **MathExtensionSample.sln** を読み込みます。

![Math Extension コード サンプル](images/mathextensionhost-calctab.png)

## <a name="declare-an-app-to-be-an-extension-host"></a>アプリを拡張機能のホストとして宣言する

アプリの Package.appxmanifest ファイル内で `<AppExtensionHost>` 要素を宣言すると、そのアプリは自身をアプリ拡張機能のホストとして認識します。 その方法については、**MathExtensionHost** プロジェクトの **Package.appxmanifest** ファイルをご覧ください。

_MathExtensionHost プロジェクト内の Package.appxmanifest_
```xml
<Package
  ...
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap uap3 mp">
  ...
    <Applications>
      <Application Id="App" ... >
        ...
        <Extensions>
            <uap3:Extension Category="windows.appExtensionHost">
                <uap3:AppExtensionHost>
                  <uap3:Name>microsoft.com.MathExt</uap3:Name>
                </uap3:AppExtensionHost>
          </uap3:Extension>
        </Extensions>
      </Application>
    </Applications>
    ...
</Package>
```

`xmlns:uap3="http://..."` という記述があり、`IgnorableNamespaces` に `uap3` が指定されています。 これらは、uap3 名前空間を使用するために必要な記述です。

`<uap3:Extension Category="windows.appExtensionHost">` は、このアプリを拡張機能のホストとして識別します。

`<uap3:AppExtensionHost>` の **Name** 要素は、_拡張機能コントラクト_名です。 拡張機能が同じ拡張機能コントラクト名を指定していれば、ホストからの検出が可能になります。 慣例として、他の拡張機能コントラクト名との競合を回避するため、アプリ名または発行元の名前を使用して拡張機能コントラクト名を作成するようお勧めします。

同じアプリで、複数のホストと複数の拡張機能を定義できます。 この例では、1 つのホストを宣言します。 拡張機能は、別のアプリで定義します。

## <a name="declare-an-app-to-be-an-extension"></a>アプリを拡張機能として宣言する

アプリの **Package.appxmanifest** ファイル内で `<uap3:AppExtension>` 要素を宣言すると、そのアプリは自身をアプリ拡張機能のホストとして認識します。 その方法については、**MathExtension** プロジェクトの **Package.appxmanifest** ファイルをご覧ください。

_MathExtension プロジェクト内の Package.appxmanifest_
```xml
<Package
  ...
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap uap3 mp">
  ...
    <Applications>
      <Application Id="App" ... >
        ...
        <Extensions>
          ...
          <uap3:Extension Category="windows.appExtension">
            <uap3:AppExtension Name="Microsoft.com.MathExt"
                               Id="power"
                               DisplayName="x^y"
                               Description="Exponent"
                               PublicFolder="Public">
              <uap3:Properties>
                <Service>com.microsoft.powservice</Service>
              </uap3:Properties>
              </uap3:AppExtension>
          </uap3:Extension>
        </Extensions>
      </Application>
    </Applications>
    ...
</Package>
```

ここでも、`xmlns:uap3="http://..."` という記述があり、`IgnorableNamespaces` に `uap3` が指定されています。 これらは、`uap3` 名前空間を使用するために必要な記述です。

`<uap3:Extension Category="windows.appExtension">` は、このアプリを拡張機能として識別します。

`<uap3:AppExtension>` 属性の意味は次のとおりです。

|属性|説明|必須かどうか|
|---------|-----------|:------:|
|**Name**|これは、拡張機能コントラクト名です。 ホストで宣言されている **Name** と一致すれば、ホストがこの拡張機能を検出できます。| :heavy_check_mark: |
|**ID**| このアプリを拡張機能を一意に識別します。 複数の拡張機能で同じ拡張機能コントラクト名が使用されることも考えられるため (たとえば、ペイント アプリでは複数の拡張機能がサポートされています)、ID を使用して区別できます。 アプリ拡張機能のホストは、ID を使用して拡張機能の種類を推測できます。 たとえば、1 つ目の拡張機能がデスクトップ用、2 つ目の拡張機能がモバイル用に設計されている場合に、これらを ID で区別できます。 この目的で **Properties** 要素を使用することもできます (以下をご覧ください)。| :heavy_check_mark: |
|**DisplayName**| ユーザーが拡張機能を識別できるように、ホスト アプリから使用できます。 照会が可能であり、ローカライズ用に[新しいリソース管理システム](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) を使用できます。 ローカライズされたコンテンツは、ホスト アプリからではなく、アプリ拡張機能から読み込まれます。 | |
|**Description** | ユーザーに対して拡張機能を説明するために、ホスト アプリから使用できます。 照会が可能であり、ローカライズ用に[新しいリソース管理システム](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) を使用できます。 ローカライズされたコンテンツは、ホスト アプリからではなく、アプリ拡張機能から読み込まれます。 | |
|**PublicFolder**|パッケージのルートを基準としたフォルダーの名前です。このフォルダーでは、コンテンツを拡張機能のホストと共有できます。 この名前は、慣例では "Public" ですが、拡張機能内のフォルダーと一致する名前であれば、任意の名前を使用できます。| :heavy_check_mark: |

`<uap3:Properties>` は、実行時にホストが読み取ることができるカスタム メタデータが含まれた省略可能な要素です。 コード サンプルでは拡張機能がアプリ サービスとして実装されるため、ホストでは、そのアプリ サービスを呼び出すことができるように、名前を取得する方法が必要になります。 アプリ サービスの名前は、<Service> 要素で定義されています (任意の名前を定義できます)。 コード サンプルのホストは、実行時にこのプロパティを探して、アプリ サービスの名前を取得します。

## <a name="decide-how-you-will-implement-the-extension"></a>拡張機能の実装方法を決定する

[アプリ拡張機能に関する Build 2016 セッション](https://channel9.msdn.com/Events/Build/2016/B808)では、ホストと拡張機能の間で共有されるパブリック フォルダーの使用方法を説明しています。 その例では、ホストが呼び出す Javascript ファイル (パブリック フォルダーに格納されている) によって拡張機能が実装されています。 このアプローチには、軽量でありコンパイルを必要としないという利点があります。また、拡張機能の使用方法やアプリの Microsoft Store ページのリンクが記載された既定のランディング ページの作成もサポートされます。 詳しくは、[Build 2016 のアプリ拡張機能コード サンプル](https://github.com/Microsoft/App-Extensibility-Sample)をご覧ください。 具体的には、**InvertImageExtension** プロジェクトと、**ExtensibilitySample** プロジェクトに含まれる ExtensionManager.cs の `InvokeLoad()` をご覧ください。

この例では、アプリ サービスを使用して拡張機能を実装します。 アプリ サービスには、次の利点があります。

- ホスト アプリは自身のプロセス内で実行されるため、拡張機能がクラッシュしても、ホスト アプリはダウンしません。
- 好みの言語を使用してサービスを実装できます。 ホスト アプリの実装に使用する言語と一致する必要はありません。
- アプリ サービスは、自身用のアプリ コンテナーにアクセスできます。ホストの機能とは異なる場合があります。
- 使用中のデータとホスト アプリが分離されます。

### <a name="host-app-service-code"></a>アプリ サービスのコードをホストする

拡張機能のアプリ サービスを呼び出すホスト コードを次に示します。

_MathExtensionHost プロジェクト内の ExtensionManager.cs_
```cs
public async Task<double> Invoke(ValueSet message)
{
    if (Loaded)
    {
        try
        {
            // make the app service call
            using (var connection = new AppServiceConnection())
            {
                // service name is defined in appxmanifest properties
                connection.AppServiceName = _serviceName;
                // package Family Name is provided by the extension
                connection.PackageFamilyName = AppExtension.Package.Id.FamilyName;

                // open the app service connection
                AppServiceConnectionStatus status = await connection.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    Debug.WriteLine("Failed App Service Connection");
                }
                else
                {
                    // Call the app service
                    AppServiceResponse response = await connection.SendMessageAsync(message);
                    if (response.Status == AppServiceResponseStatus.Success)
                    {
                        ValueSet answer = response.Message as ValueSet;
                        if (answer.ContainsKey("Result")) // When our app service returns "Result", it means it succeeded
                        {
                            return (double)answer["Result"];
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
             Debug.WriteLine("Calling the App Service failed");
        }
    }
    return double.NaN; // indicates an error from the app service
}
```

これは、アプリ サービスを呼び出すための一般的なコードです。 アプリ サービスの実装方法と呼び出し方法について詳しくは、「[アプリ サービスの作成と利用の方法](how-to-create-and-consume-an-app-service.md)」をご覧ください。

1 点、呼び出すアプリ サービスの名前の決定方法に注意が必要です。 ホストは、拡張機能の実装に関する情報を持っていないため、拡張機能が自身のアプリ サービスの名前を提供する必要があります。 コード サンプルでは、拡張機能がアプリ サービスの名前を自身のファイル内の `<uap3:Properties>` 要素で宣言しています。

_MathExtension プロジェクト内の Package.appxmanifest_
```xml
    ...
    <uap3:Extension Category="windows.appExtension">
      <uap3:AppExtension ...>
        <uap3:Properties>
          <Service>com.microsoft.powservice</Service>
        </uap3:Properties>
        </uap3:AppExtension>
    </uap3:Extension>
```

`<uap3:Properties>` 要素では、独自の XML を定義できます。 ここでは、拡張機能を呼び出すときにホストが参照できるよう、アプリ サービスの名前を定義しています。

ホストが拡張機能を読み込むと、このようなコードによって、拡張機能の Package.appxmanifest で定義されているプロパティから、サービスの名前が抽出されます。

_`Update()` (MathExtensionHost プロジェクト内の ExtensionManager.cs に含まれている)_
```cs
...
var properties = await ext.GetExtensionPropertiesAsync() as PropertySet;

...
#region Update Properties
// update app service information
_serviceName = null;
if (_properties != null)
{
   if (_properties.ContainsKey("Service"))
   {
       PropertySet serviceProperty = _properties["Service"] as PropertySet;
       this._serviceName = serviceProperty["#text"].ToString();
   }
}
#endregion
```

アプリ サービスの名前が `_serviceName` に格納されていれば、ホストはこれを使用して、アプリ サービスを起動できます。

アプリ サービスを呼び出すには、そのアプリ サービスが含まれるパッケージのファミリ名も必要です。 この情報は、以下の行で取得され、アプリ拡張機能 API によって提供されます。 `connection.PackageFamilyName = AppExtension.Package.Id.FamilyName;`

### <a name="define-how-the-host-and-the-extension-will-communicate"></a>ホストと拡張機能の通信方法を定義する

アプリ サービスは [ValueSet](https://docs.microsoft.com/uwp/api/windows.foundation.collections.valueset) を使って情報を交換します。 ホストの作成者は、拡張機能と通信するための柔軟なプロトコルを用意する必要があります。 コード サンプルでは、将来的に拡張機能が 1 つまたは 2 つ、あるいはそれ以上の引数を受け取る可能性を考慮しています。

この例では、引数のプロトコルは 'Arg' + 引数番号 (`Arg1`、`Arg2` など) という名前のキー値ペアが含まれる **ValueSet** です。 ホストはすべての引数を **ValueSet** で渡し、拡張機能はそのうち必要なものを利用します。 拡張機能が結果を計算できる場合、拡張機能から返された **ValueSet** に `Result` という名前のキーがあり計算値が含まれていることをホストが想定します。 そのキーが存在しない場合、ホストでは、拡張機能が計算を完了できなかったと見なします。

### <a name="extension-app-service-code"></a>拡張機能のアプリ サービス コード

コード サンプルでは、拡張機能のアプリ サービスは、バック グラウンド タスクとして実装されていません。 代わりに、単一プロセスのアプリ サービス モデルが使用されており、アプリ サービスは、ホスト元の拡張機能アプリと同じプロセスで実行されます。 これは、ホスト アプリとは別のプロセスであり、拡張機能プロセスと、アプリ サービスが実装されたバックグラウンド プロセスとの間でのプロセス間通信を回避することで、パフォーマンス上のメリットと共にプロセス分離のメリットも得ることができます。 アプリ サービスをバックグラウンド タスクとして実行する場合と同じプロセスで実行する場合の相違点については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。

アプリ サービスが有効になると、`OnBackgroundActivate()` が呼び出されます。 このコードでは、`OnAppServiceRequestReceived()` に到達すると実際のアプリ サービスの呼び出しを処理すると共にハウスキーピング イベントを扱う (取り消しイベントや終了イベントを処理する保留オブジェクトの取得など) ためのイベント ハンドラーをセットアップします。

_MathExtension プロジェクト内の App.xaml.cs_
```cs
protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
{
    base.OnBackgroundActivated(args);

    if ( _appServiceInitialized == false ) // Only need to setup the handlers once
    {
        _appServiceInitialized = true;

        IBackgroundTaskInstance taskInstance = args.TaskInstance;
        taskInstance.Canceled += OnAppServicesCanceled;

        AppServiceTriggerDetails appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
        _appServiceDeferral = taskInstance.GetDeferral();
        _appServiceConnection = appService.AppServiceConnection;
        _appServiceConnection.RequestReceived += OnAppServiceRequestReceived;
        _appServiceConnection.ServiceClosed += AppServiceConnection_ServiceClosed;
    }
}
```

拡張機能の作業を行うコードは、`OnAppServiceRequestReceived()` に記述されています。 この関数は、アプリ サービスの起動時に呼び出され、計算を実行します。 必要な値を **ValueSet** から抽出し、 計算を実行できる場合は、ホストから返される **ValueSet** の中で、**Result** というキーを使用して結果を出力します。 このホストと拡張機能の通信方法について定義されているプロトコルにより、**Result** キーがあれば成功、それ以外の場合は失敗を示します。

_MathExtension プロジェクト内の App.xaml.cs_
```cs
private async void OnAppServiceRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below (SendResponseAsync()) to respond to the message
    // and we don't want this call to get cancelled while we are waiting.
    AppServiceDeferral messageDeferral = args.GetDeferral();
    ValueSet message = args.Request.Message;
    ValueSet returnMessage = new ValueSet();

    double? arg1 = Convert.ToDouble(message["arg1"]);
    double? arg2 = Convert.ToDouble(message["arg2"]);
    if (arg1.HasValue && arg2.HasValue)
    {
        returnMessage.Add("Result", Math.Pow(arg1.Value, arg2.Value)); // For this sample, the presence of a "Result" key will mean the call succeeded
    }

    await args.Request.SendResponseAsync(returnMessage);
    messageDeferral.Complete();
}
```

## <a name="manage-extensions"></a>拡張機能を管理する

ここまで、ホストと拡張機能の間の関係を実装する方法を見てきました。次に、システムにインストールされている拡張機能をホストが検出し、拡張機能を含むパッケージの追加と削除に対応する方法を見てみましょう。

Microsoft Store では、拡張機能がパッケージとして提供されます。 [AppExtensionCatalog](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions.appextensioncatalog) は、ホストの拡張機能コントラクト名に一致する拡張機能が含まれたインストール済みパッケージを検出し、ホストに関連するアプリ拡張機能パッケージがインストールまたは削除された場合に発生するイベントを提供します。

コード サンプルの `ExtensionManager` クラス (**MathExtensionHost** プロジェクトの **ExtensionManager.cs** に定義されている) は、拡張機能を読み込み、拡張機能パッケージのインストールおよびアンインストールに応答するためのロジックをラップしています。

`ExtensionManager` コンストラクターは `AppExtensionCatalog` を使用して、ホストと同じ拡張機能コントラクト名を持つアプリ拡張機能をシステム上で検出します。

_MathExtensionHost プロジェクト内の ExtensionManager.cs_
```cs
public ExtensionManager(string extensionContractName)
{
   // catalog & contract
   ExtensionContractName = extensionContractName;
   _catalog = AppExtensionCatalog.Open(ExtensionContractName);
   ...
}
```

拡張機能パッケージがインストールされると、`ExtensionManager` は、ホストと同じ拡張機能コントラクト名を持つパッケージ内の拡張機能に関する情報を収集します。 インストールに更新プログラムが含まれている場合もあり、その場合は影響を受ける拡張機能の情報も更新されます。 拡張機能パッケージがアンインストールされると、`ExtensionManager` は、どの拡張機能が利用できなくなったのかをユーザーが認識できるように、影響を受ける拡張機能に関する情報を削除します。

`Extension` クラス (**MathExtensionHost** プロジェクトの **ExtensionManager.cs** で定義されている) は、コード サンプルで拡張機能の ID、説明、ロゴ、およびアプリ固有の情報 (ユーザーによって拡張機能が有効化されているかどうかなど) にアクセスするために作成されました。

拡張機能が読み込まれている (**ExtensionManager.cs** の `Load()` をご覧ください) とは、パッケージの状態が正常であり、その拡張機能の ID、ロゴ、説明、パブリック フォルダー (このサンプルでは使用しませんが取得方法のみ示しています) が取得済みであるということを指します。 拡張機能パッケージ自体は読み込まれません。

どの拡張機能についてユーザーへの提示を停止するかを追跡するには、アンロードの概念を使用します。

`ExtensionManager` は、拡張機能、名前、説明、ロゴを UI にデータ バインドできるように、コレクション `Extension` のインスタンスを提供します。 **ExtensionsTab** ページは、このコレクションにバインドされ、拡張機能の有効化、無効化、削除を行うための UI を提供します。

![[拡張機能] タブの UI 例](images/mathextensionhost-extensiontab.png)

 拡張機能が削除されると、システムは、この拡張機能が含まれる (他の拡張機能が含まれている可能性もある) パッケージをアンインストールするかどうかの確認をユーザーに求めるメッセージを表示します。 ユーザーが同意するとパッケージがアンインストールされ、アンインストールされたパッケージ内の拡張機能が、ホスト アプリで利用可能な拡張機能の一覧から `ExtensionManager` によって削除されます。

 ![アンインストール用 UI](images/mathextensionhost-uninstall.png)

## <a name="debugging-app-extensions-and-hosts"></a>アプリ拡張機能とホストのデバッグ

拡張機能のホストと拡張機能は、同じソリューションに属していないことが一般的です。 この場合、ホストと拡張機能をデバッグするには、次の手順に従います。

1. Visual Studio の 1 つ目のインスタンスでホスト プロジェクトを読み込みます。
2. Visual Studio の 2 つ目のインスタンスで拡張機能を読み込みます。
3. デバッガーでホスト アプリを起動します。
4. デバッガーで拡張機能アプリを起動します  (拡張機能のデバッグではなく展開を行う場合、ホストのパッケージ インストール イベントをテストするには、**[ビルド] &gt; [ソリューションの配置]** を選択します)。

これで、ホスト内と拡張機能内のブレークポイントにヒットできます。
拡張機能アプリ自体のデバッグを開始すると、アプリ用に空白のウィンドウが表示されます。 空白のウィンドウが表示されないようにするには、拡張機能プロジェクトのデバッグ設定で、開始時にアプリが起動ではなくデバッグされるように変更できます (拡張機能プロジェクトを右クリックし、**[プロパティ]** > **[デバッグ]** > **[起動しないが、開始時にコードをデバッグ]** を選択)。この場合も拡張機能プロジェクトのデバッグを開始 (**F5**) する必要がありますが、開始は、ホストが拡張機能をアクティブ化し、拡張機能内のブレークポイントがヒットした後になります。

**コード サンプルをデバッグする**

コード サンプルでは、ホストと拡張機能が同じソリューションに属しています。 デバッグを行うには、以下の手順に従います。

1. **MathExtensionHost** がスタートアップ プロジェクトに設定されていることを確認します (**MathExtensionHost** プロジェクトを右クリックし、**[スタートアップ プロジェクトに設定]** をクリック)。
2. **MathExtensionHost** プロジェクトに含まれる ExtensionManager.cs 内で、`Invoke` にブレークポイントを設定します。
3. **F5** キーを押して **MathExtensionHost** プロジェクトを実行します。
4. **MathExtension** プロジェクトに含まれる App.xaml.cs 内で、`OnAppServiceRequestReceived` にブレークポイントを設定します。
5. **MathExtension** プロジェクトのデバッグを開始します (**MathExtension** プロジェクトで右クリックし、**[デバッグ] > [新しいインスタンスを開始]** を選択)。これにより、プロジェクトが展開され、ホスト内のパッケージ インストール イベントがトリガーされます。
6. **MathExtensionHost** アプリで、**[Calculation]** (計算) ページに移動し、**[x^y]** をクリックして拡張機能を有効化します。 最初に `Invoke()` ブレークポイントがヒットし、拡張機能のアプリ サービス呼び出しが行われたことを確認できます。 次に、拡張機能内の `OnAppServiceRequestReceived()` メソッドがヒットし、アプリ サービスによって結果が計算され、返されることを確認できます。

**アプリ サービスとして実装された拡張機能のトラブルシューティング**

拡張機能のホストが拡張機能のアプリ サービスに接続できない場合は、`<uap:AppService Name="...">` 属性が `<Service>` 要素の設定に一致しているか確認してください。 これらが一致していないと、拡張機能からホストに渡されるサービス名が、実装されているサービス名に一致せず、ホストは拡張機能を有効化できません。

_MathExtension プロジェクト内の Package.appxmanifest_
```xml
<Extensions>
   <uap:Extension Category="windows.appService">
     <uap:AppService Name="com.microsoft.sqrtservice" />      <!-- This must match the contents of <Service>...</Service> -->
   </uap:Extension>
   <uap3:Extension Category="windows.appExtension">
     <uap3:AppExtension Name="Microsoft.com.MathExt" Id="sqrt" DisplayName="Sqrt(x)" Description="Square root" PublicFolder="Public">
       <uap3:Properties>
         <Service>com.microsoft.powservice</Service>   <!-- this must match <uap:AppService Name=...> -->
       </uap3:Properties>
     </uap3:AppExtension>
   </uap3:Extension>
</Extensions>   
```

## <a name="a-checklist-of-basic-scenarios-to-test"></a>基本的なテスト シナリオのチェックリスト

拡張機能のホストをビルドして、拡張機能のサポートをテストする準備ができたら、次の基本的なシナリオを試してみてください。

- ホストを実行してから拡張機能アプリを展開する  
    - ホストでは、呼び出された新しい拡張機能を実行中に検出できますか?  
- 拡張機能アプリを展開してからホストを実行する
    - ホストでは、以前から存在する拡張機能を検出できますか?  
- ホストを実行してから拡張機能アプリを削除する
    - ホストでは、削除を正しく検出できますか?
- ホストを実行し、拡張機能アプリを新しいバージョンに更新する
    - ホストでは変化を検出し、拡張機能の古いバージョンを正しくアンロードできますか?  

**高度なテスト シナリオ**

- ホストを実行し、拡張機能アプリをリムーバブル メディアに移動して、そのメディアを取り外す
    - ホストでは、パッケージ状態の変化を検出し、拡張機能を無効にできますか?
- ホストを実行してから、拡張機能アプリを無効化する (無効に設定する、別の署名を使用するなど)
    - ホストでは、改ざんされた拡張機能を検出し、適切に処理できますか?
- ホストを実行し、無効なコンテンツまたはプロパティを持つ拡張機能アプリを展開する
    - ホストでは、無効なコンテンツを検出し、適切に処理できますか?

## <a name="design-considerations"></a>設計時の考慮事項

- 利用可能な拡張機能をユーザーに提示し、ユーザーによる有効化/無効化を可能にするための UI を用意します。 パッケージがオフラインになったなどの理由で利用不可能になった拡張機能を示すグリフの追加も検討します。
- 拡張機能を入手できる場所にユーザーを誘導します。 拡張機能のページに Microsoft Store 検索クエリを設置して、対象のアプリと共に使用できる拡張機能の一覧が提示されるようにしておくこともできます。
- 拡張機能の追加と削除をユーザーに通知する方法を検討します。 新しい拡張機能がインストールされた場合の通知を作成し、その拡張機能の有効化をユーザーに案内することもできます。 ユーザーによる管理を尊重できるように、拡張機能は既定で無効にします。

## <a name="how-app-extensions-differ-from-optional-packages"></a>アプリ拡張機能とオプション パッケージの相違点

[オプション パッケージ](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)とアプリ拡張機能との大きな相違点は、エコシステムが開いているか閉じているかという点と、パッケージが従属しているか独立しているかという点です。

アプリ拡張機能は、開いたエコシステムに属しています。 アプリでアプリ拡張機能をホストできる場合、拡張機能からの情報の請け渡し方法に従って、そのホストに対する拡張機能をだれでも作成できます。 この点が、閉じたエコシステムに属しているオプション パッケージと異なります。閉じたエコシステムでは、そのアプリと連携できるオプション パッケージをだれが作成できるのかを発行元が決定します。

アプリ拡張機能は、独立したパッケージであり、スタンドアロン アプリにすることもできます。 展開に関して別のアプリに依存することはできません。一方、オプション パッケージは、プライマリ パッケージを必要とし、プライマリ パッケージがないと実行できません。

オプション パッケージの好例はゲームの拡張機能パックです。ゲームに緊密にバインドされ、ゲームから独立して実行することはできません。また、拡張機能パックは開発者エコシステム内のだれが開発してもよいというものではありません。

このゲームにカスタマイズ可能な UI アドオンまたはテーマがある場合は、アプリ拡張機能の使用をお勧めします。拡張機能を提供するアプリは単独で実行でき、どのサード パーティでもそのようなアプリを作成できます。

## <a name="remarks"></a>解説

このトピックでは、アプリ拡張機能を紹介します。 重要な点として、ホストを作成して Package.appxmanifest ファイル内でホストとしてマークすること、拡張機能を作成して Package.appxmanifest ファイル内で拡張機能としてマークすること、拡張機能の実装方法 (アプリ サービス、バックグラウンド タスク、その他の方法) を決定すること、ホストと拡張機能との間の通信方法を定義すること、拡張機能へのアクセスと管理に [AppExtensions API](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions) を使用することが挙げられます。

## <a name="related-topics"></a>関連トピック

* [アプリ拡張機能の概要](https://blogs.msdn.microsoft.com/appinstaller/2017/05/01/introduction-to-app-extensions/)
* [アプリ拡張機能に関する Build 2016 セッション](https://channel9.msdn.com/Events/Build/2016/B808)
* [Build 2016 のアプリ拡張機能コード サンプル](https://github.com/Microsoft/App-Extensibility-Sample)
* [バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)
* [アプリ サービスの作成と利用の方法](how-to-create-and-consume-an-app-service.md)
* [AppExtensions 名前空間](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions)
* [サービス、拡張機能、パッケージでアプリを拡張する](https://docs.microsoft.com/windows/uwp/launch-resume/extend-your-app-with-services-extensions-packages)
