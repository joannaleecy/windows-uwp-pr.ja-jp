---
Description: Cortana 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、Cortana を通じて音声コマンドを使ってフォアグラウンド アプリを起動し、アプリ内で実行するアクションやコマンドを指定することもできます。
title: Cortana の音声コマンドを使ったフォアグラウンド アプリの起動
ms.assetid: 8D3D1F66-7D17-4DD1-B426-DCCBD534EF00
label: Cortana-フォアグラウンド アプリの起動
template: detail.hbs
---

# Cortana の音声コマンドを使ったフォアグラウンド アプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Cortana** 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、**Cortana** を通じて音声コマンドを使ってフォアグラウンド アプリを起動し、アプリ内で実行するアクションやコマンドを指定することもできます。

**注**  
音声コマンドは、具体的な目的を持って 1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。

音声コマンド定義にはさまざまなものがあり、定義が複雑になる場合があります。 音声コマンド定義では、制限された 1 つの言葉の発声から、より柔軟性の高い自然言語の発声のコレクションまで、あらゆる発声をサポートできます。ただし、これらの発声はすべて、同じ目的を示している必要があります。

VCD ファイルでは、1 つ以上の音声コマンドが定義されており、各音声コマンドは固有の目的を持っています。

ターゲット アプリは、操作の複雑さに応じて、フォアグラウンドで起動したり (アプリがフォーカスを取得します)、バックグラウンドでアクティブ化されたりします (**Cortana** がフォーカスを維持しますが、アプリからの結果を表示します)。 たとえば、追加のコンテキストやユーザー入力 (特定の連絡先へのメッセージの送信など) が必要な音声コマンドはフォアグラウンド アプリで処理するのが最適ですが、基本的なコマンドはバックグラウンド アプリを介して **Cortana** で処理できます。

 

ここでは、**Adventure Works** という旅行の計画および管理アプリを使ってそれらの機能について説明します。

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

## <span id="Create_a_VCD_file"></span><span id="create_a_vcd_file"></span><span id="CREATE_A_VCD_FILE"></span>VCD ファイルの作成


1.  Microsoft Visual Studio で、プロジェクト名を右クリックし、[追加]、[新しい項目] の順にクリックし、**[XML ファイル]** をクリックします。
2.  VCD ファイルの名前を入力します。 たとえば、"AdventureWorksCommands.xml" などです。 **[追加]** をクリックします。
3.  **ソリューション エクスプローラー**で、VCD ファイルを選びます。
4.  **[プロパティ]** ウィンドウで、**[ビルド アクション]** を **[コンテンツ]** に設定し、**[出力ディレクトリにコピー]** を **[常にコピーする]** に設定します。

## <span id="Edit_the_VCD_file"></span><span id="edit_the_vcd_file"></span><span id="EDIT_THE_VCD_FILE"></span>VCD ファイルの編集


アプリでサポートされる言語ごとに、アプリが処理できる音声コマンドの **CommandSet** を作成します。

VCD ファイルで宣言された各 **Command** は、次の情報を含む必要があります。

-   実行時に音声コマンドを識別するためにアプリケーションが使うコマンド名。
-   ユーザーがコマンドを呼び出す方法を説明する語句を含む **Example** 要素。 ユーザーが「何と言ったらよいですか」、「ヘルプ」と言ったり、**[もっと見る]** をタップしたときに、**Cortana** にこの例が表示されます。

-   アプリが認識してコマンドを開始するための単語または語句を含む **ListenFor** 要素。 各コマンドには、**ListenFor** 要素が少なくとも 1 つ必要です。
-   アプリケーションが起動したときに **Cortana** に表示されて読み上げられるテキストを含む **Feedback** 要素。
-   アプリをフォアグラウンドで起動する音声コマンドであることを示す **Navigate** 要素。 音声コマンドがアプリをバックグラウンドで起動する場合は、代わりに **VoiceCommandService** 要素を指定します。 詳しくは、「[Cortana の音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)」をご覧ください。

詳しくは、「[**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)」をご覧ください。

アプリのアクティブ化とコマンドの実行に使われるコマンドに対して、複数の言語バージョンを指定できます。 複数の **CommandSet** 要素を作成し、それぞれに異なる **xml:lang** 属性を指定することで、アプリをさまざまな市場で使うことができるようにします。 たとえば、米国用のアプリに、英語の **CommandSet** とスペイン語の **CommandSet** を含めることができます。

**注意**  
音声コマンドを使ってアプリをアクティブ化して操作を開始するには、ユーザーがデバイスで選んだ音声の言語に一致する言語を含む **CommandSet** を格納している VCD ファイルをアプリで登録する必要があります。 この言語は、デバイスで [設定]、[システム]、[音声認識]、[音声認識の言語] の順に移動し、画面上でユーザーが設定します。

 

**Adventure Works** アプリの音声コマンドを定義する VCD ファイルは以下のとおりです。

この例では、**CommandPrefix** が "Adventure Works" に設定されており、**Command** (" showTripToDestination" という名前で識別される) は、ユーザーが声に出すことができる内容と Cortana から返されるフィードバックの両方を指定しています。**ListenFor** は、認識可能なテキストを指定しており (認識ターゲットを制約する **PhraseList** 要素を参照)、**Navigate** はアプリをフォアグラウンドで起動することにより音声コマンドが処理されることを指定します。また、**Feedback** は、**Cortana** がアプリを起動したときにユーザーに聞こえる内容を指定します。

**ListenFor** 要素はプログラムで変更できません。 ただし、**ListenFor** 要素に関連付けられた **PhraseList** 要素はプログラムで変更できます。 アプリケーションは、ユーザーがアプリを使うときに生成されたデータ セットに基づいて実行時に **PhraseList** の内容を変更する必要があります。 「[音声コマンド定義 (VCD) の語句一覧を動的に変更する方法](https://msdn.microsoft.com/library/windows/apps/dn747872)」をご覧ください。

```xml
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
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

    <PhraseList Label="destination">
      <Item> London </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>

    <PhraseTopic Label="newDestination" Scenario="Search">
      <Subject>City/State</Subject>
    </PhraseTopic>
  </CommandSet>

<!-- Other CommandSets for other languages -->

</VoiceCommands>
```

## <span id="Install_the_VCD_commands"></span><span id="install_the_vcd_commands"></span><span id="INSTALL_THE_VCD_COMMANDS"></span>VCD コマンドのインストール


VCD のコマンド セットをインストールするには、アプリを 1 回実行する必要があります。

アプリがアクティブ化されたら、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーの [**InstallCommandDefinitionsFromStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn708205) を呼び出し、システムがリッスンするコマンドを登録します。

**注**  デバイスのバックアップが発生し、アプリが自動的に再インストールされる場合、音声コマンド データは保持されません。 アプリの音声コマンド データをそのまま保持するには、アプリを起動またはアクティブ化するたびに VCD ファイルを初期化するか、VCD が現在インストールされているかどうかを示す設定を保存し、アプリを起動またはアクティブ化するたびにその設定をチェックするようにしてください。

 

VCD ファイル (vcd.xml) で指定されたコマンドをインストールする方法の例を次に示します。

```CSharp
var storageFile = 
  await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
    new Uri("ms-appx:///AdventureWorksCommands.xml"));
await 
  Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
    InstallCommandDefinitionsFromStorageFileAsync(storageFile);
```

## <span id="Handle_activation_and_execute_voice_commands"></span><span id="handle_activation_and_execute_voice_commands"></span><span id="HANDLE_ACTIVATION_AND_EXECUTE_VOICE_COMMANDS"></span>アクティブ化の処理と音声コマンドの実行


アプリが起動され、音声コマンド セットがインストールされたら、その後の音声コマンドのアクティブ化にアプリがどのように応答するかを指定します。 たとえば、コンテンツの特定のページに移動することも、マップなどのナビゲーション ユーティリティを表示することも、確認メッセージや状態を読み上げることもあります。

以下を実行する必要があります。

1.  アプリが音声コマンドによってアクティブになったことを確認します。

    [
            **Application.OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベントをオーバーライドし、[**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727).[**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) が [**VoiceCommand**](https://msdn.microsoft.com/library/windows/apps/br224693) かどうかを確認します。

2.  コマンドの名前と内容を判断します。

    [
            **VoiceCommandActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn609755) オブジェクトへの参照を [**IActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224727) から取得し、[**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) オブジェクトの [**Result**](https://msdn.microsoft.com/library/windows/apps/dn609758) プロパティを照会します。

    ユーザーが声に出した内容を判断するには、[**Text**](https://msdn.microsoft.com/library/windows/apps/dn631441) の値か、[**SpeechRecognitionSemanticInterpretation**](https://msdn.microsoft.com/library/windows/apps/dn631443) ディクショナリ内の認識された語句のセマンティクス プロパティを確認します。

3.  アプリで適切なアクションを実行します (通常は関連するページに移動)。

この例では、手順 3 の「VCD ファイルの編集」の VCD について思い出す必要があります。

音声コマンドの音声認識の結果を取得したら、[**RulePath**](https://msdn.microsoft.com/library/windows/apps/dn631438) 配列の最初の値からコマンド名を取得します。 VCD ファイルでは考えられる複数の音声コマンドが定義されたため、その値を VCD 内のコマンド名と比較し、適切なアクションを実行する必要があります。

アプリケーションが実行できる最も一般的なアクションは、音声コマンドのコンテキスト関連するコンテキストを含むページへの移動です。 この例では、**TripPage** ページに移動し、音声コマンドの値、コマンドがどのように入力されたか、および認識された "destination" 語句 (該当する場合) を渡します。 または、ページに移動するときにアプリがナビゲーション パラメーターを [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) に送ることができます。

アプリを起動した音声コマンドが実際に発声されたかどうか、または **commandMode** キーを使って [**SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) ディクショナリからテキストとして入力されたかどうかを確認できます。 このキーの値は、"voice"、"text" のいずれかです。 キーの値が "voice" の場合、音声合成 ([**Windows.Media.SpeechSynthesis**](https://msdn.microsoft.com/library/windows/apps/dn278951)) を使って、発声されたフィードバックをユーザーに示すことを検討してください。

[
            **SpeechRecognitionSemanticInterpretation.Properties**](https://msdn.microsoft.com/library/windows/apps/dn631445) を使って、**ListenFor** 要素の **PhraseList** 制約または **PhraseTopic** 制約で発声されたコンテンツを調べます。 ディクショナリのキーは、**PhraseList** 要素または **PhraseTopic** 要素の **Label** 属性値です。 **{destination}** 語句の値にアクセスする方法を次に示します。

```CSS
protected override void OnActivated(IActivatedEventArgs e)
{
  // Was the app activated by a voice command?
  if (e.Kind != Windows.ApplicationModel.Activation.ActivationKind.VoiceCommand)
  {
    return;
  }

  var commandArgs = e as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;

  Windows.ApplicationModel.VoiceCommands.VoiceCommand.SpeechRecognitionResult speechRecognitionResult = 
    commandArgs.Result;

  // Get the name of the voice command and the text spoken.
  string voiceCommandName = speechRecognitionResult.RulePath[0];
  string textSpoken = speechRecognitionResult.Text;
  // The commandMode is either "voice" or "text", and it indicates how the voice command was entered by the user.
  // Apps should respect "text" mode by providing feedback in a silent form.
  string commandMode = this.SemanticInterpretation("commandMode", speechRecognitionResult);

  switch (voiceCommandName)
  {
    case "showTripToDestination":
    // Access the value of the {destination} phrase in the voice command.
    string destination = speechRecognitionResult.SemanticInterpretation.Properties["destination"][0];
    // Create a navigation parameter string to pass to the page.
    navigationParameterString = string.Format("{0}|{1}|{2}|{3}", 
                    voiceCommandName, commandMode, textSpoken, destination);
    // Set the page where to navigate for this voice command.
    navigateToPageType = typeof(TripPage);
    break;

    default:
      // There is no match for the voice command name. Navigate to MainPage.
      navigateToPageType = typeof(MainPage);
      break;
  }
  if (this.rootFrame == null)
  {
    // App needs to create a new Frame, not shown
  }

  if (!this.rootFrame.Navigate(navigateToPageType, navigationParameterString))
    {
    throw new Exception("Failed to create voice command page");
    }
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
 

 






<!--HONumber=Mar16_HO1-->


