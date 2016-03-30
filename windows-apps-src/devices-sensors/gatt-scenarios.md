---
xx.xxxxxxx: YYXYYYYY-XXYY-YXXY-XXYY-YYYYXYYYXYYY
xxxxx: Xxxxxxxxx XXXX
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxxx Xxxxxxx (XXXX) xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxxx xxxx xxxxxx xxxx xxx xxxxx xxxxxx XXXX xxxxxxxxx.
---
# Xxxxxxxxx XXXX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263413)
-   [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx.XxxxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297685)

Xxxx xxxxxxx xxxxxxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxxx Xxxxxxx (XXXX) xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxxx xxxx xxxxxx xxxx xxx xxxxx xxxxxx XXXX xxxxxxxxx: xxxxxxxxxx Xxxxxxxxx xxxx, xxxxxxxxxxx x Xxxxxxxxx XX xxxxxxxxxxx xxxxxx, xxx xxxxxxxxxxx xxx xxxxxxxxxxxx xx Xxxxxxxxx XX xxxxxx xxxx.

## Xxxxxxxx

Xxxxxxxxxx xxx xxx xxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx.XxxxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297685) xxxxxxxxx xx xxxxxx Xxxxxxxxx XX xxxxxxxx, xxxxxxxxxxx, xxx xxxxxxxxxxxxxxx. Xxxxxxxxx XX xxxxxxx xxxxxx xxxxx xxxxxxxxxxxxx xxxxxxx x xxxxxxxxxx xx:

-   Xxxxxxx Xxxxxxxx
-   Xxxxxxxx Xxxxxxxx
-   Xxxxxxxxxxxxxxx
-   Xxxxxxxxxxx

Xxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxxxx xxxxxxxx xx xxx XX xxxxxx xxx xxxxxxx x xxxxxxxxxx xx xxxxxxxxxxxxxxx xxxx xxxxxx xxx xxxxxxx. Xxxxx xxxxxxxxxxxxxxx, xx xxxx, xxxxxxx xxxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxxxxxxx.

Xxx Xxxxxxxxx XXXX XXXx xxxxxx xxxxxxx xxx xxxxxxxxx, xxxxxx xxxx xxxxxx xx xxx xxx xxxxxxxxx. Xx xxx xxxxxx xxxxx xxxxxxx xxxxxxxx xxx xxxxxxxxxx xx Xxxxx Xxxxxx Xxxxx xx xxx Xxxxxxxxx XX xxxxxx xxxxx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225459) XXXx.

Xxx Xxxxxxxxx XXXX XXXx xxxx xxxxxx xxxxxxxxxx xx xxxx xxxx Xxxxxxxxx XX xxxxxxx xxxx xxx xxxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxx:

-   Xxxxxxx Xxxxxxx / Xxxxxxxxxxxxxx / Xxxxxxxxxx xxxxxxxxx
-   Xxxx xxx Xxxxx Xxxxxxxxxxxxxx / Xxxxxxxxxx xxxxxx
-   Xxxxxxxx x xxxxxxxx xxx xxx Xxxxxxxxxxxxxx XxxxxXxxxxxx xxxxx

Xxx Xxxxxxxxx XXXX XXXx xxxxxxxx xxxxxxxxxxx xx xxxxxxx xxxx xxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xx xxx xx xxxxxx xxxxxxxxxx xxx xxxxxxxxxxxxx. Xxxx xxxxxxx x xxxxx xxx xxxxxxxxxx xx xxxxxx xxxxxxxxxxxxx xx x Xxxxxxxxx XX xxxxxx xxxx xx xxx.

Xx xxxxxx x xxxxxx xxxxxxxxxxxxxx x xxxxxxxxx xxx xx xxxx xxxxx xxxxxxxxx xx xxx XXXX xxxxxxxx xxx xxxxxxxxxxxxxxx xxx xxxxxxxxxxx xxxxxxx xx xxxxxxx, xxx xx xxxxxxx xxx xxxxxxxx xxxxxxxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxx xxxx xxxxxxxx xx xxx XXX xx xxxxxxxxxxx xxxx xxxxxx xxxx xxxxxx xxxxx xxxxxxxxx xx xxx xxxx. Xxx Xxxxxxxxx XXXX XXXx xxxxxx xxxx xxx xxxxx xxxxxxxxxx xxxxxxxx xx xxxxxxxxxxx xxxx x Xxxxxxxxx XX xxxxxx. Xx xxxxxxxxx xxx xxxx, xx xxxxxxxxxxx xxxxxxx xxxx xx xxxxxxx, xxxxxx xx x Xxxxxxxxx XXX xxxxxxxx xxxxxxx, xx x xxxxxx xxxxxxx xxxxxxxxxxx xx x xxxxxx xxxxxx. X xxxxxxx xxxxxxx x xxxxxxx xxxxxxxx xxxxxxx xxx xxxxxxxxxxx xxx xxx xxxxxx, xx xx xxxx xxx xxxxxxxxx xxxx xxxxxxxxxx xxx xxx xx xxxxxxxxx xx.

Xxx xxxxxxxxxxx xxx Xxxxxxxxx XXX xxxxxxxxx x [xxxx xx xxxxxx xxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=317977) xxxxxxxxx.

## Xxxxxxxx Xxxxxxxxx xxxx

Xx xxxx xxxxxxx, xxx xxx xxxxxxxx xxxxxxxxxxx xxxxxxxxxxxx xxxx x Xxxxxxxxx xxxxxx xxxx xxxxxxxxxx xxx Xxxxxxxxx XX Xxxxxx Xxxxxxxxxxx Xxxxxxx. Xxx xxx xxxxxxxxx xxxx xx xxxxx xx xx xxxxxxxx xxxx x xxx xxxxxxxxxxx xxxxxxxxxxx xx xxxxxxxxx. Xx xxxxxxxxxxx xx xxxxx xxxxxxx xxx xxx "Xxxxxxxxxxx Xxxxxxxxxxxxxx Xxxxx Xxxxxxx" xxxxx, xxx xxx xxxx xxxxxxx xxxxxxxxxxxxxx xxxxx xxxxxxx xxxxx xxxxxxxxxxxxx xxxxx xx xx xxxxxxx xx xxx xxxxxxxxxx.

Xxxx xxxx xxxx xxx xxx xx xxxxxxxxx, xx xxxx xxxxxxx xxx xxxxxx xxxxxxxxx xxx xxxx xx xxxxxxx, xx xxxx xxxxxxx xxxxxx xxxxxxxxxxx xxx xxxxxxxxxxxxxx xxxx xxxxx.

```csharp
double convertTemperatureData(byte[] temperatureData)
{
    // Read temperature data in IEEE 11703 floating point format
    // temperatureData[0] contains flags about optional data - not used
    UInt32 mantissa = ((UInt32)temperatureData[3] << 16) |
        ((UInt32)temperatureData[2] << 8) |
        ((UInt32)temperatureData[1]);

    Int32 exponent = (Int32)temperatureData[4];

    return mantissa * Math.Pow(10.0, exponent);
}

async void Initialize()
{
    var themometerServices = await Windows.Devices.Enumeration
        .DeviceInformation.FindAllAsync(GattDeviceService
            .GetDeviceSelectorFromUuid(
                GattServiceUuids.HealthThermometer),
        null);

    GattDeviceService firstThermometerService = await
        GattDeviceService.FromIdAsync(themometerServices[0].Id);

    serviceNameTextBlock.Text = "Using service: " + 
        themometerServices[0].Name;

    GattCharacteristic thermometerCharacteristic =
        firstThermometerService.GetCharacteristics(
            GattCharacteristicUuids.TemperatureMeasurement)[0];

    thermometerCharacteristic.ValueChanged += temperatureMeasurementChanged;

    await thermometerCharacteristic
        .WriteClientCharacteristicConfigurationDescriptorAsync(
            GattClientCharacteristicConfigurationDescriptorValue.Notify);
}

void temperatureMeasurementChanged(
    GattCharacteristic sender,
    GattValueChangedEventArgs eventArgs)
{
    byte[] temperatureData = new byte[eventArgs.CharacteristicValue.Length];
    Windows.Storage.Streams.DataReader.FromBuffer(
        eventArgs.CharacteristicValue).ReadBytes(temperatureData);

    var temperatureValue = convertTemperatureData(temperatureData);

    temperatureTextBlock.Text = temperatureValue.ToString();
}
```

```cpp
double MainPage::ConvertTemperatureData(
    const Array<unsigned char>^ temperatureData)
{
    unsigned mantissa = ((unsigned)temperatureData[3] << 16) |
        ((unsigned)temperatureData[2] << 8) |
        ((unsigned)temperatureData[1]);

    int exponent = (int)temperatureData[4];

    return mantissa * pow(10.0, (double)exponent);
}

void MainPage::Initialize()
{
    create_task(DeviceInformation::FindAllAsync(
        GattDeviceService::GetDeviceSelectorFromUuid(
            GattServiceUuids::HealthThermometer), 
        nullptr)).then(
            [this] (DeviceInformationCollection^ thermometerServices) 
    {
        create_task(GattDeviceService::FromIdAsync(
            thermometerServices->GetAt(0)->Id))
            .then([this] (GattDeviceService^ firstThermometerService) 
        {
            GattCharacteristic^ thermometerCharacteristic = 
                firstThermometerService->GetCharacteristics(
                    GattCharacteristicUuids::TemperatureMeasurement)
                        ->GetAt(0);

            thermometerCharacteristic->ValueChanged += 
                ref new TypedEventHandler<
                    GattCharacteristic^, 
                    GattValueChangedEventArgs^>(
                        this, &amp;MainPage::TemperatureMeasurementChanged);

            create_task(thermometerCharacteristic->
                WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue
                    ::Notify));
        });
    });
}


void MainPage::TemperatureMeasurementChanged(
    GattCharacteristic^ sender,
    GattValueChangedEventArgs^ eventArgs)
{
    auto temperatureData =  ref new Array<unsigned char>(
        eventArgs->CharacteristicValue->Length);
    DataReader::FromBuffer(eventArgs->CharacteristicValue)
        ->ReadBytes(temperatureData);

    double temperatureValue = ConvertTemperatureData(temperatureData);
    std::wstringstream str;
    str << temperatureValue;

    temperatureTextBlock->Text = ref new String(str.str().c_str());
}
```

## Xxxxxxx x Xxxxxxxxx XX xxxxxxxxxxx xxxxxx

Xx xxxx xxxxxxx, xx XXX xxx xxxx xx x xxxxxxxxxx xxx x xxxxxxxxxx Xxxxxxxxx XX Xxxxxxxxxxx xxxxxx. Xxx xxxxxx xxxx xxxxxxxx x xxxxxx xxxxxxxxxxxxxx xxxxx xxxxxx xxxxx xx xxxxxxxx xxx xxxxx xxxxxxx xx xxxxxx Xxxxxxx xx Xxxxxxxxxx xxxxxxx, xx xxxxxxxx xx xxx xxxxxxxx xxxxxxxxxxxxxxx xx xxx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297603) xxxxxxx. Xxx xxx xxxx xxxxxxxx xxxxx xxxxxxxxxxxx xx xxxx xxxx xxxx xxx xxxxxx xxx xxxxxxxxxxx xxxxxxxx xxx xxx xx x xxxxxx xxxxx.

```csharp
// Uuid of the "Format" Characteristic Value
Guid formatCharacteristicUuid = 
    new Guid("{00000000-0000-0000-0000-000000000010}");

// Constant representing a Fahrenheit scale temperature measurement
const byte FahrenheitReading = 1;
async void Initialize()
{
    var themometerServices = await Windows.Devices.Enumeration
        .DeviceInformation.FindAllAsync(GattDeviceService
            .GetDeviceSelectorFromUuid(
                GattServiceUuids.HealthThermometer),
        null);

    GattDeviceService thermometerService = await
        GattDeviceService.FromIdAsync(themometerServices[0].Id);

    serviceNameTextBlock.Text = "Using service: " + 
        themometerServices[0].Name;

    GattCharacteristic intervalCharacteristic = thermometerService
        .GetCharacteristics(GattCharacteristicUuids.MeasurementInterval)[0];

    GattCharacteristic formatCharacteristic = thermometerService
        .GetCharacteristics(formatCharacteristicUuid)[0];

    GattReliableWriteTransaction gattTransaction = 
        new GattReliableWriteTransaction();

    var writer = new Windows.Storage.Streams.DataWriter();

    // Get a temperature reading every 60 seconds
    writer.WriteUInt16(60);

    gattTransaction.WriteValue(
        intervalCharacteristic, 
        writer.DetachBuffer());

    // Get the reading on the Fahrenheit scale
    writer.WriteByte(FahrenheitReading);

    gattTransaction.WriteValue(
        formatCharacteristic, 
        writer.DetachBuffer());

    GattCommunicationStatus status = await gattTransaction.CommitAsync();

    if (GattCommunicationStatus.Unreachable == status)
    {
        statusTextBlock.Text = "Writing to your device failed !";
    }
}
```

```cpp
// Uuid of the "Format" Characteristic Value
Guid formatCharacteristicUuid(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 
                                  0x00, 0x00, 0x00, 0x00, 0x00, 0x10);

// Constant representing a Fahrenheit scale temperature measurement
const unsigned char FAHRENHEIT_READING = 1;

void MainPage::Initialize()
{
    create_task(DeviceInformation::FindAllAsync(
        GattDeviceService::GetDeviceSelectorFromUuid(
            GattServiceUuids::HealthThermometer), 
        nullptr)).then(
            [this] (DeviceInformationCollection^ thermometerServices) 
    {
        create_task(GattDeviceService::FromIdAsync(
            thermometerServices->GetAt(0)->Id)).then([this] (
                GattDeviceService^ thermometerService) 
        {
            GattCharacteristic^ intervalCharacteristic = 
                thermometerService->GetCharacteristics(
                    GattCharacteristicUuids::MeasurementInterval)
                        ->GetAt(0);

            GattCharacteristic^ formatCharacteristic = 
                thermometerService->GetCharacteristics(
                    formatCharacteristicUuid)->GetAt(0);

            GattReliableWriteTransaction^ gattTransaction = 
                ref new GattReliableWriteTransaction();

            DataWriter^ writer = ref new DataWriter();

            // Get a temperature reading every 60 seconds
            writer->WriteUInt16(60);

            gattTransaction->WriteValue(
                intervalCharacteristic, 
                writer->DetachBuffer());

            writer->WriteByte(FAHRENHEIT_READING);

            gattTransaction->WriteValue(
                formatCharacteristic, 
                writer->DetachBuffer());

            create_task(gattTransaction->CommitAsync())
                .then([this] (GattCommunicationStatus status) 
            {
                if (GattCommunicationStatus::Unreachable == status) 
                { 
                    statusTextBlock->Text = 
                        ref new String(L"Writing to your device failed !");
                }
            });
        });
    });

```

## Xxxxxxx xxx xxxxxxxxxxxx xx Xxxxxxxxx XX xxxxxx xxxx

X Xxxxxxxxx XX xxxxxxx xxx xxxxxx x xxxxxxx xxxxxxx xxxx xxxxxxxx xxx xxxxxxx xxxxxxx xxxxx xx xxx xxxx. Xxx xxxxxxx xxxxxxx xxxxxxxx xx xxxxxxxx [**XxxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263742) xxxxxxxxxx xxxxx xxxxxx xxxx xxxxxxxxxxx xx xxxxxxxxxxxxxx xx xxx xxxxxxx xxxxx xxxx. Xxxx xxxxxxxx xxxxxxxx xxxxxxx xx xx xxx xxxx xxxxx xxxx xxxx x xxxxxx xxx xxxx xxx **XxxxxxxxxxxxXxxxxxx** xxxxxxxx xx xxxxxx x xxxxxxxxxxxxxx xxxxx, xxxxxx xxxxxxxxxx xx xx xxx xxxx.

```csharp
async void Initialize()
{
    var batteryServices = await Windows.Devices.Enumeration
        .DeviceInformation.FindAllAsync(GattDeviceService
            .GetDeviceSelectorFromUuid(GattServiceUuids.Battery),
        null);

    if (batteryServices.Count > 0)
    {
        // Use the first Battery service on the system
        GattDeviceService batteryService = await GattDeviceService
            .FromIdAsync(batteryServices[0].Id);

        // Use the first Characteristic of that Service
        GattCharacteristic batteryLevelCharacteristic =
            batteryService.GetCharacteristics(
                GattCharacteristicUuids.BatteryLevel)[0];

        batteryLevelCharacteristic.ValueChanged += batteryLevelChanged;
    }
    else
    {
        statusTextBlock.Text = "No Battery services found !";
    }
}

void batteryLevelChanged(
    GattCharacteristic sender,
    GattValueChangedEventArgs eventArgs)
{
    byte levelData = Windows.Storage.Streams.DataReader
        .FromBuffer(eventArgs.CharacteristicValue).ReadByte();

    double levelValue;

    if (sender.PresentationFormats.Count > 0)
    {
        levelValue = levelData * 
            Math.Pow(10.0, sender.PresentationFormats[0].Exponent);
    }
    else
    {
        levelValue = (double)levelData;
    }

    batteryLevelTextBlock.Text = levelValue.ToString();
}
```

```cpp
void MainPage::Initialize()
{
    create_task(DeviceInformation::FindAllAsync(
        GattDeviceService::GetDeviceSelectorFromUuid(
            GattServiceUuids::Battery), 
        nullptr)).then([this] (DeviceInformationCollection^ batteryServices) 
    {
        create_task(GattDeviceService::FromIdAsync(
            batteryServices->GetAt(0)->Id)).then([this] (
                GattDeviceService^ batteryService) 
        {
            GattCharacteristic^ batteryLevelCharacteristic = 
                batteryService->GetCharacteristics(
                    GattCharacteristicUuids::BatteryLevel)->GetAt(0);

            batteryLevelCharacteristic->ValueChanged += 
                ref new TypedEventHandler<
                    GattCharacteristic^, 
                    GattValueChangedEventArgs^>
                    (this, &amp;MainPage::BatteryLevelChanged);

            create_task(batteryLevelCharacteristic
                ->WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue
                    ::Notify));
        });
    });
}

void MainPage::BatteryLevelChanged(
    GattCharacteristic^ sender,
    GattValueChangedEventArgs^ eventArgs)
{
    unsigned char batteryLevelData = DataReader::FromBuffer(
        eventArgs->CharacteristicValue)->ReadByte();

    // if this characteristic has a presentation format
    // use that information to format the value
    double batteryLevelValue;
    if (sender->PresentationFormats->Size > 0)
    {
        batteryLevelValue = batteryLevelData * 
            pow(10.0, sender->PresentationFormats->GetAt(0)->Exponent);
    }
    else
    {
        batteryLevelValue = batteryLevelData;
    }

    std::wstringstream str;
    str << batteryLevelValue;
    batteryLevelTextBlock->Text = 
        ref new String(str.str().c_str());
}
```



<!--HONumber=Mar16_HO1-->
