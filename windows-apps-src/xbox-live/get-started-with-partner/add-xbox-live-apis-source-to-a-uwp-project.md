---
title: Xbox Live API のソースを UWP プロジェクトに追加する
author: KevinAsgari
description: UWP プロジェクトで Xbox Live API のソースを追加し、コンパイルする方法について説明します。
ms.assetid: 744f87dc-510b-4a26-b2c0-74fc70b8453b
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: a962b0c9fddd8e7738cb30daf9aa6d41e2f1bfd1
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="add-and-compile-the-xbox-live-apis-source-in-your-uwp-project"></a><span data-ttu-id="208fa-104">UWP プロジェクトで Xbox Live API のソースを追加し、コンパイルする</span><span class="sxs-lookup"><span data-stu-id="208fa-104">Add and compile the Xbox Live APIs source in your UWP project</span></span>

<span data-ttu-id="208fa-105">Xbox Live API (XSAPI) のソースが、GitHub ([https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api)) で利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="208fa-105">The Xbox Live API (XSAPI) source is now available on GitHub at [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api).</span></span> <span data-ttu-id="208fa-106">開発者は、次の手順を使用して、ローカル ビルドを使用するようにプロジェクトを更新できます。</span><span class="sxs-lookup"><span data-stu-id="208fa-106">Developers can follow these instructions to update their projects to use a local build.</span></span>

<span data-ttu-id="208fa-107">次のような場合、XSAPI を自分でビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="208fa-107">You might want to build XSAPI yourself if:</span></span>
1. <span data-ttu-id="208fa-108">問題をデバッグしてエラーのあるコードの場所を特定する場合。</span><span class="sxs-lookup"><span data-stu-id="208fa-108">If you want to debug an issue to understand where an error code is coming from.</span></span>
1. <span data-ttu-id="208fa-109">QFE が配布されるまでに、問題を解決するためのソース コード パッチを提供する場合。</span><span class="sxs-lookup"><span data-stu-id="208fa-109">If we provide a source code patch to fix an issue for you, before we can distribute a QFE.</span></span>

<span data-ttu-id="208fa-110">XSAPI プロジェクトを自分でコンパイルするには、GitHub プロジェクト サイトの指示に従ってください。</span><span class="sxs-lookup"><span data-stu-id="208fa-110">To compile the XSAPI project yourself, follow the instructions on the GitHub project site.</span></span>
