---
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.date: 03/29/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: aff65e5f1b4771cbb33bc8b8219224042b7bf7e2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660687"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a>Xbox One の UWP の最新の更新プログラムでの開発者向けの新機能

Xbox One のユニバーサル Windows プラットフォーム (UWP) の最新の更新プログラムには、次の新しい機能、既存の機能の更新、バグ修正が含まれています。

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a>x86 アプリおよびゲームの Xbox でのサポート停止  
Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a>アプリは前のアプリに戻る移動をサポート可能に 
Xbox One アプリの UWP では、前のアプリに戻る移動をサポートできるようになりました。 これを行うには、[**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595) イベントにサブスクライブし、イベント ハンドラーで **Handled** プロパティを **false** に設定します。

> [!NOTE]
> 互換性の理由から、この機能は Xbox One で最新リリースの UWP を使って構築されたアプリでのみ利用できます。 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a>Dev Home が開発コンソールにおける既定のホーム エクスペリエンスに
開発コンソールでは、既定のホーム エクスペリエンスとして Dev Home が起動するようになりました。 これにより、製品版のホーム画面でクリックしなくてもすぐに作業を始めることができるようになりました。 Dev Home には、製品版のホーム画面を起動するクイックアクションが追加されました。 また、新しい設定では製品版のホーム画面を既定のエクスペリエンスにすることができます。 

## <a name="new-dev-home-user-interface"></a>新しい Dev Home ユーザー インターフェイス
Dev Home のユーザー インターフェイスに、次の生産性強化機能が追加されました。
 - IP アドレスや回復バージョンなどの重要なデータが、見やすいように画面の上部に表示されるようになりました。 
 - Dev Home は、ツールが論理セットにグループ化されるタブ付き UI になり、すばやいナビゲーションが可能になりました。
 - Dev Home の最初のタブにあるクイックアクション ボタンにより、最もよく使われる操作にすばやくアクセスできるようになりました。 

## <a name="wdp-for-xbox-enhancements"></a>Xbox の機能を強化するための WDP
Windows Device Portal (WDP) にコンソール設定のサポートが追加されました。 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a>"アプリ" と "ゲーム" の間で、UWP タイトルの種類を切り替えることができるようになりました。
"アプリ" と "ゲーム" の間で UWP タイトルの種類を切り替えると、ストアに公開しなくてもゲーム シナリオをテストすることができます。 Dev Home の **[アプリ+ゲーム]** ウィンドウでアプリを選んでコントローラーで [表示] ボタンを押し、**[アプリの詳細]** を選んで種類を "アプリ" または "ゲーム" に変更します。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
