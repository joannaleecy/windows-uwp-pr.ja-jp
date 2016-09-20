---
author: mcleblanc
description: "iOS 開発者のための UWP の概要"
title: "iOS 開発者のための UWP の概要"
ms.assetid: 9F67068B-E578-4C70-B3E0-DFF150FA9BDD
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 3fef53e5d6c9259bf5157b1221643d07e1d8be5e

---

# iOS 開発者のための UWP の概要

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]

この記事は、Windows 10 用の開発を検討している iOS 開発者向けに用意されています。 また、アプリの作成を開始するうえで理解しておく必要がある概念を紹介し、作成したアプリを Windows ストアで公開する方法についても説明します。

このセクションでは、Microsoft Visual Studio と C# プログラミング言語を使って簡単なアプリを作成する方法を少しずつ説明し、特にプロセスが現在お使いのツールとどのように違うかについて説明します。 (C# が気に入りませんでしたか? 心配しないでください。その他のプログラミング言語やツールも使うことができます。これらについては、「[はじめに: プログラミング言語の選択](getting-started-choosing-a-programming-language.md)」で触れます)。

Windows 10 では、デスクトップ、ノート PC、タブレット、電話の各デバイス、その他を対象とした魅力的なアプリを作成するための新しいプラットフォームが採用されています。 ユニバーサル Windows プラットフォーム (UWP) アプリには多くの独自の機能が用意されているため、iOS アプリを単純に移植するだけではこれらの機能を利用できなくなる可能性があります。 このため、新しいコントロールと機能を試して、開発者の作業がどのくらい効率化されるか、どのように新しいアプリを作ることができるかについて調べることをお勧めします。

結論は、アプリを単に移植することは避けて、アプリの **(作り直し)** をして、新機能と新しいデバイスを利用することです。 最大公約数で満足せずに、ライブ タイル、通知、Cortana の操作など、Windows 10 独自の機能を使うリッチなエクスペリエンスを作成します。

これらのチュートリアルを行うには、Windows 10 と Microsoft Visual Studio の両方がインストールされたコンピューターが必要です。 これらは、[Windows ストア アプリ プログラミングの開発者向けダウンロードに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=302144)からダウンロードできます。 PC がなくても 心配しないでください。Mac を使うことができます。詳しくは、「[Mac への Windows および開発者ツールのインストール](setting-up-your-mac-with-windows-10.md)」をご覧ください。

| トピック | 説明 |
|-------|-------------|
| [はじめに: プロジェクトの作成](getting-started-creating-a-project.md) | Windows にとっての Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。 |
| [はじめに: プログラミング言語の選択](getting-started-choosing-a-programming-language.md) | 先へ進む前に、UWP アプリを開発するときに選択できるプログラミング言語について理解している必要があります。 |
| [はじめに: Visual Studio の操作方法](getting-started-getting-around-in-visual-studio.md) | ここでは、前の手順で作ったプロジェクトに戻り、Visual Studio 統合開発環境 (IDE) の操作方法について示します。 |
| [はじめに: コモン コントロール](getting-started-common-controls.md) | ここでは、アプリやそれに対応する iOS アプリで使用するいくつかのコモン コントロールを紹介します。 |
| [はじめに: ナビゲーション](getting-started-navigation.md) | Windows 10 アプリでこのナビゲーションを管理する方法の 1 つに、[Frame](https://msdn.microsoft.com/library/windows/apps/br242682) クラスを使う方法があります。 以下のチュートリアルでは実際に試す方法を示しています。 |
| [はじめに: アニメーション](getting-started-animation.md) | Windows アプリでのアニメーションもプログラムで作成できますが、Extensible Application Markup Language (XAML) を使った宣言で定義することもできます。 |
| [はじめに: 次の手順](getting-started-what-next.md) | この基本情報を使って、もっと興味深いユニバーサル Windows プラットフォーム (UWP) アプリの作成を今すぐ開始できます。 次の手順として、次のトピックを読んでから Visual Studio を起動し、コードの作成を始めます。 |
| [Windows アプリの概念マッピング](https://msdn.microsoft.com//windows/uwp/porting/android-ios-uwp-map) | Windows (および Android) 機能の観点からの iOS の概念の考え方 |

 

 

 



<!--HONumber=Jun16_HO4-->


