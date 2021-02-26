using System;

namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    // Taken from https://stackoverflow.com/questions/39742515/stream-copytoasync-with-progress-reporting-progress-is-reported-even-after-cop
    //
    // Author Credit: Stephen Cleary

    public sealed class SynchronousProgress<T> : IProgress<T>
	{
		private readonly Action<T> _callback;
		public SynchronousProgress(Action<T> callback) { _callback = callback; }
		void IProgress<T>.Report(T data) => _callback(data);
	}
}
