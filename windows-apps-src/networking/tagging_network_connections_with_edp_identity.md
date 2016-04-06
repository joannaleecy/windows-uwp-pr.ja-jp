---
Description: 'This topic shows how to create a protected thread context before creating network connections in an enterprise data protection (EDP) scenario.'
MS-HAID: 'dev\_networking.tagging\_network\_connections\_with\_edp\_identity'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: Tagging network connections with EDP identity
---

# Tagging network connections with EDP identity

__Note__ Enterprise data protection (EDP) policy cannot be applied on Windows 10, Version 1511 (build 10586) or earlier.

This topic shows how to create a protected thread context before creating network connections in an enterprise data protection (EDP) scenario. For the full developer picture of how EDP relates to files, streams, the clipboard, networking, background tasks, and data protection under lock, see [enterprise data protection (EDP)](../enterprise/edp-hub.md).

**Note**  The [enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409) covers many EDP scenarios.



## Prerequisites


-   **Get set up for EDP**

    See [Set up your computer for EDP](../enterprise/edp-hub.md#set-up-your-computer-for-EDP).

-   **Commit to building an enterprise-enlightened app**

    An app that autonomously ensures that enterprise data stays under the managing enterprise’s control is known as an enterprise-enlightened app. An enlightened app is more powerful, smart, flexible, and trusted than an unenlightened one. Your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. There's more to being enlightened than setting a capability, though. To learn more, see [Enterprise-enlightened apps](../enterprise/edp-hub.md#enterprise-enlightened-apps).

-   **Understand async programming for Universal Windows Platform (UWP) apps**

    To learn about how to write asynchronous apps in C\# or Visual Basic, see [Call asynchronous APIs in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337). To learn about how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).

## Accessing enterprise resources over the network


In this scenario, an enlightened mail app is synchronizing a set of mailboxes that are a mixture of both enterprise and personal mailboxes. The app passes the user's identity to a call to [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706025) to create a protected thread context. This tags all network connections that are made subsequently on the same thread with that identity, and allows access to enterprise network resources that are access-controlled by the enterprise’s policy.

Here, "the enterprise" refers to the enterprise that the user identity belongs to. [**CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706025) returns a [**ThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706029) object irrespective of policy enforcement. Generally, if the app expects to handle mixed resources, it can choose to call **CreateCurrentThreadNetworkContext** for all identities. After retrieving network resources, the app calls **Dispose** on the **ThreadNetworkContext** to clear any identity tag from the current thread. The pattern you use for disposing the context object will depend on your programming language.

If the identity is unknown, the app can query the enterprise-policy-managed identity from the network address of the resource using the [**ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync**](https://msdn.microsoft.com/library/windows/apps/dn706027) API.

**Note**  As you can see in the code example, the correct usage pattern for [**CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706025) is to keep to a minimum the scope in which it is in effect. You should set enterprise network context, create network connections, then revert the context, use the connections and then close them. The code example below illustrates the details. It is important that you not create files on a thread while enterprise network context is set on that thread. Doing so will cause the file to be automatically encrypted regardless of whether your intention is for the file to be personal. This is one of the reasons we recommend reverting the context as early as possible.



```CSharp
using Windows.Data.Xml.Dom;
using Windows.Networking;
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;
using Windows.Web.Http;

...

public static async void SyncMailbox(string identity)
{
    HttpClient client = null;
    // Create a protected network context for "identity" on the current
    // thread. Network connections made after this call will be tagged
    // to "identity", and will have policy enforced. This is required
    // to access enterprise network resources for "identity".
    using (ThreadNetworkContext threadNetworkContext = 
        ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        // Retrieve new mail.
        client = new HttpClient();
    }

    string xmlResponse = await client.GetStringAsync
        (new Uri("https://contosomail/getnewmail?user=" + identity));

    // Now, process mail data received.
    var xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(xmlResponse);
    foreach (IXmlNode mailNode in xmlDocument.GetElementsByTagName("mail"))
    {
        // Code to process text data in mail (body, recipients etc.)
        // would go here ...

        // Processes resource links in mail body.
        foreach (IXmlNode childNode in mailNode.ChildNodes)
        {
            if (childNode.NodeName == "resource")
            {
                var resourceUri = new Uri(childNode.InnerText);

                // Check if the resource is on an enterprise-managed endpoint.
                string resourceIdentity =
                    await ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync
                        (new HostName(resourceUri.Host));
                if (!string.IsNullOrEmpty(resourceIdentity))
                {
                    using (ThreadNetworkContext threadNetworkContext =
                        ProtectionPolicyManager.CreateCurrentThreadNetworkContext(resourceIdentity))
                    {
                        client = new HttpClient();
                    }
                    IBuffer data = await client.GetBufferAsync(resourceUri);
                    // Code to process retrieved resource data would go here...
                }
            }
        }
    }
}
```

**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).



## Related topics


[enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData namespace**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 





<!--HONumber=Mar16_HO5-->


