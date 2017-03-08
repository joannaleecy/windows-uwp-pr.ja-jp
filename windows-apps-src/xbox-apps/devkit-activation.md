---
author: Mtoepke
title: "Xbox One 開発者モードのアクティブ化"
description: "開発者モードをアクティブ化して、リテール モードと開発者モードを切り替えることができるようにする方法を説明します。"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: ade80769-17ae-46e9-9c2f-bf08ae5a51ee
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 12022ad5ca1b70307b3d5b780ffbc366172113e3
ms.lasthandoff: 02/08/2017

---

# <a name="xbox-one-developer-mode-activation"></a>Xbox One 開発者モードのアクティブ化

* [開発者モードの動作](#how-developer-mode-works)
* [製品版の Xbox One 本体で開発者モードをアクティブにする](#activate-developer-mode-on-your-retail-xbox-one-console)  
* [リテール モードと開発者モードを切り替える](#switch-between-retail-and-developer-mode)

## <a name="how-developer-mode-works"></a>開発者モードの動作
Xbox One には、*リテール* モード (1) と*開発者*モード (2) の 2 つのモードがあります。 リテール モードは、Xbox One 本体のユーザーが本体を使うときのモードです。ユーザーとしてゲームをプレイしたり、アプリを実行したりできます。 開発者モードでは、本体用のソフトウェアを開発することができますが、製品版のゲームをプレイしたり、製品版のアプリを実行したりすることはできません。
開発者モードは、製品版のすべての Xbox One 本体で有効にできます。 開発者モードを有効にした後は、リテール モード (2a) と開発者モード (2b) を相互に切り替えることができます。

> [!NOTE]
> Xbox One Beta プログラムのような既存のプレビュー プログラムに参加している場合は、Xbox One で開発者モードをアクティブ化することはできません。 Xbox プレビュー ダッシュボード アプリを使うと、既存のプレビュー プログラムへの参加を終了できます。 

![Xbox One のモード](images/dev-mode-flow.png)

## <a name="activate-developer-mode-on-your-retail-xbox-one-console"></a>製品版の Xbox One 本体で開発者モードをアクティブにする

1.    Xbox One 本体を起動します。

2.    Xbox One ストアから、開発者モードのアクティブ化用アプリを検索してインストールします。  
    ![開発者モードのアクティブ化用アプリのインストール](images/activation-store-search.png)

3.    **[マイ コレクション]** > **[アプリ]** に移動します。

    ![開発者モードのアクティブ化用アプリ](images/activation-step-3.png)
4. 開発者モードのアクティブ化用アプリを開きます。    
    
    > [!NOTE]
    > ゲームやアプリを実行するには、リテール モードに切り替える必要があります。 サイドローディングしたアプリは、開発者モードでのみ動作します。

5.    開発者モードのアクティブ化用アプリに表示されたコードを書き留めます。  

    ![アクティブ化手順 5](images/activation-step-5.png)  
    
6.    [developer.microsoft.com/xboxactivate](https://developer.microsoft.com/xboxactivate) にアクセスします。
7.    デベロッパー センター アカウントを使ってデベロッパー センターにサインインします。  
8.    開発者モードのアクティブ化用アプリに表示されたアクティブ化コードを入力します。   
   
    > [!NOTE]
    > アカウントに関連付けられているアクティブ化の数には制限があります。 開発者モードがアクティブになると、アカウントに関連付けられているアクティブ化の 1 つが使われたことを示す通知がデベロッパー センターに表示されます。 
    
    ![アクティブ化手順 8](images/activation-step-8.png)    
    
9.    **[Agree and activate]** (同意してアクティブ化) をクリックします。 ページの再読み込みが行われ、デバイスが表に追加されます。
    
    > [!NOTE]
    > Xbox One 開発者モードのライセンス認証プログラム契約は、[Xbox One開発者モードのライセンス認証プログラム](http://go.microsoft.com/fwlink/p/?LinkId=760399) にあります。

10.    アクティブ化コードを入力すると、アクティブ化プロセスの進行状況が表示されます。  
    
11.    アクティブ化の完了後、開発者モードのアクティブ化用アプリを開き、**[Switch and restart]** (切り替えて再起動) をクリックして、開発者モードに移行します。 これは通常の再起動よりも時間がかかります。  

    ![アクティブ化手順 12](images/activation-step-12.png)   
    

    
## <a name="switch-between-retail-and-developer-mode"></a>リテール モードと開発者モードを切り替える
本体で開発者モードを有効にした後、リテール モードと開発者モードを切り替えるには、**Dev Home** を使います。 **Dev Home** の起動と使用について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。

* リテール モードに切り替えるには、**Dev Home** を使って **[Leave developer mode]** (開発者モードの終了) をクリックします。 これにより、本体がリテール モードで再起動します。    

  ![アクティブ化手順 13](images/activation-step-13.png)  
  
* 開発者モードに切り替えるには、開発者モードのアクティブ化用アプリを使います。 アプリを開き、**[Switch and restart]** (切り替えて再起動) をクリックします。 これにより、本体が開発者モードで再起動します。  

  ![アクティブ化手順 14](images/activation-step-12.png)  

## <a name="see-also"></a>参照
- [Xbox One 開発者モードの非アクティブ化](devkit-deactivation.md)
- [Xbox One の UWP](index.md)

