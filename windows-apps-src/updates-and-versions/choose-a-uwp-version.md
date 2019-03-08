---
title: UWP バージョンの選択
description: Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 ここでは、UWP バージョンによる違いと、新しいプロジェクトや既存のプロジェクトで選択したバージョンを構成する方法について説明します。
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp, バージョン, 作成, バージョン, windows, 選択, 更新, 更新プログラム
ms.assetid: a8b7830f-4929-44c6-90be-91f38be5f364
ms.localizationpriority: medium
ms.openlocfilehash: fed67ca6547ec8c8f90bc67a7be1f0d97af475df
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623597"
---
# <a name="choose-a-uwp-version"></a>UWP バージョンの選択

Windows 10 の各バージョンでは、新機能や強化された機能が UWP プラットフォームに提供されます。 Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 [.NET Standard 2.0](https://docs.microsoft.com/dotnet/standard/net-standard) を使うプロジェクトには、ビルド 16299 以降の**最小バージョン**が必要です。

> [!WARNING]
> Visual Studio 2015 では、現在のバージョンの Visual Studio で作成された UWP プロジェクトを開くことができません。

次の表に、Windows 10 で利用できるバージョンを示します。 この表は、Windows 10 でのみサポートされる UWP アプリを作成する場合にだけ適用されることに注意してください。 以前のバージョンの Windows 向けに UWP アプリを開発することはできません。また、目的のバージョンをターゲットにするには、[SDK の適切なビルドをインストール](https://go.microsoft.com/fwlink/?LinkId=821431)する必要があります。 

| バージョン | 説明 |
| --- | --- |
| ビルド 17763 (バージョンは 1809) | これは、Windows 10、10 月の 2018 年にリリースの最新バージョンです。 **注意してくださいした_する必要があります_このバージョンの Windows をターゲットにする Visual Studio 2017 を使用します。** このリリースの主な新機能は次のとおりです。 </br> \* **Windows Machine Learning:** Windows Machine Learning はこれで正式に起動され、最先端の機械学習モデルの評価を速くやサポートなどの機能を提供します。 このプラットフォームについて詳しくは、「[Windows Machine Learning](https://docs.microsoft.com/windows/ai/)」をご覧ください。 </br> \* **Fluent Design:** Windows 10 に、メニュー バー、コマンド バーのフライアウト、および XAML プロパティのアニメーションなどの新機能が追加されました。 最新情報については、「[Fluent Design の概要](../design/fluent-design-system/index.md)」をご覧ください。 </br> Windows のこのリリースで追加されたその他の多くの機能については、次を参照してください[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)の詳細ページまたは[開発者向け Windows 10 の新。](../whats-new/windows-10-build-17763.md)
| ビルド 17134 (バージョン 1803) | これは Windows 10 のバージョンは、2018 年 4 月にリリースされました。 **注意してくださいした_する必要があります_このバージョンの Windows をターゲットにする Visual Studio 2017 を使用します。** このリリースの主な新機能は次のとおりです。 </br> \* **Fluent Design:** Windows 10 に、ツリー ビュー、プル、更新、およびナビゲーション ビューなどの新機能が追加されました。 最新情報については、「[Fluent Design の概要](../design/fluent-design-system/index.md)」をご覧ください。 </br> \* **コンソールの UWP アプリ:** C++ /WinRT または /CX の UWP コンソール アプリを作成して、DOS や PowerShell などのコンソール ウィンドウで実行できるようになりました。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-17134.md)」の詳細ページをご覧ください。
| ビルド 16299 (Fall Creators Update バージョン 1709) | このバージョンの Windows 10 は、2017 年 10 月にリリースされました。 **注意してくださいした_する必要があります_このバージョンの Windows をターゲットにする Visual Studio 2017 を使用します。** このリリースの主な新機能は次のとおりです。 </br> \* **.NET standard 2.0:**.NET Api の数の大規模な増加を利用し、.NET Standard に、お気に入りの NuGet パッケージとサード パーティ製のライブラリを組み込むことです。 詳しくは、[こちら](https://docs.microsoft.com/dotnet/standard/net-standard)のドキュメントをご覧ください。 これらの新しい API にアクセスするには、**最小バージョン**をビルド 16299 に設定する必要がある点に注意してください。 </br> \* **Fluent Design:** アプリ ユーザーのフォーカスの重要な UI 要素を強化するために、光、深さ、パースペクティブ、および移動を使用します。 </br> \* **条件付き XAML:** 簡単にプロパティを設定し、デバイスとバージョンの間でシームレスに実行するアプリを有効にすると、実行時に API の有無に基づいてオブジェクトをインスタンス化します。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-16299.md)」の詳細ページをご覧ください。
| ビルド 15063 (Creators Update バージョン 1703) | このバージョンの Windows 10 は、2017 年 3 月にリリースされました。 **このバージョンの Windows をターゲットにするには、Visual Studio 2017 を使用している_必要があります_。** このリリースの主な新機能は次のとおりです。  </br> \* **Ink Analysis:** Windows のインクでは、書き込みまたは描画のいずれかのストロークと認識されたテキスト、図形、および basid レイアウト構造にインク ストロークを分類できますようになりました。 </br> \* **Windows.Ui.Composition Api:** 簡単に結合し、アプリ間でアニメーションを適用します。 </br> \* **ライブ編集。** アプリを実行しているときに、XAML を編集し、リアルタイムで適用された変更を参照してください。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-15063.md)」の詳細ページをご覧ください。  |
| ビルド 14393 (Anniversary Update バージョン 1607) | このバージョンの Windows 10 は、2016 年 7 月にリリースされました。 このリリースの主な新機能は次のとおりです。 </br> \* **Windows の手描き入力:** 新しい InkCanvas および InkToolbar コントロール。 </br> \* **Cortana Api:** アプリの特定の関数と Cortana のサポートを統合するのにには、Cortana の新しいアクションを使用します。 </br> \* **Windows こんにちは:** Microsoft Edge サポート Windows こんにちは、web 開発者に生体認証へのアクセスを付与します。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-build-14393.md)」の詳細ページをご覧ください。  |
| ビルド 10586 (November Update バージョン 1511) | このバージョンの Windows 10 は、2015 年 11 月にリリースされました。 このリリースでは主な新機能として、Microsoft Edge のビデオ通信用 ORTC (オブジェクト リアルタイム通信) APIと、アプリで Windows Hello 顔認証を使うためのプロバイダー API が導入されました。 [このビルドで導入された機能の詳細についてはします。](../whats-new/windows-10-build-10586.md) |
| ビルド 10240 (Windows 10 バージョン 1507) | 2015 年 7 月にリリースされた Windows 10 の初期リリース バージョンです。 [このビルドで導入された機能の詳細についてはします。](../whats-new/windows-10-build-10240.md) |

新しい開発者や一般的なユーザーを対象に常にコードを記述する開発者が Windows (17763) の最新のビルドを使用することを強くお勧めします。 エンタープライズ アプリを開発する場合は、**最小バージョン**で古いバージョンをサポートすることを検討してください。

## <a name="whats-different-in-each-uwp-version"></a>UWP バージョンの比較

連続する各バージョンの Windows 10 に対して、UWP の新しい API や変更された API が用意されています。 各バージョンで追加された具体的な機能については、「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-version-latest.md)」をご覧ください。

すべてのデバイス ファミリとそのバージョン、およびすべての API コントラクトとそのバージョンを列挙したリファレンス トピックについては、「[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn706137.aspx)」と「[APIコントラクト](https://msdn.microsoft.com/library/windows/apps/dn706135.aspx)」をご覧ください。

## <a name="net-api-availability-in-uwp-versions"></a>UWP のバージョンの .NET API の可用性

UWP に関係なく使用できる .NET Api の限定されたサブセットをサポートしています、**ターゲット バージョン**または**最小バージョン**のプロジェクト。 [このページは、詳細を使用できる型については、](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501(d=robot).aspx)します。

再利用可能なクロス プラットフォーム ライブラリを作成する場合は UWP の .NET Standard はサポートされています。 [.NET Standard ドキュメント](https://docs.microsoft.com/dotnet/standard/net-standard)を .NET Standard ではサポートされている UWP バージョン情報を提供します。

デスクトップ アプリを開発している場合は代わりに参照[.NET Framework のバージョンおよび依存関係](https://docs.microsoft.com/dotnet/framework/migration-guide/versions-and-dependencies).NET framework の可用性の詳細についてはします。

## <a name="choose-which-version-to-use-for-your-app"></a>アプリで使用するバージョンの選択

Visual Studio の **[新しいユニバーサル Windows プロジェクト]** ダイアログで、**[ターゲット バージョン]** と **[最小バージョン]** を選択できます。 また、アプリの **[プロパティ]** にある*アプリケーション* セクションで、UWP アプリの **[ターゲット バージョン]** と **[最小バージョン]** を変更することもできます。

* **[ターゲット バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MaxVersionTested* 属性の値が設定されます。 選択した値に基づいて、プロジェクトがターゲットとする UWP プラットフォームのバージョンが指定され、アプリで使用可能な API のセットが決まります。したがって、可能な限り新しいバージョンを選択することをお勧めします。 アプリ パッケージ マニフェストの詳細と、TargetDeviceFamily を手動で構成する場合のガイドラインについては、「[TargetDeviceFamily](https://msdn.microsoft.com/library/windows/apps/dn986903)」をご覧ください。
* **[最小バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformMinVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MinVersion* 属性の値が設定されます。 選択した値に基づいて、プロジェクトが動作できる UWP プラットフォームの最小バージョンが指定されます。

これらの設定は、アプリが **[最小バージョン]** から **[ターゲット バージョン]** までのすべてのバージョンで動作することの宣言となります。 これら 2 つが同じバージョンである場合は、特に問題はありません。 これらが異なる場合は、次の点に注意が必要です。

* コードでは、**[最小バージョン]** で指定されたバージョンに含まれているすべての API を自由に (つまり、条件チェックなしに) 呼び出すことができます。
* 必ず **[最小バージョン]** を実行するデバイスでコードをテストして、**[ターゲット バージョン]** のみに存在する API を必要とすることなく動作することを確認してください。
* プロジェクトのコンパイルに使用するすべての参照 (コントラクト winmds) は、**[ターゲット バージョン]** の値によって特定されます。 しかしそれらの参照により、(**[最小バージョン]** で) サポートを宣言したデバイスに存在しない API への呼び出しを含むコードもコンパイルできます。 したがって、**[最小バージョン]** の後に導入されたすべての API は、アダプティブ コード経由で呼び出す必要があります。 アダプティブ コードについて詳しくは、「[バージョン アダプティブ コード](https://docs.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。