---
author: mcleblanc
description: "現在の Mac コンピューターを使用して、Windows 用アプリを開発します。"
title: "Windows 10 を使用するための Mac のセットアップ"
ms.assetid: 6D520610-5DE0-476E-A792-AA57E002D309
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: c73a1d1695e3b8a2eee8f073a5d25586a24a9d24
ms.lasthandoff: 02/07/2017

---

# <a name="setting-up-your-mac-with-windows-10"></a>Windows 10 を使用するための Mac のセットアップ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

現在の Mac コンピューターを使用して、Windows 用アプリを開発します。

## <a name="run-windows-on-your-mac-and-use-visual-studio"></a>Mac で Windows を実行し、Visual Studio を使う

ユニバーサル Windows アプリの開発を始める準備は整っているのに、PC が手元にない、そういう方でも 大丈夫です。Mac を使うことができます。 Apple Boot Camp や Oracle VirtualBox、VMware Fusion、Parallels Desktop のような人気のサードパーティ ソリューションを使って、Windows 10 と Microsoft Visual Studio を Apple コンピューターにインストールできます。

**注**  ディスクまたは USB フラッシュ ドライブ上の Windows 10 の起動可能なイメージが必要です。 MSDN サブスクライバーである場合は、MSDN サブスクライバー ダウンロード センターからインストール イメージをダウンロードできます。 サブスクライバーでない場合は、[Windows ストアに関するページ](http://apps.microsoft.com/windows/app)からインストーラーを購入できます。 [この場所](http://go.microsoft.com/fwlink/?LinkId=623906)からダウンロードすることもできます。これは、Windows を既に実行中でありアップグレードする場合に便利です。

Windows を実行したら、「[Windows 10 用のダウンロードとツール](https://developer.microsoft.com/en-us/windows/downloads)」から Visual Studio 2015 をインストールし、アプリの作成を開始できます。

**注**  Visual Studio のデバイスのエミュレーターを使用する予定の場合、64 ビット (x64) バージョンの Windows 10 Pro 以上をインストールする **必要があります**。 ただし、以前の Mac では 64 ビット版の Windows を実行できない場合があります。 この [Apple サポート ページ](http://go.microsoft.com/fwlink/p/?LinkID=397959)で、お使いのハードウェアに互換性があるかどうかを確認してください。

## <a name="apple-boot-camp"></a>Apple Boot Camp

Boot Camp アシスタント アプリは最近のすべての Mac にプリインストールされていて、起動すると Windows 10 をインストールするプロセスが案内されます。 必要なのもは、上記のソースからダウンロードした Windows のコピーと 30 Gb 以上の空きディスク領域だけです。 インストールしたら、Mac OSX と Windows 10 のどちらを起動するかを選択できます。 詳しくは、Apple の [Boot Camp に関するページ](http://go.microsoft.com/fwlink/?LinkId=623912)をご覧ください。

## <a name="parallels-desktop"></a>Parallels Desktop

Parallels Desktop 11 を使用すると、Visual Studio と Cortana など、Windows アプリと既存の Mac アプリケーションを並べて実行できます。 強化されたデバッグや Docker と Jenkins のサポートなど、開発者向けの追加機能を含むプロ バージョンを利用できます。 詳しい情報、および無料試用版については、[Parallels Desktop に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=281827)をご覧ください。

## <a name="vmware-fusion"></a>VMWare Fusion

VMWare の Fusion 8 を使うと、Mac デスクトップで Visual Studio を実行できます。 vSphere サポートなど、いくつかの高度な機能を開発者に提供するプロ バージョンを利用できます。 詳しい情報、および無料試用版については、「[VMware Fusion](http://go.microsoft.com/fwlink/p/?LinkId=281826)」をご覧ください。

## <a name="oracle-virtualbox"></a>Oracle VirtualBox

VirtualBox は、お使いのコンピューター上で仮想マシンを実行するための無料アプリケーションであり、Mac での Windows の実行をサポートしています。 余分な機能を省いたバージョンですが、価格は魅力的です。 詳しくは、「[VirtualBox](http://go.microsoft.com/fwlink/p/?LinkId=280599)」をご覧ください。


