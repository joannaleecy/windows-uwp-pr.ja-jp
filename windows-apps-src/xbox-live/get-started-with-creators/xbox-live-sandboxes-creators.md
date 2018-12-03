---
title: Xbox Live のサンドボックス
description: Xbox Live のサンドボックスの概要
ms.assetid: e7daf845-e6cb-4561-9dfa-7cfba882f494
ms.date: 10/30/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f2e5496c9aab2629591a121850685e7f5a1b2fe
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8340999"
---
# <a name="xbox-live-sandboxes-introduction"></a>Xbox Live のサンドボックスの概要

記事では、 [Xbox Live サービス構成](xbox-live-service-configuration-creators.md)、[パートナー センター](https://partner.microsoft.com/dashboard)で、タイトルに関する情報を構成する必要があります説明しました。 この情報には、統計、ランキング、ローカライズなどが含まれます。 Xbox Live サービス構成への変更は、パートナー センターから開発サンド ボックスに前に公開する変更が Xbox Live の残りの部分が取得し、タイトルからアクセスでく必要があります。

開発サンドボックスでは、分離された環境でタイトルへの変更に取り組むことができます。 サンドボックスには、いくつかの利点があります。

1. 現在公開されているバージョンに影響を与えずに、タイトルの更新への変更を反復処理できます。
2. セキュリティ上の理由から、一部のツールは開発サンドボックス内でのみ動作します。
3. 他の公開元は、サンドボックスへのアクセス権が付与されない限り、その内部での作業内容を閲覧できません。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。 Xbox Live サービス構成のバージョンにアクセスするには、PC や Xbox One を開発サンドボックスに切り替える必要があります。 RETAIL で何かをテストする必要がある場合や、休憩を取ってお気に入りの Xbox Live ゲームをプレイする場合は、デバイスを元の RETAIL サンドボックスに戻す必要がある点に注意してください。

## <a name="finding-out-about-your-sandbox"></a>サンドボックスを調べる

サンドボックスは、タイトルの作成時に作られます。 **パートナー センター**で製品を開くと、**サービス**への移動をサンド ボックス ID を検索できます > **Xbox Live**します。 ページの上部に**サンドボックス ID** が表示されます。

![](../images/getting_started/devcenter_sandbox_id.png)

## <a name="switch-your-pcs-development-sandbox"></a>PC の開発サンドボックスを切り替える
Unity、Windows デバイス ポータル (WPD)、またはコマンド ラインを使って、PC を開発サンドボックスに切り替えることができます。

### <a name="unity"></a>Unity

#### <a name="prerequisites"></a>前提条件
Unity で開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。

1. [Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える
組み込みの Xbox Live の構成ウィンドウを使うと、開発サンドボックスと RETAIL サンドボックスを簡単に切り替えることができます。 開始するには、メニューで **[Xbox Live]** > **[構成]** の順に移動します。 **[Developer Mode Configuration]** セクションに現在のサンドボックスが表示されます。

1. **[Developer Mode]** に **[enabled]** と表示された場合、現在ゲームに関連付けられた開発サンドボックスになっています。 **[Switch back to Retail Mode]** ボタンをクリックすると切り替えることができます。
2. **[Developer Mode]** が **[disabled]** の場合、現在 RETAIL サンドボックスになっています。 **[Switch to Developer Mode]** ボタンをクリックすると再度切り替えることができます。

![XBL 有効](../images/unity/unity-xbl-dev-mode.PNG)

### <a name="windows-device-portal"></a>Windows デバイス ポータル

#### <a name="prerequisites"></a>前提条件
Windows デバイス ポータル (WPD) でサンドボックスに切り替える前に、次の作業を行う必要があります。

1. [Windows デスクトップでデバイス ポータルをセットアップする](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える

1. 「[Windows デスクトップでデバイス ポータルをセットアップする](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)」で説明したように Web ブラウザーで **Windows デバイス ポータル**に接続してこのポータルを開きます。
2. **[Xbox Live]** をクリックします。
3. テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。

![](../images/getting_started/wdp_switch_sandbox.png)

RETAIL に戻るには、ここで「RETAIL」と入力します。

### <a name="command-line"></a>コマンド ライン

#### <a name="prerequisites"></a>前提条件
コマンド ラインを使って開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。

1. [https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) で Xbox Live ツール パッケージをダウンロードし、解凍します。

#### <a name="switch-sandboxes"></a>サンドボックスを切り替える
1. **管理者モード**で SwitchSandbox.cmd バッチ ファイルを実行します。

サンドボックスを切り替えるには、管理者モードでこのバッチ ファイルを実行します。 最初の引数がサンドボックスです。 たとえば、MJJSQH.58 サンドボックスに切り替える場合は、このコマンドを実行します。

```cmd
SwitchSandbox.cmd MJJSQH.58
```

RETAIL に戻るには、2 番目の引数として RETAIL を指定するだけです。

```cmd
SwitchSandbox.cmd RETAIL
```

## <a name="switch-your-xbox-one-console-development-sandbox"></a>Xbox One 本体の開発サンドボックスを切り替える

### <a name="using-xbox-dev-portal"></a>Xbox デベロッパー ポータルの使用

Xbox デベロッパー ポータルを使用して、本体でサンドボックスを変更できます。 これを行うには、使用している本体で [[Dev Home]](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) に移動して[デバイス ポータルを有効](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-xbox)にします。 Xbox デベロッパー ポータルを開いたら、次のようにします。

2. **[Xbox Live]** をクリックします。
3. テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。

![](../images/getting_started/xdp_switch_sandbox.png)

### <a name="using-xbox-one-console-ui"></a>Xbox One 本体の UI の使用

[Dev Home](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) を使用して、本体で直接サンドボックスを変更できます。

1. **[クイックアクション]** にある **[サンドボックスの変更]** をクリックします。
2. サンドボックス ID を入力し、**[保存すて再起動]** をクリックします。

### <a name="sign-in-with-the-xbox-app"></a>Xbox アプリにサインイン

開発用に、サインインしている Xbox Live に、テスト対象アカウントを使用することを確認することが、タイトルの適切なサンド ボックスを使用して PC を切り替えることです。 これは、 [Xbox Live のアプリ](https://www.xbox.com/en-US/xbox-app)に署名することで実行できます。 開発環境が起動すると、目的のサンド ボックスの Xbox アプリを使用して、その他の Xbox Live として同じ制約を使用してサインイン ユーザー サービス サンド ボックス内で実行されています。 これにより、サンド ボックスの有効なアカウントを使用していることを確認すると便利です。
