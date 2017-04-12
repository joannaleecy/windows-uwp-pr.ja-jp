---
author: v-angraf
title: "Xbox One の UWP の新着情報"
description: "Xbox One の UWP アプリの新機能について説明します。"
ms.author: v-angraf
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: fe63c527-8f06-43a5-868f-de909f5664b3
ms.openlocfilehash: 5546177401630e8938f0d25d77ea42afdbfb55d7
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="whats-new-for-developers-in-the-latest-update-of-uwp-on-xbox-one"></a>Xbox One の UWP の最新の更新プログラムにおける開発者向け新着情報

Xbox One のユニバーサル Windows プラットフォーム (UWP) の 2016 年 7 月リリースには、次の新しい機能、既存の機能の更新、バグ修正が含まれています。

## <a name="networking-using-tcpudp-sockets-is-now-available"></a>TCP/UDP ソケットを使用するネットワークを利用可能  
従来の TCP/UDP ソケット (WinSock、Windows.Networking.Sockets) を使用するコンソールからの入力方向と出力方向のネットワーク アクセスが利用できるようになりました。

## <a name="fiddler-support"></a>Fiddler のサポート
Xbox One の UWP を有効にしたコンソールのプロキシとして、Fiddler を有効にすることができるようになりました。 Fiddler によって、Xbox サービスと証明書利用者 Web サービスとの間のすべての HTTP および HTTPS トラフィックをログに記録し、検査することができます。 詳しくは、「[UWP を開発するときに、Xbox One で Fiddler を使用する方法](uwp-fiddler.md)」をご覧ください。

## <a name="mouse-mode-is-now-enabled-by-default"></a>既定で有効になったマウス モード
マウス モードが XAML とホストされた Web アプリを対象に既定で有効になりました。
コントローラーの方向移動操作を最適化するため、マウス モードは無効にすることを強くお勧めします。
マウス モードを無効にする方法については、「[マウス モードを無効にする方法](how-to-disable-mouse-mode.md)」をご覧ください。
Xbox 用の優れたアプリを作成する方法について詳しくは、「[Xbox およびテレビ向け設計](../input-and-devices/designing-for-tv.md#mouse-mode)」をご覧ください。

## <a name="extended-uwp-api-surface-area-is-now-functional-on-the-console"></a>拡張された UWP API サーフェイス領域がコンソールで機能するようになりました
追加の UWP API が Xbox コンソールで機能するようになりました。 UWP API のサポートについて詳しくは、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkID=760755)」をご覧ください。 

## <a name="background-music-and-audio-capabilities"></a>BGM とオーディオ機能
バック グラウンドで実行するアプリから音楽やオーディオを再生できるようになりました。

## <a name="xaml-improvements"></a>XAML の機能強化
次の機能強化が XAML プラットフォームに追加されました。
-    フォーカス用の四角形が 10 フィート エクスペリエンス向けにスタイル設定されるようになりました。
-    Xbox のサウンドが XAML プラットフォームに組み込まれるようになりました。
-    UI 要素間の XY フォーカス ナビゲーションが向上しました。 

## <a name="you-can-now-change-the-size-of-allocated-developer-storage-on-the-console"></a>コンソールに割り当てられている開発者向け記憶域のサイズを変更できるようになりました
Dev Home アプリの新しい設定では、コンソールに割り当てられている開発者向け記憶域のサイズを大きくしたり小さくしたりできます。 割り当てられている開発者向け記憶域のサイズの変更について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。

## <a name="wdp-tool-enhancements"></a>WDP ツールの機能強化
次の機能強化が Xbox 用 Windows Device Portal (WDP) ツールに追加されました。
 - このツールには、追加のコンソール設定が含まれています。 コンソール設定について詳しくは、「[/ext/settings](wdp-xboxsettings-api.md)」リファレンス トピックをご覧ください。 
 - ユーザーはコンソールでサインインとサインアウトができます。 ユーザーについて詳しくは、「[/ext/user](wdp-user-management.md)」リファレンス トピックをご覧ください。
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## <a name="see-also"></a>関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)
