---
title: Xbox Live API の概要
author: KevinAsgari
description: Xbox Live サービスとのやり取りに使用できる、さまざまな API モデルについて説明します。
ms.assetid: 5918c3a2-6529-4f07-b44d-51f9861f91ec
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: low
ms.openlocfilehash: 3d5b342da9c4cc9b1a98849b0f94432ae7e1f5a5
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
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

Xbox Live Services API (**XSAPI**) は、広範なユーザー シナリオをサポートする 2 セットのクライアント側 API を公開します。

- XSAPI WinRT API
- XSAPI C++11 ベース API

2 つの API を比較すると次のようになります。

**XSAPI WinRT ベース API**

- C++/CX、C#、および JavaScript で記述されたアプリケーションをサポートします。
    - C++/CX はマイクロソフトの C++ 拡張であり、^ を WinRT ポインターとして使用するなど、WinRT プログラミングを容易にします。
- Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。
- C++/CX を含むすべての言語で、エラーは例外を使用して処理されます。
- C++/WinRT もサポートされます。  C++/WinRT の詳細については、[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/) を参照してください。

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


**XSAPI C++11 ベース API**

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

- C++/WinRT もサポートされます。  C++/WinRT の詳細については、[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/) を参照してください。

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
