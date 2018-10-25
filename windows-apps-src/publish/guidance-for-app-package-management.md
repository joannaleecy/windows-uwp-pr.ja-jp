---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a43f3b4c5684d93ea6986c4d1f1e4dae46c1a959
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5521163"
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

一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。 ただし、アプリには、現在の OS バージョンをターゲットとするパッケージが含まれていない場合、ユーザーはそれらのパッケージを取得限られます。

たとえば、windows 10 デバイスでは、以前サポートされている OS バージョンをすべて (ごとにデバイス ファミリ) を実行できます。 Windows 10 デスクトップ デバイスで Windows8.1 または Windows8; 用に構築されたアプリを実行できます。Windows 10 モバイル デバイスで Windows Phone 8.1、WindowsPhone8、およびも Windows Phone 用に構築されたアプリを実行できる 7.x します。 

以下の例では、複数の OS バージョンをターゲットとするパッケージなど、アプリのさまざまなシナリオについて説明します。ただし、パッケージ特有の制約によって、ここに示したすべての OS バージョンとデバイスの種類で実行できないことがあります (デバイスでパッケージのアーキテクチャが特定のものである必要がある場合など)。 

### <a name="example-app-1"></a>アプリ例 1

| パッケージの対象オペレーティング システム | このパッケージを取得するオペレーティング システム |
|-------------------------------------|----------------------------------------------|
| Windows8.1                         | Windows 10 デスクトップ デバイスを Windows8.1      |
| Windows Phone 8.1                   | Windows 10 モバイル デバイス、Windows Phone 8.1 |
| WindowsPhone8                     | WindowsPhone8                              |
| Windows Phone 7.1                   | Windows Phone 7.x                            |

アプリ例 1、アプリはまだありませんは具体的には、windows 10 デバイス用に構築されたユニバーサル Windows プラットフォーム (UWP) パッケージが windows 10 のユーザー、アプリを入手できます。 ユーザーはデバイスの種類で使用できる最適なパッケージを取得します。

### <a name="example-app-2"></a>アプリ例 2

| パッケージの対象オペレーティング システム  | このパッケージを取得するオペレーティング システム |
|--------------------------------------|----------------------------------------------|
| Windows 10 (ユニバーサル デバイス ファミリ) | Windows 10 (すべてのデバイス ファミリ)             |
| Windows8.1                          | Windows8.1                                  |
| Windows Phone 8.1                    | Windows Phone 8.1                            |
| Windows Phone 7.1                    | Windows Phone 7.x、WindowsPhone8           |

アプリ例 2、Windows8 で実行できるパッケージはありません。 他のすべての OS バージョンを実行しているユーザーは、アプリを入手できます。 Windows 10 でのすべてのお客様は、同じパッケージを取得します。

### <a name="example-app-3"></a>アプリ例 3

| パッケージの対象オペレーティング システム | このパッケージを取得するオペレーティング システム                  |
|-------------------------------------|---------------------------------------------------------------|
| Windows 10 (デスクトップ デバイス ファミリ)  | Windows 10 デスクトップ デバイス                                    |
| WindowsPhone8                     | Windows 10 モバイル デバイス、WindowsPhone8、Windows Phone 8.1 |

アプリ例 3 で、モバイル デバイス ファミリを対象にした UWP パッケージがないため windows 10 モバイル デバイスのユーザーは、パッケージを取得 WindowsPhone8 します。 このアプリは、後で、モバイル デバイス ファミリ (またはユニバーサル デバイス ファミリ) を対象にしたパッケージを追加する場合、パッケージが提供されます WindowsPhone8 パッケージではなく、windows 10 モバイル デバイスのユーザーにします。

また、このアプリ例には Windows Phone 7.x で実行可能なパッケージが含まれていない点にも注目してください。

### <a name="example-app-4"></a>アプリ例 4

| パッケージの対象オペレーティング システム  | このパッケージを取得するオペレーティング システム |
|--------------------------------------|----------------------------------------------|
| Windows 10 (ユニバーサル デバイス ファミリ) | Windows 10 (すべてのデバイス ファミリ)             |

アプリ例 4 のでは、windows 10 を実行している任意のデバイスは、アプリを入手できますが、それ以前の OS バージョンのユーザーに利用できなくなります。 UWP パッケージがユニバーサル デバイス ファミリを対象としているために、すべての windows 10 デバイス (ごとに、[デバイス ファミリの利用可否選択](device-family-availability.md)) を利用可能ななります。


## <a name="removing-an-app-from-the-store"></a>アプリをストアから削除する

ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。 これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。 アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。

> [!IMPORTANT]
> このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。 

このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。 ただし、新しい申請を作成する必要はありません。

アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。

アプリを入手不可にした後も、ダッシュボードには引き続き表示されます。 アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。 確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。

> [!NOTE]
> アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。 たとえば、Windows Phone 8.1 と windows 10 では、パッケージを持っていた WindowsPhone8.1 で新しいユーザーへのアプリの提供を継続したくない場合は、すべて WindowsPhone8.1 パッケージの申請から削除します。 更新プログラムが公開されると、WindowsPhone8.1 で新しいユーザーできなくなりますを既に持っているユーザーは、それを使い続けることができますが、アプリを入手する)。 ただし、アプリも新しいユーザーに windows 10 で利用できます。


## <a name="removing-packages-for-a-previously-supported-device-family"></a>これまでサポートされていたデバイス ファミリ用のパッケージを削除する

場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますことを確認するこれによって、意図を **[パッケージ**] ページで、変更を保存する前にすべてのパッケージを削除します。

すべてのアプリが以前にサポートされているデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。 そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。

特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a>Windows 10 の以前に公開されたアプリ パッケージに追加します。

For Windows パッケージしか含まれているストアにアプリがあるかどうかは 8.x や Windows Phone 8.x をし、windows 10 向けアプリの更新プログラム、新しい申請を作成および[パッケージ](upload-app-packages.md)手順中に、UWP の .msixupload または .appxupload パッケージを追加します。 アプリが認定プロセスと、UWP パッケージもできるようになります windows 10 のユーザーが新規取得用です。

> [!NOTE]
> Windows 10 のユーザーが UWP パッケージを取得した後は、パッケージを使用して、以前の OS バージョン用にそのユーザーをロールバックことはできません。 

Windows 10 パッケージのバージョン番号を使用した Windows8 や Windows8.1、Windows Phone 8.1 のパッケージよりもする必要があることに注意します。 詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。

Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。
