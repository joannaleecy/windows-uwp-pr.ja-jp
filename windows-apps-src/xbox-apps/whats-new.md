---
author: v-angraf
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.author: v-angraf
ms.date: 03/29/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: cbabe9d31b5b9762320df8e4a92d19ae4e33497d
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "301456"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a>Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報

最新の更新プログラムどこからでも Windows プラットフォーム (UWP) Xbox 1 つ上にはには、次の新機能更新を既存の機能、バグの修正などにはが含まれています。

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a>x86 アプリとゲーム Xbox ではサポートされません。  
Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a>アプリが前アプリに移動をサポートできるようになりました 
UWP の Xbox を 1 つのアプリでは、前のアプリケーションに戻ることができますなりました。 これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。

> [!NOTE]
> 互換性のために、この機能を使用できるの UWP Xbox 1 つ上の最新リリースに組み込まれているアプリのみです。 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a>開発ホームが、既定のホーム エクスペリエンス開発コンソール
開発コンソールとして、既定のホーム エクスペリエンス Dev ホームを起動します。 これにより、販売のホーム画面から順にクリックする必要はありません。 作業を簡単に見つけることができます。 開発ホームには、販売のホーム画面を起動するクイック操作が含まれています。 また、新しい設定を使用すると、既定の動作を小売ホームことできます。 

## <a name="new-dev-home-user-interface"></a>新しい開発ホーム ユーザー インターフェイス
開発ホーム ユーザー インターフェイスでは、次の生産性の向上できるようになりました。
 - IP アドレス重要なデータを見やすくするための画面の上部にある回復のバージョンが表示されます。 
 - 開発ホームのタブ表示の UI 論理セットにツールをグループ化されているクイック操作するようになりました。
 - 開発ホームの最初のタブにクイック アクション ボタンは、最も頻繁に使われるアクションにすばやくアクセスを使用します。 

## <a name="wdp-for-xbox-enhancements"></a>Xbox の機能強化 WDP
Windows デバイス ポータル (WDP) には、コンソール設定の追加のサポートが含まれています。 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a>"App"と「ゲーム」の UWP タイトルの種類を切り替えることができるようになりました
"App"と「ゲーム」の UWP タイトルの種類の移行するには、ストアに公開せずにゲームのシナリオをテストすることができます。 開発ホーム]、[は、**ゲームとアプリ**のウィンドウで、アプリを選びます、コント ローラーの表示] ボタンを押して、[**アプリの詳細**を選択し、「アプリ」または「ゲーム」の種類を変更します。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
