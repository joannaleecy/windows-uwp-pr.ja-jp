---
Description: Describes the requirements for declaring your Universal Windows Platform (UWP) app as accessible in the Microsoft Store.
ms.assetid: 59FA3B87-75A6-4B30-BA7C-A0E769D68050
title: Microsoft Store 内のアクセシビリティ
label: Accessibility in the Store
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6a9991cd4a0a3fce630b1c7be64650c79daf74e6
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7706630"
---
# <a name="accessibility-in-the-store"></a>Microsoft Store 内のアクセシビリティ  



ユニバーサル Windows プラットフォーム (UWP) アプリがアクセシビリティ対応であると Microsoft Store で宣言するための要件について説明します。

Microsoft Store で認定を受けるためにアプリを提出している間に、アプリがアクセシビリティ対応であることを宣言することができます。 アクセシビリティ対応アプリであることを宣言すると、視覚に障碍があるユーザーのように、アクセシビリティ対応アプリに興味を持っているユーザーが簡単にそのアプリを見つけられるようになります。 ユーザーは、Microsoft Store での検索時に**アクセシビリティ対応**のフィルターを使うことで、アクセシビリティ対応アプリを見つけます。 また、アクセシビリティ対応アプリであることを宣言すると、アプリの説明に**アクセシビリティ対応**のタグが追加されます。

アプリがアクセシビリティ対応であることを宣言して、次のうちの 1 つ以上を使う主なシナリオでユーザーが必要とする [基本的なアクセシビリティ情報](basic-accessibility-information.md) が用意されていることを示します。

* キーボード。
* ハイ コントラスト テーマ。
* 可変 DPI (1 インチあたりのドット数) の設定。
* Windows アクセシビリティ機能 (ナレーター、拡大鏡、スクリーン キーボードなど) のような一般的な支援技術。

アプリをアクセシビリティ対応としてビルドし、テストした場合は、アプリをアクセシビリティ対応として宣言する必要があります。 これは、次のことが完了していることを意味します。

* 名前、役割、値などの UI 要素に関するすべてのアクセシビリティ情報を設定している。
* キーボードの完全なアクセシビリティを実装している。ユーザーは次のことができる。
    * キーボードのみを使ってアプリの主なシナリオを達成する。
    * Tab キーを使って論理的な順序で UI 要素を切り替える。
    * 方向キーを使ってコントロール内の UI 要素間を移動する。
    * キーボード ショートカットを使ってアプリの主な機能を利用する。
    * キーボードがないデバイスで、タブと矢印を同等に扱うためにナレーターのタッチ ジェスチャを使う。
* アプリの UI が視覚上のアクセシビリティに対応している。最低でも 4.5:1 のテキスト コントラスト比がある、情報を伝えるときに色だけに依存していない、など。
* [**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521)、[**UIAVerify**](https://msdn.microsoft.com/library/windows/desktop/Hh920986) などのアクセシビリティ テスト ツールを使ってアクセシビリティの実装が検証されていて、このようなツールで報告される優先度 1 のエラーをすべて解決している。
* ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト テーマ、調整された DPI 設定を使って、エンド ツー エンドでアプリの主なシナリオを検証している。

これらの手順と、その実行に役立つリソースへのリンクを確認する場合は、「[アクセシビリティのチェック リスト](accessibility-checklist.md)」をご覧ください。

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック    
* [アクセシビリティ](accessibility.md) 
