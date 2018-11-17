---
author: lex
Description: The following article describes all of the properties and elements within the toast content XML payload.
title: トースト通知のコンテンツの XML スキーマ
ms.assetid: AF49EFAC-447E-44C3-93C3-CCBEDCF07D22
label: Toast content XML schema
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: bcfc56264ab3063995fd9f2b06bd93e9406cd37e
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151614"
---
# <a name="toast-content-xml-schema"></a>トースト通知のコンテンツの XML スキーマ

 

ここでは、トースト通知のコンテンツの XML ペイロードにあるすべてのプロパティと要素を説明します。

次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。

## <a name="ltvisualgt-and-ltaudiogt"></a>&lt;visual&gt; および &lt;audio&gt;

```
<toast launch? duration? activationType? scenario? >
  <visual lang? baseUri? addImageQuery? >
    <binding template? lang? baseUri? addImageQuery? >
      <text lang? hint-maxLines? >content</text>
      <image src placement? alt? addImageQuery? hint-crop? />
      <group>
        <subgroup hint-weight? hint-textStacking? >
          <text />
          <image />
        </subgroup>
      </group>
    </binding>
  </visual>
  <audio src? loop? silent? />
</toast>
```

**&lt;toast&gt; 内の属性**

launch?

-   launch?  = 文字列
-   この属性は省略可能です。
-   トースト通知によってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。
-   activationType の値に応じて、この値は、フォアグラウンドのアプリ、バックグラウンド タスクの内部、または元のアプリからプロトコル起動された他のアプリで取得することができます。
-   この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。
-   ユーザーがトースト通知をタップまたはクリックし、関連するアプリを起動すると、そのアプリは既定の方法で起動されるのではなく、起動文字列によって、そのコンテキストがアプリに渡され、トースト通知のコンテンツに関連するビューがユーザーに表示されます。
-   ユーザーがトースト通知の本文ではなく操作をクリックしたことによってアクティブ化が行われた場合、&lt;toast&gt; タグ内に定義済みの "launch" ではなく、&lt;action&gt; タグ内に事前に定義されている "arguments" が取得されます。

duration?

-   duration?  = "short|long"
-   この属性は省略可能です。 既定値は "short" です。
-   これは、特定のシナリオやアプリケーションの互換性のみを目的とした属性です。 アラーム シナリオでは、この属性は必要ありません。
-   このプロパティを使うことはお勧めしません。

activationType?

-   activationType?  = "foreground | background | protocol | system"
-   この属性は省略可能です。
-   既定値は "foreground" です。

scenario?

-   scenario?  = "default | alarm | reminder | incomingCall"
-   この属性は省略可能です。既定値は "default" です。
-   シナリオがアラーム、リマインダー、着信呼び出しの表示以外の場合、この属性は必要ありません。
-   通知を常に画面上に表示することのみを目的とする場合は、この属性を使わないでください。

**&lt;visual&gt; 内の属性**

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

baseUri?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;binding&gt; 内の属性**

template?

-   \[重要\] template?  = "ToastGeneric"
-   新しいアダプティブ通知と対話型通知の機能を使う場合は、従来のテンプレートではなく、必ず "ToastGeneric" テンプレートを使って作業を始めてください。
-   新しい操作で従来のテンプレートを使うと、現時点では動作する可能性があります。ただし、この方法は対象となる使用方法ではないため、今後も引き続き動作するかどうかは保証できません。

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

baseUri?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;text&gt; 内の属性**

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;image&gt; 内の属性**

src

-   この必須の属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

placement?

-   placement?  = "inline" | "appLogoOverride"
-   この属性は省略可能です。
-   この属性は、画像が表示される場所を指定します。
-   "inline" は、トースト通知本文内のテキストの下に表示されることを意味します。"appLogoOverride" は、アプリケーション アイコン (トースト通知の左上隅に表示される) を置き換えることを意味します。
-   各 placement の値に指定できる画像は 1 つまでです。

alt?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

hint-crop?

-   hint-crop?  = "none" | "circle"
-   この属性は省略可能です。
-   既定値は "none" であり、トリミングされないことを意味します。
-   "circle" を指定すると、画像が円形にトリミングされます。 連絡先のプロフィール画像、人物の画像などにこの属性を使います。

**&lt;audio&gt; 内の属性**

src?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

loop?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

silent?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

## <a name="schemas-ltactiongt"></a>スキーマ: &lt;action&gt;


次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。

```
<toast>
  <visual>
  </visual>
  <audio />
  <actions>
    <input id type title? placeHolderContent? defaultInput? >
      <selection id content />
    </input>
    <action content arguments activationType? imageUri? hint-inputId />
  </actions>
</toast>
```

**&lt;input&gt; 内の属性**

id

-   id = 文字列
-   この属性は必須です。
-   id 属性は必須の属性であり、アプリが (フォアグラウンドまたはバックグラウンドで) アクティブ化されたときにユーザー入力を取得するために使われます。

type

-   type = "text | selection"
-   この属性は必須です。
-   この属性を使って、テキスト入力であるか、事前に定義された選択項目の一覧からの入力であるかを指定します。
-   モバイルやデスクトップでは、この属性は、テキスト ボックスによる入力を使うか、リスト ボックスによる入力を使うかを指定します。

title?

-   title?  = 文字列
-   title 属性は省略可能です。開発者は、シェルの入力に対してタイトルを指定し、アフォーダンスがあるときに表示します。
-   モバイルやデスクトップでは、入力の上にこのタイトルが表示されます。

placeHolderContent?

-   placeHolderContent?  = 文字列
-   placeHolderContent 属性は省略可能です。入力の種類が text の場合に、ヒントのテキストを灰色で表示します。 入力の種類が "text" 以外の場合、この属性は無視されます。

defaultInput?

-   defaultInput?  = 文字列
-   defaultInput 属性は省略可能です。既定の入力値を指定するために使われます。
-   入力の種類が "text" である場合、この属性は文字列入力として処理されます。
-   入力の種類が "selection" である場合、この属性は、入力の要素内で利用できるいずれかの選択項目の ID として処理されます。

**&lt;selection&gt; 内の属性**

id

-   この属性は必須です。 ユーザーの選択項目を特定するために使われます。 id はアプリに返されます。

content

-   この属性は必須です。 この selection 要素に対して表示する文字列を指定します。

**&lt;action&gt; 内の属性**

content

-   content = 文字列
-   content 属性は必須です。 ボタンに表示されるテキスト文字列を指定します。

arguments

-   arguments = 文字列
-   arguments 属性は必須です。 この属性は、アプリによって定義されたデータを表します。ユーザーがこの action を実行し、アプリがアクティブ化された後で、アプリはこのデータを取得することができます。

activationType?

-   activationType?  = "foreground | background | protocol | system"
-   activationType 属性は省略可能です。既定値は "foreground" です。
-   この属性は、この action によって行われるアクティブ化の種類を表します (フォアグラウンド、バックグラウンド、プロトコル起動による別のアプリの起動、またはシステム操作の呼び出し)。

imageUri?

-   imageUri?  = 文字列
-   imageUri は省略可能です。この action 用の画像アイコンを指定するために使われます。このアイコンは、テキスト コンテンツと共にボタン内に表示されます。

hint-inputId

-   hint-inputId = 文字列
-   hint-inpudId 属性は必須です。 特に、すばやく応答するシナリオで使われます。
-   値は、この属性に関連付ける必要がある入力要素の ID にする必要があります。
-   モバイルやデスクトップでは、この属性によって、入力ボックスのすぐ横にボタンが配置されます。

## <a name="attributes-for-system-handled-actions"></a>システムによって処理される操作の属性


アプリで再通知や通知の再スケジュールをバックグラウンド タスクとして処理しない場合は、システムで、再通知や通知を閉じるための操作を処理できます。 システムによって処理される操作は、組み合わせることができます (または個別に指定することもできます)。ただし、閉じる操作を使わないで再通知の操作を実装することはお勧めしません。

システム コマンドの組み合わせ: SnoozeAndDismiss

```
<toast>
  <visual>
  </visual>
  <actions hint-systemCommands="SnoozeAndDismiss" />
</toast>
```

システムによって処理される操作を個別に指定

```
<toast>
  <visual>
  </visual>
  <actions>
  <input id="snoozeTime" type="selection" defaultInput="10">
    <selection id="5" content="5 minutes" />
    <selection id="10" content="10 minutes" />
    <selection id="20" content="20 minutes" />
    <selection id="30" content="30 minutes" />
    <selection id="60" content="1 hour" />
  </input>
  <action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content=""/>
  <action activationType="system" arguments="dismiss" content=""/>
  </actions>
</toast>
```

再通知や閉じる操作を個別に指定するには、次の手順に従います。

-   activationType = "system" を指定します。
-   arguments = "snooze" または arguments = "dismiss" を指定します。
-   content を指定します。
    -   "snooze" (一時停止する) や "dismiss" (無視) に対応するローカライズされた文字列を操作に対して表示する場合は、content に空の文字列を指定します (&lt;action content = ""/&gt;)。
    -   カスタマイズした文字列を使用する場合は、その値を指定します (&lt;action content="Remind me later" /&gt;)。
-   input を指定します。
    -   再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。
    -   再通知の間隔に関する選択項目を指定する場合:
        -   再通知の操作内に、hint-inputId を指定します。
        -   input の id に、再通知の操作の hint-inputId と同じ値を指定します (&lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/&gt;)。
        -   selection の id に、再通知の間隔を分単位で表す負以外の整数を指定します。&lt;selection id="240" /&gt; は、再通知の間隔が 4 時間であることを示します。
        -   &lt;input&gt; の defaultInput の値が、&lt;selection&gt; 子要素の id のいずれかと一致することを確認します。
        -   &lt;selection&gt; の値は、最大で 5 つまで指定できます。