---
author: mcleblanc
ms.assetid: 78D833B9-E528-4BCA-9C48-A757F17E6C22
title: Windows アプリ認定キット
description: 作成したアプリを Windows ストアに公開する、または、Windows 認定を受ける一番の方法は、認定のためアプリを提出する前に、ローカルでアプリの検証とテストを行うことです。 このトピックでは、Windows アプリ認定キットのインストール方法と実行方法について説明します。
---
# Windows アプリ認定キット

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


作成したアプリを [Windows ストアに公開](https://msdn.microsoft.com/library/windows/apps/Hh694062)する、または [Windows 認定](https://msdn.microsoft.com/windows/desktop/jj134964.aspx)を受ける最善の方法は、認定のためアプリを提出する前に、ローカルでアプリの検証とテストを行うことです。 このトピックでは、[Windows アプリ認定キット](http://go.microsoft.com/fwlink/p/?LinkID=309666)のインストール方法と実行方法について説明します。

## 前提条件

ユニバーサル Windows アプリのテストの前提条件:

-   Windows 10 をインストールして実行する必要があります。
-   Windows 10 用 Windows ソフトウェア開発キット (Windows SDK) に含まれる [Windows アプリ認定キット 10]( http://go.microsoft.com/fwlink/p/?LinkID=309666) をインストールする必要があります。
-   コンピューターに有効な開発者用ライセンスが必要です。 方法については、「[開発者用ライセンスの取得](https://msdn.microsoft.com/library/windows/apps/Hh974578)」をご覧ください。
-   テストする Windows アプリをコンピューターに展開する必要があります。

**一括アップグレードに関する注意事項**

最新の [Windows アプリ認定キット]( http://go.microsoft.com/fwlink/p/?LinkID=309666)をインストールすると、コンピューターにインストールされているキットの以前のバージョンが置き換えられます。

## Windows アプリ認定キットを使った Windows アプリをインタラクティブに検証する

1.  **[スタート]** メニューから、**[アプリ]**、**[Windows キット]** の順に進み、**[Windows アプリ認定キット]** をクリックします。

2.  [Windows アプリ認定キット] で、実行する検証のカテゴリを選びます。 たとえば、Windows アプリを検証する場合、**[Validate a Windows app]** (Windows アプリの検証) を選択します。

    テストするアプリを直接参照するか、UI で一覧からアプリを選ぶことができます。 Windows アプリ認定キットを初めて実行すると、UI にはコンピューターにインストールされているすべての Windows アプリが一覧表示されます。 以降の実行では、UI には検証済みの最新の Windows アプリが表示されます。 テストするアプリが表示されていない場合は、**[自分のアプリが表示されない]** をクリックして、システムにインストールされているすべてのアプリを一覧表示できます。

3.  テストするアプリを入力するか選択したら **[次へ]** をクリックします。

4.  次の画面からは、テストするアプリの種類に合ったテスト ワークフローが表示されます。 一覧でテストが淡色されている場合、お使いの環境にはそのテストが適用されません。 たとえば、Windows 7 で Windows 10 アプリをテストする場合、静的テストのみがワークフローに適用されます。 Windows ストアにはこのワークフローのすべてのテストを適用できる点に注意してください。 実行するテストを選んで **[次へ]** をクリックします。

    Windows アプリ認定キットによってアプリの検証が開始されます。

5.  テストが終わった後のプロンプトで、テスト レポートを保存するフォルダーのパスを入力します。

    Windows アプリ認定キットによって XML 形式のレポートと共に HTML が作成され、このフォルダーに保存されます。

6.  レポート ファイルを開いて、テストの結果を確認します。

**注:** Visual Studio を使っている場合は、アプリ パッケージを作るときに Windows アプリ認定キットを実行できます。 方法については、「[UWP アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/Mt627715)」をご覧ください。

 

## コマンド ラインから Windows アプリ認定キットを使った Windows アプリを検証する

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

**注:** Windows アプリ認定キットのコマンド ラインについて詳しく知るには、コマンド「」を入力します。 `appcert.exe /?`

## 低電力コンピューターでのテスト

Windows アプリ認定キットで使用するパフォーマンス テストのしきい値は、低電力コンピューターのパフォーマンスに基づいて設定します。

テストを実行するコンピューターの特性がテスト結果に影響することがあります。 アプリのパフォーマンスが [Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)を満たしているかどうかを判断するには、アプリを低電力コンピューター (たとえば画面の解像度が 1366x768 またはそれ以上で、ソリッド ステート ハード ドライブではなく回転式ハード ドライブを搭載した Intel Atom プロセッサ ベースのコンピューター) 上でテストすることをお勧めします。

低電力コンピューターの進化に伴い、パフォーマンスの特性が時間の経過と共に変化する可能性があります。 アプリが最新のパフォーマンス要件を満たすように、最新の [Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944) を参照し、最新版の Windows アプリ認定キットでアプリをテストしてください。

## 関連トピック

* [Windows アプリ認定キットのテスト](windows-app-certification-kit-tests.md)
* [Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 

 






<!--HONumber=May16_HO2-->


