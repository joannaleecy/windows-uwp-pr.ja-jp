---
author: PatrickFarley
ms.assetid: 78D833B9-E528-4BCA-9C48-A757F17E6C22
title: Windows アプリ認定キット
description: アプリにマイクロソフト ストアに公開するの最善の機会を与えるまたは Windows 認定、検証し、証明のために送信する前にローカルでテストします。 このトピックでは、Windows アプリ認定キットのインストール方法と実行方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: 10、uwp、ダイアログ ボックスの windows アプリ認定
ms.localizationpriority: medium
ms.openlocfilehash: b7a72a89704aa3768cc43cdfbb75b620bae303e3
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2917028"
---
# <a name="windows-app-certification-kit"></a>Windows アプリ認定キット



[Windows 認定](https://msdn.microsoft.com/windows/desktop/jj134964.aspx)アプリを取得または、[マイクロソフトのストアへの文書](https://msdn.microsoft.com/library/windows/apps/Hh694062)のための準備、検証し、テストをローカルで最初にする必要があります。 このトピックをインストールして、アプリは、安全で効率的なことを確認するのには[Windows アプリ認定キット](http://go.microsoft.com/fwlink/p/?LinkID=309666)を実行する方法を説明します。

## <a name="prerequisites"></a>前提条件

ユニバーサル Windows アプリのテストの前提条件:

-   Windows 10 をインストールして実行する必要があります。
-   Windows 10 用 Windows ソフトウェア開発キット (Windows SDK) に含まれる [Windows アプリ認定キット 10]( http://go.microsoft.com/fwlink/p/?LinkID=309666) をインストールする必要があります。
-   [開発用にデバイスを有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)必要があります。
-   テストする Windows アプリをコンピューターに展開する必要があります。

**一括アップグレードに関する注意事項**

最新の [Windows アプリ認定キット]( http://go.microsoft.com/fwlink/p/?LinkID=309666)をインストールすると、コンピューターにインストールされているキットの以前のバージョンが置き換えられます。

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-interactively"></a>Windows アプリ認定キットを使った Windows アプリをインタラクティブに検証する

1.  **[スタート]** メニューから、**[アプリ]**、**[Windows キット]** の順に進み、**[Windows アプリ認定キット]** をクリックします。

2.  [Windows アプリ認定キット] で、実行する検証のカテゴリを選びます。 たとえば、Windows アプリを検証する場合、**[Validate a Windows app]** (Windows アプリの検証) を選択します。

    テストするアプリを直接参照するか、UI で一覧からアプリを選ぶことができます。 Windows アプリ認定キットを初めて実行すると、UI にはコンピューターにインストールされているすべての Windows アプリが一覧表示されます。 以降の実行では、UI には検証済みの最新の Windows アプリが表示されます。 テストするアプリが表示されていない場合は、**[自分のアプリが表示されない]** をクリックして、システムにインストールされているすべてのアプリを一覧表示できます。

3.  テストするアプリを入力するか選択したら **[次へ]** をクリックします。

4.  次の画面からは、テストするアプリの種類に合ったテスト ワークフローが表示されます。 一覧でテストが淡色されている場合、お使いの環境にはそのテストが適用されません。 たとえば、Windows 7 で Windows 10 アプリをテストする場合、静的テストのみがワークフローに適用されます。 マイクロソフト ストアがこのワークフローのすべてのテストを適用可能性があることに注意してください。 実行するテストを選んで **[次へ]** をクリックします。

    Windows アプリ認定キットによってアプリの検証が開始されます。

5.  テストが終わった後のプロンプトで、テスト レポートを保存するフォルダーのパスを入力します。

    Windows アプリ認定キットによって XML 形式のレポートと共に HTML が作成され、このフォルダーに保存されます。

6.  レポート ファイルを開いて、テストの結果を確認します。

**注:** Visual Studio を使っている場合は、アプリ パッケージを作るときに Windows アプリ認定キットを実行できます。 方法については、「[UWP アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/Mt627715)」をご覧ください。

 

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-from-a-command-line"></a>コマンド ラインから Windows アプリ認定キットを使った Windows アプリを検証する

**重要**  Windows アプリ認定キットは、アクティブなユーザー セッションで実行する必要があります。

1.  コマンド ウィンドウで、Windows アプリ認定キットを含むディレクトリに移動します。

    **注:** 既定のパスは C:\\Program Files\\Windows Kits\\10\\App Certification Kit\\ です。

2.  次のコマンドをこの順序で入力し、テスト コンピューターにすでにインストールされているアプリをテストします。

    `appcert.exe reset`

    `appcert.exe test -packagefullname [package full name] -reportoutputpath [report file name]`

    または、アプリがインストールされていない場合は次のコマンドを使うことができます。 Windows アプリ認定キットにパッケージが開き、適切なテスト ワークフローが適用されます。

    `appcert.exe reset`

    `appcert.exe test -appxpackagepath [package path] -reportoutputpath [report file name]`

3.  テストが完了したら、`[report file name]` という名前のレポート ファイルを開いて、テスト結果を確認します。

**注:** Windows アプリ認定キットはサービスから実行できますが、サービスはアクティブなユーザー セッションでキットのプロセスを開始する必要があり、Session0 では実行できません。

**注:** Windows アプリ認定キットのコマンド ラインについて詳しく知るには、次のコマンドを入力します。 `appcert.exe /?`

## <a name="testing-with-a-low-power-computer"></a>低電力コンピューターでのテスト

Windows アプリ認定キットで使用するパフォーマンス テストのしきい値は、低電力コンピューターのパフォーマンスに基づいて設定します。

テストを実行するコンピューターの特性がテスト結果に影響することがあります。 インテル Atom プロセッサ ベースのコンピューターと 1366 x 768 以上の画面解像度、回転ハードなどの低電力コンピューターでアプリケーションをテストすることお勧めを調べるには、アプリケーションのパフォーマンスが[マイクロソフト ストアのポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)を満たしているかどうか、(ソリッド ・ ステート ・ ハード ・ ドライブ) ではなくドライブします。

低電力コンピューターの進化に伴い、パフォーマンスの特性が時間の経過と共に変化する可能性があります。 最新の[マイクロソフト ストアのポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)を参照してくださいし、アプリケーションが、最新のパフォーマンス要件に準拠しているかどうかを確認するのには、Windows アプリ認定キットの最新バージョンを使用してアプリケーションをテストします。

## <a name="related-topics"></a>関連トピック

* [Windows アプリ認定キットのテスト](windows-app-certification-kit-tests.md)
* [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 

 




