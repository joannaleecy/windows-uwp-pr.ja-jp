---
author: jnHs
Description: Product declarations help make sure your app is displayed appropriately in the Microsoft Store and offered to the right set of customers.
title: 製品の宣言
ms.assetid: 3AF618F3-2B47-4A57-B7E8-1DF979D4A82C
ms.author: wdg-dev-content
ms.date: 12/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 959e056d5edf5e1fe7a1c51a2f855c9e11512cb0
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2862262"
---
# <a name="product-declarations"></a>製品の宣言

[送信プロセス](app-submissions.md)の[プロパティ](enter-app-properties.md)] ページの**製品の宣言**セクションを使うアプリが適切に表示され、顧客、およびそのアプリを使用する方法を理解するのに役立ちますの右側に提供されているかどうかを確認できます。

次のセクションでは、いくつかの宣言と各宣言は、アプリに適用するかどうかを決定するときに考慮すべきことについて説明します。 これらの宣言の 2 つがオンになっている既定 (以下のとおりです。) に注意してください。によっては、製品のカテゴリでは、その他の宣言を表示することも可能性があります。 すべての宣言を確認し、送信物を正確に反映していることを確認することを確認します。

## <a name="this-app-allows-users-to-make-purchases-but-does-not-use-the-microsoft-store-commerce-system"></a>このアプリは、により、ユーザーは、購入を行うには、Microsoft ストア コマース システムを使用しません。

ほぼすべての送信、このチェック ボックスをオフのままにする必要がある、アプリを購入する営業案件を提供するため、または消費またはアプリ内で使用できるアイテムは、作成して、アドオンを送信する Microsoft ストア アプリの購入 API を使用する必要があります。 [アプリの開発契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)あたりアプリが作成され、2015 年 6 月 29 日より前に送信された続けることが購入機能は、[に準拠している場合に限り、Microsoft のコマース エンジンを使わずにアプリの購入機能を提供します。Microsoft ストア ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies#108-financial-transactions)します。 アプリがこれに該当する場合、このチェック ボックスをオンにする必要があります。 それ以外の場合は、オフのままにします。

## <a name="this-app-has-been-tested-to-meet-accessibility-guidelines"></a>このアプリは、アクセシビリティ ガイドラインを満していることがテストされました。

このボックスをオンにすると、ストアでアクセシビリティ対応アプリを明確に探しているユーザーが、そのアプリを見つけることができるようになります。

このチェック ボックスは、次の項目のすべてを行った場合のみオンにしてください。

-   すべての UI 要素に、対応するアクセシビリティ情報 (アクセシビリティに対応した名前など) を設定した。
-   タブ オーダー、キーボードのアクティブ化、方向キーによるナビゲーション、ショートカットを考慮して、キーボードのナビゲーションと操作を実装した。
-   4.5:1 のテキスト コントラスト比を守っているなど、視覚表現がアクセシビリティに対応していて、ユーザーに情報を伝えるときに色だけに依存していない。
-   Inspect、AccChecker などのアクセシビリティ テスト ツールを使ってアプリを検証し、ツールによって検出された優先度の高いすべてのエラーを解決した。
-   アプリの主要なシナリオの全体にわたって、ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト、高 DPI などの機能やツールの動作を確認した。

アプリをアクセシビリティ対応として宣言すると、障碍を持つユーザーも含めてすべてのユーザーがアプリにアクセスできることに同意したことになります。 たとえば、アプリをハイ コントラスト モードやスクリーン リーダーでテストしたことを意味します。 ユーザー インターフェイスがキーボード、拡大鏡、その他のアクセシビリティ ツールで適切に機能することも検証しておく必要があります。

詳しくは、[アクセシビリティ](../design/accessibility/accessibility.md)、[アクセシビリティのテスト](../design/accessibility/accessibility-testing.md)、および[ストアでのアクセシビリティ](../design/accessibility/accessibility-in-the-store.md)を参照してください。

> [!IMPORTANT]
> 特にエンジニア リングし、その目的のテストにアクセスできるアプリ] ボックスの一覧をしないでください。 アプリをアクセシビリティ対応と宣言しているのにアクセシビリティを実際にサポートしていないと、コミュニティから否定的なフィードバックを受けるおそれがあります。

## <a name="customers-can-install-this-app-to-alternate-drives-or-removable-storage"></a>ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。

既定に外付けドライブなどのメディア SD カードなど、またはシステム以外のボリュームにドライブ外部またはリムーバブルの記憶域にアプリをインストールできるようにするのには、このボックスをオンします。 (For Windows Phone 8.1 では、この以前に指定された StoreManifest.xml を介して。)

アプリが、リムーバブル記憶域の別のドライブにインストールされていることを防止できますが、デバイスの内部ハード ドライブにインストールする場合は、このチェック ボックスをオフにします。

ノートをできるように、アプリ*のみ*にインストールを制限するためのオプションはありませんが、リムーバブル記憶域メディアにインストールされます。


## <a name="windows-can-include-this-apps-data-in-automatic-backups-to-onedrive"></a>Windows では、このアプリのデータを OneDrive への自動バックアップに含めることができます。

このボックスは、Windows が OneDrive に自動バックアップすることをユーザーが選んだ場合にアプリのデータを含めることができるように、既定でオンになっています。 (For Windows Phone 8.1 では、この以前に指定された StoreManifest.xml を介して。)

アプリのデータが自動バックアップに含まれないようにする場合は、このボックスをオフにします。


## <a name="this-app-sends-kinect-data-to-external-services"></a>このアプリは、外部サービスを Kinect データを送信します。 

アプリが Kinect データを使用して、任意の外部サービスに送信する場合は、このボックスをオンする必要があります。



 

 

 




