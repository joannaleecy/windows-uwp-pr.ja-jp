---
author: Karl-Bridge-Microsoft
Description: ユーザーがコマンド内の任意の場所にアプリ名を含めることができるように、柔軟で自然な音声コマンドで Cortana を拡張する方法について説明します。
title: Cortana での自然言語音声コマンドのサポート
ms.assetid: 281E068A-336A-4A8D-879A-D8715C817911
label: Support natural language voice commands
template: detail.hbs
---

# Cortana での自然言語音声コマンドのサポート

ユーザーがコマンド内の任意の場所にアプリ名を含めることができる柔軟で自然な音声コマンドで **Cortana** を拡張します。

**重要な API**

-   [**Windows.ApplicationModel.VoiceCommands**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**音声コマンド定義 (VCD) の要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)


音声コマンドを使ってアプリの機能で Cortana を拡張する場合、ユーザーはアプリと実行するコマンドや機能の両方を指定する必要があります。 通常、これは音声コマンドの最初または最後にアプリ名を発音することによって行います。 たとえば、「Adventure Works、新しいラスベガス旅行を追加します」などです。

ただし、このような方法でアプリケーション名を指定すると、不自然であったり、堅苦しくなる可能性がありますし、意味をなさないことすらあります。 多くの場合、コマンドの別の場所でアプリ名を言うことができた方が使いやすく自然なため、操作がより直感的になり、ユーザーにとって魅力的です。 前の例の「Adventure Works、新しいラスベガス旅行を追加します」は次のように言い換えることができます。 「新しい Adventure Works のラスベガス旅行を追加します」 または「Adventure Works を使って、新しいラスベガス旅行を追加します」

アプリ名が以下の位置でサポートされるように音声コマンドを設定することができます。

-   プレフィックス - コマンド語句の前
-   インフィックス - コマンド語句の途中
-   サフィックス - コマンド語句の後

**前提条件:  **

このトピックは、「[Cortana の音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)」に基づいています。 ここでは、引き続き **Adventure Works** という旅行の計画および管理アプリを使って機能について説明します。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:  **

アプリと **Cortana** を統合する方法については「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」を、便利で魅力的な音声認識対応アプリの設計に役立つヒントについては「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Specify_an_AppName_element_in_the_VCD"></span><span id="specify_an_appname_element_in_the_vcd"></span><span id="SPECIFY_AN_APPNAME_ELEMENT_IN_THE_VCD"></span>VCD での **AppName** 要素の指定


**AppName** 要素は、音声コマンドでアプリのわかりやすい名前を指定するために使います。
```XML
<AppName>Adventure Works</AppName>
```

## <span id="Specify_where_the_app_name_can_be_spoken_in_the_voice_command"></span><span id="specify_where_the_app_name_can_be_spoken_in_the_voice_command"></span><span id="SPECIFY_WHERE_THE_APP_NAME_CAN_BE_SPOKEN_IN_THE_VOICE_COMMAND"></span>アプリ名を言うことができる音声コマンド内の場所を指定します。


**ListenFor** 要素には、アプリ名を言うことができる音声コマンド内の場所を指定する **RequireAppName** 属性があります。 この属性では、次の 4 つの値がサポートされます。

1.  **BeforePhrase**

    既定値。

    ユーザーがコマンド語句の前にアプリ名を言う必要があることを指定します。

    ここでは、Cortana は「Adventure Works、次のラスベガス旅行はいつですか」という内容を待機します。
```xml
<ListenFor RequireAppName="BeforePhrase"> show [my] trip to {destination} </ListenFor>
```

2.  **AfterPhrase**

    ユーザーがコマンド語句の後にアプリ名を言う必要があることを指定します。

    前置詞付きの接続詞のローカライズされた語句一覧がシステムによって提供されます。 これには、"を使って"、"によって"、"で" などの語句が含まれます。

    ここでは、Cortana は「次のラスベガス旅行を Adventure Works で表示してください」や「次のラスベガス旅行を、Adventure Works を使って表示してください」などのコマンドを待機します。
```xml
<ListenFor RequireAppName="AfterPhrase">show [my] next trip to {destination} </ListenFor>
```

3.  **BeforeOrAfterPhrase**

    ユーザーがコマンド語句の前または後にアプリ名を言う必要があることを指定します。

    サフィックスとして使われる場合については、前置詞付きの接続詞のローカライズされた語句一覧がシステムによって提供されます。 これには、"を使って"、"によって"、"で" などの語句が含まれます。

    ここでは、Cortana は「Adventure Works、次のラスベガス旅行を表示してください」や「次のラスベガス旅行を Adventure Works で表示してください」などのコマンドを待機します。
``` xml
<ListenFor RequireAppName="BeforeOrAfterPhrase">show [my] next trip to {destination}</ListenFor>
```

4.  **ExplicitlySpecified**

    ユーザーがコマンド語句の指定箇所でアプリ名を言う必要があることを指定します。 ユーザーは、語句の前後にアプリ名を言う必要はありません。

    **{builtin:AppName}** タグを使ってアプリ名を明示的に参照する必要があります。

    ここでは、Cortana は「Adventure Works、次のラスベガス旅行を表示してください」や「Adventure Works に登録されている次のラスベガス旅行を表示してください」などのコマンドを待機します。
```xml
<ListenFor RequireAppName="ExplicitlySpecified">show [my] next {builtin:AppName} trip to {destination} </ListenFor>
```

## <span id="Special_cases"></span><span id="special_cases"></span><span id="SPECIAL_CASES"></span>特殊なケース

**RequireAppName** が "AfterPhrase" または "ExplicitlySpecified" の **ListenFor** 要素を宣言するときは、次の特定の要件を満たす必要があります。

1.  **RequireAppName** が "ExplicitlySpecified" の場合、**{builtin:AppName}** は 1 回だけ出現する必要があります。

    この値を使うと、システムはアプリ名が音声コマンドのどの場所に出現するかを推測できません。 場所を明示的に指定する必要があります。

2.  音声コマンドの先頭を **PhraseTopic** 要素にすることはできません。この要素は、通常語彙の多い音声認識に使われます。 少なくとも 1 つの単語を前に付ける必要があります。

    これは、コマンドの言葉のどこかにアプリ名やその一部が含まれている場合に **Cortana** によりアプリが起動される可能性を最小限に抑えるのに役立ちます。

    ユーザーが「Kinect のアドベンチャー ワークスのレビューを表示してください」のような内容を声に出した場合に、**Cortana** によって **Adventure Works** アプリが起動される可能性がある無効な宣言の例を次に示します。
```xml
<ListenFor RequireAppName="ExplicitlySpecified">{searchPhrase} {builtin:AppName}</ListenFor>
```

3.  アプリ名と **PhraseTopic** 要素への参照に加えて、**ListenFor** 文字列内に 2 単語以上が含まれている必要があります。

    ケース 2 と同様、アプリが意図せずに起動してしまう可能性を最小限に抑えるため、コマンドに十分な音声コンテンツが含まれるようにする必要があります。

    これは、ユーザーが「Kinect のアドベンチャー ワークスを検索します」などと言ったときにアプリケーションが間違って起動しないように、できる限り成功率の高い方法でアプリケーションを設定するのに役立ちます。

    ユーザーが「アドベンチャー ワークスさん」や「Kinect のアドベンチャー ワークスを検索します」のような内容を声に出した場合に、**Cortana** によって **Adventure Works** アプリが起動される可能性がある無効な宣言の例を次に示します。
```xml
<ListenFor RequireAppName="ExplicitlySpecified">Hey {builtin:AppName}</ListenFor>
<ListenFor RequireAppName="ExplicitlySpecified">Find {searchPhrase} {builtin:AppName}</ListenFor>
```

## <span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈

**Cortana** でユーザーが声に出すことができる音声コマンドのバリエーションを増やすことによっても、アプリの全体的な使いやすさが高まります。

「\[アプリ名\] さん」を **AppName** や **CommandPrefix** にしないでください。 ユーザーは、音声アクティブ化により Cortana を呼び出すために「コルタナさん」と言う可能性は高く、言葉の途中で「\[アプリ名\] さん」と言うことは自然ではありません。 たとえば、「コルタナさん。次のラスベガス旅行を Adventure Works さんで表示してください」などです。

既存の音声コマンドにインフィックス/サフィックスのバリエーションを追加することを検討してください。 ここに示したように、既存の **ListenFor** 要素を追加してサフィックスの変化形をサポートするのに、多くの労力はかかりません。 「コルタナさん。Adventure Works、次のラスベガス旅行を表示してください」より「コルタナさん。次のラスベガス旅行を Adventure Works で表示してください」の方が自然です。

音声コマンドが **Cortana** の既存の機能 (通話、メッセージングなど) と競合する場合は、アプリ名をプレフィックスとして使うことを検討してください。 たとえば、「Adventure Works、ラスベガス旅行に関する \[旅行会社\] にメッセージ送信してください」などです。

## <span id="Complete_example"></span><span id="complete_example"></span><span id="COMPLETE_EXAMPLE"></span>完全な例


より自然な言語の音声コマンドを提供するさまざまな方法を示す VCD ファイルを次に示します。

**注**  それぞれ異なる **RequireAppName** 属性値を持つ複数の **ListenFor** 要素を設定することは有効です。 

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="commandSet_en-us">
    <AppName>Adventure Works</AppName>
    <Example> When is my trip to Las Vegas? </Example>
    <Command Name="whenIsTripToDestination">
      <Example> When is my trip to Las Vegas?</Example>
      <ListenFor RequireAppName="BeforePhrase">
        when is my] trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands like 
           “Show my next trip to Las Vegas on Adventure Works”; “Show my next 
           trip to Las Vegas using Adventure Works” -->
      <ListenFor RequireAppName="AfterPhrase">
        show [my] next trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands when 
           the user specifies your app name either before or after the command. 
           “Adventure Works, show my next trip to Las Vegas”; 
           “Show my next trip to Last Vegas on Adventure works” -->
      <ListenFor RequireAppName="BeforeOrAfterPhrase">
        show [my] next trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands 
           when the user specifies your app name inline. 
           “Show my next Adventure Works trip to Las Vegas” -->
      <ListenFor RequireAppName="ExplicitlySpecified">
        show [my] next {builtin:AppName} trip to {destination} </ListenFor>

      <Feedback> Looking for trip to {destination} </Feedback>
      <Navigate />
    </Command>
    <PhraseList Label="destination">
      <Item> Las Vegas </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>
  </CommandSet>
  <!-- Other CommandSets for other languages -->
</VoiceCommands>
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
 

 






<!--HONumber=May16_HO2-->


