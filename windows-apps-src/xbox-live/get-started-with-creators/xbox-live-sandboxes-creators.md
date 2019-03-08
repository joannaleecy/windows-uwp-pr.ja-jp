---
title: Xbox Live のサンドボックス
description: Xbox Live のサンドボックスの概要
ms.assetid: e7daf845-e6cb-4561-9dfa-7cfba882f494
ms.date: 10/30/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f2e5496c9aab2629591a121850685e7f5a1b2fe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590227"
---
# <a name="xbox-live-sandboxes-introduction"></a>Xbox Live のサンドボックスの概要

[サービス構成の Xbox Live](xbox-live-service-configuration-creators.md)記事で、タイトルに関する情報を構成する必要がありますに説明した[パートナー センター](https://partner.microsoft.com/dashboard)します。 この情報には、統計、ランキング、ローカライズなどが含まれます。 Xbox Live サービス構成の変更は、変更 Xbox Live の残りの部分によって取り出され、タイトルにアクセスできる前に、開発サンド ボックスにパートナー センターから公開する必要があります。

開発サンドボックスでは、分離された環境でタイトルへの変更に取り組むことができます。 サンドボックスには、いくつかの利点があります。

1. 現在公開されているバージョンに影響を与えずに、タイトルの更新への変更を反復処理できます。
2. セキュリティ上の理由から、一部のツールは開発サンドボックス内でのみ動作します。
3. 他のパブリッシャーは、サンドボックスへのアクセス権が付与されない限り、その内部での作業内容を閲覧できません。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。 Xbox Live サービス構成のバージョンにアクセスするには、PC や Xbox One を開発サンドボックスに切り替える必要があります。 RETAIL で何かをテストする必要がある場合や、休憩を取ってお気に入りの Xbox Live ゲームをプレイする場合は、デバイスを元の RETAIL サンドボックスに戻す必要がある点に注意してください。

## <a name="finding-out-about-your-sandbox"></a>サンドボックスを調べる

サンドボックスは、タイトルの作成時に作られます。 製品を開くことで、サンド ボックス ID を確認できます**パートナー センター**に移動して**サービス** > **Xbox Live**します。 ページの上部に**サンドボックス ID** が表示されます。

![](../images/getting_started/devcenter_sandbox_id.png)

## <a name="switch-your-pcs-development-sandbox"></a>PC の開発サンドボックスを切り替える
Unity、Windows デバイス ポータル (WPD)、またはコマンド ラインを使って、PC を開発サンドボックスに切り替えることができます。

### <a name="unity"></a>Unity

#### <a name="prerequisites"></a>前提条件
Unity で開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。

1. [構成の Xbox Live Unity で](configure-xbox-live-in-unity.md)

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える
組み込みの Xbox Live の構成ウィンドウを使うと、開発サンドボックスと RETAIL サンドボックスを簡単に切り替えることができます。 開始するには、メニューで **[Xbox Live]** > **[構成]** の順に移動します。 **[Developer Mode Configuration]** セクションに現在のサンドボックスが表示されます。

1. **[Developer Mode]** に **[enabled]** と表示された場合、現在ゲームに関連付けられた開発サンドボックスになっています。 **[Switch back to Retail Mode]** ボタンをクリックすると切り替えることができます。
2. **[Developer Mode]** が **[disabled]** の場合、現在 RETAIL サンドボックスになっています。 **[Switch to Developer Mode]** ボタンをクリックすると再度切り替えることができます。

![XBL 有効](../images/unity/unity-xbl-dev-mode.PNG)

### <a name="windows-device-portal"></a>Windows Device Portal

#### <a name="prerequisites"></a>前提条件
Windows デバイス ポータル (WPD) でサンドボックスに切り替える前に、次の作業を行う必要があります。

1. [Windows デスクトップ上のデバイスのポータルをセットアップします。](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える

1. 「[Windows デスクトップでデバイス ポータルをセットアップする](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)」で説明したように Web ブラウザーで **Windows デバイス ポータル**に接続してこのポータルを開きます。
2. **[Xbox Live]** をクリックします。
3. テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。

![](../images/getting_started/wdp_switch_sandbox.png)

RETAIL に戻るには、ここで「RETAIL」と入力します。

### <a name="command-line"></a>コマンド ライン

#### <a name="prerequisites"></a>前提条件
コマンド ラインを使って開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。

1. [https://aka.ms/xboxliveuwptools  ](https://aka.ms/xboxliveuwptools) で Xbox Live ツール パッケージをダウンロードし、解凍します。

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える
1. **管理者モード**で SwitchSandbox.cmd バッチ ファイルを実行します。

サンドボックスを切り替えるには、管理者モードでこのファイルを実行します。 最初の引数がサンドボックスです。 たとえば、MJJSQH.58 サンドボックスに切り替える場合は、このコマンドを実行します。

```cmd
SwitchSandbox.cmd MJJSQH.58
```

RETAIL に戻るには、単に 2 番目の引数として RETAIL を指定します。

```cmd
SwitchSandbox.cmd RETAIL
```

## <a name="switch-your-xbox-one-console-development-sandbox"></a>Xbox One 本体の開発サンドボックスを切り替える

### <a name="using-xbox-dev-portal"></a>Xbox デベロッパー ポータルの使用

Xbox デベロッパー ポータルを使用して、本体でサンドボックスを変更できます。 これを行うには、使用している本体で [[Dev Home]](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) に移動して[デバイス ポータルを有効](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-xbox)にします。 Xbox デベロッパー ポータルを開いたら、次のようにします。

2. **[Xbox Live]** をクリックします。
3. テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。

![](../images/getting_started/xdp_switch_sandbox.png)

### <a name="using-xbox-one-console-ui"></a>Xbox One 本体の UI を使用する

[Dev Home](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) を使用して、本体で直接サンドボックスを変更できます。

1. **[クイックアクション]** にある **[サンドボックスの変更]** をクリックします。
2. サンドボックス ID を入力し、**[保存すて再起動]** をクリックします。

### <a name="sign-in-with-the-xbox-app"></a>Xbox アプリでサインイン

開発用のタイトルの適切なサンド ボックスを使用する PC を切り替えることをサインイン Xbox Live を対象となるテスト アカウントを持つことを確認します。 サインインしてできます、 [Xbox Live アプリケーション](https://www.xbox.com/en-US/xbox-app)します。 開発環境では、必要なサンド ボックス Xbox アプリを使用してが開始されるとは、サインイン ユーザーとして、他の Xbox Live、同じ制約を使用してサービス、サンド ボックスで実行されています。 これにより、サンド ボックスの有効なアカウントを使用していることを確認するのに便利です。
