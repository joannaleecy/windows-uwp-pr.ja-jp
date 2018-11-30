---
Description: Introduces accessibility concepts that relate to Universal Windows Platform (UWP) apps.
ms.assetid: C89D79C2-B830-493D-B020-F3FF8EB5FFDD
title: アクセシビリティ
label: Accessibility
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2f9cdfb8a20e273d5d9e5819fc1e28aba97e4296
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8352236"
---
# <a name="accessibility"></a>ユーザー補助  



ユニバーサル Windows プラットフォーム (UWP) アプリに関連するアクセシビリティの概念について紹介します。

アクセシビリティの目的は、さまざまな環境でテクノロジを使い、幅広いニーズとエクスペリエンスに対応したユーザー インターフェイスにアクセスするユーザーにとって、アプリを使いやすいものにするエクスペリエンスを構築することです。 状況によってはアクセシビリティの要件が法律で定められているものもありますが、 できるだけ多くの人にアプリを使ってもらえるように、法的要件に関係なくアクセシビリティの問題に対処することをお勧めします。 また、アプリのアクセシビリティに関する Microsoft Store の宣言も含まれます。

> [!NOTE]
> アプリをアクセシビリティ対応として宣言する方法は、Microsoft Store にのみ適用されます。

| 記事 | 説明 |
|---------|-------------|
| [アクセシビリティの概要](accessibility-overview.md) | この記事では、UWP アプリのアクセシビリティ シナリオに関連する概念とテクノロジの概要を示します。 |
| [包括的なソフトウェアの設計](designing-inclusive-software.md) | Windows 10 用の UWP アプリでの包括性を備えた設計の進化について説明します。  アクセシビリティを考慮して、包括的なソフトウェアを設計、構築します。 |
| [包括的な Windows アプリの開発](developing-inclusive-windows-apps.md) | この記事は、アクセシビリティ対応の UWP アプリを開発するためのロードマップです。 |
| [アクセシビリティ テスト](accessibility-testing.md) | UWP アプリをアクセシビリティ対応にするためのテスト手順です。 |
| [ストア内のアクセシビリティ](accessibility-in-the-store.md) | UWP アプリがアクセシビリティ対応であることを Microsoft Store で宣言するために必要なことを説明します。 |
| [アクセシビリティのチェック リスト](accessibility-checklist.md) | UWP アプリをアクセシビリティ対応にするために役立つチェック リストを示します。 |
| [基本的なアクセシビリティ情報の開示](basic-accessibility-information.md) | 基本的なアクセシビリティ情報は、多くの場合、名前、役割、値に分類されます。 このトピックでは、支援技術が必要とする基本情報をアプリで公開するのに役立つコードについて説明します。 |
| [キーボードのアクセシビリティ](keyboard-accessibility.md) | アプリに十分なキーボード操作機能が備わっていない場合、視覚障碍や運動障碍のあるユーザーはアプリをうまく使うことができなかったり、まったく使うことができない可能性があります。 |
| [ランドマークと見出し](landmarks-and-headings.md) | ランドマークと見出しは、ユーザー インターフェイスのセクションを定義し、スクリーン リーダーなどのアクセシビリティ対応技術のユーザーの効率的なナビゲーションに役立ちます。 |
| [ハイ コントラスト テーマ](high-contrast-themes.md) | ハイ コントラスト テーマがアクティブになっているときに UWP アプリを使えることを確かめるために必要な手順について説明します。 |
| [アクセシビリティに対応したテキストの要件](accessible-text-requirements.md) | このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。 また、UWP アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。 |
| [アクセシビリティ対応にするために避ける事項](practices-to-avoid.md) | アクセシビリティ対応の UWP アプリを作成するために避ける事項の一覧を表示します。 |
| [カスタム オートメーション ピア](custom-automation-peers.md) | UI オートメーションに対するオートメーション ピアの概念について説明します。また、独自のカスタム UI クラスに対してオートメーションのサポートを提供する方法についても説明します。 |
| [コントロール パターンとインターフェイス](control-patterns-and-interfaces.md) | Microsoft UI オートメーションのコントロール パターン、それらにアクセスするためにクライアントが使うクラス、それらを実装するためにプロバイダーが使うインターフェイスを紹介します。 |

## <a name="related-topics"></a>関連トピック  
* [**Windows.UI.Xaml.Automation**](https://msdn.microsoft.com/library/windows/apps/BR209179) 
* [ナレーターの概要](https://support.microsoft.com/en-us/help/22798/windows-10-narrator-get-started)