---
ms.assetid: 78D833B9-E528-4BCA-9C48-A757F17E6C22
title: Windows アプリ認定キット
description: 作成したアプリを Microsoft Store に公開する、または Windows 認定を受ける最善の方法は、認定のためにアプリを提出する前に、ローカルでアプリの検証とテストを行うことです。 このトピックでは、Windows アプリ認定キットのインストール方法と実行方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10 は、uwp アプリの認定
ms.localizationpriority: medium
ms.openlocfilehash: b480e96621e143e283a2556bdbef394aaf7dbc07
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597437"
---
# <a name="windows-app-certification-kit"></a>Windows アプリ認定キット



アプリを取得する[Windows 認定](https://msdn.microsoft.com/windows/desktop/jj134964.aspx)の準備を行うまたは[Microsoft Store への発行](https://msdn.microsoft.com/library/windows/apps/Hh694062)、検証し、最初にテストがローカルにする必要があります。 このトピックでは、インストールして実行する方法、 [Windows アプリ認定キット](https://go.microsoft.com/fwlink/p/?LinkID=309666)アプリが安全で効率的なことを確認します。

## <a name="prerequisites"></a>前提条件

ユニバーサル Windows アプリのテストの前提条件:

-   インストールして、Windows 10 を実行する必要があります。
-   インストールする必要があります[Windows アプリ認定キットのバージョン 10]( https://go.microsoft.com/fwlink/p/?LinkID=309666)、Windows 10 用 Windows ソフトウェア開発キット (SDK) に含まれています。
-   [開発用にデバイスを有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)必要があります。
-   テストする Windows アプリをコンピューターに展開する必要があります。

**インプレース アップグレードに関する注意事項**

最新の [Windows アプリ認定キット]( https://go.microsoft.com/fwlink/p/?LinkID=309666)をインストールすると、コンピューターにインストールされているキットの以前のバージョンが置き換えられます。

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-interactively"></a>Windows アプリ認定キットを使った Windows アプリをインタラクティブに検証する

1.  **[スタート]** メニューから、**[アプリ]**、**[Windows キット]** の順に進み、**[Windows アプリ認定キット]** をクリックします。

2.  [Windows アプリ認定キット] で、実行する検証のカテゴリを選びます。 次に、例を示します。Windows アプリを検証する場合は、選択**Windows アプリを検証**です。

    テストするアプリを直接参照するか、UI で一覧からアプリを選ぶことができます。 Windows アプリ認定キットを初めて実行すると、UI にはコンピューターにインストールされているすべての Windows アプリが一覧表示されます。 以降の実行では、UI には検証済みの最新の Windows アプリが表示されます。 テストするアプリが表示されていない場合は、**[自分のアプリが表示されない]** をクリックして、システムにインストールされているすべてのアプリを一覧表示できます。

3.  テストするアプリを入力するか選択したら **[次へ]** をクリックします。

4.  次の画面からは、テストするアプリの種類に合ったテスト ワークフローが表示されます。 一覧でテストが淡色されている場合、お使いの環境にはそのテストが適用されません。 たとえば、Windows 7 で Windows 10 アプリをテストする場合、静的テストのみがワークフローに適用されます。 Microsoft Store がワークフローからすべてのテストを適用可能性がありますに注意してください。 実行するテストを選んで **[次へ]** をクリックします。

    Windows アプリ認定キットによってアプリの検証が開始されます。

5.  テストが終わった後のプロンプトで、テスト レポートを保存するフォルダーのパスを入力します。

    Windows アプリ認定キットによって XML 形式のレポートと共に HTML が作成され、このフォルダーに保存されます。

6.  レポート ファイルを開いて、テストの結果を確認します。

**注**  Visual Studio を使用している場合、アプリ パッケージを作成するときに、Windows アプリ認定キットを実行できます。 方法については、「[UWP アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/Mt627715)」をご覧ください。

 

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-from-a-command-line"></a>コマンド ラインから Windows アプリ認定キットを使った Windows アプリを検証する

**重要な**  Windows アプリ認定キットは、アクティブなユーザー セッションのコンテキスト内で実行する必要があります。

1.  コマンド ウィンドウで、Windows アプリ認定キットを含むディレクトリに移動します。

    **注**  既定のパスは c:\\Program Files\\Windows キット\\10\\アプリ認定キット\\します。

2.  次のコマンドをこの順序で入力し、テスト コンピューターにすでにインストールされているアプリをテストします。

    `appcert.exe reset`

    `appcert.exe test -packagefullname [package full name] -reportoutputpath [report file name]`

    または、アプリがインストールされていない場合は次のコマンドを使うことができます。 Windows アプリ認定キットにパッケージが開き、適切なテスト ワークフローが適用されます。

    `appcert.exe reset`

    `appcert.exe test -appxpackagepath [package path] -reportoutputpath [report file name]`

3.  テストが完了したら、`[report file name]` という名前のレポート ファイルを開いて、テスト結果を確認します。

**注**  サービスから、Windows アプリ認定キットを実行できますが、サービスは、アクティブなユーザー セッション内でキット プロセスを開始する必要があり、Session0 で実行することはできません。

**注**   Windows アプリ認定キットのコマンドラインの詳細については、コマンドを入力します。 `appcert.exe /?`

## <a name="testing-with-a-low-power-computer"></a>低電力コンピューターでのテスト

Windows アプリ認定キットで使用するパフォーマンス テストのしきい値は、低電力コンピューターのパフォーマンスに基づいて設定します。

テストを実行するコンピューターの特性がテスト結果に影響することがあります。 アプリのパフォーマンスが満たしているかどうかを判断する、 [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)画面の解像度の 1366 x 768 (または以降)、Intel Atom プロセッサ ベース コンピュータなどの低電力コンピューターでアプリをテストすることをお勧めします。(ソリッドステート ドライブ) ではなく、回転のハード ドライブを選択します。

低電力コンピューターの進化に伴い、パフォーマンスの特性が時間の経過と共に変化する可能性があります。 最新を参照してください[Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)し、アプリが最新のパフォーマンス要件に準拠しているかどうかを確認するには、Windows アプリ認定キットの最新バージョンを使用してアプリケーションをテストします。

## <a name="related-topics"></a>関連トピック

* [Windows アプリ認定キット テスト](windows-app-certification-kit-tests.md)
* [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 

 




