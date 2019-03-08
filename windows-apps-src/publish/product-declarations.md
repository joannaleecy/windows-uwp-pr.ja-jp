---
Description: 製品宣言では、アプリを Microsoft Store に適切に表示され、適切な一連の顧客に提供されるかどうかを確認のに役立ちます。
title: 製品の宣言
ms.assetid: 3AF618F3-2B47-4A57-B7E8-1DF979D4A82C
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1e17fbd81c84ca4ce72d36dbabf9991fe8c6d75d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611787"
---
# <a name="product-declarations"></a>製品の宣言

**製品宣言**のセクション、[プロパティ](enter-app-properties.md)のページ、[送信プロセス](app-submissions.md)することで、アプリが適切に表示され、適切なセットを提供してください。顧客、および支援のアプリを使用する方法を理解しています。

次のセクションでは、いくつかの宣言と各宣言は、アプリに適用されるかどうかを決定する際に考慮する必要がありますについて説明します。 (以下のとおりです。)、これらの宣言の 2 つは既定でオンに注意してください。製品のカテゴリに応じて追加の宣言も参照してください可能性があります。 必ずすべての宣言を確認し、お客様の提出が正確に反映されることを確認してください。

## <a name="this-app-allows-users-to-make-purchases-but-does-not-use-the-microsoft-store-commerce-system"></a>このアプリは、購入を行うことができますが、Microsoft Store コマース システムを使用できません。

ほぼすべての送信では、このボックスをオフのままにする必要があります、購入する機会を提供するアプリ以降、または使用や、アプリ内で使用できる項目は、作成して、アドオンを送信する Microsoft Store アプリ内購入 API を使用する必要があります。 ごと、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)2015 年 6 月 29 日の前に送信され、作成されたアプリを購入機能として、Microsoft のコマース エンジンを限りを使用せずにアプリ内購入機能を提供する続行でした準拠している、 [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies#108-financial-transactions)します。 アプリがこれに該当する場合、このチェック ボックスをオンにする必要があります。 それ以外の場合は、オフのままにします。

## <a name="this-app-has-been-tested-to-meet-accessibility-guidelines"></a>このアプリは、アクセシビリティ ガイドラインを満していることがテストされました。

このボックスをオンにすると、ストアでアクセシビリティ対応アプリを明確に探しているユーザーが、そのアプリを見つけることができるようになります。

このチェック ボックスは、次の項目のすべてを行った場合のみオンにしてください。

-   すべての UI 要素に、対応するアクセシビリティ情報 (アクセシビリティに対応した名前など) を設定した。
-   タブ オーダー、キーボードのアクティブ化、方向キーによるナビゲーション、ショートカットを考慮して、キーボードのナビゲーションと操作を実装した。
-   4.5:1 のテキスト コントラスト比を守っているなど、視覚表現がアクセシビリティに対応していて、ユーザーに情報を伝えるときに色だけに依存していない。
-   Inspect、AccChecker などのアクセシビリティ テスト ツールを使ってアプリを検証し、ツールによって検出された優先度の高いすべてのエラーを解決した。
-   アプリの主要なシナリオの全体にわたって、ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト、高 DPI などの機能やツールの動作を確認した。

アプリをアクセシビリティ対応として宣言すると、障碍を持つユーザーも含めてすべてのユーザーがアプリにアクセスできることに同意したことになります。 たとえば、アプリをハイ コントラスト モードやスクリーン リーダーでテストしたことを意味します。 ユーザー インターフェイスがキーボード、拡大鏡、その他のアクセシビリティ ツールで適切に機能することも検証しておく必要があります。

詳しくは、「[アクセシビリティ](../design/accessibility/accessibility.md)」、「[アクセシビリティ テスト](../design/accessibility/accessibility-testing.md)」、「[ストア内のアクセシビリティ](../design/accessibility/accessibility-in-the-store.md)」をご覧ください。

> [!IMPORTANT]
> 具体的にはエンジニア リングおよび目的のためにテストすることがない限り、アプリをアクセス可能なリストをしないでください。 アプリをアクセシビリティ対応と宣言しているのにアクセシビリティを実際にサポートしていないと、コミュニティから否定的なフィードバックを受けるおそれがあります。

## <a name="customers-can-install-this-app-to-alternate-drives-or-removable-storage"></a>ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。

既定では、により、お客様は、外部ドライブなどのメディア、SD カードなど、システム以外のボリュームにドライブまたは外部のリムーバブル ストレージにアプリをインストールするには、このボックスをオンします。

自分のデバイスの内部ハード ドライブにインストールを許可して、アプリが別のドライブまたはリムーバブル記憶域にインストールされないようにする場合は、このボックスをオフにします。 (アプリが実行できるように、インストールを制限するオプションがないことに注意してください*のみ*リムーバブル記憶域メディアにインストールされます。)。


## <a name="windows-can-include-this-apps-data-in-automatic-backups-to-onedrive"></a>Windows では、このアプリのデータを OneDrive への自動バックアップに含めることができます。

このボックスは、Windows が OneDrive に自動バックアップすることをユーザーが選んだ場合にアプリのデータを含めることができるように、既定でオンになっています。

アプリのデータが自動バックアップに含まれないようにする場合は、このボックスをオフにします。


## <a name="this-app-sends-kinect-data-to-external-services"></a>このアプリでは、Kinect データが外部サービスに送信されます。 

アプリで Kinect データを使い、そのデータを外部サービスに送信する場合は、このチェック ボックスをオンにする必要があります。



 

 

 




