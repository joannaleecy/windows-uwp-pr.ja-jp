---
title: Web インストールのための UWP アプリ パッケージの AWS へのホスト
description: アプリ インストーラー アプリを使用してアプリのインストールを検証する AWS web サーバーを設定するためのチュートリアル
ms.date: 05/30/2018
ms.topic: article
keywords: windows 10、Windows 10 では、UWP、関連する設定、省略可能なパッケージ、AWS のアプリ インストーラー、AppInstaller、サイドローディングを行う
ms.localizationpriority: medium
ms.openlocfilehash: 53fe01a1c1a825377e886e042b4eef3868cbf5eb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628057"
---
# <a name="hosting-uwp-app-packages-on-aws-for-web-install"></a>Web インストールのための UWP アプリ パッケージの AWS へのホスト

アプリ インストーラー アプリは、開発者と IT 担当者が、Windows 10 アプリを独自の Content Delivery Network (CDN) でホストすることで配布できるようにします。 これは Microsoft Store にアプリを公開しない、または公開する必要がないが、Windows 10 のパッケージおよび展開のプラットフォームを利用したい企業に役立ちます。

このトピックでは、UWP アプリのパッケージのホストを Amazon Web Services (AWS) の web サイトとアプリのインストーラー アプリを使用して、アプリ パッケージをインストールする方法を構成する手順について説明します。

## <a name="setup"></a>セットアップ

このチュートリアに正常に従うには、以下が必要になります。
 
1. AWS サブスクリプション 
2. Web ページ
3. UWP アプリ パッケージ - 配布するアプリ パッケージ

省略可能: [スタート プロジェクト](https://github.com/AppInstaller/MySampleWebApp)GitHub でします。 これは、使用するアプリ パッケージまたは Web ページがないが、この機能を使用する方法を確認したい場合に便利です。

このチュートリアルは、セットアップの web ページと AWS のパッケージをホストする方法が変わります。 AWS サブスクリプションが必要になります。 によって、スケール操作のでは、このチュートリアルに従うの無料のメンバーシップを使用できます。 

## <a name="step-1---aws-membership"></a>手順 1 - AWS メンバーシップ
AWS のメンバーシップを取得するには、次を参照してください。、 [AWS アカウントの詳細ページ](https://aws.amazon.com/free/)します。 このチュートリアルの目的上、無料のメンバーシップを使用できます。

## <a name="step-2---create-an-amazon-s3-bucket"></a>手順 2 - Amazon S3 バケットの作成

Amazon Simple Storage Service (S3) では、収集、保存、およびデータの分析のための製品、AWS です。 S3 バケットは、UWP アプリのパッケージをホストおよび配布用の web ページに便利な方法です。 

ログイン後 AWS の資格情報を `Services`検索`S3`します。 

選択**を作成するバケット**を入力し、**バケット名**web サイトの。 プロパティとアクセス許可を設定するためのダイアログ プロンプトに従います。 UWP アプリは、web サイトから配布できることを確認するには、有効にする**読み取り**と**書き込み**アクセス許可を選択して、バケット**このバケットにパブリックの読み取りアクセス権を付与**.

![Amazon S3 バケットに権限を設定します。](images/aws-permissions.png) 

選択したオプションが反映されるかどうかを確認する概要を確認します。 クリックして**作成バケット**この手順を完了します。 

## <a name="step-3---upload-uwp-app-package-and-web-pages-to-an-s3-bucket"></a>手順 3 - UWP アプリのパッケージと web ページ、S3 バケットをアップロードします。

Amazon S3 バケットを作成した 1 つ、Amazon S3 ビューで表示することができます。 次のように、デモのバケットの外観の例に示します。

![Amazon S3 バケットのビュー](images/aws-post-create.png)

これで、アプリ パッケージと、Amazon S3 バケットでホストするたい web ページをアップロードする準備が整いました。 

コンテンツのアップロードを新しく作成したバケットをクリックします。 まだ何もアップロードされているため、バケットは現在空です。 をクリックして、**アップロード**ボタンをクリックし、アプリ パッケージとアップロードしたい web ページのファイルを選択します。

> [!NOTE]
> 利用可能なアプリ パッケージがない場合は、提供された GitHub の[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp) リポジトリの一部であるアプリ パッケージを使用できます。 パッケージの署名に使用された証明書 (MySampleApp.cer) も GitHub のサンプルに含まれています。 アプリをインストールする前に、デバイスに証明書がインストールされている必要があります。

![アプリ パッケージをアップロードします。](images/aws-upload-package.png)

Amazon S3 バケットを作成するためのアクセス許可と同様に、バケット内のコンテンツも必要**読み取り**、**書き込み**、および**このオブジェクトにパブリックの読み取りアクセス権を付与**アクセス許可。

Web ページでは、アップロードをテストするには、お持ちでない場合からサンプル html ページ (default.html) を使用することができます、[スターター プロジェクト](https://github.com/AppInstaller/MySampleWebApp/blob/master/MySampleWebApp/default.html)します。

> [!IMPORTANT]
> Web ページをアップロードする前に、web ページでアプリのパッケージ参照が正しいことを確認します。 

アプリ パッケージの参照を取得するには、最初に、アプリ パッケージをアップロードし、アプリ パッケージの URL をコピーします。 正しいアプリ パッケージのパスを反映するように html web ページを編集します。 詳細については、コード例を参照してください。 

アプリ パッケージへの参照リンクを取得するアップロードされたアプリ パッケージ ファイルを選択して、この例のような場合があります。

![アップロードされたパッケージのパス](images/aws-package-path.png)

**コピー**アプリへのリンクをパッケージ化し、web ページで、参照を追加します。 

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
Amazon S3 バケットには、html ファイルをアップロードします。 許可するアクセス許可を設定してください**読み取り**と**書き込み**アクセスします。

## <a name="step-4---test"></a>手順 4 - テスト

Web ページは、Amazon S3 バケットに、アップロードは、アップロードされた html ファイルを選択して web ページへのリンクを取得します。

リンクを使用して、web ページを開きます。 アプリ パッケージと web ページへのパブリック アクセスを付与するアクセス許可を設定しますのでは、アクセスして、アプリのインストーラーを使用して、UWP アプリのパッケージをインストールする web ページへのリンクを持つユーザーはできます。 アプリのインストーラーは、Windows 10 プラットフォームの一部であることに注意してください。 開発者は、アプリのインストーラーの使用を有効にするアプリにコードを追加または機能を追加する必要はありません。 

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="app-installer-fails-to-install"></a>アプリのインストーラーがインストールに失敗します。 

デバイス上でアプリ パッケージが署名された証明書がインストールされていない場合、アプリのインストールは失敗します。 これを修正するには、アプリのインストール前に証明書をインストールする必要があります。 パブリック配布用アプリケーション パッケージをホストしている場合、証明機関から証明書で、アプリ パッケージに署名するがお勧めします。 


