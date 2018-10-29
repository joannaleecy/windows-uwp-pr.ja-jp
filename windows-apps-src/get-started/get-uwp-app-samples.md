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
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5751614"
---
# <a name="get-uwp-app-samples"></a>UWP アプリのサンプルを取得する

ユニバーサル Windows プラットフォーム (UWP) アプリのサンプルは、GitHub のリポジトリを利用して入手できます。 検索可能な、カテゴリ別の一覧については、[サンプル](https://developer.microsoft.com/windows/samples "デベロッパー センターのサンプル")をご覧ください。または [Microsoft/Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples "ユニバーサル Windows プラットフォーム アプリのサンプルの GitHub リポジトリ") リポジトリには、UWP 機能のすべてと API の使用パターンを示すサンプルが含まれています。  
![GitHub の UWP サンプルのリポジトリ](images/GitHubUWPSamplesPage.png)

## <a name="download-the-code"></a>コードのダウンロード

サンプルをダウンロードするには、[リポジトリ](https://github.com/Microsoft/Windows-universal-samples "ユニバーサル Windows プラットフォーム アプリのサンプル GitHub リポジトリ")に移動し、**[Clone or download]**、**[Download ZIP]** の順に選択します。 または、[ここ](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip "ユニバーサル Windows プラットフォーム アプリのサンプル zip ファイルのダウンロード")をクリックしてください。

zip ファイルには、常に最新のサンプルが含まれています。 ダウンロードする際に GitHub のアカウントは必要ありません。 SDK の更新プログラムがリリースされた場合、または最新の変更内容や追加内容を選ぶ場合は、最新の zip ファイルを確認してください。

![サンプルのダウンロード](images/SamplesDownloadButton.png)


> [!NOTE]
> UWP のサンプルを開いたり、作成や実行したりする場合は、Visual Studio 2015 以降と Windows SDK が必要になります。 UWP アプリの構築をサポートする Visual Studio Community の無料コピーは[こちら](http://go.microsoft.com/fwlink/p/?LinkID=280676 "Windows development tools downloads")から入手できます。  
>
> また、個々のサンプルだけではなく、アーカイブ全体を解凍してください。 すべてのサンプルは、アーカイブ内の SharedContent フォルダーに依存しているためです。 UWP 機能のサンプルは、Visual Studio のリンク ファイルを使用して、共通ファイル (サンプルのテンプレート ファイルや画像アセットなど) の重複を減らします。 これらの共通ファイルは、リポジトリのルートにある SharedContent フォルダーに格納され、リンクを使用するプロジェクト ファイル内で参照されます。

zip ファイルをダウンロードしたら、Visual Studio でサンプルを開きます。

1.  アーカイブを解凍する前に、アーカイブを右クリックし、**[プロパティ]** > **[ブロックの解除]** > **[適用]** の順に選びます。 次に、アーカイブをコンピューター上のローカル フォルダーに展開します。

    ![解凍されたアーカイブ](images/SamplesUnzip1.png)
2.  [Samples] フォルダーには多くのフォルダーが含まれており、各フォルダーには UWP 機能のサンプルが含まれています。

    ![サンプルのフォルダー](images/SamplesUnzip2.png)

3.  ([Altimeter)] （高度計） などのサンプルを選ぶと、サポートされている言語を示す複数のフォルダーが表示されます。

    ![言語フォルダー](images/SamplesUnzip3.png)

4.  使用する言語 (C\# の場合は [CS]) を選ぶと、Visual Studio で開くことができる Visual Studio のソリューション ファイルが表示されます。

    ![VS ソリューション](images/SamplesUnzip4.png)

## <a name="give-feedback-ask-questions-and-report-issues"></a>フィードバックの提供、質問の投稿、問題の報告

問題や質問がある場合は、リポジトリの [Issues] タブを使用して、新しい問題や質問に関する報告を作成します。サポートできる問題や質問については、弊社で対応します。

![フィードバックの画像](images/GitHubUWPSamplesFeedback.png)
