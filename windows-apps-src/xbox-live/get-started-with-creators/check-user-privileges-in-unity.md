---
title: "Unity でユーザー特権の設定を確認する"
author: StaceyHaffner
description: "ログイン済みの Xbox Live アカウントに設定された特権の確認方法を説明します。"
ms.assetid: 
ms.author: sthaff
ms.date: 10/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP. Windows 10, Xbox One, アカウント, テスト アカウント, 保護者による制限, ユーザー特権, Enforcement チームによる禁止, アップセル"
ms.openlocfilehash: 45c5785899dcdda596fe66bb76930a781d50b77d
ms.sourcegitcommit: d5f74029f9844603914e8e46a8d4dfe078c2a90a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2017
---
# <a name="check-user-privilege-settings-in-unity"></a><span data-ttu-id="a40f2-104">Unity でユーザー特権の設定を確認する</span><span class="sxs-lookup"><span data-stu-id="a40f2-104">Check user privilege settings in Unity</span></span>
<span data-ttu-id="a40f2-105">Xbox Live では、すべての認証済みユーザーのアカウントに特権が関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="a40f2-105">On Xbox Live, every authenticated user’s account has associated privileges.</span></span> <span data-ttu-id="a40f2-106">特権によって、任意の時点でユーザーがアクセスできる Xbox Live の機能が制御されます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-106">Privileges control which features of Xbox Live a user can access at a given point in time.</span></span> <span data-ttu-id="a40f2-107">システムで制御される機能に関する特権もあれば、特定のゲームやサブスクリプション レベルでのみ利用できる特権もあります。</span><span class="sxs-lookup"><span data-stu-id="a40f2-107">Some of these privileges are for system-controlled features, while others may be associated with specific games or extension subscriptions.</span></span> <span data-ttu-id="a40f2-108">さらに、保護者による制限や Xbox Live Enforcement チームによる禁止措置によって、ユーザー特権が制限されることもあります。</span><span class="sxs-lookup"><span data-stu-id="a40f2-108">In addition, parental controls and bans issued by the Xbox Live enforcement team can restrict the privileges of a user.</span></span> <span data-ttu-id="a40f2-109">これらの特権は、マルチプレイヤー、ユーザー作成コンテンツへのアクセス、チャット、ストリーミング ビデオなど、数多くの一般的なシナリオを対象としています。</span><span class="sxs-lookup"><span data-stu-id="a40f2-109">These privileges cover a number of common scenarios, including multiplayer, accessing user generated content, chatting, or to streaming video.</span></span> <span data-ttu-id="a40f2-110">ゲームでは、この情報を使用してアクセス制御とカスタマイズの判断を行います。</span><span class="sxs-lookup"><span data-stu-id="a40f2-110">Games use this information to make access control and personalization decisions.</span></span> 

## <a name="prerequisites"></a><span data-ttu-id="a40f2-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="a40f2-111">Prerequisites</span></span>
<span data-ttu-id="a40f2-112">ユーザー特権の設定を判断するには、Xbox Live での認証に対応するようにゲームを構成し、ユーザーのサインインを適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a40f2-112">In order to determine user privilege settings, you must have configured your game for authentication with Xbox Live and successfully signed a user in.</span></span> <span data-ttu-id="a40f2-113">これらの手順の概要は、次の記事で説明されています。</span><span class="sxs-lookup"><span data-stu-id="a40f2-113">The following articles outline the steps that you can take:</span></span>

* [<span data-ttu-id="a40f2-114">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="a40f2-114">Configure Xbox Live in Unity</span></span>](check-user-privileges-in-unity.md)
* [<span data-ttu-id="a40f2-115">Unity で Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="a40f2-115">Sign in to Xbox Live in Unity</span></span>](sign-in-to-xbox-live-in-unity.md)

## <a name="determine-privileges"></a><span data-ttu-id="a40f2-116">特権の判断</span><span class="sxs-lookup"><span data-stu-id="a40f2-116">Determine privileges</span></span>
<span data-ttu-id="a40f2-117">ユーザーの特権は、認証時に受け取るトークンによって伝達されます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-117">A user’s privileges are carried in the token received at authentication time.</span></span> <span data-ttu-id="a40f2-118">Unity では、ユーザーが正常にサインインした後、ユーザーが持つ特権の一覧に `XboxLiveUser` クラスでアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-118">In Unity, you can access the list of privileges that a user has in the `XboxLiveUser` class, after the user has successfully signed in.</span></span> <span data-ttu-id="a40f2-119">特権は、スペースで区切られた 1 つの文字列として保存されています。</span><span class="sxs-lookup"><span data-stu-id="a40f2-119">Privileges are stored as a single string, separated by a space.</span></span> <span data-ttu-id="a40f2-120">たとえば、ユーザーには、次のような形式で特権が設定されています。</span><span class="sxs-lookup"><span data-stu-id="a40f2-120">For example, you might see a user with the following privileges:</span></span>

```csharp
public XboxLiveUserInfo XboxLiveUser;

//sign in is done and the user has been successfully signed in

Debug.Log(XboxLiveUser.User.Privileges);

//Console would read:
// Privileges: "188 191 192 193 194 195 196 198 199 200 201 203 204 205 206 207 208 211 214 215 216 217 220 224 227 228 235 238 245 247 249 252 254 255"
```

<span data-ttu-id="a40f2-121">特定のアクセス許可について判断する場合は、`Privileges` プロパティにそれに関連するコードが含まれているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="a40f2-121">If you want to look for a specific permission, you can check to see if the `Privileges` property contains the associated code:</span></span>

```csharp
public XboxLiveUserInfo XboxLiveUser;

//sign in is done and the user has been successfully signed in

if (XboxLiveUser.User.Privileges.Contains("247"))
{
    Debug.Log("User has the user_created_content privilege");
}
```

## <a name="privilege-codes"></a><span data-ttu-id="a40f2-122">特権コード</span><span class="sxs-lookup"><span data-stu-id="a40f2-122">Privilege Codes</span></span>
<span data-ttu-id="a40f2-123">次の一覧に、返される特権コードを示します。</span><span class="sxs-lookup"><span data-stu-id="a40f2-123">The following is a list of possible privilege codes that may be returned.</span></span>

| <span data-ttu-id="a40f2-124">コード</span><span class="sxs-lookup"><span data-stu-id="a40f2-124">Code</span></span>  | <span data-ttu-id="a40f2-125">特権</span><span class="sxs-lookup"><span data-stu-id="a40f2-125">Privilege</span></span>  | <span data-ttu-id="a40f2-126">説明</span><span class="sxs-lookup"><span data-stu-id="a40f2-126">Description</span></span>   |
|------ |-----------------------------  |-------------------    |
| <span data-ttu-id="a40f2-127">190</span><span class="sxs-lookup"><span data-stu-id="a40f2-127">190</span></span>   | <span data-ttu-id="a40f2-128">broadcast</span><span class="sxs-lookup"><span data-stu-id="a40f2-128">broadcast</span></span>             | <span data-ttu-id="a40f2-129">ライブ ゲームプレイを配信できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-129">Can broadcast live game play.</span></span>     |
| <span data-ttu-id="a40f2-130">197</span><span class="sxs-lookup"><span data-stu-id="a40f2-130">197</span></span>   | <span data-ttu-id="a40f2-131">view_friends_list</span><span class="sxs-lookup"><span data-stu-id="a40f2-131">view_friends_list</span></span>     | <span data-ttu-id="a40f2-132">他のユーザーのフレンド リストを表示できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-132">Can view other user's friends list.</span></span>   |
| <span data-ttu-id="a40f2-133">198</span><span class="sxs-lookup"><span data-stu-id="a40f2-133">198</span></span>   | <span data-ttu-id="a40f2-134">game_dvr</span><span class="sxs-lookup"><span data-stu-id="a40f2-134">game_dvr</span></span>              | <span data-ttu-id="a40f2-135">記録したゲーム内ビデオをクラウドにアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-135">Can upload recorded in-game videos to the cloud.</span></span>      |
| <span data-ttu-id="a40f2-136">199</span><span class="sxs-lookup"><span data-stu-id="a40f2-136">199</span></span>   | <span data-ttu-id="a40f2-137">share_kinect_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-137">share_kinect_content</span></span>          | <span data-ttu-id="a40f2-138">Kinect で記録されたコンテンツをクラウドにアップロードして、だれでもアクセスできるように提供できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-138">Kinect recorded content can be uploaded to the cloud for the user and made accessible to anyone.</span></span> |
| <span data-ttu-id="a40f2-139">203</span><span class="sxs-lookup"><span data-stu-id="a40f2-139">203</span></span>   | <span data-ttu-id="a40f2-140">multiplayer_parties</span><span class="sxs-lookup"><span data-stu-id="a40f2-140">multiplayer_parties</span></span>           | <span data-ttu-id="a40f2-141">パーティー セッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-141">Can join a party session.</span></span>     |
| <span data-ttu-id="a40f2-142">205</span><span class="sxs-lookup"><span data-stu-id="a40f2-142">205</span></span>   | <span data-ttu-id="a40f2-143">communication_voice_ingame</span><span class="sxs-lookup"><span data-stu-id="a40f2-143">communication_voice_ingame</span></span>    | <span data-ttu-id="a40f2-144">パーティー時およびマルチプレイヤー ゲーム セッション時にボイス チャットに参加できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-144">Can participate in voice chat during parties and multiplayer game sessions.</span></span>    |
| <span data-ttu-id="a40f2-145">206</span><span class="sxs-lookup"><span data-stu-id="a40f2-145">206</span></span>   | <span data-ttu-id="a40f2-146">communication_voice_skype</span><span class="sxs-lookup"><span data-stu-id="a40f2-146">communication_voice_skype</span></span>     | <span data-ttu-id="a40f2-147">Xbox One 上で Skype を使って音声によるコミュニケーションができます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-147">Can use voice communication with Skype on Xbox One.</span></span>   |
| <span data-ttu-id="a40f2-148">207</span><span class="sxs-lookup"><span data-stu-id="a40f2-148">207</span></span>   | <span data-ttu-id="a40f2-149">cloud_gaming_manage_session</span><span class="sxs-lookup"><span data-stu-id="a40f2-149">cloud_gaming_manage_session</span></span>   | <span data-ttu-id="a40f2-150">ホストされたゲーム セッション用にクラウド コンピューティング クラスターを割り当てて管理できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-150">Can allocate and manage a cloud compute cluster for a hosted game session.</span></span>    |
| <span data-ttu-id="a40f2-151">208</span><span class="sxs-lookup"><span data-stu-id="a40f2-151">208</span></span>   | <span data-ttu-id="a40f2-152">cloud_gaming_join_session</span><span class="sxs-lookup"><span data-stu-id="a40f2-152">cloud_gaming_join_session</span></span>     | <span data-ttu-id="a40f2-153">クラウド コンピューティング セッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-153">Can join a cloud compute session.</span></span>     |
| <span data-ttu-id="a40f2-154">209</span><span class="sxs-lookup"><span data-stu-id="a40f2-154">209</span></span>   | <span data-ttu-id="a40f2-155">cloud_saved_games</span><span class="sxs-lookup"><span data-stu-id="a40f2-155">cloud_saved_games</span></span>     | <span data-ttu-id="a40f2-156">クラウド タイトル ストレージにゲームを保存できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-156">Can save games in cloud title storage.</span></span>    |
| <span data-ttu-id="a40f2-157">211</span><span class="sxs-lookup"><span data-stu-id="a40f2-157">211</span></span>   | <span data-ttu-id="a40f2-158">share_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-158">share_content</span></span>     | <span data-ttu-id="a40f2-159">他のユーザーにコンテンツを公開できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-159">Can share content with others.</span></span>    |
| <span data-ttu-id="a40f2-160">214</span><span class="sxs-lookup"><span data-stu-id="a40f2-160">214</span></span>   | <span data-ttu-id="a40f2-161">premium_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-161">premium_content</span></span>   | <span data-ttu-id="a40f2-162">Xbox Live ゴールド サブスクリプションで提供されている有料コンテンツを購入、ダウンロード、起動できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-162">Can purchase, download and launch premium content available with the Xbox Live Gold subscription.</span></span>     |
| <span data-ttu-id="a40f2-163">219</span><span class="sxs-lookup"><span data-stu-id="a40f2-163">219</span></span>   | <span data-ttu-id="a40f2-164">subscription_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-164">subscription_content</span></span>  | <span data-ttu-id="a40f2-165">プレミアム サブスクリプション コンテンツを購入およびダウンロードしたり、プレミアム サブスクリプション機能を利用したりできます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-165">Can purchase and download premium subscription content and use premium subscription features.</span></span>     |
| <span data-ttu-id="a40f2-166">220</span><span class="sxs-lookup"><span data-stu-id="a40f2-166">220</span></span>   | <span data-ttu-id="a40f2-167">social_network_sharing</span><span class="sxs-lookup"><span data-stu-id="a40f2-167">social_network_sharing</span></span>    | <span data-ttu-id="a40f2-168">進行状況の情報をソーシャル ネットワーク上で公開できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-168">Can share progress information on social networks.</span></span>    |
| <span data-ttu-id="a40f2-169">224</span><span class="sxs-lookup"><span data-stu-id="a40f2-169">224</span></span>   | <span data-ttu-id="a40f2-170">premium_video</span><span class="sxs-lookup"><span data-stu-id="a40f2-170">premium_video</span></span>     | <span data-ttu-id="a40f2-171">プレミアム ビデオ サービスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-171">Can access premium video services.</span></span>    |
| <span data-ttu-id="a40f2-172">235</span><span class="sxs-lookup"><span data-stu-id="a40f2-172">235</span></span>   | <span data-ttu-id="a40f2-173">purchase_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-173">purchase_content</span></span>  | <span data-ttu-id="a40f2-174">コンテンツを購入できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-174">Can purchase content.</span></span>     |
| <span data-ttu-id="a40f2-175">247</span><span class="sxs-lookup"><span data-stu-id="a40f2-175">247</span></span>   | <span data-ttu-id="a40f2-176">user_created_content</span><span class="sxs-lookup"><span data-stu-id="a40f2-176">user_created_content</span></span>  | <span data-ttu-id="a40f2-177">オンラインのユーザー作成コンテンツをダウンロードおよび表示できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-177">Can download and view online user created content.</span></span>    |
| <span data-ttu-id="a40f2-178">249</span><span class="sxs-lookup"><span data-stu-id="a40f2-178">249</span></span>   | <span data-ttu-id="a40f2-179">profile_viewing</span><span class="sxs-lookup"><span data-stu-id="a40f2-179">profile_viewing</span></span>   | <span data-ttu-id="a40f2-180">他のユーザーのプロフィールを表示できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-180">Can view other user's profiles.</span></span>   |
| <span data-ttu-id="a40f2-181">252</span><span class="sxs-lookup"><span data-stu-id="a40f2-181">252</span></span>   | <span data-ttu-id="a40f2-182">communications</span><span class="sxs-lookup"><span data-stu-id="a40f2-182">communications</span></span>    | <span data-ttu-id="a40f2-183">だれとでもテキスト メッセージングを利用できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-183">Can use asynchronous text messaging with anyone.</span></span>    |
| <span data-ttu-id="a40f2-184">254</span><span class="sxs-lookup"><span data-stu-id="a40f2-184">254</span></span>   | <span data-ttu-id="a40f2-185">multiplayer_sessions</span><span class="sxs-lookup"><span data-stu-id="a40f2-185">multiplayer_sessions</span></span>  | <span data-ttu-id="a40f2-186">ゲームのマルチプレイヤー セッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-186">Can join a multiplayer sessions for a game.</span></span>   |
| <span data-ttu-id="a40f2-187">255</span><span class="sxs-lookup"><span data-stu-id="a40f2-187">255</span></span>   | <span data-ttu-id="a40f2-188">add_friend</span><span class="sxs-lookup"><span data-stu-id="a40f2-188">add_friend</span></span>    | <span data-ttu-id="a40f2-189">他の Xbox Live ユーザーをフォローでき、Xbox Live フレンドを追加できます。</span><span class="sxs-lookup"><span data-stu-id="a40f2-189">Can follow other Xbox Live users and add Xbox Live friends.</span></span>   |
 
