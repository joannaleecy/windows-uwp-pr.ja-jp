---
title: 1 つの Xbox 本体のテスト
description: Xbox Live コンソールで、Xbox Live サービスをテストする方法について説明します
ms.date: 08/15/2018
ms.topic: article
keywords: windows 10、uwp、ゲーム、xbox、xbox live、1 つ xbox
ms.localizationpriority: low
ms.openlocfilehash: aa14071f5ddc9af778fc59cc20891bf83310088b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628017"
---
# <a name="testing-on-the-xbox-one-console"></a>Xbox One のコンソールでのテスト

Xbox One ファミリ コンソールのタイトルを開発するときに、自然のタイトルと実際のコンソールで Xbox Live の機能をテストできるようにすることはのみ。 タイトルのハードウェアをテストするためのいくつかのオプションがあります。 任意の小売 Xbox の 1 つのコンソールを使用するには、コンソールの開発者モードをアクティブ化して、ユニバーサル Windows プラットフォーム (UWP) のタイトルまたはアプリをテストします。 このオプションはすべての開発者にアクセスできる、Xbox Live Creators プログラムの開発者の唯一のオプションです。 ID@Xbox 管理対象のパートナーの順序付けと Xbox 開発キットを使用するオプションがあります。

## <a name="retail-console-testing-xbox-live-creators"></a>小売コンソール テスト:Xbox Live クリエーターズ

Xbox One の小売コンソールで開発者モードをアクティブ化では、Visual Studio のビルドと組み合わせることで、1 つの Xbox コンソールに UWP のタイトルとアプリを配置することを許可します。 これは、オプションとして、Xbox Live Creators プログラム開発者がテスト コンソールです。 小売 Xbox One コンソール上の XDK ゲームをテストすることはできません。

* に従って、[開発者モードのアクティブ化手順](../xbox-apps/devkit-activation.md)小売コンソールにテストの開発を可能にします。  
* 次で Xbox One にタイトルを読み込み、 [Xbox One の手順については、セットアップ](../xbox-apps/development-environment-setup.md#setting-up-your-xbox-one)します。  
* に従って、[開発者モードの非アクティブ化手順](../xbox-apps/devkit-deactivation.md)コンソールを小売モードに戻すまたは小売りコンソールで、開発環境をアンインストールします。  
* コンソールは開発者モード中にアクセスできるリモートを各自のコンピューターを使用して、 [Xbox 用の Windows デバイス ポータル](../debug-test-perf/device-portal-xbox.md)します。  

## <a name="xbox-development-kit-testing-idxbox-and-managed-partners"></a>Xbox 開発キットのテスト:ID@Xboxとパートナーの管理

パートナーの管理とID@Xboxから Xbox 開発者キットを購入することが開発者、 [Xbox デベロッパー ストア](https://gamedevstore.partners.extranet.microsoft.com/)、これはアクセス可能であるマネージ開発者アカウントでのみです。 Xbox 開発者キットを使用する XDK を読み込むコンソール ゲームのテスト、UWP ゲームを開発キットで調べることもできます。 開発者用キット ハードウェア オプションとのより詳細なパフォーマンス テストとコンソールの管理を許可するテストの機能が付属します。

Xbox 開発者キットを読み取り、体験を開始する、 [Xbox の 1 つの開発に関する記事の概要](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-getting-started)管理対象のパートナーのドキュメント サイト。 このドキュメントは承認済みの開発者にアクセスできるのみ、ID@Xboxプログラムおよび管理対象のパートナーです。