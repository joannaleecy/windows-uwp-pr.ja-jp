---
title: デベロッパー センターでのリッチ プレゼンスの構成
author: aablackm
description: Windows デベロッパー センターでリッチ プレゼンス文字列を構成する方法について説明します。
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, リッチ プレゼンス文字列, Windows デベロッパー センター
ms.openlocfilehash: 125d14fe0bf261caf9177a8ef5fa4cdb72b7952b
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5165457"
---
# <a name="configure-rich-presence-on-windows-dev-center"></a>Windows デベロッパー センターでのリッチ プレゼンスの構成

リッチ プレゼンス文字列には、ユーザーのゲーム内のアクティビティが表示されます。 **[フレンドとクラブ]** リストにあるプレイヤーのゲーマータグの下に、Xbox Live ユーザー プロフィールと共に表示されます。 構成済みのリッチ プレゼンス文字列が、プレイしているゲームの名前に付加されます。 BubblePop というゲームを作成し、リッチ プレゼンス文字列 "友だちと一緒にバブルをはじこう" を構成した場合、構成された文字列により状態 "BubblePop - 友だちと一緒にバブルをはじこう" が生成されます。 リッチ プレゼンス文字列が実際にどのように表示されるかを以下で確認できます。

次のスクリーンショットでは、Xbox Live ユーザー **Last Roar** と **Lucha Uno** が、リッチ プレゼンス文字列を使っているゲームをプレイしています。

![フレンド リストの例](../../images/rich_presence/RichPresence_FriendsList_Screen.jpg)

次のスクリーンショットでは、**Lucha Uno** のリッチ プレゼンス文字列全体がプロフィールに表示されています。

![プロフィールの例](../../images/rich_presence/RichPresence_Config_ProfileScreen.jpg)

> [!IMPORTANT]
> リッチ プレゼンス文字列は、Xbox Live クリエーターズ プログラムのタイトルには使用できないため、それらのタイトルには構成できません。 この記事の内容は、ID@Xbox と対象パートナーのタイトル向けです。

## <a name="requirements"></a>要件

リッチ プレゼンス文字列を構成する前に、次の条件を満たしている必要があります。

- Windows 開発アカウントを持っている。
- 開発アカウントが ID@Xboxプログラムに登録されているか、対象パートナーの開発者アカウントとして登録されている。
- タイトルがデベロッパー センターに登録されていて、Xbox Live が有効になっている。

リッチ プレゼンス文字列を使う前に、デベロッパー センター ダッシュボードで構成する必要があります。

## <a name="rich-presence-configuration-page"></a>リッチ プレゼンスの構成ページ

リッチ プレゼンス文字列は、[developer.microsoft.com](https://developer.microsoft.com/windows) からアクセスできるデベロッパー センター ダッシュボードでタイトルの Xbox Live サービスの一部として構成されます。

次の手順に従って、リッチ プレゼンスの構成ページに移動します。

1. developer.microsoft.com で[デベロッパー センター ダッシュボード](https://developer.microsoft.com/windows)に移動します。
2. サインインが要求された場合は、登録されている Windows 開発者アカウントでサインインします。
3. **[概要]** ページで Xbox Live 対応のタイトルまたはアプリを選択します。 リッチ プレゼンス文字列の構成が有効にならないため、クリエイター プログラムのタイトルは選択しないでください。
4. **[サービス]** ドロップダウン リストをクリックして [Xbox Live] を選択します。
5. **[Rich Presence]** (リッチ プレゼンス) リンクまで下にスクロールしてクリックします。

[Rich Presence] (リッチ プレゼンス) ページに、サービスの簡単な説明、新しいリッチ プレゼンス文字列を作成するボタン、以前に構成した文字列の検索可能な一覧が表示されます。 このページでは、新しい文字列を構成するだけでなく、構成した文字列を編集および確認できます。

![リッチ プレゼンス文字列の構成ページの例](../../images/rich_presence/RichPresence_ConfigPage_New.JPG)

> [!NOTE]
> "Playing Net Runner - 月面基地でのマルチプレイヤー デスマッチ (10 キル)" などの文字列 は、データ プラットフォーム 2017 更新プログラムの時点では開発者は使用できません。 データ プラットフォーム 2013 の*変数*は、データ プラットフォーム 2017 では使用できません。 この場合の変数は、キル数の "10" です。 データ プラットフォーム 2017 更新プログラムより後における同等の文字列は、"Playing Net Runner - 月面基地におけるマルチプレイヤー デスマッチ" です。 “Playing Net Runner - メニュー内” も有効なリッチ プレゼンス文字列です。

## <a name="create-a-new-rich-presence-string"></a>新しいリッチ プレゼンス文字列の作成

リッチ プレゼンス文字列を作成するには、**[New Rich Presence string]** (新しいリッチ プレゼンス文字列) ボタンをクリックします。 UI に **[Presence Details]** (プレゼンスの詳細) が表示され、新しいリッチ プレゼンス文字列の **[Unique Rich Presence ID]** (一意のリッチ プレゼンス ID) と **[Display string]** (表示文字列) を入力できます。

![新しいリッチ プレゼンス文字列 UI](../../images/rich_presence/RichPresence_Config_NewString.JPG)

**[Unique Rich Presence ID]** 一意のリッチ プレゼンス ID - 一意のリッチ プレゼンス ID は、リッチ プレゼンス文字列を識別するための文字列です。 この文字列は、ゲームのプレイヤーの状態を設定するために使用され、表示する特定の文字列に関連付けられます。 ID の上限は 50 文字です。

**[Display string]** (表示文字列) - 表示文字列は、ゲームをプレイしているゲーマーの状態に加えて表示する文字列です。 ここには、ゲームへの興味を誘うために表示するリッチ プレゼンス文字列を入力します。 表示内容は最大 100 文字ですが、先頭の 40 文字のみが表示されるインスタンスがあります。

新しいリッチ プレゼンス文字列を作成するには、両方のフィールドに入力して **[保存]** ボタンを押します。
[保存] をクリックすると、リッチ プレゼンスの構成ページに戻り、新しいリッチ プレゼンス文字列が構成した文字列の一覧に追加されているのがわかります。

## <a name="review-edit-and-delete-strings"></a>文字列の確認、編集、削除

ここでは、リッチ プレゼンスの構成ページで構成したいくつかの文字列を表示できます。
![構成されたリッチ プレゼンス文字列の例](../../images/rich_presence/RichPresence_ConfigPage_Configured.JPG)

以前に作成した文字列を確認するには、リッチ プレゼンスの構成ページの一覧を参照します。 ここでは、一意のリッチ プレゼンス ID と表示文字列の両方を一緒に確認できます。 タイトルのコードで一意のリッチ プレゼンス ID を使って、リッチ プレゼンス文字列を指定する必要がある場合に役立ちます。

リッチ プレゼンス文字列を編集するには、編集する文字列の **[Unique Rich Presence ID]** (一意のリッチ プレゼンス ID) リンクをクリックします。 新しいリッチ プレゼンス文字列を作成するときと同じ UI が表示され、編集のために現在の文字列設定が表示されます。 編集したら **[保存]** ボタンをクリックし、構成されている文字列を変更内容で更新します。

構成済みのリッチ プレゼンス文字列を削除するには、リッチ プレゼンスの構成ページで削除するリッチ プレゼンス文字列と同じ行にある **[削除]** リンクをクリックします。 削除の確認画面が表示されます。

## <a name="further-reading"></a>参考資料

リッチ プレゼンス機能の詳しい概念情報と実装方法について詳しくは、[リッチ プレゼンスのドキュメント](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/social-platform/rich-presence-strings/rich-presence-strings-overview)をご覧ください。