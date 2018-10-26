---
title: 文字列とバイナリ データの間の変換
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの文字列とバイナリ データ間での変換方法を示しています。
ms.assetid: AED4C74F-E63B-4980-BB4D-28ACCC1AB58B
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 030fe81685fbc6caea0b9847b366384476f6298f
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5572511"
---
# <a name="convert-between-strings-and-binary-data"></a><span data-ttu-id="a2190-104">文字列とバイナリ データの間の変換</span><span class="sxs-lookup"><span data-stu-id="a2190-104">Convert between strings and binary data</span></span>



<span data-ttu-id="a2190-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの文字列とバイナリ データ間での変換方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a2190-105">This example code shows how to convert between strings and binary data in an Universal Windows Platform (UWP) app.</span></span>

```cs
public void ConvertData()
{
    // Create a string to convert.
    String strIn = "Input String";

    // Convert the string to UTF16BE binary data.
    IBuffer buffUTF16BE = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf16BE);

    // Convert the string to UTF16LE binary data.
    IBuffer buffUTF16LE = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf16LE);

    // Convert the string to UTF8 binary data.
    IBuffer buffUTF8 = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf8);
}
```