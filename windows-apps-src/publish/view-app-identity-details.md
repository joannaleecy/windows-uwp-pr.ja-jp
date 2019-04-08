---
Description: Microsoft Store、により、アプリに割り当てられた一意の id に関連する詳細を表示し、アプリのストアの一覧へのリンクを取得します。
title: アプリ ID の詳細の表示
ms.assetid: 86F05A79-EFBC-4705-9A71-3A056323AC65
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 7e108d603a623e3b9e41d7ced3c0fafc80f006b8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610817"
---
# <a name="view-app-identity-details"></a>アプリ ID の詳細の表示


は、Microsoft Store によって、アプリに割り当てられた一意の id に関連する詳細を表示するその**アプリ id**ページ。 取得できます、アプリのストアのリンクをこのページに一覧表示します。

アプリ ID の情報を探すには、アプリのいずれかに移動し、左側のナビゲーション メニューで **[アプリ管理]** を展開します。 **[アプリ ID]** を選ぶと、アプリ ID の詳細が表示されます。


## <a name="values-to-include-in-your-app-package-manifest"></a>アプリのパッケージ マニフェストに追加する値

パッケージ マニフェストでは、次の値を含める必要があります。 [パッケージのビルドに Microsoft Visual Studio を使っていて](../packaging/packaging-uwp-apps.md)、開発者アカウントに関連付けられている同じ Microsoft アカウントでサインインしている場合は、これらの値は自動的に追加されています。 パッケージを手動でビルドしている場合は、以下の項目を追加する必要があります。

-   **パッケージ/ユーザー/名前**
-   **パッケージ/ユーザー/パブリッシャー**
-   **パッケージ/プロパティ/PublisherDisplayName**

詳しくは、[パッケージ マニフェスト スキーマのリファレンス](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/schema-root)の「[**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity)」をご覧ください。

また、アプリ ID を宣言するこれらの値により、パッケージが属している "パッケージ ファミリ" が確定されます。 個々のパッケージには、アーキテクチャやバージョンなど、その他の詳細が含まれています。


## <a name="additional-values-for-package-family"></a>パッケージファミリのその他の値

次の値は、アプリのパッケージ ファミリを参照するが、マニフェストには含まれていないその他の値です。

-   **パッケージ ファミリ名 (PFN)**:この値は、特定の Windows Api で使用されます。
-   **パッケージ SID**:この値をアプリに WNS 通知を送信する必要があります。 詳しくは、「[Windows プッシュ通知サービスの概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。


## <a name="link-to-your-apps-listing"></a>アプリの登録情報へのリンク

アプリのページへの直接リンクを共有することで、ユーザーはストアでアプリを見つけやすくなります。 このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。 ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。

アプリの**ストア ID** も、このセクションに表示されます。 このストア ID を使って、[ストア バッジを生成](https://go.microsoft.com/fwlink/p/?LinkId=534236)したり、その他の方法でアプリを識別したりすることができます。

**ストア プロトコルのリンク**を使うと、アプリ内からリンクする場合などに、ブラウザーを開かずにストア内のアプリに直接リンクできます。 詳しくは、「[アプリへのリンク](link-to-your-app.md)」をご覧ください。



 

 




