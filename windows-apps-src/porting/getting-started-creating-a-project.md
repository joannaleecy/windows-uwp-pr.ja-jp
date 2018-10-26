---
author: stevewhims
ms.assetid: 08C8F359-E8B6-4A45-8F4B-8A1962F0CE38
description: Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。
title: Visual Studio でのプロジェクトの作成
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3b10d615146c8989231c4fe36ad9588716c59c34
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5547571"
---
# <a name="getting-started-creating-a-project"></a>はじめに: プロジェクトの作成

## <a name="creating-a-project"></a>プロジェクトの作成

Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。 このチュートリアルを通して、開始にあたって知っておく必要がある最も基本的な事柄を確認できます。 アプリを作るたびに、この手順に従うことになります。

次のビデオでは、Xcode と Visual Studio を比較しています。

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Comparing-Xcode-to-Visual-Studio/player]

この [Windows 用アプリ開発ブログの記事](https://blogs.windows.com/buildingapps/2016/01/27/visual-studio-walkthrough-for-ios-developers/)も非常に役立ちます。

ストーリー ボードを使って iOS アプリの作成に似ていますが (正式には、ユニバーサル Windows プラットフォーム (UWP) アプリと呼ばれます) を windows 10 用のアプリを作成します。 Windows 10 アプリは、しばしば複数のページでは、各ページの web サイトのように、ユーザー インターフェイスの異なる部分が含まれています。 各ページには通常、2 つのソース ファイルが関連付けられています。1 つは [XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)形式のユーザー インターフェイスを格納するファイルで、もう 1 つはソース コードを記述したファイルです (多くの場合 C#)。 ユーザーは、アプリとやり取りするときに、これらのページの間を移動します。 このチュートリアルでは、ページを 2 つ持つアプリを作成します。

**注:** windows 10 アプリの重要な機能が、同じソース コードと同じ API セットがプラットフォームに関係なく利用可能なポイントです。 ご存知のように、iPhone や iPad 向けのユニバーサル iOS アプリを作っている場合、実行時にアプリを実行するプラットフォームを決定して、適切なアクションを実行できます。 同様に、windows 10 アプリ見分けることができます、実行時に、デバイスで実行されています。 UWP アプリでは、電話とデスクトップのビルドを作成するためにソース コードで \#ifdef を使用する必要はありません。 Windows 10 アプリもインテリジェント デバイスに応じてユーザー インターフェイス コントロールを使って、: たとえば、アプリが日付の選択コントロールを参照し、コントロールに自動的に検索およびがあるかどうかによって異なる動作をデスクトップまたは電話の画面で実行されています。 ただし、ソース コードは変わりません。

Windows 10 アプリを作成する方法を見てみましょう。 Visual Studio の実行から始めます。 Visual Studio を初めて起動すると、開発者用ライセンスを取得するように求められます。 開発者用ライセンスでは、UWP アプリを Microsoft Store に提出する前にローカル コンピューター上にインストールしてテストできます。 ライセンスを取得するには、画面の指示に従って、Microsoft アカウントを使ってサインインします。 Microsoft アカウントがない場合は、**[開発者用ライセンス]** ダイアログ ボックスの **[新規登録]** リンクをクリックし、画面の指示に従います。

Xcode では、初めて起動したときに次のような **[Welcome to Xcode]** (Xcode へようこそ) 画面が表示されます。比較してください。

![Xcode のようこそ画面](images/ios-to-uwp/ios-to-uwp-xcode-welcome.png)

Visual Studio もこれに似ています。 次の図に示すように、**[スタート ページ]** が表示されます。

![Visual Studio のスタート画面](images/ios-to-uwp/ios-to-uwp-vs-welcome.png)

新しいアプリを作るには、次のどちらかの操作を行って、プロジェクトの作成を開始します。

-   **[開始]** 領域で、**[新しいプロジェクト]** をタップします。
-   **[ファイル]** メニュー、**[新しいプロジェクト]** の順にタップします。

Xcode で新しいプロジェクトを作るときは、次の図に示すようなプロジェクト テンプレートの一覧が表示されます。比較してください。

![Xcode のプロジェクトの新規作成ダイアログ ボックス](images/ios-to-uwp/ios-to-uwp-xcode-choose-template.png)

Visual Studio の場合も、次の図に示すように、いくつかのプロジェクト テンプレートから選択できるようになっています。

![Visual Studio の [新しいプロジェクト] ダイアログ ボックス](images/ios-to-uwp/ios-to-uwp-vs-choose-template.png)このチュートリアルでは、**[Visual C#]**、**[Windows]**、**[Windows ユニバーサル]**、**[空のアプリ (Windows ユニバーサル)]** の順にタップします。 **[名前]** ボックスに「MyApp」と入力し、**[OK]** をタップします。 Visual Studio によって初めてのプロジェクトが作成され、表示されます。 これで、アプリの設計を開始して、コードを追加できるようになりました。

## <a name="next-step"></a>次のステップ

[はじめに: プログラミング言語の選択](getting-started-choosing-a-programming-language.md)
