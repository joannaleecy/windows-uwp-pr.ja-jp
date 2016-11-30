---
title: "GitHub からユニバーサル Windows プラットフォーム (UWP) のサンプルを取得する"
description: "GitHub から UWP 機能のサンプルをダウンロードする方法について説明します"
author: JoshuaPartlow
translationtype: Human Translation
ms.sourcegitcommit: 27f98124d8360c3d0266645660b35cf040af0ef0
ms.openlocfilehash: dbd2d5d7924cfbfd48d20f48ccfcd4bfe62db645

---

#GitHub からユニバーサル Windows プラットフォーム (UWP) のサンプルを取得する
UWP アプリのサンプルは、GitHub のリポジトリを利用して入手できます。 初めて UWP を操作する場合は、[Microsoft/Windows-universal-samples](https://github.com/Microsoft/Windows-universal-samples) リポジトリを最初に使用することをお勧めします。このリポジトリには、すべての UWP 機能と API の使用パターンを示すサンプルが含まれています。  
![GitHub の UWP サンプルのリポジトリ](images/GitHubUWPSamplesPage.png) デベロッパー センターの「[サンプル](https://developer.microsoft.com/windows/samples)」セクションを利用すると、その他のサンプルを探すことができます。  

##コードのダウンロード
サンプルをダウンロードするには、[リポジトリ](https://github.com/Microsoft/Windows-universal-samples)にアクセスして、**[Clone or download]** を選んでから **[Download ZIP]** を選びます。 または、[ここ](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip) をクリックします。

zip ファイルには、常に最新のサンプルが含まれています。 ダウンロードする際に GitHub のアカウントは必要ありません。 SDK の更新プログラムがリリースされた場合、または最新の変更内容や追加内容を選ぶ場合は、最新の zip ファイルを確認してください。

![サンプルのダウンロード](images/SamplesDownloadButton.png)


> **注**: UWP のサンプルを開いたり、作成や実行したりする場合は、Visual Studio 2015 と Windows SDK が必要になります。 Visual Studio をまだインストールしていない場合は、[ここ](http://go.microsoft.com/fwlink/p/?LinkID=280676)から、UWP アプリの作成をサポートする Visual Studio 2015 Community Edition を無料で入手できます。  
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

## フィードバックの提供、質問の投稿、問題の報告

問題や質問がある場合は、リポジトリの [Issues] タブを使用して、新しい問題や質問に関する報告を作成します。サポートできる問題や質問については、弊社で対応します。

![フィードバックの画像](images/GitHubUWPSamplesFeedback.png)



<!--HONumber=Nov16_HO1-->


