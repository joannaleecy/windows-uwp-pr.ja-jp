---
title: アプリの URI ハンドラーを使用してアプリを Web サイトで有効にする
description: Web サイト用のアプリ機能をサポートすることで、ユーザーがアプリを利用するように促します。
keywords: Windows でのディープ リンクの設定
ms.date: 08/25/2017
ms.topic: article
ms.assetid: 260cf387-88be-4a3d-93bc-7e4560f90abc
ms.localizationpriority: medium
ms.openlocfilehash: 176009cb3a2fb14eb5071d48d59a0b807d4c81d6
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63770365"
---
# <a name="enable-apps-for-websites-using-app-uri-handlers"></a>アプリの URI ハンドラーを使用してアプリを Web サイトで有効にする

Web サイト用のアプリ機能によってアプリが Web サイトに関連付けられ、Web サイトへのリンクを開いたときに、ブラウザーが開く代わりにアプリが起動されます。 アプリがインストールされていない場合は、通常のように、ブラウザーで Web サイトが開きます。 検証済みのコンテンツ所有者だけがリンクに登録できるため、ユーザーはこのエクスペリエンスを信頼することができます。 ユーザーは、登録された Web とアプリのリンクすべてを、[設定] > [アプリ] > [Web サイト用のアプリ] で確認できます。

Web とアプリのリンクを有効にするには、次を行う必要があります。
- アプリが処理する URI をマニフェスト ファイル内に指定します。
- アプリと Web サイト間の関連付けを定義する JSON ファイル。 アプリのマニフェスト宣言と同じホストのルートに配置されているこの JSON ファイルに、アプリのパッケージ ファミリ名を指定します。
- アプリでアクティブ化を処理します。

> [!Note]
> 以降、Windows 10 Creators update では、Microsoft Edge でクリックされたサポートされているリンクは、対応するアプリを起動します。 サポートされているリンクを他のブラウザー (例: Internet Explorer など) でクリックすると、そのままの閲覧エクスペリエンスが保持されます。

## <a name="register-to-handle-http-and-https-links-in-the-app-manifest"></a>http リンクや https リンクを処理できるようにアプリ マニフェストに登録する

アプリでは、処理する Web サイトの URI を指定する必要があります。 そのためには、**Windows.appUriHandler** 拡張機能登録をアプリのマニフェスト ファイル **Package.appxmanifest** に追加します。

たとえば、Web サイトのアドレスが “msn.com” である場合は、アプリのマニフェスト内に次のエントリを作成します。

```xml
<Applications>
  <Application ... >
      ...
      <Extensions>
         <uap3:Extension Category="windows.appUriHandler">
          <uap3:AppUriHandler>
            <uap3:Host Name="msn.com" />
          </uap3:AppUriHandler>
        </uap3:Extension>
      </Extensions>
  </Application>
</Applications>
```

上記の宣言によって、指定されたホストからのリンクを処理するようにアプリが登録されます。 Web サイトに複数のアドレス (例: m.example.com、www\.、example.com、*.example.com) 個別に追加し、`<uap3:Host Name=... />`内のエントリ、`<uap3:AppUriHandler>`アドレスごとにします。

## <a name="associate-your-app-and-website-with-a-json-file"></a>アプリと Web サイトを JSON ファイルに関連付ける

アプリで開くことができるのがお客様の Web サイトのコンテンツのみにする場合は、Web サーバーのルートまたはドメイン上の既知のディレクトリに配置されている JSON ファイル内に、アプリのパッケージ ファミリ名を指定します。 これにより、お客様の Web サイトは、指定されている一連のアプリがサイト上のコンテンツを開くことに同意したことになります。 パッケージ ファミリ名は、アプリケーション マニフェスト デザイナーの [パッケージ] セクションで確認できます。

>[!Important]
> JSON ファイルには、.json ファイル接尾辞を指定しないでください。

**windows-app-web-link** という名前で JSON ファイルを作成し (.json ファイル拡張子は付加しない)、アプリのパッケージ ファミリ名を指定します。 次に、例を示します。

``` JSON
[{
  "packageFamilyName": "Your app's package family name, e.g MyApp_9jmtgj1pbbz6e",
  "paths": [ "*" ],
  "excludePaths" : [ "/news/*", "/blog/*" ]
 }]
```

Windows によって、Web サイトへの https 接続が行われ、Web サーバー上の対応する JSON ファイルが検索されます。

### <a name="wildcards"></a>ワイルドカード

上記の JSON ファイルの例では、ワイルドカードの使用も示しています。 ワイルドカードを使用すると、数行のコードでさまざまなリンクをサポートすることができます。 Web とアプリのリンクでは、JSON ファイルで 2 種類のワイルドカードを使用できます。

| **ワイルドカード** | **説明**               |
|--------------|-------------------------------|
| **\***       | 任意の部分文字列を表します      |
| **?**        | 1 つの文字を表します |

たとえば、上記の例のように `"excludePaths" : [ "/news/*", "/blog/*" ]` と指定すると、アプリでは、Web サイトのアドレス (上記の例では msn.com) で始まるすべてのパスがサポートされますが、`/news/` と `/blog/` の下にあるパスは**サポートされません**。 つまり、**msn.com/weather.html** はサポートされますが、****msn.com/news/topnews.html**** はサポートされません。

### <a name="multiple-apps"></a>複数のアプリ

Web サイトにリンクするアプリが 2 つある場合、両方のアプリケーションのパッケージ ファミリ名を **windows-app-web-link** JSON ファイルに指定します。 これで、どちらのアプリもサポートされます。 両方のアプリがインストールされている場合、ユーザーに対して、どちらを既定のリンクとして選ぶかが示されます。 既定のリンクを後で変更する場合は、**[設定] > [Web サイト用のアプリ]** で変更できます。 また、開発者はいつでも JSON ファイルを変更できます。変更内容は、変更と同日内になるべく早く確認するか、更新後 8 日以内に確認してください。

``` JSON
[{
  "packageFamilyName": "Your apps's package family name, e.g MyApp_9jmtgj1pbbz6e",
  "paths": [ "*" ],
  "excludePaths" : [ "/news/*", "/blog/*" ]
 },
 {
  "packageFamilyName": "Your second app's package family name, e.g. MyApp2_8jmtgj2pbbz6e",
  "paths": [ "/example/*", "/links/*" ]
 }]
```

ユーザーに最適なエクスペリエンスを提供するには、JSON ファイル内のサポート対象のパスからオンラインのみのコンテンツが除外されるように、除外パスを使用してください。

最初に除外パスが確認され、除外パスが一致すると、そのパスに対応するページは、指定されたアプリではなくブラウザーで開かれます。 上記の例で '/news/\*'中にそのパスの下の任意のページが含まれます '/ニュース\*' (スラッシュ証跡 'ニュース' なし) の下の任意のパスが含まれています 'ニュース\*' など ' newslocal/'、' newsinternational/' などです。

## <a name="handle-links-on-activation-to-link-to-content"></a>コンテンツにリンクするためのアクティブ化でリンクを処理する

アプリの Visual Studio ソリューションで **App.xaml.cs** に移動し、**OnActivated()** に、リンクされたコンテンツの処理を追加します。 次の例では、アプリで開かれるページは URI パスによって異なります。

``` CS
protected override void OnActivated(IActivatedEventArgs e)
{
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame == null)
    {
        ...
    }

    // Check ActivationKind, Parse URI, and Navigate user to content
    Type deepLinkPageType = typeof(MainPage);
    if (e.Kind == ActivationKind.Protocol)
    {
        var protocolArgs = (ProtocolActivatedEventArgs)e;        
        switch (protocolArgs.Uri.AbsolutePath)
        {
            case "/":
                break;
            case "/index.html":
                break;
            case "/sports.html":
                deepLinkPageType = typeof(SportsPage);
                break;
            case "/technology.html":
                deepLinkPageType = typeof(TechnologyPage);
                break;
            case "/business.html":
                deepLinkPageType = typeof(BusinessPage);
                break;
            case "/science.html":
                deepLinkPageType = typeof(SciencePage);
                break;
        }
    }

    if (rootFrame.Content == null)
    {
        // Default navigation
        rootFrame.Navigate(deepLinkPageType, e);
    }

    // Ensure the current window is active
    Window.Current.Activate();
}
```

**重要** 上記の例で示したように、最後の `if (rootFrame.Content == null)` ロジックは `rootFrame.Navigate(deepLinkPageType, e);` に置き換えてください。

## <a name="test-it-out-local-validation-tool"></a>テストを実行します。ローカルの検証ツール

アプリ ホスト登録検証ツールを実行して、アプリと Web サイトの構成をテストできます。このツールは次の場所にあります。

%windir%\\system32\\**AppHostRegistrationVerifier.exe**

次のパラメーターを使用してこのツールを実行し、アプリと Web サイトの構成をテストしてください。

**AppHostRegistrationVerifier.exe** *packagefamilyname filepath のホスト名*

-   ホスト名:Web サイト (例: microsoft.com)
-   パッケージ ファミリ名 (PFN):アプリの PFN
-   ファイルのパス:ローカルの検証のための JSON ファイル (例: c:\\SomeFolder\\windows アプリ-web リンク)

ツールが何も返さない場合、アップロード時にそのファイルの検証は正常に終了します。 エラー コードがある場合は機能しません。

次のレジストリ キーを有効にすることで、ローカルな検証の一部としてサイドロードされたアプリ用にパスの一致を強制することができます。

`HKCU\Software\Classes\LocalSettings\Software\Microsoft\Windows\CurrentVersion\
AppModel\SystemAppData\YourApp\AppUriHandlers`

キー名:`ForceValidation` 値: `1`

## <a name="test-it-web-validation"></a>これをテストします。Web 検証

リンクをクリックしたときにアプリがアクティブ化されるかどうか確認するには、アプリケーションを閉じておきます。 次に、Web サイトでサポートされるパスのいずれかのアドレスをコピーします。 たとえば、web サイトのアドレスが"msn.com"で"path1"は、サポート パスの 1 つの場合を使用します。 `http://msn.com/path1`

アプリが閉じていることを確認します。 **Windows キー + R** キーを押し、**[ファイル名を指定して実行]** ダイアログ ボックスを開き、ウィンドウにリンクを貼り付けます。 Web ブラウザーではなく、アプリが起動します。

また、[LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) API を使用し、他のアプリから目的のアプリを起動してテストすることもできます。 この API を使用して、電話でテストすることもできます。

プロトコルのアクティブ化ロジックを実行する場合は、**OnActivated** イベント ハンドラーにブレークポイントを設定します。

## <a name="appurihandlers-tips"></a>AppUriHandlers のヒント:

- アプリで処理できるリンクのみを必ず指定してください。
- サポートするすべてのホストの一覧を指定します。  その www に注意してください\.example.com、*.example.com、別のホスト。
- ユーザーは、Web サイトを処理する特定のアプリを [設定] で選ぶことができます。
- JSON ファイルは、https サーバーにアップロードする必要があります。
- サポートするパスを変更する場合は、アプリを再公開しなくても、JSON ファイルを再公開することができます。 ユーザーには、1 ~ 8 日の間、変更内容が表示されます。
- AppUriHandlers と共にサイドロードされたすべてのアプリでは、インストール時にホストのリンクが検証されます。 機能をテストするために JSON ファイルをアップロードする必要はありません。
- この機能は、アプリが [LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx) によって起動された UWP アプリである場合、または [ShellExecuteEx](https://msdn.microsoft.com/library/windows/desktop/bb762154(v=vs.85).aspx) によって起動された Windows デスクトップ アプリである場合は、必ず動作します。 URL が、登録されているアプリの URI ハンドラーに対応している場合、ブラウザーではなくアプリが起動されます。

## <a name="see-also"></a>関連項目

[Web とアプリのサンプル プロジェクト](https://github.com/project-rome/AppUriHandlers/tree/master/NarwhalFacts)
[windows.protocol の登録](https://msdn.microsoft.com/library/windows/apps/br211458.aspx)
[URI のアクティブ化の処理](https://msdn.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)
[関連付けによる起動のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AssociationLaunching)では、LaunchUriAsync() API の使用方法を説明します。
