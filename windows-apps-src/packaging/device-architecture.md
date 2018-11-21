---
author: laurenhughes
title: アプリ パッケージのアーキテクチャ
description: UWP アプリ パッケージを構築するときにどのプロセッサ アーキテクチャを使用するべきかについて説明します。
ms.author: lahugh
ms.date: 7/13/2017
ms.topic: article
keywords: Windows 10, UWP, パッケージ化, アーキテクチャ, パッケージの構成
ms.localizationpriority: medium
ms.openlocfilehash: 3e265df32a8c4168cddced905e7b0712e4601264
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7436943"
---
# <a name="app-package-architectures"></a>アプリ パッケージのアーキテクチャ

アプリ パッケージは、特定のプロセッサ アーキテクチャで実行するように構成されます。 アーキテクチャを選択することで、アプリを実行するデバイスを指定することになります。 ユニバーサル Windows プラットフォーム (UWP) アプリは、次のアーキテクチャで実行するように構成できます。
- x86
- x64
- ARM

すべてのアーキテクチャを対象にしてアプリ パッケージを構築することを**強く**お勧めします。 1 つのデバイス アーキテクチャを選択から外すと、アプリを実行できるデバイスの種類を制限することになり、アプリを使用できるユーザー数も抑制することになります。

## <a name="windows-10-devices-and-architectures"></a>Windows 10 デバイスとアーキテクチャ

> [!div class="mx-tableFixed"]
| UWP のアーキテクチャ | デスクトップ (x86)      | デスクトップ (x64)      | デスクトップ (ARM)      | モバイル             | HoloLens           | Xbox               | IoT Core (デバイス依存) | Surface Hub        |
|------------------|--------------------|--------------------|--------------------|--------------------|--------------------|--------------------|-----------------------------|--------------------|
| x86              | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :x:                | :heavy_check_mark: | :x:                | :heavy_check_mark:          | :heavy_check_mark: |
| x64              | :x:                | :heavy_check_mark: | :x:                | :x:                | :x:                | :heavy_check_mark: | :heavy_check_mark:          | :heavy_check_mark: |
| ARM              | :x:                | :x:                | :heavy_check_mark: | :heavy_check_mark: | :x:                | :x:                | :heavy_check_mark:          | :x:                |
 

これらのアーキテクチャについて詳しく説明しましょう。 

### <a name="x86"></a>x86
x86 はほぼすべてのデバイスで実行されるため、一般的に、アプリ パッケージでは x86 を選ぶのが最も安全な構成になります。 Xbox や一部の IoT Core デバイスなど、デバイスの中には x86 構成のアプリ パッケージを実行できないものもあります。 ただし、PC の場合は x86 パッケージが最も安全な選択肢であり、最も広い範囲のデバイスに展開できます。 Windows 10 デバイスの大部分は、引き続き x86 バージョンの Windows を実行しています。 

### <a name="x64"></a>x64
この構成は x86 構成に比べると使用される頻度は低くなります。 この構成は、64 ビットバージョンの Windows 10 を採用しているデスクトップ、[Xbox の UWP アプリ](https://docs.microsoft.com/windows/uwp/xbox-apps/system-resource-allocation)、および Intel Joule の Windows 10 IoT Core 向けのものであることに注意してください。

### <a name="arm"></a>ARM
ARM 版 Windows 10 構成には、デスクトップ PC、モバイル デバイス、および一部の IoT Core デバイス (Rasperry Pi 2、Raspberry Pi 3、および DragonBoard) が含まれます。 ARM 版 Windows 10 デスクトップ PC が Windows ファミリに新たに加わりました。そのため、UWP アプリ開発者がこれらの PC で最適なエクスペリエンスを実現するには ARM パッケージをストアに提出する必要があります。 

[ARM 版 Windows 10](https://channel9.msdn.com/Events/Build/2017/P4171) のデモを確認し、そのしくみを詳しく知るには、この //Build トークをご覧ください。 

IoT 固有のトピックについて詳しくは、[Visual Studio を使ったアプリの展開に関するページ](https://developer.microsoft.com/windows/iot/Docs/AppDeployment)をご覧ください。
