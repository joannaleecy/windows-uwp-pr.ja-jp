---
title: Unity で Xbox Live を構成する
description: Xbox Live Unity プラグインを使用して、Unity ゲームで Xbox Live を構成する方法について説明します。
ms.assetid: 55147c41-cc49-47f3-829b-fa7e1a46b2dd
ms.date: 01/25/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, 構成
localizationpriority: medium
ms.openlocfilehash: d464fc54d322db9da91870bd3ca7cbc29957b379
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596727"
---
# <a name="configure-xbox-live-in-unity"></a>Unity で Xbox Live を構成する

> [!NOTE]
> Xbox Live の Unity プラグインにのみ推奨[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)から現在のメンバーのアチーブメントまたはマルチ プレーヤー サポートはありません。

[Xbox Live の Unity プラグイン](https://github.com/Microsoft/xbox-live-unity-plugin)、Unity ゲームに Xbox Live のサポートの追加は簡単な多くの時間が最もがタイトルを合わせての方法で Xbox Live の使用に重点を提供します。

このトピックでは、Unity で Xbox Live プラグインをセットアップする手順について説明します。

## <a name="prerequisites"></a>前提条件

Xbox Live を使用 Unity で前に、次を必要となります。

1.  **[Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)** します。
1. 登録、 **[パートナー センター開発者プログラム](https://developer.microsoft.com/store/register)** します。
2. **[Windows 10 Anniversary Update](https://microsoft.com/windows)** またはそれ以降
3. **[Unity](https://store.unity.com/)** バージョン**5.5.4p5** (またはそれ以降)、 **2017.1p5** (またはそれ以降)、または**2017.2.0f3** (またはそれ以降) で**[Microsoft Visual Studio Tools for Unity](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity)** と**Windows ストアの .NET バックエンドをスクリプト**します。
4. **[Visual Studio 2015](https://www.visualstudio.com/)** または**[Visual Studio 2017 15.3.3](https://www.visualstudio.com/)** (またはそれ以降) で、**ユニバーサル Windows アプリ開発ツール**します。
5. **[Xbox Live プラットフォーム拡張機能 SDK](https://aka.ms/xblextsdk)** します。


> [!NOTE]
> Unity 2017.2.0p2 が必要で、Xbox Live il2cpp バック エンドのスクリプトのバックエンドを使用する場合は、またはそれ以降、Xbox Live の Unity プラグイン バージョン"1802 Preview Release"またはそれ以降。


## <a name="import-the-unity-plugin"></a>Unity プラグインをインポートする

新規または既存の Unity プロジェクトにプラグインをインポートするには、次の手順を実行します。

1. Xbox Live の Unity プラグイン [リリース] タブに移動します[ https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases)します。
2. ダウンロード**XboxLive.unitypackage**します。
3. Unity では、次のようにクリックします**資産** > **パッケージのインポート** > **カスタム パッケージ**に移動します**XboxLive.unitypackage。**.

![インポートに成功](../images/unity/get-started-with-creators/importXBL_Small.gif)

### <a name="optional-configure-the-plugin-to-work-in-the-unity-editor-net-46-or-il2cpp-only"></a>(省略可能)プラグインを構成する作業で、Unity エディター (.NET 4.6 または il2cpp バック エンドのみ)

> [!NOTE]
> Unity のスクリプトのランタイム バージョンを変更するには、Xbox Live の Unity プラグイン バージョン「1711 リリース」が必要です。 サポート以上の .NET 4.6 およびバージョン"1802 プレビュー リリース"以上 il2cpp バック エンドの。

コードのコンパイル方法を定義する Unity のように構成できる 3 つの設定があります。

1. **バックエンド スクリプト**が使用されるコンパイラ。 Unity は、ユニバーサル Windows プラットフォーム用の 2 つの異なるスクリプト バックエンドをサポートしています: .NET と il2cpp バック エンドです。
2. **Scripting Runtime Version** Unity エディターを実行するスクリプトのランタイムのバージョンです。
3. **API 互換性レベル**に対してゲームをビルドする API サーフェイスです。

次の表では、Xbox Live の Unity プラグインの現在のスクリプトのサポート マトリックスを示しています。

| スクリプトのバックエンド     | スクリプトのランタイム バージョン | サポート対象     | 必要な最小の Unity バージョン |
|-------------------    |-------------------        |-----------    |------------------------------- |
| IL2CPP バック エンド                | .NET 3.5 と同じです       | X            | なし                            |
| Il2cpp バック エンド                | .NET 4.6 対応       | 〇           | 2017.2.0p2                     |
| .NET                  | .NET 3.5 と同じです       | 〇           | 前提条件と同じ          |
| .NET                  | .NET 4.6 対応       | 〇           | 前提条件と同じ          |

スクリプトのランタイム サポートを追加、Xbox Live Unity プラグインを「1711 リリース」バージョン以降に追加されました。 既定では、プラグインが Unity エディターで、.net バックエンド スクリプトおよび .NET 3.5 のランタイムのバージョンのスクリプトを実行するように構成します。 プロジェクトが .NET 4.6 のスクリプトのランタイム バージョンを使用している場合は、エディターで正しく動作するようにプラグインを構成する必要があります。

1. Unity プロジェクト エクスプ ローラーに移動します。 **Xbox Live\Libs\UnityEditor\NET46**フォルダー内のすべての Dll を選択します。
2. インスペクター ウィンドウで確認**エディター** **含めるプラットフォーム**します。
3. Unity プロジェクト エクスプ ローラーに移動します。 **Xbox Live\Libs\UnityEditor\NET35**フォルダー内のすべての Dll を選択します。
4. Inspector] ウィンドウで、オフにします。**エディター** [**含めるプラットフォーム**します。

![スクリプト ランタイムを変更します。](../images/unity/get-started-with-creators/changeScriptingRuntime.gif)

> [!IMPORTANT]
> 次の手順は、3.5 にプロジェクトのスクリプトのランタイム バージョンを変更する場合を元に戻す必要があります。

## <a name="set-visual-studio-as-the-ide-in-unity"></a>Visual Studio を Unity に IDE として設定します。

Visual Studio がビルドに必要な[ユニバーサル Windows プラットフォーム (UWP)](https://docs.microsoft.com/windows/uwp/get-started/whats-a-uwp)ゲームです。 移動して Visual Studio を Unity でお使いの IDE を設定できる**編集** > **設定** > **外部ツール**の設定と**External Script Editor** Visual Studio にします。

![VS の外部ツールを設定します。](../images/unity/get-started-with-creators/setVSExternalTool_Small.gif)

## <a name="unity-plugin-file-structure"></a>Unity プラグインのファイル構造

Unity プラグインのファイル構造は、次の部分に分かれています。

* __Xbox Live__ には、公開された **.unitypackage** に含まれている実際のプラグイン アセットが含まれています。
    * __Editor__ には、基本的な Unity 構成 UI を表示し、ビルド時にプロジェクトを処理するスクリプトが含まれています。
    * __Examples__ には、さまざまなプレハブを使って相互に接続する方法を示す一連のシンプルなシーン ファイルが含まれています。
    * __Images__ は、プレハブにより使用される小さいイメージ セットです。
    * __Libs__ Xbox Live ライブラリが格納されます。
    * __Prefabs__ には、Xbox Live 機能を実装するさまざまな [Unity プレハブ](https://docs.unity3d.com/Manual/Prefabs.html) オブジェクトが含まれています。
    * __スクリプト__のプレハブから Xbox Live Api を呼び出すすべてのコード ファイルが含まれています。 これは、Xbox Live API を正しく呼び出す方法に関する例を探すのに最適な場所です。
    * __Tools\AssociationWizard__ 、Xbox Live の関連付けウィザード、アプリケーションからの構成をプルするために使用を含む[パートナー センター](https://developer.microsoft.com/windows) Unity 内で使用します。

## <a name="enable-xbox-live"></a>Xbox Live を有効にする

Xbox Live との対話にタイトル、Xbox Live の初期構成を設定する必要があります。 こうことに簡単にして、Unity 内で Xbox Live の関連付けウィザードを使用しています。

1. **[Xbox Live]** メニューで **[Configuration]** を選択します。
2. **[Xbox Live]** ウィンドウで、**[Run Xbox Live Association Wizard]** を選択します。
3. **タイトルを Windows ストアに関連付ける**ダイアログ ボックスで、 をクリックして**次へ**、パートナー センター アカウントでサインインします。
4. このプロジェクトに関連付けるアプリを選択し、**[Select]** をクリックします。 アプリが表示されない場合は、**[Refresh]** をクリックしてみてください。 または、名前を予約して **[Reserve]** をクリックすることで、新しいアプリを作成できます。
5. まだある場合、Xbox Live を有効にするように促されます。 クリックして**を有効にする**タイトルで Xbox Live を有効にします。
6. **[Finish]** をクリックして構成を保存します。

Xbox Live サービスを呼び出すには、デスクトップが開発者モードになってし、タイトルは、Xbox Live の構成と同じサンド ボックスに設定する必要があります。 調べることで両方を確認することができます、 **Xbox Live 構成**Unity でのウィンドウ。

1. **開発者モード構成**と答えるべき**有効**します。 **[Disabled]** になっている場合、**[Switch to Developer Mode]** をクリックします。
2. **構成タイトル** > **サンド ボックス**として ID が同じである必要があります**開発者モード構成** > **開発者モード**します。

![XBL 有効](../images/unity/unity-xbl-enabled.png)

参照してください[サンド ボックスの Xbox Live](../xbox-live-sandboxes.md)サンド ボックスについてはします。

## <a name="build-and-test-the-project"></a>プロジェクトのビルドおよびテスト

エディターでタイトルを実行しているとき、Xbox Live の機能を使おうとすると仮のデータが表示されます。 たとえば場合、する[サインオン機能を追加](unity-prefabs-and-sign-in.md)、シーンとサインインしようとする表示されます**偽のユーザー**プレース ホルダーのアイコン、プロファイル名として表示されます。 で実際のプロファイルを使用してサインインして、タイトルで Xbox Live の機能をテストするには、UWP ソリューションを構築し、Visual Studio で実行する必要があります。  次の手順では、Unity での UWP プロジェクトをビルドできます。

1. 開く、 **Build Settings**ウィンドウを選択して**ファイル** > **Build Settings**します。
2. すべての下で、ビルドに含めるシーンを追加、 **Scenes In Build**セクション。
3. 切り替えて、**ユニバーサル Windows プラットフォーム**を選択して**ユニバーサル Windows プラットフォーム****[プラットフォーム]** をクリック**スイッチ プラットフォーム**.
4. 設定**SDK**に**10.0.15063.0**以上。
5. スクリプトのデバッグ チェックを有効にする**UnityC#プロジェクト**します。
6. クリックして**ビルド**し、プロジェクトの場所を指定します。

![ビルド設定](../images/unity/build_settings.JPG)

ビルドが完了すると、Unity には、Visual Studio での実行に必要になる新しい UWP ソリューション ファイルが生成が。

1. 指定したフォルダーを開きます **&lt;ProjectName&gt;.sln** Visual Studio でします。
2. 上部にあるツールバーで選択**x64**を展開し、**ローカル マシン**します。

有効にした場合**スクリプトのデバッグ**Unity から UWP ソリューションを構築したときに、スクリプトに置かれます、**アセンブリ CSharp (ユニバーサル Windows)** プロジェクト。

![ユーザーを偽装します。123456789](../images/unity/get-started-with-creators/visualStudio.PNG)

> [!NOTE]
> Visual Studio のビルドを使用して、実際のデータを使用して、ゲームをテストする、前に以下の[このチェックリスト](test-visual-studio-build.md)タイトルが Xbox Live サービスにアクセスできるようにします。

> [!IMPORTANT]
> ようになりました 2018 必要な場合が Visual Studio で、UWP のタイトルを正しくテストするには、ある package.appxmanifest.xml ファイルに更新を作成します。 これには、次の手順を実行します。
>
> 1. Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。
> 2. ファイルを右クリックし、コードの表示を選択します。  
    コードの表示オプションは使用できません、package.appxmanifest ファイルで、拡張子が付いていない場合。 Xml ファイルを開き、残りの手順を続行する必要があります。
> 3. で、`<Properties></Properties>`セクションで、次の行を追加:`<uap:SupportedUsers>multiple</uap:SupportedUsers>`します。
> 4. お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。 Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。
>
> 構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。

## <a name="try-out-the-examples"></a>サンプルを試す

Unity プロジェクトで Xbox Live を使い始める準備ができました。 **Xbox Live/Examples** フォルダーにあるシーンを開いて、プラグインの動作と機能の使用方法の例をご自分で確認してください。 エディターの例を実行できるようになります仮のデータが、Visual Studio でプロジェクトをビルドする場合と[サンド ボックスで、Xbox Live アカウントを関連付ける](authorize-xbox-live-accounts.md)ゲーマータグでサインインすることができます。

Microsoft アカウントにサインインするには **SignInAndProfile** シーン、ランキングを作成するには **Leaderboard** シーン、統計を表示および更新するには **UpdateStat** シーンを試してみてください。

## <a name="see-also"></a>関連項目

* [Unity に住んで Xbox へのサインイン](unity-prefabs-and-sign-in.md)
* [Xbox Live アカウントを承認します。](authorize-xbox-live-accounts.md)
