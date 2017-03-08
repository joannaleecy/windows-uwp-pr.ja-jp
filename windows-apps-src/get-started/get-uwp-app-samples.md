---
title: "GitHub からユニバーサル Windows プラットフォーム (UWP) のサンプルを取得する"
description: "GitHub から UWP 機能のサンプルをダウンロードする方法について説明します"
author: JoshuaPartlow
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 393c5a81-ee14-45e7-acd7-495e5d916909
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 93dde6fe68275987c16562370ba277072e5467a9
ms.lasthandoff: 02/08/2017

---

#<a name="get-the-universal-windows-platform-uwp-samples-from-github"></a>GitHub からユニバーサル Windows プラットフォーム (UWP) のサンプルを取得する
UWP アプリのサンプルは、GitHub のリポジトリを利用して入手できます。 初めて UWP を操作する場合は、[Microsoft/Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples "Universal Windows Platform app samples GitHub repository") リポジトリを最初に使用することをお勧めします。このリポジトリには、すべての UWP 機能と API の使用パターンを示すサンプルが含まれています。  
![GitHub の UWP サンプルのリポジトリ](images/GitHubUWPSamplesPage.png) デベロッパー センターの「[サンプル](https://developer.microsoft.com/windows/samples "Dev Center samples")」セクションを利用すると、その他のサンプルを探すことができます。  

##<a name="download-the-code"></a>コードのダウンロード
サンプルをダウンロードするには、[リポジトリ](https://github.com/Microsoft/Windows-universal-samples "ユニバーサル Windows プラットフォーム アプリのサンプル GitHub リポジトリ")に移動し、**[Clone or download]**、**[Download ZIP]** の順に選択します。 または、[ここ](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip "ユニバーサル Windows プラットフォーム アプリのサンプル zip ファイルのダウンロード")をクリックしてください。

zip ファイルには、常に最新のサンプルが含まれています。 ダウンロードする際に GitHub のアカウントは必要ありません。 SDK の更新プログラムがリリースされた場合、または最新の変更内容や追加内容を選ぶ場合は、最新の zip ファイルを確認してください。

![サンプルのダウンロード](images/SamplesDownloadButton.png)


> **注**: UWP のサンプルを開いたり、作成や実行したりする場合は、Visual Studio 2015 と Windows SDK が必要になります。 Visual Studio をまだインストールしていない場合は、[ここ](http://go.microsoft.com/fwlink/p/?LinkID=280676 "Windows 開発ツールのダウンロード")から、UWP アプリの作成をサポートする Visual Studio 2015 Community Edition を無料で入手できます。  
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

