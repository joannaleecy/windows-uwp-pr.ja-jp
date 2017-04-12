---
description: "特定の種類の入力とデバイスに対応するように UWP アプリをカスタマイズします。 タッチと音声コマンドを利用します。 Xbox、電話、テレビでアプリを実行します。"
title: "UWP アプリの入力とデバイスの設計 - Windows アプリ開発"
author: kbridge
keywords: "デバイスの基本情報, アプリの入力, UWP アプリケーションのカスタマイズ"
label: Input & devices
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: b771d452-c3ac-4d97-8482-eaf81bf34306
ms.openlocfilehash: 6bcc81d80bb3e2167b6d6e5ee078279bd830f04c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="inputs-and-devices"></a>入力とデバイス

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

UWP アプリは、さまざまな入力を自動的に処理し、さまざまなデバイスで実行できます。タッチ入力を有効にする場合や、アプリを電話で実行できるようにする場合に、追加の作業は何も必要ありません。

ただし、特定の種類の入力やデバイス用にアプリを最適化することが必要になる場合もあります。 たとえば、ペイント アプリを作成している場合は、必要に応じてペン入力の処理方法をカスタマイズできます。

このセクションの設計とコーディングの手順は、特定の種類の入力とデバイス用に UWP アプリをカスタマイズする場合に役立ちます。

## <a name="input-primer"></a>入力の基本情報

特定のフォーム ファクターと組み合わせて使うときの各入力デバイスの種類とその動作、機能、制限事項について詳しくは、「<b>[操作の基本情報](input-primer.md)</b>」をご覧ください。

## <a name="inputs-and-interactions"></a>入力と対話式操作

<div class="side-by-side">
<div class="side-by-side-content">
<p>
<b>[Surface Dial](windows-wheel-interactions.md)</b><br/>
このまったく新しいカテゴリの入力デバイスを Windows アプリに統合する方法について説明します。</br>
このデバイスは、セカンダリのマルチ モーダル入力デバイスであり、プライマリ デバイスからの入力を補完または変更するためのものです。
</p>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[Cortana](cortana-interactions.md)</b><br/>
音声コマンドを使って Cortana の基本機能を拡張し、外部アプリケーションで単一の操作を起動して実行します。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[音声認識](speech-interactions.md)</b><br/>
音声認識や音声合成 (TTS: text-to-speech) をアプリのユーザー エクスペリエンスに直接統合します。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[ペン](pen-and-stylus-interactions.md)</b><br/>
ペン入力向けに UWP アプリを最適化して、標準のポインター デバイス機能と最適な Windows Ink エクスペリエンスをユーザーに提供します。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[キーボード](keyboard-interactions.md)</b><br/>
キーボード入力は、アプリのユーザー操作エクスペリエンスの中でも重要な部分です。 キーボードは、特定の障碍のあるユーザーや、キーボードを使った方がアプリを効率よく操作できると考えるユーザーにとって欠かせません。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[タッチ](touch-interactions.md)</b><br/>
UWP にはタッチ入力を処理するためのさまざまなメカニズムがあり、ユーザーが安心して操作できるイマーシブ エクスペリエンスを実現できます。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[タッチパッド](touchpad-interactions.md)</b><br/>
タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。 この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリのより小さいターゲットにも適しています。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[マウス](mouse-interactions.md)</b><br/>
マウス入力は、ポイントとクリックの正確さが求められるユーザー操作に最適です。 この固有の正確さは、タッチの本来の不正確さに合わせて最適化されている Windows の UI でも当然サポートされています。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[ゲームパッドとリモート制御](gamepad-and-remote-interactions.md)</b><br/>
UWP アプリでは、ゲームパッドとリモコンの入力がサポートされます。 ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<p>
<b>[複数の入力](multiple-input-design-guidelines.md)</b><br/>
できるだけ多くのユーザーやデバイスに対応するため、可能な限り多くの入力の種類 (ジェスチャ、音声、タッチ、タッチパッド、マウス、キーボード) で作業できるようにアプリを設計することをお勧めします。 これにより、柔軟性、操作性、アクセシビリティが最大限に高まります。
</p>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[入力デバイスの識別](identify-input-devices.md)</b><br/>
ユニバーサル Windows プラットフォーム (UWP) デバイスに接続されている入力デバイスを識別し、その機能と属性を識別します。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[ポインター入力の処理](handle-pointer-input.md)</b><br/>
ユニバーサル Windows プラットフォーム (UWP) アプリで、タッチ、マウス、ペン/スタイラス、タッチパッドなどのポインティング デバイスからの入力データを受信、処理、管理します。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p><b>[カスタム テキスト入力](custom-text-input.md)</b><br/>
Windows.UI.Text.Core 名前空間の基本的なテキスト API によって、UWP アプリは、Windows デバイスでサポートされている任意のテキスト サービスからテキスト入力を受け取ることができます。 これにより、アプリは、キーボード、音声、ペンなどのすべての入力の種類から、テキストを任意の言語で受け取ることができます。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[テキストと画像の選択](guidelines-for-textselection.md)</b><br/>
この記事では、テキスト、画像、コントロールの選択と操作について説明し、アプリでこれらのメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<p>
<b>[パン](guidelines-for-panning.md)</b><br/>
パンとスクロールにより、ユーザーは単一ビュー内で移動し、ビューポートに収まらないビューのコンテンツを表示できます。
</p>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p>
<b>[光学式ズームとサイズ変更](guidelines-for-optical-zoom.md)</b><br/>
この記事では、Windows のズームとサイズ変更の要素について説明し、アプリでこのような対話式操作のメカニズムを使うためのユーザー エクスペリエンスのガイドラインを示します。
</p>
</div>
<div class="side-by-side-content-right">
<p>
<b>[回転](guidelines-for-rotation.md)</b><br/>
この記事では、新しい Windows UI の回転について説明し、UWP アプリでこの新しい対話式操作のメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。
</p>
</div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
<div class="side-by-side-content-left">
<p><b>[ターゲット設定](guidelines-for-targeting.md)</b><br/>
Windows のタッチ補正では、タッチ デジタイザーで検出されるそれぞれの指が接触する領域全体を使います。 デジタイザーから伝えられる、より広く複雑なこの入力データのセットを使うと、ユーザーが意図した (または意図した可能性が高い) ターゲットをより正確に特定できます。
</p>
</div>
<div class="side-by-side-content-right">
<p><b>[視覚的なフィードバック](guidelines-for-visualfeedback.md)</b><br/>
視覚的なフィードバックは、対話式操作が検出、解釈、処理されていることをユーザーに示すために使います。 視覚的なフィードバックは、対話式操作を促進することによってユーザーを支援します。 対話式操作の成功を示すことによって、ユーザーのコントロール感を向上させます。 また、システム状態の中継やエラーの削減も可能になります。
</p>
</div>
</div>
</div>

## <a name="devices"></a>デバイス

UWP アプリをサポートするデバイスを理解することは、各フォーム ファクター向けの最適なユーザー エクスペリエンスを提供するために役立ちます。 特定のデバイス向けのアプリを設計するときは、アプリがデバイスにどのように表示されるか、そのデバイスでアプリがいつどこでどのように使われるか、ユーザーがそのデバイスをどのように操作するかについて、特に考慮する必要があります。

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[デバイスの基本情報](device-primer.md)</b><br/>UWP アプリをサポートするデバイスを理解することは、各フォーム ファクター向けの最適なユーザー エクスペリエンスを提供するために役立ちます。
</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[Xbox およびテレビ向け設計](designing-for-tv.md)</b><br/>Xbox One とテレビ画面で見栄えよく表示され、適切に機能するようにユニバーサル Windows プラットフォーム (UWP) アプリの設計を行います。
</p>
  </div>
</div>
</div>
