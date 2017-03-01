---
author: seksenov
title: "ホストされた Web アプリ - Chrome アプリからユニバーサル Windows プラットフォーム アプリへの変換"
description: "Chrome アプリや Chrome 拡張機能を Windows ストア向けのユニバーサル Windows プラットフォーム (UWP) アプリに変換します。"
kw: Package Chrome Extension for Windows Store tutorial, Port Chrome Extension to Windows 10, How to convert Chrome App to Windows, How to add Chrome Extension to Windows Store, hwa-cli, Hosted Web Apps Command Line Interface CLI Tool, Install Chrome Extension on Windows 10 Device, convert .crx to .AppX
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 用 Chrome 拡張機能, Windows 向け Chrome アプリ, hwa cli, .crx から AppX への変換"
ms.assetid: 04f37333-48ba-441b-875e-246fbc3e1a4d
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 84d8875cc7b1c8540f54fec78cd675bd96919fd2
ms.lasthandoff: 02/08/2017

---

# <a name="convert-your-existing-chrome-app-to-a-universal-windows-platform-app"></a>既存の Chrome アプリからユニバーサル Windows プラットフォーム アプリへの変換

既存の Chrome でホストされたアプリからユニバーサル Windows プラットフォーム (UWP) で実行されるアプリへの変換が容易になりました。 Chrome アプリを変換する方法は 2 つあります。

- オプション 1: [ManifoldJS](http://manifoldjs.com/) で、入力の形式として Chrome マニフェストを受け入れるようになりました。 

- オプション 2: 既存の `.zip` または `.crx` ファイルから `.appx` パッケージを生成する [CLI ツール](https://github.com/MicrosoftEdge/hwa-cli)が開発されました。

## <a name="convert-your-existing-chrome-app-using-the-command-line-interface"></a>コマンド ライン インターフェイスを使った既存の Chrome アプリの変換

1. [NodeJS](https://nodejs.org/en/) とそのパッケージ マネージャーである [npm](https://www.npmjs.com/) をインストールします。 


2. コマンド プロンプト ウィンドウを開いて任意のディレクトリに移動します。


3. コマンド ラインで次のように入力することによって、ホストされた Web アプリ (HWA) のコマンド ライン インターフェイス (CLI) をインストールします。 `npm i -g hwa-cli`

4. Chrome パッケージ (`.crx` と `.zip` はサポートされているパッケージの形式) を変換します。`hwa convert path/to/chrome/app.crx` または  `hwa convert path/to/chrome/app.zip`

    **`path/to/chrome/app` を、変換する対象の Chrome アプリのパス情報に置き換えます。*
    
5. 生成された `.appx` は、Chrome パッケージと同じフォルダーに表示されます。 これで Windows ストアにアプリをアップロードする準備が整いました。 

## <a name="uploading-your-app-to-the-windows-store"></a>Windows ストアへのアプリのアップロード

アプリをアップロードするには、[Windows デベロッパー センター](https://developer.microsoft.com/windows)のダッシュボードにアクセスします。 [[新しいアプリの作成]](https://developer.microsoft.com/dashboard/Application/New) をクリックし、アプリ名を予約します。
![Windows デベロッパー センターのダッシュボードでの名前の予約](images/hwa-to-uwp/reserve_a_name.png)


[申請] セクションの [パッケージ] ページに移動して、`AppX` パッケージをアップロードします。

Windows ストアのプロンプトで必要事項を入力します。

    During the conversion process, you will be prompted for an Identity Name, Publisher Identity, and Publisher Display Name. To retrieve these values, visit the Dashboard in the [Windows Dev Center](https://developer.microsoft.com/windows).
    - Click on "[Create a new app](https://developer.microsoft.com/dashboard/Application/New)" and reserve your app name.
![Windows デベロッパー センターのダッシュボードでの名前の予約](images/hwa-to-uwp/reserve_a_name.png)
    - 次に、左側のメニューの [アプリ管理] セクションで [アプリ ID] クリックします。
    ![Windows デベロッパー センターのダッシュボードの [アプリ ID]](images/hwa-to-uwp/app_identity.png)
    - ページで入力を求められている 3 つの値が表示されます。 
        1. 識別名: `Package/Identity/Name`
        2. 発行元 ID: `Package/Identity/Publisher`
        3. 発行者表示名: `Package/Properties/PublisherDisplayName`


## <a name="guide-for-migrating-your-hosted-web-app"></a>ホストされた Web アプリを移行するためのガイド

Windows ストア用に Web アプリをパッケージ化した後、PC、タブレット、電話、HoloLens、Surface Hub、Xbox、Raspberry Pi など、すべての Windows ベースのデバイスで適切に動作するようにアプリをカスタマイズします。

### <a name="application-content-uri-rules"></a>アプリケーション コンテンツ URI 規則

[アプリケーション コンテンツ URI 規則 (ACUR)](./hwa-access-features.md) またはコンテンツ URI は、アプリ パッケージ マニフェスト内の URL 許可リストによって、ホストされた Web アプリのスコープを定義します。 リモート コンテンツとの相互の通信を制御するために、このリストに含める URL やこのリストから除外する URL を定義する必要があります。 ユーザーが明示的に含まれていない URL をクリックした場合、Windows は既定のブラウザーでターゲット パスを開きます。 ACUR を使うことで、[ユニバーサル Windows API](https://msdn.microsoft.com/library/windows/apps/br211377.aspx) に対する URL アクセスを許可することもできます。

少なくとも、規則にはアプリのスタート ページを含める必要があります。 変換ツールは、スタート ページとそのドメインに基づいて、一連の ACUR を自動的に作成します。 ただし、サーバー上とクライアント上のいずれかに関係なく、プログラムによるリダイレクトがある場合は、それらの宛先を許可リストに追加する必要があります。

*注: ACUR はページのナビゲーションにのみ適用されます。 画像、JavaScript ライブラリ、その他の類似アセットは、これらの制限の影響を受けません。*

多くのアプリは、ログイン フローに、Facebook や Google などのサード パーティのサイトを使用します。 変換ツールは、最も一般的なサイトに基づいて、一連の ACUR を自動的に作成します。 使用する認証の方法がそのリストに含まれておらず、リダイレクト フローである場合は、そのパスを ACUR として追加する必要があります。 [Web 認証ブローカー](./hwa-access-features.md)の使用を検討することもできます。

### <a name="flash"></a>Flash

Windows 10 アプリでは、Flash は使用できません。 Flash が使用できない場合でもアプリのエクスペリエンスに影響がないことを確認する必要があります。

広告については、広告主が HTML5 オプションを提供しているかどうかを確認する必要があります。 [Bing Ads](https://bingads.microsoft.com/) と[アプリ内広告](http://adsinapps.microsoft.com/)を調べることができます。

YouTube のビデオは、[既定の設定が HTML5 `<video>`](http://youtube-eng.blogspot.com/2015/01/youtube-now-defaults-to-html5_27.html) になったため、[`<iframe>` による埋め込み](https://developers.google.com/youtube/iframe_api_reference)を使用している限り、そのままで動作します。 アプリでまだ Flash API を使用している場合は、前に示した埋め込みのスタイルに切り替える必要があります。

### <a name="image-assets"></a>画像アセット

Chrome Web ストアでは、既にアプリ パッケージに [128 x 128 のアプリ アイコンの画像が必要です](https://developer.chrome.com/webstore/images)。 Windows 10 アプリの場合は、少なくとも、44 x 44、50 x 50、150 x 150、600 x 350 のアプリ アイコンの画像を提供する必要があります。 変換ツールは、128 x 128 の画像に基づいて、これらの画像を自動的に作成します。 より充実し、洗練されたアプリのエクスペリエンスを提供するには、独自の画像ファイルを作成することを強くお勧めします。 詳しくは、[タイルとアイコン アセットのガイドライン](https://msdn.microsoft.com/library/windows/apps/mt412102.aspx)をご覧ください。

### <a name="capabilities"></a>機能

アプリの機能は、特定の API やリソースにアクセスするために、パッケージ マニフェストで[宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)されている必要があります。 変換ツールは、位置情報、マイク、Web カメラの 3 つの一般的なデバイス機能を自動的に有効にします。 前者については、システムは、アクセスを付与する前にユーザーに許可を求めます。

*注: ユーザーには、アプリで宣言されているすべての機能が通知されます。 アプリで不要な機能は削除することをお勧めします。*

### <a name="file-downloads"></a>ファイルのダウンロード

従来のファイルのダウンロード (ブラウザーでのダウンロードなど) は現在サポートされていません。

### <a name="chrome-platform-apis"></a>Chrome プラットフォーム API

Chrome では、バックグラウンド スクリプトとして実行できる[専用 API](https://developer.chrome.com/apps/api_index) をアプリに提供しています。 これらはサポートされていません。 同等またはそれ以上の機能を、[Windows ランタイム API](https://msdn.microsoft.com/library/windows/apps/br211377.aspx) で見つけることができます。

## <a name="related-topics"></a>関連トピック

- [ユニバーサル Windows プラットフォーム (UWP) 機能にアクセスして Web アプリを強化する](./hwa-access-features.md)
- [ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](http://go.microsoft.com/fwlink/p/?LinkID=397871)
- [Windows ストア アプリ設計のアセットのダウンロード](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)

