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
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5683103"
---
# <a name="specify-the-speech-recognizer-language"></a><span data-ttu-id="46e90-103">音声認識エンジンの言語の指定</span><span class="sxs-lookup"><span data-stu-id="46e90-103">Specify the speech recognizer language</span></span>


<span data-ttu-id="46e90-104">音声認識に使われるインストール済みの言語を選ぶ方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="46e90-104">Learn how to select an installed language to use for speech recognition.</span></span>

> <span data-ttu-id="46e90-105">**重要な API**: [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)、[**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)、[**Language**](https://msdn.microsoft.com/library/windows/apps/br206804)</span><span class="sxs-lookup"><span data-stu-id="46e90-105">**Important APIs**: [**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251), [**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250), [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804)</span></span>


<span data-ttu-id="46e90-106">ここでは、システムにインストールされている言語を列挙し、どの言語が既定の言語であるかを指定します。また、音声認識用に別の言語を選びます。</span><span class="sxs-lookup"><span data-stu-id="46e90-106">Here, we enumerate the languages installed on a system, identify which is the default language, and select a different language for recognition.</span></span>

**<span data-ttu-id="46e90-107">前提条件:</span><span class="sxs-lookup"><span data-stu-id="46e90-107">Prerequisites:</span></span>**

<span data-ttu-id="46e90-108">このトピックは、「[音声認識](speech-recognition.md)」に基づいています。</span><span class="sxs-lookup"><span data-stu-id="46e90-108">This topic builds on [Speech recognition](speech-recognition.md).</span></span>

<span data-ttu-id="46e90-109">音声認識と認識の制約についての基本的な知識が必要です。</span><span class="sxs-lookup"><span data-stu-id="46e90-109">You should have a basic understanding of speech recognition and recognition constraints.</span></span>

<span data-ttu-id="46e90-110">ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="46e90-110">If you're new to developing Universal Windows Platform (UWP) apps, have a look through these topics to get familiar with the technologies discussed here.</span></span>

-   [<span data-ttu-id="46e90-111">初めてのアプリ作成</span><span class="sxs-lookup"><span data-stu-id="46e90-111">Create your first app</span></span>](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   <span data-ttu-id="46e90-112">「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明</span><span class="sxs-lookup"><span data-stu-id="46e90-112">Learn about events with [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584)</span></span>

**<span data-ttu-id="46e90-113">ユーザー エクスペリエンス ガイドライン:</span><span class="sxs-lookup"><span data-stu-id="46e90-113">User experience guidelines:</span></span>**

<span data-ttu-id="46e90-114">魅力的な音声認識対応アプリの設計に役立つ便利なヒントについては、「[音声機能の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46e90-114">For helpful tips about designing a useful and engaging speech-enabled app, see [Speech design guidelines](https://msdn.microsoft.com/library/windows/apps/dn596121) .</span></span>

## <a name="identify-the-default-language"></a><span data-ttu-id="46e90-115">既定の言語を指定する</span><span class="sxs-lookup"><span data-stu-id="46e90-115">Identify the default language</span></span>


<span data-ttu-id="46e90-116">音声認識エンジンでは、システムの音声認識の言語を既定の認識言語として使います。</span><span class="sxs-lookup"><span data-stu-id="46e90-116">A speech recognizer uses the system speech language as its default recognition language.</span></span> <span data-ttu-id="46e90-117">この言語は、デバイスで [設定] &gt; [システム] &gt; [音声認識] &gt; [音声認識の言語] の順に移動し、画面上でユーザーが設定します。</span><span class="sxs-lookup"><span data-stu-id="46e90-117">This language is set by the user on the device Settings &gt; System &gt; Speech &gt; Speech Language screen.</span></span>

<span data-ttu-id="46e90-118">[**SystemSpeechLanguage**](https://msdn.microsoft.com/library/windows/apps/dn653252) 静的プロパティを調べて、既定の言語を特定します。</span><span class="sxs-lookup"><span data-stu-id="46e90-118">We identify the default language by checking the [**SystemSpeechLanguage**](https://msdn.microsoft.com/library/windows/apps/dn653252) static property.</span></span>

```CSharp
var language = SpeechRecognizer.SystemSpeechLanguage; 
```

## <a name="confirm-an-installed-language"></a><span data-ttu-id="46e90-119">インストールされている言語を確認する</span><span class="sxs-lookup"><span data-stu-id="46e90-119">Confirm an installed language</span></span>


<span data-ttu-id="46e90-120">インストールされている言語はデバイスによって異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46e90-120">Installed languages can vary between devices.</span></span> <span data-ttu-id="46e90-121">特定の制約を使う際にある言語に依存する場合は、その言語が存在するかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="46e90-121">You should verify the existence of a language if you depend on it for a particular constraint.</span></span>

<span data-ttu-id="46e90-122">**注:** 新しい言語パックをインストールした後、再起動が必要です。</span><span class="sxs-lookup"><span data-stu-id="46e90-122">**Note**A reboot is required after a new language pack is installed.</span></span> <span data-ttu-id="46e90-123">指定の言語がサポートされていない場合や、指定の言語のインストールが完了していない場合は、エラー コード SPERR\_NOT\_FOUND (0x8004503a) の例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="46e90-123">An exception with error code SPERR\_NOT\_FOUND (0x8004503a) is raised if the specified language is not supported or has not finished installing.</span></span>

 

<span data-ttu-id="46e90-124">[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) クラスの 2 つの静的プロパティのいずれかを調べて、デバイスでサポートされる言語を特定します。</span><span class="sxs-lookup"><span data-stu-id="46e90-124">Determine the supported languages on a device by checking one of two static properties of the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) class:</span></span>

-   <span data-ttu-id="46e90-125">[**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)— 定義済みのディクテーション文法および Web 検索文法と共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="46e90-125">[**SupportedTopicLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653251)—The collection of [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) objects used with predefined dictation and web search grammars.</span></span>

-   <span data-ttu-id="46e90-126">[**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)— 一覧の制約または Speech Recognition Grammar Specification (SRGS) ファイルと共に使われる [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="46e90-126">[**SupportedGrammarLanguages**](https://msdn.microsoft.com/library/windows/apps/dn653250)—The collection of [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) objects used with a list constraint or a Speech Recognition Grammar Specification (SRGS) file.</span></span>

## <a name="specify-a-language"></a><span data-ttu-id="46e90-127">言語を指定する</span><span class="sxs-lookup"><span data-stu-id="46e90-127">Specify a language</span></span>


<span data-ttu-id="46e90-128">言語を指定するには、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) コンストラクターで [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="46e90-128">To specify a language, pass a [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) object in the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) constructor.</span></span>

<span data-ttu-id="46e90-129">ここでは、認識言語として "en-US" を指定します。</span><span class="sxs-lookup"><span data-stu-id="46e90-129">Here, we specify "en-US" as the recognition language.</span></span>


```CSharp
var language = new Windows.Globalization.Language(“en-US”); 
var recognizer = new SpeechRecognizer(language); 
```

## <a name="remarks"></a><span data-ttu-id="46e90-130">注釈</span><span class="sxs-lookup"><span data-stu-id="46e90-130">Remarks</span></span>


<span data-ttu-id="46e90-131">トピック制約を構成するには、[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="46e90-131">A topic constraint can be configured by adding a [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446) to the [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) collection of the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) and then calling [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240).</span></span> <span data-ttu-id="46e90-132">サポートされているトピックの言語で認識エンジンが初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) が返されます。</span><span class="sxs-lookup"><span data-stu-id="46e90-132">A [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) of **TopicLanguageNotSupported** is returned if the recognizer is not initialized with a supported topic language.</span></span>

<span data-ttu-id="46e90-133">一覧の制約を構成するには、[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421) を [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) コレクションに追加して、[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="46e90-133">A list constraint is configured by adding a [**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421) to the [**Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) collection of the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) and then calling [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240).</span></span> <span data-ttu-id="46e90-134">カスタム一覧の言語を直接指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="46e90-134">You cannot specify the language of a custom list directly.</span></span> <span data-ttu-id="46e90-135">代わりに、認識エンジンの言語を使って一覧が処理されます。</span><span class="sxs-lookup"><span data-stu-id="46e90-135">Instead, the list will be processed using the language of the recognizer.</span></span>

<span data-ttu-id="46e90-136">SRGS 文法は、[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412) クラスによって表されるオープン スタンダードの XML 形式です。</span><span class="sxs-lookup"><span data-stu-id="46e90-136">An SRGS grammar is an open-standard XML format represented by the [**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412) class.</span></span> <span data-ttu-id="46e90-137">カスタム一覧とは異なり、SRGS マークアップで文法の言語を指定できます。</span><span class="sxs-lookup"><span data-stu-id="46e90-137">Unlike custom lists, you can specify the language of the grammar in the SRGS markup.</span></span> <span data-ttu-id="46e90-138">[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) は、認識エンジンが SRGS マークアップと同じ言語に初期化されていない場合は、**TopicLanguageNotSupported** の [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) により失敗します。</span><span class="sxs-lookup"><span data-stu-id="46e90-138">[**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) fails with a [**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433) of **TopicLanguageNotSupported** if the recognizer is not initialized to the same language as the SRGS markup.</span></span>

## <a name="related-articles"></a><span data-ttu-id="46e90-139">関連記事</span><span class="sxs-lookup"><span data-stu-id="46e90-139">Related articles</span></span>

**<span data-ttu-id="46e90-140">開発者向け</span><span class="sxs-lookup"><span data-stu-id="46e90-140">Developers</span></span>**

* [<span data-ttu-id="46e90-141">音声操作</span><span class="sxs-lookup"><span data-stu-id="46e90-141">Speech interactions</span></span>](speech-interactions.md)

**<span data-ttu-id="46e90-142">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="46e90-142">Designers</span></span>**

* [<span data-ttu-id="46e90-143">音声認識の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="46e90-143">Speech design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596121)

**<span data-ttu-id="46e90-144">サンプル</span><span class="sxs-lookup"><span data-stu-id="46e90-144">Samples</span></span>**

* [<span data-ttu-id="46e90-145">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="46e90-145">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




