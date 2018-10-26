---
title: Xbox Live の開発ツール
author: StaceyHaffner
description: Xbox Live 対応タイトルを開発およびテストするために用意されているツールについて説明します。
ms.assetid: 380a29bf-41a7-4817-9c57-f48f2b824b52
ms.author: kevinasg
ms.date: 6/13/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, ツール, プレイヤーのリセット, live trace analyzer, LTA, xbox live アカウント ツール,
ms.localizationpriority: medium
ms.openlocfilehash: 69c1a22c1984ae78a096b7a279225c0e658285e6
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5570156"
---
# <a name="development-tools-for-xbox-live"></a>Xbox Live の開発ツール

ここでは、Xbox Live で開発するときに便利な、さまざまなツールについて説明します。 ツールの多くは、[Xbox Live 開発者ツール GitHub](https://github.com/Microsoft/xbox-live-developer-tools) リポジトリで使用できます。 [デベロッパー ツール ライブラリ](https://www.nuget.org/packages/Microsoft.Xbox.Services.DevTools)を使って独自のカスタム ツールを作成することもできます。 すべてのスタンドアロン開発者ツールは、[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) でダウンロードできます。

> [!NOTE]
> ダウンロードに含まれている MatchSim と XboxLiveCompute ツールは、対象のパートナーのみが使用できますかに登録されているパートナー、[ID@Xbox](http://www.xbox.com/Developers/id)プログラムです。 利用可能な開発者プログラムについて詳しくは、[開発者プログラムの概要](https://docs.microsoft.com/windows/uwp/xbox-live/developer-program-overview)をご覧ください。 

## <a name="global-storage"></a>グローバル ストレージ
グローバル タイトル ストレージは、ロスター、マップ、チャレンジ、アート リソースなど、だれでも読み取ることができるデータの保存に使用されます。 これは、[タイトル ストレージ](../storage-platform/xbox-live-title-storage/xbox-live-title-storage.md)の一種です。 グローバル ストレージ ツールを使って、テスト サンドボックス内でグローバル タイトル ストレージを管理します。 この場合も、データは Windows デベロッパー センターまたは Xbox デベロッパー ポータル (XDP) 経由で RETAIL に公開する必要があります。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。 カスタム ツールは、[デベロッパー ツール ライブラリ](https://www.nuget.org/packages/Microsoft.Xbox.Services.DevTools)を使って作成できます。

## <a name="multiplayer-session-history-viewer"></a>マルチプレイヤー セッション履歴ビューアー
マルチプレイヤー セッション履歴ビューアーでは、マルチプレイヤー セッション ドキュメントの履歴 (削除されたドキュメントを含む) を使ってすべての変更の履歴タイムラインを表示することができます。 MPSD セッション ドキュメントは時間の経過と共に変化するため、このツールを使うとドキュメントで何が行われたかをよく理解することができます。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip でスタンドアロン ツールとして使うことができます。

## <a name="player-data-reset"></a>プレイヤー データ リセット
プレイヤー データ リセット ツールを使うとテスト サンドボックスでプレイヤーのデータをリセットできます。 実績、ランキング、統計、タイトル履歴などのデータをリセットできます。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。 カスタム ツールは、[デベロッパー ツール ライブラリ](https://www.nuget.org/packages/Microsoft.Xbox.Services.DevTools)を使って作成できます。

## <a name="xbox-live-developer-account"></a>Xbox Live 開発者アカウント
Xbox Live 開発者アカウント ツールを使うと、開発者アカウントの認証を管理できます。 プレイヤー リセットやグローバル ストレージなど、開発者の資格情報を必要とする他の開発者ツールを操作するために必要です。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。

## <a name="xbox-live-trace-analyzer"></a>Xbox Live Trace Analyzer
[Xbox Live Trace Analyzer](analyze-service-calls.md) を使うと、すべてのサービス呼び出しをキャプチャーし、呼び出しパターンに違反がないかオフラインで分析できます。 サービス呼び出しトレースをアクティベーションするには、xbtrace コマンド ライン ツールを使用するか、またはより高度なシナリオ向けのプロトコル アクティベーションを使用します。 また、タイトル コードから直接サービス呼び出しトレースをアクティベーションすることもできます。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。

## <a name="xbox-live-account-tool"></a>Xbox Live Account Tool  
[Xbox Live Account Tool](xbox-live-account-tool.md) は、既存のテスト アカウントをゲーム シナリオのテスト用にセットアップするときに使用できるように作られています。 たとえば、Xbox Live Account Tool を使用すると、アカウントのゲーマータグを変更したり、アカウントのフレンド リストに 1000 人のフォロワーをすばやく追加したりできます。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。

## <a name="config-as-source"></a>Config As Source
[Config as Source](https://github.com/Microsoft/xbox-live-developer-tools/blob/master/CONFIGASSOURCE.md) は、詳しい知識のあるユーザーに合わせてマイクロソフトが開発したツールのスイートであり、構成サービスに統合するための公式にサポートされるツールと API を提供します。 これらの Xbox Live サービスは、通常、デベロッパー センターでタイトル用に構成されます。これには、ランキングや実績から、Web サービスや証明書利用者などのサービスが含まれます。 多くのゲーム開発者にとっては、デベロッパー センターを使用することで十分です。 ただし、詳しい知識のあるユーザーの場合は、独自のプロセスとツールに一般的な構成タスクを統合したいという要望があります。  Config as Source は、既存のワークフローとパイプラインへの独自の統合をサポートするためのコマンド ライン ツールと新しい API を提供することで、これらのシナリオをサポートするものです。 このツールは、[開発ツール](https://aka.ms/xboxliveuwptools) zip の一部としてコマンド ラインを通じて使うことができます。
