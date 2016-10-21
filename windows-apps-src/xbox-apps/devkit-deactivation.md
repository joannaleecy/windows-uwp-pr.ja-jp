---
author: Mtoepke
title: "Xbox One 開発者モードの非アクティブ化"
description: "開発者モードを非アクティブ化する方法を説明します。"
translationtype: Human Translation
ms.sourcegitcommit: c80849904eccae1ef0e0740bb4e882f7f0f37cc8
ms.openlocfilehash: 273cd14d5f51a693ba8385c13d128bb2888de2ea

---

# Xbox One 開発者モードの非アクティブ化

* [リテール モードに切り替える](#switch-to-retail-mode)
* [開発者モードのアクティブ化用アプリを使って本体を非アクティブ化する](#deactivate-your-console-using-the-dev-mode-activation-app)  
* [本体をリセットする](#reset-your-console)
* [Windows デベロッパー センターを使って本体を非アクティブ化する](#deactivate-your-console-using-windows-dev-center)

本体を開発用に使うことをやめる場合は、以下の手順を使って開発者モードを非アクティブ化します。

## リテール モードに切り替える
まず、Xbox One 本体をリテール モードに戻します。

1. **Dev Home** を開きます。
2. **[Leave developer mode]** (開発者モードの終了) をクリックします。  本体がリテール モードで再起動します。  

   ![](images/deactivation-leave-dev-mode.png)

次のいずれかの方法を使って本体を非アクティブ化します。

## 開発者モードのアクティブ化用アプリを使って本体を非アクティブ化する

本体の開発者モードを非アクティブ化するための推奨される方法は、開発者モードのアクティブ化用アプリを使うことです。 

1. **[マイ コレクション]** > **[アプリ]** に移動します。
  
   ![アクティブ化手順 3](images/activation-step-3.png)    
   
2.  開発者モードのアクティブ化用アプリを開きます。    
3.  **[Deactivate]** (非アクティブ化) をクリックします。
  
![本体の非アクティブ化](images/deactivation-app.png)

## 本体をリセットする

開発者モードを非アクティブ化するには、本体をリセットする方法を使うこともできます。  

> [!NOTE]
> 本体をリセットすると、ローカルに保存されているゲーム データはすべて失われます。

本体をリセットするには、次の手順を実行します。

1.  **[マイ コレクション]** に移動します。  
2.  **[アプリ]** を選択し、**[設定]** を選択します。  
3.  左ペインの **[システム]** に移動し、右ペインの **[本体の情報と更新]** を選択します。  
4.  **[本体の情報と更新]** に移動します。  
   
    ![本体の情報と更新](images/deactivation-console-info-updates.png)  
    
5.  **[Reset console]** (本体のリセット) をクリックします。
    
    ![本体のリセット](images/deactivation-reset-console.png)
    
6.  次に、**[Reset and remove everything]** (すべてを削除してリセット) をクリックします。 このオプションは、本体をリセットして元の製品版の状態にします。  アプリ、ゲーム、ローカルに保存されたデータはすべて削除されます。 もう 1 つのオプションである **[Reset and keep my games & apps]** (ゲームとアプリを保持してリセット) を選んだ場合、本体は開発者プログラムから削除されません。  
   
    ![すべてを削除してリセット](images/deactivation-reset-remove.png)

## Windows デベロッパー センターを使って本体を非アクティブ化する

何らかの理由で本体にアクセスできない場合は、Windows デベロッパー センターを使って本体の開発者モードを非アクティブ化できます。

1. [developer.microsoft.com/xboxdevices](https://developer.microsoft.com/xboxdevices) にアクセスします。    
2. デベロッパー センター アカウントを使ってデベロッパー センターにサインインします。    
3. 本体の一覧で、シリアル番号、本体の ID、またはデバイス ID を照らし合わせて、非アクティブ化する本体を見つけます。  
4. **[Deactivate]** (非アクティブ化) をクリックします。  
  
![DevCenter を使った非アクティブ化](images/deactivation-devcenter.png)

事前に Xbox One 本体をリテール モードに戻していない場合は、ここで戻してください。

1. **Dev Home** を起動します。
2. **[Leave developer mode]** (開発者モードの終了) をクリックします。  本体がリテール モードで再起動します。

![アクティブ化手順 13](images/deactivation-leave-dev-mode.png)

## 参照
- [Xbox One 開発者モードのアクティブ化](devkit-activation.md)
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO3-->


