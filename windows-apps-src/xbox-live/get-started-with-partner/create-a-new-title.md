---
title: 新しいタイトルを作成する
description: パートナー センターを使用して、Xbox Live の新しいタイトルを作成する方法について説明します。
ms.assetid: b8bd69e6-887a-4b1f-a42d-8affdbec0234
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1aa2447a2044bec9b2013b30c05e45342b763fc3
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8739254"
---
# <a name="create-a-new-title-for-xbox-live"></a>Xbox Live 用の新しいタイトルを作成する

## <a name="introduction"></a>はじめに

コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。  サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。

この記事では、新しいタイトルをセットアップする手順について説明します。前提条件は以下のとおりです。

1. ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。  UWP タイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで動作するタイトルです。
2. [パートナー センター](https://partner.microsoft.com/dashboard)でタイトルを構成します。
3. カスタム ゲーム エンジンを備えた Visual Studio、または Unity のいずれかを使用している。
4. 開発用コンピュータは Windows 10 を実行している。

上記が true に、この記事の残りの部分は、新しいプロジェクトの作成、および Xbox Live サインイン コードの記述されテストされたパートナー センターで構成されているタイトルを取得するために必要なすべての手順について説明します。

> [!NOTE]
> Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。

## <a name="partner-center-setup"></a>パートナー センターのセットアップ

Xbox Live 機能が動作する前提条件として、[パートナー センター](https://partner.microsoft.com/dashboard)で作成した Xbox Live 対応のタイトルが必要です。

### <a name="create-a-microsoft-account"></a>Microsoft アカウントを作成する
Microsoft アカウント (MSA とも呼ばれます) があるない場合は、一度に 1 つを最初に作成する必要があります。[https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486)します。  Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。

### <a name="register-as-an-app-developer"></a>アプリ開発者として登録する
パートナー センターで新しいタイトルを作成することが前に、アプリ開発者として登録する必要があります。

登録するにhttps://developer.microsoft.com/en-us/store/registerし、サインアップ プロセスに従います。

### <a name="create-a-new-uwp-title"></a>新しい UWP タイトルを作成する
次に、UWP タイトルがパートナー センターで定義されている必要があります。  これを実行するには、まずダッシュ ボードに移動します

![](../images/getting_started/first_xbltitle_dashboard.png)

<p>
</p>
<br>
<p>
</p>

次に、新しいタイトルを作成します。  名前を予約する必要があります。

![](../images/getting_started/first_xbltitle_newapp.png)

次に、アプリに関する *[アプリの概要]* ページが表示されます。  Xbox Live を構成するための主要なページは、以下に示すように [サービス] -> [Xbox Live] メニューにあります。

![](../images/getting_started/first_xbltitle_leftnav.png)

<div id="createxblaccount"></div>

## <a name="create-an-xbox-live-account"></a>Xbox Live アカウントを作成する
Xbox Live にサインインするには、Xbox Live アカウントが必要です。  既にアカウントをお持ちで、Xbox One 本体、または Windows 10 の Xbox アプリへのサインインに使用している場合は、そのアカウントを使用できます。

それ以外の場合は、PC で Xbox アプリを開いて、Microsoft アカウントでサインインする必要があります。  これで、Xbox Live で使用できるようになります。

以下に示すように、*[スタート] メニュー*に移動して、「Xbox」と入力すると Xbox アプリを検索できます。

![](../images/getting_started/first_xbltitle_xboxapp.png)

## <a name="next-steps"></a>次の手順
これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。

「[Xbox Live を統合するためのステップ バイ ステップ ガイド](partners-step-by-step-guide.md)」をご覧ください
