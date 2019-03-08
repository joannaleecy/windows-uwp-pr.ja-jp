---
ms.assetid: 08C8F359-E8B6-4A45-8F4B-8A1962F0CE38
description: Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。
title: Visual Studio でのプロジェクトの作成
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1b6ea9fdf2e504e1ceee71658eab308751e1745c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601447"
---
# <a name="getting-started-creating-a-project"></a>はじめに。プロジェクトの作成

## <a name="creating-a-project"></a>プロジェクトの作成

Windows にとっての Microsoft Visual Studio は、iOS や Mac OS にとっての Xcode に相当します。 このチュートリアルでは、Visual Studio の使い方に慣れる訓練を行います。 このチュートリアルを通して、開始にあたって知っておく必要がある最も基本的な事柄を確認できます。 アプリを作るたびに、この手順に従うことになります。

次のビデオでは、Xcode と Visual Studio を比較しています。

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Comparing-Xcode-to-Visual-Studio/player]

この [Windows 用アプリ開発ブログの記事](https://blogs.windows.com/buildingapps/2016/01/27/visual-studio-walkthrough-for-ios-developers/)も非常に役立ちます。

(正式には、ユニバーサル Windows プラットフォーム (UWP) アプリと呼ばれます)、Windows 10 用アプリケーションの作成はストーリー ボードを使用して iOS アプリの作成ではなくと似ています。 Web サイトのように、ユーザー インターフェイスの別の部分を格納している各ページ、Windows 10 アプリは複数のページにわたって多くの場合、構成されます。 各ページには通常、2 つのソース ファイルが関連付けられています。1 つは [XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)形式のユーザー インターフェイスを格納するファイルで、もう 1 つはソース コードを記述したファイルです (多くの場合 C#)。 ユーザーは、アプリとやり取りするときに、これらのページの間を移動します。 このチュートリアルでは、ページを 2 つ持つアプリを作成します。

**注**  Windows 10 アプリの重要な機能は、同じのソース コードと同じ API セットがプラットフォームに関係なく利用可能なことです。 ご存知のように、iPhone や iPad 向けのユニバーサル iOS アプリを作っている場合、実行時にアプリを実行するプラットフォームを決定して、適切なアクションを実行できます。 同様の方法で Windows 10 アプリ分かるように、実行時にで実行されているデバイス。 UWP アプリで使用する必要はありません\#ifdef デスクトップと phone を作成するソース コードでビルドします。 便利なことは、Windows 10 アプリは、デバイスによって、ユーザー インターフェイス コントロールも適切を使用しますたとえば、アプリは、日付の選択コントロールを参照できます、コントロールは自動的に検索しがかどうかによって動作が異なります。デスクトップまたは [電話] 画面で実行されています。 ただし、ソース コードは変わりません。

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

![visual studio の新しいプロジェクト ダイアログ ボックス](images/ios-to-uwp/ios-to-uwp-vs-choose-template.png)このチュートリアルでは、タップ**Visual C#** 、 をタップし、 **Windows**、 **Windows ユニバーサル**と**空のアプリ (Windows ユニバーサル)** します。 **[名前]** ボックスに「MyApp」と入力し、**[OK]** をタップします。 Visual Studio によって初めてのプロジェクトが作成され、表示されます。 これで、アプリの設計を開始して、コードを追加できるようになりました。

## <a name="next-step"></a>次の手順

[はじめに。プログラミング言語の選択](getting-started-choosing-a-programming-language.md)
