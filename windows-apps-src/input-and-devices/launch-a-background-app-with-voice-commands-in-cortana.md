---
Description: Cortana 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、アプリ内で実行するアクションやコマンドを指定する音声コマンドを使うバックグラウンド アプリの機能によって Cortana を拡張することもできます。
title: Cortana の音声コマンドを使ったバックグラウンド アプリの起動
ms.assetid: DF5B530C-57DD-4CA5-B3BE-1A0B3695C9C6
label: バックグラウンド アプリの起動
template: detail.hbs
---

# Cortana の音声コマンドを使ったバックグラウンド アプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Cortana** 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、アプリ内で実行するアクションやコマンドを指定する音声コマンドを使うバックグラウンド アプリの機能によって **Cortana** を拡張することもできます。 アプリがバックグラウンドで音声コマンドを処理する際、**Cortana** キャンバスにフィードバックが表示され、**Cortana** 音声の使用方法についてユーザーに通知されることがあります。

**注**  
音声コマンドは、具体的な目的を持って 1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。

音声コマンド定義にはさまざまなものがあり、定義が複雑になる場合があります。 音声コマンド定義では、制限された 1 つの言葉の発声から、より柔軟性の高い自然言語の発声のコレクションまで、あらゆる発声をサポートできます。ただし、これらの発声はすべて、同じ目的を示している必要があります。

VCD ファイルでは、1 つ以上の音声コマンドが定義されており、各音声コマンドは固有の目的を持っています。

ターゲット アプリは、操作の複雑さに応じて、フォアグラウンドで起動したり (アプリがフォーカスを取得します)、バックグラウンドでアクティブ化されたりします (**Cortana** がフォーカスを維持しますが、アプリからの結果を表示します)。 たとえば、追加のコンテキストやユーザー入力 (特定の連絡先へのメッセージの送信など) が必要な音声コマンドはフォアグラウンド アプリで処理するのが最適ですが、基本的なコマンドはバックグラウンド アプリを介して **Cortana** で処理できます。

 

ここでは、[Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)の **Adventure Works** という旅行の計画および管理アプリを使ってそれらの機能について説明します。

**Cortana** のキャンバスに統合された **Adventure Works** アプリの概要は次のとおりです。

![Cortana のキャンバスの概要 ](images/cortana-overview.png)

**Cortana** を使わないで **Adventure Works** の旅行を表示するには、アプリを起動して **[Upcoming trips]** (今後の旅行) ページに移動します。

**Cortana** の音声コマンドを使ってアプリをバックグラウンドで起動する場合、代わりに「Adventure Works に登録されている次のラスベガス旅行はいつですか」と言うことができます。 アプリによりコマンドが処理され、**Cortana** にアプリ アイコンや他のアプリ情報 (ある場合) と共に結果が表示されます。 基本的な旅行クエリと **Cortana** の結果画面の例を次に示します。どちらにも、「次のラスベガス旅行は 8 月 1 日です」という意味の内容が示されます。

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
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」でイベントについて学習します。

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Create_a_new_solution_with_a_primary_project_in_Visual_Studio"></span><span id="create_a_new_solution_with_a_primary_project_in_visual_studio"></span><span id="CREATE_A_NEW_SOLUTION_WITH_A_PRIMARY_PROJECT_IN_VISUAL_STUDIO"></span>Visual Studio でのプライマリ プロジェクトを使った新しいソリューションの作成


1.  Microsoft Visual Studio 2015 を起動します。

    Visual Studio 2015 のスタート画面が表示されます。

2.  **[ファイル]** メニューの **[新規作成]**、**[プロジェクト]** の順にクリックします。

    **[新しいプロジェクト]** ダイアログ ボックスが表示されます。 ダイアログの左側のウィンドウで、表示するテンプレートの種類を選択できます。

3.  左側のウィンドウで、**[インストール済み]、[テンプレート]、[Visual C#]、[Windows]** の順に展開した後、**[ユニバーサル]** テンプレート グループを選びます。 ユニバーサル Windows プラットフォーム (UWP) アプリで使うことができるプロジェクト テンプレートの一覧がダイアログの中央のウィンドウに表示されます。
4.  中央のウィンドウで、**[空白のアプリ (ユニバーサル Windows)]** プロジェクト テンプレートを選びます。

    **[空白のアプリ]** テンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールは、このチュートリアルの途中でアプリに追加します。

5.  **[名前]** ボックスで、プロジェクト名を入力します。
6.  **[OK]** をクリックしてプロジェクトを作ります。

    Microsoft Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。

## <span id="Create_an_app_service_project"></span><span id="create_an_app_service_project"></span><span id="CREATE_AN_APP_SERVICE_PROJECT"></span>アプリ サービス プロジェクトの作成


1.  ソリューション名を右クリックし、[追加]、[新しいプロジェクト] の順にクリックし、**[Windows ランタイム コンポーネント]** をクリックします。 これは、アプリ サービスが実装されるコンポーネントです (「[**Windows.ApplicationModel.AppService**](https://msdn.microsoft.com/library/windows/apps/dn921731)」をご覧ください)。
2.  プロジェクトの名前 (たとえば、"VoiceCommandService") を入力し、**[OK]** をクリックします。
3.  **ソリューション エクスプローラー**で、"VoiceCommandService" プロジェクトを選び、Visual Studio によって生成された "Class1.cs" ファイルの名前を変更します。 たとえば、"YourAppVoiceCommandService.cs" などです。
4.  "YourAppVoiceCommandService.cs" ファイルで、ディレクティブを使って次の内容を追加します。
```    CSharp
using Windows.ApplicationModel.Background;</code></pre></td>
    </tr>
    </tbody>
    </table>
```

5.  [
            **IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを作成します。 このクラスの [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドは、**Cortana** が音声コマンドを認識するときに呼び出される必須のエントリ ポイントです。

    **注**  バックグラウンド タスク クラス自体と、バックグラウンド タスク プロジェクト内のその他すべてのクラスは、sealed public クラスである必要があります。

     

    Here's a basic background task class for the **Adventure Works** app.

    Note that we've renamed the default namespace assigned by Visual Studio.

    <span codelanguage="CSharp"></span>
```    CSharp
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">C#</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
using Windows.ApplicationModel.Background;

    namespace AdventureWorks.VoiceCommands
    {
      public sealed class AdventureWorksVoiceCommandService : IBackgroundTask
      {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
          BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
        
          //
          // TODO: Insert code 
          //
          //
        
          _deferral.Complete();
        }        
      }
    }
```

6.  アプリ マニフェストでバックグラウンド タスクを **AppService** として宣言します。

    1.  **ソリューション エクスプローラー**で、"Package.appxmanifest" ファイルを右クリックして **[コードの表示]** を選択します。
    2.  [****Application****](https://msdn.microsoft.com/library/windows/apps/dn934738) 要素を検索します。
    3.  [****Extensions****](https://msdn.microsoft.com/library/windows/apps/dn934720) 要素を [****Application****](https://msdn.microsoft.com/library/windows/apps/dn934738) 要素に追加します。
    4.  [****uap:Extension****](https://msdn.microsoft.com/library/windows/apps/dn986788) 要素を [****Extensions****](https://msdn.microsoft.com/library/windows/apps/dn934720) 要素に追加します。
    5.  **Category** 属性を **uap:Extension** 要素に追加し、**Category** 属性の値を "windows.appService" に設定します。
    6.  **EntryPoint** 属性を **uap:Extension** 要素に追加し、**EntryPoint** 属性の値を、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) を実装するクラスの名前 (この場合は "AdventureWorks.VoiceCommands.AdventureWorksVoiceCommandService") に設定します。
    7.  [****uap:AppService****](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素を **uap:Extension** 要素に追加します。
    8.  **Name** 属性を [****uap:AppService****](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素に追加し、**Name** 属性の値を、アプリ サービスの名前 (この場合は "AdventureWorksVoiceCommandService") に設定します。
```        XML
<Package>
          <Applications>
            <Application>

              <Extensions>
                <uap:Extension Category="windows.appService" 
                  EntryPoint="AdventureWorks.VoiceCommands.AdventureWorksVoiceCommandService">
                  <uap:AppService Name="AdventureWorksVoiceCommandService"/>
                </uap:Extension>
                <uap:Extension Category="windows.personalAssistantLaunch"/>
              </Extensions>

            <Application>
          <Applications>
        </Package>
```

## <span id="Create_a_VCD_file"></span><span id="create_a_vcd_file"></span><span id="CREATE_A_VCD_FILE"></span>VCD ファイルの作成


1.  Visual Studio で、プライマリ プロジェクト名を右クリックし、[追加]、[新しい項目] の順にクリックし、**[テキスト ファイル]** をクリックします。
2.  [
            **VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルの名前を入力します。ファイル拡張子は ".xml" とします。 たとえば、"AdventureWorksCommands.xml" などです。 **[追加]** をクリックします。
3.  **ソリューション エクスプローラー**で、[**VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルを選びます。
4.  **[プロパティ]** ウィンドウで、**[ビルド アクション]** を **[コンテンツ]** に設定し、**[出力ディレクトリにコピー]** を **[常にコピーする]** に設定します。

## <span id="Edit_the_VCD_file"></span><span id="edit_the_vcd_file"></span><span id="EDIT_THE_VCD_FILE"></span>VCD ファイルの編集


アプリでサポートされる言語ごとに、アプリが処理できる音声コマンドの **CommandSet** を作成します。

[
            **VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルで宣言された各 **Command** は、次の情報を含む必要があります。

-   実行時に音声コマンドを識別するためにアプリケーションが使うコマンド名
-   ユーザーがコマンドを呼び出す方法を説明する語句を含む **Example** 要素。 ユーザーが「何と言ったらよいですか」、「ヘルプ」と言ったり、**[もっと見る]** をタップしたときに、**Cortana** にこの例が表示されます。

    以下をご覧ください。

-   アプリが認識してコマンドを開始するための単語または語句を含む **ListenFor** 要素。 各コマンドには、**ListenFor** 要素が少なくとも 1 つ必要です。
-   アプリケーションが起動したときに **Cortana** に表示されて読み上げられるテキストを含む **Feedback** 要素。
-   音声コマンドにアプリをバックグラウンドで起動するように指示する **VoiceCommandService** 要素。

詳しくは、「[**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)」をご覧ください。

アプリのアクティブ化とコマンドの実行に使われるコマンドに対して、複数の言語バージョンを指定できます。 複数の [****CommandSet****](https://msdn.microsoft.com/library/windows/apps/dn722331) 要素を作成し、それぞれに異なる [****xml:lang****](https://msdn.microsoft.com/library/windows/apps/dn722331) 属性を指定することで、アプリをさまざまな市場で使うことができるようにします。 たとえば、米国用のアプリに、英語の [****CommandSet****](https://msdn.microsoft.com/library/windows/apps/dn722331) とスペイン語の [****CommandSet****](https://msdn.microsoft.com/library/windows/apps/dn722331) を含めることができます。

**注意**  
音声コマンドを使ってアプリをアクティブ化して操作を開始するには、ユーザーがデバイスで選んだ音声の言語に一致する言語を含む [****CommandSet****](https://msdn.microsoft.com/library/windows/apps/dn722331) を格納している VCD ファイルをアプリで登録する必要があります。 この言語は、デバイスで [設定]、[システム]、[音声認識]、[音声認識の言語] の順に移動し、画面上でユーザーが設定します。

 

**Adventure Works** アプリの音声コマンドを定義する [**VCD**](https://msdn.microsoft.com/library/windows/apps/dn706593) ファイルは以下のとおりです。

この例では、**CommandPrefix** が "Adventure Works" に設定されており、**Command** は "whenIsTripToDestination" に設定されています。**ListenFor** は、認識可能なテキストを指定しており (認識ターゲットを制約する **PhraseList** 要素を参照)、**VoiceCommandService** は音声コマンドがアプリ サービスによりバックグラウンドで処理されることを指定します。また、**Feedback** は、**Cortana** がアプリ サービスを起動したときにユーザーに聞こえる内容を指定します。

**VoiceCommandService** 要素の **Target** 属性の値は、package.appxmanifest の [****uap:AppService****](https://msdn.microsoft.com/library/windows/apps/dn934779) 要素で指定されたアプリ サービスの名前である必要があります。 この例では、アプリ サービスの名前は "AdventureWorksVoiceCommandService" です。

"whenIsTripToDestination" コマンドには、制約されたターゲット セットの **PhraseList** を参照する **ListenFor** 要素が含まれています。

**ListenFor** 要素はプログラムで変更できません。 ただし、**ListenFor** 要素に関連付けられた **PhraseList** 要素はプログラムで変更できます。 アプリケーションは、ユーザーがアプリを使うときに生成されたデータ セットに基づいて実行時に **PhraseList** の内容を変更する必要があります。 「[音声コマンド定義 (VCD) の語句一覧の動的な変更](dynamically-modify-voice-command-definition--vcd--phrase-lists.md)」をご覧ください。

```XML
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
</VoiceCommands>
```

## <span id="Install_the_VCD_commands"></span><span id="install_the_vcd_commands"></span><span id="INSTALL_THE_VCD_COMMANDS"></span>VCD コマンドのインストール


VCD のコマンド セットをインストールするには、アプリを 1 回実行する必要があります。

アプリがアクティブ化されたら、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーの [**InstallCommandDefinitionsFromStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn708205) を呼び出し、システムがリッスンするコマンドを登録します。

**注**  デバイスのバックアップが発生し、アプリが自動的に再インストールされる場合、音声コマンド データは保持されません。 アプリの音声コマンド データをそのまま保持するには、アプリを起動またはアクティブ化するたびに VCD ファイルを初期化するか、VCD が現在インストールされているかどうかを示す設定を保存し、アプリを起動またはアクティブ化するたびにその設定をチェックするようにしてください。

 

この例では、まず [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを定義します。

次に、[**GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) を呼び出し、"AdventureWorksCommands.xml" ファイルを使って初期化します。

次に、この [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトが [**InstallCommandDefinitionsFromStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn708205) に渡されます。

```CSharp
try
{
    // Install the VCD. 
    StorageFile vcdStorageFile = 
        await Package.Current.InstalledLocation.GetFileAsync(
        @"AdventureWorksCommands.xml");

    await 
        Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
        InstallCommandDefinitionsFromStorageFileAsync(vcdStorageFile);
}
catch (Exception ex)
{
    System.Diagnostics.Debug.WriteLine(
      "Installing Voice Commands Failed: " + ex.ToString());
}
```

## <span id="Handle_the_voice_command_in_the_app_service"></span><span id="handle_the_voice_command_in_the_app_service"></span><span id="HANDLE_THE_VOICE_COMMAND_IN_THE_APP_SERVICE"></span>アプリ サービスでの音声コマンドの処理


アプリが起動されて音声コマンド セットがインストールされた後、音声コマンドのアクティブ化にアプリがどのように応答するかをアプリ サービスで指定します。

1.  音声コマンドを処理するときにアプリ サービスが終了しないように、サービス遅延を取得します。
2.  バックグラウンド タスクが、音声コマンドによってアクティブ化されたアプリ サービスとして実行されていることを確認します。

    1.  [
            **IBackgroundTaskInstance.TriggerDetails**](https://msdn.microsoft.com/library/windows/apps/br224802) を [**Windows.ApplicationModel.AppService.AppServiceTriggerDetails**](https://msdn.microsoft.com/library/windows/apps/dn921727) にキャストします。
    2.  [
            **IBackgroundTaskInstance.TriggerDetails.Name**](https://msdn.microsoft.com/library/windows/apps/br224807) が "Package.appxmanifest" ファイル内のアプリ サービスの名前であることを確認します。

3.  [
            **IBackgroundTaskInstance.TriggerDetails**](https://msdn.microsoft.com/library/windows/apps/br224802) を使って **Cortana** への [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) を作成し、音声コマンドを取得します。
4.  ユーザーによるキャンセルのためにアプリ サービスが閉じたときに通知を受け取ることができるように、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204).[**VoiceCommandCompleted**](https://msdn.microsoft.com/library/windows/apps/dn706584) のイベント ハンドラーを登録します。
5.  予期しないエラーのためにアプリ サービスが閉じたときに通知を受け取ることができるようにするため、[**IBackgroundTaskInstance.Canceled**](https://msdn.microsoft.com/library/windows/apps/br224798) のイベント ハンドラーを登録します。
6.  コマンドの名前と内容を判断します。

    1.  [
            **VoiceCommand**](https://msdn.microsoft.com/library/windows/apps/dn974162).[**CommandName**](https://msdn.microsoft.com/library/windows/apps/dn706589) プロパティを使って、音声コマンドの名前を決定します。
    2.  ユーザーが声に出した内容を判断するには、[**Text**](https://msdn.microsoft.com/library/windows/apps/dn631441) の値か、[**SpeechRecognitionSemanticInterpretation**](https://msdn.microsoft.com/library/windows/apps/dn631443) ディクショナリ内の認識された語句のセマンティクス プロパティを確認します。

7.  アプリ サービスで適切なアクションを実行します。
8.  **Cortana** で音声コマンドに対するフィードバックを表示して読み上げます。

    1.  音声コマンドに対する応答として **Cortana** がユーザーに表示して読み上げる文字列を決定し、[**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) オブジェクトを作成します。 **Cortana** が表示して読み上げるフィードバック文字列を選ぶ方法については、「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」をご覧ください。
    2.  **VoiceCommandServiceConnection** オブジェクトと共に [**ReportProgressAsync**](https://msdn.microsoft.com/library/windows/apps/dn706579) または [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) を呼び出して、[**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) インスタンスを使って **Cortana** に進行状況または完了を報告します。

    この例では、手順 3 の「VCD ファイルの編集」の VCD について思い出す必要があります。

```    CSharp
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

起動時、アプリ サービスは 0.5 秒以内に [**ReportSuccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706580) を呼び出すことができます。 **Cortana** は、VCD ファイルで指定したフィードバックを表示して読み上げるためにアプリによって提供されたデータを使います。 アプリが呼び出しに 0.5 秒以上かかる場合、次に示すように **Cortana** はハンドオフ画面を挿入します。 アプリケーションが **ReportSuccessAsync** を呼び出すまで最大 5 秒間、**Cortana** にハンドオフ画面が表示されます。 アプリ サービスが **ReportSuccessAsync** を呼び出さないか、**Cortana** に情報を提供する [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) メソッドを何も呼び出さない場合、エラー メッセージが表示されてアプリ サービスがキャンセルされます。

![Adventure Works アプリをバックグラウンドで使った場合の基本的なクエリと結果画面 (進行状況も表示される)](images/cortana-backgroundapp-progress-result.png)

## <span id="Image_resources_and_scaling"></span><span id="image_resources_and_scaling"></span><span id="IMAGE_RESOURCES_AND_SCALING"></span>画像リソースとスケーリング


UWP アプリでは、特定の設定とデバイス機能 (ハイ コントラスト、有効ピクセル、ロケールなど) に基づいて最適な画像を自動的に選択できます。 必要な作業は、画像を提供し、リソースのバージョンごとに、アプリ プロジェクト内で適切な名前付け規則とフォルダー構造を使用していることを確認することだけです。 推奨されるリソースのバージョンが提供されない場合、ユーザーの基本設定、身体能力、デバイスの種類、場所によって、アクセシビリティ、ローカライズ、画像の品質が影響を受ける可能性があります。

ハイ コントラストとスケール ファクター用の画像リソースについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://msdn.microsoft.com/library/windows/apps/mt412102)」をご覧ください。

修飾子を使ってリソースに名前を付けます。 リソース修飾子は、リソースの特定のバージョンが使われるコンテキストを識別するフォルダーとファイル名の修飾子です。

標準的な命名規則は、"foldername/qualifiername-value\[\_qualifiername-value\]/filename.qualifiername-value\[\_qualifiername-value\].ext" です。 たとえば、images/en-US/logo.scale-100\_contrast-white.png は、コード内ではルート フォルダーとファイル名を使用して単に images/logo.png と参照されます。 詳しくは、「[ファイル、データ、グローバリゼーションのガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611859)」と「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)」をご覧ください。

ローカライズされたリソースや複数の解像度のリソースの提供を現在計画していない場合でも、文字列リソース ファイルに既定の言語をマークし ("en-US\\resources.resw" など)、画像に既定のスケール ファクターをマークする ("logo.scale-100.png" など) ことをお勧めします。 ただし、100、200、400 のスケール ファクターのアセットを提供する必要があります。

**重要**  
**Cortana** コンテンツ タイルの有効なアイコンのサイズは次のとおりです。

-   幅 68 x 高さ 68
-   幅 68 x 高さ 92
-   幅 280 x 高さ 140

コンテンツ タイルは、[**VoiceCommandResponse**](https://msdn.microsoft.com/library/windows/apps/dn974182) が [**VoiceCommandServiceConnection**](https://msdn.microsoft.com/library/windows/apps/dn974204) に渡されるまで検証されません。 画像がこれらのサイズ比率に準拠していないコンテンツ タイルを含む **VoiceCommandResponse** オブジェクトを **Cortana** に渡した場合、例外が発生する可能性があります。

 

この **Adventure Works** アプリ (VoiceCommandService\\AdventureWorksVoiceCommandService.cs) の例では、[**TitleWith68x68IconAndText**](https://msdn.microsoft.com/library/windows/apps/dn974169) タイル テンプレートを使用して、単純な灰色の四角形 ("GreyTile.png") を [**VoiceCommandContentTile**](https://msdn.microsoft.com/library/windows/apps/dn974168) 上のアプリのロゴとして指定します。 ロゴのバリアントは VoiceCommandService\\Images にあり、[**GetFileFromApplicationUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701741) メソッドを使って取得できます。

```CSharp
var destinationTile = new VoiceCommandContentTile();

destinationTile.ContentTileType = 
  VoiceCommandContentTileType.TitleWith68x68IconAndText;
destinationTile.Image = 
  await StorageFile.GetFileFromApplicationUriAsync(
    new Uri("ms-appx:///AdventureWorks.VoiceCommands/Images/GreyTile.png"));
```

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
 

 






<!--HONumber=Mar16_HO1-->


