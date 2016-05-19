using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.IO
{
    public class NotificationMemoryStream : MemoryStream
    {

        public event EventHandler Flushed;
        public event EventHandler WriteCompleted;

        public NotificationMemoryStream() : base() { }

        public NotificationMemoryStream(int capacity) : base(capacity) { }

        public NotificationMemoryStream(byte[] buffer) : base(buffer) { }

        public NotificationMemoryStream(byte[] buffer, bool writable) : base(buffer, writable) { }

        public NotificationMemoryStream(byte[] buffer, int index, int count) : base(buffer, index, count) { }

        public NotificationMemoryStream(byte[] buffer, int index, int count, bool writable) : base(buffer, index, count, writable) { }

        public NotificationMemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible) : base(buffer, index, count, writable, publiclyVisible) { }

        public override void Flush()
        {
            base.Flush();
            OnFlushed(new EventArgs());
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            OnWriteCompleted(new EventArgs());
        }

        protected virtual void OnWriteCompleted(EventArgs e)
        {
            if (WriteCompleted != null) WriteCompleted(this, e);
        }

        protected virtual void OnFlushed(EventArgs e)
        {
            if (Flushed != null) Flushed(this, e);
        }
    }
}
