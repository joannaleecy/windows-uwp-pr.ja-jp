---
description: 現在の Mac コンピューターを使用して、Windows 用アプリを開発します。
title: Windows 10 を使用するための Mac のセットアップ
ms.assetid: 6D520610-5DE0-476E-A792-AA57E002D309
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e4f7b0469ae8c50e6da40fb248678a69a2827931
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57663827"
---
# <a name="setting-up-your-mac-with-windows-10"></a>Windows 10 を使用するための Mac のセットアップ


現在の Mac コンピューターを使用して、Windows 用アプリを開発します。

## <a name="run-windows-on-your-mac-and-use-visual-studio"></a>Mac で Windows を実行し、Visual Studio を使う

ユニバーサル Windows アプリの開発を始める準備は整っているのに、PC が手元にない、そういう方でも 大丈夫です。Mac を使うことができます。 Apple Boot Camp、Oracle VirtualBox、VMware Fusion の場合は、Parallels Desktop などの人気のあるサード パーティ製のソリューションを Apple コンピューターに Windows 10 および Microsoft Visual Studio をインストールすることができます。

**注**  ディスクまたは USB フラッシュ ドライブに Windows 10 の起動可能なイメージが必要です。 MSDN サブスクライバーである場合は、MSDN サブスクライバー ダウンロード センターからインストール イメージをダウンロードできます。 インストーラーから購入できる、サブスクライバーでない場合、 [Microsoft Store](https://apps.microsoft.com/windows/app)します。 [この場所](https://go.microsoft.com/fwlink/?LinkId=623906)からダウンロードすることもできます。これは、Windows を既に実行中でありアップグレードする場合に便利です。

Visual Studio からの最新リリースをインストールできますし、Windows 実行したら、 [Windows 10 用の開発者向けダウンロード](https://developer.microsoft.com/en-us/windows/downloads)アプリの作成を開始!

**注**  Visual Studio のデバイス エミュレーターを使用する場合を**する必要があります**64 ビット (x64) バージョンの Windows 10 Pro 以降をインストールします。 ただし、以前の Mac では 64 ビット版の Windows を実行できない場合があります。 この [Apple サポート ページ](https://go.microsoft.com/fwlink/p/?LinkID=397959)で、お使いのハードウェアに互換性があるかどうかを確認してください。

## <a name="apple-boot-camp"></a>Apple Boot Camp

Boot Camp のアシスタントのアプリがすべて最新の Mac で事前にインストールされているし、起動プロセスを説明する、Windows 10 をインストールします。 必要なのもは、上記のソースからダウンロードした Windows のコピーと 30 Gb 以上の空きディスク領域だけです。 インストールしたら、Mac OSX と Windows 10 のどちらを起動するかを選択できます。 詳しくは、Apple の [Boot Camp に関するページ](https://go.microsoft.com/fwlink/?LinkId=623912)をご覧ください。

## <a name="parallels-desktop"></a>Parallels Desktop

Parallels Desktop 11 を使用すると、Visual Studio と Cortana など、Windows アプリと既存の Mac アプリケーションを並べて実行できます。 強化されたデバッグや Docker と Jenkins のサポートなど、開発者向けの追加機能を含むプロ バージョンを利用できます。 詳しい情報、および無料試用版については、[Parallels Desktop に関するページ](https://go.microsoft.com/fwlink/p/?LinkId=281827)をご覧ください。

## <a name="vmware-fusion"></a>VMWare Fusion

VMWare の Fusion 8 を使うと、Mac デスクトップで Visual Studio を実行できます。 vSphere サポートなど、いくつかの高度な機能を開発者に提供するプロ バージョンを利用できます。 詳しい情報、および無料試用版については、「[VMware Fusion](https://go.microsoft.com/fwlink/p/?LinkId=281826)」をご覧ください。

## <a name="oracle-virtualbox"></a>Oracle VirtualBox

VirtualBox は、お使いのコンピューター上で仮想マシンを実行するための無料アプリケーションであり、Mac での Windows の実行をサポートしています。 余分な機能を省いたバージョンですが、価格は魅力的です。 詳しくは、「[VirtualBox](https://go.microsoft.com/fwlink/p/?LinkId=280599)」をご覧ください。

