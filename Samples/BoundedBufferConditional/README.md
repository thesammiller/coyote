## BoundedBufferConditional

This is an update to the BoundedBuffer sample which uses a different strategy to resolve the bug.

Markus Kuppe [shared on Twitter](https://twitter.com/lemmster/status/1597260119213240320) that, "Most textbook solutions and runtime implementations... use two conditionals instead of notifyAll/pulseAll."

This implementation uses the same commands as the original sample, namely:
 
 ```
 dotnet build
 coyote rewrite ../bin/net6.0/BoundedBuffer.dll 
 coyote test ../bin/net6.0/BoundedBuffer.dll -m TestBoundedBufferMinimalDeadlock -i 100
 coyote test ../bin/net6.0/BoundedBuffer.dll -m TestBoundedBufferMinimalDeadlock -i 100 --explore
 coyote test ../bin/net6.0/BoundedBuffer.dll -m TestBoundedBufferNoDeadlock -i 100 --explore
```

Additional references:

- [Conditional Blocking Queue in TLA+](https://github.com/lemmy/BlockingQueue#v13-bugfix-logically-two-mutexes)
- [Conditional Blocking Queue Example from JDK](https://github.com/openjdk-mirror/jdk7u-jdk/blob/f4d80957e89a19a29bb9f9807d2a28351ed7f7df/src/share/classes/java/util/concurrent/ArrayBlockingQueue.java#L106-L108)
- [Interlocked dotnet Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked?view=net-7.0)


See the original sample for Coyote tutorial content:

- [Bounded Buffer](https://github.com/microsoft/coyote/tree/main/Samples/BoundedBuffer).
