---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードを使ったアプリの作業では、Windows ストアによってアプリに割り当てられた一意の ID の詳細を表示したり、ストアでのアプリの内容へのリンクを取得したりできます。"
title: "アプリ ID の詳細の表示"
ms.assetid: 86F05A79-EFBC-4705-9A71-3A056323AC65
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b48f99d4146bfa5e4d9b2af3184e1ce3c1aea491
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="view-app-identity-details"></a>アプリ ID の詳細の表示


Windows デベロッパー センター ダッシュボードを使ったアプリの作業では、Windows ストアによってアプリに割り当てられた一意の ID の詳細を表示したり、ストアでのアプリの内容へのリンクを取得したりできます。

アプリ ID の情報を探すには、アプリのいずれかに移動し、左側のナビゲーション メニューで **[アプリ管理]** を展開します。 **[アプリ ID]** をクリックすると、アプリ ID の詳細が表示されます。

> **注**  ID の詳細に関するほとんどの情報を表示するには、アプリの[予約名](create-your-app-by-reserving-a-name.md)が必要です。

## <a name="values-to-include-in-your-appx-manifest"></a>APPX マニフェストに追加する値


次の値を APPX マニフェストに追加する必要があります。 パッケージのビルドに Microsoft Visual Studio を使っており、開発者アカウントに関連付けられている同じ Microsoft アカウントでサインインしている場合は、これらの値は自動的に追加されています。 パッケージを手動でビルドしている場合は、これらの値の追加が必要になります。

-   **パッケージ/ID/名前**
-   **パッケージ/ID/発行者**

詳しくは、[パッケージ マニフェスト スキーマのリファレンス](https://msdn.microsoft.com/library/windows/apps/br211473)の「[**Identity**](https://msdn.microsoft.com/library/windows/apps/br211441)」をご覧ください。

また、アプリ ID を宣言するこれらの値により、パッケージが属している "パッケージ ファミリ" が確定されます。 個々のパッケージには、アーキテクチャやバージョンなど、その他の詳細が含まれています。

## <a name="additional-values-for-package-family"></a>パッケージファミリのその他の値


次の値は、アプリのパッケージ ファミリを参照するが、マニフェストには含まれていないその他の値です。

-   **パッケージ ファミリ名 (PFN)**: この値は特定の Windows API で使われます。
-   **パッケージ SID**: アプリに WNS の通知を渡すには、この値が必要になります。 詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](https://msdn.microsoft.com/library/windows/apps/mt187203)」をご覧ください。

## <a name="link-to-your-apps-listing"></a>アプリの内容へのリンク

アプリのページへのリンクを共有することで、ユーザーはストアでアプリを見つけやすくなります。 このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。

> **注**  この URL は、アプリが利用可能な任意の OS バージョンで機能します。 また、Windows 8.1 以前や Windows Phone 8.1 以前向けの追加のリンクが表示されることもあります。それらは指定された OS バージョンでのみ機能します。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの内容ページが開きます。 アプリがユーザーの Windows デバイスで利用できる場合、ストア アプリも起動して、アプリの内容を表示します。

アプリの**ストア ID** も、このセクションに表示されます。 このストア ID を使って、[ストア バッジを生成](http://go.microsoft.com/fwlink/p/?LinkId=534236)したり、その他の方法でアプリを識別したりすることができます。

 

 




