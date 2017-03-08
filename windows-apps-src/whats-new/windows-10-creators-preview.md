---
author: QuinnRadich
title: "Windows 10 Creators Update Preview の新機能 - UWP アプリの開発"
description: "Windows 10 Creators Update Preview では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスを提供していく予定です。"
ms.assetid: 27a9ce65-c811-4f79-bf65-3493337199c8
keywords: "新機能, 新着情報, プレビュー, 更新, 更新情報, 機能, 新規, Windows 10, Creators"
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: 29a888286062c59ea257cf0e43d3598d847a6588
ms.openlocfilehash: d36b84299b8e469624cef54f89c94744f3f4ae83
ms.lasthandoff: 02/08/2017

---

# <a name="whats-new-in-the-windows-10-creators-update-preview"></a>Windows 10 Creators Update Preview の新機能

Windows 10 Creators Update では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスを提供していく予定です。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)がどのように使えるかを試したりすることができます。

これらの機能は、Windows 10 Creators Update がリリースされるまで一般には公開されません。 現時点では、[Windows Insider](https://insider.windows.com/) 向けに提供されているプレビュー ビルドで使用できます。 このページは、新しいドキュメントの公開に合わせて、より多くの新機能の情報で更新される可能性があります。

このリリースや他の Windows 更新プログラムでの主な新機能について詳しくは、[Windows Developer Day サイト](https://developer.microsoft.com/en-us/windows/projects/campaigns/windows-developer-day)と「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。 また、過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/en-us/windows/platform/features)をご覧ください。

機能 | 説明
 :---- | :----
**UWP ドキュメントの刷新** | ユニバーサル Windows プラットフォームのドキュメントが docs.microsoft.com で利用できるようになりました。 コード サンプルの送信、技術的な専門知識の追加、フィードバックの提供も簡単に行うことができます。 手順については、[One Dev Minute ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Modernizing-the-Windows-UWP-Docs)をご覧ください。
**顧客注文データベースのサンプルの更新** | GitHub にある[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database)のサンプルが更新され、Telerik のデータ グリッド コントロールとデータ入力検証機能を利用するようになりました。このコントロールは UI for UWP スイートの一部です。 UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。
**インクの解析** | Windows Ink で、インク ストロークを筆記のストロークか描画のストロークかに分類し、テキスト、図形、基本的なレイアウト構造を認識できるようになりました。
**Android 用 Project Rome SDK** | UWP の Project Rome 機能が Android プラットフォームでも利用できるようになりました。 Windows デバイスだけでなく**、Android デバイスを使ってリモートでアプリを起動し、Windows デバイスで行っていた作業を続けることができます。 この機能を使い始めるには、公式の[クロスプラットフォーム シナリオ向け Project Rome リポジトリ](https://github.com/Microsoft/project-rome)をご覧ください。
**XAML コントロール** | ContentDialog に Primary、Secondary、Close の 3 つのボタンが追加されました。 ボタンの 1 つを既定の動作に設定することもできます。 <br> ShowAsMonochrome プロパティを使うと、ビットマップ アイコンを単色またはフル カラーで表示できます。 <br> 新しい SelectionChangedTrigger を使うと、ComboBox でキーボードによる選択の処理方法を変更できます。 <br> ListViewBase の新しい API である PrepareConnectedAnimation と TryStartConnectedAnimationAsync により、リスト ビューやグリッド ビューで接続型アニメーションを簡単に使用できます。 <br> 新しい Icon プロパティを使うと、MenuFlyoutItem または MenuFlyoutSubItem にアイコンを追加できます。 <br> SvgImageSource クラスを使うと、XAML で SVG イメージを追加できます。 <br> LoadedImageSource クラスを使うと、XAML でコンポジション サーフェスを追加できます。 <br> XAMLLight クラスと UIElement.Lights プロパティを使うと、XAML で CompositionLight 効果を追加できます。 <br> XamlCompositionBrushBase を使うと、XAML で合成ブラシを使用できます。

