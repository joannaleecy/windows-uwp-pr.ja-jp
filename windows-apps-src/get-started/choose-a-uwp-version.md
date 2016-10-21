---
author: QuinnRadich
title: "UWP バージョンの選択"
description: "Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 ここでは、UWP バージョンによる違いと、新しいプロジェクトや既存のプロジェクトで選択したバージョンを構成する方法について説明します。"
redirect_url: ../updates-and-versions/choose-a-uwp-version/
translationtype: Human Translation
ms.sourcegitcommit: a86002c944841536d37735bb8c4b657905582144
ms.openlocfilehash: d6d2be6c91ddf5fb85cdec759c753db1561f066f

---

# UWP バージョンの選択

**このページは、次のアドレスに移動しました。../updates-and-versions/choose-a-uwp-version/**

Microsoft Visual Studio で UWP アプリを作成するときは、ターゲットのバージョンを選択できます。 ここでは、UWP バージョンによる違いと、新しいプロジェクトや既存のプロジェクトで選択したバージョンを構成する方法について説明します。

## UWP バージョンの比較

連続する各バージョンの Windows 10 に対して、UWP の新しい API や変更された API が用意されています。 各バージョンで追加された具体的な機能については、「[Windows 10 の開発者向け新着情報](../whats-new/windows-10-version-1607.md)」をご覧ください。

すべてのデバイス ファミリとそのバージョン、およびすべての API コントラクトとそのバージョンを列挙したリファレンス トピックについては、[デバイス ファミリ](https://msdn.microsoft.com/library/windows/apps/dn706137.aspx)」と「[APIコントラクト](https://msdn.microsoft.com/library/windows/apps/dn706135.aspx)」をご覧ください。

## アプリで使用するバージョンの選択

Visual Studio の **[新しいユニバーサル Windows プロジェクト]** ダイアログで、**[ターゲット バージョン]** と **[最小バージョン]** を選択できます。

* **[ターゲット バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MaxVersionTested* 属性の値が設定されます。 選択した値に基づいて、プロジェクトがターゲットとする UWP プラットフォームのバージョンが指定され、アプリで使用可能な API のセットが決まります。したがって、可能な限り新しいバージョンを選択することをお勧めします。 アプリ パッケージ マニフェストの詳細と、TargetDeviceFamily を手動で構成する場合のガイドラインについては、「[TargetDeviceFamily](https://msdn.microsoft.com/library/windows/apps/dn986903)」を参照してください。
* **[最小バージョン]**。 この設定により、プロジェクト ファイルの *TargetPlatformMinVersion* が設定されます。 またアプリ パッケージ マニフェスト内の *TargetDeviceFamily@MinVersion* 属性の値が設定されます。 選択した値に基づいて、プロジェクトが動作できる UWP プラットフォームの最小バージョンが指定されます。

これらの設定は、アプリが **[最小バージョン]** から **[ターゲット バージョン]** までのすべてのバージョンで動作することの宣言となります。 これら 2 つが同じバージョンである場合は、特に問題はありません。 これらが異なる場合は、次の点に注意が必要です。

* コードでは、**[最小バージョン]** で指定されたバージョンに含まれているすべての API を自由に (つまり、条件チェックなしに) 呼び出すことができます。
* プロジェクトのコンパイルに使用するすべての参照 (コントラクト winmds) は、**[ターゲット バージョン]** の値によって特定されます。 しかしそれらの参照により、(**[最小バージョン]** で) サポートを宣言したデバイスに存在しない API への呼び出しを含むコードもコンパイルできます。 したがって、**[最小バージョン]** の後に導入されたすべての API は、アダプティブ コード経由で呼び出す必要があります。 アダプティブ コードについて詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](universal-application-platform-guide.md)」をご覧ください。


<!--HONumber=Aug16_HO5-->


