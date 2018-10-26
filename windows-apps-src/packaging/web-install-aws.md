---
author: laurenhughes
title: Web インストール用に AWS で UWP アプリ パッケージをホストする
description: アプリ インストーラー アプリ経由でアプリのインストールを検証する AWS web サーバーを設定するためのチュートリアル
ms.author: cdon
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、Windows 10, UWP, アプリ インストーラー, AppInstaller, サイドローディングでは、関連セット, オプション パッケージ、AWS
ms.localizationpriority: medium
ms.openlocfilehash: f24abac93e2444a3c9f454c8883902e5db4d31be
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5548836"
---
# <a name="hosting-uwp-app-packages-on-aws-for-web-install"></a>Web インストール用に AWS で UWP アプリ パッケージをホストする

アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。 これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。

このトピックでは、UWP アプリ パッケージをホストする、Amazon Web サービス (AWS) web サイトとアプリ パッケージをインストールするアプリ インストーラー アプリを使用する方法を構成する手順について説明します。

## <a name="setup"></a>セットアップ

このチュートリアに正常に従うには、以下が必要になります。
 
1. AWS サブスクリプション 
2. Web ページ
3. UWP アプリ パッケージ - 配布するアプリ パッケージ

オプション: GitHub での[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。

このチュートリアルについては、セットアップの web ページと AWS でパッケージをホストする方法を経由します。 これによって、AWS サブスクリプションが必要です。 に応じて、操作のスケールは、このチュートリアルに従う無料のメンバーシップを使用できます。 

## <a name="step-1---aws-membership"></a>手順 1 - AWS メンバーシップ
AWS メンバーシップを取得するには、 [AWS アカウントの詳細ページ](https://aws.amazon.com/free/)を参照してください。 このチュートリアルの目的上、無料のメンバーシップを使用できます。

## <a name="step-2---create-an-amazon-s3-bucket"></a>手順 2 -、Amazon S3 バケットを作成します。

Amazon Simple Storage Service (S3) は、AWS の収集、保存データの分析を提供します。 S3 バケットは、UWP アプリ パッケージをホストして配布するための web ページの便利な方法です。 

ログインした後に AWS、資格情報を使って [`Services`検索`S3`します。 

**作成バケット**を選択し、web サイトの**バケット名**を入力します。 プロパティとアクセス許可を設定するためのダイアログ ボックスの指示に従います。 Web サイトから UWP アプリを配布でくためには、**読み取り**と**書き込み**のアクセス許可のバケツを有効にし、**このバケットにパブリック読み取りアクセスを許可**を選択します。

![Amazon S3 バケットにアクセス許可を設定します。](images/aws-permissions.png) 

選択したオプションが反映されるかどうかを確認する概要を確認します。 この手順を完了**作成バケット**をクリックします。 

## <a name="step-3---upload-uwp-app-package-and-web-pages-to-an-s3-bucket"></a>手順 3 - UWP アプリ パッケージと web ページを S3 バケットにアップロードします。

Amazon S3 バケットを作成した 1 つは、Amazon S3 ビューで表示することができます。 このデモ バケットがどのようにの例を次に示します。

![Amazon S3 バケット ビュー](images/aws-post-create.png)

アプリ パッケージと web ページをホストする、Amazon S3 バケットにしたいをアップロードする準備が整いました。 

新しく作成したコンテンツをアップロードするバケットをクリックします。 バケツがまだ何もアップロードされた後に現在空です。 [ **Upload** ] ボタンをクリックし、アプリ パッケージとをアップロードする web ページのファイルを選択します。

> [!NOTE]
> 利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。 パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。 アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。

![アプリ パッケージをアップロードします。](images/aws-upload-package.png)

Amazon S3 バケットを作成するためのアクセス許可と同様に、バケット内のコンテンツも必要**読み取り**、**書き込み**、およびアクセス許可の**このオブジェクトにパブリック読み取りアクセスを許可**します。

テスト web ページでは、アップロードするがない場合は、[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html)からサンプル html ページ (default.html) を使用できます。

> [!IMPORTANT]
> Web ページをアップロードする前に、web ページで、アプリ パッケージの参照が正しいことを確認します。 

アプリのパッケージ参照を取得するには、最初に、アプリ パッケージをアップロードし、アプリ パッケージの URL をコピーします。 適切なアプリ パッケージのパスを反映するように、html web ページを編集します。 詳細については、コード例を参照してください。 

アプリ パッケージへのリンクを参照を取得するのにアップロードされたアプリ パッケージ ファイルを選択して、この例のような場合があります。

![アップロードされたパッケージのパス](images/aws-package-path.png)

**コピー**へのリンク、アプリをパッケージ化し、web ページで、参照を追加します。 

```html
<html>
    <head>
        <meta charset="utf-8" />
        <title> Install My Sample App</title>
    </head>
    <body>
        <a href="ms-appinstaller:?source=https://s3-us-west-2.amazonaws.com/appinstaller-aws-demo/MySampleApp.appxbundle"> Install My Sample App</a>
    </body>
</html>
```
Html ファイルは、Amazon S3 バケットにアップロードします。 **読み取り**し、**書き込み**のアクセスを許可するアクセス許可を設定してください。

## <a name="step-4---test"></a>手順 4: テスト

Web ページ、Amazon S3 バケットには、アップロードは、アップロードされた html ファイルを選択することによって、web ページへのリンクを取得します。

リンクを使用して、web ページを開きます。 に、アプリ パッケージと web ページへのパブリック アクセスを許可するアクセス許可を設定します web ページへのリンクを知っているユーザーにアクセスして、アプリ インストーラーを使用して、UWP アプリ パッケージをインストールすることになります。 アプリ インストーラーが Windows 10 プラットフォームの一部であることに注意します。 開発者は、任意のコードを追加または機能をアプリ インストーラーの使用を有効にするアプリを追加する必要はありません。 

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="app-installer-fails-to-install"></a>アプリ インストーラーがインストールに失敗します。 

デバイス上でアプリ パッケージが署名されている証明書がインストールされていない場合、アプリのインストールは失敗します。 これを修正するには、アプリのインストール前に証明書をインストールする必要があります。 一般配布用アプリ パッケージをホストしている場合、証明機関から証明書を使ってアプリ パッケージに署名するにはお勧めします。 


