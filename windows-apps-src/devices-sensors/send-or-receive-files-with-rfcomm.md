---
xx.xxxxxxx: YXYXYYYY-YYXX-YYYY-XXYX-XYXYXXYYYYXX
xxxxx: Xxxxxxxxx XXXXXX
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xx xxxxxxxx xx Xxxxxxxxx XXXXXX xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxxx xxxx xxxxxxx xxxx xx xxx xx xxxx xx xxxxxxx x xxxx.
---
# Xxxxxxxxx XXXXXX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263529)

Xxxx xxxxxxx xxxxxxxx xx xxxxxxxx xx Xxxxxxxxx XXXXXX xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxxx xxxx xxxxxxx xxxx xx xxx xx xxxx xx xxxxxxx x xxxx..

## Xxxxxxxx

Xxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263529) xxxxxxxxx xxxxx xx xxxxxxxx xxxxxxxx xxx Xxxxxxx.Xxxxxxx, xxxxxxxxx [**xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225459) xxx [**xxxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225654). Xxxx xxxxxxx xxx xxxxxxx xx xxxxxxxx xx xxxx xxxxxxxxx xx [**xxxxxxxxxxx xxxx xxxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208119) xxx xxxxxxx xx [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR241791). Xxxxxxx Xxxxxxxxxxx Xxxxxxxx (XXX) xxxxxxxxxx xxxx x xxxxx xxx xx xxxxxxxx xxxx. Xxxxxxx, xxxx xxxxxx xxxxxxx xxxx xxxxxx xxxxxxxxxxxxxxx xx XXX xxxxxxxxxx xxxxx xxx xxxxx xx xxx xx xxx xxxxxxxx xxxx. Xxxxxxxxxxxx, xxxx xxxxxx xx XXXXXX xx xxx xxxxxxx xxxxxxxxxx XXX xxxxxxxxxx xx xxx. Xxx xxxxx xxxxxxx, xxxx XXX xxxxxx xxxxxx xx xxx xxxxxxxx XXX xxxx, xxxx xxxxx xxxxxxxxxx xxx xxxxxx xxx xxxxxxxxxxx xxxx xxxx.

Xxx XXXXXX XXXx xxx xxx xxxxxxx xx xxxxxxx xxxxxxxxxxx. Xxxxxxxx x xxxxxxx xxxxxxxxxx xx xxxxxx x YYY-xxx XXXX, xx xx xxxx xxxxxxxx xxxxxxxxx xx xxxxxx x YY- xx YY-xxx xxxxxxx. Xxx XXXXXX XXX xxxxxx x xxxxxxx xxx xxxxxxx xxxxxxxxxxx xxxx xxxxxx xxxx xx xxxxxxxxx xxx xxxxxxxx xx YYY-xxx XXXXx xx xxxx xx YY-xxx xxxxxxxx xxx xxxx xxx xxxxx YY-xxx xxxxxxxx. Xxxx xx xxx xx xxxxx xxx xxx XXX xxxxxxx xxxxxxxxx xxxx xxxxxxxxxxxxx xxxxxx xx x YY-xxx xxxxxxx xxx xxx xxxxxxxxxx xxx xxxxx xx xxxxxxxxx xxxxxxxxx.

Xxxx xxx xxxxxxx xxxxx-xxxx xxxxxx xxxxxxxxxx xx x xxxxxxxxxx xxxx xx xxxx xxxx xxx xxx xx xxxxxxxxxx xxxx xx xxx xxx xx xxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxx. Xxxx xxxxxx xxx xxxxxxxx xxxxxx xxxxxxxxx xxxx xx xxxxxxx xx xxxxxxxxxx xxxxxxxx xx xxxxxxxx, xxx xxxxxxx xxxxxxxxxxxxxxx, xxxxxxx xxxxxxxxx xxx xxxx xx xxx xxx xxxxx x xxxxxxxx xxx. Xxx xxx [**XxxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297315) xxx xxxxxx xxxxxxxxx xxx xxx [**XxxxxxXxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297337) xxx xxxxxxx xxxxxxxxxxxxxxx. Xxxx xxxx xxxxx xxxxxxxxxx xxxxx xxxxxxxxx xxx xxxxxx xx xxxx xxx xxx xxx xxx xx xxx xxxxxxxxxx, xxx xxx xxx xxxxxxxx xx xxxxx xxxxxxxxxx xxxxxxxxx xx xxxxxxxx xxxxxxxxxxxxxxx.

## Xxxx x xxxx xx x xxxxxx

Xxxx xxxxxxx x xxxx, xxx xxxx xxxxx xxxxxxxx xx xx xxxxxxx xx x xxxxxx xxxxxx xxxxx xx x xxxxxxx xxxxxxx. Xxxx xxxxxxxx xxx xxxxxxxxx xxxxx:

-   Xxx xxx **XxxxxxXxxxxxXxxxxxx.XxxXxxxxxXxxxxxxx\*** xxxxxxxxx xx xxxx xxxxxxxx xx XXX xxxxx xxxx xxx xx xxxx xx xxxxxxxxxx xxxxxx xxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxxxx.
-   Xxxx xx xxxxxxxxxx xxxxxx, xxxxxx xx [**XxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263463), xxx xxxx xxx XXX xxxxxxxxxx xx xxxxxx (xxxxx [**xxxxxxxxxxx xxxx xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208119) xx xxxxx xxx xxxxxxxxx'x xxxx).
-   Xxxxxx x xxxxxx xxx xxx xxx [**XxxxxxXxxxxxXxxxxxx.XxxxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionhostname.aspx) xxx [**XxxxxxXxxxxxXxxxxxx.XxxxxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.bluetooth.rfcomm.rfcommdeviceservice.connectionservicename.aspx) xxxxxxxxxx xx [**XxxxxxXxxxxx.XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701504) xx xxx xxxxxx xxxxxx xxxxxxx xxxx xxx xxxxxxxxxxx xxxxxxxxxx.
-   Xxxxxx xxxxxxxxxxx xxxx xxxxxx xxxxxxxx xx xxxx xxxxxx xx xxxx xxxx xxx xxxx xxx xxxx xx xx xxx xxxxxx'x [**XxxxxxXxxxxx.XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226920) xx xxx xxxxxx.

```csharp
Windows.Devices.Bluetooth.RfcommDeviceService _service;
Windows.Networking.Sockets.StreamSocket _socket;

async void Initialize()
{
    // Enumerate devices with the object push service
    auto services =
        await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(
            RfcommDeviceService.GetDeviceSelector(
                RfcommServiceId.ObexObjectPush));

    if (services.Count > 0) 
    {
        // Initialize the target Bluetooth BR device
        auto service = await RfcommDeviceService.FromIdAsync(services[0].Id);

        // Check that the service meets this App’s minimum requirement
        if (SupportsProtection(service) &amp;&amp; IsCompatibleVersion(service))
        {
            _service = service;

            // Create a socket and connect to the target
            _socket = new StreamSocket();
            await _socket.ConnectAsync(
                _service.ConnectionHostName,
                _service.ConnectionServiceName,
                SocketProtectionLevel
                    .BluetoothEncryptionAllowNullAuthentication);

            // The socket is connected. At this point the App can wait for
            // the user to take some action, e.g. click a button to send a
            // file to the device, which could invoke the Picker and then
            // send the picked file. The transfer itself would use the
            // Sockets API and not the Rfcomm API, and so is omitted here for
            // brevity.
        }
    }
}

// This App requires a connection that is encrypted but does not care about
// whether its authenticated.
bool SupportsProtection(RfcommDeviceService service)
{
    switch (service.ProtectionLevel)
    {
    case SocketProtectionLevel.PlainSocket:
        if ((service.MaximumProtectionLevel == SocketProtectionLevel
                .BluetoothEncryptionWithAuthentication)
            || (service.MaximumProtectionLevel == SocketProtectionLevel
                .BluetoothEncryptionAllowNullAuthentication)
        {
            // The connection can be upgraded when opening the socket so the
            // App may offer UI here to notify the user that Windows may
            // prompt for a PIN exchange.
            return true;
        }
        else
        {
            // The connection cannot be upgraded so an App may offer UI here
            // to explain why a connection won’t be made.
            return false;
        }
    case SocketProtectionLevel.BluetoothEncryptionWithAuthentication:
        return true;
    case SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication:
        return true;
    }
    return false;
}

// This App relies on CRC32 checking available in version 2.0 of the service.
const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint MINIMUM_SERVICE_VERSION = 200;
bool IsCompatibleVersion(RfcommDeviceService service)
{
    auto attributes = await service.GetSdpRawAttributesAsync(
        BluetothCacheMode.Uncached);
    auto attribute = attributes[SERVICE_VERSION_ATTRIBUTE_ID];
    auto reader = DataReader.FromBuffer(attribute);

    // The first byte contains the attribute' s type
    byte attributeType = reader.ReadByte();
    if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
    {
        // The remainder is the data
        uint version = reader.Uint32();
        return version >= MINIMUM_SERVICE_VERSION;
    }
}
```

```cpp
Windows::Devices::Bluetooth::RfcommDeviceService^ _service;
Windows::Networking::Sockets::StreamSocket^ _socket;

void Initialize()
{
    // Enumerate devices with the object push service
    create_task(
        Windows::Devices::Enumeration::DeviceInformation::FindAllAsync(
            RfcommDeviceService::GetDeviceSelector(
                RfcommServiceId::ObexObjectPush)))
    .then([](DeviceInformationCollection^ services)
    {
        if (services->Size > 0) 
        {
            // Initialize the target Bluetooth BR device
            create_task(RfcommDeviceService::FromIdAsync(services[0]->Id))
            .then([](RfcommDeviceService^ service)
            {
                // Check that the service meets this App’s minimum
                // requirement
                if (SupportsProtection(service)
                    &amp;&amp; IsCompatibleVersion(service))
                {
                    _service = service;

                    // Create a socket and connect to the target
                    _socket = ref new StreamSocket();
                    create_task(_socket->ConnectAsync(
                        _service->ConnectionHostName,
                        _service->ConnectionServiceName,
                        SocketProtectionLevel
                            ::BluetoothEncryptionAllowNullAuthentication)
                    .then([](void)
                    {
                        // The socket is connected. At this point the App can
                        // wait for the user to take some action, e.g. click
                        // a button to send a file to the device, which could
                        // invoke the Picker and then send the picked file.
                        // The transfer itself would use the Sockets API and
                        // not the Rfcomm API, and so is omitted here for
                        //brevity.
                    });
                }
            });
        }
    });
}

// This App requires a connection that is encrypted but does not care about
// whether its authenticated.
bool SupportsProtection(RfcommDeviceService^ service)
{
    switch (service->ProtectionLevel)
    {
    case SocketProtectionLevel->PlainSocket:
        if ((service->MaximumProtectionLevel == SocketProtectionLevel
                ::BluetoothEncryptionWithAuthentication)
            || (service->MaximumProtectionLevel == SocketProtectionLevel
                ::BluetoothEncryptionAllowNullAuthentication)
        {
            // The connection can be upgraded when opening the socket so the
            // App may offer UI here to notify the user that Windows may
            // prompt for a PIN exchange.
            return true;
        }
        else
        {
            // The connection cannot be upgraded so an App may offer UI here
            // to explain why a connection won’t be made.
            return false;
        }
    case SocketProtectionLevel::BluetoothEncryptionWithAuthentication:
        return true;
    case SocketProtectionLevel::BluetoothEncryptionAllowNullAuthentication:
        return true;
    }
    return false;
}

// This App relies on CRC32 checking available in version 2.0 of the service.
const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint MINIMUM_SERVICE_VERSION = 200;
bool IsCompatibleVersion(RfcommDeviceService^ service)
{
    auto attributes = await service->GetSdpRawAttributesAsync(
        BluetoothCacheMode::Uncached);
    auto attribute = attributes[SERVICE_VERSION_ATTRIBUTE_ID];
    auto reader = DataReader.FromBuffer(attribute);

    // The first byte contains the attribute' s type
    byte attributeType = reader->ReadByte();
    if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
    {
        // The remainder is the data
        uint version = reader->Uint32();
        return version >= MINIMUM_SERVICE_VERSION;
    }
}
```

## Xxxxxxx Xxxx xx x Xxxxxx

Xxxxxxx xxxxxx XXXXXX Xxx xxxxxxxx xx xx xxxx x xxxxxxx xx xxx XX xxx xxxxxx xx xxx xxxxx xxxxxxx.

-   Xxxxxx x [**XxxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263511) xx xxxxxxxxx xxx xxxxxxx xxxxxxx.
-   Xxx xxx XXX xxxxxxxxxx xx xxxxxx (xxxxx [**xxxxxxxxxxx xxxx xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208119) xx xxxxxxxx xxx xxxxxxxxx’x Xxxx) xxx xxxxxx xxxxxxxxxxx xxx XXX xxxxxxx xxx xxxxx xxxxxxx xx xxxxxxxx.
-   Xx xxxxxxx xx x xxxxxx xxxxxx, xxxxxx x xxxxxx xxxxxxxx xx xxxxx xxxxxxxxx xxx xxxxxxxx xxxxxxxxxx xxxxxxxx.
-   Xxxx x xxxxxxxxxx xx xxxxxxxx, xxxxx xxx xxxxxxxxx xxxxxx xxx xxxxx xxxxxxxxxx.
-   Xxxxxx xxxxxxxxxxx xxxx xxxxxx xxxxxxxx xx xxxx xxxxxx xx xxxx xxxx xxx xxxxxx'x XxxxxXxxxxx xxx xxxx xx xx x xxxx.

```csharp
Windows.Devices.Bluetooth.RfcommServiceProvider _provider;

async void Initialize()
{
    // Initialize the provider for the hosted RFCOMM service
    _provider = await Windows.Devices.Bluetooth.
        RfcommServiceProvider.CreateAsync(RfcommServiceId.ObexObjectPush);

    // Create a listener for this service and start listening
    StreamSocketListener listener = new StreamSocketListener();
    listener.ConnectionReceived += OnConnectionReceived;
    await listener.BindServiceNameAsync(
        _provider.ServiceId.AsString(),
        SocketProtectionLevel
            .BluetoothEncryptionAllowNullAuthentication);

    // Set the SDP attributes and start advertising
    InitializeServiceSdpAttributes(_provider);
    _provider.StartAdvertising();
}

const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint SERVICE_VERSION = 200;
void InitializeServiceSdpAttributes(RfcommServiceProvider provider)
{
    auto writer = new Windows.Storage.Streams.DataWriter();

    // First write the attribute type
    writer.WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE)
    // Then write the data
    writer.WriteUint32(SERVICE_VERSION);
    
    auto data = writer.DetachBuffer();
    provider.SdpRawAttributes.Add(SERVICE_VERSION_ATTRIBUTE_ID, data);
}

void OnConnectionReceived(
    StreamSocketListener listener,
    StreamSocketListenerConnectionReceivedEventArgs args)
{
    // Stop advertising/listening so that we’re only serving one client
    _provider.StopAdvertising();
    await listener.Close();
    _socket = args.Socket;

    // The client socket is connected. At this point the App can wait for
    // the user to take some action, e.g. click a button to receive a file
    // from the device, which could invoke the Picker and then save the
    // received file to the picked location. The transfer itself would use
    // the Sockets API and not the Rfcomm API, and so is omitted here for
    // brevity.
}
```

```cpp
Windows::Devices::Bluetooth::RfcommServiceProvider^ _provider;

void Initialize()
{
    // Initialize the provider for the hosted RFCOMM service
    create_task(Windows::Devices::Bluetooth.
        RfcommServiceProvider::CreateAsync(
            RfcommServiceId::ObexObjectPush))
    .then([](RfcommServiceProvider^ provider) -> task<void> {
        _provider = provider;

        // Create a listener for this service and start listening
        auto listener = ref new StreamSocketListener();
        listener->ConnectionReceived += ref new TypedEventHandler<
                StreamSocketListener^,
                StreamSocketListenerConnectionReceivedEventArgs^>
           (&amp;OnConnectionReceived);
        return create_task(listener->BindServiceNameAsync(
            _provider->ServiceId->AsString(),
            SocketProtectionLevel
                ::BluetoothEncryptionAllowNullAuthentication));
    }).then([listener](void) {
        // Set the SDP attributes and start advertising
        InitializeServiceSdpAttributes(_provider);
        _provider->StartAdvertising();
    });
}

const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
const uint SERVICE_VERSION = 200;
void InitializeServiceSdpAttributes(RfcommServiceProvider^ provider)
{
    auto writer = ref new Windows::Storage::Streams::DataWriter();

    // First write the attribute type
    writer->WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE)
    // Then write the data
    writer->WriteUint32(SERVICE_VERSION);
    
    auto data = writer->DetachBuffer();
    provider->SdpRawAttributes->Add(SERVICE_VERSION_ATTRIBUTE_ID, data);
}

void OnConnectionReceived(
    StreamSocketListener^ listener,
    StreamSocketListenerConnectionReceivedEventArgs^ args)
{
    // Stop advertising/listening so that we’re only serving one client
    _provider->StopAdvertising();
    create_task(listener->Close())
    .then([args](void) {
        _socket = args->Socket;

        // The client socket is connected. At this point the App can wait for
        // the user to take some action, e.g. click a button to receive a
        // file from the device, which could invoke the Picker and then save
        // the received file to the picked location. The transfer itself
        // would use the Sockets API and not the Rfcomm API, and so is
        // omitted here for brevity.
    });
}
```

<!--HONumber=Mar16_HO1-->
