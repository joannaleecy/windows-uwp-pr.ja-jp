---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 03/28/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9b0b6315b1177138c3ede7834e2dbc792ee106dd
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3964846"
---
# <a name="guidance-for-app-package-management"></a>アプリ パッケージ管理のガイダンス

アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。

-   [OS のバージョンとパッケージの配布](#os-versions-and-package-distribution)
-   [以前に公開したアプリに Windows 10 用のパッケージを追加する](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [Windows Phone 8.1 に対するパッケージの互換性を維持する](#maintaining-package-compatibility-for-windows-phone-81)
-   [アプリをストアから削除する](#removing-an-app-from-the-store)
-   [これまでサポートされていたデバイス ファミリ用のパッケージを削除する](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a>OS のバージョンとパッケージの配布

さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。 ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。

一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。 ただし、アプリには、現在の OS バージョンをターゲットとするパッケージが含まれていない場合、ユーザーはそれらのパッケージを取得のみです。

たとえば、Windows 10 デバイスでは、(デバイス ファミリごとに) サポートされている以前の OS のバージョンをすべて実行できます。 Windows 10 のデスクトップ デバイスでは Windows 8.1 または Windows 8 用に構築されたアプリを実行でき、Windows 10 のモバイル デバイスでは Windows Phone 8.1、Windows Phone 8、さらには Windows Phone 7.x 用に構築されたアプリまで実行できます。 

以下の例では、複数の OS バージョンをターゲットとするパッケージなど、アプリのさまざまなシナリオについて説明します。ただし、パッケージ特有の制約によって、ここに示したすべての OS バージョンとデバイスの種類で実行できないことがあります (デバイスでパッケージのアーキテクチャが特定のものである必要がある場合など)。 

### <a name="example-app-1"></a>アプリ例 1

| パッケージの対象オペレーティング システム | このパッケージを取得するオペレーティング システム |
|-------------------------------------|----------------------------------------------|
| Windows 8.1                         | Windows 10 デスクトップ デバイス、Windows 8.1      |
| Windows Phone 8.1                   | Windows 10 モバイル デバイス、Windows Phone 8.1 |
| Windows Phone 8                     | Windows Phone 8                              |
| Windows Phone 7.1                   | Windows Phone 7.x                            |

アプリ例 1 のアプリには Windows 10 デバイス用に特別に構築されたユニバーサル Windows プラットフォーム (UWP) パッケージがまだありませんが、Windows 10 のユーザーはこのアプリを入手できます。 ユーザーはデバイスの種類で使用できる最適なパッケージを取得します。

### <a name="example-app-2"></a>アプリ例 2

| パッケージの対象オペレーティング システム  | このパッケージを取得するオペレーティング システム |
|--------------------------------------|----------------------------------------------|
| Windows 10 (ユニバーサル デバイス ファミリ) | Windows 10 (すべてのデバイス ファミリ)             |
| Windows 8.1                          | Windows 8.1                                  |
| Windows Phone 8.1                    | Windows Phone 8.1                            |
| Windows Phone 7.1                    | Windows Phone 7.x、Windows Phone 8           |

アプリ例 2 では、Windows 8 で実行可能なパッケージはありません。 他のすべての OS バージョンを実行しているユーザーは、アプリを入手できます。 Windows 10 でのすべてのお客様は、同じパッケージを取得します。

### <a name="example-app-3"></a>アプリ例 3

| パッケージの対象オペレーティング システム | このパッケージを取得するオペレーティング システム                  |
|-------------------------------------|---------------------------------------------------------------|
| Windows 10 (デスクトップ デバイス ファミリ)  | Windows 10 デスクトップ デバイス                                    |
| Windows Phone 8                     | Windows 10 モバイル デバイス、Windows Phone 8、Windows Phone 8.1 |

アプリ例 3 では、モバイル デバイス ファミリを対象にした UWP パッケージがないため、Windows 10 モバイル デバイスのユーザーは Windows Phone 8 パッケージを取得することになります。 モバイル デバイス ファミリ (またはユニバーサル デバイス ファミリ) を対象とするパッケージがこのアプリに後で追加される場合、Windows Phone 8 パッケージの代わりにそのパッケージが Windows 10 モバイル デバイスのユーザーに提供されます。

また、このアプリ例には Windows Phone 7.x で実行可能なパッケージが含まれていない点にも注目してください。

### <a name="example-app-4"></a>アプリ例 4

| パッケージの対象オペレーティング システム  | このパッケージを取得するオペレーティング システム |
|--------------------------------------|----------------------------------------------|
| Windows 10 (ユニバーサル デバイス ファミリ) | Windows 10 (すべてのデバイス ファミリ)             |

アプリ例 4 では、Windows 10 を実行しているデバイスではアプリを入手することができますが、以前の OS バージョンのユーザーは利用できません。 UWP パッケージがユニバーサル デバイス ファミリを対象としているために、すべての Windows 10 デバイス (ごとに、[デバイス ファミリの利用可否選択](device-family-availability.md)) を利用可能ななります。


## <a name="removing-an-app-from-the-store"></a>アプリをストアから削除する

ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。 これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。 アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。

> [!IMPORTANT]
> このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。 

このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。 ただし、新しい申請を作成する必要はありません。

アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。

アプリを入手不可にした後も、ダッシュボードには引き続き表示されます。 アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。 確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。

> [!NOTE]
> アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。 たとえば、以前に Windows Phone 8.1 と Windows 10 用のパッケージを提供していて、Windows Phone 8.1 の新しいユーザーへのアプリの提供を終了する場合は、申請から Windows Phone 8.1 用のパッケージを削除します。 更新プログラムの公開後、Windows Phone 8.1 では新しいユーザーがアプリを入手できなくなります (ただし、既に取得しているユーザーは使い続けることができます)。 ただし、Windows 10 では、引き続き新しいユーザーにアプリが提供されます。


## <a name="removing-packages-for-a-previously-supported-device-family"></a>これまでサポートされていたデバイス ファミリ用のパッケージを削除する

場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますこれが、目的**のパッケージ**] ページで、変更を保存する前に確認するためのすべてのパッケージを削除します。

すべてのアプリが以前にサポートされているデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。 そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。

特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>以前に公開したアプリに Windows 10 用のパッケージを追加する

ストアに Windows 8.x や Windows Phone 8.x を対象とするアプリがあり、Windows 10 用にアプリを更新する場合、「[パッケージ](upload-app-packages.md)」の手順で、新しい申請を作成し、UWP の .appxupload パッケージを追加します。 アプリが認定プロセスが、お客様が既にアプリを持っていて、Windows 10 では UWP パッケージをストアから更新プログラムとして取得します。 この UWP パッケージは、Windows 10 のユーザーが新規の取得として利用することもできます。

> [!NOTE]
> Windows 10 のユーザーが UWP パッケージを入手した場合、以前の OS バージョン用のパッケージを使うようにそのユーザーをロールバックすることはできません。 

Windows 10 パッケージのバージョン番号は、含めている Windows 8、Windows 8.1、Windows Phone 8.1 のパッケージ (または以前に公開したこれらの OS バージョン用のパッケージ) のバージョン番号より大きくする必要があることに注意してください。 詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。

Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。

> [!IMPORTANT]
> ユニバーサル デバイス ファミリをターゲットとするパッケージを提供する場合は、以前のオペレーティング システム (Windows Phone 8、Windows 8.1 など) で既にアプリを入手していたユーザーが Windows 10 にアップグレードすると、そのユーザーは Windows 10 パッケージを使うように更新されることに注意してください。
> 
> これが発生以降に提出の[デバイス ファミリの利用可否](device-family-availability.md)の手順で特定のデバイス ファミリを除外している場合でもセクションは、新規の利用者にのみ適用されます。 以前のすべてのユーザーに新しいユニバーサル Windows 10 パッケージを取得させることを避けたい場合は、サポート対象の特定のデバイス ファミリのみを含めるように appx マニフェストの [**TargetDeviceFamily**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily) 要素を更新する必要があります。
> 
> たとえば、する、新しい UWP アプリを取得するには、Windows 10 デスクトップ デバイスをアップグレードした、Windows 8 と Windows 8.1 のユーザーが以前には、パッケージのままに Windows 10 Mobile デバイスで行われて availabl Windows Phone ユーザーの場合e (Windows Phone 8 または Windows Phone 8.1 をターゲット設定)。 これを行う必要があります (デスクトップ デバイス ファミリ用)、 **Windows.Desktop**を含める appx マニフェスト[**TargetDeviceFamily**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily)を更新する**Windows.Universal**値 (ユニバーサル デバイス ファミリ用) としてそのままではなくMicrosoft Visual Studio で既定では、マニフェストに含まれています。 ユニバーサル デバイス ファミリまたはモバイル デバイス ファミリ (**Windows.Universal** または **Windows.Universal**) のどちらかを対象にした UWP パッケージは申請しないでください。 この場合、Windows 10 Mobile のユーザーが UWP パッケージを取得することはなくなります。


## <a name="maintaining-package-compatibility-for-windows-phone-81"></a>Windows Phone 8.1 に対するパッケージの互換性を維持する

Windows Phone 8.1 用に以前公開されていたアプリを更新する場合、パッケージの種類に関する特定の要件が適用されます。

-   アプリに公開済みの Windows Phone 8.1 パッケージがある場合、それ以降のすべての更新にも Windows Phone 8.1 パッケージを含める必要があります。
-   アプリに公開済みの Windows Phone 8.1 XAP がある場合、それ以降の更新には Windows Phone 8.1 XAP、Windows Phone 8.1 appx、Windows Phone 8.1 appxbundle のいずれかが含まれている必要があります。
-   アプリに公開済みの Windows Phone 8.1 .appx がある場合、それ以降の更新には Windows Phone 8.1 .appx または Windows Phone 8.1 .appxbundle が含まれている必要があります。 つまり、Windows Phone 8.1 XAP は認められません。 これは、Windows Phone 8.1 .appx を含む .appxupload にも適用されます。
-   アプリに公開済みの Windows Phone 8.1 .appxbundle がある場合、それ以降の更新にも Windows Phone 8.1 .appxbundle を含める必要があります。 つまり、Windows Phone 8.1 XAP または Windows Phone 8.1 .appx は認められません。 これは、Windows Phone 8.1 .appxbundle を含む .appxupload にも適用されます。

これらの規則に従わない場合、パッケージのアップロード エラーとなり申請を完了できません。