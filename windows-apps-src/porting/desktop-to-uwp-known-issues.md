---
author: normesta
Description: "この記事では、Desktop to UWP Bridge に関する既知の問題について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge の既知の問題"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.openlocfilehash: 1923d7eb8d2d4956d68a10d3727251eee0398b06
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-known-issues"></a>Desktop to UWP Bridge: 既知の問題

この記事では、Desktop to UWP Bridge に関する既知の問題について説明します。

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a>エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)

Windows ストアのアプリをインストールまたは起動した後、予期せず **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)** というエラーでコンピューターの再起動が発生することがあります。

影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。

この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。 この問題が発生した場合は、コンピューターを更新してください。 ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。 システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。

更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。

開発者様には、この更新プログラムが含まれていないバージョンの Windows に Desktop Bridge アプリをインストールしないことをお勧めします。 その場合、更新プログラムをインストールしていないユーザーはアプリを利用できません。 この更新プログラムをインストールしたユーザーだけがアプリを使用できるようにするには、AppxManifest.xml ファイルを次のように変更します。

```<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.351" MaxVersionTested="10.0.14393.351"/>```

Windows 更新プログラムについて詳しくは、以下をご覧ください。
* https://support.microsoft.com/kb/3197954
* https://support.microsoft.com/help/12387/windows-10-update-history
