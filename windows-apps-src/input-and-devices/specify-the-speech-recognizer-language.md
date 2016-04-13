---
Description: 音声認識に使われるインストール済みの言語を選ぶ方法について説明します。
title: 音声認識エンジンの言語の指定
ms.assetid: 4C463A1B-AF6A-46FD-A839-5D6724955B38
label: 音声認識エンジンの言語の指定
template: detail.hbs
---

# 音声認識エンジンの言語の指定


音声認識に使われるインストール済みの言語を選ぶ方法について説明します。

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)
-   [**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)
-   [**言語**](https://msdn.microsoft.com/library/windows/apps/br206804)


ここでは、システムにインストールされている言語を列挙し、どの言語が既定の言語であるかを指定します。また、音声認識用に別の言語を選びます。

**前提条件:  **

このトピックは、「[音声認識](speech-recognition.md)」に基づいています。

音声認識と認識の制約についての基本的な知識が必要です。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」でイベントについて学習します。

**ユーザー エクスペリエンス ガイドライン:  **

魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては、「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <span id="Identify_the_default_language"></span><span id="identify_the_default_language"></span><span id="IDENTIFY_THE_DEFAULT_LANGUAGE"></span>既定の言語を指定する


音声認識エンジンでは、システムの音声認識の言語を既定の認識言語として使います。 この言語は、デバイスで [設定]、[システム]、[音声認識]、[音声認識の言語] の順に移動し、画面上でユーザーが設定します。

[
            **SystemSpeechLanguage**](https://msdn.microsoft.com/library/windows/apps/dn653252) 静的プロパティを調べて、既定の言語を特定します。

```CSharp
var language = SpeechRecognizer.SystemSpeechLanguage; </code></pre></td>
</tr>
</tbody>
</table>
```

## <span id="Confirm_an_installed_language"></span><span id="confirm_an_installed_language"></span><span id="CONFIRM_AN_INSTALLED_LANGUAGE"></span>インストールされている言語を確認する


インストールされている言語はデバイスによって異なる場合があります。 特定の制約を使う際にある言語に依存する場合は、その言語が存在するかどうかを確認してください。

**注**  新しい言語パックをインストールした場合は、再起動が必要です。 指定の言語がサポートされていない場合や、指定の言語のインストールが完了していない場合は、エラー コード SPERR\_NOT\_FOUND (0x8004503a) の例外が発生します。

 

[
            **SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) クラスの 2 つの静的プロパティのいずれかを調べて、デバイスでサポートされる言語を特定します。

-   [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251): 定義済みのディクテーション文法および Web 検索文法と共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。

-   [**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250): 一覧の制約または Speech Recognition Grammar Specification (SRGS) ファイルと共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。

## <span id="Specify_a_language"></span><span id="specify_a_language"></span><span id="SPECIFY_A_LANGUAGE"></span>言語を指定する


言語を指定するには、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) コンストラクターで [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトを渡します。

ここでは、認識言語として "en-US" を指定します。

<span codelanguage="CSharp"></span>
```CSharp
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
var language = new Windows.Globalization.Language(“en-US”); 
var recognizer = new SpeechRecognizer(language); 
```

## <span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈


トピック制約を構成するには、[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。 サポートされているトピックの言語で認識エンジンが初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) が返されます。

一覧の制約を構成するには、[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。 カスタム一覧の言語を直接指定することはできません。 代わりに、認識エンジンの言語を使って一覧が処理されます。

SRGS 文法は、[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412) クラスによって表されるオープン スタンダードの XML 形式です。 カスタム一覧とは異なり、SRGS マークアップで文法の言語を指定できます。 認識エンジンが SRGS マークアップと同じ言語に初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) に基づいて [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) が失敗します。

## <span id="related_topics"></span>関連記事


**開発者向け**
* [音声操作](speech-interactions.md)
**デザイナー向け**
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 






<!--HONumber=Mar16_HO1-->


