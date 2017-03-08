---
author: seksenov
title: "ホストされた Web アプリ - ユニバーサル Windows プラットフォーム (UWP) の機能とランタイム API へのアクセス"
description: "ユニバーサル Windows プラットフォーム (UWP) のネイティブ機能と Windows 10 ランタイム API (Cortona 音声コマンド、ライブ タイル、セキュリティのための ACUR、OpenID や OAuth など) のすべてに、リモートの JavaScript からアクセスします。"
kw: Hosted Web Apps, Accessing Windows 10 features from remote JavaScript, Building a Win10 Web Application, Windows JavaScript Apps, Microsoft Web Apps, HTML5 app for PC, ACUR URI Rules for Windows App, Call Live Tiles with web app, Use Cortana with web app, Access Cortana from website, msapplication-cortanavcd
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "ホストされた Web アプリ, JavaScript 用 WinRT API, Win10 Web アプリ, Windows JavaScript アプリ, ApplicationContentUriRules, ACUR, msapplication-cortanavcd, Web アプリ用 Cortana"
ms.assetid: 86ca4590-2675-4de2-b825-c586d9669b8e
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: ccb59581227db82b8566da11d6db731b362ec258
ms.lasthandoff: 02/08/2017

---

# <a name="accessing-universal-windows-platform-uwp-features"></a>ユニバーサル Windows プラットフォーム (UWP) の機能へのアクセス

Web アプリケーションは、ユニバーサル Windows プラットフォーム (UWP) へのフル アクセスが可能で、Windows デバイスのネイティブ機能のアクティブ化、[Windows セキュリティのメリットの活用](#keep-your-app-secure--setting-application-content-uri-rules-acurs)、サーバーでホストされるスクリプトからの直接的な [Windows ランタイム API の呼び出し](#call-windows-runtime-apis)、[Cortana の統合](#integrate-cortana-voice-commands)の活用、[オンライン認証プロバイダー](#web-authentication-broker)の使用を実現できます。 [ハイブリッド アプリ](#create-hybrid-apps--packaged-web-apps-vs-hosted-web-apps)もサポートされているため、ホストされているスクリプトから呼び出されるローカル コードを使って、リモートとローカルのページ間でのアプリのナビゲーションを管理することができます。

## <a name="keep-your-app-secure--setting-application-content-uri-rules-acurs"></a>アプリのセキュリティの保護: アプリケーション コンテンツ URI 規則 (ACUR) の設定

ACUR (URL 許可リストとも呼ばれる) によって、リモートの HTML、CSS、JavaScript からユニバーサル Windows API への直接的なアクセスを、リモート URL に許可できます。 Windows OS レベルでは、Web サーバーでホストされているコードがプラットフォーム API を直接呼び出すことができるように、適切なポリシーの境界が設定されています。 ホストされた Web アプリを構成する一連の URL を、アプリケーション コンテンツ URI 規則 (ACUR) に配置する場合は、アプリ パッケージ マニフェストでこれらの境界を定義します。 この規則には、アプリのスタート ページと、アプリのページとして含めるその他のあらゆるページを含める必要があります。 必要に応じて、特定の URL を除外することもできます。

規則では、次のような方法で URL 照合を指定します。

- 完全なホスト名
- 任意のサブドメインを指定した URI を含むホスト名、またはサブドメインを指定した URI を除外したホスト名
- 完全な URI
- クエリ プロパティを含むことができる完全な URI
- 対象に含めるルールの場合は、部分的なパスと、特定のファイル拡張子を示すワイルドカード
- 対象から除外する規則の場合は、相対パス

規則に含まれない URL にユーザーが移動した場合は、Windows によってターゲット URL がブラウザーで開かれます。

以下に、ACUR の例をいくつか示します。

```HTML
<Application
Id="App"
StartPage="http://contoso.com/home">
<uap:ApplicationContentUriRules>
    <uap:Rule Type="include" Match="https://contoso.com/" WindowsRuntimeAccess="all" />
    <uap:Rule Type="include" Match="https://*.contoso.com/" WindowsRuntimeAccess="all" />
    <uap:Rule Type="exclude" Match="https://contoso.com/excludethispage.aspx" />
</uap:ApplicationContentUriRules>
```

## <a name="call-windows-runtime-apis"></a>Windows ランタイム API の呼び出し

URL がアプリの境界内 (ACUR) で定義されている場合、JavaScript で "WindowsRuntimeAccess" 属性を使って、Windows ランタイム API を呼び出すことができます。 適切なアクセス権を持つ URL がアプリ ホスティング プロセスに読み込まれたときに、Windows 名前空間がスクリプト エンジンに挿入されて存在しています。 これにより、アプリのスクリプトでユニバーサル Windows API を直接呼び出すことができます。 開発者として必要な作業は、呼び出す Windows API の機能を検出し、必要に応じて、プラットフォームの機能の実行に進むことだけです。

これを実現するには、ACUR で `(WindowsRuntimeAccess="<<level>>")` 属性を、次のいずれかの値で指定する必要があります。

- **all**: リモート JavaScript コードは、すべての UWP API とローカルのパッケージ化されたコンポーネントにアクセスできます。
- **allowForWeb**: リモート JavaScript コードは、パッケージ コード内のカスタム コンポーネントにのみアクセスできます。 カスタム C++/C# コンポーネントにローカルにアクセスできます。
- **none**: 既定値。 指定された URL はプラットフォームにアクセスできません。

以下に、規則の種類の例を示します。

```HTML
<uap:ApplicationContentUriRules>
    <uap:Rule Type="include" Match="http://contoso.com/" WindowsRuntimeAccess="all"  />
</uap:ApplicationContentUriRules>
```

これにより、http://contoso.com/ で動作しているスクリプトに、Windows ランタイム名前空間と、パッケージに含まれるカスタム コンポーネントへのアクセスが許可されます。 トースト通知用の GitHub のサンプル [Windows.UI.Notifications.js](https://gist.github.com/Gr8Gatsby/3d471150e5b317eb1813#file-windows-ui-notifications-js) をご覧ください。

ライブ タイルを実装し、リモート JavaScript からそれを更新する例を以下に示します。

```Javascript
function updateTile(message, imgUrl, imgAlt) {
    // Namespace: Windows.UI.Notifications

    if (typeof Windows !== 'undefined'&&
            typeof Windows.UI !== 'undefined' &&
            typeof Windows.UI.Notifications !== 'undefined') {    
        var notifications = Windows.UI.Notifications,
        tile = notifications.TileTemplateType.tileSquare150x150PeekImageAndText01,
        tileContent = notifications.TileUpdateManager.getTemplateContent(tile),
        tileText = tileContent.getElementsByTagName('text'),
        tileImage = tileContent.getElementsByTagName('image');    
        tileText[0].appendChild(tileContent.createTextNode(message || 'Demo Message'));
        tileImage[0].setAttribute('src', imgUrl || 'https://unsplash.it/150/150/?random');
        tileImage[0].setAttribute('alt', imgAlt || 'Random demo image');    
        var tileNotification = new notifications.TileNotification(tileContent);
        var currentTime = new Date();
        tileNotification.expirationTime = new Date(currentTime.getTime() + 600 * 1000);
        notifications.TileUpdateManager.createTileUpdaterForApplication().update(tileNotification);
    } else {
        //Alternative behavior

    }
}
```

このコードは、次のような外観のタイルを生成します。

![Windows 10 のライブ タイルの呼び出し](images/hwa-to-uwp/hwa_livetile.png)

呼び出しの前にサーバー上のリソースで常に Windows の機能を検出することによって、最も使い慣れた任意の環境や手法を用いて Windows ランタイム API を呼び出します。 プラットフォームの機能が利用できず、Web アプリが別のホストで実行されている場合は、ブラウザーで動作する標準的な既定のエクスペリエンスをユーザーに提供できます。

## <a name="integrate-cortana-voice-commands"></a>Cortana 音声コマンドの統合

html ページで音声コマンド定義 (VCD) ファイルを指定すると、Cortana 統合を利用できます。 VCD ファイルは、コマンドに特定の語句をマップする xml ファイルです。 たとえば、[スタート] ボタンをタップし、「Contoso Books、ベスト セラーを表示」と発声すると、Contoso Books アプリを起動して、アプリ内の "ベスト セラー" ページに移動できます。

VCD ファイルの場所の一覧を含む `<meta>` 要素タグを追加すると、Windows によって音声コマンド定義ファイルが自動的にダウンロードされ、登録されます。

ホストされた Web アプリの html ページでの meta タグの使用例を次に示します。

```HTML
<meta name="msapplication-cortanavcd" content="http:// contoso.com/vcd.xml"/>
```

Cortana の統合と VCD について詳しくは、「Cortana の操作」と「音声コマンド定義 (VCD) の要素および属性 v1.2」をご覧ください。

## <a name="create-hybrid-apps--packaged-web-apps-vs-hosted-web-apps"></a>ハイブリッド アプリの作成: ページ Web アプリとホストされた Web アプリ

UWP アプリを作成するためのオプションがあります。 アプリは、Windows ストアからダウンロードし、ローカル クライアントで完全にホストするように設計することができます (一般的に**パッケージ Web アプリ**と呼ばれます)。 これにより、互換性のある任意のプラットフォームでアプリをオフラインで実行できます。 または、アプリはリモート Web サーバーで実行する完全にホストされた Web アプリ (一般的に**ホストされた Web アプリ**と呼ばれます) とすることができます。 ただし、3 つ目のオプションもあります。アプリはローカル クライアントで部分的にホストされるか、リモート Web サーバーで部分的にホストできます。 この 3 つ目のオプションを**ハイブリッド アプリ**と呼び、通常 **WebView** コンポーネントを使って、リモート コンテンツをローカル コンテンツのように表示します。 ハイブリッド アプリ パッケージには、ローカル アプリ コンテンツ内のパッケージとして実行される HTML5、CSS、Javascript コードを格納し、リモート コンテンツを操作する機能を保持できます。

## <a name="web-authentication-broker"></a>Web 認証ブローカー

インターネット認証と、OpenID や OAuth などの認証プロトコルを使用するオンライン ID プロバイダーがある場合は、Web 認証ブローカーを使って、ユーザーのログイン フローを処理できます。 アプリの html ページ上の `<meta>` タグに、開始 URI と終了 URI を指定します。 これらの URI が Windows で検出され、Web 認証ブローカーに渡されて、ログイン フローが完了します。 開始 URI は、オンライン プロバイダーに対する認証要求の送信先のアドレスと、必要なその他の情報 (アプリ ID、認証後にユーザーが転送されるリダイレクト URI、必要な応答の型など) で構成されます。 必要なパラメーターについては、プロバイダーに確認してください。 `<meta>` タグの使用例を次に示します。

```HTML
<meta name="ms-webauth-uris" content="https://<providerstartpoint>?client_id=<clientid>&response_type=token, https://<appendpoint>"/>
```

詳しいガイダンスが必要な場合は、「[Web 認証ブローカーに関する考慮事項 (オンライン プロバイダー向け)](https://msdn.microsoft.com/library/windows/apps/dn448956.aspx)」をご覧ください。

## <a name="app-capability-declarations"></a>アプリ機能の宣言

アプリでユーザー リソース (ピクチャや音楽など) やデバイス (カメラやマイクなど) に対してプログラムによるアクセスが必要な場合は、適切な機能を宣言する必要があります。 アプリ機能の宣言には次の 3 つのカテゴリがあります。 

- ストア アプリのほとんどのシナリオに適用される[一般的な用途の機能](https://msdn.microsoft.com/library/windows/apps/Mt270968.aspx#General-use_capabilities)。 
- アプリが周辺機器と内部デバイスにアクセスできるようにする[デバイス機能](https://msdn.microsoft.com/library/windows/apps/Mt270968.aspx#Device_capabilities)。 
- ストアに提出して使用可能にするために特別な会社のアカウントが必要になる[特殊な用途の機能](https://msdn.microsoft.com/library/windows/apps/Mt270968.aspx#Special_and_restricted_capabilities)。 

会社のアカウントについて詳しくは、「[アカウントの種類、場所、料金](https://msdn.microsoft.com/library/windows/apps/jj863494.aspx)」をご覧ください。

> [!NOTE]
> ユーザーが Windows ストアからアプリを入手するときに、アプリで宣言されているすべての機能が通知されることを知っておくのは重要です。 そのため、アプリに不要な機能は使わないでください。

アクセスを要求するには、アプリの[パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474.aspx)で機能を宣言します。 一般的な機能は Microsoft Visual Studio の[マニフェスト デザイナー](https://msdn.microsoft.com/library/windows/apps/xaml/hh454036(v=vs.140).aspx#Configure)で宣言できるほか、「[パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/br211477.aspx)」で説明しているように、パッケージ マニフェストに手動で追加することもできます。

一部の機能では、アプリが機密性の高いリソースにアクセスできます。 ユーザーの個人データにアクセスしたり、ユーザーに課金したりできるため、これらのリソースは機密性の高いリソースと見なされます。 設定アプリで管理されるプライバシー設定で、機密性の高いリソースへのアクセスを動的に制御することができます。 したがって、機密性の高いリソースが常に利用できるとアプリで認識されないことが重要です。 機密性の高いリソースへのアクセスについて詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223.aspx)」をご覧ください。

## <a name="manifoldjs-and-the-app-manifest"></a>manifoldjs とアプリ マニフェスト

Web サイトを UWP アプリに変換する簡単な方法は、**アプリ マニフェスト**と **manifoldjs** を使うことです。 アプリ マニフェストは、アプリに関するメタデータを格納する xml ファイルです。 アプリ マニフェストでは、アプリの名前、リソースへのリンク、表示モード、URL など、アプリを展開し、実行する方法を説明するデータを指定します。 manifoldjs は、このプロセスを簡単にします。Web アプリをサポートしないシステムでも同様です。 詳しくは、「[manifoldjs.com](http://www.manifoldjs.com/)」をご覧ください。 この [Windows 10 Web Apps プレゼンテーション](http://channel9.msdn.com/Events/WebPlatformSummit/2015/Hosted-web-apps-and-web-platform-innovations?wt.mc_id=relatedsession)の一部として、manifoldjs のデモを見ることもできます。

## <a name="related-topics"></a>関連トピック
- [Windows ランタイム API: JavaScript コード サンプル](http://rjs.azurewebsites.net/)
- [Codepen: Windows ランタイム API の呼び出しに使用するサンドボックス](http://codepen.io/seksenov/pen/wBbVyb/)
- [Cortana の操作](https://msdn.microsoft.com/library/windows/apps/dn974231.aspx)
- [音声コマンド定義 (VCD) の要素および属性 v1.2](https://msdn.microsoft.com/library/windows/apps/dn954977.aspx)
- [Web 認証ブローカーに関する考慮事項 (オンライン プロバイダー向け)](https://msdn.microsoft.com/library/windows/apps/dn448956.aspx)
- [アプリ機能の宣言 (Windows ストア アプリ)](https://msdn.microsoft.com/ibrary/windows/apps/hh464936.aspx)
