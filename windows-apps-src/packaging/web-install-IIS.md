---
author: laurenhughes
title: IIS サーバーから UWP アプリをインストールする
description: このチュートリアルでは、IIS サーバーをセットアップとことを確認、web アプリをアプリ パッケージをホストを呼び出すアプリ インストーラーを効果的に使用する方法を示します。
ms.author: cdon
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング、関連セット, オプション パッケージ、IIS サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 2898a3450f75379492bae1ade5c85581cc8e5a4e
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5742475"
---
# <a name="install-a-uwp-app-from-an-iis-server"></a>IIS サーバーから UWP アプリをインストールする

このチュートリアルでは、IIS サーバーをセットアップとことを確認、web アプリをアプリ パッケージをホストを呼び出すアプリ インストーラーを効果的に使用する方法を示します。

アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。 これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。 

## <a name="setup"></a>セットアップ

正常に実行するこのチュートリアルで、以下が必要は。

1. Visual Studio 2017  
2. Web 開発ツールと IIS 
3. UWP アプリ パッケージ - 配布するアプリ パッケージ

オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) これは、アプリ パッケージと併用する必要はありませんをこの機能を使用する方法について説明したい場合に役立ちます。

## <a name="step-1---install-iis-and-aspnet"></a>手順 1 - IIS と ASP.NET をインストールします。 

[インターネット インフォメーション サービス](https://www.iis.net/)は、[スタート] メニュー経由でインストールできる Windows 機能です。 **[スタート] メニュー**検索の対象に**有効にする Windows の機能のオンまたはオフに**します。

検索し、**インターネット インフォメーション サービス**を IIS のインストールを選択します。

> [!NOTE]
> [インターネット インフォメーション サービスのすべてのチェック ボックスをオンにする必要はありません。 **インターネット インフォメーション サービス**をチェックすると、選択されているだけで十分です。

また、ASP.NET 4.5 以上をインストールする必要があります。 インストールするには、検索**インターネット インフォメーション サービス] の [World Wide Web サービス アプリケーション開発機能]-> [** します。 ASP.NET 4.5 以上 ASP.NET のバージョンを選択します。

![ASP.NET をインストールします。](images/install-asp.png)

## <a name="step-2---install-visual-studio-2017-and-web-development-tools"></a>手順 2 - Visual Studio 2017 をインストールし、Web 開発ツール 

[Visual Studio 2017 のインストール](https://docs.microsoft.com/visualstudio/install/install-visual-studio)を既にインストールしていない場合。 Visual Studio 2017 を既にある場合は、以下のワークロードがインストールされていることを確認します。 ワークロードがない場合、インストールに存在する、([スタート] メニューからが見つかりません) Visual Studio インストーラーを使用してに従ってください。  

インストール中には、 **ASP.NET と Web 開発**と興味のあるその他のワークロードを選択します。 

インストールが完了したら、Visual Studio を起動し、新しいプロジェクトの作成 (**ファイル** -> **新しいプロジェクト**)。

## <a name="step-3---build-a-web-app"></a>手順 3 - Web アプリを構築

**管理者**として Visual Studio 2017 を起動し、**空**のプロジェクト テンプレートを使って新しい**Visual c# Web アプリケーション**プロジェクトを作成します。 

![新しいプロジェクト](images/sample-web-app.png)

## <a name="step-4---configure-iis-with-our-web-app"></a>手順 4 -、Web アプリでの IIS の構成 

ソリューション エクスプ ローラーで、ルート プロジェクトを右クリックし、[**プロパティ**] を選択します。

Web アプリのプロパティでは、 **Web** ] タブを選択します。**サーバー**のセクションでは、ドロップダウン メニューから**ローカル IIS**を選択し、**仮想ディレクトリの作成**] をクリックします。 

![[web] タブ](images/web-tab.png)

## <a name="step-5---add-an-app-package-to-a-web-application"></a>手順 5: web アプリケーションに、アプリ パッケージを追加します。 

Web アプリケーションに配布する予定のアプリ パッケージを追加します。 利用可能なアプリ パッケージがない場合、GitHub 上に提供されている[スターター プロジェクトのパッケージ](https://github.com/AppInstaller/MySampleWebApp/tree/master/MySampleWebApp/packages)の一部であるアプリのパッケージを使用することができます。 パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。 (手順 9) アプリをインストールする前に、デバイスにインストールされている証明書が必要です。

スターター プロジェクトの web アプリケーションに新しいフォルダーと呼ばれる web アプリに追加された`packages`配布するアプリ パッケージが含まれています。 Visual Studio で、フォルダーを作成するには、ソリューション エクスプ ローラーのルート右クリックし、**追加**] を選択 -> **新しいフォルダー**と名前を付けます`packages`します。 アプリ パッケージをフォルダーを追加するを右クリックして、`packages`フォルダーと [ **Add** -> 、アプリを参照し、**既存の項目**の場所をパッケージ化します。 

![パッケージに追加します。](images/add-package.png)

## <a name="step-6---create-a-web-page"></a>手順 6 - Web ページを作成します。

このサンプルの web アプリでは、単純な HTML を使用します。 自由にお客様のニーズごとに必要に応じて、web アプリを構築します。 

ソリューション エクスプ ローラーのルート プロジェクトを右クリックしてで、**追加**の選択 -> **新しい項目**では、 **Web** ] セクションから新しい**HTML ページ**を追加します。

HTML ページを作成した後は、ソリューション エクスプ ローラーでの HTML ページを右クリックし、**スタート ページに設定**を選択します。  

コード エディター ウィンドウで開く HTML ファイルをダブルクリックします。 このチュートリアルでは、Windows 10 アプリをインストールするには、正常にアプリ インストーラー アプリを起動する web ページで必須要素のみが使用されます。 

次の HTML コードは、web ページに含めます。 アプリ インストーラーを正常に実行するキーは、OS にアプリ インストーラーが登録されるカスタム スキームを使用する:`ms-appinstaller:?source=`します。 詳細については、次のコード例を参照してください。

> [!NOTE]
> カスタム スキームが、VS ソリューションの [web] タブで、プロジェクトの Url と一致する後に指定された URL パスを確認します。
 
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

## <a name="step-7---configure-the-web-app-for-app-package-mime-types"></a>手順 7: アプリ パッケージの MIME タイプ用の web アプリを構成します。

ソリューション エクスプ ローラーから、 **Web.config**ファイルを開き、内で、次の行を追加、`<configuration>`要素です。 

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

## <a name="step-8---add-loopback-exemption-for-app-installer"></a>手順 8 のアプリ インストーラーのループバックに関する除外を追加します。

ネットワークの分離のためアプリ インストーラーなどの UWP アプリがなど、IP ループバック アドレスを使用する制限されてhttp://localhost/します。 ローカル IIS サーバーを使用して、アプリ インストーラーがループバックの除外一覧に追加する必要があります。 

これを行うには、**管理者**として**コマンド プロンプト**を開き、次を入力します: '' コマンド ライン CheckNetIsolation.exe LoopbackExempt-a-n=microsoft.desktopappinstaller_8wekyb3d8bbwe
```

To verify that the app is added to the exempt list, use the following command to display the apps in the loopback exempt list: 
```Command Line
CheckNetIsolation.exe LoopbackExempt -s
```

検索する必要があります`microsoft.desktopappinstaller_8wekyb3d8bbwe`一覧にします。

アプリ インストーラーでアプリのインストールのローカルの検証が完了したら後でこの手順で追加した、ループバックに関する除外を削除できます。

'' コマンド ライン CheckNetIsolation.exe LoopbackExempt-d-n=microsoft.desktopappinstaller_8wekyb3d8bbwe
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
