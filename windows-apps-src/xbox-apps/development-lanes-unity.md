---
title: Xbox の UWP への Unity ゲームの移行
description: Xbox での Unity UWP 開発。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fca3267a-0c0f-4872-8017-90384fb34215
ms.localizationpriority: medium
ms.openlocfilehash: 64a686aea24d23b5e999780eaa0eda661af3637f
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7969690"
---
# <a name="bringing-unity-games-to-uwp-on-xbox"></a>Xbox の UWP への Unity ゲームの移行


このチュートリアルでは、既に Unity のゲームが存在し、ビルドおよび展開する準備ができていることを前提としています。

[このチュートリアルのビデオ バージョン](https://www.youtube.com/watch?v=f0Ptvw7k-CE)もご覧ください。

Unity UWP プロジェクトのバージョン管理については、 「[UWP プロジェクトのバージョン管理](development-lanes-unity-versioning.md)」をご覧ください

## <a name="step-0-ensure-unity-is-installed-correctly"></a>手順 0: Unity が正しくインストールされていることを確認する

Unity をインストールするときに、以下のコンポーネントを選択する必要があります。

![Unity のインストール コンポーネント](images/unity-install-components.png)

## <a name="step-1-building-the-uwp-solution"></a>手順 1: UWP ソリューションを構築する

Unity ゲーム プロジェクトで、**[File] -> [Build Settings]** から **[Build Settings]** ウィンドウを開き、Microsoft Store オプション メニューに移動します。

![[Build Settings] ウィンドウ](images/build-settings.png)

**[SDK]** 設定が **[Universal 10]** であることを確認し、**[Build]** ボタンを選択します。作成先フォルダーを要求するエクスプローラー ウィンドウが起動します。 プロジェクトの **[Assets]** ディレクトリと並んで **[UWP]** というフォルダーを作成し、ビルドの保存先フォルダーとしてこのフォルダーを選択します。

![ビルドの保存先フォルダー](images/build-destination.png)

Unity で新しい Visual Studio ソリューションを作成できたので、これを使って UWP ゲームを展開します。

![UWP VS ソリューション](images/uwp-vs-solution.png)

## <a name="step-2-deploying-your-game"></a>手順 2: ゲームを展開する

**[UWP]** フォルダーに新しく作成されたソリューションを開き、ターゲット プラットフォームを **[x64]** に変更します。

![x64 ビルド プラットフォーム](images/x64-build-platform.png)

これで、ゲームの UWP Visual Studio ソリューションの準備ができました。[こちらの手順に従うことによって](getting-started.md)、ゲームを製品版の Xbox One に正常に展開できます。

## <a name="step-3-modify-and-rebuild"></a>手順 3: 変更とリビルド

スクリプトではないものに変更を行った場合、これらの変更がゲームの UWP ビルドに表示されるようにするために、(__手順 1__ の説明に従って) エディター内からプロジェクトをリビルドする必要があります。

## <a name="versioning-your-uwp-project"></a>UWP プロジェクトのバージョン管理

この新しく生成された UWP ディレクトリの一部をバージョン管理に追加することが必要になる一般的な状況がいくつかあります。 たとえば、新しい依存関係を UWP プロジェクト (たとえば Xbox Live SDK など) に追加する場合です。  この例の詳細については、[UWP プロジェクトのバージョン管理](development-lanes-unity-versioning.md)で説明します。

## <a name="see-also"></a>関連項目
- [既存のゲームの Xbox への移行](development-lanes-landing.md)
- [Xbox One の UWP](index.md)
