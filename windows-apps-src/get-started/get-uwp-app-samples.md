---
title: UWP アプリのサンプルを取得する
description: GitHub から UWP コードのサンプルをダウンロードする方法について説明します
author: JoshuaPartlow
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、サンプル コード、コード サンプル
ms.assetid: 393c5a81-ee14-45e7-acd7-495e5d916909
ms.localizationpriority: medium
ms.openlocfilehash: ef8f99ade3fa5e4d9f12b8670bf22242e7c4e585
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7307089"
---
# <a name="get-uwp-app-samples"></a><span data-ttu-id="fd504-104">UWP アプリのサンプルを取得する</span><span class="sxs-lookup"><span data-stu-id="fd504-104">Get UWP app samples</span></span>

<span data-ttu-id="fd504-105">ユニバーサル Windows プラットフォーム (UWP) アプリのサンプルは、GitHub のリポジトリを利用して入手できます。</span><span class="sxs-lookup"><span data-stu-id="fd504-105">The Universal Windows Platform (UWP) app samples are available through repositories on GitHub.</span></span> <span data-ttu-id="fd504-106">検索可能な、カテゴリ別の一覧については、[サンプル](https://developer.microsoft.com/windows/samples "デベロッパー センターのサンプル")をご覧ください。または [Microsoft/Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples "ユニバーサル Windows プラットフォーム アプリのサンプルの GitHub リポジトリ") リポジトリには、UWP 機能のすべてと API の使用パターンを示すサンプルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fd504-106">See [Samples](https://developer.microsoft.com/windows/samples "Dev Center samples") for a searchable, categorized list, or browse the [Microsoft/Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples "Universal Windows Platform app samples GitHub repository") repository, which contains samples that demonstrate all of the UWP features and their API usage patterns.</span></span>  
![GitHub の UWP サンプルのリポジトリ](images/GitHubUWPSamplesPage.png)

## <a name="download-the-code"></a><span data-ttu-id="fd504-108">コードのダウンロード</span><span class="sxs-lookup"><span data-stu-id="fd504-108">Download the code</span></span>

<span data-ttu-id="fd504-109">サンプルをダウンロードするには、[リポジトリ](https://github.com/Microsoft/Windows-universal-samples "ユニバーサル Windows プラットフォーム アプリのサンプル GitHub リポジトリ")に移動し、**[Clone or download]**、**[Download ZIP]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="fd504-109">To download the samples, go to the [repository](https://github.com/Microsoft/Windows-universal-samples "Universal Windows Platform app samples GitHub repository") and select **Clone or download**, then **Download ZIP**.</span></span> <span data-ttu-id="fd504-110">または、[ここ](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip "ユニバーサル Windows プラットフォーム アプリのサンプル zip ファイルのダウンロード")をクリックしてください。</span><span class="sxs-lookup"><span data-stu-id="fd504-110">Or, just click [here](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip "Universal Windows Platform app samples zip file download").</span></span>

<span data-ttu-id="fd504-111">zip ファイルには、常に最新のサンプルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fd504-111">The zip file will always have the latest samples.</span></span> <span data-ttu-id="fd504-112">ダウンロードする際に GitHub のアカウントは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="fd504-112">You don’t need a GitHub account to download it.</span></span> <span data-ttu-id="fd504-113">SDK の更新プログラムがリリースされた場合、または最新の変更内容や追加内容を選ぶ場合は、最新の zip ファイルを確認してください。</span><span class="sxs-lookup"><span data-stu-id="fd504-113">When an SDK update is released or if you want to pick up any recent changes/additions, just check back for the latest zip file.</span></span>

![サンプルのダウンロード](images/SamplesDownloadButton.png)


> [!NOTE]
> <span data-ttu-id="fd504-115">UWP のサンプルを開いたり、作成や実行したりする場合は、Visual Studio 2015 以降と Windows SDK が必要になります。</span><span class="sxs-lookup"><span data-stu-id="fd504-115">The UWP samples require Visual Studio 2015 or later and the Windows SDK to open, build, and run.</span></span> <span data-ttu-id="fd504-116">UWP アプリの構築をサポートする Visual Studio Community の無料コピーは[こちら](http://go.microsoft.com/fwlink/p/?LinkID=280676 "Windows development tools downloads")から入手できます。</span><span class="sxs-lookup"><span data-stu-id="fd504-116">You can get a free copy of Visual Studio Community with support for building UWP apps [here](http://go.microsoft.com/fwlink/p/?LinkID=280676 "Windows development tools downloads").</span></span>  
>
> <span data-ttu-id="fd504-117">また、個々のサンプルだけではなく、アーカイブ全体を解凍してください。</span><span class="sxs-lookup"><span data-stu-id="fd504-117">Also, be sure to unzip the entire archive, and not just individual samples.</span></span> <span data-ttu-id="fd504-118">すべてのサンプルは、アーカイブ内の SharedContent フォルダーに依存しているためです。</span><span class="sxs-lookup"><span data-stu-id="fd504-118">The samples all depend on the SharedContent folder in the archive.</span></span> <span data-ttu-id="fd504-119">UWP 機能のサンプルは、Visual Studio のリンク ファイルを使用して、共通ファイル (サンプルのテンプレート ファイルや画像アセットなど) の重複を減らします。</span><span class="sxs-lookup"><span data-stu-id="fd504-119">The UWP feature samples use Linked files in Visual Studio to reduce duplication of common files, including sample template files and image assets.</span></span> <span data-ttu-id="fd504-120">これらの共通ファイルは、リポジトリのルートにある SharedContent フォルダーに格納され、リンクを使用するプロジェクト ファイル内で参照されます。</span><span class="sxs-lookup"><span data-stu-id="fd504-120">These common files are stored in the SharedContent folder at the root of the repository, and are referred to in the project files using links.</span></span>

<span data-ttu-id="fd504-121">zip ファイルをダウンロードしたら、Visual Studio でサンプルを開きます。</span><span class="sxs-lookup"><span data-stu-id="fd504-121">After you download the zip file, open the samples in Visual Studio:</span></span>

1.  <span data-ttu-id="fd504-122">アーカイブを解凍する前に、アーカイブを右クリックし、**[プロパティ]** > **[ブロックの解除]** > **[適用]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="fd504-122">Before you unzip the archive, right-click it, select **Properties** > **Unblock** > **Apply**.</span></span> <span data-ttu-id="fd504-123">次に、アーカイブをコンピューター上のローカル フォルダーに展開します。</span><span class="sxs-lookup"><span data-stu-id="fd504-123">Then, unzip the archive to a local folder on your machine.</span></span>

    ![解凍されたアーカイブ](images/SamplesUnzip1.png)
2.  <span data-ttu-id="fd504-125">[Samples] フォルダーには多くのフォルダーが含まれており、各フォルダーには UWP 機能のサンプルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fd504-125">Within the samples folder, you’ll see a number of folders, each of which contains a UWP feature sample.</span></span>

    ![サンプルのフォルダー](images/SamplesUnzip2.png)

3.  <span data-ttu-id="fd504-127">([Altimeter)] （高度計） などのサンプルを選ぶと、サポートされている言語を示す複数のフォルダーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fd504-127">Select a sample, such as Altimeter, and you’ll see multiple folders indicating the languages supported.</span></span>

    ![言語フォルダー](images/SamplesUnzip3.png)

4.  <span data-ttu-id="fd504-129">使用する言語 (C\# の場合は [CS]) を選ぶと、Visual Studio で開くことができる Visual Studio のソリューション ファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fd504-129">Select the language you’d like to use, such as CS for C\#, and you’ll see a Visual Studio solution file, which you can open in Visual Studio.</span></span>

    ![VS ソリューション](images/SamplesUnzip4.png)

## <a name="give-feedback-ask-questions-and-report-issues"></a><span data-ttu-id="fd504-131">フィードバックの提供、質問の投稿、問題の報告</span><span class="sxs-lookup"><span data-stu-id="fd504-131">Give feedback, ask questions, and report issues</span></span>

<span data-ttu-id="fd504-132">問題や質問がある場合は、リポジトリの [Issues] タブを使用して、新しい問題や質問に関する報告を作成します。サポートできる問題や質問については、弊社で対応します。</span><span class="sxs-lookup"><span data-stu-id="fd504-132">If you have problems or questions, just use the Issues tab on the repository to create a new issue and we’ll do what we can to help.</span></span>

![フィードバックの画像](images/GitHubUWPSamplesFeedback.png)
