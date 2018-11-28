---
title: 記述スタイル
description: アプリのテキストを設計と融合させるには、適切なボイスとトーンを使用することが重要です。
keywords: UWP, Windows 10, テキスト, 記述, ボイス, トーン, 設計, UI, UX
ms.date: 5/7/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: b09265164ccd922ab310c06e6c2bd14b6d7a841c
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7851546"
---
# <a name="writing-style"></a>記述スタイル

![ヘッダー画像](images/header-writing-style.gif)

エラー メッセージの表現や、ヘルプ ドキュメントの文章、ボタンのテキストは、アプリの使いやすさに大きな影響を与えます。 記述スタイルによって、ユーザー エクスペリエンスが不快にも快適にもなる大きな違いが生まれます。

## <a name="voice-and-tone-principles"></a>ボイスとトーンの原則

研究によると、ユーザーの好感度が最も高いのは、親しみやすく、有用で、簡潔な記述スタイルです。 この調査の一貫として、Microsoft は、すべてのコンテンツ全体に適用するボイスとトーンに関する 3 つの原則を作成しました。これは Fluent Design の重要な一部です。

### <a name="be-warm-and-relaxed"></a>友好的で気取らない

まずユーザーを萎縮させないことが、何よりも大切です。 堅苦しくない、打ち解けた口調を使います。ユーザーが理解できない用語を使わないでください。 問題が発生した場合も、ユーザーを非難してはなりません。 問題の責任はアプリが引き受け、ユーザーの操作を第一に考えて、親切に手順を説明してください。

### <a name="be-ready-to-lend-a-hand"></a>手助けになる

常に、文章で共感を示します。 現在の状況説明とユーザーに必要な情報の提供に絞って記述します。不要な情報でユーザーに負担をかけないでください。 また、可能であれば、問題がある場合には常にソリューションを提供します。

### <a name="be-crisp-and-clear"></a>簡潔かつ明瞭である

ほとんどの場合、テキストはアプリの主役ではありません。 テキストはユーザーをガイドし、現在の状況と次に行う操作を説明するためにあります。 アプリのテキストを作成する際には、この視点を忘れないでください。また、ユーザーがすべての言葉を読むと想定しないでください。 対象ユーザーにとって馴染みのある言葉を使用し、一目で理解しやすいことを確認します。

## <a name="lead-with-whats-important"></a>大切なことから説明する

テキストは、ユーザーが読んで一目で理解できる必要があります。 不要な前置きを付けて単語を長くしないでください。 重要なポイントが最も目立つようにします。常に、アイデアの中核部分を示した後で、説明を追加します。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        Select **filters** to add effects to your image.
    :::column-end:::
    :::column:::
        ![Don't](images/dont.svg)
        If you want to add visual effects or alterations to your image, select **filters.**
    :::column-end:::
:::row-end:::

## <a name="emphasize-action"></a>アクションを強調する

アプリは、アクションによって定義されます。 ユーザーはアプリを使用するときにアクションを実行し、アプリはユーザーに応答するときにアクションを実行します。 アプリ全体のテキストで*能動態*を使用していることを確認します。 ユーザーや機能は、アクションが実行される対象ではなく、アクションを実行するものとして記述する必要があります。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        Restart the app to see your changes.
    :::column-end:::
    :::column:::
        ![Don't](images/dont.svg)
        The changes will be applied when the app is restarted.
    :::column-end:::
:::row-end:::

## <a name="short-and-sweet"></a>短く、わかりやすく

ユーザーはテキストをざっと見て、多くの場合、より大きな単語のブロック全体をスキップします。 必要な情報やプレゼンテーションを犠牲してはいけませんが、必要以上に語句を使用しないでください。 これは、短い文や語句を多用することを意味する場合もあれば、 長い文で単語や構造を慎重に選ぶことを意味する場合もあります。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        We couldn't upload the picture. If this happens again, try restarting the app. But don't worry — your picture will be waiting when you come back.
    :::column-end:::
    :::column:::
        ![Don't](images/dont.svg)
        An error occured, and we weren't able to upload the picture. Please try again, and if you encounter this problem again, you may need to restart the app. But don't worry — we've saved your work locally, and it'll be waiting for you when you come back.
    :::column-end:::
:::row-end:::

## <a name="style-conventions"></a>スタイルの規則

日頃から書き慣れていない限り、これらの原則や推奨事項を実際のテキストに応用すると考えただけで、しり込みしてしまうかもしれません。 しかし心配は要りません。シンプルで率直な言葉遣いこそが、優れたユーザー エクスペリエンスへの一番の近道です。 しかしそれでもなお、テキストの作成が不安な方のために、役立つガイドラインを以下にご紹介します。 また、詳細情報が必要な場合は、「[Microsoft スタイル ガイド](https://docs.microsoft.com/style-guide/welcome/)」を参照してください。

### <a name="addressing-the-user"></a>ユーザーに対して話しかける

ユーザーに直接話しかけます。
* ユーザーを常に "あなた" と呼びます。
* 自分の視点から書く場合は、"私たち" を使います。 暖かい口調で、ユーザーが自分をアプリのエクスペリエンスの一部だと感じられるように話しかけます。
* アプリの開発者が自分だけであっても、アプリの視点を "私" と表現しないでください。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        We couldn't save your file to that location.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end:::

### <a name="abbreviations"></a>略語

 略語は、同じ製品、場所、技術的概念をアプリ全体にわたって何度も参照する必要がある場合に便利です。 略語を使用することで、スペースを節約でき、テキストがより自然になります。ただし、それはあくまでユーザーが略語を理解している場合です。
* 一般的だと思われる略語でも、ユーザーが当然知っていると考えないでください。
* すべての新しい略語は、必ず初出時にその意味を定義します。
* 混同しやすい複数の略語を使用しないでください。
* アプリをローカライズしている場合、または、ユーザーが第二言語として英語を話す場合は、略語を使用しないでください。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps. With the design features that are included in every UWP app, you can build user interfaces (UI) that scale across a range of devices.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end:::

### <a name="contractions"></a>短縮形

短縮形は多くのユーザーが慣れ親しんだ、通常使用されている形式です。 短縮形を使わずに記述すると、アプリが堅苦しく、形式ばった印象になります。
* テキストに自然に溶け込んでいる場合は、短縮形を使用してください。
* スペースの節約や、テキストを堅苦しくするためだけに、不自然な短縮形を使用しないでください。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        When you're happy with your image, select **save** to add it to your gallery. From there, you'll be able to share it with friends.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end:::

### <a name="periods"></a>ピリオド

 テキストの末尾のピリオドは、そのテキストが完全文であることを暗に意味します。 大きなブロックのテキストにはピリオドを使用し、完全文でないテキストの場合は使用を避けてください。
* ツールチップ、エラー メッセージ、ダイアログの完全文の末尾には、ピリオドを使用します。
* ボタン、ラジオ ボタン、ラベル、チェック ボックスのテキストの末尾には、ピリオドを使用しません。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        <b>You’re not connected.</b>
        * Check that your network cables are plugged in.
        * Make sure you're not in airplane mode.
        * See if your wireless switch is turned on.
        * Restart your router.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end:::

### <a name="capitalization"></a>大文字化

大文字を使用することは重要ですが、使い過ぎに注意してください。
* 固有名詞の先頭は大文字にします。
* アプリ内のすべてのテキスト文字列の先頭 (すべての文、ラベル、タイトルの先頭) は大文字にします。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        <b>Which part is giving you trouble?</b>
        * I forgot your password.
        * It won't accept password.
        * Someone else might be using my account.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end:::

## <a name="error-messages"></a>エラー メッセージ

アプリで問題が発生すると、ユーザーはそれに対して注意を払います。 エラー メッセージが発生するとユーザーは混乱したり、苛立ちを感じたりする可能性があるため、エラー メッセージで適切なボイスとトーンを使うことは特に大きな効果があります。

何よりも重要なのは、エラー メッセージでユーザーを非難しないことです。 また、理解できない情報で、ユーザーを困惑させないことも重要です。 ほとんどの場合、エラーに遭遇したユーザーは、できるだけ素早く簡単にエラー発生前の状態に戻ることだけを望んでいます。 したがって、エラー メッセージは、以下の条件を備える必要があります。

* 会話的なトーンを使用し、なじみのない用語や技術的な専門用語を避けることで、**友好的で気取らない**ようにします。

* ユーザーにできる限り原因を明らかにし、その後の流れを説明すると共に、ユーザーが実行できる現実的な解決策を提示することで、**手助けになる**ようにします。

* 余分な情報を除外することで**簡潔かつ明瞭である**ようにします。

:::row:::
    :::column:::
        ![Do](images/do.svg)
        <b>You’re not connected.</b>
        * Check that your network cables are plugged in.
        * Make sure you're not in airplane mode.
        * See if your wireless switch is turned on.
        * Restart your router.
    :::column-end:::
    :::column:::
    :::column-end:::
:::row-end::: 

## <a name="dialogs"></a>ダイアログ

:::row:::
    :::column:::
        Many of the same advice for writing error messages also applies when creating the text for any dialogs in your app. While dialogs are expected by the user, they still interrupt the normal flow of the app, and need to be helpful and concise so the user can get back to what they were doing.

        But most important is the "call and response" between the title of a dialog and its buttons. Make sure that your buttons are clear answers to the question posed by the title, and that their format is consistent across your app.
    :::column-end:::
    :::column:::
        ![Do](images/do.svg)
        <b>Which part is giving you trouble?</b>
        1. I forgot my password
        2. It won't accept my password
        3. Someone else might be using my account
    :::column-end:::
:::row-end:::

## <a name="buttons"></a>ボタン

:::row:::
    :::column:::
        Text on buttons needs to be concise enough that users can read it all at a glance and clear enough that the button's function is immediately obvious. The longest the text on a button should ever be is a couple short words, and many should be shorter than that.
        When writing the text for buttons, remember that every button represents an action. Be sure to use the *active voice* in button text, to use words that represent actions rather than reactions.
    :::column-end:::
    :::column:::
        ![Do](images/do.svg)
        * Install now
        * Share
    :::column-end:::
:::row-end:::

## <a name="spoken-experiences"></a>音声エクスペリエンス

同じ一般原則と推奨事項は、Cortana などの音声エクスペリエンス用のテキストを作成する場合にも当てはまります。 音声エクスペリエンスでは、他の視覚的デザイン要素をユーザーに提供して音声情報を補足できないため、適切なテキスト作成のための原則に従うことがさらに重要になります。

* 会話的なトーンで、ユーザーに親近感を与えることで**友好的で気取らない**ようにします。 音声エクスペリエンスでは、暖かく親しみやすい印象と、ユーザーが抵抗なく話せることが他のどの領域よりも重要です。

* ユーザーから不可能なことを要求されたときは、代替案を提示して、**手助けになる**ようにします。 エラー メッセージと同様、何らかの理由でアプリがユーザーの要求を満たせない場合、ユーザーが代わりに要求できる現実的な代替案をアプリが提示する必要があります。

* 常にシンプルな言葉を使用して**簡潔かつ明瞭である**ようにします。 音声エクスペリエンスは、長い文章や複雑な単語には不向きです。

## <a name="accessibility-and-localization"></a>アクセシビリティとローカライズ

アクセシビリティとローカライズを念頭に置いてテキストが作成されているアプリは、幅広いユーザーにアクセスできます。 これはテキストによってのみ達成できる側面です。率直で親しみやすい言葉遣いが成功への第一歩となります。 詳細については、弊社の[アクセシビリティの概要](https://docs.microsoft.com/windows/uwp/design/accessibility/accessibility-overview)と[ローカライズのガイドライン](https://docs.microsoft.com/windows/uwp/design/globalizing/globalizing-portal)を参照してください。

* さまざまなエクスペリエンスを考慮に入れて、**手助けになる**ようにします。 他国のユーザーに理解できない可能性のある語句を避けます。またユーザーに何ができ、何ができないかを想定する言葉を使わないでください。

* 必要でない限り、特殊な専門用語を避け、**簡潔かつ明瞭である**ようにします。 テキストが率直であるほど、ローカライズが容易になります。


## <a name="techniques-for-non-writers"></a>テキスト作成に慣れていない方のためのテクニック

快適なエクスペリエンスをユーザーに提供するために、トレーニングを受け、経験を積んだ書き手である必要はありません。 自分にとって心地よい言葉を選びます。それは他人にも心地よい言葉です。 しかしそれは、考えていたほど簡単でないことがあります。 行き詰まった場合は、以下のテクニックを試してみてください。 

* アプリを友人に説明しているところを想像します。 このアプリをその人たちにどのように説明しますか。 アプリの機能についてどのように話し、操作手順をどのように伝えますか。 さらに良いのは、まだ使用したことのない人にアプリを説明してみることです。 

* まったく異なるアプリを説明するとしたら、どのように説明するかを想像してください。 たとえば、ゲームを作っている場合は、財務アプリやニュース アプリを説明するのにどのように話したり、書いたりするかを考えてみてください。 言葉遣いや構造の違いを意識すると、実際のアプリの説明に使う適切な単語がより明らかになります。

* 同種のアプリを見て、ヒントを得るのも良い方法です。 

適切な言葉を見つけることは多くの人にとって簡単ではありません。自然に感じられる表現が見つからなくても、決して気に病むことはありません。
