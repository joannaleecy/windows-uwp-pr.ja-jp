---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e625522b0e9fd03fda49eb28bbedb20c00c15634
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7420760"
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

一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。 Windows 10 デバイスでは、以前サポートされている OS バージョンをすべて (ごとにデバイス ファミリ) を実行できます。 Windows 10 デスクトップ デバイスで Windows8.1 または Windows8; 用に構築されたアプリを実行できます。Windows 10 モバイル デバイスが Windows Phone 8.1、WindowsPhone8、およびも Windows Phone 用に構築されたアプリを実行できる 7.x します。 ただし、アプリには、適用可能なデバイス ファミリを対象とする UWP パッケージが含まれていない場合、Windows 10 のユーザーはそれらのパッケージを取得のみです。

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成した製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳しくは、この[ブログ記事](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/)を参照してください。


## <a name="removing-an-app-from-the-store"></a>アプリをストアから削除する

ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。 これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。 アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。

> [!IMPORTANT]
> このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。 

このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。 ただし、新しい申請を作成する必要はありません。

アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。

アプリ入手不可にした後でも表示されますがパートナー センターで。 アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。 確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。

> [!NOTE]
> アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。 たとえば、Windows Phone 8.1 と windows 10 では、パッケージを持っていた WindowsPhone8.1 の新しいユーザーに、アプリの提供を継続したくない場合は、すべて WindowsPhone8.1 パッケージの申請から削除します。 更新プログラムが公開されると、WindowsPhone8.1 で新しいユーザーできなくなりますを既に持っているユーザーは使い続けることも、アプリを入手する)。 ただし、アプリも新しいユーザーに windows 10 で利用できます。


## <a name="removing-packages-for-a-previously-supported-device-family"></a>これまでサポートされていたデバイス ファミリ用のパッケージを削除する

場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますこれが、目的**のパッケージ**] ページで、変更を保存する前に確認するためのすべてのパッケージを削除します。

すべてのアプリでサポートされていたデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。 そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。

特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a>Windows 10 のパッケージを公開したアプリに追加します。

For Windows パッケージしか含まれているストアでアプリがあるかどうかは 8.x や Windows Phone 8.x をし、windows 10 向けアプリの更新プログラム、新しい申請を作成および[パッケージ](upload-app-packages.md)手順中に、UWP .msixupload または .appxupload パッケージを追加します。 アプリが認定プロセスと、UWP パッケージもできるようになります windows 10 のユーザーが新規取得用です。

> [!NOTE]
> Windows 10 のユーザーが UWP パッケージを取得した後は、パッケージを使用して、以前の OS バージョン用にそのユーザーをロールバックことはできません。 

Windows 10 パッケージのバージョン番号を使用した Windows8 や Windows8.1、Windows Phone 8.1 のパッケージよりも高いにする必要のあるに注意してください。 詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。

Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。
