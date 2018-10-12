---
title: Xbox Live セットアップ構成
author: shrutimundra
description: Windows デベロッパー センターで Xbox Live セットアップを構成する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Windows デベロッパー センター, Xbox Live セットアップ
ms.openlocfilehash: ba4ab2b6cad1968c3d223f99e80ed024e085e8e4
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4538326"
---
# <a name="configure-xbox-live-setup-on-windows-dev-center"></a>Windows デベロッパー センターでの Xbox Live セットアップの構成

[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)を使うと、ゲームに関連付けられた Xbox Live プロパティの初期セットを構成できます。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[Xbox Live Setup]** (Xbox Live セットアップ) の順に選択して、**[Xbox Live Setup]** (Xbox Live セットアップ) セクションに移動します。
2. このページでは、タイトル名、既定のロケール、製品の種類、デバイス ファミリ、公開開始日を設定できます。 構成の設定が完了したら、**[保存]** ボタンをクリックして変更を確定します。

## <a name="title-names"></a>タイトル名
**[Add localized title]** (ローカライズ タイトルの追加) をクリックすると、製品の名前を入力してローカライズする言語を選択することができます。 ここでは、タイトル名が、申請のプロパティ ページで定義されているローカライズされた製品名にマッピングされることに注意してください。 既定値は英語 (en-US) です。

![デベロッパー センターのローカライズ タイトルの追加ダイアログ ボックスの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-1.png)

## <a name="default-locale"></a>既定のロケール
このオプションでは、Xbox Live サービス構成のすべての文字列の構成に使用する既定の言語を設定することができます。 たとえば、既定のロケールをスペイン語 (es-ES) に設定して実績を構成する場合、少なくとも、実績の名前と説明にスペイン語が必要です。 言い換えると、実績情報が英語のみの場合、このオプションをスペイン語に設定することはできません。 すべての Xbox Live サービス構成を、既定のロケールと同じバージョンで指定する必要があります。 既定では、既定のロケールは英語 (en-US) に設定されます。
> [!NOTE]
> さらに、[Localized strings] (ローカライズされた文字列) ページではすべての文字列をローカライズできます。  

![デベロッパー センターの既定のロケールを選択するドロップダウンの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-2.png)

## <a name="product-type"></a>製品の種類
このドロップダウン メニューでは、製品の種類を変更できます。 既定値は、種類 **[ゲーム]** です。 選択内容は、使用可能な Xbox Live の機能に影響を与えます。 次の 3 つのオプションから選択できます。
1. アプリ 
2. ゲーム 
3. ゲームの体験版 

![デベロッパー センターの製品の種類を選択するドロップダウンの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-3.png)

## <a name="device-families"></a>デバイス ファミリ
この構成では、タイトルが Xbox Live にアクセスできるデバイスの種類を選択することができます。 既定では、すべてのデバイス ファミリが有効です。 有効にするデバイスをオンにできます。

![デベロッパー センターのデバイス ファミリを選択する選択チェック ボックスの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-4.png)

## <a name="embargo-date"></a>公開開始日
選択した日付によって、Xbox Live 構成がいつ公開されるかが決まります。 変更内容を RETAIL に公開した場合でも、公開開始日になっていなければ公開されません。 詳しい説明は以下のとおりです。
1. 将来の日付を選択した場合、変更内容はその日に公開されます。
2. 過去の日付を選択した場合、変更内容は RETAIL に公開するとすぐに一般公開されます。

日付と時刻の選択コントロールをクリックすると展開され、正確な日付と時刻を選択できます。 **[OK]** をクリックすると、公開開始日が設定されます。

![デベロッパー センターでの公開開始日の設定の画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-5.png)

## <a name="advanced-settings"></a>詳細設定

**[オプションの表示]** をクリックすると、**[Multiple points of presence]** (複数のプレゼンス ポイント) を設定できます。 複数のプレゼンス ポイントを設定すると、同じユーザーが複数のデバイスから同時に Xbox Live にサインインできます。 実績やマルチプレイヤーなどの Xbox Live の機能は、アクセスが制限されます。 このため、このオプションはゲームには推奨されません。 このオプションを有効にするには、チェック ボックスをオンにします。
