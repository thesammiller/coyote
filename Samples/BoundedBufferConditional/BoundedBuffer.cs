// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

// With thanks to Tom Cargill and
// http://wiki.c2.com/?ExtremeProgrammingChallengeFourteen

using System.Threading;

namespace Microsoft.Coyote.Samples.BoundedBuffer
{
    public class BoundedBuffer
    {
        private readonly object SyncObject = new object();
        private int notEmpty;
        private int notFull;
        private readonly object[] Buffer;
        private readonly bool Conditional;
        private int PutAt;
        private int TakeAt;
        private int Occupied;

        public BoundedBuffer(int bufferSize, bool conditional = false)
        {
            this.Conditional = conditional;
            this.Buffer = new object[bufferSize];
        }

        public void Put(object x)
        {
            lock (this.SyncObject)
            {
                while (this.Occupied == this.Buffer.Length ||
                (this.Conditional && Interlocked.Exchange(ref this.notFull, 1) == 1))
                {
                    Monitor.Wait(this.SyncObject);
                }

                ++this.Occupied;
                this.PutAt %= this.Buffer.Length;
                this.Buffer[this.PutAt++] = x;
                Monitor.Pulse(this.SyncObject);
            }

            if (this.Conditional)
            {
                 // Release the lock
                Interlocked.Exchange(ref this.notEmpty, 0);
            }
        }

        public object Take()
        {
            object result = null;
            lock (this.SyncObject)
            {
                while (this.Occupied == 0 ||
                (this.Conditional && Interlocked.Exchange(ref this.notEmpty, 1) == 1))
                {
                    Monitor.Wait(this.SyncObject);
                }

                --this.Occupied;
                this.TakeAt %= this.Buffer.Length;
                result = this.Buffer[this.TakeAt++];
                Monitor.Pulse(this.SyncObject);
            }

            if (this.Conditional)
            {
                 // Release the lock
                Interlocked.Exchange(ref this.notFull, 0);
            }

            return result;
        }
    }
}
