---
author: jwmsft
title: バージョン アダプティブ アプリ
description: 以前のバージョンとの互換性を保ちながら、新しい API を利用する方法について説明します
ms.author: jimwalk
ms.date: 09/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f2485eab4b192fe4a65c68d957de1ec9192f8c20
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5409517"
---
# <a name="version-adaptive-apps-use-new-apis-while-maintaining-compatibility-with-previous-versions"></a>バージョン アダプティブ アプリ: 以前のバージョンとの互換性を保ちながら新しい API を使う

Windows 10 SDK の各リリースには、ユーザーが利用したくなるような魅力的な新機能が追加されています。 ただし、すべてのユーザーがデバイスを最新バージョンの Windows 10 に同時に更新するわけではないため、できるだけ幅広いデバイスでアプリが動作するようにする必要があります。 ここでは、アプリが以前のバージョンの Windows 10 で動作するだけでなく、最新の更新プログラムがインストールされたデバイスでアプリを実行したときに新機能を利用できるように、アプリを設計する方法について説明します。

できるだけ幅広い Windows 10 デバイスをアプリでサポートするには、3 つの手順を実行する必要があります。

- まず、最新の API を対象とするように Visual Studio プロジェクトを構成します。 これは、アプリをコンパイルするときの処理に影響します。
- 次に、ランタイム チェックを実行して、アプリが実行されているデバイスに存在する API だけを呼び出すようにします。
- 最後に、最小バージョンとターゲット バージョンの Windows 10 でアプリをテストします。

## <a name="configure-your-visual-studio-project"></a>Visual Studio プロジェクトの構成

複数の Windows 10 バージョンをサポートするための最初の手順は、Visual Studio プロジェクトで、サポートされる*ターゲット*と*最小*の OS/SDK バージョンを指定することです。

- *ターゲット*: Visual Studio がアプリ コードをコンパイルし、すべてのツールを実行する際に対象となる SDK バージョン。 この SDK バージョンに含まれているすべての API とリソースは、コンパイル時にアプリ コードで使うことができます。
- *最小*: アプリを実行できる (ストアからの展開先となる) 以前の OS バージョンと、Visual Studio がアプリ マークアップ コードをコンパイルする際に対象となるバージョンをサポートする SDK バージョン。 

実行時には展開先の OS バージョンに対してアプリが実行されるため、そのバージョンで利用できないリソースを使ったり、そのような API を呼び出したりすると、アプリによって例外がスローされます。 ランタイム チェックを使って適切な API を呼び出す方法については、この記事の後半で説明します。

ターゲットと最小の設定では、OS/SDK バージョンの範囲の両端を指定します。 ただし、最小バージョンでアプリをテストした場合、最小とターゲット間のすべてのバージョンでアプリが実行されるようになります。

> [!TIP]
> Visual Studio では API の互換性についての警告は表示されません。 ご自身の責任で最小とターゲットの間にあるすべての OS バージョン (最小とターゲットのバージョンを含む) でアプリが期待どおりに実行されることをテストし、確認してください。

Visual Studio 2015 Update 2 以降で新しいプロジェクトを作成すると、アプリがサポートしているターゲット バージョンと最小バージョンを設定するように求められます。 既定では、ターゲット バージョンはインストール済みの SDK の中で最も高いバージョンで、最小バージョンはインストール済みの SDK バージョンの中で最も低いバージョンです。 コンピューターにインストールされている SDK バージョンからのみ、ターゲットと最小を選ぶことができます。 

![Visual Studio でターゲット SDK を設定する](images/vs-target-sdk-1.png)

通常、既定値のままにすることをお勧めします。 ただし、SDK のプレビュー版をインストールしていて、運用コードを記述している場合、ターゲット バージョンを Preview SDK から最新の公式の SDK バージョンに変更する必要があります。 

Visual Studio で既に作成済みのプロジェクトの最小バージョンとターゲット バージョンを変更するには、[プロジェクト]、[プロパティ]、[アプリケーション] タブ、[ターゲット] の順に移動します。

![Visual Studio でターゲット SDK を変更する](images/vs-target-sdk-2.png)

参考のために、各 SDK のビルド番号を次の表に示します。

| フレンドリ名 | バージョン | OS/SDK ビルド |
| ---- | ---- | ---- |
| RTM | 1507 | 10240 |
| 11 月の更新プログラム | 1511 | 10586 |
| Anniversary Update | 1607 | 14393 |
| Creators Update | 1703 | 15063 |
| Fall Creators Update | 1709 | 16299 |
| April 2018 Update | 1803 | 17134 |
| 年 2018年 10 月 Update | 1809 | _Insider Preview_ |

SDK のすべてのリリース版は、「[Windows SDK とエミュレーターのアーカイブ](https://developer.microsoft.com/downloads/sdk-archive)」からダウンロードできます。 最新の Windows Insider Preview SDK は、[Windows Insider](https://insider.windows.com/Home/BuildWithWindows) サイトの「開発者向け」セクションからダウンロードできます。

 Windows 10 更新プログラムについて詳しくは、 [Windows 10 のリリース情報](https://technet.microsoft.com/windows/release-info)を参照してください。 Windows 10 に関する重要な情報のライフ サイクルをサポートは、 [Windows のライフ サイクルの実際のシート](https://support.microsoft.com/help/13853/windows-lifecycle-fact-sheet)を参照してください。

## <a name="perform-api-checks"></a>API チェックの実行

バージョン アダプティブ アプリの要は、API コントラクトと [ApiInformation](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation) クラスの組み合わせにあります。 このクラスは、さまざまなデバイスと OS バージョンで、指定した API コントラクト、型、またはメンバーが存在し、安全に API を呼び出すことができるかどうかを検出します。

### <a name="api-contracts"></a>API コントラクト

デバイス ファミリ内の API のセットは、API コントラクトと呼ばれる小項目に分類されます。 API コントラクトの存在をテストするには、**ApiInformation.IsApiContractPresent** メソッドを使うことができます。 これは、すべてが API コントラクトの同じバージョンに存在する多数の API の存在をテストする場合に便利です。

```csharp
    bool isScannerDeviceContract_1_Present =
        Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent
            ("Windows.Devices.Scanners.ScannerDeviceContract", 1);
```

API コントラクトとは何でしょうか。 基本的に、API コントラクトとは機能を表します。これは、何らかの特定の機能を構成する関連 API のセットです。 たとえば、ある API コントラクトは、2 つのクラス、5 つのインターフェイス、1 つの構造体、2 つの列挙体などを含む API のセットを表している可能性があります。

論理的に関連する型は API コントラクトにグループ化され、Windows 10 以降、すべての Windows ランタイム API は何らかの API コントラクトに属しています。 API コントラクトでは、デバイス上の特定の機能や API の存在がチェックされます。デバイスの機能のチェックは、特定のデバイスまたは OS をチェックするよりも効率的に行われます。 API コントラクト内のいずれかの API を実装するプラットフォームには、同じ API コントラクト内のすべての API を実装する必要があります。 つまり、実行中の OS が特定の API コントラクトをサポートしているかどうかをテストし、サポートしていると判明した場合は、その API コントラクト内のすべての API を個別にチェックせずに呼び出すことができます。

最も大規模で最もよく使われる API コントラクトは **Windows.Foundation.UniversalApiContract** です。 これには、ユニバーサル Windows プラットフォームの API の大部分が含まれています。 「[デバイス ファミリの拡張 SDK および API コントラクト](https://docs.microsoft.com/uwp/extension-sdks/)」ドキュメントでは、利用できるさまざまな API コントラクトについて説明しています。 ほとんどの API コントラクトは、機能的に関連のある API のセットを表していることがわかります。

> [!NOTE]
> まだドキュメントが公開されていないプレビュー版の Windows ソフトウェア開発キット (SDK) をインストールしている場合は、SDK のインストール フォルダーにある "Platform.xml" ファイル ("\(Program Files (x86))\Windows Kits\10\Platforms\<platform>\<SDK version>\Platform.xml") で API コントラクトのサポートに関する情報を確認できます。

### <a name="version-adaptive-code-and-conditional-xaml"></a>バージョン アダプティブ コードと条件付き XAML

すべてのバージョンの Windows 10 では、コード内の条件式で ApiInformation クラスを使って、呼び出そうとしている API が存在するかどうかをテストできます。 IsTypePresent、IsEventPresent、IsMethodPresent、IsPropertyPresent など、このクラスのさまざまなメソッドをアダプティブ コードで使って、必要に応じた精度で API をテストできます。

詳細と例については、「**[バージョン アダプティブ コード](version-adaptive-code.md)**」をご覧ください。

アプリの最小バージョンがビルド 15063 (Creators Update) 以降の場合は、*条件付き XAML* を使って、プロパティの設定やオブジェクトのインスタンス化をマークアップで行うことができます。この場合、分離コードを使う必要はありません。 条件付き XAML は、マークアップで ApiInformation.IsApiContractPresent メソッドを使う方法を提供するものです。

詳しい説明と例については、「**[条件付き XAML](conditional-xaml.md)**」をご覧ください。

## <a name="test-your-version-adaptive-app"></a>バージョン アダプティブ アプリのテスト

バージョン アダプティブ コードや条件付き XAML を使ってバージョン アダプティブ アプリを作成する場合は、最小バージョンの Windows 10 を実行しているデバイスとターゲット バージョンを実行しているデバイスでアプリをテストする必要があります。

条件付きコードのすべてのパスを 1 台のデバイスでテストすることはできません。 すべてのコード パスを確実にテストするために、サポートされる最小の OS バージョンを実行しているリモート デバイス (または仮想マシン) でアプリを展開してテストする必要があります。
リモート デバッグについて詳しくは、「[UWP アプリの展開とデバッグ](deploying-and-debugging-uwp-apps.md)」をご覧ください。

## <a name="related-articles"></a>関連記事

- [UWP アプリとは](https://docs.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)
- [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
- [API コントラクト](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 のビデオ)