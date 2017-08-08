---
author: QuinnRadich
title: "Windows 10 SDK Preview Build 16190 の新機能 - UWP アプリの開発"
description: "Windows 10 SDK Preview Build 16190 では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスが引き続き提供されます。"
keywords: "新着情報, 新機能, 更新, 更新プログラム, 機能, 新規, Windows 10, ビルド, カンファレンス, Insider, フライト, 最新, 16190"
ms.author: quradic
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
msdn.assetid: 0fdde031-97a5-430c-91af-846c5fbb028f
ms.openlocfilehash: 78a2f69cc82899de946f5815f7dc9f07c279d69d
ms.sourcegitcommit: 512a82a782775795e301d6235d0c977c0a9e9c74
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/11/2017
---
# <a name="whats-new-in-windows-10-at-microsoft-build-2017"></a>Microsoft Build 2017 で発表された Windows 10 の新機能

[Microsoft Build 2017 開発者カンファレンス](https://developer.microsoft.com/windows/projects/events/build/2017?ocid=wdgbld17_intreferral_devcenterhp_null_null_devcenter_hppost&utm_campaign=wdgbld17&utm_medium=internalreferral&utm_source=devcenterhp&utm_content=devcenter_hppost)でリリースされた Windows 10 SDK Preview Build 16190 では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスが引き続き提供されます。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)がどのように使えるかを試したりすることができます。

以下の機能紹介とチュートリアルの多くは、Build 2017 カンファレンスで SDK Preview Build と共にリリースされた内容ですが、プレビュー ビルドの使用は必要ありません。 特定の変更内容について詳しくは、[このプレビュー ビルドで追加または更新された API 名前空間のプレリリース ドキュメントをご覧ください](windows-10-build-16190-api-diff.md)。

この更新および他の Windows 更新プログラムでの注目すべき機能について詳しくは、「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。

## <a name="new-features"></a>新機能

### <a name="effects"></a>効果

これらの新しい効果では、重要な UI 要素にユーザーが専念できるように、深度、視点、および動きが使用されています。 これらは SDK Preview Build のみで利用可能です。

[アクリル素材](../style/acrylic.md)は、透明なテクスチャを作成できる、ブラシの種類です。 

![淡色テーマのアクリル](../style/images/Acrylic_DarkTheme_Base.png)

[視差効果](../style/parallax.md)を使用すると、3 次元の深度と視点をアプリに追加できます。

![リストと背景画像を使用した視差の例](../style/images/_Parallax_v2.gif)

[表示](../style/reveal.md)を使用すると、アプリの重要な要素を強調できます。 

![表示のビジュアル効果](../style/images/Nav_Reveal_Animation.gif)


### <a name="controls"></a>コントロール

新しいコントロールを使用すると、優れた外観の UI をすばやく簡単に作成できます。 これらは SDK Preview Build のみで利用可能です。

ユーザーは[カラー ピッカー コントロール](../controls-and-patterns/color-picker.md)を使って、色を自由に確認し、選択できます。  

![既定のカラー ピッカー](../controls-and-patterns/images/color-picker-default.png)

[ナビゲーション ビュー コントロール](../controls-and-patterns/navigationview.md)を使うと、トップレベルのナビゲーションを簡単にアプリに追加できます。  

![ナビゲーション ビューのセクション](../controls-and-patterns/images/navview_sections.png)

[ユーザー画像コントロール](../controls-and-patterns/person-picture.md)では、人物のアバター画像を表示できます。

![ユーザー画像コントロール](../controls-and-patterns/images/person-picture/person-picture_hero.png)

[評価コントロール](../controls-and-patterns/rating.md)では、ユーザーが評価の確認と設定を簡単に行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。

![評価コントロールの例](../controls-and-patterns/images/rating_rs2_doc_ratings_intro.png)

[ツリー ビュー コントロール](../controls-and-patterns/tree-view.md)では、階層リストが作成され、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。

![ツリー ビューでの山形記号アイコンの使用](../controls-and-patterns/images/treeview_chevron.png)
 

#### <a name="keyboard"></a>キーボード

「[キーボード操作](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-interactions)」では、キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを設計および最適化する方法を示します。

Windows アプリの使いやすさとアクセシビリティの両方を高めるには、「[アクセス キー](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/access-keys)」を使います。 アクセス キーの使用は、ポインター デバイス (タッチやマウスなど) の代わりにキーボードを使ってアプリに表示される UI をすばやく移動して操作する直感的な方法です。

「[カスタムのキーボード操作](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/custom-keyboard-interactions)」では、キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に対して、総合的で一貫性のあるキーボード エクスペリエンスを UWP アプリやカスタム コントロールで提供する方法を示します。

「[キーボード イベント](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-events)」トピックでは、ハードウェア キーボードとタッチ キーボードの両方について、キーボード イベントを追加する方法について説明します。

#### <a name="remote-sessions-apis-project-rome"></a>リモート セッション API (Project Rome)

Project Rome チームは、UWP 開発者用にリモート セッション SDK をリリースしました ([RemoteSystemSession](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems.remotesystemsession) クラスなど、[RemoteSystems](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems) 名前空間の新しいメンバーをご覧ください)。 Windows アプリでは、"共有エクスペリエンス" と通じてデバイスどうしを接続できるようになりました。"共有エクスペリエンス" では、デバイスは排他的双方向通信チャネルに参加します。 チャネルに参加している他のデバイスの一部またはすべてにデータ パケットを送信できるため、リモート アプリ メッセージングなど、新しいさまざまなクロス デバイス シナリオが可能になります。

SDK のリモート セッション機能は、Windows SDK Preview Build のみで利用可能です。

#### <a name="project-rome-for-ios"></a>Project Rome for iOS
Microsoft の Project Rome 機能が iOS のプラットフォームにデビューしました。 新しいプレビュー SDK を使うと、リモートでアプリを起動してユーザーの Windows デバイスでタスクを続行するような iOS アプリを作成できます。 この機能を使い始めるには、公式の[クロスプラットフォーム シナリオ向け Project Rome リポジトリ](https://github.com/Microsoft/project-rome)をご覧ください。

#### <a name="windows-ink"></a>Windows Ink

「[Windows Ink でのストロークのテキスト認識](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/convert-ink-to-text)」トピックでは、[Windows Ink 分析エンジン](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis)を使用した豊富な認識機能について説明しています。 一連のストロークをテキストまたは図形として分類、分析、および認識する方法についても示します (ドキュメントの構造、箇条書き、および汎用的な描画の認識にも Ink の分析を使用できます)。

## <a name="samples-and-tutorials"></a>サンプルとチュートリアル

#### <a name="high-dpi"></a>高 DPI

[Per-window DPI Awareness サンプル](https://github.com/Microsoft/Windows-classic-samples/tree/master/Samples/DPIAwarenessPerWindow) が更新され、Creators Update で新しく追加された Per-Monitor v2 DPI 対応コンテキスト モードがサポートされるようになりました。 このサンプルでは、単一のデスクトップ アプリケーション プロセスで、さまざまなトップレベル ウィンドウにさまざまな DPI 対応モードを割り当てる方法を示し、モードによる動作の違いを説明しています。

#### <a name="radialcontroller"></a>RadialController

[UWP アプリによる Surface Dial (およびその他のホイール デバイス) のサポート](https://docs.microsoft.com/en-us/windows/uwp/get-started/radialcontroller-walkthrough)に関するチュートリアルがリリースされました。 RadialController API を使用してサンプル アプリのダイヤル エクスペリエンスをカスタマイズする方法が示されています。

#### <a name="webvr"></a>WebVR

[3D Babylon.js ゲームに WebVR サポートを追加する方法](https://docs.microsoft.com/en-us/windows/uwp/get-started/adding-webvr-to-a-babylonjs-game)に関するチュートリアルがリリースされました。 このチュートリアルを進めるには、Windows Mixed Reality ヘッドセットが必要になります。動作する Babylon.js ゲームを使い、WebVR 用に構成する方法のプロセスを順に説明します。

#### <a name="windows-ink"></a>Windows Ink

[UWP による Ink のサポート](https://docs.microsoft.com/en-us/windows/uwp/get-started/ink-walkthrough)に関するチュートリアルがリリースされました。 Windows Ink を使った描画と手書きをサポートする基本的な UWP アプリの作成方法を順に説明します。