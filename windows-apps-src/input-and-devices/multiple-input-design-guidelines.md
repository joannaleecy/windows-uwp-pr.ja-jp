---
author: Karl-Bridge-Microsoft
Description: 人がお互いにコミュニケーションをとる際に音声とジェスチャを組み合わせて使うように、アプリの操作では、複数の種類とモードの入力を使うと便利な場合があります。
title: 複数の入力の設計ガイドライン
ms.assetid: 03EB5388-080F-467C-B272-C92BE00F2C69
label: Multiple inputs
template: detail.hbs
---

# 複数の入力

人がお互いにコミュニケーションをとる際に音声とジェスチャを組み合わせて使うように、アプリの操作では、複数の種類とモードの入力を使うと便利な場合があります。


できるだけ多くのユーザーやデバイスに対応するため、可能な限り多くの入力の種類 (ジェスチャ、音声、タッチ、タッチパッド、マウス、キーボード) で作業できるようにアプリを設計することをお勧めします。 これにより、柔軟性、操作性、アクセシビリティが最大限に高まります。

最初に、アプリで入力を処理するさまざまなシナリオを検討します。 アプリ全体で一貫性を保つようにし、プラットフォーム コントロールでは、複数の入力の種類に対応する組み込みサポートを用意します。

-   ユーザーは、複数の入力デバイスを使ってアプリケーションを操作できますか?
-   すべての入力方法が常にサポートされていますか? 特定のコントロールでサポートされていますか? 特定の時間や環境でサポートされていますか?
-   1 つの入力方法が優先されますか?

## <span id="Single__or_exclusive_-mode_interactions_"></span><span id="single__or_exclusive_-mode_interactions_"></span><span id="SINGLE__OR_EXCLUSIVE_-MODE_INTERACTIONS_"></span>単一 (排他) モードの操作


単一モードの操作では、複数の入力の種類がサポートされますが、1 つのアクションで使用できるのは、1 つのみです。 たとえば、コマンドに音声認識、ナビゲーションにジェスチャなどです。または近接度に応じて、タッチかジェスチャを使用してテキストを入力します。

## <span id="Multimodal_interactions"></span><span id="multimodal_interactions"></span><span id="MULTIMODAL_INTERACTIONS"></span>マルチモーダル操作


マルチモーダル操作では、1 つのアクションを完了するために複数の入力方法が順番に使われます。

<span id="Speech___gesture"></span><span id="speech___gesture"></span><span id="SPEECH___GESTURE"></span>音声認識 + ジェスチャ  
ユーザーは製品をポイントし、「カートに追加」と言います。

<span id="Speech___touch"></span><span id="speech___touch"></span><span id="SPEECH___TOUCH"></span>音声認識 + タッチ  
ユーザーは長押しを使用して写真を選択し、「写真の送信」と言います。





<!--HONumber=May16_HO2-->


