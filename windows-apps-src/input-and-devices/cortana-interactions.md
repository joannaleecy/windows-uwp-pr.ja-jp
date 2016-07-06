---
author: Karl-Bridge-Microsoft
Description: "音声コマンドが Cortana の基本機能を拡張し、外部アプリケーションで単一の操作を起動して実行します。"
title: "Cortana の操作"
ms.assetid: 4C11A7CF-DA26-4CA1-A9B9-FE52670101F5
label: Cortana
template: detail.hbs
ms.sourcegitcommit: a2ec5e64b91c9d0e401c48902a18e5496fc987ab
ms.openlocfilehash: d23416ad3344a39c09078b6ba3acc38fa3ba65a0

---

# UWP アプリでの Cortana の操作




音声コマンドが **Cortana** の基本機能を拡張し、外部アプリケーションで単一の操作を起動して実行します。 


**他の音声機能コンポーネント**

-   音声認識や音声合成 (TTS: text-to-speech) をアプリに直接統合する場合は、「[音声認識の設計ガイドライン](speech-interactions.md)」をご覧ください。

> **注**  
> 音声コマンドは、具体的な目的を持って 1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。

> VCD ファイルでは、1 つ以上の音声コマンドが定義されており、各音声コマンドは固有の目的を持っています。

> 音声コマンド定義にはさまざまなものがあり、定義が複雑になる場合があります。 音声コマンド定義では、制限された 1 つの言葉の発声から、より柔軟性の高い自然言語の発声のコレクションまで、あらゆる発声をサポートできます。ただし、これらの発声はすべて、同じ目的を示している必要があります。


ターゲット アプリは、操作の複雑さに応じて、フォアグラウンドで起動したり (アプリがフォーカスを取得し、**Cortana** は消えます)、バックグラウンドでアクティブ化されたりします (**Cortana** がフォーカスを維持しますが、アプリからの結果を表示します)。 たとえば、追加のコンテキストやユーザー入力が必要な音声コマンドはフォアグラウンド アプリで処理するのが最適ですが、基本的なコマンドは **Cortana** でバックグラウンド アプリを通じて処理できます。

 

アプリの基本的な機能を統合し、ユーザーが直接アプリを開かずにほとんどのタスクを実行できる中心的エントリ ポイントを提供することで、**Cortana** はアプリとユーザーの仲介役となります。 アプリの機能にこのショートカットを提供し、アプリを切り替える必要性を減らすことによって、ユーザーの時間と労力を大幅に節約できます。


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">記事</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[設計ガイドライン](cortana-design-guidelines.md)</p></td>
<td align="left"><p>このガイドラインおよび推奨事項では、アプリがユーザーとやり取りしてタスクを実行し、どのように行われているかがすべて明らかになるように **Cortana** を有効に活用する方法について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[音声コマンドを使ったフォアグラウンド アプリの起動](launch-a-foreground-app-with-voice-commands-in-cortana.md)</p></td>
<td align="left"><p><strong>Cortana</strong> 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、<strong>Cortana</strong> を通じて音声コマンドを使ってフォアグラウンド アプリを起動し、アプリ内で実行するアクションやコマンドを指定することもできます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[音声コマンド定義 (VCD) の語句一覧の動的変更](dynamically-modify-voice-command-definition--vcd--phrase-lists.md)</p></td>
<td align="left"><p>実行時に音声認識結果を使って、VCD ファイルのサポート対象語句の一覧 (<strong>PhraseList</strong> 要素) にアクセスして更新する方法を説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[音声コマンドを使ったバックグラウンド アプリの起動](launch-a-background-app-with-voice-commands-in-cortana.md)</p></td>
<td align="left"><p><strong>Cortana</strong> 内で音声コマンドを使ってシステム機能にアクセスするだけでなく、アプリ内で実行するアクションやコマンドを指定する音声コマンドを使うバックグラウンド アプリの機能によって <strong>Cortana</strong> を拡張することもできます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[バックグラウンド アプリの操作](interact-with-a-background-app-in-cortana.md)</p></td>
<td align="left"><p>音声コマンドの実行時に <strong>Cortana</strong> の音声とキャンバスを通じてバックグラウンド アプリを操作する方法について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[バックグラウンド アプリへのディープ リンク](deep-link-into-your-app-from-cortana.md)</p></td>
<td align="left"><p><strong>Cortana</strong> でバックグラウンド アプリのサービスからのディープ リンクを提供し、フォアグラウンドに特定の状態やコンテキストでアプリを起動します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[自然言語音声コマンドのサポート](support-natural-language-voice-commands-in-cortana.md)</p></td>
<td align="left"><p>ユーザーがコマンド内の任意の場所にアプリ名を含めることができるように、柔軟で自然な音声コマンドで <strong>Cortana</strong> を拡張する方法について説明します。</p></td>
</tr>
</tbody>
</table>

 

## 関連記事


* [**VCD 要素および属性 v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**デザイナー向け**
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
* [Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)

**サンプル**
* [Cortana 音声コマンドのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 







<!--HONumber=Jun16_HO5-->


