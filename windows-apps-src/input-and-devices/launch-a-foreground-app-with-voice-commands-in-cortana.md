---
Description: Cortana 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、Cortana を通じて音声コマンドを使ってフォアグラウンド アプリを起動し、アプリ内で実行するアクションやコマンドを指定することもできます。
title: Cortana の音声コマンドを使ったフォアグラウンド アプリの起動
ms.assetid: 8D3D1F66-7D17-4DD1-B426-DCCBD534EF00
label: Cortana-Launch a foreground app
template: detail.hbs
---

# Cortana の音声コマンドを使ったフォアグラウンド アプリのアクティブ化


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Cortana** 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、アプリの機能によって **Cortana** を拡張することもできます。 音声コマンドを使用して、アプリをフォアグラウンドでアクティブ化し、アプリ内で操作やコマンドを実行できます。 

アプリがフォアグラウンドで音声コマンドを処理するときに、フォーカスを取得すると、Cortana が閉じられます。 必要に応じて、アプリをバックグラウンド タスクとしてアクティブ化し、コマンドを実行できます。 この場合、Cortana はフォーカスを保持し、アプリは、**Cortana** キャンバスと **Cortana** 音声を介して、すべてのフィードバックと結果を返します。

追加のコンテキストやユーザー入力 (特定の連絡先へのメッセージの送信など) が必要な音声コマンドはフォアグラウンド アプリで処理するのが最適ですが、基本的なコマンド (旅行の予定の一覧表示など) はバックグラウンド アプリを介して **Cortana** で処理できます。

音声コマンドを使用してバックグラウンドでアプリをアクティブ化する場合は、「[Cortana の音声コマンドを使ったバックグラウンド アプリのアクティブ化](launch-a-background-app-with-voice-commands-in-cortana.md)」をご覧ください。

> **注**  
> 音声コマンドは、具体的な目的を持って 1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。

> VCD ファイルでは、1 つ以上の音声コマンドが定義されており、各音声コマンドは固有の目的を持っています。

> 音声コマンド定義にはさまざまなものがあり、定義が複雑になる場合があります。 音声コマンド定義では、制限された 1 つの言葉の発声から、より柔軟性の高い自然言語の発声のコレクションまで、あらゆる発声をサポートできます。ただし、これらの発声はすべて、同じ目的を示している必要があります。

フォアグラウンド アプリの機能を示すために、[Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)の **Adventure Works** という旅行の計画および管理アプリを使用します。

**Cortana** を使わないで新しい **Adventure Works** の旅行を作るには、アプリを起動して **[New trip]** (新しい旅行) ページに移動します。 既存の旅行を表示するには、**[Upcoming trips]** (今後の旅行) ページに移動して旅行を選びます。

**Cortana** を通じて音声コマンドを使うと、ユーザーは代わりに「Adventure Works の旅行を追加します」や「Adventure Works で旅行を追加します」と言うだけでアプリを起動し、**[New trip]** (新しい旅行) ページに移動できます。 次に、「Adventure Works、ロンドン旅行を表示してください」と言うと、次のように、アプリが起動し、**[Trip]** (旅行) 詳細ページに移動します。

![フォアグラウンド アプリを起動する Cortana](images/cortana-foreground-with-adventureworks.png)

以下は、音声コマンド機能を追加し、音声またはキーボード入力を使うアプリに Cortana を統合する基本的な手順です。

1.  VCD ファイルを作ります。 これは、アプリをアクティブ化して操作を開始するかコマンドを呼び出すためにユーザーが発声できる音声コマンドをすべて定義する XML ドキュメントです。 「[**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)」をご覧ください。
2.  アプリが起動したら、VCD ファイル内のコマンド セットを登録します。
3.  音声コマンドによるアクティブ化、アプリ内でのナビゲーション、コマンドの実行を処理します。

**前提条件:  **

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」でイベントについて学習します。

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Create_a_new_solution_with_project_in_Visual_Studio"></span><span id="create_a_new_solution_with__project_in_visual_studio"></span><span id="CREATE_A_NEW_SOLUTION_WITH__PROJECT_IN_VISUAL_STUDIO"></span>Visual Studio でプロジェクトを使って新しいソリューションを作成する


1.  Microsoft Visual Studio 2015 を起動します。

    Visual Studio 2015 のスタート画面が表示されます。

2.  **[ファイル]** メニューの **[新規作成]**、**[プロジェクト]** の順にクリックします。

    **[新しいプロジェクト]** ダイアログ ボックスが表示されます。 ダイアログの左側のウィンドウで、表示するテンプレートの種類を選択できます。

3.  左側のウィンドウで、**[インストール済み]、[テンプレート]、[Visual C\#]、[Windows]** の順に展開した後、**[ユニバーサル]** テンプレート グループを選びます。 ユニバーサル Windows プラットフォーム (UWP) アプリで使うことができるプロジェクト テンプレートの一覧がダイアログの中央のウィンドウに表示されます。
4.  中央のウィンドウで、**[空白のアプリ (ユニバーサル Windows)]** プロジェクト テンプレートを選びます。

    **[空白のアプリ]** テンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールは、このチュートリアルの途中でアプリに追加します。

5.  **[名前]** ボックスで、プロジェクト名を入力します。 この例では、"AdventureWorks" を使用します。
6.  **[OK]** をクリックしてプロジェクトを作ります。

    Microsoft Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。

## <span id="Add_image_assets_to_project_and_specify_them_in_the_app_manifest"></span><span id="add_image_assets_to_project_and_specify_them_in_the_app_manifest"></span><span id="ADD_IMAGE_ASSETS_TO_PROJECT_AND_SPECIFY_THEM_IN_THE_APP_MANIFEST"></span>画像アセットをプロジェクトに追加してアプリ マニフェストで指定する
      
UWP アプリでは、特定の設定とデバイス機能 (ハイ コントラスト、有効ピクセル、ロケールなど) に基づいて最適な画像を自動的に選択できます。 必要な作業は、画像を提供し、リソースのバージョンごとに、アプリ プロジェクト内で適切な名前付け規則とフォルダー構造を使用していることを確認することだけです。 推奨されるリソースのバージョンが提供されない場合、ユーザーの基本設定、身体能力、デバイスの種類、場所によって、アクセシビリティ、ローカライズ、画像の品質が影響を受ける可能性があります。

ハイ コントラストとスケール ファクター用の画像リソースについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets)」をご覧ください。

修飾子を使ってリソースに名前を付けます。 リソース修飾子は、リソースの特定のバージョンが使われるコンテキストを識別するフォルダーとファイル名の修飾子です。

標準の命名規則は、`foldername/qualifiername-value[_qualifiername-value]/filename.qualifiername-value[_qualifiername-value].ext` です。 たとえば、`images/en-US/logo.scale-100_contrast-white.png` は、コード内ではルート フォルダーとファイル名を使用して単に `images/logo.png` と参照されます。 「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh965324.aspx)」をご覧ください。

ローカライズされたリソースや複数の解像度のリソースの提供を現在計画していない場合でも、文字列リソース ファイルに既定の言語をマークし (`en-US\resources.resw` など)、画像に既定のスケール ファクターをマークする (`logo.scale-100.png` など) ことをお勧めします。 ただし、100、200、400 の倍率のアセットを提供することをお勧めします。

> *重要

> **Cortana** キャンバスのタイトル領域で使用するアプリ アイコンは、"Package.appxmanifest" ファイルで指定される Square44x44Logo アイコンです。 
    
## <span id="Create_a_VCD_file"></span><span id="create_a_vcd_file"></span><span id="CREATE_A_VCD_FILE"></span>VCD ファイルの作成

1. Visual Studio で、プライマリ プロジェクト名を右クリックし、**[追加]、[新しい項目]** の順にクリックします。 **XML ファイル**を追加します。
2. [
            **VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルの名前 (この例では、"AdventureWorksCommands.xml") を入力し、[追加] をクリックします。 
3. **ソリューション エクスプローラー**で、[**VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルを選びます。
4.  **[プロパティ]** ウィンドウで、**[ビルド アクション]** を **[コンテンツ]** に設定し、**[出力ディレクトリにコピー]** を **[常にコピーする]** に設定します。

## <span id="Edit_the_VCD_file"></span><span id="edit_the_vcd_file"></span><span id="EDIT_THE_VCD_FILE"></span>VCD ファイルの編集


. "http://schemas.microsoft.com/voicecommands/1.2" を指す **xmlns** 属性を持つ **VoiceCommands** 要素を追加します。

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
```csharp
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
}```

## <span id="Handle_activation_and_execute_voice_commands"></span><span id="handle_activation_and_execute_voice_commands"></span><span id="HANDLE_ACTIVATION_AND_EXECUTE_VOICE_COMMANDS"></span>Handle activation and execute voice commands

Specify how your app responds to subsequent voice command activations (after it has been launched at least once and the voice command sets have been installed).

1.  Confirm that your app was activated by a voice command.

    Override the [**Application.OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) event and check whether [**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727).[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) is [**VoiceCommand**](https://msdn.microsoft.com/library/windows/apps/br224693).

2.  Determine the name of the command and what was spoken.

    Get a reference to a [**VoiceCommandActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn609755) object from the [**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727) and query the [**Result**](https://msdn.microsoft.com/library/windows/apps/dn609758) property for a [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) object.

    To determine what the user said, check the value of [**Text**](https://msdn.microsoft.com/library/windows/apps/dn631441) or the semantic properties of the recognized phrase in the [**SpeechRecognitionSemanticInterpretation**](https://msdn.microsoft.com/library/windows/apps/dn631443) dictionary.

3.  Take the appropriate action in your app, such as navigating to the desired page.

For this example, we refer back to the VCD in Step 3: Edit the VCD file.

Once we get the speech-recognition result for the voice command, we get the command name from the first value in the [**RulePath**](https://msdn.microsoft.com/library/windows/apps/dn631438) array. As the VCD file defined more than one possible voice command, we need to compare the value against the command names in the VCD and take the appropriate action.

The most common action an application can take is to navigate to a page with content relevant to the context of the voice command. For this example, we navigate to a **TripPage** page and pass in the value of the voice command, how the command was input, and the recognized "destination" phrase (if applicable). Alternatively, the app could send a navigation parameter to the [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) when navigating to the page.

You can find out whether the voice command that launched your app was actually spoken, or whether it was typed in as text, from the [**SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) dictionary using the **commandMode** key. The value of that key will be either "voice" or "text". If the value of the key is "voice", consider using speech synthesis ([**Windows.Media.SpeechSynthesis**](https://msdn.microsoft.com/library/windows/apps/dn278951)) in your app to provide the user with spoken feedback.

Use the [**SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) to find out the content spoken in the **PhraseList** or **PhraseTopic** constraints of a **ListenFor** element. The dictionary key is the value of the **Label** attribute of the **PhraseList** or **PhraseTopic** element. Here, we show how to access the value of **{destination}** phrase.

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

## <span id="related_topics"></span>関連記事


**開発者向け**
* [Cortana の操作](cortana-interactions.md)
* [カスタム認識の制約の定義](define-custom-recognition-constraints.md)
* [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**デザイナー向け**
* [Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)

**サンプル**
* [Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 






<!--HONumber=Mar16_HO4-->


