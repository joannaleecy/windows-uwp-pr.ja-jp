---
title: C++ API のエラー処理
author: KevinAsgari
description: C++ API を使って Xbox Live サービス呼び出しを行ったときのエラーを処理する方法について説明します。
ms.assetid: 10b47e68-8b1f-4023-96a4-404f3f6a9850
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, エラー処理
ms.localizationpriority: medium
ms.openlocfilehash: 9863ac224e04d48265a05fe56ed484db5dcc3cd8
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5169765"
---
# <a name="c-api-error-handling"></a>C++ API のエラー処理

C++ API のほとんどの呼び出しは、例外をスローするのではなく、必要に応じて xbox_live_result<payload_type> を返します。

## <a name="xboxliveresult-structure"></a>xbox_live_result structure
xbox_live_result には 3 つの項目があります。
1. 操作によって返されるエラー
2. デバッグに使用する具体的なエラー メッセージ
3. 結果のペイロード (エラーがあった場合、空の可能性があります)

xbox_live_result およびエラー コードの詳細については、Xbox Live のドキュメントを参照してください。

その構造は次のとおりです。

```cpp
template<typename T>
class xbox_live_result
{
    const std::error_code& err();
    const std::string& err_message();
    T& payload();
};
```

**err** - エラーを返します。  エラーがない場合は NULL 参照です。  これは C++ STL エラーと同様に動作し、value() を呼び出すことによってプリミティブ値を取得できます。  message() を呼び出すと文字列表現を取得できます。  したがって、エラー コードが "Invalid Argument" という意味の場合、```err().message()``` は "Invalid Argument" というテキストになります。

**err_message** - エラーの詳細です。  たとえば、**err** が "Invalid Argument" の場合、**err_message** では無効な引数が詳しく示されます。

**payload** - 対象の項目を返します。  たとえば、get_achievement の呼び出しから取得する ```xbox_live_result<achievement>``` について考えます。  この例では、ペイロードは実績自体になります (エラーがない場合)。

## <a name="example"></a>例

```cpp
// Function which returns an xbox_live_result
xbox_live_result<std::shared_ptr<title_presence_change_subscription>> presenceChangeSubscriptionResult =
xbox::services::presence::subscribe_to_title_presence_change(
    xboxUserId,
    titleId
    );

printf("Error value %d, string %s", achievementResult.err().value(), achievementResult.err().message());

// Would output:
// "0 Success" if successful
// "401 Unauthorized" if auth issue

if (!achievementResult.err())
{
  // Do things on success.  Payload will be populated if applicable.
  std::shared_ptr<title_presence_change_subscription> presenceChangeSubscription = presenceChangeSubscriptionResult->payload();

  // ...
}
else if (achievement.err() == xboxlive_error_code::http_status_403_forbidden)
{
  // Special handling for 403 errors
}
else if (achievementResult.err() == xbox_live_error_condition::auth)
{
  // Handle broad auth failures.  See below section for more info on xbox_live_error_condition
}

```

## <a name="using-xboxliveerrorcondition-to-test-against-broad-error-categories"></a>広範なエラー カテゴリーテストするための xbox_live_error_condition の使用
上の例では、403 エラーおよび ```xbox_live_error_condition::auth``` などについてのエラー コードをテストしています。

 xbox_live_result err() 関数を使用すると、エラー コードを個別にテストできます。  たとえば、400 クラスのエラーの場合、以下に対する個別のテストと制御フローがあります。

* xbox_live_error_code::http_status_400_bad_request
* xbox_live_error_code::http_status_401_unauthorized
* xbox_live_error_code::http_status_403_forbidden
* など

ただし、このような方法ではなく、エラーのクラス全体に対してテストする方が効率的です。  そこで、```xbox_live_error_condition``` クラスで使用できる列挙値を使用してエラーのクラスに対してテストします。  多数のエラー コードに対するテストを自動化する等値演算子のオーバーロードが実装されています。  ```auth``` に加えて、```rta``` and ```http``` などのカテゴリーがあります。  完全なリストは、*errors.h* または *xblsdk_cpp.chm* で確認できます。

これに関して説明している動画、および C++ Xbox Service API のその他の機能については、[Xfest 2015 のビデオ](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx)の「*XSAPI:C++, No Exceptions!*」にある Xfest の講演をご覧ください。
