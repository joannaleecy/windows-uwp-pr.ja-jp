---
author: eliotcowley
title: Xbox One ツールの概要
description: Windows デバイス ポータルを使った、Xbox One 固有のツールである Dev Home
ms.author: elcowle
ms.date: 10/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, xbox one, ツール
ms.assetid: 6eaf376f-0d7c-49de-ad78-38e689b43658
ms.localizationpriority: medium
ms.openlocfilehash: f39759b91993bdb641dca9d3029a620ada2ab59c
ms.sourcegitcommit: cceaf2206ec53a3e9155f97f44e4795a7b6a1d78
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2018
ms.locfileid: "1701108"
---
# <a name="introduction-to-xbox-one-tools"></a>Xbox One ツールの概要

このセクションでは、Dev Home アプリを介して Xbox Device Portal にアクセスする方法について説明します。

## <a name="dev-home"></a>Dev Home

Dev Home は、Xbox One 開発キットに含まれ、開発者の生産性をサポートするための 1 つのツール エクスペリエンスです。 Dev Home は、開発キットの管理と構成の機能を提供します。

Dev Home は、開発者モードで本体が起動するときに開かれる既定のアプリです。 Dev Home は、ホーム画面の **[Dev Home]** タイルを選択して開くこともできます。 タイルが表示されていない場合は、本体が開発者モードに設定されていません。

Dev Home について詳しくは、「[コンソール (Dev Home) における開発者ホーム](dev-home.md)」をご覧ください。

## <a name="xbox-device-portal"></a>Xbox Device Portal
Xbox Device Portal は、ブラウザー ベースのデバイス管理ツールであり、ゲームやアプリの追加、Xbox Live テスト アカウントの追加、サンドボックスの変更などを行うことができます。

Xbox One 本体で Xbox Device Portal を有効にするには、次のようにします。

1. ホーム画面で、**Dev Home** タイルを選びます。

  ![Dev Home タイルの選択](images/introduction-to-xbox-one-tools-1.png)

2. Dev Home 内で、**[ホーム]** タブに移動し、**[リモート アクセス]** セクションで、**[リモート アクセス設定]** を選択します。

  ![リモート管理ツール](images/introduction-to-xbox-one-tools-2.png)

3. **[Enable Xbox Device Portal]** (Xbox Device Portal を有効にする) チェックボックスをオンにします。

4. **[Authentication]** (認証) で、**[Require authentication to remotely access this console from the web or PC tools]** (Web または PC ツールからこの本体にリモートでアクセスするときに認証を求める)チェック ボックスをオンにします。

5. **[ユーザー名]** と __[パスワード]__ を入力して、**[保存]** を選びます。 この認証情報はブラウザーから開発キットへのアクセスの認証に使用されます。

6. **[閉じる]** を選択し、**[ホーム]** タブの **[リモート アクセス]** ツールに表示される URL を書き留めます。

7. ブラウザーに URL を入力します。 提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One 本体によって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。 Edge で **[詳細]** をクリックし、**[Go on to the webpage]** (Web ページにアクセス) をクリックして、Xbox Device Portal にアクセスします。

    ![セキュリティ証明書の警告](images/introduction-to-xbox-one-tools-3.png)

8. 構成した資格情報でサインインします。

## <a name="xbox-dev-mode-companion"></a>Xbox 開発者モード コンパニオン
Xbox 開発者モード コンパニオンは、PC から離れずに本体を操作できるツールです。 このアプリを使うと、本体の画面を表示し、入力を本体に送ることができます。 詳しくは、「[Xbox 開発者モード コンパニオン](xbox-dev-mode-companion.md)」をご覧ください。

## <a name="see-also"></a>関連項目
- [UWP を開発するときに、Xbox One で Fiddler を使用する方法](uwp-fiddler.md)
- [Windows Device Portal の概要](../debug-test-perf/device-portal.md)
- [Xbox One の UWP](index.md)