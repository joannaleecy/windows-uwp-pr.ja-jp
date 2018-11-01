---
author: v-angraf
ms.assetid: a56156e4-7adb-bf37-527b-fc3243e04b46
title: コンソール (Dev Home) における開発者ホーム
description: Xbox one Dev Home アプリについてを説明します。
ms.author: v-angraf@microsoft.com
ms.date: 08/09/2017
ms.topic: article
keywords: Windows 10, UWP
permalink: en-us/docs/xdk/dev-home.html
ms.localizationpriority: medium
ms.openlocfilehash: 232770ab4b746663a105982605d1cedcb92adbe3
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5884943"
---
# <a name="developer-home-on-the-console-dev-home"></a>コンソール (Dev Home) における開発者ホーム
   
  
Dev Home は、開発者の生産性を支援するために設計された Xbox One 開発キット上のツール エクスペリエンスです。 Dev Home は、管理し、開発キットを構成、ユーザーの管理、インストールされているタイトルを起動および実行するための機能をキャプチャし、トレースを提供します。 将来のリリースで引き続きお客様のフィードバックに基づいて、追加の機能を有効にして、拡張機能と、独自のツールの追加を有効にする機能を拡張します。   
   
  
Dev Home と表示をサポートする最も興味のあるシナリオでフィードバックは、非常に関心を持つしています。 アプリのメイン メニューの [**フィードバックの送信**に説明した方法またはデベロッパー アカウント マネージャー (DAM) を通じて、コメントを提供してください。   
   
  
2015 年 11 月で Dev Home またはそれ以降の回復を起動します。  
 
   1. Home で左または double Nexus ボタンをクリックすると移動することで、ガイドを開く  
   1. **設定**(歯車アイコン) を作成します。   
   1. **すべての設定**を選択します。  
   1. 既定の**開発者**のページから**開発者 Home** (ホーム アイコン) を選択します   

 ![](images/dev_home_icons.png)   
  
以前の回復の**コンテンツの機能を備えた**で、ホーム画面の右側にある Dev Home タイルを選択または Xbox One Manager でアプリケーションの一覧を表示し、 **Dev Home**を起動します。   
 ![](images/dev_home_1.png) 
<a id="ID4EBC"></a>

   

## <a name="user-interface"></a>ユーザー インターフェイス  
   
  
Dev Home のユーザー インターフェイスのヘッダーには、次の重要な"概要"が含まれている開発機本体に関する情報。   
 
   *  **IP をコンソール:** コンソールの現在の IP アドレス。   
   *  **コンソール名:** コンソールの現在のホスト名。  
   *  **サンド ボックス:** コンソールで公開されているサンド ボックスの名前。  
   *  **OS のバージョン:** コンソールで実行されている現在の回復バージョン。
   *  現在のシステム時刻。   

   
  
Dev Home の UI の残りの部分は、次のページに分かれています。 これらのページで、ツールについて詳しくは、個々 のトピックをご覧ください。   
 
   *  [ホーム](devhome-home.md)  
   *  [Xbox Live](devhome-live.md)  
   *  [Settings](devhome-settings.md)  
   *  [メディアのキャプチャ](devhome-capture.md)  
   *  [ネットワーク](devhome-networking.md)  
   *  [パフォーマンス](devhome-performance.md)  

  
<a id="ID4EKE"></a>

   

## <a name="main-menu"></a>メイン メニュー  
   
  
コント ローラーで、**メニュー**ボタンを押して、アプリ] ワークスペースで、ネットワークの場所と、アプリでフィードバックを提供することに関する情報にアクセスするための資格情報を管理する機能の構成が許可されるメイン メニューを表示できます。   
  
<a id="ID4EUE"></a>

   

## <a name="snap-mode-ux"></a>スナップ モード UX  
   
  
マルチプレイヤーでは、ネットワークなど、Dev Home で既存のおよび今後予定されているツールがいくつかはできるようにするツールに簡単にアクセスをテストするときは、タイトルの実行中に、端にスナップするために使用しています。   
   
  
スナップ モードにアクセスするに適切なツールのタイトルを強調表示して、コント ローラーの**ビュー**ボタンを押して、**スナップ**コンテキスト メニューを選択します。  
 ![](images/dev_home_4.png)   
  
Dev Home は右にスナップします。 通常どおり [連結] ボタンをダブル タップすると、コンテキストを切り替えることができます。  
 ![](images/dev_home_5.png)  
<a id="ID4EKF"></a>

   

## <a name="customizing-dev-home"></a>Dev Home のカスタマイズ  
   
  
Dev Home は、カスタマイズして個人用に設定できるように設計されています。 取引先企業、ワークスペースとして保存するワークフローに合わせてアプリを構成できます。 このワークスペースをエクスポートし、できるので、インポートされたとして他の本体をレイアウトにコピーすることです。 これらのオプション **] ワークスペース**で、メイン メニューがあります。 エクスポートされたファイルはシステム スクラッチ ドライブのある、`Dev Home\Workspaces`ディレクトリ。   
 
<a id="ID4EVF"></a>

   

### <a name="resizing-and-reordering-tools"></a>サイズ変更とツールの並べ替え  
   
  
サイズやツールの位置を変更するには、コンテキスト メニュー ボタン (コント ローラーのビュー ボタン) を使用して、タイトルの中にフォーカスがあります。 コンテキスト メニューから**移動**または**サイズ変更**を選択します。   
 ![](images/dev_home_6.png)  
<a id="ID4EEG"></a>

   

### <a name="changing-theme-color-and-background-image"></a>テーマの色と背景画像の変更  
   
  
メイン メニューから**ワークスペース**し、**テーマの色の変更**を選択できます。 新しい色を選択し、**保存**フォーカスが強調表示されたテーマの色を更新する] を選択します。   
 ![](images/dev_home_7.png)  
<a id="ID4EVG"></a>

   

### <a name="setting-the-default-application-for-a-package"></a>パッケージの既定のアプリケーションの設定  
   
  
パッケージに複数のアプリケーションが含まれている場合 Dev Home は、既定アプリケーションを起動するように設定できます。 ランチャーでパッケージを強調表示し、利用可能なアプリケーションの一覧を開く、 **A**ボタンを押します。 既定の設定し**ビュー**ボタンを押すし、**既定として設定**コンテキスト メニューから選択する 1 つを強調表示します。   
 ![](images/dev_home_setdefault.png)  
<a id="ID4EGH"></a>

   

### <a name="using-dev-home-to-register-and-launch-titles-from-a-network-share"></a>Dev Home を使用して登録し、ネットワーク共有からタイトルを起動するには  
   
  
インストールされているアプリとゲームの一覧の下部にある、ランチャーからタイトルのルーズ ファイルのバージョンをリモートで実行する **、ネットワーク共有からゲームの登録**オプションを選択できます。   
 ![](images/dev_home_8.png)   
  
登録するタイトルの appxmanifest.xml ファイルへのネットワーク パスを入力できます。 Dev Home は、共有するため、既存の資格情報を使用してタイトルを登録しようとします。 場合は新しいネットワーク資格情報の入力が必要です。 (たとえばリソースにアクセスするシンボリック リンクされている別のサーバーに) 追加の共有にアクセスする必要がある場合は、次のオプションを通じてこれらを追加する必要があります。   
   
  
これらの保存された資格情報の管理 (して追加)、メイン メニューの**ネットワーク資格情報の管理**オプションを使用してコンソールにします。   
 ![](images/dev_home_9.png)   
  
本体に現在の資格情報を表示、資格情報を編集するには、資格情報のパスを選択し、 **A**ボタンをクリックすると、および資格情報を削除するには、リンクの削除] を選択し、 **A**ボタンをクリックするとことができます。   
   
<a id="ID4EGAAC"></a>

   

## <a name="in-this-section"></a>このセクションの内容  
  
[ホーム ページ (Dev Home)](devhome-home.md)  


&nbsp;&nbsp;開発機本体で定期的に実行されるタスクへのクイック アクセスを提供します。 
  
  
[Xbox Live ページ (Dev Home)](devhome-live.md)  


&nbsp;&nbsp;マルチプレイヤーの情報をキャプチャーし、Xbox Live サービスの現在の状態が表示されます。 
  
  
[[設定] ページ (Dev Home)](devhome-settings.md)  


&nbsp;&nbsp;開発機本体のさまざまな設定をへのアクセスを提供します。 
  
  
[メディア キャプチャ ページ (Dev Home)](devhome-capture.md)  


&nbsp;&nbsp;Dev Home の**メディア キャプチャ**ページでは、コンソールで現在実行されているタイトルのビデオをキャプチャします。 
  
  
[[ネットワーク] ページ (Dev Home)](devhome-networking.md)  


&nbsp;&nbsp;トラブルシューティングのためのさまざまなネットワーク条件をシミュレートします。 
  
  
[パフォーマンス ページ (Dev Home)](devhome-performance.md)  


&nbsp;&nbsp;さまざまなディスクのアクティビティやトラブルシューティングのために、CPU 使用条件をシミュレートします。 
 