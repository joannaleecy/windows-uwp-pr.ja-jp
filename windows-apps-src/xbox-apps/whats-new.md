---
title: Xbox One の UWP の新着情報
description: Xbox One の UWP アプリの新機能について説明します。
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.localizationpriority: medium
ms.openlocfilehash: aff65e5f1b4771cbb33bc8b8219224042b7bf7e2
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7847581"
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a>Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報

最新の更新プログラム ユニバーサル Windows プラットフォーム (UWP) Xbox one にはには、次の新機能、既存の機能やバグ修正プログラムの更新プログラムが含まれています。

## <a name="x86-apps-and-games-are-no-longer-supported-on-xbox"></a>x86 アプリとゲームが Xbox でサポートされていません  
Xbox では、x86 アプリの開発または x86 アプリのストアへの申請をサポートしなくなりました。

## <a name="apps-can-now-support-navigating-back-to-the-previous-app"></a>アプリは、前のアプリに戻る移動でサポートできます。 
アプリが Xbox One の UWP では、前のアプリに戻る移動をサポートできますできるようになりました。 これを行うには、 [**Windows.UI.Core.SystemNavigationManager.BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893595)イベントをサブスクライブし、 **false**イベント ハンドラーで**Handled**プロパティを設定します。

> [!NOTE]
> 互換性の理由から、この機能は、Xbox One の UWP の最新リリースに組み込まれているアプリでのみ利用可能です。 

## <a name="dev-home-is-now-the-default-home-experience-on-development-consoles"></a>Dev Home は開発コンソールで既定のホーム エクスペリエンスができるようになりました。
今すぐ開発コンソールは既定のホーム エクスペリエンスとして Dev Home を起動します。 これにより、製品版ホーム画面からクリックスルーすることがなく動作する適切なできます。 Dev Home には、製品版ホーム画面を起動するクイック アクションが含まれています。 また、新しい設定を使用すると、既定のエクスペリエンスを小売ホームようにできます。 

## <a name="new-dev-home-user-interface"></a>Dev Home の新しいユーザー インターフェイス
Dev Home のユーザー インターフェイスには、次の生産性向上にはできるようになりましたが含まれています。
 - 重要なデータなどの IP アドレスとの可視性で、画面の上部に回復のバージョンが表示されるようになりました。 
 - Dev Home は、タブ UI 論理セットにツールをグループ化されているすばやいナビゲーションを許可するようになりました。
 - Dev Home の最初のタブのクイック アクション ボタンは、最もよく使われる操作を高速アクセスを許可します。 

## <a name="wdp-for-xbox-enhancements"></a>Xbox の機能強化 WDP
Windows Device Portal (WDP) には、コンソールの設定の追加のサポートが含まれています。 

## <a name="you-can-now-switch-the-type-of-your-uwp-title-between-app-and-game"></a>これで、"App"と「ゲーム」の間で UWP タイトルの種類を切り替えることができます。
"App"と「ゲーム」の間で UWP タイトルの種類を切り替えるには、ストアに公開することがなくゲーム シナリオをテストすることができます。 Dev Home で**ゲームとアプリ**のウィンドウで、アプリを選択、コント ローラーのビュー ボタンを押して**アプリの詳細**を選択し、"App"または「ゲーム」の種類を変更します。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
