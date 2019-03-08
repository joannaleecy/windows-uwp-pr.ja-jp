---
title: IIS サーバーからの UWP アプリのインストール
description: このチュートリアルは、IIS サーバーを設定することを確認、web アプリできますアプリのパッケージをホストと呼び出すアプリのインストーラーを効果的に使用する方法を示します。
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、uwp アプリのインストーラー、AppInstaller、サイドローディングを行う、関連の設定、省略可能なパッケージ、IIS サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 6a4512229a29a7adc59d6b61edd596eaeb56a5a8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623567"
---
# <a name="install-a-uwp-app-from-an-iis-server"></a>IIS サーバーからの UWP アプリのインストール

このチュートリアルは、IIS サーバーを設定することを確認、web アプリできますアプリのパッケージをホストと呼び出すアプリのインストーラーを効果的に使用する方法を示します。

アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。 これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。 

## <a name="setup"></a>セットアップ

このチュートリアルで正常に移動に、以下の手順が必要されます。

1. Visual Studio 2017  
2. Web 開発ツールと IIS 
3. UWP アプリ パッケージ - 配布するアプリ パッケージ

省略可能: [スタート プロジェクト](https://github.com/AppInstaller/MySampleWebApp)GitHub でします。 これは、機能は、アプリ パッケージを使用すると、動作はありませんが、この機能を使用する方法を説明する場合に便利です。

## <a name="step-1---install-iis-and-aspnet"></a>手順 1 - IIS と ASP.NET のインストール 

[インターネット インフォメーション サービス](https://www.iis.net/)は [スタート] メニューを使用してインストールできる Windows の機能です。 **[スタート] メニュー**検索**オンまたはオフにする Windows 機能**します。

検索して選択**インターネット インフォメーション サービス**IIS をインストールします。

> [!NOTE]
> インターネット インフォメーション サービスのすべてのチェック ボックスをオンにする必要はありません。 チェックするときに選択したもののみ**インターネット インフォメーション サービス**で十分です。

ASP.NET 4.5 以上をインストールする必要があります。 これをインストールするには、検索**インターネット インフォメーション サービス Web サイト]-> [サービス]、[アプリケーション開発機能**します。 ASP.NET 4.5 以上である ASP.NET のバージョンを選択します。

![ASP.NET をインストールします。](images/install-asp.png)

## <a name="step-2---install-visual-studio-2017-and-web-development-tools"></a>手順 2 - Visual Studio 2017 をインストールし、Web 開発ツール 

[Visual Studio 2017 インストール](https://docs.microsoft.com/visualstudio/install/install-visual-studio)を既にインストールしていない場合。 Visual Studio 2017 が既にあるを場合は、次のワークロードがインストールされていることを確認します。 ワークロードがインストールに存在しない場合は、([スタート] メニューから検出)、Visual Studio インストーラーを使用して作業を進めるにします。  

インストール中に、次のように選択します。 **ASP.NET および Web 開発**と興味のあるその他の任意のワークロード。 

インストールが完了すると Visual Studio を起動し、新しいプロジェクトを作成 (**ファイル** -> **新しいプロジェクト**)。

## <a name="step-3---build-a-web-app"></a>手順 3 - Web アプリの構築

として Visual Studio 2017 を起動**管理者**され、新しい作成**Visual C# Web アプリケーション**でプロジェクトを**空**プロジェクト テンプレート。 

![新しいプロジェクト](images/sample-web-app.png)

## <a name="step-4---configure-iis-with-our-web-app"></a>手順 4 - Web アプリでの IIS の構成 

ソリューション エクスプ ローラーで、ルート プロジェクトを右クリックし、選択**プロパティ**します。

Web アプリのプロパティで、選択、 **Web**タブ。**サーバー**セクションで、選択**ローカル IIS**をクリックして、ドロップダウンから**仮想ディレクトリの作成**です。 

![[web] タブ](images/web-tab.png)

## <a name="step-5---add-an-app-package-to-a-web-application"></a>手順 5 - web アプリケーションにアプリ パッケージを追加 

Web アプリケーションに配布する予定のアプリ パッケージを追加します。 アプリ パッケージの一部であるを使用して[スターター プロジェクト パッケージ](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages)github アプリ パッケージを使用していない場合。 パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。 (手順 9)、アプリをインストールする前に、デバイスにインストールされている証明書が必要です。

スタート プロジェクトの web アプリケーションで新しいフォルダーがという名前の web アプリケーションに追加された`packages`配布するアプリ パッケージを格納しています。 Visual Studio で、フォルダーを作成するソリューション エクスプ ローラー、選択のルートを右クリックして**追加** -> **新しいフォルダー**名前を付けます`packages`します。 アプリ パッケージをフォルダーに追加する右クリック、`packages`フォルダーと選択**追加** -> **既存の項目.** し、アプリ パッケージの場所を参照します。 

![パッケージを追加します。](images/add-package.png)

## <a name="step-6---create-a-web-page"></a>手順 6 - Web ページの作成

このサンプル web アプリでは、単純な HTML を使用します。 ニーズに合わせて必要に応じて、web アプリをビルドしてかまいません。 

ソリューション エクスプ ローラーのルート プロジェクトを右クリックして**追加** -> **新しい項目の**、し、新しい追加**HTML ページ**から、 **Web**セクション。

HTML ページが作成されると、ソリューション エクスプ ローラーで HTML ページを右クリックし、選択**スタート ページとして設定**します。  

コード エディター ウィンドウで開く、HTML ファイルをダブルクリックします。 このチュートリアルでは、Windows 10 アプリをインストールするには、正常にアプリ インストーラー アプリを起動する web ページで、必要な内の要素のみが使用されます。 

Web ページでは、次の HTML コードを追加します。 キーが正常に呼び出すアプリのインストーラーは、アプリのインストーラーは、OS を登録するカスタムのスキームを使用する:`ms-appinstaller:?source=`します。 詳細については、次のコード例を参照してください。

> [!NOTE]
> カスタムのスキームに一致するプロジェクトの Url、VS ソリューションの [web] タブで後に指定された URL パスを確認します。
 
```HTML
<html>
<head>
    <meta charset="utf-8" />
    <title> Install Page </title>
</head>
<body>
    <a href="ms-appinstaller:?source=http://localhost/SampleWebApp/packages/MySampleApp.appxbundle"> Install My Sample App</a>
</body>
</html>
```

## <a name="step-7---configure-the-web-app-for-app-package-mime-types"></a>手順 7 - アプリ パッケージの MIME の種類の web アプリの構成

開く、 **Web.config**ソリューション エクスプ ローラーからファイルを開き内で次の行を追加、`<configuration>`要素。 

```xml
<system.webServer>
    <!--This is to allow the web server to serve resources with the appropriate file extension-->
    <staticContent>
      <mimeMap fileExtension=".appx" mimeType="application/appx" />
      <mimeMap fileExtension=".msix" mimeType="application/msix" />
      <mimeMap fileExtension=".appxbundle" mimeType="application/appxbundle" />
      <mimeMap fileExtension=".msixbundle" mimeType="application/msixbundle" />
      <mimeMap fileExtension=".appinstaller" mimeType="application/appinstaller" />
    </staticContent>
</system.webServer>
```

## <a name="step-8---add-loopback-exemption-for-app-installer"></a>手順 8 - アプリのインストーラーのループバックの免除を追加

ネットワークの分離によりアプリのインストーラーのような UWP アプリはなど、IP ループバック アドレスの使用に制限 http://localhost/します。 ローカル IIS サーバーを使用する場合、アプリのインストーラーはループバックの除外リストに追加する必要があります。 

これを行うには、開く**コマンド プロンプト**として、**管理者**」と入力します: '' コマンド ライン CheckNetIsolation.exe LoopbackExempt-a-n="microsoft.desktopappinstaller_8wekyb3d8bbwe"
```

To verify that the app is added to the exempt list, use the following command to display the apps in the loopback exempt list: 
```Command Line
CheckNetIsolation.exe LoopbackExempt -s
```

検索する必要があります`microsoft.desktopappinstaller_8wekyb3d8bbwe`一覧にします。

アプリのインストーラーを使用してアプリのインストールのローカルな検証が完了すると、この手順で追加したループバックの免除を削除できます。

'' コマンド ライン CheckNetIsolation.exe LoopbackExempt-d-n="microsoft.desktopappinstaller_8wekyb3d8bbwe"
```

## Step 9 - Run the Web App 

Build and run the web application by clicking on the run button on the VS Ribbon as shown in the image below:

![run](images/run.png)

A web page will open in your browser:

![web page](images/web-page.png)

Click on the link in the web page to launch the App Installer app and install your Windows 10 app package.


## Troubleshooting issues

### Not sufficient privilege 

If running the web app in Visual Studio displays an error such as "You do not have sufficient privilege to access IIS web sites on your machine", you will need to run Visual Studio as an administrator. Close the current instance of Visual Studio and reopen it as an admin.

### Set start page 

If running the web app causes the browser to load with an HTTP 403.14 - Forbidden error, it's because the web app doesn't have a defined start page. Refer to Step 6 in this tutorial to learn how to define a start page.
