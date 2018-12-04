---
title: Azure Web サーバーからの UWP アプリのインストール
description: このチュートリアルでは、Azure Web サーバーをセットアップし、Web アプリでアプリ パッケージをホストできることを確認し、アプリ インストーラを効果的に起動して使用する方法を示しています。
ms.date: 11/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ、Azure Web サーバー
ms.localizationpriority: medium
ms.openlocfilehash: 074a8e9941d4314bb35c28b0ee296e9d86fa23a5
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8469213"
---
# <a name="install-a-uwp-app-from-an-azure-web-app"></a>Azure Web アプリからの UWP アプリのインストール

アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。 これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。

このトピックでは、Azure Web サーバーが UWP アプリ パッケージをホストするように構成し、アプリ インストーラー アプリを使用してアプリ パッケージをインストールする手順を示しています。

## <a name="setup"></a>セットアップ

このチュートリアに正常に従うには、以下が必要になります。
 
1. Microsoft Azure サブスクリプション 
2. UWP アプリ パッケージ - 配布するアプリ パッケージ

オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。

### <a name="step-1---get-an-azure-subscription"></a>手順 1 - Azure サブスクリプションの取得
Azure サブスクリプションを取得するには、[Azure アカウント ページ](https://azure.microsoft.com/free/)にアクセスしてください。 このチュートリアルの目的上、無料のメンバーシップを使用できます。

### <a name="step-2---create-an-azure-web-app"></a>手順 2 - Azure Web アプリの作成 
Azure Portal ページで、**[+ Create a Resource] (+ リソースの作成)** ボタンをクリックし、**[Web アプリ]** を選択します。

![作成](images/azure-create-app.png)

一意の **[アプリ名]** を作成し、残りのフィールドは既定値のままにします。 **[作成]** をクリックして Web アプリの作成ウィザードを閉じます。 

![Web アプリの作成](images/azure-create-app-2.png)

### <a name="step-3---hosting-the-app-package-and-the-web-page"></a>手順 3 - アプリ パッケージと Web ページのホスト 
Web アプリを作成したら、Azure ポータルでダッシュ ボードからアクセスできます。 この手順では、Azure ポータルの GUI を備えた簡単な Web ページを作成します。

新規に作成した Web アプリをダッシュ ボードから選択した後、検索フィールドを使用して **App Service エディター** を見つけて開きます。 

エディターには、既定の `hostingstart.html` ファイルがあります。 エクスプローラー パネルの空白領域を右クリックし、**[ファイルのアップロード]** を選択してアプリ パッケージのアップロードを開始します。

> [!NOTE]
> 利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。 パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。 アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。

![アップロード](images/azure-upload-file.png)

エクスプ ローラー パネルの空白領域を右クリックし、**[新しいファイル]** を選択して新しいファイルを作成します。 ファイルに `default.html` という名前を付けます。

[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) で提供されたアプリ パッケージを使用している場合は、次の HTML コードをコピーして `default.html` という Web ページを新規に作成します。 独自のアプリ パッケージを使用している場合は、アプリ サービスの URL (`source=` の後の URL) を変更します。 Azure ポータルで、アプリの概要ページから、アプリ サービスの URL を取得できます。

```html
<html>
<head>
    <meta charset="utf-8" />
    <title> Install My Sample App</title>
</head>
<body>
    <a href="ms-appinstaller:?source=https://appinstaller-azure-demo.azurewebsites.net/MySampleApp.appxbundle"> Install My Sample App</a>
</body>
</html>
```

### <a name="step-4---configure-the-web-app-for-app-package-mime-types"></a>手順 4 - アプリ パッケージの MIME タイプ用の Web アプリの構成

新しいファイルを `Web.config` という名前の Web アプリに追加します。 エクスプローラーから `Web.config` ファイルを開き、次の行を追加します。 

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
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
</configuration>
```

### <a name="step-5---run-and-test"></a>手順 5 - 実行とテスト

作成した Web ページを起動するには、手順 3 の URL を `/default.html` に続けてブラウザーに貼り付けます。 

![エッジ](images/edge.png)

[Install My Sample App] (マイ サンプル アプリのインストール) をクリックしてアプリ インストーラーを起動し、アプリ パッケージをインストールします。 

## <a name="troubleshooting-issues"></a>問題のトラブルシューティング

### <a name="app-installer-app-fails-to-install"></a>アプリ インストーラー アプリのインストールの失敗 
アプリ パッケージの署名に使用されている証明書がデバイスにインストールされていない場合、アプリのインストールは失敗します。 これを修正するには、アプリのインストール前に証明書をインストールする必要があります。 一般配布用アプリ パッケージをホストしている場合は、証明機関からの証明書を使用してアプリ パッケージを署名することをお勧めします。 

![アプリ認定](images/aws-app-cert.png)

### <a name="nothing-happens-when-you-click-the-link"></a>リンクをクリックしても何も反応がない 
アプリ インストーラー アプリがインストールされていることを確認します。 **[設定]** -> **[アプリと機能]** に移動し、インストールされたアプリの一覧でアプリ インストーラーを見つけます。 

