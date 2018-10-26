---
author: v-angraf
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.author: v-angraf
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: cc2168014e714de0b43b6ffffe84126764f0a4a3
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5560967"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a>Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報

最新の更新プログラム ユニバーサル Windows プラットフォーム (UWP) Xbox One でにはは、次の新機能、既存の機能やバグ修正する更新プログラムが含まれます。

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a>x86 アプリやゲームは Xbox でサポートされなくなった  
Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a>アプリは、前のアプリに戻る移動でサポートできます。 
アプリが Xbox One の UWP では、前のアプリに戻る移動をサポートできますできるようになりました。 これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。

> [!NOTE]
> 互換性の理由から、この機能は、Xbox One の UWP の最新リリースに組み込まれているアプリでのみ利用可能です。 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a>Dev Home は開発コンソールで既定のホーム エクスペリエンスができるようになりました。
今すぐ開発コンソールは、既定のホーム エクスペリエンスとして Dev Home を起動します。 これにより、製品版ホーム画面からクリックスルーすることがなく動作する適切なできます。 Dev Home には、製品版ホーム画面を起動するクイック アクションが含まれています。 また、新しい設定には、既定のエクスペリエンスを小売ホームようにすることができます。 

## <a name="new-dev-home-user-interface"></a>Dev Home の新しいユーザー インターフェイス
Dev Home のユーザー インターフェイスには、次の生産性向上にはできるようになりましたが含まれています。
 - 重要なデータなどの IP アドレスと回復のバージョンがの可視性で、画面の上部に表示されるようになりました。 
 - Dev Home は、タブ UI 論理セットにツールをグループ化されているすばやいナビゲーションを許可するようになりました。
 - Dev Home の最初のタブのクイック アクション ボタンでは、最もよく使われる操作を高速アクセスを許可します。 

## <a name="wdp-for-xbox-enhancements"></a>Xbox の機能強化 WDP
Windows Device Portal (WDP) には、コンソールの設定の追加のサポートが含まれています。 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a>これで、"App"と"Game"の間で UWP タイトルの種類を切り替えることができます。
"App"と「ゲーム」の間で UWP タイトルの種類を切り替えるには、ストアに公開することがなくゲーム シナリオをテストすることができます。 Dev home では、**ゲームとアプリ**のウィンドウで、アプリを選択、コント ローラーのビュー ボタンを押して、**アプリの詳細**を選択およびの種類を"App"または"Game"に変更します。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
