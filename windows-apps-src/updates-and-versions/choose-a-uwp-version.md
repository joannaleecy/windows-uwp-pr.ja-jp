---
author: QuinnRadich
title: UWP バージョンの選択
description: Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 ここでは、UWP バージョンによる違いと、新しいプロジェクトや既存のプロジェクトで選択したバージョンを構成する方法について説明します。
ms.author: quradic
ms.date: 4/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, バージョン, 作成, バージョン, windows, 選択, 更新, 更新プログラム
ms.assetid: a8b7830f-4929-44c6-90be-91f38be5f364
ms.localizationpriority: medium
ms.openlocfilehash: c7951098e576047b5c82da72b7c4e9118ffb7569
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3239802"
---
# <a name="choose-a-uwp-version"></a>UWP バージョンの選択

Windows 10 の各バージョンでは、新機能や強化された機能が UWP プラットフォームに提供されます。 Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 [.NET Standard 2.0](https://docs.microsoft.com/dotnet/standard/net-standard) を使うプロジェクトには、ビルド 16299 以降の**最小バージョン**が必要です。

> [!WARNING]
> Visual Studio 2015 では、現在のバージョンの Visual Studio で作成された UWP プロジェクトを開くことができません。

次の表に、Windows 10 で利用できるバージョンを示します。 この表は、Windows 10 でのみサポートされる UWP アプリを作成する場合にだけ適用されることに注意してください。 以前のバージョンの Windows 向けに UWP アプリを開発することはできません。また、目的のバージョンをターゲットにするには、[SDK の適切なビルドをインストール](http://go.microsoft.com/fwlink/?LinkId=821431)する必要があります。 

| バージョン | 説明 |
| --- | --- |
| ビルド 17134 (バージョン 1803) | 2018 年 4 月にリリースされた Windows 10 の最新バージョンです。 **このバージョンの Windows をターゲットにするには、Visual Studio 2017 を使用している_必要があります_。** このリリースの主な新機能は次のとおりです。 </br> \* **Windows Machine Learning:** Windows Machine Learning を使用すると、ローカルの事前学習済み機械学習モデルを Windows 10 デバイス上で評価するアプリを構築できます。 このプラットフォームについて詳しくは、「[Windows Machine Learning](https://docs.microsoft.com/windows/ai/)」をご覧ください。 </br> \* **Fluent Design:** ツリー ビュー、引っ張って更新、ナビゲーション ビューなど、Windows 10 に追加された新機能です。 最新情報については、「[Fluent Design の概要](../design/fluent-design-system/index.md)」をご覧ください。 </br> \* **コンソール UWP アプリ:** C++/WinRT または C++/CX の UWP コンソール アプリを作成して、DOS や PowerShell などのコンソール ウィンドウで実行できるようになりました。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-17134.md)」の詳細ページをご覧ください。
| ビルド 16299 (Fall Creators Update バージョン 1709) | このバージョンの Windows 10 は、2017 年 10 月にリリースされました。 **このバージョンの Windows をターゲットにするには、Visual Studio 2017 を使用している_必要があります_。** このリリースの主な新機能は次のとおりです。 </br> \* **.NET Standard 2.0:** .NET API の数が大幅に増えており、お気に入りの NuGet パッケージとサード パーティ製ライブラリが .NET Standard に組み込まれています。 詳しくは、[こちら](https://docs.microsoft.com/dotnet/standard/net-standard)のドキュメントをご覧ください。 これらの新しい API にアクセスするには、**最小バージョン**をビルド 16299 に設定する必要がある点に注意してください。 </br> \* **Fluent Design: **照明、深度、視点、および動きを使ってアプリを強化し、重要な UI 要素にユーザーが専念できるようにしています。 </br> \* **条件付き XAML:** プロパティを簡単に設定し、実行時に API があるかどうかに基づいてオブジェクトをインスタンス化できるため、デバイスやバージョン間でアプリをシームレスに実行できるようになります。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-16299.md)」の詳細ページをご覧ください。
| ビルド 15063 (Creators Update バージョン 1703) | このバージョンの Windows 10 は、2017 年 3 月にリリースされました。 **このバージョンの Windows をターゲットにするには、Visual Studio 2017 を使用している_必要があります_。** このリリースの主な新機能は次のとおりです。  </br> \* **インクの解析:** Windows Ink で、インク ストロークを筆記のストロークか描画のストロークかに分類し、テキスト、図形、基本的なレイアウト構造を認識できるようになりました。 </br> \* **Windows.Ui.Composition API:** アプリ全体でアニメーションを簡単に組み合わせ、適用することができます。 </br> \* **ライブ編集:** アプリの実行中に XAML を編集し、適用される変更内容をリアルタイムで確認できます。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-15063.md)」の詳細ページをご覧ください。  |
| ビルド 14393 (Anniversary Update バージョン 1607) | このバージョンの Windows 10 は、2016 年 7 月にリリースされました。 このリリースの主な新機能は次のとおりです。 </br> \* **Windows Ink:** InkCanvas と InkToolbar の各コントロールが新しく追加されました。 </br> \* **Cortana API:** 新しい Cortana アクションを使って、Cortana のサポートをアプリの特定の機能と統合できます。 </br> \* **Windows Hello:** Microsoft Edge が Windows Hello をサポートするようになり、Web 開発者が生体認証にアクセスできるようになりました。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-14393.md)」の詳細ページをご覧ください。  |
| ビルド 10586 (November Update バージョン 1511) | このバージョンの Windows 10 は、2015 年 11 月にリリースされました。 このリリースでは主な新機能として、Microsoft Edge のビデオ通信用 ORTC (オブジェクト リアルタイム通信) APIと、アプリで Windows Hello 顔認証を使うためのプロバイダー API が導入されました。 [このビルドで導入された機能について詳しくはこちらをご覧ください。](../whats-new/windows-10-build-10586.md) |
| ビルド 10240 (Windows 10 バージョン 1507) | 2015 年 7 月にリリースされた Windows 10 の初期リリース バージョンです。 [このビルドで導入された機能について詳しくはこちらをご覧ください。](../whats-new/windows-10-build-10240.md) |

新しいを常に、一般のユーザーのコードを新しく開発するが、最新のビルドの Windows (17134) を使用することを強くお勧めします。 エンタープライズ アプリを開発する場合は、**最小バージョン**で古いバージョンをサポートすることを検討してください。

## <a name="whats-different-in-each-uwp-version"></a>UWP バージョンの比較

連続する各バージョンの Windows 10 に対して、UWP の新しい API や変更された API が用意されています。 各バージョンで追加された具体的な機能については、「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-version-latest.md)」をご覧ください。

すべてのデバイス ファミリとそのバージョン、およびすべての API コントラクトとそのバージョンを列挙したリファレンス トピックについては、「[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn706137.aspx)」と「[APIコントラクト](https://msdn.microsoft.com/library/windows/apps/dn706135.aspx)」をご覧ください。

## <a name="net-api-availability-in-uwp-versions"></a>UWP バージョンの .NET API の使用可能状況]

UWP は、**ターゲット バージョン**や、プロジェクトの**最小バージョン**に関係なく利用できる .NET Api の一部のサブセットをサポートしています。 [このページは利用可能な種類の詳細を提供します](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501(d=robot).aspx)。

クロス プラットフォームの再利用可能なライブラリを作成する場合は、.NET Standard でサポートされて UWP。 [.NET Standard のドキュメント](https://docs.microsoft.com/dotnet/standard/net-standard)を .NET Standard ではサポートされている UWP バージョン情報を提供します。

デスクトップ アプリを開発する場合について代わりに[.NET Framework のバージョンと依存関係](https://docs.microsoft.com/dotnet/framework/migration-guide/versions-and-dependencies).NET framework の可用性について詳しくは、

## <a name="choose-which-version-to-use-for-your-app"></a>アプリで使用するバージョンの選択

Visual Studio の **[新しいユニバーサル Windows プロジェクト]** ダイアログで、**[ターゲット バージョン]** と **[最小バージョン]** を選択できます。 また、アプリの **[プロパティ]** にある*アプリケーション* セクションで、UWP アプリの **[ターゲット バージョン]** と **[最小バージョン]** を変更することもできます。

* **[ターゲット バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MaxVersionTested* 属性の値が設定されます。 選択した値に基づいて、プロジェクトがターゲットとする UWP プラットフォームのバージョンが指定され、アプリで使用可能な API のセットが決まります。したがって、可能な限り新しいバージョンを選択することをお勧めします。 アプリ パッケージ マニフェストの詳細と、TargetDeviceFamily を手動で構成する場合のガイドラインについては、「[TargetDeviceFamily](https://msdn.microsoft.com/library/windows/apps/dn986903)」をご覧ください。
* **[最小バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformMinVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MinVersion* 属性の値が設定されます。 選択した値に基づいて、プロジェクトが動作できる UWP プラットフォームの最小バージョンが指定されます。

これらの設定は、アプリが **[最小バージョン]** から **[ターゲット バージョン]** までのすべてのバージョンで動作することの宣言となります。 これら 2 つが同じバージョンである場合は、特に問題はありません。 これらが異なる場合は、次の点に注意が必要です。

* コードでは、**[最小バージョン]** で指定されたバージョンに含まれているすべての API を自由に (つまり、条件チェックなしに) 呼び出すことができます。
* 必ず **[最小バージョン]** を実行するデバイスでコードをテストして、**[ターゲット バージョン]** のみに存在する API を必要とすることなく動作することを確認してください。
* プロジェクトのコンパイルに使用するすべての参照 (コントラクト winmds) は、**[ターゲット バージョン]** の値によって特定されます。 しかしそれらの参照により、(**[最小バージョン]** で) サポートを宣言したデバイスに存在しない API への呼び出しを含むコードもコンパイルできます。 したがって、**[最小バージョン]** の後に導入されたすべての API は、アダプティブ コード経由で呼び出す必要があります。 アダプティブ コードについて詳しくは、「[バージョン アダプティブ コード](https://docs.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。