---
author: aablackm
title: Xbox One 本体上でのテスト
description: Xbox Live 本体で Xbox Live サービスをテストする方法について説明します
ms.author: aablackm
ms.date: 08/15/2018
ms.topic: article
keywords: windows 10, uwp, ゲーム、xbox、xbox live, xbox one
ms.localizationpriority: low
ms.openlocfilehash: 4958cdf5ee0fd0788118dc818564c2c8538dd716
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6031962"
---
# <a name="testing-on-the-xbox-one-console"></a>Xbox One 本体上でのテスト

Xbox One 本体のファミリのタイトルを開発するときは、自然タイトルと実際の本体で Xbox Live の機能をテストすることができるようにすることはのみ。 ハードウェアでタイトルをテストするためのいくつかのオプションがあります。 本体の開発者モードのアクティブ化をユニバーサル Windows プラットフォーム (UWP) のタイトルやアプリをテストするのに、市販の Xbox One 本体を使用することができます。 このオプションはすべての開発者にアクセスできるように、Xbox Live クリエーターズ プログラムの開発者の唯一のオプションです。 ID@Xboxおよび対象パートナー順序と Xbox 開発キットを使用するオプションがあります。

## <a name="retail-console-testing-xbox-live-creators"></a>製品版の本体のテスト: Xbox Live クリエーターズ

Xbox One の製品版本体で開発者モードをアクティブ化と Xbox One 本体に Visual Studio のビルドにペアリングして UWP タイトルとアプリを展開できます。 これは、Xbox Live クリエーターズ プログラム開発者向けのオプションのテスト コンソールです。 製品版の Xbox One 本体で XDK ゲームをテストすることはできません。

* 開発製品版の本体でテストできるようにする[開発者モードのアクティブ化手順](../xbox-apps/devkit-activation.md)に従います。  
* [の設定](../xbox-apps/development-environment-setup.md#setting-up-your-xbox-one)に従って、Xbox One にタイトルを読み込みます。  
* 本体をリテール モードに戻す、または製品版の本体で開発環境をアンインストールする[開発者モードの非アクティブ化手順](../xbox-apps/devkit-deactivation.md)に従います。  
* 本体が開発者モードではアクセスできますがリモートでお使いの PC で[Xbox 用の Windows デバイス ポータル](../debug-test-perf/device-portal-xbox.md)を使用しています。  

## <a name="xbox-development-kit-testing-idxbox-and-managed-partners"></a>Xbox 開発キットのテスト:ID@Xboxおよび対象パートナー

対象パートナー向けとID@Xbox開発者になるだけがアクセスできる管理対象の開発者アカウントを持つ、 [Xbox デベロッパー ストア](https://gamedevstore.partners.extranet.microsoft.com/)から、Xbox 開発キットを購入するオプションがあります。 Xbox 開発キット グランド XDK をロードするコンソールにゲームをテストするため、UWP ゲームを開発キットを調べることもできます。 開発キットは、ハードウェア オプションと詳細なパフォーマンスのテストと本体の管理を使用するテスト機能が付属します。

Xbox 開発者とへの取り組みを開始するには、キットは、 [Xbox One の開発の記事をはじめ](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-getting-started)対象パートナーのドキュメントのサイトを読み取ります。 このドキュメントは、承認された開発者にアクセスできるようにのみ、ID@Xboxプログラムおよび対象パートナーです。