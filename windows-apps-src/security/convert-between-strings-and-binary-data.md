---
title: 文字列とバイナリ データの間の変換
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの文字列とバイナリ データ間での変換方法を示しています。
ms.assetid: AED4C74F-E63B-4980-BB4D-28ACCC1AB58B
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: ae2de8f009da1873c9aebf4f60ef315b36c7d744
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8758452"
---
# <a name="convert-between-strings-and-binary-data"></a>文字列とバイナリ データの間の変換



次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの文字列とバイナリ データ間での変換方法を示しています。

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