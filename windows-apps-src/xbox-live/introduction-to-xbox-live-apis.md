---
title: Xbox Live API の概要
description: Xbox Live サービスとのやり取りに使用できる、さまざまな API モデルについて説明します。
ms.assetid: 5918c3a2-6529-4f07-b44d-51f9861f91ec
ms.date: 06/05/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 118c451bb4e015d578620647f09ff23724701da0
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8729230"
---
# <a name="introduction-to-xbox-live-apis"></a>Xbox Live API の概要

## <a name="use-xbox-live-services"></a>Xbox Live サービスの使用

Xbox Live サービスから情報を取得する方法は 2 つあります。

- Xbox Live Services API (**XSAPI**) と呼ばれるクライアント側 API を使用する
- **Xbox Live REST エンドポイント**を直接呼び出す

Xbox Live Services API (**XSAPI**) を使用する方法には、以下のような利点があります。

- 認証、エンコーディング、および HTTP 送受信の詳細が自動的に処理されます。
- ラッパー API への引数およびラッパー API から返されるデータは、ネイティブのデータ型で処理されるため、JSON エンコーディングおよびデコーディングを実行する必要はありません。
- Web サービスの直接呼び出しに、ラッパー API でカプセル化される複数の非同期手順が含まれます。これにより、タイトル コードの読み書きが容易になります。
- ゲーム イベントの書き込みなどの一部機能は XSAPI でのみ利用できます。

**Xbox Live REST エンドポイント**を直接使用する方法には、以下の利点があります。

- Xbox Live エンドポイントを Web サービスから呼び出すことができます。
- XSAPI に含まれていないエンドポイントを呼び出すことができます。  XSAPI には、ゲームで使用すると思われる API のみが含まれています。API が不足している場合は、フォーラムからお知らせください。
- REST エンドポイント経由で利用できる一部の機能には、対応する XSAPI ラッパーが存在しない場合があります。

ゲームおよびアプリで、以上のどちらかの方法しか使用できないということはありません。 XSAPI ラッパーを使用しつつ、必要な場合は REST エンドポイントを直接呼び出すことができます。

## <a name="xbox-live-services-api-overview"></a>Xbox Live Services API の概要 ##

Xbox Live Services API (**XSAPI**) は、次の 3 つのセットのクライアント側のさまざまなユーザー シナリオをサポートする Api を公開します。

- [XSAPI WinRT API](#xsapi-winrt-based-api)
- [XSAPI C++11 ベース API](#xsapi-c++11-based-api)
- [XSAPI C ベース API](#xsapi-c-based-api)(**2018 6 月時点で新しい**)

Api を比較します。

### <a name="xsapi-winrt-based-api"></a>XSAPI WinRT ベース API

- C++/CX、C#、および JavaScript で記述されたアプリケーションをサポートします。
    - C++/CX はマイクロソフトの C++ 拡張であり、^ を WinRT ポインターとして使用するなど、WinRT プログラミングを容易にします。
- Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。
- C++/CX を含むすべての言語で、エラーは例外を使用して処理されます。
- C++/WinRT もサポートされます。  詳細については、C++/WinRT で入手できます[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)

C++/WinRT を使用する XSAPI WinRT API の呼び出しの例を次に示します。

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```

コードの移行時に C++/CX と C++/WinRT を混在したい場合は、このようにすることもできますが、少し複雑です。  
C++/WinRT を使用する C++/CX User^ オブジェクトが指定された XSAPI WinRT API の呼び出しの例を次に示します。

```c++
::Windows::Xbox::System::User^ user1 = ::Windows::Xbox::System::User::Users->GetAt(0);
winrt::Windows::Xbox::System::User cppWinrtUser(nullptr);
winrt::copy_from(cppWinrtUser, reinterpret_cast<winrt::ABI::Windows::Xbox::System::IUser*>(user1));
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```


### <a name="xsapi-c11-based-api"></a>XSAPI C++11 ベース API

- クロス プラットフォームの ISO 標準 C++11 を使用します。
- C++ で記述されたアプリケーションをサポートします。
- Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。
- エラーは std::error_code を使用して処理されます。
- パフォーマンスとデバッグの向上のため、C++ のゲーム エンジンを使用する場合は C++11 ベースの API が推奨されます。
- Xbox Live クリエーターズ プログラムに参加している場合、XSAPI ヘッダーをインクルードする前に XBOX_LIVE_CREATORS_SDK を定義します。 これによって、API サーフェイス領域は Xbox Live Creators Program の開発者が使用できるもののみに制限されます。また、Xbox Live クリエーターズ プログラムのタイトルで機能するサインイン メソッドが変更されます。  次に、例を示します。

```c++
#define XBOX_LIVE_CREATORS_SDK
#include "xsapi\services.h"
```

- C++/WinRT もサポートされます。  詳細については、C++/WinRT で入手できます[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)

C++/WinRT と XSAPI C++ API を使うには、XSAPI ヘッダーをインクルードする前に XSAPI_CPPWINRT を定義します。  次に、例を示します。

```c++
#define XSAPI_CPPWINRT
#include "xsapi\services.h"
```

C++/WinRT を使用した XSAPI C++ API の呼び出しの例を次に示します。

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
std::shared_ptr<xbox::services::xbox_live_context> xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>(cppWinrtUser);
```

### <a name="xsapi-c-based-api"></a>XSAPI C ベース API

- タイトルを XSAPI を呼び出すと、メモリ割り当てを制御できます。
- により、タイトルを XSAPI を呼び出すときの処理スレッドの完全な制御を取得します。
- 新しい HTTP ライブラリ、libHttpClient、ゲーム開発者向けに設計されたを使用します。

詳細については、 [Xbox Live C Api の概要](xsapi-flat-c.md)をご覧ください。
