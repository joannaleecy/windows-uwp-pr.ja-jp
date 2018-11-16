---
author: jnHs
Description: After your packages have been successfully uploaded, you'll see a table that indicates which packages will be offered to specific Windows 10 device families (and earlier OS versions, if applicable), in ranked order.
title: デバイス ファミリの利用可否
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, パッケージ, アップロード, デバイス ファミリの利用可否
ms.localizationpriority: medium
ms.openlocfilehash: 543b5c519e7514ccef397c2bb78eadcc5e3692f5
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6854495"
---
# <a name="device-family-availability"></a>デバイス ファミリの利用可否

**[パッケージ]** ページにパッケージが正常にアップロードされると、**[デバイス ファミリの利用可否]** セクションに、特定の Windows 10 デバイス ファミリ (および該当する場合は以前の OS バージョン) に対して提供されるパッケージをランキング順に示すテーブルが表示されます。 このセクションでは、申請するアプリを特定の Windows 10 デバイス ファミリのユーザーに提供するかどうかも選択できます。

> [!NOTE]
> パッケージをまだアップロードしていない場合、**[デバイス ファミリの利用可否]** セクションには、Windows 10 デバイス ファミリと、申請するアプリがそのデバイス ファミリのユーザーに提供されるかどうかを示すチェック ボックスが表示されます。 テーブルは、1 つ以上のパッケージをアップロードした後で表示されます。

このセクションには、将来の Windows 10 デバイス ファミリでアプリを利用できるように Microsoft に許可するかどうかを指定できるチェック ボックスも含まれています。 新しいデバイス ファミリが導入されるとより多くの潜在的なユーザーがアプリを利用できるようになるため、このチェック ボックスはオンのままにすることをお勧めします。


## <a name="choosing-which-device-families-to-support"></a>サポートするデバイス ファミリの選択

特定のデバイス ファミリを対象とするパッケージをアップロードすると、その種類のデバイスの新しいユーザーがそのパッケージを使用できるように、該当するチェック ボックスがオンになります。 たとえば、パッケージが Windows.Desktop を対象にしている場合、そのパッケージの **[Windows 10 デスクトップ]** チェック ボックスがオンになります (また、他のデバイス ファミリのチェック ボックスをオンにすることはできません)。

Windows.Universal デバイス ファミリを対象とするパッケージは、Windows 10 デバイス (Xbox One を含む) で実行できます。 既定では、これらのパッケージは Xbox を*除く*すべての種類のデバイスの新しいユーザーに対して利用可能になります。

ユーザーに申請を提供したくないデバイスの種類がある場合は、その Windows 10 デバイス ファミリのチェック ボックスをオフにすることができます。 デバイス ファミリのチェック ボックスをオフにすると、その種類のデバイスを使っている新しいユーザーはアプリを入手できません (ただし、アプリを既に持っているユーザーは引き続き使うことができ、提出された更新プログラムを入手できます)。

アプリを入手できる Windows 10 デバイスの種類を制限する特別な理由がない限り、アプリのサポート対象のチェック ボックスはすべてオンにしておくことをお勧めします。 たとえば、[Surface Hub](https://developer.microsoft.com/windows/surfacehub) や [Microsoft HoloLens](https://developer.microsoft.com/windows/mixed-reality) でアプリが優れたエクスペリエンスを提供できないとわかっている場合は、**[Windows 10 Team]** ボックスや **[Windows 10 Holographic]** ボックスをオフにします。 これにより、これらのデバイスの新しいユーザーによるアプリの入手を防ぐことができます。 これらのユーザーに提供する準備ができたら、該当するチェック ボックスをオンにして新しい申請を作成することができます。

<span id="xbox" />

Windows.Universal パッケージに対してチェック ボックスが既定でオンにならない Windows 10 デバイス ファミリは、**[Windows 10 Xbox]** のみです。 アプリがゲームではない場合 (または、アプリがゲームで [Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)が有効になっている場合) やアプリで[概念の承認](../gaming/concept-approval.md)プロセスが完了している場合で、Windows 10 SDK バージョン 14393 以降を使ってコンパイルされたニュートラルまたは x64 版の UWP パッケージが申請に含まれる場合は、**[Windows 10 Xbox]** チェック ボックスをオンにして Xbox One ユーザーにアプリを提供できます。

> [!IMPORTANT]
> アプリが Xbox デバイスで起動されるようにするには、Windows SDK バージョン 14393 以降を使ってコンパイルされたニュートラルまたは x64 パッケージを含める必要があります。 ただし、**[Windows 10 Xbox]** をオンにすると、パッケージが以前のバージョンの SDK でコンパイルされていたとしても、Xbox で使用可能な最も高いバージョンのパッケージ (つまり、Xbox またはユニバーサル デバイス ファミリを対象とするニュートラルまたは x64 パッケージ) が常に Xbox ユーザーに提供されます。 このため、Xbox で使用可能な最高バージョンのパッケージを Windows SDK バージョン 14393 以降でコンパイルすることが不可欠です。 そうでない場合、Xbox ユーザーがアプリを起動できないことを示すエラー メッセージが表示されます。 
> 
> このエラーを解決するには、次のいずれかを行います。
> - 該当するパッケージを、Windows SDK バージョン 14393 以降を使ってコンパイルした新しいものに置き換えます。
> - Xbox をサポートし、Windows SDK バージョン 14393 以降でコンパイルされたパッケージが既にある場合は、申請で最も高いバージョンのパッケージになるように、バージョン番号を大きくします。
> - **[Windows 10 Xbox]** のチェック ボックスをオフにします。
>   
> 問題がまだ解決しない場合は、サポートにお問い合わせください。

Windows 10 IoT Core の UWP アプリを申請する場合、パッケージをアップロードした後に既定の選択を変更しないでください。Windows 10 IoT 用の別個のチェック ボックスはありません。 IoT Core UWP アプリの公開について詳しくは、[Microsoft Store による IoT Core UWP アプリのサポートに関する記事](https://docs.microsoft.com/windows/iot-core/commercialize-your-device/installingandservicing)をご覧ください。

**Windows 8 または 8.1**で実行できるパッケージが以前に公開したアプリの申請に含まれるかどうかと**Windows Phone 8.x 以前**、それらのパッケージが利用できるこれらの OS バージョンのユーザーにします。 これらのユーザーへのアプリ提供を停止するには、対応するパッケージを申請から削除する必要があります。

> [!IMPORTANT]
> 申請の取得から完全に特定の Windows 10 デバイス ファミリを防ぐためには、更新をサポートするデバイス ファミリのみを対象に、マニフェストで[**TargetDeviceFamily**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily)要素 (つまり、Windows.Mobile または Windows.Desktop) ではなくまま Windows.Universal 値 (ユニバーサル デバイス ファミリ用) としてするよりも Microsoft Visual Studio が既定では、マニフェストで含まれます。

**[デバイス ファミリの利用可否]** セクションで行った選択は新しい取得のみに適用されることにも注意することが重要です。 ここでデバイス ファミリを削除した場合でも、アプリを既に持っているユーザーは使い続けることができ、提出された更新プログラムを取得します。 これは、Windows 10 にアップグレードする前にアプリを取得したユーザーにも当てはまります。 たとえば、Windows Phone 8.1 パッケージでは、公開されたアプリがあり、Windows.Universal デバイス ファミリをターゲットとする Windows 10 (UWP) パッケージを追加する場合、Windows Phone 8.1 パッケージを受け取って、Windows 10 モバイル ユーザー更新が提供される、この windows10 (UWP) パッケージをしている場合でもオフ、 **Windows 10 Mobile**のボックス。

デバイス ファミリについて詳しくは、[**デバイス ファミリの概要に関する記事**](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)をご覧ください。


## <a name="understanding-ranking"></a>ランク付けの概要

**デバイス ファミリの利用可否**] セクションでは示さだけでなく Windows 10 デバイス ファミリは、申請をダウンロードできることを示すためが利用できるさまざまなデバイス ファミリに特定のパッケージを示しています。 特定のデバイス ファミリで実行できるパッケージが複数ある場合は、パッケージのバージョン番号に基づくパッケージの提供順序がテーブルに示されます。 ストアがバージョン番号を基にしてパッケージをランク付けする方法について詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。 

たとえば、2 つのパッケージ Package_A.appxupload と Package_B.appxupload があるものとします。 特定のデバイス ファミリについて、Package_A.appxupload のランクが 1、Package_B.appxupload のランクが 2 であるとすると、そのデバイスの種類を使用するユーザーがアプリを入手するとき、ストアでは最初に Package_A.appxupload が提供されます。 ユーザーのデバイスが Package_A.appxupload を実行できない場合、ストアは Package_B.appxupload を提供します。 ユーザーのデバイスは、そのデバイス ファミリ用のパッケージのいずれかを実行できない場合 (たとえば、 **MinVersion**アプリがサポートされている場合は、顧客のデバイス上のバージョンよりも高い) し、顧客がそのデバイスにアプリをダウンロードできません。

> [!NOTE]
> (以前に公開したアプリ用) の .xap パッケージのバージョン番号は、特定の顧客に提供するには、どのパッケージを決定する場合とは見なされません。 このため、同じランクの .xap パッケージが複数ある場合、番号ではなくアスタリスクが表示され、ユーザーはどちらのパッケージでも受け取ることができます。 ユーザーの .xap パッケージを新しいパッケージに更新する場合、新しい申請では必ず以前の .xap を削除してください。

