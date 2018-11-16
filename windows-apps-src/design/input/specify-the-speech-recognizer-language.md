---
author: Karl-Bridge-Microsoft
Description: Learn how to select an installed language to use for speech recognition.
title: 音声認識エンジンの言語の指定
ms.assetid: 4C463A1B-AF6A-46FD-A839-5D6724955B38
label: Specify the speech recognizer language
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7e042a9bbedee3ded0601eda06da8e349c4b788c
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6835242"
---
# <a name="specify-the-speech-recognizer-language"></a>音声認識エンジンの言語の指定


音声認識に使われるインストール済みの言語を選ぶ方法について説明します。

> **重要な API**: [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)、[**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)、[**Language**](https://msdn.microsoft.com/library/windows/apps/br206804)


ここでは、システムにインストールされている言語を列挙し、どの言語が既定の言語であるかを指定します。また、音声認識用に別の言語を選びます。

**前提条件:**

このトピックは、「[音声認識](speech-recognition.md)」に基づいています。

音声認識と認識の制約についての基本的な知識が必要です。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:**

魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては、「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。

## <a name="identify-the-default-language"></a>既定の言語を指定する


音声認識エンジンでは、システムの音声認識の言語を既定の認識言語として使います。 この言語は、デバイスで [設定] &gt; [システム] &gt; [音声認識] &gt; [音声認識の言語] の順に移動し、画面上でユーザーが設定します。

[**SystemSpeechLanguage**](https://msdn.microsoft.com/library/windows/apps/dn653252) 静的プロパティを調べて、既定の言語を特定します。

```CSharp
var language = SpeechRecognizer.SystemSpeechLanguage; 
```

## <a name="confirm-an-installed-language"></a>インストールされている言語を確認する


インストールされている言語はデバイスによって異なる場合があります。 特定の制約を使う際にある言語に依存する場合は、その言語が存在するかどうかを確認してください。

**注:** 新しい言語パックをインストールした後、再起動が必要です。 指定の言語がサポートされていない場合や、指定の言語のインストールが完了していない場合は、エラー コード SPERR\_NOT\_FOUND (0x8004503a) の例外が発生します。

 

[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) クラスの 2 つの静的プロパティのいずれかを調べて、デバイスでサポートされる言語を特定します。

-   [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)— 定義済みのディクテーション文法および Web 検索文法と共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。

-   [**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)— 一覧の制約または Speech Recognition Grammar Specification (SRGS) ファイルと共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。

## <a name="specify-a-language"></a>言語を指定する


言語を指定するには、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) コンストラクターで [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトを渡します。

ここでは、認識言語として "en-US" を指定します。


```CSharp
var language = new Windows.Globalization.Language(“en-US”); 
var recognizer = new SpeechRecognizer(language); 
```

## <a name="remarks"></a>注釈


トピック制約を構成するには、[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。 サポートされているトピックの言語で認識エンジンが初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) が返されます。

一覧の制約を構成するには、[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。 カスタム一覧の言語を直接指定することはできません。 代わりに、認識エンジンの言語を使って一覧が処理されます。

SRGS 文法は、[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412) クラスによって表されるオープン スタンダードの XML 形式です。 カスタム一覧とは異なり、SRGS マークアップで文法の言語を指定できます。 [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) は、認識エンジンが SRGS マークアップと同じ言語に初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) により失敗します。

## <a name="related-articles"></a>関連記事

**開発者向け**

* [音声操作](speech-interactions.md)

**デザイナー向け**

* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)

**サンプル**

* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




