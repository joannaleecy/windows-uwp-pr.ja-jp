---
author: jnHs
Description: "アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。"
title: "一般的な認定エラーの回避"
ms.assetid: 9E9E3841-2F9B-42D4-B5F8-4C7C31E42E3D
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 92e1b35c8eba7f1f3d3a32f0c994d3353a065419
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="avoid-common-certification-failures"></a>一般的な認定エラーの回避


アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。

> [!NOTE]
> 必ず「[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)」も確認し、アプリがここに掲げる要件をすべて満たすようにしてください。

-   アプリを申請するのは、アプリが完成した場合だけにします。 アプリの説明を使って今後の機能を言及することをお勧めしますが、不完全なセクションや、作成中の Web ページへのリンクなど、アプリが不完全であるという印象をユーザーに与えるものをアプリに含めないようにしてください。

-   アプリを申請する前に、[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md)します。

-   できるだけアプリの安定性が高くなるように、複数の異なる構成でアプリをテストします。

-   ネットワークに接続できない状況でもアプリがクラッシュしないことを確認します。 実際に使うためには接続を必要とするアプリであっても、接続が存在しない状態で正常に動作する必要があります。

-   テスト アカウントのユーザー名とパスワード (ユーザーがサービスにログインする必要のあるアプリの場合) や、非表示の機能やロックされている機能へのアクセスに必要な手順など、アプリを使うために [必要な情報を提供](notes-for-certification.md) してください。

-   アプリが何かしらの方法で個人情報にアクセスする、または法律で義務付けられている場合など、アプリに[プライバシー ポリシー](create-app-store-listings.md#privacy-policy)が必要な場合は提供してください。 アプリにプライバシー ポリシーが必要かどうかを確認するには、「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」と「[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)」をご覧ください。

-   アプリの内容を明確に表せるように、アプリの説明はできるだけ詳しく記載します。 ヘルプが必要な場合は、[アプリに関する優れた説明を記載する](write-a-great-app-description.md) ためのガイダンスをご覧ください。

-   [年齢区分](age-ratings.md)のセクションのすべての質問に正確で完全な回答を入力してください。

-   アクセシビリティのシナリオを想定して具体的な設計とテストを行っていない限り、[アプリをアクセシビリティ対応として宣言](app-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines)しないでください。

-   アプリが [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間から商取引 API を使う場合、アプリを必ずテストして、一般的な例外が処理されることを確認します。 また、アプリがテスト用途のみの [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) クラスではなく、[**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使っていることも確認してください。 (アプリが Windows 10 バージョン 1607 以降のバージョンをターゲットにする場合は、Windows.ApplicationModel.Store 名前空間ではなく、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間を使用することをお勧めします)。


 

 




