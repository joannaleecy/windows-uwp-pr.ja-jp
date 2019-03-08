---
Description: アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。
title: 一般的な認定エラーの回避
ms.assetid: 9E9E3841-2F9B-42D4-B5F8-4C7C31E42E3D
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 62c99c159ff68201919fa15baded999e3b6a2477
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625797"
---
# <a name="avoid-common-certification-failures"></a>一般的な認定エラーの回避


アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。

> [!NOTE]
> 確認してください、 [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)アプリが一覧表示の要件をすべてを満たしていることを確認します。

-   アプリを申請するのは、アプリが完成した場合だけにします。 アプリの説明を使って今後の機能を言及することをお勧めしますが、不完全なセクションや、作成中の Web ページへのリンクなど、アプリが不完全であるという印象をユーザーに与えるものをアプリに含めないようにしてください。

-   アプリを提出する前に、[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md)します。

-   できるだけアプリの安定性が高くなるように、複数の異なる構成でアプリをテストします。

-   ネットワークに接続できない状況でもアプリがクラッシュしないことを確認します。 実際に使うためには接続を必要とするアプリであっても、接続が存在しない状態で正常に動作する必要があります。

-   テスト アカウントのユーザー名とパスワード (ユーザーがサービスにログインする必要のあるアプリの場合) や、非表示の機能やロックされている機能へのアクセスに必要な手順など、アプリを使うために [必要な情報を提供](notes-for-certification.md) してください。

-   含める、[プライバシー ポリシー URL](enter-app-properties.md#privacy-policy-url)アプリでは、1 つ; が必要な場合など、アプリのあらゆる種類の任意の方法で個人情報にアクセスまたはそれ以外の場合は、法律によって必要とします。 アプリのプライバシー ポリシーが必要かどうかを判断するためには、確認、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)と[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)します。

-   アプリの内容を明確に表せるように、アプリの説明はできるだけ詳しく記載します。 ヘルプが必要な場合は、[アプリに関する優れた説明を記載する](write-a-great-app-description.md) ためのガイダンスをご覧ください。

-   [年齢区分](age-ratings.md)のセクションのすべての質問に正確で完全な回答を入力してください。

-   アクセシビリティのシナリオを想定して具体的な設計とテストを行っていない限り、[アプリをアクセシビリティ対応として宣言](product-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines)しないでください。

-   アプリが [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間から商取引 API を使う場合、アプリを必ずテストして、一般的な例外が処理されることを確認します。 また、アプリがテスト用途のみの [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) クラスではなく、[**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使っていることも確認してください。 (アプリが Windows 10 バージョン 1607 以降のバージョンをターゲットにする場合は、Windows.ApplicationModel.Store 名前空間ではなく、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間を使用することをお勧めします)。


 

 




