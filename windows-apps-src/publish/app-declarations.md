---
author: jnHs
Description: Product declarations help make sure your app is displayed appropriately in the Microsoft Store and offered to the right set of customers.
title: 製品の宣言
ms.assetid: 3AF618F3-2B47-4A57-B7E8-1DF979D4A82C
ms.author: wdg-dev-content
ms.date: 12/05/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6c1fc444dbd106f4eeb0996903f71701a96a9735
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5564403"
---
# <a name="product-declarations"></a>製品の宣言

[申請プロセス](app-submissions.md)の [[プロパティ](enter-app-properties.md)] ページの**製品の宣言**セクションは、アプリが適切に表示され、顧客、およびアプリを使用する方法をわかりやすくの適切なセットに提供されるかどうかを確認に役立ちます。

次のセクションでは、いくつかの宣言と、各宣言をアプリに適用するかどうかを決定するときに考慮する必要があるについて説明します。 これらの宣言の 2 つが選ばれて既定 (以下のとおりです。) に注意してください。によって、製品のカテゴリでは、その他の宣言を確認することも可能性があります。 必ずすべての宣言を確認し、申請が正確に反映されることを確認してください。

## <a name="this-app-allows-users-to-make-purchases-but-does-not-use-the-microsoft-store-commerce-system"></a>このアプリは、購入を行うことができますが、Microsoft Store コマース システムを使用できません。

ほぼすべての申請に関するこのチェック ボックスをオフのままにする必要があります、アプリを購入する機会を提供するためはまたは消費またはアプリ内で使用できる項目は、作成し、アドオンを提出する Microsoft Store アプリ内購入 API を使用する必要があります。 購入機能は、[に準拠している限り、Microsoft のコマース エンジンを使用せず、アプリ内購入機能を提供する続けることが作成され、2015 年 6 月 29 日より前に提出されたアプリごと、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies#108-financial-transactions)します。 アプリがこれに該当する場合、このチェック ボックスをオンにする必要があります。 それ以外の場合は、オフのままにします。

## <a name="this-app-has-been-tested-to-meet-accessibility-guidelines"></a>このアプリは、アクセシビリティ ガイドラインを満していることがテストされました。

このボックスをオンにすると、ストアでアクセシビリティ対応アプリを明確に探しているユーザーが、そのアプリを見つけることができるようになります。

このチェック ボックスは、次の項目のすべてを行った場合のみオンにしてください。

-   すべての UI 要素に、対応するアクセシビリティ情報 (アクセシビリティに対応した名前など) を設定した。
-   タブ オーダー、キーボードのアクティブ化、方向キーによるナビゲーション、ショートカットを考慮して、キーボードのナビゲーションと操作を実装した。
-   4.5:1 のテキスト コントラスト比を守っているなど、視覚表現がアクセシビリティに対応していて、ユーザーに情報を伝えるときに色だけに依存していない。
-   Inspect、AccChecker などのアクセシビリティ テスト ツールを使ってアプリを検証し、ツールによって検出された優先度の高いすべてのエラーを解決した。
-   アプリの主要なシナリオの全体にわたって、ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト、高 DPI などの機能やツールの動作を確認した。

アプリをアクセシビリティ対応として宣言すると、障碍を持つユーザーも含めてすべてのユーザーがアプリにアクセスできることに同意したことになります。 たとえば、アプリをハイ コントラスト モードやスクリーン リーダーでテストしたことを意味します。 ユーザー インターフェイスがキーボード、拡大鏡、その他のアクセシビリティ ツールで適切に機能することも検証しておく必要があります。

詳しくは、[アクセシビリティ](../design/accessibility/accessibility.md)、[アクセシビリティのテスト](../design/accessibility/accessibility-testing.md)、および[ストア内のアクセシビリティ](../design/accessibility/accessibility-in-the-store.md)を参照してください。

> [!IMPORTANT]
> 具体的にはエンジニア リングし、その目的のためにテストがない限り、アプリがアクセシビリティ対応の一覧をしないでください。 アプリをアクセシビリティ対応と宣言しているのにアクセシビリティを実際にサポートしていないと、コミュニティから否定的なフィードバックを受けるおそれがあります。

## <a name="customers-can-install-this-app-to-alternate-drives-or-removable-storage"></a>ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。

このチェック ボックスはユーザーを外部ドライブなどのメディアが SD カードなど、または非システム ボリュームにドライブまたは外部のリムーバブル ストレージにアプリをインストールできるように、既定でオンです。 (Windows Phone 8.1 では、これが以前指定して StoreManifest.xml。)

アプリが代替ドライブやリムーバブル記憶域にインストールされていることを防ぐのみがデバイスに内部ハード ドライブへのインストールを許可する場合は、このチェック ボックスをオフにします。

注アプリ*だけ*が参照できるように、インストールを制限するオプションはありませんが、リムーバブル記憶域メディアにインストールされます。


## <a name="windows-can-include-this-apps-data-in-automatic-backups-to-onedrive"></a>Windows では、このアプリのデータを OneDrive への自動バックアップに含めることができます。

このボックスは、Windows が OneDrive に自動バックアップすることをユーザーが選んだ場合にアプリのデータを含めることができるように、既定でオンになっています。 (Windows Phone 8.1 では、これが以前指定して StoreManifest.xml。)

アプリのデータが自動バックアップに含まれないようにする場合は、このボックスをオフにします。


## <a name="this-app-sends-kinect-data-to-external-services"></a>このアプリは、外部サービスに Kinect データを送信します。 

アプリが Kinect データを使用して、でも外部サービスに送信された場合は、このボックスをオンする必要があります。



 

 

 




