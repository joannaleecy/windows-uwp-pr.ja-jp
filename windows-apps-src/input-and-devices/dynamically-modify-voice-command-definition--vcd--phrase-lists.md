---
Description: 実行時に音声認識結果を使って、音声コマンド定義 (VCD) ファイルのサポート対象語句の一覧 (PhraseList 要素) にアクセスして更新する方法を説明します。
title: 音声コマンド定義 (VCD) の語句一覧の動的変更
ms.assetid: 98024EAC-EC0E-44AA-AEC5-A611BA7C5884
label: 音声コマンド定義 (VCD) の語句一覧の動的変更
template: detail.hbs
---

# 音声コマンド定義 (VCD) の語句一覧の動的変更


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

実行時に音声認識結果を使って、音声コマンド定義 (VCD) ファイルのサポート対象語句の一覧 (**PhraseList** 要素) にアクセスして更新する方法を説明します。

実行時に動的に語句一覧を変更できると、ある種のユーザー定義のお気に入りデータや一時的なアプリ データが関係する作業専用の音声コマンドを使う場合に便利です。

たとえば、ユーザーが目的地を入力できる旅行アプリがあり、ユーザーがアプリ名の後に「&lt;目的地&gt; 旅行を表示」と発声するだけでアプリを起動できるようにするとします。 想定されるすべての目的地について個別の **ListenFor** 要素を作成する必要はありません。 代わりに、ユーザーが作った目的地を実行時に動的に **PhraseList** に設定できます。 **ListenFor** 要素自体では、`<ListenFor> Show trip to {destination}  </ListenFor>` のように指定できます。ここで、"destination" は、**PhraseList** の **Label** 属性の値です。

**PhraseList** などの VCD 要素について詳しくは、[**VCD elements and attributes v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593) リファレンスをご覧ください。

**前提条件: **

このトピックは、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](launch-a-foreground-app-with-voice-commands-in-cortana.md)」に基づいています。 ここでは、引き続き **Adventure Works** という旅行の計画および管理アプリを使って機能について説明します。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン: **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、便利で魅力的な音声認識対応アプリの設計に役立つヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Identify_the_command"></span><span id="identify_the_command"></span><span id="IDENTIFY_THE_COMMAND"></span>コマンドの特定


VCD ファイルの **PhraseList** 要素を更新するには、語句一覧を含む **CommandSet** 要素を取得します。 **CommandSet** 要素の **Name** 属性 (**Name** は VCD ファイル内で重複しないようにします) をキーとして [**VoiceCommandManager.InstalledCommandSets**](https://msdn.microsoft.com/library/windows/apps/dn653257) プロパティにアクセスし、[**VoiceCommandSet**](https://msdn.microsoft.com/library/windows/apps/dn653258) の参照を取得します。

## <span id="Replace_the_phrase_list"></span><span id="replace_the_phrase_list"></span><span id="REPLACE_THE_PHRASE_LIST"></span>語句一覧の置換


コマンド セットを特定したら、変更する語句一覧の参照を取得し、**PhraseList** 要素の **Label** 属性と文字列の配列を、語句一覧の新しい内容として [**SetPhraseListAsync**](https://msdn.microsoft.com/library/windows/apps/dn653261) メソッドを呼び出します。

**注**  語句一覧は、変更すると語句一覧全体が置き換えられます。 語句一覧に新しい項目を追加する場合は、既にある項目と新しい項目の両方を指定して [**SetPhraseListAsync**](https://msdn.microsoft.com/library/windows/apps/dn653261) を呼び出す必要があります。

 

ここでは、VCD ファイルは **Command**"showTripToDestination" と、**Adventure Works** 旅行アプリで目的地を選ぶための 3 つのオプションを定義する **PhraseList** を定義します。 ユーザーがアプリで目的地を保存および削除すると、アプリは **PhraseList** のオプションを更新します。

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="AdventureWorksCommandSet_en-us">
    <CommandPrefix> Adventure Works, </CommandPrefix>
    <Example> Show trip to London </Example>

    <Command Name="showTripToDestination">
      <Example> show trip to London  </Example>
      <ListenFor> show trip to {destination} </ListenFor>
      <Feedback> Showing trip to {destination} </Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label="destination">
      <Item> London </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>

  </CommandSet>

<!-- Other CommandSets for other languages -->

</VoiceCommands>
```

次に、この例の **PhraseList** を更新して、目的地「フェニックス」を追加する方法を示します。

```CSharp
Windows.ApplicationModel.VoiceCommands.VoiceCommnadDefinition.VoiceCommandSet commandSetEnUs;

if (Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
      InstalledCommandSets.TryGetValue(
        "AdventureWorksCommandSet_en-us", out commandSetEnUs))
{
  await commandSetEnUs.SetPhraseListAsync(
    "destination", new string[] {“London”, “Dallas”, “New York”, “Phoenix”});
}
```

## <span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈


**PhraseList** を使った認識の制約は、比較的少ないセットや単語に適しています。 単語セットが大きすぎ (数百語など) たり、まったく制約しない場合は、**PhraseTopic** 要素と **Subject** 要素を使って音声認識結果の関連性を絞り込み、スケーラビリティを高めます。

この例では、**Scenario** が "Search" の **PhraseTopic** があり、"City\\State" という **Subject** によってさらに絞り込まれています。

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="AdventureWorksCommandSet_en-us">
    <CommandPrefix> Adventure Works, </CommandPrefix>
    <Example> Show trip to London </Example>

    <Command Name="showTripToDestination">
      <Example> show trip to London  </Example>
      <ListenFor> show trip to {destination} </ListenFor>
      <Feedback> Showing trip to {destination} </Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label="destination">
      <Item> London </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>

    <PhraseTopic Label="destination" Scenario="Search">
      <Subject>City/State</Subject>
    </PhraseTopic>

  </CommandSet>
```

## <span id="related_topics"></span>関連記事


**開発者向け**
* [Cortana の操作](cortana-interactions.md)
* [Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](launch-a-foreground-app-with-voice-commands-in-cortana.md)
* [Cortana の音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)
* [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)
**デザイナー向け**
* [Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
**サンプル**
* [Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 






<!--HONumber=Mar16_HO1-->


