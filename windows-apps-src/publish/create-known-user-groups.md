---
author: JnHs
Description: "パッケージ フライトなどに使う既知のユーザー グループの作成方法を説明します。"
title: "既知のユーザー グループを作成する"
ms.author: wdg-dev-content
ms.date: 08/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, セグメント, セグメント, 対象グループ, ユーザー"
ms.openlocfilehash: fc3986520e55ae0c636eb2db731df065463002b5
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="create-known-user-groups"></a><span data-ttu-id="6d869-104">既知のユーザー グループを作成する</span><span class="sxs-lookup"><span data-stu-id="6d869-104">Create known user groups</span></span>

<span data-ttu-id="6d869-105">既知のユーザー グループを使うと、Microsoft アカウントに関連付けられているメール アドレスを使って、任意のグループに特定のユーザーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="6d869-105">Known user groups let you add specific people to a group, using the email address associated with their Microsoft account.</span></span> <span data-ttu-id="6d869-106">既知のユーザー グループは、選ばれたユーザーのグループに特定のパッケージを配布するために、[パッケージ フライト](package-flights.md)と使われることが最も一般的です。</span><span class="sxs-lookup"><span data-stu-id="6d869-106">These known user groups are most often used with [package flights](package-flights.md) to distribute specific packages to a selected group of people.</span></span> <span data-ttu-id="6d869-107">また、エンゲージメント キャンペーンの一環で、[ターゲット通知](send-push-notifications-to-your-apps-customers.md)や[対象のプラン](use-targeted-offers-to-maximize-engagement-and-conversions.md)を特定のユーザーに送信するためにも使われます。</span><span class="sxs-lookup"><span data-stu-id="6d869-107">They can also be used to send [targeted notifications](send-push-notifications-to-your-apps-customers.md) or [targeted offers](use-targeted-offers-to-maximize-engagement-and-conversions.md) to a group of specific customers as part of your engagement campaigns.</span></span>

<span data-ttu-id="6d869-108">ユーザーがグループのメンバーとして扱われるには、指定したメール アドレスと関連付けられている Microsoft アカウントを使ってストアで認証されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d869-108">In order to be counted as a member of the group, each person must be authenticated with the Store using the Microsoft account associated with the email address you provide.</span></span> <span data-ttu-id="6d869-109">パッケージ フライトの場合、[パッケージ フライトをサポートする Windows 10 デバイス](package-flights.md)を使って、アプリをダウンロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d869-109">For package flights, they must be using [a Windows 10 device that supports package flighting](package-flights.md) to download the app.</span></span>


## <a name="to-create-a-known-user-group"></a><span data-ttu-id="6d869-110">既知のユーザー グループを作成するには</span><span class="sxs-lookup"><span data-stu-id="6d869-110">To create a known user group</span></span>

1.  <span data-ttu-id="6d869-111">Windows デベロッパー センター ダッシュボードで、左側のナビゲーション メニューの **[Engage] (関心を引く)** を展開して、**[ユーザー グループ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-111">In the Windows Dev Center dashboard, expand **Engage** in the left navigation menu and then select **Customer groups**.</span></span> 
2.  <span data-ttu-id="6d869-112">**[自分のユーザー グループ]** セクションで、**[新しいグループの作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-112">In the **My customer groups** section, select **Create new group**.</span></span>
3.  <span data-ttu-id="6d869-113">次のページで、**[既知のユーザー グループ]** ラジオ ボタンを選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-113">On the next page, select the **Known user group** radio button.</span></span>
4.  <span data-ttu-id="6d869-114">**[グループ名]** に既知のユーザー グループの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="6d869-114">In the **Group name** box, enter a name for your known user group.</span></span>
5.  <span data-ttu-id="6d869-115">グループに追加するユーザーの電子メール アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="6d869-115">Enter the email addresses of the people you'd like to add to the group.</span></span> <span data-ttu-id="6d869-116">少なくとも 1 つのメール アドレスを設定してください。最大で 10,000 件まで設定できます。</span><span class="sxs-lookup"><span data-stu-id="6d869-116">You must include at least one email address, with a maximum of 10,000.</span></span> <span data-ttu-id="6d869-117">メール アドレスは、フィールドに直接入力することができます (スペース、コンマ、セミコロン、または改行で区切ります)。または、**[インポート (.csv)]** リンクをクリックし、.csv ファイル形式のメール アドレスの一覧からフライト グループを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="6d869-117">You can enter email addresses directly into the field (separated by spaces, commas, semicolons, or line breaks), or you can click the **Import .csv** link to create the flight group from a list of email addresses in a .csv file.</span></span>
6. <span data-ttu-id="6d869-118">**[保存]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-118">Select **Save**.</span></span>

<span data-ttu-id="6d869-119">これで、グループを使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="6d869-119">The group will now be available for you to use.</span></span>

<span data-ttu-id="6d869-120">また、[package flight](package-flights.md)を作成するページで **[フライト グループを作成する]** を選んで、既知のユーザー グループを作ることもできます。</span><span class="sxs-lookup"><span data-stu-id="6d869-120">You can also create a known user group by selecting **Create a flight group** from the [package flight](package-flights.md) creation page.</span></span> <span data-ttu-id="6d869-121">パッケージ フライトの作成ページで既に入力した情報をもう一度入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d869-121">Note that you'll need to re-enter any info you've already provided in the package flight creation page if you do this.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6d869-122">パッケージ フライトで既知のユーザー グループを使う場合は、必ず、フライト グループに追加するユーザーから必要な同意をすべて得てください。また、フライト以外の申請とは異なるパッケージを入手するようになることをそれらのユーザーが理解していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="6d869-122">When using known user groups with package flighting, be sure that you have obtained any necessary consent from people that you add to your group, and that they understand that they will be getting packages that are different from your non-flighted submission.</span></span> 

## <a name="to-edit-a-known-user-group"></a><span data-ttu-id="6d869-123">既知のユーザー グループを編集するには</span><span class="sxs-lookup"><span data-stu-id="6d869-123">To edit a known user group</span></span>

<span data-ttu-id="6d869-124">既知のユーザー グループは作成されると、ダッシュボードから削除 (や名前の変更) を行うことはできませんが、いつでもメンバーシップは編集できます。</span><span class="sxs-lookup"><span data-stu-id="6d869-124">You cannot remove a known user group from your dashboard (or change its name) after it's been created, but you can edit its membership at any time.</span></span>

<span data-ttu-id="6d869-125">既知のユーザー グループを確認および編集するには、左側のナビゲーション メニューの **[Engage] (関心を引く)** メニューを展開し、ダッシュボードの上部付近の **[ユーザー グループ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-125">To review and edit your known user groups, expand the **Engage** menu in the left navigation menu and select **Customer groups**.</span></span> <span data-ttu-id="6d869-126">**[自分のユーザー グループ]** で、編集するグループの名前を選びます。</span><span class="sxs-lookup"><span data-stu-id="6d869-126">Under **My customer groups**, select the name of the group you want to edit.</span></span> <span data-ttu-id="6d869-127">また、パッケージ フライトの作成ページで新しいフライトの作成時に **[既存のグループを表示および管理]** を選ぶか、パッケージ フライトの概要ページでグループの名前を選んでも、既知のユーザー グループを編集できます。</span><span class="sxs-lookup"><span data-stu-id="6d869-127">You can also edit a known user group from the package flight creation page by selecting **View and manage existing groups** when creating a new flight, or by selecting the group's name from a package flight's overview page.</span></span> 

<span data-ttu-id="6d869-128">編集するグループを選ぶと、フィールドに直接メール アドレスを追加または削除できます。</span><span class="sxs-lookup"><span data-stu-id="6d869-128">After you've selected the group you want to edit, you can add or remove email addresses directly in the field.</span></span>

<span data-ttu-id="6d869-129">大幅に変更する場合は、**[エクスポート (.csv)]** を選んで、グループ メンバーシップ情報を .csv ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="6d869-129">For larger changes, select **Export .csv** to save your group membership info to a .csv file.</span></span> <span data-ttu-id="6d869-130">このファイルに必要な変更を加えた後、**[インポート (.csv)]** をクリックし、新しいバージョンを使ってグループのメンバーシップを更新します。</span><span class="sxs-lookup"><span data-stu-id="6d869-130">Make your changes in this file, then click **Import .csv** to use the new version to update the group membership.</span></span>

<span data-ttu-id="6d869-131">メンバーシップの変更内容が反映されるまで最大 30 分かかる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6d869-131">Note that it may take up to 30 minutes for membership changes to be implemented.</span></span> <span data-ttu-id="6d869-132">パッケージ フライトを既知のユーザー グループに公開した後でそのグループにユーザーを追加すると、パッケージは自動的に新しいユーザーに配信されます。そのパッケージ フライトの新しい申請を作成して公開する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6d869-132">If you add people to a known user group after you've published a package flight for that group, the packages will be delivered to the new people automatically; you don't have to create and publish a new submission for that package flight.</span></span> 





