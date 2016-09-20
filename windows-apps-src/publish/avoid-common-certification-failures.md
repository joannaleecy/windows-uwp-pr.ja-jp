---
author: jnHs
Description: "アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。"
title: "一般的な認定エラーの回避"
ms.assetid: 9E9E3841-2F9B-42D4-B5F8-4C7C31E42E3D
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 6af2842eeb5eeebfc9ffc5a7a3ec98fdcebddb74

---

# 一般的な認定エラーの回避


アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。

> 
            **注:** アプリがここに掲げる要件をすべて満たすようにするには、「[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)」も確認してください。

 

-   アプリを申請するのは、アプリが完成した場合だけにします。 アプリの説明を使って今後の機能を言及することをお勧めしますが、不完全なセクションや、作成中の Web ページへのリンクなど、アプリが不完全であるという印象をユーザーに与えるものをアプリに含めないようにしてください。

-   
            アプリを提出する前に、[Windows アプリ認定キットでアプリをテスト](https://msdn.microsoft.com/library/windows/apps/mt186449)します。

-   できるだけアプリの安定性が高くなるように、複数の異なる構成でアプリをテストします。

-   ネットワークに接続できない状況でもアプリがクラッシュしないことを確認してください。 実際に使うためには接続を必要とするアプリであっても、接続が存在しない状態で正常に動作する必要があります。
-   アプリの内容を明確に表せるように、アプリの説明はできるだけ詳しく記載します。 ヘルプが必要な場合は、[アプリに関する優れた説明を記載する](write-a-great-app-description.md) ためのガイダンスをご覧ください。

-   必ず、[年齢区分](age-ratings.md) セクションのすべての質問に正確で完全な回答を入力してください。

-   アプリが [**Windows.ApplicationModel.Store**](https://msdn.microsoft.com/library/windows/apps/br225197) 名前空間から商取引 API を使う場合、アプリを必ずテストして、一般的な例外が処理されることを確認します。 また、アプリが (テスト用途のみの [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスではなく) [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスを使っていることも確認してください。

-   アクセシビリティのシナリオを想定して具体的な設計とテストを行っていない限り、[アプリをアクセシビリティ対応として宣言](app-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines) しないでください。

-   テスト アカウントのユーザー名とパスワード (ユーザーがサービスにログインする必要のあるアプリの場合) や、非表示の機能やロックされている機能へのアクセスに必要な手順など、アプリを使うために [必要な情報を提供](notes-for-certification.md) してください。

 

 







<!--HONumber=Jun16_HO4-->


