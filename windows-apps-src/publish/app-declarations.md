---
author: jnHs
Description: "申請プロセス中、[アプリケーションのプロパティ] ページの [App declarations] (アプリの宣言) セクションで、アプリに関する追加情報を入力できます。"
title: "アプリの宣言"
ms.assetid: 3AF618F3-2B47-4A57-B7E8-1DF979D4A82C
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: feacd96ca2fa0cc4cd3d1087a982f61bc18d4604
ms.lasthandoff: 02/07/2017

---

# <a name="app-declarations"></a>アプリの宣言

[申請プロセス](app-submissions.md)中、**[アプリケーションのプロパティ]** ページの **[App declarations]** (アプリの宣言) セクションで、アプリに関する追加情報を入力できます。 これらの宣言は、アプリが適切に表示され、適切なユーザー セットに提供されるようにするのに役立ちます。または、ユーザーにアプリの使い方を示すこともできます。

次のセクションでは、各宣言についてと、各宣言をアプリに適用するかどうかを検討する際に考慮する必要がある事柄について説明します。

## <a name="this-app-allows-users-to-make-purchases-but-does-not-use-the-windows-store-commerce-system"></a>このアプリでは、ユーザーが購入を行うことができますが、Windows ストア コマース システムを使いません。

ほとんどのアプリではこのボックスはオフのままにします。アプリ内での購入を行うことができるアプリは、一般的に Microsoft アプリ内での購入 API を使って[アドオンを作成および申請](add-on-submissions.md) するためです。 [アプリ開発者契約書](https://msdn.microsoft.com/library/windows/apps/hh694058) によると、2015 年 6 月 29 日より前に作成および申請されたアプリでは、[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_8) に準拠している限り、Microsoft のコマース エンジンを使わずにアプリ内購入機能を実装していてもかまいません。 アプリがこれに該当する場合、このチェック ボックスをオンにする必要があります。 それ以外の場合は、オフのままにします。

## <a name="this-app-has-been-tested-to-meet-accessibility-guidelines"></a>このアプリは、アクセシビリティ ガイドラインを満していることがテストされました。

このボックスをオンにすると、ストアでアクセシビリティ対応アプリを明確に探しているユーザーが、そのアプリを見つけることができるようになります。

このチェック ボックスは、次の項目のすべてを行った場合のみオンにしてください。

-   すべての UI 要素に、対応するアクセシビリティ情報 (アクセシビリティに対応した名前など) を設定した。
-   タブ オーダー、キーボードのアクティブ化、方向キーによるナビゲーション、ショートカットを考慮して、キーボードのナビゲーションと操作を実装した。
-   4.5:1 のテキスト コントラスト比を守っているなど、視覚表現がアクセシビリティに対応していて、ユーザーに情報を伝えるときに色だけに依存していない。
-   Inspect、AccChecker などのアクセシビリティ テスト ツールを使ってアプリを検証し、ツールによって検出された優先度の高いすべてのエラーを解決した。
-   アプリの主要なシナリオの全体にわたって、ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト、高 DPI などの機能やツールの動作を確認した。

アプリをアクセシビリティ対応として宣言すると、障碍を持つユーザーも含めてすべてのユーザーがアプリにアクセスできることに同意したことになります。 たとえば、アプリをハイ コントラスト モードやスクリーン リーダーでテストしたことを意味します。 ユーザー インターフェイスがキーボード、拡大鏡、その他のアクセシビリティ ツールで適切に機能することも検証しておく必要があります。

詳しくは、「[Windows ランタイム アプリのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/dn263101)」、「[アクセシビリティ テスト](https://msdn.microsoft.com/library/windows/apps/mt297664)」、「[ストア内のアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt297663)」をご覧ください。

> **重要**  アクセシビリティのための具体的な設計とテストを行っていない限り、アプリをアクセシビリティ対応として登録しないでください。 アプリをアクセシビリティ対応と宣言しているのにアクセシビリティを実際にサポートしていないと、コミュニティから否定的なフィードバックを受けるおそれがあります。

## <a name="customers-can-install-this-app-to-alternate-drives-or-removable-storage"></a>ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。

ユーザーが SD カードなどのリムーバブル記憶域メディアや、外部ドライブなどの非システム ボリューム ドライブにアプリをインストールできるように、このチェック ボックスは既定でオンになっています。

アプリが代替ドライブやリムーバブル記憶域にインストールされないようにする場合は、このチェック ボックスをオフにします。

アプリをリムーバブル記憶域メディアにのみインストールできるようにするためにインストールを制限するオプションはないことに注意してください。

> **注**  Windows Phone 8.1 では、以前は StoreManifest.xml を通じてこれを指定していました。

## <a name="windows-can-include-this-apps-data-in-automatic-backups-to-onedrive"></a>Windows では、このアプリのデータを OneDrive への自動バックアップに含めることができます。

このボックスは、Windows が OneDrive に自動バックアップすることをユーザーが選んだ場合にアプリのデータを含めることができるように、既定でオンになっています。

アプリのデータが自動バックアップに含まれないようにする場合は、このボックスをオフにします。

> **注**  Windows Phone 8.1 では、以前は StoreManifest.xml を通じてこれを指定していました。

 

 

 





