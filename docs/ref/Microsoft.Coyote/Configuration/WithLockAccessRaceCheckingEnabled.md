# Configuration.WithLockAccessRaceCheckingEnabled method

Updates the configuration with race checking for lock accesses enabled or disabled. If this race checking strategy is enabled, then the runtime will explore interleavings when concurrent operations try to access lock-based synchronization primitives.

```csharp
public Configuration WithLockAccessRaceCheckingEnabled(bool isEnabled = true)
```

| parameter | description |
| --- | --- |
| isEnabled | If true, then checking races during lock accesses is enabled. |

## See Also

* class [Configuration](../Configuration.md)
* namespace [Microsoft.Coyote](../Configuration.md)
* assembly [Microsoft.Coyote](../../Microsoft.Coyote.md)

<!-- DO NOT EDIT: generated by xmldocmd for Microsoft.Coyote.dll -->
