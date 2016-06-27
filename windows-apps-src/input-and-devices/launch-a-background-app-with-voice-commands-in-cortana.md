---
author: Karl-Bridge-Microsoft
Description: "Cortana 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、アプリ内で実行するアクションやコマンドを指定する音声コマンドを使うバックグラウンド アプリの機能によって Cortana を拡張することもできます。"
title: "Cortana の音声コマンドを使ったバックグラウンド アプリの起動"
ms.assetid: DF5B530C-57DD-4CA5-B3BE-1A0B3695C9C6
label: Launch a background app
template: detail.hbs
ms.sourcegitcommit: 7d9f5eff0f6561b18024658fe99d1e11bbe3309f
ms.openlocfilehash: c65abdda905a390567d3c2b199a891c0c3067df1

---

# Cortana の音声コマンドを使ったバックグラウンド アプリのアクティブ化

**Cortana** 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、実行するアクションやコマンドを指定する音声コマンドを使うアプリの機能 (バックグラウンド タスク) によって **Cortana** を拡張することもできます。 アプリはバックグラウンドで音声コマンドを処理するとき、フォーカスを取得しません。 その代わり、**Cortana** キャンバスと **Cortana** 音声を介して、すべてのフィードバックと結果が返されます。

**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)



アプリは、操作の複雑さに応じて、フォアグラウンド (アプリがフォーカスを取得します) またはバックグラウンド (**Cortana** がフォーカスを維持します) でアクティブ化することができます。 たとえば、追加のコンテキストやユーザー入力 (特定の連絡先へのメッセージの送信など) が必要な音声コマンドはフォアグラウンド アプリで処理するのが最適ですが、基本的なコマンド (旅行の予定の一覧表示など) はバックグラウンド アプリを介して **Cortana** で処理できます。

音声コマンドを使用してフォアグラウンドでアプリをアクティブ化する場合は、「[Cortana の音声コマンドを使ったフォアグラウンド アプリのアクティブ化](launch-a-foreground-app-with-voice-commands-in-cortana.md)」をご覧ください。

> **注**  
> 音声コマンドは、具体的な目的を持って 1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。

> VCD ファイルでは、1 つ以上の音声コマンドが定義されており、各音声コマンドは固有の目的を持っています。

> 音声コマンド定義にはさまざまなものがあり、定義が複雑になる場合があります。 音声コマンド定義では、制限された 1 つの言葉の発声から、より柔軟性の高い自然言語の発声のコレクションまで、あらゆる発声をサポートできます。ただし、これらの発声はすべて、同じ目的を示している必要があります。

バックグラウンド アプリの機能を示すために、[Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)の **Adventure Works** という旅行の計画および管理アプリを使用します。

**Cortana** のキャンバスに統合された **Adventure Works** アプリの概要は次のとおりです。

![Cortana のキャンバスの概要 ](images/cortana-overview.png)

**Cortana** を使わないで **Adventure Works** の旅行を表示するには、アプリを起動して **[Upcoming trips]** (今後の旅行) ページに移動します。

**Cortana** の音声コマンドを使ってアプリをバックグラウンドで起動する場合、代わりに「Adventure Works に登録されている次のラスベガス旅行はいつですか」と言うことができます。 アプリによりコマンドが処理され、**Cortana** にアプリ アイコンや他のアプリ情報 (ある場合) と共に結果が表示されます。 基本的な旅行クエリと **Cortana** の結果画面の例を次に示します。どちらにも、「次のラスベガス旅行は 2015 年 7 月 31 日、金曜日です」という意味の内容が示されます。

![Adventure Works アプリをバックグラウンドで使った場合の基本的なクエリと結果画面](images/cortana-backgroundapp-result.png)

以下は、音声コマンド機能を追加し、音声またはキーボード入力を使うアプリのバックグラウンド機能によって **Cortana** を拡張する基本的な手順です。

1.  **Cortana** がバックグラウンドで呼び出すアプリ サービスを作成します (「[**Windows.ApplicationModel.AppService**](https://msdn.microsoft.com/library/windows/apps/dn921731)」をご覧ください)。
2.  VCD ファイルを作ります。 これは、アプリをアクティブ化して操作を開始するかコマンドを呼び出すためにユーザーが発声できる音声コマンドをすべて定義する XML ドキュメントです。 「[**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)」をご覧ください。
3.  アプリが起動したら、VCD ファイル内のコマンド セットを登録します。
4.  アプリ サービスのバックグラウンド アクティブ化と音声コマンドの実行を処理します。
5.  **Cortana** 内で音声コマンドに対する適切なフィードバックを表示して読み上げます。

**前提条件:  **

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては[音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)をご覧ください。

## <span id="Create_a_new_solution_with_a_primary_project_in_Visual_Studio"></span><span id="create_a_new_solution_with_a_primary_project_in_visual_studio"></span><span id="CREATE_A_NEW_SOLUTION_WITH_A_PRIMARY_PROJECT_IN_VISUAL_STUDIO"></span>Visual Studio でのプライマリ プロジェクトを使った新しいソリューションの作成


1.  Microsoft Visual Studio 2015 を起動します。

    Visual Studio 2015 のスタート画面が表示されます。

2.  **[ファイル]** メニューの **[新規作成]** > **[プロジェクト]** の順にクリックします。

    **[新しいプロジェクト]** ダイアログ ボックスが表示されます。 ダイアログの左側のウィンドウで、表示するテンプレートの種類を選択できます。

3.  左側のウィンドウで、**[インストール済み]、[テンプレート]、[Visual C\#]、[Windows]** の順に展開した後、**[ユニバーサル]** テンプレート グループを選びます。 ユニバーサル Windows プラットフォーム (UWP) アプリで使うことができるプロジェクト テンプレートの一覧がダイアログの中央のウィンドウに表示されます。
4.  中央のウィンドウで、**[空白のアプリ (ユニバーサル Windows)]** プロジェクト テンプレートを選びます。

    **[空白のアプリ]** テンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールは、このチュートリアルの途中でアプリに追加します。

5.  **[名前]** ボックスで、プロジェクト名を入力します。 この例では、"AdventureWorks" を使用します。
6.  **[OK]** をクリックしてプロジェクトを作ります。

    Microsoft Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。


## <span id="Add_image_assets_to_primary_project_and_specify_them_in_the_app_manifest"></span><span id="add_image_assets_to_primary_project_and_specify_them_in_the_app_manifest"></span><span id="ADD_IMAGE_ASSETS_TO_PRIMARY_PROJECT_AND_SPECIFY_THEM_IN_THE_APP_MANIFEST"></span>画像アセットをプライマリ プロジェクトに追加してアプリ マニフェストで指定する
      
UWP アプリでは、特定の設定とデバイス機能 (ハイ コントラスト、有効ピクセル、ロケールなど) に基づいて最適な画像を自動的に選択できます。 必要な作業は、画像を提供し、リソースのバージョンごとに、アプリ プロジェクト内で適切な名前付け規則とフォルダー構造を使用していることを確認することだけです。 推奨されるリソースのバージョンが提供されない場合、ユーザーの基本設定、身体能力、デバイスの種類、場所によって、アクセシビリティ、ローカライズ、画像の品質が影響を受ける可能性があります。

ハイ コントラストとスケール ファクター用の画像リソースについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets)」をご覧ください。

修飾子を使ってリソースに名前を付けます。 リソース修飾子は、リソースの特定のバージョンが使われるコンテキストを識別するフォルダーとファイル名の修飾子です。

標準の命名規則は、`foldername/qualifiername-value[_qualifiername-value]/filename.qualifiername-value[_qualifiername-value].ext` です。 たとえば、`images/en-US/logo.scale-100_contrast-white.png` は、コード内ではルート フォルダーとファイル名を使用して単に `images/logo.png` と参照されます。 「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324.aspx)」をご覧ください。

ローカライズされたリソースや複数の解像度のリソースの提供を現在計画していない場合でも、文字列リソース ファイルに既定の言語をマークし (`en-US\resources.resw` など)、画像に既定のスケール ファクターをマークする (`logo.scale-100.png` など) ことをお勧めします。 ただし、100、200、400 の倍率のアセットを提供することをお勧めします。

> *重要

> **Cortana** キャンバスのタイトル領域で使用するアプリ アイコンは、"Package.appxmanifest" ファイルで指定される Square44x44Logo アイコンです。 

> **Cortana** キャンバスのコンテンツ領域で各エントリのアイコンを指定することもできます。 結果のアイコンに対して有効な画像のサイズは次のとおりです。

> - 幅 68 x 高さ 68 
> - 幅 68 x 高さ 92 
> - 幅 280 x 高さ 140 

コンテンツ タイルは、[**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) が [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) に渡されるまで検証されません。 画像がこれらのサイズ比率に準拠していないコンテンツ タイルを含む **VoiceCommandResponse** オブジェクトを **Cortana** に渡した場合、例外が発生する可能性があります。 

この **Adventure Works** アプリ (VoiceCommandService\\AdventureWorksVoiceCommandService.cs) の例では、[**TitleWith68x68IconAndText**](https://msdn.microsoft.com/library/windows/apps/dn974169) タイル テンプレートを使用して、単純な灰色の四角形 ("GreyTile.png") を [**VoiceCommandContentTile**](https://msdn.microsoft.com/library/windows/apps/dn974168) 上に指定します。 ロゴのバリアントは VoiceCommandService\\Images にあり、[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) メソッドを使って取得できます。

```CSharp
var destinationTile = new VoiceCommandContentTile();

destinationTile.ContentTileType = 
  VoiceCommandContentTileType.TitleWith68x68IconAndText;
destinationTile.Image = 
  await StorageFile.GetFileFromApplicationUriAsync(
    new Uri("ms-appx:///AdventureWorks.VoiceCommands/Images/GreyTile.png"));
```

## <span id="Create_an_app_service_project"></span><span id="create_an_app_service_project"></span><span id="CREATE_AN_APP_SERVICE_PROJECT"></span>アプリ サービス プロジェクトの作成

<ol>
    <li>
ソリューションの名前を右クリックし、**[新規作成]、[プロジェクト]** の順にクリックします。
    </li>
    <li>
**[インストール済み]、[テンプレート]、[Visual C#]、[Windows]、[ユニバーサル]** の順にクリックし、**[Windows ランタイム コンポーネント]** をクリックします。 これは、アプリ サービス (**[Windows.ApplicationModel.AppService](https://msdn.microsoft.com/library/windows/apps/dn921731)**) を実装するコンポーネントです。
    </li>
    <li>
プロジェクトの名前 (たとえば、"VoiceCommandService") を入力し、**[OK]** をクリックします。
    </li>
    <li>
**ソリューション エクスプローラー**で、"VoiceCommandService" プロジェクトを選び、Visual Studio によって生成された "Class1.cs" ファイルの名前を変更します。 **Adventure Works** の例では、"AdventureWorksVoiceCommandService.cs" を使います。
    </li>
    <li>
"Class1.cs" のすべての出現箇所の名前を変更するかどうかをたずねるメッセージが表示されたら、**[はい]** をクリックします。 
    </li>
    <li>
"AdventureWorksVoiceCommandService.cs" ファイルで、次の操作を行います。 <ol type="i">
 <li>
次の using ディレクティブを追加します。  
 ```using Windows.ApplicationModel.Background;```
 </li>
 <li>
新しいプロジェクトを作成するときに、プロジェクト名は、すべてのファイルで既定のルート名前空間として使用されます。 プライマリ プロジェクトの下でアプリ サービスのコードを入れ子にするために、名前空間の名前を変更します。 たとえば、`namespace AdventureWorks.VoiceCommands` と記述します。 
 </li>
 <li>
ソリューション エクスプローラーでアプリ サービスのプロジェクト名を右クリックし、**[プロパティ]** を選択します。 
 </li>
 <li>
**[ライブラリ]** タブで、**"既定の名前空間"** フィールドをこの同じ値で更新します (たとえば、"AdventureWorks.VoiceCommands")。 
 </li>
 <li>
[
            **IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを作成します。 このクラスには、Cortana が音声コマンドを認識するときのエントリ ポイントである [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドが必要です。 
 </li>
        </ol>
    </li>
</ol>

**Adventure Works** アプリの基本的なバックグラウンド タスク クラスは次のとおりです。 後でさらに詳しく入力します。
> **注**    
> バックグラウンド タスク クラス自体と、バックグラウンド タスク プロジェクト内のその他すべてのクラスは、sealed public クラスである必要があります。
 
``` csharp
namespace AdventureWorks.VoiceCommands
{
    ...
    
    /// <summary>
    /// The VoiceCommandService implements the entry point for all voice commands.
    /// The individual commands supported are described in the VCD xml file. 
    /// The service entry point is defined in the appxmanifest.
    /// </summary>
    public sealed class AdventureWorksVoiceCommandService : IBackgroundTask
    {
        ...
        
        /// <summary>
        /// The background task entrypoint. 
        /// 
        /// Background tasks must respond to activation by Cortana within 0.5 seconds, and must 
        /// report progress to Cortana every 5 seconds (unless Cortana is waiting for user
        /// input). There is no execution time limit on the background task managed by Cortana,
        /// but developers should use plmdebug (https://msdn.microsoft.com/library/windows/hardware/jj680085%28v=vs.85%29.aspx)
        /// on the Cortana app package in order to prevent Cortana timing out the task during
        /// debugging.
        /// 
        /// The Cortana UI is dismissed if Cortana loses focus. 
        /// The background task is also dismissed even if being debugged. 
        /// Use of Remote Debugging is recommended in order to debug background task behaviors. 
        /// Open the project properties for the app package (not the background task project), 
        /// and enable Debug -> "Do not launch, but debug my code when it starts". 
        /// Alternatively, add a long initial progress screen, and attach to the background task process while it executes.
        /// </summary>
        /// <param name="taskInstance">Connection to the hosting background service process.</param>
        public void Run(IBackgroundTaskInstance taskInstance)
        {
        
          //
          // TODO: Insert code 
          //
          //
        
    }        
  }
}
```

<ol start="7">
    <li>
アプリ マニフェストでバックグラウンド タスクを **AppService** として宣言します。
    <ol type="i">
        <li>
**ソリューション エクスプローラー**で、"Package.appxmanifest" ファイルを右クリックして **[コードの表示]** を選択します。 
        </li>
        <li>
[
            **Application**](https://msdn.microsoft.com/library/windows/apps/dn934738) 要素を探します。
        </li>
        <li>
[
            **Extensions**](https://msdn.microsoft.com/library/windows/apps/dn934720) 要素を [**Application**](https://msdn.microsoft.com/library/windows/apps/dn934738) 要素に追加します。
        </li>
        <li>
[
            **uap:Extension**](https://msdn.microsoft.com/library/windows/apps/dn986788) 要素を [**Extensions**](https://msdn.microsoft.com/library/windows/apps/dn934720) 要素に追加します。
        </li>
        <li>**Category** 属性を **uap:Extension** 要素に追加し、**Category** 属性の値を "windows.appService" に設定します。
        </li>
        <li>
**EntryPoint** 属性を **uap:Extension** 要素に追加し、**EntryPoint** 属性の値を、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) を実装するクラスの名前 (この場合は "AdventureWorks.VoiceCommands.AdventureWorksVoiceCommandService") に設定します。
        </li>
        <li>
[
            **uap:AppService**](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素を **uap:Extension** 要素に追加します。
        </li>
        <li>
**Name** 属性を [**uap:AppService**](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素に追加し、**Name** 属性の値を、アプリ サービスの名前 (この場合は "AdventureWorksVoiceCommandService") に設定します。
        </li>
        <li>
2 つ目の [**uap:Extension**](https://msdn.microsoft.com/library/windows/apps/dn986788) 要素を [**Extensions**](https://msdn.microsoft.com/library/windows/apps/dn934720) に追加します。
        </li>
        <li>
**Category** 属性をこの [**uap:Extension**](https://msdn.microsoft.com/library/windows/apps/dn986788) 要素に追加し、**Category** 属性の値を "windows.personalAssistantLaunch" に設定します。
        </li>
    </li> 
    </ol>
    </li>    
</ol>  

Adventure Works アプリのマニフェストを次に示します。
```xml
<Package>
  <Applications>
    <Application>

      <Extensions>
        <uap:Extension Category="windows.appService" 
          EntryPoint="CortanaBack1.VoiceCommands.CortanaBack1VoiceCommandService">
          <uap:AppService Name="CortanaBack1VoiceCommandService"/>
        </uap:Extension>
        <uap:Extension Category="windows.personalAssistantLaunch"/>
      </Extensions>

    <Application>
  <Applications>
</Package>
```

<ol start="8">
    <li>
このアプリ サービス プロジェクトをプライマリ プロジェクトの参照として追加します。 
    <ol type="i">
        <li>
**[参照設定]** を右クリックします。 
        </li>
        <li>
**[参照の追加...]** をクリックします。 
        </li>
        <li>
**[参照マネージャー]** ダイアログ ボックスで、**[プロジェクト]** を展開し、アプリ サービス プロジェクトを選択します。 
        </li>
        <li>
[OK] をクリックします。 
        </li>
    </ol>
    </li>
</ol>

## <span id="Create_a_VCD_file"></span><span id="create_a_vcd_file"></span><span id="CREATE_A_VCD_FILE"></span>VCD ファイルの作成


1. Visual Studio で、プライマリ プロジェクト名を右クリックし、**[追加]、[新しい項目]** の順にクリックします。 **XML ファイル**を追加します。
2. [
            **VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルの名前 (この例では、"AdventureWorksCommands.xml") を入力し、[追加] をクリックします。 
3. **ソリューション エクスプローラー**で、[**VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルを選びます。
4.  **[プロパティ]** ウィンドウで、**[ビルド アクション]** を **[コンテンツ]** に設定し、**[出力ディレクトリにコピー]** を **[常にコピーする]** に設定します。

## <span id="Edit_the_VCD_file"></span><span id="edit_the_vcd_file"></span><span id="EDIT_THE_VCD_FILE"></span>VCD ファイルの編集

1. `http://schemas.microsoft.com/voicecommands/1.2` を指す **xmlns** 属性を持つ **VoiceCommands** 要素を追加します。

2. アプリがサポートする各言語に対して、アプリがサポートする音声コマンドを含む [**CommandSet**](https://msdn.microsoft.com/library/windows/apps/dn722331) 要素を作成します。

  複数の [**CommandSet**](https://msdn.microsoft.com/library/windows/apps/dn722331) 要素を宣言し、それぞれに異なる [**xml:lang**](https://msdn.microsoft.com/library/windows/apps/dn722331) 属性を指定することで、アプリをさまざまな市場で使うことができるようにします。 たとえば、米国用のアプリに、英語の [**CommandSet**](https://msdn.microsoft.com/library/windows/apps/dn722331) とスペイン語の [**CommandSet**](https://msdn.microsoft.com/library/windows/apps/dn722331) を含めることができます。

  >  **注意**  
  音声コマンドを使ってアプリをアクティブ化して操作を開始するには、ユーザーがデバイスで選んだ音声の言語に一致する言語を含む [**CommandSet**](https://msdn.microsoft.com/library/windows/apps/dn722331) を格納している VCD ファイルをアプリで登録する必要があります。 音声の言語は、**[設定]、[システム]、[音声認識]、[音声認識の言語]** にあります。

3. サポートする各コマンドの **Command** 要素を追加します。

  [
            **VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルで宣言された各 **Command** は、次の情報を含む必要があります。

  - アプリが実行時に音声コマンドを識別するために使用する **Name** 属性。 
  - ユーザーがコマンドを呼び出す方法を説明する語句を含む **Example** 要素。 ユーザーが「何と言ったらよいですか」、「ヘルプ」と言ったり、**[もっと見る]** をタップしたときに、**Cortana** にこの例が表示されます。    
  -   アプリがコマンドとして認識する単語または語句を含む **ListenFor** 要素。 各 **ListenFor** 要素には、コマンドに関連する特定の単語を含む 1 つまたは複数の **PhraseList** 要素への参照を格納できます。
  > **注**  
  **ListenFor** 要素はプログラムで変更できません。 ただし、**ListenFor** 要素に関連付けられた **PhraseList** 要素はプログラムで変更できます。 アプリケーションは、ユーザーがアプリを使うときに生成されたデータ セットに基づいて実行時に **PhraseList** の内容を変更する必要があります。 「[音声コマンド定義 (VCD) の語句一覧の動的な変更](dynamically-modify-voice-command-definition--vcd--phrase-lists.md)」をご覧ください。

  -   アプリケーションが起動したときに **Cortana** に表示されて読み上げられるテキストを含む **Feedback** 要素。

**Navigate** 要素は、音声コマンドにアプリをフォアグラウンドでアクティブ化するように指示します。 この例では、```showTripToDestination``` コマンドはフォアグラウンド タスクです。

**VoiceCommandService** 要素は、音声コマンドにアプリをバックグラウンドでアクティブ化するように指示します。 この要素の **Target** 属性の値は、package.appxmanifest ファイルにある [**uap:AppService**](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素の **Name** 属性の値に一致する必要があります。 この例では、```whenIsTripToDestination``` コマンドと ```cancelTripToDestination``` コマンドは、アプリ サービス名を "AdventureWorksVoiceCommandService" として指定するバックグラウンド タスクです。

詳しくは、「[**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)」をご覧ください。

**Adventure Works** アプリ向けの en-us 音声コマンドを定義する [**VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルの一部は次のとおりです。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.2">
  <CommandSet xml:lang="en-us" Name="AdventureWorksCommandSet_en-us">
    <AppName> Adventure Works </AppName>
    <Example> Show trip to London </Example>

    <Command Name="showTripToDestination">
      <Example> Show trip to London </Example>
      <ListenFor RequireAppName="BeforeOrAfterPhrase"> show [my] trip to {destination} </ListenFor>
      <ListenFor RequireAppName="ExplicitlySpecified"> show [my] {builtin:AppName} trip to {destination} </ListenFor>
      <Feedback> Showing trip to {destination} </Feedback>
      <Navigate />
    </Command>

    <Command Name="whenIsTripToDestination">
      <Example> When is my trip to Las Vegas?</Example>
      <ListenFor RequireAppName="BeforeOrAfterPhrase"> when is [my] trip to {destination}</ListenFor>
      <ListenFor RequireAppName="ExplicitlySpecified"> when is [my] {builtin:AppName} trip to {destination} </ListenFor>
      <Feedback> Looking for trip to {destination}</Feedback>
      <VoiceCommandService Target="AdventureWorksVoiceCommandService"/>
    </Command>
    
    <Command Name="cancelTripToDestination">
      <Example> Cancel my trip to Las Vegas </Example>
      <ListenFor RequireAppName="BeforeOrAfterPhrase"> cancel [my] trip to {destination}</ListenFor>
      <ListenFor RequireAppName="ExplicitlySpecified"> cancel [my] {builtin:AppName} trip to {destination} </ListenFor>
      <Feedback> Cancelling trip to {destination}</Feedback>
      <VoiceCommandService Target="AdventureWorksVoiceCommandService"/>
    </Command>

    <PhraseList Label="destination">
      <Item>London</Item>
      <Item>Las Vegas</Item>
      <Item>Melbourne</Item>
      <Item>Yosemite National Park</Item>
    </PhraseList>
  </CommandSet>
```

## <span id="Install_the_VCD_commands"></span><span id="install_the_vcd_commands"></span><span id="INSTALL_THE_VCD_COMMANDS"></span>VCD コマンドのインストール

VCD をインストールするには、アプリを 1 回実行する必要があります。 

>  **注**  
音声コマンド データは、アプリのインストールで保持されません。 アプリの音声コマンド データをそのまま保持する場合は、アプリを起動またはアクティブ化するたびに VCD ファイルを初期化するか、VCD が現在インストールされているかどうかを示す設定を保持することを考慮してください。

"app.xaml.cs" ファイルで、次の操作を実行します。

1. 次の using ディレクティブを追加します。  
```csharp
using Windows.Storage;
```
2. "OnLaunched" メソッドを async 修飾子でマークします。  
```csharp
protected async override void OnLaunched(LaunchActivatedEventArgs e)
```
3. [
            **OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーの [**InstallCommandDefinitionsFromStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn708205) を呼び出し、システムが認識する必要のある音声コマンドを登録します。

  Adventure Works のサンプルで、まず [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを定義します。 

  次に、[**GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) を呼び出し、"AdventureWorksCommands.xml" ファイルを使って初期化します。

  次に、この [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトが [**InstallCommandDefinitionsFromStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn708205) に渡されます。    
```CSharp
try
{
  // Install the main VCD. 
  StorageFile vcdStorageFile = 
    await Package.Current.InstalledLocation.GetFileAsync(
      @"AdventureWorksCommands.xml");

  await Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
    InstallCommandDefinitionsFromStorageFileAsync(vcdStorageFile);

  // Update phrase list.
  ViewModel.ViewModelLocator locator = App.Current.Resources["ViewModelLocator"] as ViewModel.ViewModelLocator;
  if(locator != null)
  {
     await locator.TripViewModel.UpdateDestinationPhraseList();
  }
}
catch (Exception ex)
{
  System.Diagnostics.Debug.WriteLine("Installing Voice Commands Failed: " + ex.ToString());
}
```

## <span id="Handle_activation_and_execute_voice_commands"></span><span id="handle_activation_and_execute_voice_commands"></span><span id="HANDLE_ACTIVATION_AND_EXECUTE_VOICE_COMMANDS"></span>アクティブ化の処理

アプリが少なくとも 1 回起動されて音声コマンド セットがインストールされた後、それ以降の音声コマンドのアクティブ化にアプリがどのように応答するかを指定します。

1.  アプリが音声コマンドによってアクティブになったことを確認します。

    [
            **Application.OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベントをオーバーライドし、[**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727).[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) が [**VoiceCommand**](https://msdn.microsoft.com/library/windows/apps/br224693) かどうかを確認します。

2.  コマンドの名前と内容を判断します。

    [
            **VoiceCommandActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn609755) オブジェクトへの参照を [**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727) から取得し、[**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) オブジェクトの [**Result**](https://msdn.microsoft.com/library/windows/apps/dn609758) プロパティを照会します。

    ユーザーが声に出した内容を判断するには、[**Text**](https://msdn.microsoft.com/library/windows/apps/dn631441) の値か、[**SpeechRecognitionSemanticInterpretation**](https://msdn.microsoft.com/library/windows/apps/dn631443) ディクショナリ内の認識された語句のセマンティクス プロパティを確認します。

3.  アプリで適切なアクションを実行します (希望するページに移動するなど)。

この例では、手順 3 の「VCD ファイルの編集」の VCD について思い出す必要があります。

音声コマンドの音声認識の結果を取得したら、[**RulePath**](https://msdn.microsoft.com/library/windows/apps/dn631438) 配列の最初の値からコマンド名を取得します。 VCD ファイルでは考えられる複数の音声コマンドが定義されたため、その値を VCD 内のコマンド名と比較し、適切なアクションを実行する必要があります。

アプリケーションが実行できる最も一般的なアクションは、音声コマンドのコンテキスト関連するコンテキストを含むページへの移動です。 この例では、**TripPage** ページに移動し、音声コマンドの値、コマンドがどのように入力されたか、および認識された "destination" 語句 (該当する場合) を渡します。 または、ページに移動するときにアプリがナビゲーション パラメーターを [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) に送ることができます。

アプリを起動した音声コマンドが実際に発声されたかどうか、または **commandMode** キーを使って [**SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) ディクショナリからテキストとして入力されたかどうかを確認できます。 このキーの値は、"voice"、"text" のいずれかです。 キーの値が "voice" の場合、音声合成 ([**Windows.Media.SpeechSynthesis**](https://msdn.microsoft.com/library/windows/apps/dn278951)) を使って、発声されたフィードバックをアプリでユーザーに示すことを検討してください。

[
            **SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) を使って、**ListenFor** 要素の **PhraseList** 制約または **PhraseTopic** 制約で発声されたコンテンツを調べます。 ディクショナリのキーは、**PhraseList** 要素または **PhraseTopic** 要素の **Label** 属性値です。 **{destination}** 語句の値にアクセスする方法を次に示します。

``` csharp
/// <summary>
/// Entry point for an application activated by some means other than normal launching. 
/// This includes voice commands, URI, share target from another app, and so on. 
/// 
/// NOTE:
/// A previous version of the VCD file might remain in place 
/// if you modify it and update the app through the store. 
/// Activations might include commands from older versions of your VCD. 
/// Try to handle these commands gracefully.
/// </summary>
/// <param name="args">Details about the activation method.</param>
protected override void OnActivated(IActivatedEventArgs args)
{
    base.OnActivated(args);

    Type navigationToPageType;
    ViewModel.TripVoiceCommand? navigationCommand = null;

    // Voice command activation.
    if (args.Kind == ActivationKind.VoiceCommand)
    {
        // Event args can represent many different activation types. 
        // Cast it so we can get the parameters we care about out.
        var commandArgs = args as VoiceCommandActivatedEventArgs;

        Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

        // Get the name of the voice command and the text spoken. 
        // See VoiceCommands.xml for supported voice commands.
        string voiceCommandName = speechRecognitionResult.RulePath[0];
        string textSpoken = speechRecognitionResult.Text;

        // commandMode indicates whether the command was entered using speech or text.
        // Apps should respect text mode by providing silent (text) feedback.
        string commandMode = this.SemanticInterpretation("commandMode", speechRecognitionResult);
        
        switch (voiceCommandName)
        {
            case "showTripToDestination":
                // Access the value of {destination} in the voice command.
                string destination = this.SemanticInterpretation("destination", speechRecognitionResult);

                // Create a navigation command object to pass to the page. 
                navigationCommand = new ViewModel.TripVoiceCommand(
                    voiceCommandName,
                    commandMode,
                    textSpoken,
                    destination);

                // Set the page to navigate to for this voice command.
                navigationToPageType = typeof(View.TripDetails);
                break;
            default:
                // If we can't determine what page to launch, go to the default entry point.
                navigationToPageType = typeof(View.TripListView);
                break;
        }
    }
    // Protocol activation occurs when a card is clicked within Cortana (using a background task).
    else if (args.Kind == ActivationKind.Protocol)
    {
        // Extract the launch context. In this case, we're just using the destination from the phrase set (passed
        // along in the background task inside Cortana), which makes no attempt to be unique. A unique id or 
        // identifier is ideal for more complex scenarios. We let the destination page check if the 
        // destination trip still exists, and navigate back to the trip list if it doesn't.
        var commandArgs = args as ProtocolActivatedEventArgs;
        Windows.Foundation.WwwFormUrlDecoder decoder = new Windows.Foundation.WwwFormUrlDecoder(commandArgs.Uri.Query);
        var destination = decoder.GetFirstValueByName("LaunchContext");

        navigationCommand = new ViewModel.TripVoiceCommand(
                                "protocolLaunch",
                                "text",
                                "destination",
                                destination);

        navigationToPageType = typeof(View.TripDetails);
    }
    else
    {
        // If we were launched via any other mechanism, fall back to the main page view.
        // Otherwise, we'll hang at a splash screen.
        navigationToPageType = typeof(View.TripListView);
    }

    // Repeat the same basic initialization as OnLaunched() above, taking into account whether
    // or not the app is already active.
    Frame rootFrame = Window.Current.Content as Frame;

    // Do not repeat app initialization when the Window already has content,
    // just ensure that the window is active.
    if (rootFrame == null)
    {
        // Create a frame to act as the navigation context and navigate to the first page.
        rootFrame = new Frame();
        App.NavigationService = new NavigationService(rootFrame);

        rootFrame.NavigationFailed += OnNavigationFailed;

        // Place the frame in the current window.
        Window.Current.Content = rootFrame;
    }

    // Since we're expecting to always show a details page, navigate even if 
    // a content frame is in place (unlike OnLaunched).
    // Navigate to either the main trip list page, or if a valid voice command
    // was provided, to the details page for that trip.
    rootFrame.Navigate(navigationToPageType, navigationCommand);

    // Ensure the current window is active
    Window.Current.Activate();
}

/// <summary>
/// Returns the semantic interpretation of a speech result. 
/// Returns null if there is no interpretation for that key.
/// </summary>
/// <param name="interpretationKey">The interpretation key.</param>
/// <param name="speechRecognitionResult">The speech recognition result to get the semantic interpretation from.</param>
/// <returns></returns>
private string SemanticInterpretation(string interpretationKey, SpeechRecognitionResult speechRecognitionResult)
{
  return speechRecognitionResult.SemanticInterpretation.Properties[interpretationKey].FirstOrDefault();
}
```

## <span id="Handle_the_voice_command_in_the_app_service"></span><span id="handle_the_voice_command_in_the_app_service"></span><span id="HANDLE_THE_VOICE_COMMAND_IN_THE_APP_SERVICE"></span>アプリ サービスでの音声コマンドの処理


アプリ サービスで音声コマンドを処理します。


1.  次の using ディレクティブをこの例の音声コマンド サービス ファイル "AdventureWorksVoiceCommandService.cs" に追加します。
```csharp
using Windows.ApplicationModel.VoiceCommands;
using Windows.ApplicationModel.Resources.Core;
using Windows.ApplicationModel.AppService;
```

2.  音声コマンドを処理するときにアプリ サービスが終了しないように、サービス遅延を取得します。
3.  バックグラウンド タスクが、音声コマンドによってアクティブ化されたアプリ サービスとして実行されていることを確認します。

    1.  [
            **IBackgroundTaskInstance.TriggerDetails**](https://msdn.microsoft.com/library/windows/apps/br224802) を [**Windows.ApplicationModel.AppService.AppServiceTriggerDetails**](https://msdn.microsoft.com/library/windows/apps/dn921727) にキャストします。
    2.  [
            **IBackgroundTaskInstance.TriggerDetails.Name**](https://msdn.microsoft.com/library/windows/apps/br224807) が "Package.appxmanifest" ファイル内のアプリ サービスの名前であることを確認します。

4.  [
            **IBackgroundTaskInstance.TriggerDetails**](https://msdn.microsoft.com/library/windows/apps/br224802) を使って **Cortana** への [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) を作成し、音声コマンドを取得します。
5.  ユーザーによるキャンセルのためにアプリ サービスが閉じたときに通知を受け取ることができるように、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204).[**VoiceCommandCompleted**](https://msdn.microsoft.com/library/windows/apps/dn706584) のイベント ハンドラーを登録します。
6.  予期しないエラーのためにアプリ サービスが閉じたときに通知を受け取ることができるようにするため、[**IBackgroundTaskInstance.Canceled**](https://msdn.microsoft.com/library/windows/apps/br224798) のイベント ハンドラーを登録します。
7.  コマンドの名前と内容を判断します。

    1.  [
            **VoiceCommand**](https://msdn.microsoft.com/library/windows/apps/dn974162).[**CommandName**](https://msdn.microsoft.com/library/windows/apps/dn706589) プロパティを使って、音声コマンドの名前を決定します。
    2.  ユーザーが声に出した内容を判断するには、[**Text**](https://msdn.microsoft.com/library/windows/apps/dn631441) の値か、[**SpeechRecognitionSemanticInterpretation**](https://msdn.microsoft.com/library/windows/apps/dn631443) ディクショナリ内の認識された語句のセマンティクス プロパティを確認します。

7.  アプリ サービスで適切なアクションを実行します。
8.  **Cortana** で音声コマンドに対するフィードバックを表示して読み上げます。

    1.  音声コマンドに対する応答として **Cortana** がユーザーに表示して読み上げる文字列を決定し、[**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) オブジェクトを作成します。 **Cortana** が表示して読み上げるフィードバック文字列を選ぶ方法については、「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」をご覧ください。
    2.  **VoiceCommandServiceConnection** オブジェクトと共に [**ReportProgressAsync**](https://msdn.microsoft.com/library/windows/apps/dn706579) または [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) を呼び出して、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) インスタンスを使って **Cortana** に進行状況または完了を報告します。

    この例では、手順 3 の「VCD ファイルの編集」の VCD について思い出す必要があります。

```csharp
public sealed class VoiceCommandService : IBackgroundTask
    {
      private BackgroundTaskDeferral serviceDeferral;
      VoiceCommandServiceConnection voiceServiceConnection;

      public async void Run(IBackgroundTaskInstance taskInstance)
      {
      //Take a service deferral so the service isn&#39;t terminated.
        this.serviceDeferral = taskInstance.GetDeferral();

        taskInstance.Canceled += OnTaskCanceled;

        var triggerDetails = 
          taskInstance.TriggerDetails as AppServiceTriggerDetails;

        if (triggerDetails != null &amp;&amp; 
          triggerDetails.Name == "AdventureWorksVoiceServiceEndpoint")
        {
          try
          {
 voiceServiceConnection = 
   VoiceCommandServiceConnection.FromAppServiceTriggerDetails(
     triggerDetails);

 voiceServiceConnection.VoiceCommandCompleted += 
   VoiceCommandCompleted;

 VoiceCommand voiceCommand = await
 voiceServiceConnection.GetVoiceCommandAsync();

 switch (voiceCommand.CommandName)
 {
   case "whenIsTripToDestination":
   {
     var destination = 
       voiceCommand.Properties["destination"][0];
     SendCompletionMessageForDestination(destination);
     break;
   }

   // As a last resort, launch the app in the foreground.
   default:
     LaunchAppInForeground();
     break;
 }
          }
          finally
          {
 if (this.serviceDeferral != null)
 {
   // Complete the service deferral.
   this.serviceDeferral.Complete();
 }
          }
        }
      }

      private void VoiceCommandCompleted(
        VoiceCommandServiceConnection sender, 
        VoiceCommandCompletedEventArgs args)
      {
        if (this.serviceDeferral != null)
        {
          // Insert your code here.
          // Complete the service deferral.
          this.serviceDeferral.Complete();
        }
      }

      private async void SendCompletionMessageForDestination(
        string destination)
      {
        // Take action and determine when the next trip to destination
        // Insert code here.
        
        // Replace the hardcoded strings used here with strings 
        // appropriate for your application.

        // First, create the VoiceCommandUserMessage with the strings 
        // that Cortana will show and speak.
        var userMessage = new VoiceCommandUserMessage();
        userMessage.DisplayMessage = "Here’s your trip.";
        userMessage.SpokenMessage = "Your trip to Vegas is on August 3rd.";

        // Optionally, present visual information about the answer.
        // For this example, create a VoiceCommandContentTile with an 
        // icon and a string.
        var destinationsContentTiles = new List<VoiceCommandContentTile>();

        var destinationTile = new VoiceCommandContentTile();
        destinationTile.ContentTileType = 
          VoiceCommandContentTileType.TitleWith68x68IconAndText;
        // The user can tap on the visual content to launch the app. 
        // Pass in a launch argument to enable the app to deep link to a 
        // page relevant to the item displayed on the content tile.
        destinationTile.AppLaunchArgument = 
          string.Format("destination={0}”, “Las Vegas");
        destinationTile.Title = "Las Vegas";
        destinationTile.TextLine1 = "August 3rd 2015";
        destinationsContentTiles.Add(destinationTile);

        // Create the VoiceCommandResponse from the userMessage and list    
        // of content tiles.
        var response = 
          VoiceCommandResponse.CreateResponse(
 userMessage, destinationsContentTiles);

        // Cortana will present a “Go to app_name” link that the user 
        // can tap to launch the app. 
        // Pass in a launch to enable the app to deep link to a page 
        // relevant to the voice command.
        response.AppLaunchArgument = 
          string.Format("destination={0}”, “Las Vegas");
        
        // Ask Cortana to display the user message and content tile and 
        // also speak the user message.
        await voiceServiceConnection.ReportSuccessAsync(response);
      }

      private async void LaunchAppInForeground()
      {
        var userMessage = new VoiceCommandUserMessage();
        userMessage.SpokenMessage = "Launching Adventure Works";

        var response = VoiceCommandResponse.CreateResponse(userMessage);

        // When launching the app in the foreground, pass an app 
        // specific launch parameter to indicate what page to show.
        response.AppLaunchArgument = "showAllTrips=true";

        await voiceServiceConnection.RequestAppLaunchAsync(response);
      }
    }
```

アクティブ化されたら、アプリ サービスは 0.5 秒以内に [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) を呼び出すことができます。 **Cortana** は、VCD ファイルで指定したフィードバックを表示して読み上げるためにアプリによって提供されたデータを使います。 アプリが呼び出しに 0.5 秒以上かかる場合、次に示すように **Cortana** はハンドオフ画面を挿入します。 アプリケーションが **ReportSuccessAsync** を呼び出すまで最大 5 秒間、**Cortana** にハンドオフ画面が表示されます。 アプリ サービスが **ReportSuccessAsync** を呼び出さないか、**Cortana** に情報を提供する [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) メソッドを何も呼び出さない場合、エラー メッセージが表示されてアプリ サービスがキャンセルされます。

![Adventure Works アプリをバックグラウンドで使った場合の基本的なクエリと結果画面 (進行状況も表示される)](images/cortana-backgroundapp-progress-result.png)

## <span id="related_topics"></span>関連記事


**開発者向け**
* [Cortana の操作](cortana-interactions.md)
* [カスタム認識の制約の定義](define-custom-recognition-constraints.md)
* [Cortana でのバックグラウンド アプリの操作](interact-with-a-background-app-in-cortana.md)
* [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)
* [クイック スタート: ファイルまたは画像リソースの使用](https://msdn.microsoft.com/library/windows/apps/xaml/hh965325)
* [修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)

**デザイナー向け**
* [Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
* [UWP アプリ用レスポンシブ デザイン 101](https://msdn.microsoft.com/library/windows/apps/dn958435)
* [タイルとアイコン アセットのガイドライン](https://msdn.microsoft.com/library/windows/apps/mt412102)

**サンプル**
* [Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 







<!--HONumber=Jun16_HO3-->


