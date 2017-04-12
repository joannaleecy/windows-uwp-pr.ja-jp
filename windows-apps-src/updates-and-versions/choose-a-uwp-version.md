---
author: QuinnRadich
title: "UWP バージョンの選択"
description: "Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 ここでは、UWP バージョンによる違いと、新しいプロジェクトや既存のプロジェクトで選択したバージョンを構成する方法について説明します。"
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: a8b7830f-4929-44c6-90be-91f38be5f364
ms.openlocfilehash: 2fe7d9017919166992b13a5cc5f058591fecda3e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="choose-a-uwp-version"></a>UWP バージョンの選択

Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 現時点では、可能なバージョンは次の 3つだけです。

| バージョン | 説明 |
| --- | --- |
| ビルド 14393 (Anniversary エディション) | 2016 年 7 月にリリースされた Windows 10 の最新バージョンです。 このリリースの主な新機能は次のとおりです。 </br> \* **Windows Ink:** 新しい InkCanvas と InkToolbar のコントロールです。 </br> \* **Cortana API:** 新しい Cortana アクションを使って、Cortana のサポートをアプリの特定の機能と統合できます。 </br> \* **Windows Hello:** Microsoft Edge が Windows Hello をサポートするようになり、Web 開発者が生体認証にアクセスできるようになりました。 </br> このリリースの Windows で追加されたこれらの機能や他の多くの機能については、[デベロッパー センター](https://developer.microsoft.com/windows/windows-10-for-developers)または「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-version-1607.md)」の詳細ページをご覧ください。  |
| ビルド 10586 | このバージョンの Windows 10 は、2015 年 11 月にリリースされました。 このリリースでは主な新機能として、Microsoft Edge のビデオ通信用 ORTC (オブジェクト リアルタイム通信) APIと、アプリで Windows Hello 顔認証を使うためのプロバイダー API が導入されました。 [このビルドで導入された機能について詳しくはこちらをご覧ください。](../whats-new/windows-10-version-1511.md) |
| ビルド 10240 | 2015 年 7 月にリリースされた Windows 10 の初期リリース バージョンです。 [このビルドで導入された機能について詳しくはこちらをご覧ください。](../whats-new/windows-10-version-1507.md) |

一般ユーザー向けのコードを新しく開発する場合、常に最新ビルドの Windows (14393) を使うことを強くお勧めします。 エンタープライズ アプリを開発する場合は、**最小バージョン**で古いバージョンをサポートすることを検討してください。

## <a name="whats-different-in-each-uwp-version"></a>UWP バージョンの比較

連続する各バージョンの Windows 10 に対して、UWP の新しい API や変更された API が用意されています。 各バージョンで追加された具体的な機能については、「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-version-1607.md)」をご覧ください。

すべてのデバイス ファミリとそのバージョン、およびすべての API コントラクトとそのバージョンを列挙したリファレンス トピックについては、「[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn706137.aspx)」と「[APIコントラクト](https://msdn.microsoft.com/library/windows/apps/dn706135.aspx)」をご覧ください。

## <a name="choose-which-version-to-use-for-your-app"></a>アプリで使用するバージョンの選択

Visual Studio の **[新しいユニバーサル Windows プロジェクト]** ダイアログで、**[ターゲット バージョン]** と **[最小バージョン]** を選択できます。

* **[ターゲット バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MaxVersionTested* 属性の値が設定されます。 選択した値に基づいて、プロジェクトがターゲットとする UWP プラットフォームのバージョンが指定され、アプリで使用可能な API のセットが決まります。したがって、可能な限り新しいバージョンを選択することをお勧めします。 アプリ パッケージ マニフェストの詳細と、TargetDeviceFamily を手動で構成する場合のガイドラインについては、「[TargetDeviceFamily](https://msdn.microsoft.com/library/windows/apps/dn986903)」をご覧ください。
* **[最小バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformMinVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MinVersion* 属性の値が設定されます。 選択した値に基づいて、プロジェクトが動作できる UWP プラットフォームの最小バージョンが指定されます。

これらの設定は、アプリが **[最小バージョン]** から **[ターゲット バージョン]** までのすべてのバージョンで動作することの宣言となります。 これら 2 つが同じバージョンである場合は、特に問題はありません。 これらが異なる場合は、次の点に注意が必要です。

* コードでは、**[最小バージョン]** で指定されたバージョンに含まれているすべての API を自由に (つまり、条件チェックなしに) 呼び出すことができます。
* 必ず **[最小バージョン]** を実行するデバイスでコードをテストして、**[ターゲット バージョン]** のみに存在する API を必要とすることなく動作することを確認してください。
* プロジェクトのコンパイルに使用するすべての参照 (コントラクト winmds) は、**[ターゲット バージョン]** の値によって特定されます。 しかしそれらの参照により、(**[最小バージョン]** で) サポートを宣言したデバイスに存在しない API への呼び出しを含むコードもコンパイルできます。 したがって、**[最小バージョン]** の後に導入されたすべての API は、アダプティブ コード経由で呼び出す必要があります。 アダプティブ コードについて詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](../get-started/universal-application-platform-guide.md)」をご覧ください。
