---
author: JnHs
Description: Learn how to create known user groups to use for package flighting and more.
title: 既知のユーザー グループを作成する
ms.author: wdg-dev-content
ms.date: 03/28/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 対象グループ, ユーザー, フライト グループ, ユーザー グループ, 既知のユーザー
ms.localizationpriority: medium
ms.openlocfilehash: e15b5a4a2f76cbfc33db593c3110ac6f2d054b5b
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483375"
---
# <a name="create-known-user-groups"></a><span data-ttu-id="9b74e-103">既知のユーザー グループを作成する</span><span class="sxs-lookup"><span data-stu-id="9b74e-103">Create known user groups</span></span>

<span data-ttu-id="9b74e-104">既知のユーザー グループを使うと、Microsoft アカウントに関連付けられているメール アドレスを使って、任意のグループに特定のユーザーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-104">Known user groups let you add specific people to a group, using the email address associated with their Microsoft account.</span></span> <span data-ttu-id="9b74e-105">既知のユーザー グループは、選ばれたユーザーのグループに特定のパッケージを配布したり、申請を[プライベート対象ユーザー](choose-visibility-options.md#audience)に配布したりするために、[パッケージ フライト](package-flights.md)と共に使われることが最も一般的です。</span><span class="sxs-lookup"><span data-stu-id="9b74e-105">These known user groups are most often used to distribute specific packages to a selected group of people with [package flights](package-flights.md), or for distribution of a submission to a [private audience](choose-visibility-options.md#audience).</span></span> <span data-ttu-id="9b74e-106">また、[ターゲット通知](send-push-notifications-to-your-apps-customers.md)や[対象のプラン](use-targeted-offers-to-maximize-engagement-and-conversions.md)を特定のユーザーに送信するなど、エンゲージメント キャンペーンのためにも使われます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-106">They can also be used for engagement campaigns, such as sending [targeted notifications](send-push-notifications-to-your-apps-customers.md) or [targeted offers](use-targeted-offers-to-maximize-engagement-and-conversions.md) to a group of specific customers.</span></span>

<span data-ttu-id="9b74e-107">ユーザーがグループのメンバーとして扱われるには、指定したメール アドレスと関連付けられている Microsoft アカウントを使ってストアで認証されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b74e-107">In order to be counted as a member of the group, each person must be authenticated with the Store using the Microsoft account associated with the email address you provide.</span></span> <span data-ttu-id="9b74e-108">パッケージ フライトと共にアプリをダウンロードするには、グループ メンバーがパッケージ フライトをサポートするバージョンの Windows 10 を使っている必要があります (Windows.Desktop ビルド 10586 以降、Windows.Mobile ビルド 10586.63 以降、Xbox One)。</span><span class="sxs-lookup"><span data-stu-id="9b74e-108">To download the app with package flighting, group members must be using a version of Windows 10 that supports package flights (Windows.Desktop build 10586 or later; Windows.Mobile build 10586.63 or later; or Xbox One).</span></span> <span data-ttu-id="9b74e-109">プライベート対象ユーザーの申請では、グループ メンバーは Windows 10 バージョン 1607 以上 (Xbox One を含む) を使っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b74e-109">With private audience submissions, group members must be using Windows 10, version 1607 or higher (including Xbox One).</span></span>

## <a name="to-create-a-known-user-group"></a><span data-ttu-id="9b74e-110">既知のユーザー グループを作成するには</span><span class="sxs-lookup"><span data-stu-id="9b74e-110">To create a known user group</span></span>

1. <span data-ttu-id="9b74e-111">Windows デベロッパー センター ダッシュボードで、左側のナビゲーション メニューの **[Engage] (関心を引く)** を展開して、**[ユーザー グループ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-111">In the Windows Dev Center dashboard, expand **Engage** in the left navigation menu and then select **Customer groups**.</span></span> 
2. <span data-ttu-id="9b74e-112">**[自分のユーザー グループ]** セクションで、**[新しいグループの作成]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-112">In the **My customer groups** section, select **Create new group**.</span></span>
3. <span data-ttu-id="9b74e-113">次のページで、**[グループ名]** にグループの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="9b74e-113">On the next page, enter a name for your group in the **Group name** box.</span></span>
4. <span data-ttu-id="9b74e-114">**[既知のユーザー グループ]** ラジオ ボタンがオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9b74e-114">Ensure that the **Known user group** radio button is selected.</span></span>
5. <span data-ttu-id="9b74e-115">グループに追加するユーザーの電子メール アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="9b74e-115">Enter the email addresses of the people you'd like to add to the group.</span></span> <span data-ttu-id="9b74e-116">少なくとも 1 つのメール アドレスを設定してください。最大で 10,000 件まで設定できます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-116">You must include at least one email address, with a maximum of 10,000.</span></span> <span data-ttu-id="9b74e-117">メール アドレスは、フィールドに直接入力することができます (スペース、コンマ、セミコロン、または改行で区切ります)。または、**[インポート (.csv)]** リンクをクリックし、.csv ファイル形式のメール アドレスの一覧からフライト グループを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-117">You can enter email addresses directly into the field (separated by spaces, commas, semicolons, or line breaks), or you can click the **Import .csv** link to create the flight group from a list of email addresses in a .csv file.</span></span>
6. <span data-ttu-id="9b74e-118">**[保存]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-118">Select **Save**.</span></span>

<span data-ttu-id="9b74e-119">これで、グループを使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="9b74e-119">The group will now be available for you to use.</span></span>

<span data-ttu-id="9b74e-120">また、[package flight](package-flights.md)を作成するページで **[フライト グループを作成する]** を選んで、既知のユーザー グループを作ることもできます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-120">You can also create a known user group by selecting **Create a flight group** from the [package flight](package-flights.md) creation page.</span></span> <span data-ttu-id="9b74e-121">パッケージ フライトの作成ページで既に入力した情報をもう一度入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b74e-121">Note that you'll need to re-enter any info you've already provided in the package flight creation page if you do this.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9b74e-122">パッケージ フライトで既知のユーザー グループを使う場合は、必ず、フライト グループに追加するユーザーから必要な同意をすべて得てください。また、フライト以外の申請とは異なるパッケージを入手するようになることをそれらのユーザーが理解していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="9b74e-122">When using known user groups with package flighting, be sure that you have obtained any necessary consent from people that you add to your group, and that they understand that they will be getting packages that are different from your non-flighted submission.</span></span> 

## <a name="to-edit-a-known-user-group"></a><span data-ttu-id="9b74e-123">既知のユーザー グループを編集するには</span><span class="sxs-lookup"><span data-stu-id="9b74e-123">To edit a known user group</span></span>

<span data-ttu-id="9b74e-124">既知のユーザー グループは作成されると、ダッシュボードから削除 (や名前の変更) を行うことはできませんが、いつでもメンバーシップは編集できます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-124">You cannot remove a known user group from your dashboard (or change its name) after it's been created, but you can edit its membership at any time.</span></span>

<span data-ttu-id="9b74e-125">既知のユーザー グループを確認および編集するには、左側のナビゲーション メニューの **[Engage] (関心を引く)** メニューを展開し、ダッシュボードの上部付近の **[ユーザー グループ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-125">To review and edit your known user groups, expand the **Engage** menu in the left navigation menu and select **Customer groups**.</span></span> <span data-ttu-id="9b74e-126">**[自分のユーザー グループ]** で、編集するグループの名前を選びます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-126">Under **My customer groups**, select the name of the group you want to edit.</span></span> <span data-ttu-id="9b74e-127">また、パッケージ フライトの作成ページで新しいフライトの作成時に **[既存のグループを表示および管理]** を選ぶか、パッケージ フライトの概要ページでグループの名前を選んでも、既知のユーザー グループを編集できます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-127">You can also edit a known user group from the package flight creation page by selecting **View and manage existing groups** when creating a new flight, or by selecting the group's name from a package flight's overview page.</span></span> 

<span data-ttu-id="9b74e-128">編集するグループを選ぶと、フィールドに直接メール アドレスを追加または削除できます。</span><span class="sxs-lookup"><span data-stu-id="9b74e-128">After you've selected the group you want to edit, you can add or remove email addresses directly in the field.</span></span>

<span data-ttu-id="9b74e-129">大幅に変更する場合は、**[エクスポート (.csv)]** を選んで、グループ メンバーシップ情報を .csv ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="9b74e-129">For larger changes, select **Export .csv** to save your group membership info to a .csv file.</span></span> <span data-ttu-id="9b74e-130">このファイルに必要な変更を加えた後、**[インポート (.csv)]** をクリックし、新しいバージョンを使ってグループのメンバーシップを更新します。</span><span class="sxs-lookup"><span data-stu-id="9b74e-130">Make your changes in this file, then click **Import .csv** to use the new version to update the group membership.</span></span>

<span data-ttu-id="9b74e-131">メンバーシップの変更内容が反映されるまで最大 30 分かかる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9b74e-131">Note that it may take up to 30 minutes for membership changes to be implemented.</span></span> <span data-ttu-id="9b74e-132">新しいグループ メンバーがパッケージ フライトやプライベート対象ユーザーを通じて申請にアクセスするために、新しい申請を公開する必要はありません。変更が実装されるとすぐにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="9b74e-132">You don't need to publish a new submission in order for new group members to be able to access your submission through package flights or private audience; they will have access as soon as the changes are implemented.</span></span> 






