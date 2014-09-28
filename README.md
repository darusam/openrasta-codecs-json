
#CDMSmith.OpenRasta.Legacy

Library containing tools for use with OpenRasta on .NET 2.0

Currently this library contains a simple JSON Codec for OpenRasta

`JsonCodec` may be used with `.TranscodedBy<JsonCodec>()` or with the extension `.AsJsonData()`

### Example

With `TranscodedBy`:
```
ResourceSpace.Has.ResourcesOfType<Home>()
  .AtUri("/home")
  .HandledBy<HomeHandler>()
  .TranscodedBy<JsonCodec>(null);
```

With `AsJsonData`:
```
ResourceSpace.Has.ResourcesOfType<Home>()
  .AtUri("/home")
  .HandledBy<HomeHandler>()
  .AsJsonData();
```
With [Json.NET](http://james.newtonking.com/json) and [LINQBridge](https://code.google.com/p/linqbridge/) this codec is fully compatible with .NET 2.0 and higher.
