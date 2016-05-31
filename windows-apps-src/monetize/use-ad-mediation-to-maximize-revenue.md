---
author: mcleanbyron
ms.assetid: 772DEBF2-1578-4330-9C14-70BCC6F55005
description: Microsoft では、複数の広告ネットワークからのバナー広告要求を仲介してアプリ内広告の収益を最大限に増やすことができるように、広告仲介をサポートしています。
title: 広告仲介を使って収益を最大限に高める
---

#  広告仲介を使って収益を最大限に高める


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

Microsoft では、複数の広告ネットワークからのバナー広告要求を仲介してアプリ内広告の収益を最大限に増やすことができるように、広告仲介をサポートしています。 広告ネットワークには、1000 回の広告表示あたりの料金 (eCPM) が高い、特定の市場におけるフィル レート (アプリが要求を行ったときに提供される広告の割合) が他の市場より高いなど、それぞれ強みがあります。 広告ネットワークが 1 つしかない場合、広告要求を満たすことができず、潜在的な収益を失う可能性があります。 広告仲介の利用によって、ライブ広告を常時表示できるようになり、最大限の広告収入を上げることができます。

広告仲介サポートは、[Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) から利用できます。 SDK をインストールしてアプリに広告メディエーター コントロールを追加した後、デベロッパー センターで仲介の構成を更新して各ネットワークの利用頻度を指定できます。 これは、市場ごとに最適化できるため、該当する地域で最も効果の高い広告ネットワークを使うことになります。 さらに、アプリを再公開しなくても、各広告ネットワークの利用方法を変更することができます。

## 広告仲介の概要


アプリで広告の仲介を設定および構成するには、次の手順を実行します。

1.  広告の仲介でサポートする広告ネットワークとプロジェクトの種類の一覧を確認して、使用する広告ネットワークでアカウントを設定し、各広告ネットワークの指示に従ってアプリを登録します。 詳しくは、「[広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)」をご覧ください。

2.  [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) を Visual Studio 2015 または Visual Studio 2013 と共にインストールします。

3.  Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。 広告をホストするページを開き、**AdMediatorControl** をページにドラッグします。 Microsoft Advertising を使う場合は、サポートされている広告サイズに収まるようにコントロールの高さと幅を調整します。 詳しくは、「[広告メディエーター コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。

4.  **接続済みサービス**を実行し、対象の広告ネットワークを選択して、各広告ネットワークの必須のパラメーターを構成します。 詳しくは、「[広告メディエーター コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。

5.  アプリで広告仲介の実装をテストします。 詳しくは、「[広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)」をご覧ください。

6.  アプリを Windows デベロッパー センター ダッシュボードに提出し、ダッシュボードで広告の仲介に関する設定を構成します。 詳しくは、「[アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)」をご覧ください。

7.  デベロッパー センター ダッシュボードで広告の仲介レポートを確認します。 詳しくは、「[広告仲介レポート](https://msdn.microsoft.com/library/windows/apps/mt148521)」をご覧ください。

## 広告仲介を使わないで Microsoft Advertising を使用する


広告仲介を使う必要がない場合や、プロジェクトの種類が広告仲介で現在サポートされていない場合でも、広告仲介を使わずに Microsoft からバナー広告を提供できます。 詳しくは、[XAML および .NET の AdControl](https://msdn.microsoft.com/library/mt313186.aspx) に関するページ、または [HTML 5 および JavaScript の AdControl](https://msdn.microsoft.com/library/mt313130.aspx) に関するページをご覧ください。

## 関連トピック

* [広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)
* [広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)
* [広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)
* [アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)
* [広告の仲介のトラブルシューティング](troubleshoot-ad-mediation.md)
 

 


<!--HONumber=May16_HO2-->


