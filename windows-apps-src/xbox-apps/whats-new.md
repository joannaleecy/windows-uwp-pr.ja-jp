---
author: v-angraf
title: "Xbox One の UWP の新着情報"
description: "Xbox One の UWP アプリの新機能について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 044aac722180015586487dcc8738facccf209f5c
ms.openlocfilehash: 4cc1e0b495a80e019296b9c3be9e75a37c60224a

---

# Xbox One の UWP の最新の更新プログラムでの開発者向けの新機能

Xbox One のユニバーサル Windows プラットフォーム (UWP) の 2016 年 7 月リリースには、次の新しい機能、既存の機能の更新、バグ修正が含まれています。

## TCP/UDP ソケットを使用するネットワークを利用可能  
従来の TCP/UDP ソケット (WinSock、Windows.Networking.Sockets) を使用するコンソールからの入力方向と出力方向のネットワーク アクセスが利用できるようになりました。

## Fiddler のサポート
Xbox One の UWP を有効にしたコンソールのプロキシとして、Fiddler を有効にすることができるようになりました。 Fiddler によって、Xbox サービスと証明書利用者 Web サービスとの間のすべての HTTP および HTTPS トラフィックをログに記録し、検査することができます。 詳しくは、「[UWP を開発するときに、Xbox One で Fiddler を使用する方法](uwp-fiddler.md)」をご覧ください。

## 既定で有効になったマウス モード
マウス モードが XAML とホストされた Web アプリを対象に既定で有効になりました。
コントローラーの方向移動操作を最適化するため、マウス モードは無効にすることを強くお勧めします。
マウス モードを無効にする方法については、「[マウス モードを無効にする方法](how-to-disable-mouse-mode.md)」をご覧ください。
Xbox 用の優れたアプリを作成する方法について詳しくは、「[Xbox およびテレビ向け設計](../input-and-devices/designing-for-tv.md#mouse-mode)」をご覧ください。

## 拡張された UWP API サーフェイス領域がコンソールで機能するようになりました
追加の UWP API が Xbox コンソールで機能するようになりました。 UWP API のサポートについて詳しくは、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkID=760755)」をご覧ください。 

## BGM とオーディオ機能
バック グラウンドで実行するアプリから音楽やオーディオを再生できるようになりました。

## XAML の機能強化
次の機能強化が XAML プラットフォームに追加されました。
-   フォーカス用の四角形が 10 フィート エクスペリエンス向けにスタイル設定されるようになりました。
-   Xbox のサウンドが XAML プラットフォームに組み込まれるようになりました。
-   UI 要素間の XY フォーカス ナビゲーションが向上しました。 

## コンソールに割り当てられている開発者向け記憶域のサイズを変更できるようになりました
Dev Home アプリの新しい設定では、コンソールに割り当てられている開発者向け記憶域のサイズを大きくしたり小さくしたりできます。 割り当てられている開発者向け記憶域のサイズの変更について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。

## WDP ツールの機能強化
次の機能強化が Xbox 用 Windows Device Portal (WDP) ツールに追加されました。
 - このツールには、追加のコンソール設定が含まれています。 コンソール設定について詳しくは、「[/ext/settings](wdp-xboxsettings-api.md)」リファレンス トピックをご覧ください。 
 - ユーザーはコンソールでサインインとサインアウトができます。 ユーザーについて詳しくは、「[/ext/user](wdp-user-management.md)」リファレンス トピックをご覧ください。
 - コンソールのスクリーンショットをキャプチャできるようになりました。 スクリーンショットのキャプチャについて詳しくは、「[/ext/screenshot](wdp-media-capture-api.md)」リファレンス トピックをご覧ください。
 - このツールでは、アプリの緩やかなファイル ビルドを展開できます。 緩やかなファイル ビルドについて詳しくは、「[/api/app/packagemanager/register](wdp-loose-folder-register-api.md)」リファレンス トピックをご覧ください。
 - コンソールの開発者ファイルには、開発用 PC のエクスプローラーからアクセスできます。 エクスプローラーを介したファイルのアクセスについて詳しくは、「[/ext/smb/developerfolder](wdp-smb-api.md)」リファレンス トピックをご覧ください。

## 関連項目
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO3-->


