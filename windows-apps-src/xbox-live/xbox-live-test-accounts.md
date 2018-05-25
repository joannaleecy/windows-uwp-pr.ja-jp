---
title: Xbox Live テスト アカウント
author: KevinAsgari
description: 開発中に Xbox Live 対応ゲームをテストするためのテスト アカウントを作成する方法について説明します。
ms.assetid: e8076233-c93c-4961-86ac-27ec74917ebc
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, テスト アカウント
ms.localizationpriority: low
ms.openlocfilehash: d0457e477eeb21499c4062b6cc1902eabdd9f1e5
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="xbox-live-test-accounts"></a>Xbox Live テスト アカウント

開発中にタイトルの機能をテストするときに、追加の Xbox Live アカウントを作成すると便利な場合があります。  たとえば、実績がまったくない新しいアカウントが必要な場合です。  または、ソーシャル シナリオをテストするために、いくつかのアカウントを作り、お互いのフレンドにする必要がある場合です。

複数の Microsoft アカウント (MSA) を作成するのは非常に時間がかかることがあるため、多数のテスト アカウントを一度に作成する簡単な方法が用意されています。

テスト アカウントには、他にもいくつかの利点があります。  通常の MSA ではセキュリティに関する制限によってサインインできない*開発サンドボックス*にサインインできます。  *開発サンドボックス*を知らない場合は、「[Xbox Live のサンドボックス](xbox-live-sandboxes.md)」を参照してください。

## <a name="types-of-test-accounts"></a>テスト アカウントの種類

テスト アカウントには 2 つのオプションがあります。  開発サンド ボックスで動作するようにプロビジョニングされている通常の MSA と、開発サンドボックスのみで動作するテスト アカウントです。

Xbox Live クリエーターズ プログラムでタイトルを開発している場合、開発サンドボックス用にプロビジョニングされている通常の MSA しか使用できません。

以下で、両方の種類を作成する方法を説明します。

## <a name="provisioning-regular-msas"></a>通常の MSA のプロビジョニング

既存の Xbox Live アカウントがある場合、それを開発サンドボックスで使用できるようにプロビジョニングするのがお勧めです。

既存の Xbox Live アカウントがないか、追加の MSA が必要な場合は、[https://account.microsoft.com/account](https://account.microsoft.com/account) でアカウントをいくつか作成できます。

## <a name="creating-test-accounts"></a>テスト アカウントの作成

ID@Xbox 開発者である場合、開発サンドボックス専用のテスト アカウントを作成することもできます。  一度に複数のテスト アカウントを作成することもできます。

デベロッパー センターのテスト アカウント管理ページに移動するには
1. デベロッパー センター ダッシュボードに移動します。
2. 右上隅のギア アイコンをクリックして、アカウント設定に進みます。
3. [テスト アカウント] をクリックします。

以下は、この場所を示すスクリーンショットです。

![](images/getting_started/devcenter_testaccount_nav.png)

[テスト アカウント] をクリックすると、既存のテスト アカウントがある場合はその概要が表示されます。  新しいテスト アカウントを作成するオプションもあります。

![](images/getting_started/devcenter_testaccount_summary.png)

[新しいテスト アカウント] をクリックすると、テスト アカウントの作成に使用できるフォームが表示されます。

![](images/getting_started/devcenter_testaccount_new.png)

作成したテスト アカウントはプレフィックスとして開発サンドボックスの名前が付けられ、自動的に開発サンドボックスへのアクセス権が付与されます。
